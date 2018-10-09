using System;
using System.Collections.Generic;
using System.Linq;
using Clang;
using Clang.Ast;
using Mono.Cecil;
using static Extrospection.Helpers;

namespace Extrospection
{
	public class DeprecatedCheck : BaseVisitor
	{
		Dictionary<string, VersionTuple> ObjCDeprecatedItems = new Dictionary<string, VersionTuple> ();
		Dictionary<string, VersionTuple> ObjCDeprecatedSelectors = new Dictionary<string, VersionTuple> ();

		List<TypeDefinition> ManagedTypes = new List<TypeDefinition> ();

		public override void End ()
		{
			foreach (var objcEntry in ObjCDeprecatedItems)
				ProcessObjcEntry (objcEntry.Key, objcEntry.Value);

			foreach (var objcEntry in ObjCDeprecatedSelectors)
				ProcessObjcSelector (objcEntry.Key, objcEntry.Value);
		}

		void ProcessObjcEntry (string objcClassName, VersionTuple objcVersion)
		{
			TypeDefinition managedType = ManagedTypes.FirstOrDefault (x => Helpers.GetName (x) == objcClassName && x.IsPublic);
			if (managedType != null) {
				
				// In some cases we've used [Advice] when entire types are deprecated
				if (Helpers.HasAdvicedAttribute (managedType.CustomAttributes))
					return;

				var framework = Helpers.GetFramework (managedType);
				if (framework != null)
					ProcessItem (managedType, Helpers.GetName (managedType), objcVersion, framework);
			}
		}

		void ProcessObjcSelector (string fullname, VersionTuple objcVersion)
		{
			string[] nameParts = fullname.Split (new string[] { "::" }, StringSplitOptions.None);

			string objcClassName = nameParts[0];
			string selector = nameParts[1];

			TypeDefinition managedType = ManagedTypes.FirstOrDefault (x => Helpers.GetName (x) == objcClassName);
			if (managedType != null) {

				var framework = Helpers.GetFramework (managedType);
				if (framework == null)
					return;

				// If the entire type is deprecated, call it good enough
				if (HasAnyDeprecationAttribute (managedType.CustomAttributes))
					return;

				var matchingMethod = managedType.Methods.FirstOrDefault (x => x.GetSelector () == selector && x.IsPublic);
				if (matchingMethod != null)
					ProcessItem (matchingMethod, fullname, objcVersion, framework);
			}
		}

		public void ProcessItem (ICustomAttributeProvider item, string itemName, VersionTuple objcVersion, string framework)
		{
			if (!Helpers.VersionTooOldToCare (objcVersion)) {
				if (!HasAnyDeprecationAttribute (item.CustomAttributes))
				{
					Log.On (framework).Add ($"!deprecated-attribute-missing! {itemName} missing a [Deprecated] attribute");
					return;
				}

				// Some APIs have both a [Deprecated] and [Obsoleted]. Bias towards [Obsoleted].
				Version managedVersion;
				bool foundObsoleted = Helpers.FindManagedObsoleteAttribute (item.CustomAttributes, out managedVersion);
				if (foundObsoleted) {
					if (managedVersion != null && !Helpers.CompareManagedToObjcVersion (objcVersion, managedVersion))
						Log.On (framework).Add ($"!deprecated-attribute-wrong! {itemName} has {managedVersion} not {objcVersion} on [Obsoleted] attribute");
					return;
				}

				bool foundDeprecated = Helpers.FindManagedDeprecatedAttribute (item.CustomAttributes, out managedVersion);
				if (foundDeprecated && managedVersion != null && !Helpers.CompareManagedToObjcVersion (objcVersion, managedVersion))
					Log.On (framework).Add ($"!deprecated-attribute-wrong! {itemName} has {managedVersion} not {objcVersion} on [Deprecated] attribute");
			}
		}

		static bool HasAnyDeprecationAttribute (IEnumerable<CustomAttribute> attributes)
		{
			// If we want to force seperate tv\watch attributes instead of accepting iOS
			// Then remove GetRelatedPlatforms and just check Helpers.Platform
			Platforms[] platforms = GetRelatedPlatforms ();
			foreach (var attribute in attributes) {
				if (platforms.Any (x => Helpers.HasDeprecatedAttribute (attribute, x)) || platforms.Any (x => Helpers.HasObsoletedAttribute (attribute, x)))
					return true;
			}
			return false;
		}

		static Platforms[] GetRelatedPlatforms ()
		{
			// TV and Watch also implictly accept iOS
			switch (Helpers.Platform)
			{
			case Platforms.macOS:
				return new Platforms[] { Platforms.macOS };
			case Platforms.iOS:
				return new Platforms[] { Platforms.iOS };
			case Platforms.tvOS:
				return new Platforms[] { Platforms.iOS, Platforms.tvOS };
			case Platforms.watchOS:
				return new Platforms[] { Platforms.iOS, Platforms.watchOS };
			default:
				throw new InvalidOperationException ($"Unknown {Platform} in GetPlatforms");
			}
		}

		public override void VisitManagedType (TypeDefinition type)
		{
			ManagedTypes.Add (type);
		}

		void VisitItem (NamedDecl decl, VisitKind visitKind)
		{
			if (visitKind == VisitKind.Enter && Helpers.FindObjcDeprecatedAttribute (decl.Attrs, out VersionTuple version))
				ObjCDeprecatedItems[decl.Name] = version;
		}

		public override void VisitObjCCategoryDecl (ObjCCategoryDecl decl, VisitKind visitKind) => VisitItem (decl, visitKind);
		public override void VisitObjCInterfaceDecl (ObjCInterfaceDecl decl, VisitKind visitKind) => VisitItem (decl, visitKind);

		public override void VisitObjCMethodDecl (ObjCMethodDecl decl, VisitKind visitKind)
		{
			if (visitKind == VisitKind.Enter && Helpers.FindObjcDeprecatedAttribute(decl.Attrs, out VersionTuple version))
				ObjCDeprecatedSelectors[decl.QualifiedName] = version;
		}
	}
}

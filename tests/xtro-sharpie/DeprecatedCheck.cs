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
				if (Helpers.HasDeprecatedAttribute (managedType.CustomAttributes, GetRelatedPlatforms ()))
					return;

				var matchingMethod = managedType.Methods.FirstOrDefault (x => x.GetSelector () == selector && x.IsPublic);
				if (matchingMethod != null)
					ProcessItem (matchingMethod, fullname, objcVersion, framework);
			}
		}

		public void ProcessItem (ICustomAttributeProvider item, string itemName, VersionTuple objcVersion, string framework)
		{
			if (!Helpers.VersionTooOldToCare (objcVersion)) {
				if (!Helpers.HasDeprecatedAttribute (item.CustomAttributes, GetRelatedPlatforms ()))
				{
					Log.On (framework).Add ($"!deprecated-attribute-missing! {itemName} missing a [Deprecated] attribute");
					return;
				}

				if (Helpers.FindManagedDeprecatedAttribute (item.CustomAttributes, out Version managedVersion)) {
					if (!Helpers.CompareManagedToObjcVersion (objcVersion, managedVersion))
						Log.On (framework).Add ($"!deprecated-attribute-wrong! {itemName} missing has {managedVersion} not {objcVersion} on [Deprecated] attribute");
				}
			}
		}

		IEnumerable<Platforms> GetRelatedPlatforms ()
		{
			// TV and Watch also implictly accept iOS
			switch (Platform)
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
				throw new InvalidOperationException ($"Unknown platform {Platform} in GetPlatforms");
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

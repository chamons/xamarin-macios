using System;
using System.Collections.Generic;
using System.Linq;
using Clang;
using Clang.Ast;
using Mono.Cecil;

namespace Extrospection
{
	public class DeprecatedCheck : BaseVisitor
	{
		Dictionary<string, VersionTuple> ObjCDeprecatedItems = new Dictionary<string, VersionTuple> ();
		Dictionary<string, VersionTuple> ObjCDeprecatedSelectors = new Dictionary<string, VersionTuple> ();

		List<TypeDefinition> ManagedTypes = new List<TypeDefinition> ();

		public override void End ()
		{
			foreach (var objcEntry in ObjCDeprecatedItems) {
				string objcClassName = objcEntry.Key;
				VersionTuple objcVersion = objcEntry.Value;

				TypeDefinition managedType = ManagedTypes.FirstOrDefault (x => Helpers.GetName (x) == objcClassName);
				if (managedType != null) {

					var framework = Helpers.GetFramework (managedType);
					if (framework == null)
						return;

					if (!Helpers.VersionTooOldToCare (objcVersion)) {
						if (Helpers.FindManagedDeprecatedAttribute (managedType.CustomAttributes, out Version managedVersion)) {
							if (!Helpers.CompareManagedToObjcVersion (objcVersion, managedVersion))
								Log.On (framework).Add ($"!deprecated-attribute-wrong! {Helpers.GetName (managedType)} missing has {managedVersion} not {objcVersion} on [Deprecated] attribute");
						} else {
							Log.On (framework).Add ($"!deprecated-attribute-missing! {Helpers.GetName (managedType)} missing a [Deprecated] attribute");
						}
					}
				}
			}

			foreach (var objcEntry in ObjCDeprecatedSelectors) {
				string [] nameParts = objcEntry.Key.Split (new string[] { "::" }, StringSplitOptions.None);
				string objcClassName = nameParts[0];
				string selector = nameParts[1];

				VersionTuple objcVersion = objcEntry.Value;

				TypeDefinition managedType = ManagedTypes.FirstOrDefault (x => Helpers.GetName (x) == objcClassName);
				if (managedType != null) {

					var framework = Helpers.GetFramework (managedType);
					if (framework == null)
						return;

					// If the entire type is deprecated, call it good enough
					if (Helpers.FindManagedDeprecatedAttribute (managedType.CustomAttributes, out Version managedVersionOnType)) {
						continue;
					}

					var matchingMethod = managedType.Methods.FirstOrDefault (x => x.GetSelector () == selector);
					if (matchingMethod != null && !Helpers.VersionTooOldToCare (objcVersion)) {
						if (Helpers.FindManagedDeprecatedAttribute (matchingMethod.CustomAttributes, out Version managedVersionOnMethod)) {
							if (!Helpers.CompareManagedToObjcVersion (objcVersion, managedVersionOnMethod))
								Log.On (framework).Add ($"!deprecated-attribute-wrong! {objcEntry.Key} missing has {managedVersionOnMethod} not {objcVersion} on [Deprecated] attribute");
						} else {
							Log.On (framework).Add ($"!deprecated-attribute-missing! {objcEntry.Key} missing a [Deprecated] attribute");
						}
					}
				}
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

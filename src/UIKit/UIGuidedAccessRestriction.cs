//
// UIGuidedAccessRestriction
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyrigh 2013-2014 Xamarin Inc.
//

#if !WATCH

using System;
using System.Runtime.InteropServices;

using XamCore.Foundation;
using XamCore.ObjCRuntime;
using XamCore.UIKit;

namespace XamCore.UIKit {

	// NSInteger -> UIGuidedAccessRestrictions.h
	[Native]
	[Introduced (PlatformName.iOS, 7, 0)]
	public enum UIGuidedAccessRestrictionState : long {
		Allow,
		Deny
	}

	public static partial class UIGuidedAccessRestriction {
#if !COREBUILD
		[Introduced (PlatformName.iOS, 7, 0)]
		[DllImport (Constants.UIKitLibrary)]
		extern static /* UIGuidedAccessRestrictionState */ nint UIGuidedAccessRestrictionStateForIdentifier (/* NSString */ IntPtr restrictionIdentifier);

		[Introduced (PlatformName.iOS, 7, 0)]
		public static UIGuidedAccessRestrictionState GetState (string restrictionIdentifier)
		{
			IntPtr p = NSString.CreateNative (restrictionIdentifier);
			var result = UIGuidedAccessRestrictionStateForIdentifier (p);
			NSString.ReleaseNative (p);
			return (UIGuidedAccessRestrictionState) (int) result;
		}
#endif // !COREBUILD
	}

#if !XAMCORE_2_0
	[Obsolete ("Use IUIGuidedAccessRestrictionDelegate")]
	public interface IUIGuidedAccessRestriction : INativeObject {

		string [] GetGuidedAccessRestrictionIdentifiers { get; }

		void GuidedAccessRestrictionChangedState (string restrictionIdentifier, UIGuidedAccessRestrictionState newRestrictionState);

		string GetTextForGuidedAccessRestriction  (string restrictionIdentifier);

		string GetDetailTextForGuidedAccessRestriction (string restrictionIdentifier);
	}
#endif
}

#endif // !WATCH

// Copyright 2014 Xamarin Inc. All rights reserved.

#if IOS

using System;
using XamCore.CoreGraphics;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using AvailabilityAttribute = XamCore.ObjCRuntime.Extensions.AvailabilityAttribute;
using Platform = XamCore.ObjCRuntime.Extensions.Platform;


namespace XamCore.UIKit {

	public partial class UIPopoverPresentationController {

		// cute helper to avoid using `Class` in the public API
		public virtual Type PopoverBackgroundViewType {
			get {
				IntPtr p = PopoverBackgroundViewClass;
				if (p == IntPtr.Zero)
					return null;
				return Class.Lookup (p);
			}
			set {
				PopoverBackgroundViewClass =  (value == null) ? IntPtr.Zero : 
					Class.GetHandle (value);
			}
		}
	}

#if !XAMCORE_3_0
	public partial class UIPopoverPresentationControllerDelegate {
		[Obsolete ("Use the overload with 'ref' parameters for 'targetRect' and 'inView'.")]
		public virtual void WillRepositionPopover (UIPopoverPresentationController popoverPresentationController, CGRect targetRect, UIView inView)
		{
		}
	}

	public static partial class UIPopoverPresentationControllerDelegate_Extensions {
		[Obsolete ("Use the overload with 'ref' parameters for 'targetRect' and 'inView'.")]
		public static void WillRepositionPopover (IUIPopoverPresentationControllerDelegate This, UIPopoverPresentationController popoverPresentationController, CGRect targetRect, UIView inView)
		{
		}
	}
#endif
}

#endif // IOS

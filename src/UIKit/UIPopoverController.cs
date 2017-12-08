// Copyright 2012 Xamarin Inc. All rights reserved.

#if !WATCH

using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.UIKit {

	public partial class UIPopoverController {

		[iOS (5,0)]
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
}

#endif // !WATCH

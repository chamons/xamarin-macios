#if !XAMCORE_3_0

using System;
using System.Runtime.InteropServices;

using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.UIKit {
	public static class UIPrint {

		static NSString _ErrorDomain;
		public static NSString ErrorDomain {
			get {
				if (_ErrorDomain == null)
					_ErrorDomain = Dlfcn.GetStringConstant (Libraries.UIKit.Handle, "UIPrintErrorDomain");
				return _ErrorDomain;
			}
		}
	
	}
}

#endif

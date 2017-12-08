#if !WATCH
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.UIKit {
	public partial class UINavigationController {
		static IntPtr LookupClass (Type t)
		{
			return t == null ? IntPtr.Zero : Class.GetHandle (t);
		}
		
		public UINavigationController (Type navigationBarType, Type toolbarType) : this (LookupClass (navigationBarType), LookupClass (toolbarType))
		{
		}
						      
	}
}

#endif // !WATCH

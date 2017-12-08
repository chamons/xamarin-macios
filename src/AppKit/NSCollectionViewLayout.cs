using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.AppKit {

	public partial class NSCollectionViewLayout {
		public void RegisterClassForDecorationView (Type itemClass, NSString elementKind)
		{
			_RegisterClassForDecorationView (itemClass == null ? IntPtr.Zero : Class.GetHandle (itemClass), elementKind);
		}
	}
}

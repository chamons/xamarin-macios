using System;

using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.CoreGraphics;

namespace XamCore.CoreAnimation {

	partial class CAScrollLayer {

		public CAScroll Scroll {
			get { return CAScrollExtensions.GetValue (ScrollMode); }
			set { ScrollMode = value.GetConstant (); }
		}
	}
}

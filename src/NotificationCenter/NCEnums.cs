using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreGraphics;
using XamCore.CoreLocation;

#if !MONOMAC
using XamCore.UIKit;
#endif

namespace XamCore.NotificationCenter {

	[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	public enum NCUpdateResult : ulong {
		NewData,
		NoData,
		Failed
	}

	[Introduced (PlatformName.iOS, 10, 0)][Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum NCWidgetDisplayMode : long {
		Compact,
		Expanded
	}
}
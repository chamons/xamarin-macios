using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;
using XamCore.CoreGraphics;
using XamCore.AppKit;

using System;
using System.ComponentModel;

namespace XamCore.QuickLookUI {
	public partial class QLPreviewPanel
	{
		public bool EnterFullScreenMode ()
		{
			return EnterFullScreenMode (null, null);
		}

		public void ExitFullScreenModeWithOptions ()
		{
			ExitFullScreenModeWithOptions (null);
		}
	}
}

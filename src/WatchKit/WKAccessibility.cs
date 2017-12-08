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

#if WATCH

namespace XamCore.WatchKit {

	public partial class WKAccessibility {

		[DllImport (Constants.WatchKitLibrary)]
		static extern bool WKAccessibilityIsVoiceOverRunning ();

		static public bool IsVoiceOverRunning {
			get { return WKAccessibilityIsVoiceOverRunning (); }
		}

		[Watch (4,0)]
		[DllImport (Constants.WatchKitLibrary)]
		static extern bool WKAccessibilityIsReduceMotionEnabled ();

		[Watch (4,0)]
		static public bool IsReduceMotionEnabled {
			get { return WKAccessibilityIsReduceMotionEnabled (); }
		}
	}
}

#endif
using System;
using System.Runtime.InteropServices;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

#if WATCH

namespace XamCore.WatchKit {

	public partial class WKAccessibility {

		[DllImport (Constants.WatchKitLibrary)]
		static extern bool WKAccessibilityIsVoiceOverRunning ();

		static public bool IsVoiceOverRunning {
			get { return WKAccessibilityIsVoiceOverRunning (); }
		}

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[DllImport (Constants.WatchKitLibrary)]
		static extern bool WKAccessibilityIsReduceMotionEnabled ();

		[Introduced (PlatformName.WatchOS, 4, 0)]
		static public bool IsReduceMotionEnabled {
			get { return WKAccessibilityIsReduceMotionEnabled (); }
		}
	}
}

#endif
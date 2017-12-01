//
// 
//

#if !WATCH

using System;
using System.Runtime.InteropServices;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
using XamCore.MapKit;

namespace XamCore.MapKit {
	public partial class MKOverlayView {

		[Introduced (PlatformName.TvOS, 9, 2)]
		[Introduced (PlatformName.MacOSX, 10, 9, PlatformArchitecture.Arch64)]
		[DllImport (Constants.MapKitLibrary)]
		public static extern nfloat MKRoadWidthAtZoomScale (/* MKZoomScale */ nfloat zoomScale);
	}
}

#endif
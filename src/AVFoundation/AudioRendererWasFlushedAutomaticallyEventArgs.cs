#if !WATCH
using XamCore.Foundation;
using XamCore.CoreMedia;
using XamCore.ObjCRuntime;

namespace XamCore.AVFoundation {

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	public partial class AudioRendererWasFlushedAutomaticallyEventArgs {
		public CMTime AudioRendererFlushTime { 
			get {
				return _AudioRendererFlushTime.CMTimeValue;
			}
		}
	}
}
#endif
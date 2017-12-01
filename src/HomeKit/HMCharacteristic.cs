using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.HomeKit {

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	partial class HMCharacteristic 
	{
		public bool SupportsEventNotification {
			get {
				foreach (var p in Properties){
					if (p == HMCharacteristicPropertyInternal.SupportsEventNotification)
						return true;
				}
				return false;
			}
		}
		
		public bool Readable {
			get {
				foreach (var p in Properties){
					if (p == HMCharacteristicPropertyInternal.Readable)
						return true;
				}
				return false;
			}
		}

		public bool Writable {
			get {
				foreach (var p in Properties){
					if (p == HMCharacteristicPropertyInternal.Writable)
						return true;
				}
				return false;
			}
		}

		[Introduced (PlatformName.iOS, 9, 3)][Introduced (PlatformName.WatchOS, 2, 2)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		public bool Hidden {
			get {
				foreach (var p in Properties) {
					if (p == HMCharacteristicPropertyInternal.Hidden)
						return true;
				}
				return false;
			}
		}
	}
}
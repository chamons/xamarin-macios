using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.HomeKit {

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public class HMCharacteristicProperties {

		public bool SupportsChangeNumber { get; set; }

		public bool SupportsBonjourNotification { get; set; }

		public bool SupportsEventNotification { get; set; }

		public bool Readable { get; set; }

		public bool Writable { get; set; }
	}
}
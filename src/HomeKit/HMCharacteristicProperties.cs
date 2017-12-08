using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.HomeKit {

	[iOS (8,0)]
	[TV (10,0)]
	public class HMCharacteristicProperties {

		public bool SupportsChangeNumber { get; set; }

		public bool SupportsBonjourNotification { get; set; }

		public bool SupportsEventNotification { get; set; }

		public bool Readable { get; set; }

		public bool Writable { get; set; }
	}
}
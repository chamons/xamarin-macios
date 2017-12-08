using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.HomeKit {

	partial class HMMutableSignificantTimeEvent {

		public virtual HMSignificantEvent SignificantEvent {
			get {
				return (HMSignificantEvent) (HMSignificantEventExtensions.GetValue (_SignificantEvent));
			}
			set {
				_SignificantEvent = HMSignificantEventExtensions.GetConstant (value);
			}
		}
	}
}

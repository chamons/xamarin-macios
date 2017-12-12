using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif

namespace XamCore.HomeKit {

	partial class HMSignificantTimeEvent {

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

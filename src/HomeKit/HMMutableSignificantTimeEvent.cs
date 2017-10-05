using System;
using ObjCRuntime;

namespace HomeKit {

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

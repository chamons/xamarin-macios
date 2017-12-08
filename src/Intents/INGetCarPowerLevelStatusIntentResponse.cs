// INGetCarPowerLevelStatusIntentResponse.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0 && (IOS || TVOS)

using XamCore.Foundation;
using XamCore.Intents;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Intents {

	public partial class INGetCarPowerLevelStatusIntentResponse {

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public float? FuelPercentRemaining {
			get { return _FuelPercentRemaining == null ? null : (float?) _FuelPercentRemaining.FloatValue; }
		}

		public float? ChargePercentRemaining {
			get { return _ChargePercentRemaining == null ? null : (float?) _ChargePercentRemaining.FloatValue; }
		}
	}
}

#endif

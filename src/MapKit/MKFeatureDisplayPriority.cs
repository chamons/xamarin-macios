#if XAMCORE_2_0 || !MONOMAC
using System;
using ObjCRuntime;

namespace MapKit {

	// .net does not allow float-based enumerations
	[Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.WatchOS)][Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	public static class MKFeatureDisplayPriority {
		public const float Required = 1000f;
		public const float DefaultHigh = 750f;
		public const float DefaultLow = 250f;
	}
}

#endif
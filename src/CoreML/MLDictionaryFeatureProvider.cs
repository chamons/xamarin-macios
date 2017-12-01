//
// MLDictionaryFeatureProvider.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.CoreML {
	public partial class MLDictionaryFeatureProvider {

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public MLFeatureValue this [string featureName] {
			get { return GetFeatureValue (featureName); }
		}
	}
}
#endif

// Copyright 2016 Xamarin Inc. All rights reserved.

using System;
using XamCore.CoreGraphics;
using XamCore.Foundation;
using XamCore.HealthKit;
using XamCore.ObjCRuntime;
using XamCore.UIKit;

namespace XamCore.HealthKitUI {

	[Introduced (PlatformName.iOS, 9, 3), Introduced (PlatformName.WatchOS, 2, 2)]
	[BaseType (typeof (UIView))]
	[DisableDefaultCtor] // nil handle (introspection)
	interface HKActivityRingView {

		// inlined from UIView
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed, Export ("activitySummary", ArgumentSemantic.Strong)]
		HKActivitySummary ActivitySummary { get; set; }

		[Export ("setActivitySummary:animated:")]
		void SetActivitySummary ([NullAllowed] HKActivitySummary activitySummary, bool animated);
	}
}

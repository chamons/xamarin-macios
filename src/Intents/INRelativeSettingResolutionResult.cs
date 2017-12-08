//
// INRelativeSettingResolutionResult.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0 && !MONOMAC
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Intents {
	public partial class INRelativeSettingResolutionResult {

		public static INRelativeSettingResolutionResult GetSuccess (INRelativeSetting resolvedValue)
		{
#if IOS
			if (XamCore.UIKit.UIDevice.CurrentDevice.CheckSystemVersion (11, 0))
#elif WATCH
			if (XamCore.WatchKit.WKInterfaceDevice.CurrentDevice.CheckSystemVersion (4, 0))
#endif
				return SuccessWithResolvedRelativeSetting (resolvedValue);
			else
				return SuccessWithResolvedValue (resolvedValue);
		}

		public static INRelativeSettingResolutionResult GetConfirmationRequired (INRelativeSetting valueToConfirm)
		{
#if IOS
			if (XamCore.UIKit.UIDevice.CurrentDevice.CheckSystemVersion (11, 0))
#elif WATCH
			if (XamCore.WatchKit.WKInterfaceDevice.CurrentDevice.CheckSystemVersion (4, 0))
#endif
				return ConfirmationRequiredWithRelativeSettingToConfirm (valueToConfirm);
			else
				return ConfirmationRequiredWithValueToConfirm (valueToConfirm);
		}
	}
}
#endif

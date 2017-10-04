// 
// AVCaptureDeviceDiscoverySession.cs
//
// Authors:
//	Alex Soto (alexsoto@microsoft.com)
//     
// Copyright 2016 Xamarin Inc.
//

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.AVFoundation {
#if IOS
	public partial class AVCaptureDeviceDiscoverySession {
		[Introduced (PlatformName.iOS, 10, 0)]
		public static AVCaptureDeviceDiscoverySession Create (AVCaptureDeviceType [] deviceTypes, string mediaType, AVCaptureDevicePosition position)
		{
			var arr = new NSMutableArray ();
			foreach (var device in deviceTypes)
				arr.Add (device.GetConstant ());

			return _Create (arr, mediaType, position);
		}
	}
#endif
}

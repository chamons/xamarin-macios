//
// EAEnums.cs: API definition for ExternalAccessory binding
//
// Copyright 2012-2014 Xamarin Inc. All rights reserved.
//
using System;
using Foundation;
using ObjCRuntime;

namespace ExternalAccessory {

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	[Flags]
	public enum EAWiFiUnconfiguredAccessoryProperties : ulong {
		SupportsAirPlay  = (1 << 0),
		SupportsAirPrint = (1 << 1),
		SupportsHomeKit  = (1 << 2), // iOS 8 beta 5
	}

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum EAWiFiUnconfiguredAccessoryBrowserState : long {
		WiFiUnavailable = 0,
		Stopped,
		Searching,
		Configuring,
	}

	// NSInteger -> EAWiFiUnconfiguredAccessoryBrowser.h
	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum EAWiFiUnconfiguredAccessoryConfigurationStatus : long {
		Success,
		UserCancelledConfiguration,
		Failed,
	}

	// NSInteger -> EAAccessoryManager.h
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 6, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13)]
	[Native]
	[ErrorDomain ("EABluetoothAccessoryPickerErrorDomain")]
	public enum EABluetoothAccessoryPickerError : long {
		AlreadyConnected,
		NotFound,
		Cancelled,
		Failed
	}
}

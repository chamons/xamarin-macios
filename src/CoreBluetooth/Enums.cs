//
// Enums.cs: Enums definitions for CoreBluetooth
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//   Marek Safar (marek.safar@gmail.com)
//
// Copyright 2011-2014 Xamarin Inc
//

using System;
using XamCore.ObjCRuntime;

namespace XamCore.CoreBluetooth {

	[Introduced (PlatformName.MacOSX, 10, 13)]
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum CBManagerState : long {
		Unknown = 0,
		Resetting,
		Unsupported,
		Unauthorized,
		PoweredOff,
		PoweredOn
	}

	// NSInteger -> CBCentralManager.h
	[Introduced (PlatformName.iOS, 5, 0)]
	[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'CBManagerState' instead.")]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum CBCentralManagerState : long {
		Unknown = CBManagerState.Unknown,
		Resetting = CBManagerState.Resetting,
		Unsupported = CBManagerState.Unsupported,
		Unauthorized = CBManagerState.Unauthorized,
		PoweredOff = CBManagerState.PoweredOff,
		PoweredOn = CBManagerState.PoweredOn
	}

	// NSInteger -> CBPeripheralManager.h
	[Introduced (PlatformName.iOS, 6, 0)]
	[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'CBManagerState' instead.")]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum CBPeripheralManagerState : long {
		Unknown = CBManagerState.Unknown,
		Resetting = CBManagerState.Resetting,
		Unsupported = CBManagerState.Unsupported,
		Unauthorized = CBManagerState.Unauthorized,
		PoweredOff = CBManagerState.PoweredOff,
		PoweredOn = CBManagerState.PoweredOn
	}

	// NSInteger -> CBPeripheralManager.h
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Native]
	public enum CBPeripheralState : long {
		Disconnected,
		Connecting,
		Connected,
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 13)]
		Disconnecting,
	}

#if !XAMCORE_4_0
	// NSInteger -> CBPeripheralManager.h
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Native]
	public enum CBPeripheralManagerAuthorizationStatus : long {
		NotDetermined,
		Restricted,
		Denied,
		Authorized,
	}
#endif

	// NSUInteger -> CBCharacteristic.h
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Flags]
	[Native]
	public enum CBCharacteristicProperties : nuint_compat_int {
		Broadcast = 1,
		Read = 2,
		WriteWithoutResponse = 4,
		Write = 8,
		Notify = 16,
		Indicate = 32,
		AuthenticatedSignedWrites = 64,
		ExtendedProperties = 128,
		[Introduced (PlatformName.MacOSX, 10, 9)]
		NotifyEncryptionRequired = 0x100,
		[Introduced (PlatformName.MacOSX, 10, 9)]
		IndicateEncryptionRequired = 0x200
	}

	[Introduced (PlatformName.WatchOS, 4, 0)]
	[ErrorDomain ("CBErrorDomain")]
	[Native] // NSInteger -> CBError.h
	public enum CBError : long {
		None = 0,
		Unknown = 0,
		InvalidParameters,
		InvalidHandle,
		NotConnected,
		OutOfSpace,
		OperationCancelled,
		ConnectionTimeout,
		PeripheralDisconnected,
		UUIDNotAllowed,
		AlreadyAdvertising,
		[Introduced (PlatformName.iOS, 7, 1)][Introduced (PlatformName.MacOSX, 10, 13)]
		ConnectionFailed,
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 13)]
		ConnectionLimitReached,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13)]
		UnknownDevice,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)]
	[ErrorDomain ("CBATTErrorDomain")]
	[Native] // NSInteger -> CBError.h
	public enum CBATTError : long {
		Success = 0,
		InvalidHandle,
		ReadNotPermitted,
		WriteNotPermitted,
		InvalidPdu,
		InsufficientAuthentication,
		RequestNotSupported,
		InvalidOffset,
		InsufficientAuthorization,
		PrepareQueueFull,
		AttributeNotFound,
		AttributeNotLong,
		InsufficientEncryptionKeySize,
		InvalidAttributeValueLength,
		UnlikelyError,
		InsufficientEncryption,
		UnsupportedGroupType,
		InsufficientResources
	}

	// NSInteger -> CBPeripheral.h
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Native]
	public enum CBCharacteristicWriteType : long {
		WithResponse,
		WithoutResponse
	}

	// NSUInteger -> CBCharacteristic.h
	[Introduced (PlatformName.MacOSX, 10, 9)]
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Flags]
	[Native]
	public enum CBAttributePermissions : nuint_compat_int {
		Readable	= 1,
		Writeable	= 1 << 1,
		ReadEncryptionRequired	= 1 << 2,
		WriteEncryptionRequired	= 1 << 3
	}

	// NSInteger -> CBPeripheralManager.h
	[Introduced (PlatformName.WatchOS, 4, 0)]
	[Native]
	public enum CBPeripheralManagerConnectionLatency : long {
		Low = 0,
		Medium,
		High
	}
}

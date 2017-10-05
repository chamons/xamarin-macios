using System;
using ObjCRuntime;
using Foundation;

namespace LocalAuthentication {

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	public enum LAPolicy : long {
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		DeviceOwnerAuthenticationWithBiometrics = 1,
		DeviceOwnerAuthentication = 2
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	[ErrorDomain ("LAErrorDomain")]
	public enum LAStatus : long {
		Success = 0,
		/// Authentication was not successful, because user failed to provide valid credentials.
		AuthenticationFailed = -1,
		/// Authentication was canceled by user (e.g. tapped Cancel button).
		UserCancel           = -2,	    
		/// Authentication was canceled, because the user tapped the fallback button (Enter Password).
		UserFallback         = -3,	    
		/// Authentication was canceled by system (e.g. another application went to foreground).
		SystemCancel         = -4,	    
		/// Authentication could not start, because passcode is not set on the device.
		PasscodeNotSet       = -5,
		/// Authentication could not start, because Touch ID is not available on the device.
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'BiometryNotAvailable' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'BiometryNotAvailable' instead.")]
		TouchIDNotAvailable  = -6,	    

		/// Authentication could not start, because Touch ID has no enrolled fingers.
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'BiometryNotEnrolled' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'BiometryNotEnrolled' instead.")]
		TouchIDNotEnrolled   = -7,

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'BiometryLockout' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'BiometryLockout' instead.")]
		TouchIDLockout       = -8,
		AppCancel            = -9,
		InvalidContext       = -10,

		BiometryNotAvailable = TouchIDNotAvailable,
		BiometryNotEnrolled = TouchIDNotEnrolled,
		BiometryLockout = TouchIDLockout,

		NotInteractive       = -1004,
	}

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11), Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 11, 0)]
	[Native]
	public enum LACredentialType : long {
		ApplicationPassword = 0
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum LAAccessControlOperation : long {
		CreateItem,
		UseItem,
		CreateKey,
		UseKeySign,
		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		UseKeyDecrypt,
		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		UseKeyKeyExchange,
	}
}

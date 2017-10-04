using XamCore.ObjCRuntime;

namespace XamCore.StoreKit {

	// typedef NSInteger SKPaymentTransactionState;
	// StoreKit.framework/Headers/SKPaymentTransaction.h
	[Native]
	public enum SKPaymentTransactionState : long {
		Purchasing,
		Purchased,
		Failed,  
		Restored,
		[Introduced (PlatformName.iOS, 8, 0)]Deferred
	}

	// untyped enum and not used in API - so it _could_ be an `int`
	// OTOH it's meant to be used with NSError.Code which is an NSInteger/nint
	// StoreKit.framework/Headers/SKError.h
	[Native]
	[ErrorDomain ("SKErrorDomain")]
	public enum SKError : long {
		Unknown,
		ClientInvalid,
		PaymentCancelled,
		PaymentInvalid,
		PaymentNotAllowed,
		ProductNotAvailable,
		// iOS 9.3
		CloudServicePermissionDenied,
		CloudServiceNetworkConnectionFailed,
		// iOS 10.3
		Revoked,
	}

	// typedef NSInteger SKDownloadState;
	// StoreKit.framework/Headers/SKDownload.h 
	[Native]
	public enum SKDownloadState : long {
		Waiting, Active, Paused, Finished, Failed, Cancelled
	}

#if !MONOMAC || !XAMCORE_4_0
	[Introduced (PlatformName.iOS, 9, 3)]
	[Native]
	public enum SKCloudServiceAuthorizationStatus : long {
		NotDetermined,
		Denied,
		Restricted,
		Authorized
	}

	[Introduced (PlatformName.iOS, 9, 3)]
	[Native]
	public enum SKCloudServiceCapability : ulong {
		None = 0,
		MusicCatalogPlayback = 1 << 0,
		[Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 10, 1)]
		MusicCatalogSubscriptionEligible = 1 << 1,
		AddToCloudMusicLibrary = 1 << 8
	}

	[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum SKProductStorePromotionVisibility : long {
		Default,
		Show,
		Hide,
	}
#endif
}

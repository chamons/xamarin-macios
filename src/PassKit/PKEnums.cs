// Copyright 2012-2014 Xamarin Inc. All rights reserved.

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.PassKit {

	// untyped enum -> PKError.h
	// This never seemed to be deprecatd, yet in iOS8 it's obsoleted
	[Obsoleted (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.iOS, 6, 0)]
	public enum PKErrorCode {
		None = 0,
		Unknown = 1,
		NotEntitled,
		PermissionDenied, // new in iOS7
	}

	// NSInteger -> PKPass.h
	[Introduced (PlatformName.iOS, 6, 0)]
	[ErrorDomain ("PKPassKitErrorDomain")]
	[Native]
	public enum PKPassKitErrorCode : long {
		Unknown = -1,
		None = 0,
		InvalidData = 1,
		UnsupportedVersion,
		InvalidSignature,
#if !XAMCORE_2_0
		[Obsolete ("renamed to InvalidSignature")] // after betas?
		CertificateRevoked = InvalidSignature,
#endif
		[Introduced (PlatformName.iOS, 8, 0)]
		NotEntitled
	}

	// NSInteger -> PKPassLibrary.h
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	public enum PKPassLibraryAddPassesStatus : long {
		DidAddPasses,
		ShouldReviewPasses,
		DidCancelAddPasses
	}

	[Native]
	public enum PKPassType : ulong {
		Barcode, Payment,
		// Any = ~0
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Native]
	public enum PKPaymentAuthorizationStatus : long {
		Success,
		Failure,

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentBillingAddressInvalidError'.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentBillingAddressInvalidError'.")]
		InvalidBillingPostalAddress,

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentShippingAddressInvalidError'.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentShippingAddressInvalidError'.")]
		InvalidShippingPostalAddress,

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentContactInvalidError'.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'Failure' and 'PKPaymentRequest.CreatePaymentContactInvalidError'.")]
		InvalidShippingContact,

		[Introduced (PlatformName.iOS, 9, 2)]
		PinRequired,
		[Introduced (PlatformName.iOS, 9, 2)]
		PinIncorrect,
		[Introduced (PlatformName.iOS, 9, 2)]
		PinLockout
	}

	[Native]
	public enum PKPaymentPassActivationState : ulong {
		Activated, RequiresActivation, Activating, Suspended, Deactivated
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Native]
	public enum PKMerchantCapability : ulong {
		ThreeDS = 1 << 0,
		EMV = 1 << 1,
		Credit = 1 << 2,
		Debit = 1 << 3
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'PKContactField' instead.")]
	[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'PKContactField' instead.")]
	[Native]
	[Flags]
	public enum PKAddressField : ulong {
		None = 0,
		PostalAddress = 1 << 0,
		Phone = 1 << 1,
		Email = 1 << 2,
		[Introduced (PlatformName.iOS, 8, 3)]
		Name = 1 << 3,
		All = PostalAddress|Phone|Email|Name
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 8, 3)]
	[Native]
	public enum PKPaymentButtonStyle : long {
		White,
		WhiteOutline,
		Black,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 8, 3)]
	[Native]
	public enum PKPaymentButtonType : long {
		Plain,
		Buy,
		[Introduced (PlatformName.iOS, 9, 0)]
		SetUp,
		[Introduced (PlatformName.iOS, 10, 0)]
		InStore,
		[Introduced (PlatformName.iOS, 10, 2)]
		Donate,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 8, 3)]
	[Native]
	public enum PKShippingType : ulong {
		Shipping,
		Delivery,
		StorePickup,
		ServicePickup,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum PKAddPaymentPassError : long
	{
		Unsupported,
		UserCancelled,
		SystemCancelled
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum PKAutomaticPassPresentationSuppressionResult : ulong
	{
		NotSupported = 0,
		AlreadyPresenting,
		Denied,
		Cancelled,
		Success
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum PKPaymentMethodType : ulong
	{
		Unknown = 0,
		Debit,
		Credit,
		Prepaid,
		Store
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum PKPaymentSummaryItemType : ulong
	{
		Final,
		Pending
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum PKAddPassButtonStyle : long {
		Black = 0,
		Outline
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Introduced (PlatformName.iOS, 11, 0)]
	[ErrorDomain ("PKPaymentErrorDomain")]
	[Native]
	public enum PKPaymentErrorCode : long {
		Unknown = -1,
		ShippingContactInvalid = 1,
		BillingContactInvalid,
		ShippingAddressUnserviceable,
	}
}

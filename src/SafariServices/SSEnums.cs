//
// SSEnums.cs: SafariServices framework enums
//
// Authors:
//   Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013-2014, 2016 Xamarin Inc.
//

using XamCore.ObjCRuntime;

namespace XamCore.SafariServices {

	// NSInteger -> SSReadingList.h
	[Unavailable (PlatformName.MacOSX)][Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	[ErrorDomain ("SSReadingListErrorDomain")]
	public enum SSReadingListError : long {
		UrlSchemeNotAllowed = 1
	}

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'SFErrorCode' enum.")]
	[Native]
	[ErrorDomain ("SFContentBlockerErrorDomain")]
	public enum SFContentBlockerErrorCode : long {
		Ok = 0,
		NoExtensionFound = 1,
		NoAttachmentFound = 2,
		LoadingInterrupted = 3
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	[ErrorDomain ("SFErrorDomain")]
	public enum SFErrorCode : long
	{
		Ok = 0,
		NoExtensionFound = 1,
		NoAttachmentFound = 2,
		LoadingInterrupted = 3
	}

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SFSafariViewControllerDismissButtonStyle : long {
		Done,
		Close,
		Cancel,
	}

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	[ErrorDomain ("SFAuthenticationErrorDomain")]
	public enum SFAuthenticationError : long {
		CanceledLogin = 1,
	}

	[Unavailable (PlatformName.iOS)]
	[Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
	[Native]
	public enum SFSafariServicesVersion : long {
		V10_0,
		V10_1,
		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		V11_0,
	}
}

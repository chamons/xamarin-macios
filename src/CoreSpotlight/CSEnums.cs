//
// CoreSpotlight enums
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015, 2016 Xamarin Inc. All rights reserved.
//

#if IOS

using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.CoreSpotlight {
#if !MONOMAC // TODO: Verify this is available in future OS X El Capitan betas, it was not included in beta 1, also do not forget foundation.cs(3801,3)
	// NSInteger -> CNContact.h
	[Unavailable (PlatformName.TvOS)] // CS_TVOS_UNAVAILABLE
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[ErrorDomain ("CSIndexErrorDomain")]
	public enum CSIndexErrorCode : nint {
		UnknownError =	-1,
		IndexUnavailableError = -1000,
		InvalidItemError = -1001,
		InvalidClientStateError = -1002,
		RemoteConnectionError = -1003,
		QuotaExceeded = -1004,
		IndexingUnsupported = -1005,
	}

	[Unavailable (PlatformName.TvOS)][Introduced (PlatformName.iOS, 10, 0)]
	[ErrorDomain ("CSSearchQueryErrorDomain")]
	[Native]
	public enum CSSearchQueryErrorCode : nint {
		Unknown = -2000,
		IndexUnreachable = -2001,
		InvalidQuery = -2002,
		Cancelled = -2003
	}
#endif
}

#endif

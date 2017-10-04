//
// Enums.cs: enums for MultipeerConnectivity
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//   Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013-2014, 2016 Xamarin, Inc.

#if XAMCORE_2_0 || !MONOMAC // MultipeerConnectivity is 64-bit only on OS X
using XamCore.ObjCRuntime;

namespace XamCore.MultipeerConnectivity {

	// NSInteger -> MCSession.h
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	public enum MCSessionSendDataMode : long {
		Reliable,
		Unreliable
	}

	// NSInteger -> MCSession.h
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	public enum MCSessionState : long {
		NotConnected,
		Connecting,
		Connected
	}

	// NSInteger -> MCSession.h
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	public enum MCEncryptionPreference : long {
		Optional = 0,
		Required = 1,
		None = 2
	}

	// NSInteger -> MCError.h
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	[ErrorDomain ("MCErrorDomain")]
	public enum MCError : long {
		Unknown ,
		NotConnected,
		InvalidParameter,
		Unsupported,
		TimedOut,
		Cancelled,
		Unavailable
	}
}
#endif

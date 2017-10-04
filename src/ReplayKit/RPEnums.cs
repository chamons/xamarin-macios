//
// ReplayKit enums
//
// Copyright 2015-2016 Xamarin Inc. All rights reserved.
//

using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.UIKit;

namespace XamCore.ReplayKit {

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	[ErrorDomain ("RPRecordingErrorDomain")]
	public enum RPRecordingError : long {
		None = 0,
		Unknown = -5800,
		UserDeclined = -5801,
		Disabled = -5802,
		FailedToStart = -5803,
		Failed = -5804,
		InsufficientStorage = -5805,
		Interrupted = -5806,
		ContentResize = -5807,
		BroadcastInvalidSession = -5808,
		SystemDormancy = -5809,
		Entitlements = -5810,
		ActivePhoneCall = -5811,
		FailedToSave = -5812,
		CarPlay = -5813,
	}

	[Unavailable (PlatformName.iOS)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum RPPreviewViewControllerMode : long {
		Preview,
		Share
	}

	[Native]
	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum RPSampleBufferType : long {
		Video = 1,
		AudioApp,
		AudioMic
	}

	[Native]
	[Introduced (PlatformName.iOS, 11, 0)]
	[Unavailable (PlatformName.TvOS)]
	public enum RPCameraPosition : long {
		Front = 1,
		Back,
	}
}
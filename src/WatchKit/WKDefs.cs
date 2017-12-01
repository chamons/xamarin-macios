//
// WatchKit Enums
//
// Copyright 2014-2015 Xamarin Inc.
//
// Author:
//  Miguel de Icaza
//

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.WatchKit {
	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKInterfaceMapPinColor : nint {
		Red,
		Green,
		Purple
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKMenuItemIcon : nint {
		Accept,
		Add,
		Block,
		Decline,
		Info,
		Maybe,
		More,
		Mute,
		Pause,
		Play,
		Repeat,
		Resume,
		Share,
		Shuffle,
		Speaker,
		Trash
	}
		
	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKUserNotificationInterfaceType : nint {
		Default,
		Custom
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKTextInputMode : nint {
		Plain,
		AllowEmoji,
		AllowAnimatedEmoji
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	[ErrorDomain ("WatchKitErrorDomain")]
	public enum WKErrorCode : nint {
		None = 0,
		UnknownError = 1,
		RequestReplyNotCalledError = 2,
		InvalidArgumentError = 3,
		MediaPlayerError = 4,
		DownloadError = 5,
		RecordingFailedError = 6,
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKHapticType : nint {
		Notification,
		DirectionUp,
		DirectionDown,
		Success,
		Failure,
		Retry,
		Start,
		Stop,
		Click
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAudioFilePlayerStatus : nint {
		Unknown,
		ReadyToPlay,
		Failed
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAudioFilePlayerItemStatus : nint {
		Unknown,
		ReadyToPlay,
		Failed
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAudioRecorderPreset : nint {
		NarrowBandSpeech,
		WideBandSpeech,
		HighQualityAudio
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAlertActionStyle : nint {
		Default = 0,
		Cancel,
		Destructive
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAlertControllerStyle : nint {
		Alert,
		SideBySideButtonsAlert,
		ActionSheet
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKVideoGravity : nint {
		Aspect,
		AspectFill,
		Resize
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceObjectHorizontalAlignment : nint {
		Left,
		Center,
		Right
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceObjectVerticalAlignment : nint {
		Top,
		Center,
		Bottom
	}

	[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceLayoutDirection : nint
	{
		LeftToRight,
		RightToLeft
	}

	[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceSemanticContentAttribute : nint
	{
		Unspecified,
		Playback,
		Spatial,
		ForceLeftToRight,
		ForceRightToLeft
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKApplicationState : nint {
		Active,
		Inactive,
		Background
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKGestureRecognizerState : nint {
		Possible,
		Began,
		Changed,
		Ended,
		Cancelled,
		Failed,
		Recognized
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	[Flags]
	public enum WKSwipeGestureRecognizerDirection : nuint {
		Right = 1 << 0,
		Left = 1 << 1,
		Up = 1 << 2,
		Down = 1 << 3
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceWristLocation : nint {
		Left,
		Right
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceCrownOrientation : nint {
		Left,
		Right
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKWaterResistanceRating : nint {
		Ipx7,
		Wr50,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKSnapshotReason : nint {
		AppScheduled = 0,
		ReturnToDefaultState,
		ComplicationUpdate,
		Prelaunch,
		AppBackgrounded,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKPageOrientation : nint {
		Horizontal,
		Vertical,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceScrollPosition : nint {
		Top,
		CenteredVertically,
		Bottom,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceBatteryState : nint {
		Unknown,
		Unplugged,
		Charging,
		Full,
	}
}

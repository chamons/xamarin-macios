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
	public enum WKInterfaceMapPinColor : long {
		Red,
		Green,
		Purple
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKMenuItemIcon : long {
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
	public enum WKUserNotificationInterfaceType : long {
		Default,
		Custom
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	public enum WKTextInputMode : long {
		Plain,
		AllowEmoji,
		AllowAnimatedEmoji
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Native]
	[ErrorDomain ("WatchKitErrorDomain")]
	public enum WKErrorCode : long {
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
	public enum WKHapticType : long {
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
	public enum WKAudioFilePlayerStatus : long {
		Unknown,
		ReadyToPlay,
		Failed
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAudioFilePlayerItemStatus : long {
		Unknown,
		ReadyToPlay,
		Failed
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAudioRecorderPreset : long {
		NarrowBandSpeech,
		WideBandSpeech,
		HighQualityAudio
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAlertActionStyle : long {
		Default = 0,
		Cancel,
		Destructive
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKAlertControllerStyle : long {
		Alert,
		SideBySideButtonsAlert,
		ActionSheet
	}

	[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKVideoGravity : long {
		Aspect,
		AspectFill,
		Resize
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceObjectHorizontalAlignment : long {
		Left,
		Center,
		Right
	}

	[Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceObjectVerticalAlignment : long {
		Top,
		Center,
		Bottom
	}

	[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceLayoutDirection : long
	{
		LeftToRight,
		RightToLeft
	}

	[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceSemanticContentAttribute : long
	{
		Unspecified,
		Playback,
		Spatial,
		ForceLeftToRight,
		ForceRightToLeft
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKApplicationState : long {
		Active,
		Inactive,
		Background
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKGestureRecognizerState : long {
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
	public enum WKSwipeGestureRecognizerDirection : ulong {
		Right = 1 << 0,
		Left = 1 << 1,
		Up = 1 << 2,
		Down = 1 << 3
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceWristLocation : long {
		Left,
		Right
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceCrownOrientation : long {
		Left,
		Right
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKWaterResistanceRating : long {
		Ipx7,
		Wr50,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKSnapshotReason : long {
		AppScheduled = 0,
		ReturnToDefaultState,
		ComplicationUpdate,
		Prelaunch,
		AppBackgrounded,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKPageOrientation : long {
		Horizontal,
		Vertical,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceScrollPosition : long {
		Top,
		CenteredVertically,
		Bottom,
	}

	[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
	[Native]
	public enum WKInterfaceDeviceBatteryState : long {
		Unknown,
		Unplugged,
		Charging,
		Full,
	}
}

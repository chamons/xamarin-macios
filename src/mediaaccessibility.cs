using System;

using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.MediaAccessibility {

#if XAMCORE_4_0
	[Static]
	interface MACaptionAppearance {
		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[Notification]
		[Field ("kMACaptionAppearanceSettingsChangedNotification")]
		NSString SettingsChangedNotification { get; }
	}
#endif

	[Static]
	interface MAAudibleMedia {
		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 10)]
		[Notification]
		[Field ("kMAAudibleMediaSettingsChangedNotification")]
		NSString SettingsChangedNotification { get; }
	}

	[Static]
	interface MAMediaCharacteristic {
		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[Field ("MAMediaCharacteristicDescribesMusicAndSoundForAccessibility")]
		NSString DescribesMusicAndSoundForAccessibility { get; }

		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 10)]
		[Field ("MAMediaCharacteristicDescribesVideoForAccessibility")]
		NSString DescribesVideoForAccessibility { get; }

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[Field ("MAMediaCharacteristicTranscribesSpokenDialogForAccessibility")]
		NSString TranscribesSpokenDialogForAccessibility { get; }
	}
}
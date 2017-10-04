//
// This file contains definitions used in the MediaPlayer namespace
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2011-2015 Xamarin, Inc.
//

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.MediaPlayer {
#if XAMCORE_2_0 || !MONOMAC
	// NSInteger -> MPMoviePlayerController.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	public enum MPMoviePlaybackState : long {
		Stopped,
		Playing,
		Paused,
		Interrupted,
		SeekingForward,
		SeekingBackward
	}

	// NSInteger -> MPMoviePlayerController.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	public enum MPMovieLoadState : long {
		Unknown        = 0,
		Playable       = 1 << 0,
		PlaythroughOK  = 1 << 1,
		Stalled        = 1 << 2,		
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMovieRepeatMode : long {
		None, One
	}

	// NSInteger -> MPMoviePlayerController.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	public enum MPMovieControlStyle : long {
		None, Embedded, Fullscreen, Default = Embedded
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMovieFinishReason : long {
		PlaybackEnded, PlaybackError, UserExited
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	[Flags]
	public enum MPMovieMediaType : long {
		None = 0,
		Video = 1 << 0,
		Audio = 1 << 1
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMovieSourceType : long {
		Unknown, File, Streaming
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMovieTimeOption : long {
		NearestKeyFrame,
		Exact
	}

	// NSUInteger -> MPMediaItem.h
	[Native]
	[Flags]
	public enum MPMediaType : nuint_compat_int {
#if !XAMCORE_2_0
		[Obsolete ("Use Shorter name Music")]
		MPMediaTypeMusic        = 1 << 0,
		[Obsolete ("Use Shorter name Podcast")]
		MPMediaTypePodcast      = 1 << 1,
		[Obsolete ("Use Shorter name AudioBook")]
		MPMediaTypeAudioBook    = 1 << 2,
		[Obsolete ("Use Shorter name AnyAudio")]
		MPMediaTypeAnyAudio     = 0x00ff,
#endif	
		Music        = 1 << 0,
		Podcast      = 1 << 1,
		AudioBook    = 1 << 2,
		AudioITunesU = 1 << 3,
		AnyAudio     = 0x00ff,
		
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		Movie = 1 << 8,
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		TVShow = 1 << 9,
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		VideoPodcast = 1 << 10,
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		MusicVideo = 1 << 11,
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		VideoITunesU = 1 << 12,
		[Introduced (PlatformName.iOS, 7, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		HomeVideo = 1 << 13,
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 12, 2)]
		TypeAnyVideo = 0xff00,
#if XAMCORE_2_0
		Any          = 0xFFFFFFFFFFFFFFFF
#else
		Any          = ~0
#endif
	}

	// NSInteger -> MPMediaPlaylist.h
	[Unavailable (PlatformName.MacOSX)]
	[Native]
	[Flags]
	[Unavailable (PlatformName.TvOS)]
	public enum MPMediaPlaylistAttribute : long {
		None    = 0,
		OnTheGo = (1 << 0), // if set, the playlist was created on a device rather than synced from iTunes
		Smart   = (1 << 1),
		Genius  = (1 << 2)
	};
			
	// NSInteger -> MPMediaQuery.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	public enum MPMediaGrouping : long {
		Title,
		Album,
		Artist,
		AlbumArtist,
		Composer,
		Genre,
		Playlist,
		PodcastTitle
	}

	// NSInteger -> MPMediaQuery.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	public enum MPMediaPredicateComparison : long {
		EqualsTo,
		Contains
	}

	// NSInteger -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMovieScalingMode : long {
		None,
		AspectFit,
		AspectFill,
		Fill
	}
	
	// untyped enum -> MPMoviePlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	public enum MPMovieControlMode {
		Default, 
		VolumeOnly,
		Hidden   
	}

	// NSInteger -> /MPMusicPlayerController.h
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPMusicPlaybackState : long {
		Stopped,
		Playing,
		Paused,
		Interrupted,
		SeekingForward,
		SeekingBackward
	}
	
	// NSInteger -> /MPMusicPlayerController.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	public enum MPMusicRepeatMode : long {
		Default,
		None,
		One,
		All
	}
	
	// NSInteger -> /MPMusicPlayerController.h
	[Native]
	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	public enum MPMusicShuffleMode : long {
		Default,
		Off,
		Songs,
		Albums
	}

	public delegate void MPMediaItemEnumerator (string property, NSObject value, ref bool stop);

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Native]
	public enum MPShuffleType : long
	{
		Off,
		Items,
		Collections
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Native]
	public enum MPRepeatType : long
	{
		Off,
		One,
		All
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum MPChangeLanguageOptionSetting : long
	{
		None,
		NowPlayingItemOnly,
		Permanent
	}

	// NSInteger -> MPRemoteCommand.h
	[Native]
	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Introduced (PlatformName.iOS, 7, 1)]
	public enum MPRemoteCommandHandlerStatus : long {
		Success = 0,
		NoSuchContent = 100,
		[Introduced (PlatformName.iOS, 9, 1)]
		NoActionableNowPlayingItem = 110,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13)]
		DeviceNotFound = 120,
		CommandFailed = 200
	}

	// NSUInteger -> MPRemoteCommandEvent.h
	[Native]
	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Introduced (PlatformName.iOS, 7, 1)]
	public enum MPSeekCommandEventType : nuint_compat_int {
		BeginSeeking,
		EndSeeking
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum MPNowPlayingInfoLanguageOptionType : ulong {
		Audible,
		Legible
	}

	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 9, 3)]
	[Native]
	[ErrorDomain ("MPErrorDomain")]
	public enum MPErrorCode : long {
		Unknown,
		PermissionDenied,
		CloudServiceCapabilityMissing,
		NetworkConnectionFailed,
		NotFound,
		NotSupported,
		[Introduced (PlatformName.iOS, 10, 1)]
		Cancelled,
		RequestTimedOut,
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 9, 3)]
	[Native]
	public enum MPMediaLibraryAuthorizationStatus : long {
		NotDetermined = 0,
		Denied,
		Restricted,
		Authorized
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum MPNowPlayingInfoMediaType : ulong
	{
		None = 0,
		Audio,
		Video
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2)]
	[Unavailable (PlatformName.iOS)]
	[Unavailable (PlatformName.TvOS)]
	[Native]
	public enum MPNowPlayingPlaybackState : ulong
	{
		Unknown = 0,
		Playing,
		Paused,
		Stopped,
		Interrupted,
	}
#endif
}

using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.Photos
{
	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHImageContentMode : long {
		AspectFit = 0,
		AspectFill = 1,
		Default = AspectFit
	}

	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHImageRequestOptionsVersion : long {
		Current = 0,
		Unadjusted,
		Original
	}

	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHImageRequestOptionsDeliveryMode : long {
		Opportunistic = 0,
		HighQualityFormat = 1,
		FastFormat = 2
	}

	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHImageRequestOptionsResizeMode : long {
		None = 0,
		Fast,
		Exact
	}

	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum PHVideoRequestOptionsVersion : long {
		Current = 0,
		Original
	}

	// NSInteger -> PHImageManager.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum PHVideoRequestOptionsDeliveryMode : long {
		Automatic = 0,
		HighQualityFormat = 1,
		MediumQualityFormat = 2,
		FastFormat = 3
	}

	// NSInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHCollectionListType : long {
		MomentList  = 1,
		Folder      = 2,
		SmartFolder = 3
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHCollectionListSubtype : long {
		MomentListCluster = 1,
		MomentListYear = 2,

		RegularFolder = 100,

		SmartFolderEvents = 200,
		SmartFolderFaces = 201,

#if !XAMCORE_3_0
		// this was added in the wrong enum type (ref bug #40019)
		[Obsolete ("Incorrect value (exists in 'PHAssetCollectionSubtype').")]
		SmartAlbumSelfPortraits = 210,
		[Obsolete ("Incorrect value (exists in 'PHAssetCollectionSubtype').")]
		SmartAlbumScreenshots = 211,
#endif
#if XAMCORE_2_0
		Any = Int64.MaxValue,
#else
		Any = Int32.MaxValue,
#endif
	}

	// NSUInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHCollectionEditOperation : long {
		None             = 0,
		DeleteContent    = 1,
		RemoveContent    = 2,
		AddContent       = 3,
		CreateContent    = 4,
		RearrangeContent = 5,
		Delete           = 6,
		Rename           = 7
	}

	// NSInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetCollectionType : long {
		Album      = 1,
		SmartAlbum = 2,
		Moment     = 3
	}

	// NSInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetCollectionSubtype : long {
		AlbumRegular         = 2,
		AlbumSyncedEvent     = 3,
		AlbumSyncedFaces     = 4,
		AlbumSyncedAlbum     = 5,
		AlbumImported        = 6,
		AlbumMyPhotoStream   = 100,
		AlbumCloudShared     = 101,
		SmartAlbumGeneric    = 200,
		SmartAlbumPanoramas  = 201,
		SmartAlbumVideos     = 202,
		SmartAlbumFavorites  = 203,
		SmartAlbumTimelapses = 204,
		SmartAlbumAllHidden  = 205,
		SmartAlbumRecentlyAdded = 206,
		SmartAlbumBursts        = 207,
		SmartAlbumSlomoVideos   = 208,
		SmartAlbumUserLibrary 	= 209,
		[Introduced (PlatformName.iOS, 9, 0)]
		SmartAlbumSelfPortraits = 210,
		[Introduced (PlatformName.iOS, 9, 0)]
		SmartAlbumScreenshots   = 211,
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		SmartAlbumDepthEffect   = 212,
		[Introduced (PlatformName.iOS, 10, 3), Introduced (PlatformName.TvOS, 10, 2)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		SmartAlbumLivePhotos = 213,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.MacOSX)]
		SmartAlbumAnimated = 214,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.MacOSX)]
		SmartAlbumLongExposures = 215,

#if XAMCORE_2_0
		Any           = Int64.MaxValue
#else
		Any           = Int32.MaxValue
#endif
	}

	// NSUInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetEditOperation : long {
		None       = 0,
		Delete     = 1,
		Content    = 2,
		Properties = 3
	}

	// NSInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetMediaType : long {
		Unknown = 0,
		Image   = 1,
		Video   = 2,
		Audio   = 3
	}

	// NSUInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	[Flags]
	public enum PHAssetMediaSubtype : ulong {
		None               = 0,
		PhotoPanorama      = (1 << 0),
		PhotoHDR           = (1 << 1),
		Screenshot         = (1 << 2),
		PhotoLive          = (1 << 3),
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		PhotoDepthEffect   = (1 << 4),
		VideoStreamed      = (1 << 16),
		VideoHighFrameRate = (1 << 17),
		VideoTimelapse     = (1 << 18),
			
	}

	// NSUInteger -> PhotosTypes.h
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	[Flags]
	public enum PHAssetBurstSelectionType : ulong {
		None     = 0,
		AutoPick = (1 << 0),
		UserPick = (1 << 1)
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAuthorizationStatus : long {
		NotDetermined, Restricted, Denied, Authorized
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum PHAssetResourceType : long
	{
		Photo = 1,
		Video = 2,
		Audio = 3,
		AlternatePhoto = 4,
		FullSizePhoto = 5,
		FullSizeVideo = 6,
		AdjustmentData = 7,
		AdjustmentBasePhoto = 8,
		PairedVideo = 9
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetSourceType : ulong
	{
		None = 0,
		UserLibrary = (1 << 0),
		CloudShared = (1 << 1),
		iTunesSynced = (1 << 2)
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHLivePhotoFrameType : long {
		Photo,
		Video
	}

	[Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum PHAssetPlaybackStyle : long {
		Unsupported = 0,
		Image = 1,
		ImageAnimated = 2,
		LivePhoto = 3,
		Video = 4,
		VideoLooping = 5,
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[Native]
	public enum PHProjectTextElementType : long {
		Body = 0,
		Title,
		Subtitle,
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[Native]
	public enum PHProjectCreationSource : long {
		Undefined = 0,
		UserSelection = 1,
		Album = 2,
		Memory = 3,
		Moment = 4,
		Project = 20,
		ProjectBook = 21,
		ProjectCalendar = 22,
		ProjectCard = 23,
		ProjectPrintOrder = 24,
		ProjectSlideshow = 25,
		ProjectExtension = 26,
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[Native]
	public enum PHProjectSectionType : long {
		Undefined = 0,
		Cover = 1,
		Content = 2,
		Auxiliary = 3,
	}
}

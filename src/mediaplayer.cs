//
// This file describes the API that the generator will produce
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2011-2015, Xamarin Inc
//
using System.ComponentModel;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreFoundation;
using XamCore.CoreGraphics;
using XamCore.CoreLocation;
#if MONOMAC
using XamCore.AppKit;
#else
using XamCore.UIKit;
#endif
using System;

namespace XamCore.MediaPlayer {
#if XAMCORE_2_0 || !MONOMAC
	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)] // type exists only to expose fields
	[BaseType (typeof (NSObject))]
#if XAMCORE_2_0 && IOS
	// introduced in 4.2
	interface MPMediaEntity : NSSecureCoding {
#else
	interface MPMediaItem : NSSecureCoding {
#endif
		[Static]
		[Export ("canFilterByProperty:")]
		bool CanFilterByProperty (NSString property);

		[Export ("valueForProperty:")]
		NSObject ValueForProperty (NSString property);

		[Introduced (PlatformName.iOS, 4, 0)]
		[Export ("enumerateValuesForProperties:usingBlock:")]
		void EnumerateValues (NSSet propertiesToEnumerate, MPMediaItemEnumerator enumerator);

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("objectForKeyedSubscript:")]
		NSObject GetObject (NSObject key);

		[Field ("MPMediaEntityPropertyPersistentID")]
		NSString PropertyPersistentID { get; }

#if XAMCORE_2_0 && IOS
	}
#if MONOMAC || TVOS
	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Static]
#else
	[BaseType (typeof (MPMediaEntity))]
#endif
	interface MPMediaItem {
#endif
		[Unavailable (PlatformName.MacOSX)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 2)]
		[Unavailable (PlatformName.MacOSX)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("persistentIDPropertyForGroupingType:")][Static]
		string GetPersistentIDProperty (MPMediaGrouping groupingType);

		[Unavailable (PlatformName.MacOSX)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 2)]
		[Unavailable (PlatformName.MacOSX)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("titlePropertyForGroupingType:")][Static]
		string GetTitleProperty (MPMediaGrouping groupingType);

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumPersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyArtistPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ArtistPersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumArtistPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumArtistPersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyGenrePersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString GenrePersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyComposerPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ComposerPersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyPodcastPersistentID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PodcastPersistentIDProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyMediaType")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString MediaTypeProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyTitle")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString TitleProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumTitle")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumTitleProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyArtist")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ArtistProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumArtist")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumArtistProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyGenre")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString GenreProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyComposer")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ComposerProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyPlaybackDuration")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PlaybackDurationProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumTrackNumber")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumTrackNumberProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyAlbumTrackCount")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AlbumTrackCountProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyDiscNumber")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString DiscNumberProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyDiscCount")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString DiscCountProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyArtwork")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ArtworkProperty { get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Field ("MPMediaItemPropertyIsExplicit")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString IsExplicitProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyLyrics")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString LyricsProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyIsCompilation")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString IsCompilationProperty { get; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMediaItemPropertyReleaseDate")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString ReleaseDateProperty { get; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMediaItemPropertyBeatsPerMinute")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString BeatsPerMinuteProperty { get; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMediaItemPropertyComments")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString CommentsProperty { get; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMediaItemPropertyAssetURL")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString AssetURLProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyPlayCount")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PlayCountProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertySkipCount")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString SkipCountProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyRating")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString RatingProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyLastPlayedDate")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString LastPlayedDateProperty { get; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMediaItemPropertyUserGrouping")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString UserGroupingProperty { get; }

		[Introduced (PlatformName.iOS, 3, 0)]
		[Field ("MPMediaItemPropertyPodcastTitle")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PodcastTitleProperty { get; }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("MPMediaItemPropertyBookmarkTime")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString BookmarkTimeProperty { get; }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("MPMediaItemPropertyIsCloudItem")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString IsCloudItemProperty { get; }

		[Introduced (PlatformName.iOS, 9, 2)]
		[Field ("MPMediaItemPropertyHasProtectedAsset")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString HasProtectedAssetProperty { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Field ("MPMediaItemPropertyDateAdded")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString DateAddedProperty { get; }

		[Introduced (PlatformName.iOS, 10, 3)]
		[Field ("MPMediaItemPropertyPlaybackStoreID")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSString PlaybackStoreIDProperty { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPMediaItemArtwork {
#if !MONOMAC
		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("initWithBoundsSize:requestHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGSize boundsSize, Func<CGSize, UIImage> requestHandler);

		[Deprecated (PlatformName.iOS, 10, 0)]
		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);
		
		[Export ("imageWithSize:")]
		[return: NullAllowed]
		UIImage ImageWithSize (CGSize size);
#else
		[Export ("initWithBoundsSize:requestHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGSize boundsSize, Func<CGSize, NSImage> requestHandler);

		[Export ("imageWithSize:")]
		[return: NullAllowed]
		NSImage ImageWithSize (CGSize size);
#endif

		[Export ("bounds")]
		CGRect Bounds { get; }

		[Unavailable (PlatformName.MacOSX)]
		[Deprecated (PlatformName.iOS, 10, 0)]
		[Export ("imageCropRect")]
		CGRect ImageCropRectangle { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	// Objective-C exception thrown.  Name: MPMediaItemCollectionInitException Reason: -init is not supported, use -initWithItems:
	[DisableDefaultCtor]
#if XAMCORE_2_0 && IOS
	// introduced in 4.2 - but the type was never added to classic
	[BaseType (typeof (MPMediaEntity))]
#else
	[BaseType (typeof (NSObject))]
#endif
#if XAMCORE_3_0 || !XAMCORE_2_0 || !IOS
	interface MPMediaItemCollection : NSSecureCoding {
#else
	// part of the bug is that we inlined MPMediaEntity needlessly
	interface MPMediaItemCollection : MPMediaEntity, NSSecureCoding {
#endif
		[Static]
		[Export ("collectionWithItems:")]
		MPMediaItemCollection FromItems (MPMediaItem [] items);

		[DesignatedInitializer]
		[Export ("initWithItems:")]
		IntPtr Constructor (MPMediaItem [] items);

		[Export ("items")]
		MPMediaItem [] Items { get; }

		[Export ("representativeItem")]
		MPMediaItem RepresentativeItem { get; }

		[Export ("count")]
		nint Count { get; }

		[Export ("mediaTypes")]
		MPMediaType MediaTypes { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	interface MPMediaLibrary : NSSecureCoding {
		[Static, Export ("defaultMediaLibrary")]
		MPMediaLibrary DefaultMediaLibrary { get; }

		[Export ("lastModifiedDate")]
		NSDate LastModifiedDate { get; }

		[Export ("beginGeneratingLibraryChangeNotifications")]
		void BeginGeneratingLibraryChangeNotifications ();

		[Export ("endGeneratingLibraryChangeNotifications")]
		void EndGeneratingLibraryChangeNotifications ();

		[Field ("MPMediaLibraryDidChangeNotification")]
		[Notification]
		NSString DidChangeNotification { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[Static]
		[Export ("authorizationStatus")]
		MPMediaLibraryAuthorizationStatus AuthorizationStatus { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[Static]
		[Async]
		[Export ("requestAuthorization:")]
		void RequestAuthorization (Action<MPMediaLibraryAuthorizationStatus> handler);

		[Introduced (PlatformName.iOS, 9, 3)]
		[Export ("addItemWithProductID:completionHandler:")]
		[Async]
#if XAMCORE_2_0 && IOS
		// MPMediaEntity was not part of classic
		void AddItem (string productID, [NullAllowed] Action<MPMediaEntity[], NSError> completionHandler);
#else
		void AddItem (string productID, [NullAllowed] Action<MPMediaItem[], NSError> completionHandler);
#endif

		[Introduced (PlatformName.iOS, 9, 3)]
		[Async]
		[Export ("getPlaylistWithUUID:creationMetadata:completionHandler:")]
		void GetPlaylist (NSUuid uuid, [NullAllowed] MPMediaPlaylistCreationMetadata creationMetadata, Action<MPMediaPlaylist, NSError> completionHandler);
	}

#if !MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (UIViewController), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(MPMediaPickerControllerDelegate)})]
	interface MPMediaPickerController {
		[DesignatedInitializer]
		[Export ("initWithMediaTypes:")]
		IntPtr Constructor (MPMediaType mediaTypes);

		[Export ("mediaTypes")]
		MPMediaType MediaTypes { get; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		MPMediaPickerControllerDelegate Delegate { get; set; }

		[Export ("allowsPickingMultipleItems")]
		bool AllowsPickingMultipleItems { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("prompt", ArgumentSemantic.Copy)]
		string Prompt { get; set; }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("showsCloudItems")]
		bool ShowsCloudItems { get; set; }

		[Introduced (PlatformName.iOS, 9, 2)]
		[Export ("showsItemsWithProtectedAssets")]
		bool ShowsItemsWithProtectedAssets { get; set; }
	}

	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface MPMediaPickerControllerDelegate {
		[Export ("mediaPicker:didPickMediaItems:"), EventArgs ("ItemsPicked"), EventName ("ItemsPicked")]
		void MediaItemsPicked (MPMediaPickerController sender, MPMediaItemCollection mediaItemCollection);
		
		[Export ("mediaPickerDidCancel:"), EventArgs ("MPMediaPickerController"), EventName ("DidCancel")]
		void MediaPickerDidCancel (MPMediaPickerController sender);
	}
#endif

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (MPMediaItemCollection))]
	// Objective-C exception thrown.  Name: MPMediaItemCollectionInitException Reason: -init is not supported, use -initWithItems:
	[DisableDefaultCtor]
	interface MPMediaPlaylist : NSSecureCoding {
		[Export ("initWithItems:")]
		IntPtr Constructor (MPMediaItem [] items);

		[Static, Export ("canFilterByProperty:")]
		bool CanFilterByProperty (string property);

		[Export ("valueForProperty:")]
		NSObject ValueForProperty (string property);

		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("persistentID")]
		ulong PersistentID { get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("name")]
		string Name { get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("playlistAttributes")]
		MPMediaPlaylistAttribute PlaylistAttributes { get; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("seedItems")]
		MPMediaItem [] SeedItems { get; }		

		[Introduced (PlatformName.iOS, 9, 3)]
		[NullAllowed, Export ("descriptionText")]
		string DescriptionText { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[NullAllowed, Export ("authorDisplayName")]
		string AuthorDisplayName { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[Async]
		[Export ("addItemWithProductID:completionHandler:")]
		void AddItem (string productID, [NullAllowed] Action<NSError> completionHandler);

		[Introduced (PlatformName.iOS, 9, 3)]
		[Async]
		[Export ("addMediaItems:completionHandler:")]
		void AddMediaItems (MPMediaItem[] mediaItems, [NullAllowed] Action<NSError> completionHandler);
	}

	[Unavailable (PlatformName.MacOSX)]
	[Static]
	interface MPMediaPlaylistProperty {
		[Field ("MPMediaPlaylistPropertyPersistentID")]
		NSString PersistentID { get; }

		[Field ("MPMediaPlaylistPropertyName")]
		NSString Name { get; }

		[Field ("MPMediaPlaylistPropertyPlaylistAttributes")]
		NSString PlaylistAttributes { get; }

		[Field ("MPMediaPlaylistPropertySeedItems")]
		NSString SeedItems { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[Unavailable (PlatformName.TvOS)] // do not work on AppleTV devices (only in simulator)
		[Field ("MPMediaPlaylistPropertyDescriptionText")]
		NSString DescriptionText { get; }

		[Introduced (PlatformName.iOS, 9, 3)]
		[Unavailable (PlatformName.TvOS)] // do not work on AppleTV devices (only in simulator)
		[Field ("MPMediaPlaylistPropertyAuthorDisplayName")]
		NSString AuthorDisplayName { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	interface MPMediaQuery : NSSecureCoding, NSCopying {
		[DesignatedInitializer]
		[Export ("initWithFilterPredicates:")]
		IntPtr Constructor ([NullAllowed] NSSet filterPredicates);

		[NullAllowed] // by default this property is null
		[Export ("filterPredicates", ArgumentSemantic.Retain)]
		NSSet FilterPredicates { get; set; }

		[Export ("addFilterPredicate:")]
		void AddFilterPredicate (MPMediaPredicate predicate);

		[Export ("removeFilterPredicate:")]
		void RemoveFilterPredicate (MPMediaPredicate predicate);

		[Export ("items")]
		MPMediaItem [] Items { get; }

		[Export ("collections")]
		MPMediaItemCollection [] Collections { get; }

		[Export ("groupingType")]
		MPMediaGrouping GroupingType { get; set; }
#if XAMCORE_2_0
		[Export ("albumsQuery")][Static]
		MPMediaQuery AlbumsQuery { get; }

		[Export ("artistsQuery")][Static]
		MPMediaQuery ArtistsQuery { get; }

		[Export ("songsQuery")][Static]
		MPMediaQuery SongsQuery { get; }

		[Export ("playlistsQuery")][Static]
		MPMediaQuery PlaylistsQuery { get; }

		[Export ("podcastsQuery")][Static]
		MPMediaQuery PodcastsQuery { get; }

		[Export ("audiobooksQuery")][Static]
		MPMediaQuery AudiobooksQuery { get; }

		[Export ("compilationsQuery")][Static]
		MPMediaQuery CompilationsQuery { get; }

		[Export ("composersQuery")][Static]
		MPMediaQuery ComposersQuery { get; }

		[Export ("genresQuery")][Static]
		MPMediaQuery GenresQuery { get; }
#else
		[Export ("albumsQuery")][Static]
		MPMediaQuery albumsQuery { get; }
		
		[Export ("artistsQuery")][Static]
		MPMediaQuery artistsQuery { get; }
		
		[Export ("songsQuery")][Static]
		MPMediaQuery songsQuery { get; }
		
		[Export ("playlistsQuery")][Static]
		MPMediaQuery playlistsQuery { get; }
		
		[Export ("podcastsQuery")][Static]
		MPMediaQuery podcastsQuery { get; }
		
		[Export ("audiobooksQuery")][Static]
		MPMediaQuery audiobooksQuery { get; }
		
		[Export ("compilationsQuery")][Static]
		MPMediaQuery compilationsQuery { get; }
		
		[Export ("composersQuery")][Static]
		MPMediaQuery composersQuery { get; }
		
		[Export ("genresQuery")][Static]
		MPMediaQuery genresQuery { get; }
#endif
		[Introduced (PlatformName.iOS, 4, 2)]
		[Export ("collectionSections")]
		MPMediaQuerySection [] CollectionSections { get; }

		[Introduced (PlatformName.iOS, 4, 2)]
		[Export ("itemSections")]
		MPMediaQuerySection [] ItemSections { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	interface MPMediaPredicate : NSSecureCoding {
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (MPMediaPredicate))]
	interface MPMediaPropertyPredicate {
		[Static, Export ("predicateWithValue:forProperty:")]
		MPMediaPropertyPredicate PredicateWithValue ([NullAllowed] NSObject value, string property);

		[Static, Export ("predicateWithValue:forProperty:comparisonType:")]
		MPMediaPropertyPredicate PredicateWithValue ([NullAllowed] NSObject value, string property, MPMediaPredicateComparison comparisonType);

		[Export ("property", ArgumentSemantic.Copy)]
		string Property { get; }

		[Export ("value", ArgumentSemantic.Copy)]
		NSObject Value { get; }

		[Export ("comparisonType")]
		MPMediaPredicateComparison ComparisonType { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	interface MPMovieAccessLog : NSCopying {
		[Export ("events")]
		MPMovieAccessLogEvent [] Events { get; }

		[Export ("extendedLogDataStringEncoding")]
		NSStringEncoding ExtendedLogDataStringEncoding { get; }

		[Export ("extendedLogData")]
		NSData ExtendedLogData { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	interface MPMovieErrorLog : NSCopying {
		[Export ("events")]
		MPMovieErrorLogEvent [] Events { get; }

		[Export ("extendedLogDataStringEncoding")]
		NSStringEncoding ExtendedLogDataStringEncoding { get; }

		[Export ("extendedLogData")]
		NSData ExtendedLogData { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	interface MPMovieAccessLogEvent : NSCopying {
		[Export ("numberOfSegmentsDownloaded")]
		nint SegmentedDownloadedCount { get; }

		[Export ("playbackStartDate")]
		NSData PlaybackStartDate { get; }

		[Export ("URI")]
		string Uri { get; }

		[Export ("serverAddress")]
		string ServerAddress { get; }

		[Export ("numberOfServerAddressChanges")]
		nint ServerAddressChangeCount { get; }

		[Export ("playbackSessionID")]
		string PlaybackSessionID { get; }

		[Export ("playbackStartOffset")]
		double PlaybackStartOffset { get; }

		[Export ("segmentsDownloadedDuration")]
		double SegmentsDownloadedDuration { get; }

		[Export ("durationWatched")]
		double DurationWatched { get; }

		[Export ("numberOfStalls")]
		nint StallCount { get; }

		[Export ("numberOfBytesTransferred")]
		long BytesTransferred { get; }

		[Export ("observedBitrate")]
		double ObservedBitrate { get; }

		[Export ("indicatedBitrate")]
		double IndicatedBitrate { get; }

		[Export ("numberOfDroppedVideoFrames")]
		nint DroppedVideoFrameCount { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	interface MPMovieErrorLogEvent : NSCopying {
		[Export ("date")]
		NSDate Date { get; }

		[Export ("URI")]
		string Uri { get; }

		[Export ("serverAddress")]
		string ServerAddress { get; }

		[Export ("playbackSessionID")]
		string PlaybackSessionID { get; }

		[Export ("errorStatusCode")]
		nint ErrorStatusCode { get; }

		[Export ("errorDomain")]
		string ErrorDomain { get; }

		[Export ("errorComment")]
		string ErrorComment { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	interface MPMoviePlayerFinishedEventArgs {
		[Export ("MPMoviePlayerPlaybackDidFinishReasonUserInfoKey")]
		MPMovieFinishReason FinishReason { get; }
	}

#if !MONOMAC
	[Deprecated (PlatformName.iOS, 9, 0)]
	interface MPMoviePlayerFullScreenEventArgs {
		[Export ("MPMoviePlayerFullscreenAnimationDurationUserInfoKey")]
		double AnimationDuration { get; }

		[Export ("MPMoviePlayerFullscreenAnimationCurveUserInfoKey")]
		UIViewAnimationCurve AnimationCurve { get; }
	}

	[Deprecated (PlatformName.iOS, 9, 0)]
	interface MPMoviePlayerThumbnailEventArgs {
		[Export ("MPMoviePlayerThumbnailImageKey")]
		UIImage Image { get; }

		[Export ("MPMoviePlayerThumbnailTimeKey")]
		double Time { get; }

		[Export ("MPMoviePlayerThumbnailErrorKey")]
		NSError Error { get; }
	}
#endif

	[Unavailable (PlatformName.MacOSX)]
	[Deprecated (PlatformName.iOS, 9, 0)]
	interface MPMoviePlayerTimedMetadataEventArgs {
		[Export ("MPMoviePlayerTimedMetadataUserInfoKey")]
		MPTimedMetadata [] TimedMetadata { get; }
	}

	// no [Model] yet... it can be easily created in user code (all abstract) if needed
	[Unavailable (PlatformName.MacOSX)]
	[Protocol]
	interface MPMediaPlayback {
		[Abstract]
		[Export ("play")]
		void Play ();

		[Abstract]
		[Export ("stop")]
		void Stop ();

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("pause")]
		void Pause ();
		
		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("prepareToPlay")]
		void PrepareToPlay ();

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("isPreparedToPlay")]
		bool IsPreparedToPlay { get; }

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("currentPlaybackTime")]
		double CurrentPlaybackTime { get; set; }

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("currentPlaybackRate")]
		float CurrentPlaybackRate { get; set; } // float, not CGFloat

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("beginSeekingForward")]
		void BeginSeekingForward ();

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("beginSeekingBackward")]
		void BeginSeekingBackward ();

		[Abstract]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("endSeeking")]
		void EndSeeking ();
	}

#if !MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
	[BaseType (typeof (NSObject))]
	interface MPMoviePlayerController : MPMediaPlayback {
		[DesignatedInitializer]
		[Export ("initWithContentURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		// <quote>You should avoid using this property. It is available only when you use the initWithContentURL: method to initialize the movie player controller object.</quote>
		[Introduced (PlatformName.iOS, 2, 0, message: "Do not use; this API was removed and is not always available."), Deprecated (PlatformName.iOS, 3, 2, message: "Do not use; this API was removed and is not always available."), Obsoleted (PlatformName.iOS, 8, 0, message: "Do not use; this API was removed and is not always available.")]
		UIColor BackgroundColor { get; set; }

		[Export ("scalingMode")]
		MPMovieScalingMode ScalingMode { get; set; }

		[Export ("movieControlMode")]
		[Introduced (PlatformName.iOS, 2, 0, message: "Do not use; this API was removed."), Deprecated (PlatformName.iOS, 3, 2, message: "Do not use; this API was removed."), Obsoleted (PlatformName.iOS, 8, 0, message: "Do not use; this API was removed.")]
		MPMovieControlMode MovieControlMode { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("initialPlaybackTime")]
		double InitialPlaybackTime { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[NullAllowed] // by default this property is null
		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("view")]
		UIView View { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("backgroundView")]
		UIView BackgroundView { get; }
		
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("playbackState")]
		MPMoviePlaybackState PlaybackState { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("loadState")]
		MPMovieLoadState LoadState { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("controlStyle")]
		MPMovieControlStyle ControlStyle { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("repeatMode")]
		MPMovieRepeatMode RepeatMode { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("shouldAutoplay")]
		bool ShouldAutoplay { get; set; }

		[Export ("useApplicationAudioSession")]
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		bool UseApplicationAudioSession { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("fullscreen")]
		bool Fullscreen { [Bind ("isFullscreen")] get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("setFullscreen:animated:")]
		void SetFullscreen (bool fullscreen, bool animated);

		[Introduced (PlatformName.iOS, 4, 3)]
		[Export ("allowsAirPlay")]
		bool AllowsAirPlay { get; set; }

		[Introduced (PlatformName.iOS, 5, 0)]
		[Export ("airPlayVideoActive")]
		bool AirPlayVideoActive { [Bind ("isAirPlayVideoActive")] get; }

		[Deprecated (PlatformName.iOS, 9, 0)]
		[Introduced (PlatformName.iOS, 4, 3)]
		[Export ("accessLog")]
		MPMovieAccessLog AccessLog { get; }

		[Deprecated (PlatformName.iOS, 9, 0)]
		[Introduced (PlatformName.iOS, 4, 3)]
		[Export ("errorLog")]
		MPMovieErrorLog ErrorLog { get; }

		// Brought it from the MPMediaPlayback.h

		[Export ("thumbnailImageAtTime:timeOption:")]
		[Introduced (PlatformName.iOS, 3, 2, message: "Use 'RequestThumbnails' instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use 'RequestThumbnails' instead.")]
		UIImage ThumbnailImageAt (double time, MPMovieTimeOption timeOption);

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("requestThumbnailImagesAtTimes:timeOption:")]
		void RequestThumbnails (NSNumber [] doubleNumbers, MPMovieTimeOption timeOption);

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("cancelAllThumbnailImageRequests")]
		void CancelAllThumbnailImageRequests ();

		//
		// From interface MPMovieProperties
		//
		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("movieMediaTypes")]
		MPMovieMediaType MovieMediaTypes { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("movieSourceType")]
		MPMovieSourceType SourceType { get; set; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("duration")]
		double Duration { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("playableDuration")]
		double PlayableDuration { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("naturalSize")]
		CGSize NaturalSize { get; }

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("endPlaybackTime")]
		double EndPlaybackTime { get; set; }

		[Introduced (PlatformName.iOS, 4, 0)]
		[Export ("timedMetadata")]
		MPTimedMetadata [] TimedMetadata { get; }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Field ("MPMoviePlayerScalingModeDidChangeNotification")]
		[Notification]
		NSString ScalingModeDidChangeNotification { get; }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Field ("MPMoviePlayerPlaybackDidFinishNotification")]
		[Notification (typeof (MPMoviePlayerFinishedEventArgs))]
		NSString PlaybackDidFinishNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerPlaybackDidFinishReasonUserInfoKey")] // NSNumber (MPMovieFinishReason)
		NSString PlaybackDidFinishReasonUserInfoKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerPlaybackStateDidChangeNotification")]
		[Notification]
		NSString PlaybackStateDidChangeNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerLoadStateDidChangeNotification")]
		[Notification]
		NSString LoadStateDidChangeNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerNowPlayingMovieDidChangeNotification")]
		[Notification]
		NSString NowPlayingMovieDidChangeNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerWillEnterFullscreenNotification")]
		[Notification (typeof (MPMoviePlayerFullScreenEventArgs))]
		[Notification]
		NSString WillEnterFullscreenNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerDidEnterFullscreenNotification")]
		[Notification]
		NSString DidEnterFullscreenNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerWillExitFullscreenNotification")]
		[Notification (typeof (MPMoviePlayerFullScreenEventArgs))]
		NSString WillExitFullscreenNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerDidExitFullscreenNotification")]
		[Notification]
		NSString DidExitFullscreenNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerFullscreenAnimationDurationUserInfoKey")]
		NSString FullscreenAnimationDurationUserInfoKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerFullscreenAnimationCurveUserInfoKey")]
		NSString FullscreenAnimationCurveUserInfoKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMovieMediaTypesAvailableNotification")]
		[Notification]
		NSString TypesAvailableNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMovieSourceTypeAvailableNotification")]
		[Notification]
		NSString SourceTypeAvailableNotification { get; }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMovieDurationAvailableNotification")]
		[Notification]
		NSString DurationAvailableNotification { get;  }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMovieNaturalSizeAvailableNotification")]
		[Notification]
		NSString NaturalSizeAvailableNotification { get;  }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerThumbnailImageRequestDidFinishNotification")]
		[Notification (typeof (MPMoviePlayerThumbnailEventArgs))]
		NSString ThumbnailImageRequestDidFinishNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerThumbnailImageKey")]
		NSString ThumbnailImageKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerThumbnailTimeKey")]
		NSString ThumbnailTimeKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Field ("MPMoviePlayerThumbnailErrorKey")]
		NSString ThumbnailErrorKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataUpdatedNotification")]
		[Notification (typeof (MPMoviePlayerTimedMetadataEventArgs))]
		NSString TimedMetadataUpdatedNotification { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataUserInfoKey")]
		NSString TimedMetadataUserInfoKey { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataKeyName")]
		NSString TimedMetadataKeyName { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataKeyInfo")]
		NSString TimedMetadataKeyInfo { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataKeyMIMEType")]
		NSString TimedMetadataKeyMIMEType { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataKeyDataType")]
		NSString TimedMetadataKeyDataType { get; }
		
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Field ("MPMoviePlayerTimedMetadataKeyLanguageCode")]
		NSString TimedMetadataKeyLanguageCode { get; }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Field ("MPMediaPlaybackIsPreparedToPlayDidChangeNotification")]
		[Notification]
		NSString MediaPlaybackIsPreparedToPlayDidChangeNotification { get; }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("readyForDisplay")]
		bool ReadyForDisplay { get;  }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("MPMoviePlayerReadyForDisplayDidChangeNotification")]
		[Notification]
		NSString MoviePlayerReadyForDisplayDidChangeNotification { get; }

		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
		[Introduced (PlatformName.iOS, 5, 0)]
		[Field ("MPMoviePlayerIsAirPlayVideoActiveDidChangeNotification")]
		[Notification]
		NSString MPMoviePlayerIsAirPlayVideoActiveDidChangeNotification { get; }
	}
#endif

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSGenericException Reason: MPTimedMetadata cannot be created directly
	[DisableDefaultCtor]
	interface MPTimedMetadata {
		[Export ("key")]
		string Key { get;  }

		[Export ("keyspace")]
		string Keyspace { get;  }

		[Export ("value")]
#if XAMCORE_3_0
		NSObject Value { get;  }
#else
		NSObject value { get;  }
#endif

		[Export ("timestamp")]
		double Timestamp { get;  }

		[Export ("allMetadata")]
		NSDictionary AllMetadata { get;  }
	}

#if !MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (UIViewController))]
	[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'AVPlayerViewController' (AVKit) instead.")]
	interface MPMoviePlayerViewController {
		[DesignatedInitializer]
		[Export ("initWithContentURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("moviePlayer")]
		MPMoviePlayerController MoviePlayer { get; }

		// Directly removed, shows up in iOS 6.1 SDK, but not any later SDKs.
		[Introduced (PlatformName.iOS, 3, 0, message: "Do not use; this API was removed."), Deprecated (PlatformName.iOS, 7, 0, message: "Do not use; this API was removed."), Obsoleted (PlatformName.iOS, 7, 0, message: "Do not use; this API was removed.")]
		[Export ("shouldAutorotateToInterfaceOrientation:")]
		bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation orientation);
	}
#endif

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	interface MPMusicPlayerController : MPMediaPlayback {
		[Static, Export ("applicationMusicPlayer")]
		MPMusicPlayerController ApplicationMusicPlayer { get; }

		[Introduced (PlatformName.iOS, 10, 3)]
		[Static]
		[Export ("applicationQueuePlayer")]
		MPMusicPlayerApplicationController ApplicationQueuePlayer { get; }

		[Static, Export ("iPodMusicPlayer")]
		[Deprecated (PlatformName.iOS, 8, 0, message: "Use 'SystemMusicPlayer' instead.")]
		MPMusicPlayerController iPodMusicPlayer { get; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Static, Export ("systemMusicPlayer")]
		MPMusicPlayerController SystemMusicPlayer { get; }

		[Export ("playbackState")]
		MPMusicPlaybackState PlaybackState { get; }

		[Export ("repeatMode")]
		MPMusicRepeatMode RepeatMode { get; set; }

		[Export ("shuffleMode")]
		MPMusicShuffleMode ShuffleMode { get; set; }

		[Introduced (PlatformName.iOS, 3, 0, message: "Use 'MPVolumeView' for volume control instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use 'MPVolumeView' for volume control instead.")]
		[Export ("volume")]
		float Volume { get; set; } // nfloat, not CGFloat

		[Introduced (PlatformName.iOS, 5, 0)]
		[Export ("indexOfNowPlayingItem")]
		nuint IndexOfNowPlayingItem { get; }

		[Export ("nowPlayingItem", ArgumentSemantic.Copy), NullAllowed]
		MPMediaItem NowPlayingItem { get; set; }

		[Export ("setQueueWithQuery:")]
		void SetQueue (MPMediaQuery query);

		[Export ("setQueueWithItemCollection:")]
		void SetQueue (MPMediaItemCollection collection);

		[Introduced (PlatformName.iOS, 9, 3)]
		[Export ("setQueueWithStoreIDs:")]
		void SetQueue (string[] storeIDs);

		[Introduced (PlatformName.iOS, 10, 1)]
		[Export ("setQueueWithDescriptor:")]
		void SetQueue (MPMusicPlayerQueueDescriptor descriptor);

		[Introduced (PlatformName.iOS, 10, 3)]
		[Export ("prependQueueDescriptor:")]
		void Prepend (MPMusicPlayerQueueDescriptor descriptor);

		[Introduced (PlatformName.iOS, 10, 3)]
		[Export ("appendQueueDescriptor:")]
		void Append (MPMusicPlayerQueueDescriptor descriptor);

		[Introduced (PlatformName.iOS, 10, 1)]
		[Async]
		[Export ("prepareToPlayWithCompletionHandler:")]
		void PrepareToPlay (Action<NSError> completionHandler);

		[Export ("skipToNextItem")]
		void SkipToNextItem ();

		[Export ("skipToBeginning")]
		void SkipToBeginning ();

		[Export ("skipToPreviousItem")]
		void SkipToPreviousItem ();

		[Export ("beginGeneratingPlaybackNotifications")]
		void BeginGeneratingPlaybackNotifications ();

		[Export ("endGeneratingPlaybackNotifications")]
		void EndGeneratingPlaybackNotifications ();

		[Field ("MPMusicPlayerControllerPlaybackStateDidChangeNotification")]
		[Notification]
		NSString PlaybackStateDidChangeNotification { get; }

		[Field ("MPMusicPlayerControllerNowPlayingItemDidChangeNotification")]
		[Notification]
		NSString NowPlayingItemDidChangeNotification { get; }

		[Field ("MPMusicPlayerControllerVolumeDidChangeNotification")]
		[Notification]
		NSString VolumeDidChangeNotification { get; }
	}

#if !MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (UIView))]
	interface MPVolumeView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("showsRouteButton")]
		bool ShowsRouteButton { get; set; }

		[Export ("showsVolumeSlider")]
		bool ShowsVolumeSlider { get; set; }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("setMinimumVolumeSliderImage:forState:")]
		void SetMinimumVolumeSliderImage ([NullAllowed] UIImage image, UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("setMaximumVolumeSliderImage:forState:")]
		void SetMaximumVolumeSliderImage ([NullAllowed] UIImage image, UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("setVolumeThumbImage:forState:")]
		void SetVolumeThumbImage ([NullAllowed] UIImage image, UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("minimumVolumeSliderImageForState:")]
		UIImage GetMinimumVolumeSliderImage (UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("maximumVolumeSliderImageForState:")]
		UIImage GetMaximumVolumeSliderImage (UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("volumeThumbImageForState:")]
		UIImage GetVolumeThumbImage (UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("volumeSliderRectForBounds:")]
		CGRect GetVolumeSliderRect (CGRect bounds);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("volumeThumbRectForBounds:volumeSliderRect:value:")]
		CGRect GetVolumeThumbRect (CGRect bounds, CGRect columeSliderRect, float /* float, not CGFloat */ value);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("setRouteButtonImage:forState:")]
		void SetRouteButtonImage ([NullAllowed] UIImage image, UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("routeButtonImageForState:")]
		UIImage GetRouteButtonImage (UIControlState state);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("routeButtonRectForBounds:")]
		CGRect GetRouteButtonRect (CGRect bounds);

		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("wirelessRoutesAvailable")]
		bool AreWirelessRoutesAvailable { [Bind ("areWirelessRoutesAvailable")] get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("wirelessRouteActive")]
		bool IsWirelessRouteActive { [Bind ("isWirelessRouteActive")] get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[NullAllowed] // by default this property is null
		[Export ("volumeWarningSliderImage", ArgumentSemantic.Retain)]
		UIImage VolumeWarningSliderImage { get; set; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Notification]
		[Field ("MPVolumeViewWirelessRoutesAvailableDidChangeNotification")]
		NSString WirelessRoutesAvailableDidChangeNotification { get; }

		[Introduced (PlatformName.iOS, 7, 0)]
		[Notification]
		[Field ("MPVolumeViewWirelessRouteActiveDidChangeNotification")]
		NSString WirelessRouteActiveDidChangeNotification { get; }
	}	
#endif

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 2)]
	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: MPMediaQuerySection is a read-only object
	[DisableDefaultCtor]
	interface MPMediaQuerySection : NSSecureCoding, NSCopying {
		[Export ("range", ArgumentSemantic.Assign)]	
		NSRange Range { get; }

		[Export ("title", ArgumentSemantic.Copy)]	
		string Title { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 5, 0)]
	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: -init is not supported, use +defaultCenter
	[DisableDefaultCtor]
	interface MPNowPlayingInfoCenter {
		[Export ("nowPlayingInfo", ArgumentSemantic.Copy), NullAllowed, Internal]
		NSDictionary _NowPlayingInfo { get; set;  }

		[Static]
		[Export ("defaultCenter")]
		MPNowPlayingInfoCenter DefaultCenter { get; }

		[Unavailable (PlatformName.iOS)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("playbackState", ArgumentSemantic.Assign)]
		MPNowPlayingPlaybackState PlaybackState { get; set; }

		[Internal]
 		[Field ("MPNowPlayingInfoPropertyElapsedPlaybackTime")]
		NSString PropertyElapsedPlaybackTime { get; }
			
		[Internal]
		[Field ("MPNowPlayingInfoPropertyPlaybackRate")]
		NSString PropertyPlaybackRate { get; }
		
		[Internal]
		[Field ("MPNowPlayingInfoPropertyPlaybackQueueIndex")]
		NSString PropertyPlaybackQueueIndex { get; }
		
		[Internal]
		[Field ("MPNowPlayingInfoPropertyPlaybackQueueCount")]
		NSString PropertyPlaybackQueueCount { get; }
		
		[Internal]
		[Field ("MPNowPlayingInfoPropertyChapterNumber")]
		NSString PropertyChapterNumber { get; }
		
		[Internal]
		[Field ("MPNowPlayingInfoPropertyChapterCount")]
		NSString PropertyChapterCount { get; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Internal]
		[Field ("MPNowPlayingInfoPropertyDefaultPlaybackRate")]
		NSString PropertyDefaultPlaybackRate { get; }

		[Introduced (PlatformName.iOS, 9, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Internal]
		[Field ("MPNowPlayingInfoPropertyAvailableLanguageOptions")]
		NSString PropertyAvailableLanguageOptions { get; }

		[Introduced (PlatformName.iOS, 9, 0)]
		[Internal]
		[Field ("MPNowPlayingInfoPropertyCurrentLanguageOptions")]
		NSString PropertyCurrentLanguageOptions { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoCollectionIdentifier")]
		NSString PropertyCollectionIdentifier { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoPropertyExternalContentIdentifier")]
		NSString PropertyExternalContentIdentifier { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoPropertyExternalUserProfileIdentifier")]
		NSString PropertyExternalUserProfileIdentifier { get; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Introduced (PlatformName.TvOS, 11, 0)]
		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		[Field ("MPNowPlayingInfoPropertyServiceIdentifier")]
		NSString PropertyServiceIdentifier { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoPropertyPlaybackProgress")]
		NSString PropertyPlaybackProgress { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoPropertyMediaType")]
		NSString PropertyMediaType { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MPNowPlayingInfoPropertyIsLiveStream")]
		NSString PropertyIsLiveStream { get; }

		[Introduced (PlatformName.iOS, 10, 3)]
		[Introduced (PlatformName.TvOS, 10, 2)]
		[Introduced (PlatformName.MacOSX, 10, 12, 3, PlatformArchitecture.Arch64)]
		[Field ("MPNowPlayingInfoPropertyAssetURL")]
		NSString PropertyAssetUrl { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // crash if used
	interface MPContentItem {

		[DesignatedInitializer]
		[Export ("initWithIdentifier:")]
		IntPtr Constructor (string identifier);

		[Export ("artwork")]
		MPMediaItemArtwork Artwork { get; set; }

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("playbackProgress")]
		float PlaybackProgress { get; set; } // float, not CGFloat

		[Export ("subtitle")]
		string Subtitle { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("streamingContent")]
		bool StreamingContent { [Bind ("isStreamingContent")] get; set; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("explicitContent")]
		bool ExplicitContent { [Bind ("isExplicitContent")] get; set; }

		[Export ("container")]
		bool Container { [Bind ("isContainer")] get; set; }

		[Export ("playable")]
		bool Playable { [Bind ("isPlayable")] get; set; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface MPPlayableContentDataSource {

#if XAMCORE_2_0
		[Abstract]
#endif
		[Export ("contentItemAtIndexPath:")]
#if XAMCORE_4_0
		MPContentItem GetContentItem (NSIndexPath indexPath);
#else
		MPContentItem ContentItem (NSIndexPath indexPath);
#endif

		[Export ("beginLoadingChildItemsAtIndexPath:completionHandler:")]
		void BeginLoadingChildItems (NSIndexPath indexPath, Action<NSError> completionHandler);

		[Export ("childItemsDisplayPlaybackProgressAtIndexPath:")]
		bool ChildItemsDisplayPlaybackProgress (NSIndexPath indexPath);

#if XAMCORE_2_0
		[Abstract]
#endif
		[Export ("numberOfChildItemsAtIndexPath:")]
		nint NumberOfChildItems (NSIndexPath indexPath);

		[Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.iOS, 10, 0)]
		[Async]
		[Export ("contentItemForIdentifier:completionHandler:")]
		void GetContentItem (string identifier, Action<MPContentItem, NSError> completionHandler);
	}

	interface IMPPlayableContentDataSource {
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface MPPlayableContentDelegate {
		[Export ("playableContentManager:initiatePlaybackOfContentItemAtIndexPath:completionHandler:")]
		void InitiatePlaybackOfContentItem (MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler);

		[Introduced (PlatformName.iOS, 8, 4)]
		[Export ("playableContentManager:didUpdateContext:")]
		void ContextUpdated (MPPlayableContentManager contentManager, MPPlayableContentManagerContext context);

		[Introduced (PlatformName.iOS, 9, 0)]
		[Deprecated (PlatformName.iOS, 9, 3, message: "Use 'InitializePlaybackQueue (MPPlayableContentManager, MPContentItem[], Action<NSError>)' instead.")]
		[Export ("playableContentManager:initializePlaybackQueueWithCompletionHandler:")]
		void InitializePlaybackQueue (MPPlayableContentManager contentManager, Action<NSError> completionHandler);

		[Introduced (PlatformName.iOS, 9, 3)]
		[Export ("playableContentManager:initializePlaybackQueueWithContentItems:completionHandler:")]
		void InitializePlaybackQueue (MPPlayableContentManager contentManager, [NullAllowed] MPContentItem[] contentItems, Action<NSError> completionHandler);
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // NSInvalidArgumentException Reason: -init is invalid. Use +sharedManager. <- [sic]
	interface MPPlayableContentManager {

		[Static]
		[Export ("sharedContentManager")]
		MPPlayableContentManager Shared { get; }

		[Export ("dataSource", ArgumentSemantic.Weak)][NullAllowed]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDataSource")]
		[Protocolize]
		MPPlayableContentDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		MPPlayableContentDelegate Delegate { get; set; }

		[Export ("beginUpdates")]
		void BeginUpdates ();

		[Export ("endUpdates")]
		void EndUpdates ();

		[Export ("reloadData")]
		void ReloadData ();

		[Introduced (PlatformName.iOS, 8, 4)]
		[Export ("context")]
		MPPlayableContentManagerContext Context { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Export ("nowPlayingIdentifiers", ArgumentSemantic.Strong)]
		string[] NowPlayingIdentifiers { get; set; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 8, 4)]
	[BaseType (typeof (NSObject))]
	interface MPPlayableContentManagerContext {
		[Export ("enforcedContentItemsCount")]
		nint EnforcedContentItemsCount { get; }

		[Export ("enforcedContentTreeDepth")]
		nint EnforcedContentTreeDepth { get; }

		// iOS 9 beta 2 changed this from contentLimitsEnabled - but the final iOS8.4 release used contentLimitsEnabled
		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("contentLimitsEnforced")]
		bool ContentLimitsEnforced { get; }

		[Introduced (PlatformName.iOS, 8, 4, message: "Replaced by 'ContentLimitsEnforced'."), Deprecated (PlatformName.iOS, 9, 0, message: "Replaced by 'ContentLimitsEnforced'.")]
		[Export ("contentLimitsEnabled")]
		bool ContentLimitsEnabled { get; }

		[Export ("endpointAvailable")]
		bool EndpointAvailable { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // NSGenericException Reason: MPRemoteCommands cannot be initialized externally.
	interface MPRemoteCommand {

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("addTarget:action:")]
		void AddTarget (NSObject target, Selector action);

		[Export ("addTargetWithHandler:")]
		NSObject AddTarget (Func<MPRemoteCommandEvent,MPRemoteCommandHandlerStatus> handler);

		[Export ("removeTarget:")]
		void RemoveTarget (NSObject target);

		[Export ("removeTarget:action:")]
		void RemoveTarget ([NullAllowed] NSObject target, Selector action);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangePlaybackRateCommands cannot be initialized externally.
	interface MPChangePlaybackRateCommand {

		[Export ("supportedPlaybackRates")]
		NSNumber[] SupportedPlaybackRates { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangeShuffleModeCommand cannot be initialized externally.
	interface MPChangeShuffleModeCommand
	{
		[Export ("currentShuffleType", ArgumentSemantic.Assign)]
		MPShuffleType CurrentShuffleType { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangeRepeatModeCommand cannot be initialized externally.
	interface MPChangeRepeatModeCommand
	{
		[Export ("currentRepeatType", ArgumentSemantic.Assign)]
		MPRepeatType CurrentRepeatType { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPFeedbackCommands cannot be initialized externally.
	interface MPFeedbackCommand {

		[Export ("active")]
		bool Active { [Bind ("isActive")] get; set; }

		[Export ("localizedTitle")]
		string LocalizedTitle { get; set; }

		[Introduced (PlatformName.iOS, 8, 2)] // added in 8.2, shown as NS_AVAILABLE_IOS(8_0)
		[Export ("localizedShortTitle")]
		string LocalizedShortTitle { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPRatingCommands cannot be initialized externally.
	interface MPRatingCommand {

		[Export ("maximumRating")]
		float MaximumRating { get; set; } /* float, not CGFloat */

		[Export ("minimumRating")]
		float MinimumRating { get; set; } /* float, not CGFloat */
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // NSGenericException Reason: MPSkipIntervalCommands cannot be initialized externally.
	interface MPSkipIntervalCommand {

#if XAMCORE_2_0
		[Internal] // -> we can't do double[] for an NSArray of NSTimeInterval
#endif
		[Export ("preferredIntervals")]
		NSArray _PreferredIntervals { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPRemoteCommandCenter {
		[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
		[Static]
		[Export ("sharedCommandCenter")]
		MPRemoteCommandCenter Shared { get; }

		[Export ("bookmarkCommand")]
		MPFeedbackCommand BookmarkCommand { get; }

		[Export ("changePlaybackRateCommand")]
		MPChangePlaybackRateCommand ChangePlaybackRateCommand { get; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("changeRepeatModeCommand")]
		MPChangeRepeatModeCommand ChangeRepeatModeCommand { get; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("changeShuffleModeCommand")]
		MPChangeShuffleModeCommand ChangeShuffleModeCommand { get; }

		[Export ("dislikeCommand")]
		MPFeedbackCommand DislikeCommand { get; }

		[Export ("likeCommand")]
		MPFeedbackCommand LikeCommand { get; }

		[Export ("nextTrackCommand")]
		MPRemoteCommand NextTrackCommand { get; }

		[Export ("pauseCommand")]
		MPRemoteCommand PauseCommand { get; }

		[Export ("playCommand")]
		MPRemoteCommand PlayCommand { get; }

		[Export ("previousTrackCommand")]
		MPRemoteCommand PreviousTrackCommand { get; }

		[Export ("ratingCommand")]
		MPRatingCommand RatingCommand { get; }

		[Export ("seekBackwardCommand")]
		MPRemoteCommand SeekBackwardCommand { get; }

		[Export ("seekForwardCommand")]
		MPRemoteCommand SeekForwardCommand { get; }

		[Export ("skipBackwardCommand")]
		MPSkipIntervalCommand SkipBackwardCommand { get; }

		[Export ("skipForwardCommand")]
		MPSkipIntervalCommand SkipForwardCommand { get; }

		[Export ("stopCommand")]
		MPRemoteCommand StopCommand { get; }

		[Export ("togglePlayPauseCommand")]
		MPRemoteCommand TogglePlayPauseCommand { get; }

		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("enableLanguageOptionCommand")]
		MPRemoteCommand EnableLanguageOptionCommand { get; }

		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("disableLanguageOptionCommand")]
		MPRemoteCommand DisableLanguageOptionCommand { get; }

		[Introduced (PlatformName.iOS, 9, 1)]
		[Export ("changePlaybackPositionCommand")]
		MPChangePlaybackPositionCommand ChangePlaybackPositionCommand { get; }
	}
	
	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // NSGenericException Reason: MPRemoteCommandEvents cannot be initialized externally.
	interface MPRemoteCommandEvent {

		[Export ("command")]
		MPRemoteCommand Command { get; }

		[Export ("timestamp")]
		double /* NSTimeInterval */ Timestamp { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangePlaybackRateCommandEvents cannot be initialized externally.
	interface MPChangePlaybackRateCommandEvent {

		[Export ("playbackRate")]
		float PlaybackRate { get; } // float, not CGFloat
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPRatingCommandEvents cannot be initialized externally.
	interface MPRatingCommandEvent {

		[Export ("rating")]
		float Rating { get; } // float, not CGFloat
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // Name: NSGenericException Reason: MPSeekCommandEvents cannot be initialized externally.
	interface MPSeekCommandEvent {

		[Export ("type")]
		MPSeekCommandEventType Type { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPSkipIntervalCommandEvents cannot be initialized externally.
	interface MPSkipIntervalCommandEvent {

		[Export ("interval")]
		double /* NSTimeInterval */ Interval { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor]
	interface MPFeedbackCommandEvent {

		[Export ("negative")]
		bool Negative { [Bind ("isNegative")] get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangeLanguageOptionCommandEvents cannot be initialized externally.
	interface MPChangeLanguageOptionCommandEvent {
		[Export ("languageOption")]
		MPNowPlayingInfoLanguageOption LanguageOption { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("setting")]
		MPChangeLanguageOptionSetting Setting { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangeShuffleModeCommandEvent cannot be initialized externally.
	interface MPChangeShuffleModeCommandEvent
	{
		[Export ("shuffleType")]
		MPShuffleType ShuffleType { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("preservesShuffleMode")]
		bool PreservesShuffleMode { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // NSGenericException Reason: MPChangeRepeatModeCommandEvent cannot be initialized externally.
	interface MPChangeRepeatModeCommandEvent
	{
		[Export ("repeatType")]
		MPRepeatType RepeatType { get; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Export ("preservesRepeatMode")]
		bool PreservesRepeatMode { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // pre-emptive
	interface MPNowPlayingInfoLanguageOption {
		[Export ("initWithType:languageTag:characteristics:displayName:identifier:")]
		IntPtr Constructor (MPNowPlayingInfoLanguageOptionType languageOptionType, string languageTag, [NullAllowed] NSString[] languageOptionCharacteristics, string displayName, string identifier);

		[Export ("languageOptionType")]
		MPNowPlayingInfoLanguageOptionType LanguageOptionType { get; }

		[NullAllowed, Export ("languageTag")]
		string LanguageTag { get; }

		[NullAllowed, Export ("languageOptionCharacteristics")]
		NSString[] LanguageOptionCharacteristics { get; }

		[NullAllowed]
		[Export ("displayName")]
		string DisplayName { get; }

		[NullAllowed]
		[Export ("identifier")]
		string Identifier { get; }

		[Export ("isAutomaticLegibleLanguageOption")]
		bool IsAutomaticLegibleLanguageOption { get; }

		[Introduced (PlatformName.iOS, 9, 1)][Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("isAutomaticAudibleLanguageOption")]
		bool IsAutomaticAudibleLanguageOption { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // pre-emptive
	interface MPNowPlayingInfoLanguageOptionGroup {
		[Export ("initWithLanguageOptions:defaultLanguageOption:allowEmptySelection:")]
		IntPtr Constructor (MPNowPlayingInfoLanguageOption[] languageOptions, [NullAllowed] MPNowPlayingInfoLanguageOption defaultLanguageOption, bool allowEmptySelection);

		[Export ("languageOptions")]
		MPNowPlayingInfoLanguageOption[] LanguageOptions { get; }

		[NullAllowed, Export ("defaultLanguageOption")]
		MPNowPlayingInfoLanguageOption DefaultLanguageOption { get; }

		[Export ("allowEmptySelection")]
		bool AllowEmptySelection { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Static]
	// not [Internal] since they are exposed as an NSString[] property in MPNowPlayingInfoLanguageOption
	interface MPLanguageOptionCharacteristics {
		[Field ("MPLanguageOptionCharacteristicIsMainProgramContent")]
		NSString IsMainProgramContent { get; }

		[Field ("MPLanguageOptionCharacteristicIsAuxiliaryContent")]
		NSString IsAuxiliaryContent { get; }

		[Field ("MPLanguageOptionCharacteristicContainsOnlyForcedSubtitles")]
		NSString ContainsOnlyForcedSubtitles { get; }

		[Field ("MPLanguageOptionCharacteristicTranscribesSpokenDialog")]
		NSString TranscribesSpokenDialog { get; }

		[Field ("MPLanguageOptionCharacteristicDescribesMusicAndSound")]
		NSString DescribesMusicAndSound { get; }

		[Field ("MPLanguageOptionCharacteristicEasyToRead")]
		NSString EasyToRead { get; }

		[Field ("MPLanguageOptionCharacteristicDescribesVideo")]
		NSString DescribesVideo { get; }

		[Field ("MPLanguageOptionCharacteristicLanguageTranslation")]
		NSString LanguageTranslation { get; }

		[Field ("MPLanguageOptionCharacteristicDubbedTranslation")]
		NSString DubbedTranslation { get; }

		[Field ("MPLanguageOptionCharacteristicVoiceOverTranslation")]
		NSString VoiceOverTranslation { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 1)]
	[BaseType (typeof (MPRemoteCommand))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSGenericException Reason: MPChangePlaybackPositionCommands cannot be initialized externally.
	interface MPChangePlaybackPositionCommand {
	}

	[Introduced (PlatformName.MacOSX, 10, 12, 2, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.iOS, 9, 1)]
	[BaseType (typeof (MPRemoteCommandEvent))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSGenericException Reason: MPChangePlaybackPositionCommandEvents cannot be initialized externally.
	interface MPChangePlaybackPositionCommandEvent {
		[Export ("positionTime")]
		double PositionTime { get; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)][Introduced (PlatformName.iOS, 9, 3)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPMediaPlaylistCreationMetadata {
		[Export ("initWithName:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name);

		[Export ("name")]
		string Name { get; }

		[NullAllowed] // null_resettable
		[Export ("authorDisplayName")]
		string AuthorDisplayName { get; set; }

		[Export ("descriptionText")]
		string DescriptionText { get; set; }
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 10, 1)]
	[BaseType (typeof (NSObject))]
	interface MPMusicPlayerQueueDescriptor : NSSecureCoding {}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 10, 1)]
	[BaseType (typeof (MPMusicPlayerQueueDescriptor))]
	interface MPMusicPlayerMediaItemQueueDescriptor
	{
		[Export ("initWithQuery:")]
		IntPtr Constructor (MPMediaQuery query);

		[Export ("initWithItemCollection:")]
		IntPtr Constructor (MPMediaItemCollection itemCollection);

		[Export ("query", ArgumentSemantic.Copy)]
		MPMediaQuery Query { get; }

		[Export ("itemCollection", ArgumentSemantic.Strong)]
		MPMediaItemCollection ItemCollection { get; }

		[NullAllowed, Export ("startItem", ArgumentSemantic.Strong)]
		MPMediaItem StartItem { get; set; }

		[Export ("setStartTime:forItem:")]
		void SetStartTime (double startTime, MPMediaItem mediaItem);

		[Export ("setEndTime:forItem:")]
		void SetEndTime (double endTime, MPMediaItem mediaItem);
	}

	[Unavailable (PlatformName.MacOSX)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 10, 1)]
	[BaseType (typeof (MPMusicPlayerQueueDescriptor))]
	interface MPMusicPlayerStoreQueueDescriptor
	{
		[Export ("initWithStoreIDs:")]
		IntPtr Constructor (string[] storeIDs);

		[NullAllowed, Export ("storeIDs", ArgumentSemantic.Copy)]
		string[] StoreIDs { get; set; }

		[NullAllowed, Export ("startItemID")]
		string StartItemID { get; set; }

		[Export ("setStartTime:forItemWithStoreID:")]
		void SetStartTime (double startTime, string storeID);

		[Export ("setEndTime:forItemWithStoreID:")]
		void SetEndTime (double endTime, string storeID);
	}

	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 10, 3)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPMusicPlayerControllerQueue
	{
		[Export ("items", ArgumentSemantic.Copy)]
		MPMediaItem[] Items { get; }

		[Field ("MPMusicPlayerControllerQueueDidChangeNotification")]
		[Notification]
		NSString DidChangeNotification { get; }
	}

	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 10, 3)]
	[BaseType (typeof (MPMusicPlayerControllerQueue))]
	interface MPMusicPlayerControllerMutableQueue
	{
		[Export ("insertQueueDescriptor:afterItem:")]
		void InsertAfter (MPMusicPlayerQueueDescriptor queueDescriptor, [NullAllowed] MPMediaItem item);

		[Export ("removeItem:")]
		void RemoveItem (MPMediaItem item);
	}

	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 10, 3)]
	[BaseType (typeof (MPMusicPlayerController))]
	interface MPMusicPlayerApplicationController
	{
		[Async]
		[Export ("performQueueTransaction:completionHandler:")]
		void Perform (Action<MPMusicPlayerControllerMutableQueue> queueTransaction, Action<MPMusicPlayerControllerQueue, NSError> completionHandler);
	}

	[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MPMusicPlayerPlayParameters : NSSecureCoding {
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		[Export ("dictionary", ArgumentSemantic.Copy)]
		NSDictionary Dictionary { get; }
	}

	[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (MPMusicPlayerQueueDescriptor))]
	[DisableDefaultCtor]
	interface MPMusicPlayerPlayParametersQueueDescriptor {
		[Export ("initWithPlayParametersQueue:")]
		IntPtr Constructor (MPMusicPlayerPlayParameters[] playParametersQueue);

		[Export ("playParametersQueue", ArgumentSemantic.Copy)]
		MPMusicPlayerPlayParameters[] PlayParametersQueue { get; set; }

		[NullAllowed, Export ("startItemPlayParameters", ArgumentSemantic.Strong)]
		MPMusicPlayerPlayParameters StartItemPlayParameters { get; set; }

		[Export ("setStartTime:forItemWithPlayParameters:")]
		void SetStartTime (/* NSTimeInterval */ double startTime, MPMusicPlayerPlayParameters playParameters);

		[Export ("setEndTime:forItemWithPlayParameters:")]
		void SetEndTime (/* NSTimeInterval */ double endTime, MPMusicPlayerPlayParameters playParameters);
	}

	interface IMPSystemMusicPlayerController {}

	[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.iOS, 11, 0)]
	[Protocol]
	interface MPSystemMusicPlayerController {
		[Abstract]
		[Export ("openToPlayQueueDescriptor:")]
		void OpenToPlay (MPMusicPlayerQueueDescriptor queueDescriptor);
	}

	[Category]
	[BaseType (typeof (NSUserActivity))]
	[Introduced (PlatformName.TvOS, 10, 0, 1)][Introduced (PlatformName.iOS, 10, 1)]
	[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.MacOSX)]
	interface NSUserActivity_MediaPlayerAdditions {
		[NullAllowed, Export ("externalMediaContentIdentifier")]
		NSString GetExternalMediaContentIdentifier ();

		[NullAllowed, Export ("setExternalMediaContentIdentifier:")]
		void SetExternalMediaContentIdentifier (NSString identifier);
	}
#endif
}

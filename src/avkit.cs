//
// avkit.cs: Definitions for AVKit.cs
//
// Copyright 2014-2015 Xamarin Inc
using System;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreImage;
using CoreMedia;
using CoreVideo;
using AVFoundation;
#if !MONOMAC
using OpenGLES;
using UIKit;
#else
using AppKit;
#endif

namespace AVKit {
#if !MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
#if XAMCORE_4_0
	[Sealed] // Apple docs: Do not subclass AVPictureInPictureController. Overriding this class’s methods is unsupported and results in undefined behavior.
#endif
	interface AVPictureInPictureController
	{
		[Static]
		[Export ("isPictureInPictureSupported")]
		bool IsPictureInPictureSupported { get; }
	
		[Export ("initWithPlayerLayer:")]
		[DesignatedInitializer]
		IntPtr Constructor (AVPlayerLayer playerLayer);
	
		[Export ("playerLayer")]
		AVPlayerLayer PlayerLayer { get; }
	
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		[Protocolize]
		AVPictureInPictureControllerDelegate Delegate { get; set; }
	
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	
		[Export ("startPictureInPicture")]
		void StartPictureInPicture ();
	
		[Export ("stopPictureInPicture")]
		void StopPictureInPicture ();
	
		[Export ("pictureInPicturePossible")]
		bool PictureInPicturePossible { [Bind ("isPictureInPicturePossible")] get; }
	
		[Export ("pictureInPictureActive")]
		bool PictureInPictureActive { [Bind ("isPictureInPictureActive")] get; }
	
		[Export ("pictureInPictureSuspended")]
		bool PictureInPictureSuspended { [Bind ("isPictureInPictureSuspended")] get; }

		
		[Static]
		[Export ("pictureInPictureButtonStartImageCompatibleWithTraitCollection:")]
		UIImage CreateStartButton ([NullAllowed] UITraitCollection traitCollection);

		[Static]
		[Export ("pictureInPictureButtonStopImageCompatibleWithTraitCollection:")]
		UIImage CreateStopButton ([NullAllowed] UITraitCollection traitCollection);
	}

	[Unavailable (PlatformName.TvOS)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface AVPictureInPictureControllerDelegate
	{
		[Export ("pictureInPictureControllerWillStartPictureInPicture:")]
		void WillStartPictureInPicture (AVPictureInPictureController pictureInPictureController);
	
		[Export ("pictureInPictureControllerDidStartPictureInPicture:")]
		void DidStartPictureInPicture (AVPictureInPictureController pictureInPictureController);
	
		[Export ("pictureInPictureController:failedToStartPictureInPictureWithError:")]
		void FailedToStartPictureInPicture (AVPictureInPictureController pictureInPictureController, NSError error);
	
		[Export ("pictureInPictureControllerWillStopPictureInPicture:")]
		void WillStopPictureInPicture (AVPictureInPictureController pictureInPictureController);
	
		[Export ("pictureInPictureControllerDidStopPictureInPicture:")]
		void DidStopPictureInPicture (AVPictureInPictureController pictureInPictureController);
	
		[Export ("pictureInPictureController:restoreUserInterfaceForPictureInPictureStopWithCompletionHandler:")]
		void RestoreUserInterfaceForPictureInPicture (AVPictureInPictureController pictureInPictureController, Action<bool> completionHandler);
	}
	

	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (UIViewController))]
	interface AVPlayerViewController {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[NullAllowed] // by default this property is null
		[Export ("player", ArgumentSemantic.Retain)]
		AVPlayer Player { get; set; }

		[Export ("showsPlaybackControls")]
		bool ShowsPlaybackControls { get; set; }

		[Export ("videoGravity")]
		NSString WeakVideoGravity { get; set; }

		[Export ("readyForDisplay")]
		bool ReadyForDisplay { [Bind ("isReadyForDisplay")] get; }

		[Unavailable (PlatformName.TvOS)]
		[Export ("videoBounds")]
		CGRect VideoBounds { get; }

		[Export ("contentOverlayView")]
		UIView ContentOverlayView { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Unavailable (PlatformName.iOS)]
		[NullAllowed, Export ("unobscuredContentGuide")]
		UILayoutGuide UnobscuredContentGuide { get; }

		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("allowsPictureInPicturePlayback")]
		bool AllowsPictureInPicturePlayback { get; set; }

		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 10, 0)]
		[Export ("updatesNowPlayingInfoCenter")]
		bool UpdatesNowPlayingInfoCenter { get; set; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("entersFullScreenWhenPlaybackBegins")]
		bool EntersFullScreenWhenPlaybackBegins { get; set; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("exitsFullScreenWhenPlaybackEnds")]
		bool ExitsFullScreenWhenPlaybackEnds { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		[Protocolize]
		AVPlayerViewControllerDelegate Delegate { get; set; }

		[Introduced (PlatformName.iOS, 9, 0)]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("requiresLinearPlayback")]
		bool RequiresLinearPlayback { get; set; }

#region AVPlayerViewControllerSubtitleOptions
		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[NullAllowed, Export ("allowedSubtitleOptionLanguages", ArgumentSemantic.Copy)]
		string[] AllowedSubtitleOptionLanguages { get; set; }

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("requiresFullSubtitles")]
		bool RequiresFullSubtitles { get; set; }
#endregion
#if !MONOMAC
		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("contentProposalViewController", ArgumentSemantic.Assign)]
		AVContentProposalViewController ContentProposalViewController { get; set; }
#endif
		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("skippingBehavior", ArgumentSemantic.Assign)]
		AVPlayerViewControllerSkippingBehavior SkippingBehavior { get; set; }

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("skipForwardEnabled")]
		bool SkipForwardEnabled { [Bind ("isSkipForwardEnabled")] get; set; }

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("skipBackwardEnabled")]
		bool SkipBackwardEnabled { [Bind ("isSkipBackwardEnabled")] get; set; }

		// From AVPlayerViewControllerControls category

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playbackControlsIncludeTransportBar")]
		bool PlaybackControlsIncludeTransportBar { get; set; }

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playbackControlsIncludeInfoViews")]
		bool PlaybackControlsIncludeInfoViews { get; set; }

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("customInfoViewController", ArgumentSemantic.Assign)]
		UIViewController CustomInfoViewController { get; set; }
	}

	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface AVPlayerViewControllerDelegate
	{
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewControllerWillStartPictureInPicture:")]
		void WillStartPictureInPicture (AVPlayerViewController playerViewController);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewControllerDidStartPictureInPicture:")]
		void DidStartPictureInPicture (AVPlayerViewController playerViewController);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewController:failedToStartPictureInPictureWithError:")]
		void FailedToStartPictureInPicture (AVPlayerViewController playerViewController, NSError error);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewControllerWillStopPictureInPicture:")]
		void WillStopPictureInPicture (AVPlayerViewController playerViewController);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewControllerDidStopPictureInPicture:")]
		void DidStopPictureInPicture (AVPlayerViewController playerViewController);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewControllerShouldAutomaticallyDismissAtPictureInPictureStart:")]
		bool ShouldAutomaticallyDismissAtPictureInPictureStart (AVPlayerViewController playerViewController);
	
		[Unavailable (PlatformName.TvOS)]
		[Export ("playerViewController:restoreUserInterfaceForPictureInPictureStopWithCompletionHandler:")]
		void RestoreUserInterfaceForPictureInPicture (AVPlayerViewController playerViewController, Action<bool> completionHandler);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("playerViewController:didPresentInterstitialTimeRange:")]
		void DidPresentInterstitialTimeRange (AVPlayerViewController playerViewController, AVInterstitialTimeRange interstitial);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 11, 0)]
		[Export ("playerViewControllerShouldDismiss:")]
		bool ShouldDismiss ([NullAllowed] AVPlayerViewController playerViewController);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 11, 0)]
		[Export ("playerViewControllerWillBeginDismissalTransition:")]
		void WillBeginDismissalTransition ([NullAllowed] AVPlayerViewController playerViewController);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 11, 0)]
		[Export ("playerViewControllerDidEndDismissalTransition:")]
		void DidEndDismissalTransition ([NullAllowed] AVPlayerViewController playerViewController);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("playerViewController:willPresentInterstitialTimeRange:")]
		void WillPresentInterstitialTimeRange (AVPlayerViewController playerViewController, AVInterstitialTimeRange interstitial);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("playerViewController:willResumePlaybackAfterUserNavigatedFromTime:toTime:")]
		void WillResumePlaybackAfterUserNavigatedFromTime (AVPlayerViewController playerViewController, CMTime oldTime, CMTime targetTime);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("playerViewController:didSelectMediaSelectionOption:inMediaSelectionGroup:")]
		void DidSelectMediaSelectionOption (AVPlayerViewController playerViewController, [NullAllowed] AVMediaSelectionOption mediaSelectionOption, AVMediaSelectionGroup mediaSelectionGroup);

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
		[Introduced (PlatformName.TvOS, 9, 0)]
		[Export ("playerViewController:didSelectExternalSubtitleOptionLanguage:")]
		void DidSelectExternalSubtitleOptionLanguage (AVPlayerViewController playerViewController, string language);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playerViewController:timeToSeekAfterUserNavigatedFromTime:toTime:")]
		CMTime GetTimeToSeekAfterUserNavigated (AVPlayerViewController playerViewController, CMTime oldTime, CMTime targetTime);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("skipToNextItemForPlayerViewController:")]
		void SkipToNextItem (AVPlayerViewController playerViewController);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("skipToPreviousItemForPlayerViewController:")]
		void SkipToPreviousItem (AVPlayerViewController playerViewController);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playerViewController:shouldPresentContentProposal:")]
		bool ShouldPresentContentProposal (AVPlayerViewController playerViewController, AVContentProposal proposal);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playerViewController:didAcceptContentProposal:")]
		void DidAcceptContentProposal (AVPlayerViewController playerViewController, AVContentProposal proposal);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playerViewController:didRejectContentProposal:")]
		void DidRejectContentProposal (AVPlayerViewController playerViewController, AVContentProposal proposal);

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		[Export ("playerViewController:willTransitionToVisibilityOfTransportBar:withAnimationCoordinator:")]
		void WillTransitionToVisibilityOfTransportBar ([NullAllowed] AVPlayerViewController playerViewController, bool visible, [NullAllowed] IAVPlayerViewControllerAnimationCoordinator coordinator);
	}

	interface IAVPlayerViewControllerAnimationCoordinator { }

	[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
	[Protocol]
	interface AVPlayerViewControllerAnimationCoordinator {

		[Abstract]
		[Export ("addCoordinatedAnimations:completion:")]
		void AddCoordinatedAnimations (Action animations, Action<bool> completion);
	}

#else

	[Introduced (PlatformName.MacOSX, 10, 9, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSView))]
	interface AVPlayerView {

		[Export ("player")]
		AVPlayer Player { get; set; }

		[Export ("controlsStyle")]
		AVPlayerViewControlsStyle ControlsStyle { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Export ("videoGravity")]
		string VideoGravity { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Export ("readyForDisplay")]
		bool ReadyForDisplay { [Bind ("isReadyForDisplay")] get; }

		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Export ("videoBounds")]
		CGRect VideoBounds { get; }

		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Export ("contentOverlayView")]
		NSView ContentOverlayView { get; }

		[Introduced (PlatformName.MacOSX, 10, 13)]
		[Export ("updatesNowPlayingInfoCenter")]
		bool UpdatesNowPlayingInfoCenter { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("actionPopUpButtonMenu")]
		NSMenu ActionPopUpButtonMenu { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 9)] // No async
		[Export ("beginTrimmingWithCompletionHandler:")]
		void BeginTrimming (Action<AVPlayerViewTrimResult> handler);

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("canBeginTrimming")]
		bool CanBeginTrimming { get; }

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("flashChapterNumber:chapterTitle:")]
		void FlashChapter (nuint chapterNumber, string chapterTitle);

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("showsFrameSteppingButtons")]
		bool ShowsFrameSteppingButtons { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("showsFullScreenToggleButton")]
		bool ShowsFullScreenToggleButton { get; set; }

		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Export ("showsSharingServiceButton")]
		bool ShowsSharingServiceButton { get; set; }
	}

	[Introduced (PlatformName.MacOSX, 10, 10, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSView))]
	interface AVCaptureView {

		[Export ("session"), NullAllowed]
		AVCaptureSession Session { get; }

		[Export ("setSession:showVideoPreview:showAudioPreview:")]
		void SetSession ([NullAllowed] AVCaptureSession session, bool showVideoPreview, bool showAudioPreview);

		[Export ("fileOutput"), NullAllowed]
		AVCaptureFileOutput FileOutput { get; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		IAVCaptureViewDelegate Delegate { get; set; }

		[Export ("controlsStyle")]
		AVCaptureViewControlsStyle ControlsStyle { get; set; }

		// TODO: Create an enum version of this property
		[Export ("videoGravity", ArgumentSemantic.Copy)]
		NSString WeakVideoGravity { get; set; }
	}

	interface IAVCaptureViewDelegate { }

	[Protocol, Model]
	[Introduced (PlatformName.MacOSX, 10, 10, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface AVCaptureViewDelegate {
		[Abstract]
		[Export ("captureView:startRecordingToFileOutput:")]
		void StartRecording (AVCaptureView captureView, AVCaptureFileOutput fileOutput);
	}
#endif

	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.TvOS, 9, 0)]
	[BaseType (typeof (NSObject))]
	interface AVInterstitialTimeRange : NSCopying, NSSecureCoding {
		[Export ("initWithTimeRange:")]
		[DesignatedInitializer]
		IntPtr Constructor (CMTimeRange timeRange);

		[Export ("timeRange")]
		CMTimeRange TimeRange { get; }
	}

	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.MacOSX)]
	[Introduced (PlatformName.TvOS, 9, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface AVNavigationMarkersGroup {
		[Export ("initWithTitle:timedNavigationMarkers:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string title, AVTimedMetadataGroup[] navigationMarkers);

		[Export ("initWithTitle:dateRangeNavigationMarkers:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string title, AVDateRangeMetadataGroup[] navigationMarkers);

		[NullAllowed, Export ("title")]
		string Title { get; }

		[NullAllowed, Export ("timedNavigationMarkers")]
		AVTimedMetadataGroup[] TimedNavigationMarkers { get; }

		[NullAllowed, Export ("dateRangeNavigationMarkers")]
		AVDateRangeMetadataGroup[] DateRangeNavigationMarkers { get; }
	}
	
#if !MONOMAC
	[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS)]
	[BaseType (typeof (UIViewController))]
	interface AVContentProposalViewController
	{
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);
		
		[NullAllowed, Export ("contentProposal")]
		AVContentProposal ContentProposal { get; }

		[NullAllowed, Export ("playerViewController", ArgumentSemantic.Weak)]
		AVPlayerViewController PlayerViewController { get; }

		[Export ("preferredPlayerViewFrame")]
		CGRect PreferredPlayerViewFrame { get; }

		[Export ("playerLayoutGuide")]
		UILayoutGuide PlayerLayoutGuide { get; }

		[NullAllowed, Export ("dateOfAutomaticAcceptance", ArgumentSemantic.Assign)]
		NSDate DateOfAutomaticAcceptance { get; set; }

		[Export ("dismissContentProposalForAction:animated:completion:")]
		void DismissContentProposal (AVContentProposalAction action, bool animated, [NullAllowed] Action block);
	}

	[Static]
	[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 1), Unavailable (PlatformName.WatchOS)]
	interface AVKitMetadataIdentifier {

		[Field ("AVKitMetadataIdentifierExternalContentIdentifier")]
		NSString ExternalContentIdentifier { get; }
		[Field ("AVKitMetadataIdentifierExternalUserProfileIdentifier")]
		NSString ExternalUserProfileIdentifier { get; }
		[Field ("AVKitMetadataIdentifierPlaybackProgress")]
		NSString PlaybackProgress { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("AVKitMetadataIdentifierExactStartDate")]
		NSString ExactStartDate { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("AVKitMetadataIdentifierApproximateStartDate")]
		NSString ApproximateStartDate { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("AVKitMetadataIdentifierExactEndDate")]
		NSString ExactEndDate { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("AVKitMetadataIdentifierApproximateEndDate")]
		NSString ApproximateEndDate { get; }

		[Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("AVKitMetadataIdentifierServiceIdentifier")]
		NSString ServiceIdentifier { get; }
	}

	[Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (UIView))]
	interface AVRoutePickerView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IAVRoutePickerViewDelegate Delegate { get; set; }

		[Export ("activeTintColor", ArgumentSemantic.Assign), NullAllowed]
		UIColor ActiveTintColor { get; set; }

		[Unavailable (PlatformName.iOS)]
		[Export ("routePickerButtonStyle", ArgumentSemantic.Assign)]
		AVRoutePickerViewButtonStyle RoutePickerButtonStyle { get; set; }
	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.iOS)]
	[Native]
	public enum AVRoutePickerViewButtonStyle : long {
		System,
		Plain,
		Custom,
	}

	interface IAVRoutePickerViewDelegate { }

	[Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface AVRoutePickerViewDelegate {

		[Export ("routePickerViewWillBeginPresentingRoutes:")]
		void WillBeginPresentingRoutes (AVRoutePickerView routePickerView);

		[Export ("routePickerViewDidEndPresentingRoutes:")]
		void DidEndPresentingRoutes (AVRoutePickerView routePickerView);
	}
#endif
}

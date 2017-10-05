using CoreGraphics;
using ObjCRuntime;
using Foundation;
#if !MONOMAC
using UIKit;
#else
using AppKit;
using UIImage = AppKit.NSImage;
#endif
using Photos;
using System;

namespace PhotosUI {
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Protocol]
#if !XAMCORE_4_0 && !TVOS && !MONOMAC
	// According to documentation you're supposed to implement this protocol in a UIViewController subclass,
	// which means a model (which does not inherit from UIViewController) is not useful.
	[Model]
	[BaseType (typeof (NSObject))]
#endif
	interface PHContentEditingController {

		[Abstract]
		[Export ("canHandleAdjustmentData:")]
		bool CanHandleAdjustmentData (PHAdjustmentData adjustmentData);

		[Abstract]
		[Export ("startContentEditingWithInput:placeholderImage:")]
		void StartContentEditing (PHContentEditingInput contentEditingInput, UIImage placeholderImage);

		[Abstract]
		[Export ("finishContentEditingWithCompletionHandler:")]
		void FinishContentEditing ([NullAllowed] Action<PHContentEditingOutput> completionHandler);

		[Abstract]
		[Export ("cancelContentEditing")]
		void CancelContentEditing ();

		[Abstract]
		[Export ("shouldShowCancelConfirmation")]
		bool ShouldShowCancelConfirmation { get; }
	}

#if !MONOMAC
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 9, 1)]
	[BaseType (typeof (UIView))]
	interface PHLivePhotoView {

		// inlined (designated initializer)
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Static]
		[Export ("livePhotoBadgeImageWithOptions:")]
		UIImage GetLivePhotoBadgeImage (PHLivePhotoBadgeOptions badgeOptions);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		[Protocolize]
		PHLivePhotoViewDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[NullAllowed, Export ("livePhoto", ArgumentSemantic.Strong)]
		PHLivePhoto LivePhoto { get; set; }

		[Export ("playbackGestureRecognizer", ArgumentSemantic.Strong)]
		UIGestureRecognizer PlaybackGestureRecognizer { get; }

		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		[Export ("startPlaybackWithStyle:")]
		void StartPlayback (PHLivePhotoViewPlaybackStyle playbackStyle);

		[Export ("stopPlayback")]
		void StopPlayback ();
	}

	[Introduced (PlatformName.TvOS, 10, 0)]
	[Introduced (PlatformName.iOS, 9, 1)][Unavailable (PlatformName.MacOSX)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PHLivePhotoViewDelegate {
		[Export ("livePhotoView:willBeginPlaybackWithStyle:")]
		void WillBeginPlayback (PHLivePhotoView livePhotoView, PHLivePhotoViewPlaybackStyle playbackStyle);

		[Export ("livePhotoView:didEndPlaybackWithStyle:")]
		void DidEndPlayback (PHLivePhotoView livePhotoView, PHLivePhotoViewPlaybackStyle playbackStyle);
	}
#endif

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)][Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.WatchOS)]
	[Static]
	interface PHProjectType {
		[Field ("PHProjectTypeUndefined")]
		NSString Undefined { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSExtensionContext))]
	interface PHProjectExtensionContext : NSSecureCoding, NSCopying {

		[Export ("photoLibrary")]
		PHPhotoLibrary PhotoLibrary { get; }

		[Export ("project")]
		PHProject Project { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[DisableDefaultCtor]
	[BaseType (typeof (PHProjectElement))]
	interface PHProjectJournalEntryElement : NSSecureCoding {

		[Export ("date")]
		NSDate Date { get; }

		[NullAllowed, Export ("assetElement")]
		PHProjectAssetElement AssetElement { get; }

		[NullAllowed, Export ("textElement")]
		PHProjectTextElement TextElement { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[DisableDefaultCtor]
	[BaseType (typeof (PHProjectElement))]
	interface PHProjectTextElement : NSSecureCoding {

		[Export ("text")]
		string Text { get; }

		[NullAllowed, Export ("attributedText")]
		NSAttributedString AttributedText { get; }

		[Export ("textElementType")]
		PHProjectTextElementType TextElementType { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[Protocol]
	interface PHProjectExtensionController {

		[Export ("supportedProjectTypes", ArgumentSemantic.Copy)]
		PHProjectTypeDescription [] GetSupportedProjectTypes ();

		[Abstract]
		[Export ("beginProjectWithExtensionContext:projectInfo:completion:")]
		void BeginProject (PHProjectExtensionContext extensionContext, PHProjectInfo projectInfo, Action<NSError> completion);

		[Abstract]
		[Export ("resumeProjectWithExtensionContext:completion:")]
		void ResumeProject (PHProjectExtensionContext extensionContext, Action<NSError> completion);

		[Abstract]
		[Export ("finishProjectWithCompletionHandler:")]
		void FinishProject (Action completion);
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectTypeDescription : NSSecureCoding {

		[Export ("projectType")]
		NSString ProjectType { get; }

		[Export ("localizedTitle")]
		string LocalizedTitle { get; }

		[NullAllowed, Export ("localizedDescription")]
		string LocalizedDescription { get; }

		[NullAllowed, Export ("image", ArgumentSemantic.Copy)]
		UIImage Image { get; }

		[Export ("subtypeDescriptions", ArgumentSemantic.Copy)]
		PHProjectTypeDescription[] SubtypeDescriptions { get; }

		[Export ("initWithProjectType:title:description:image:subtypeDescriptions:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSString projectType, string localizedTitle, [NullAllowed] string localizedDescription, [NullAllowed] UIImage image, PHProjectTypeDescription[] subtypeDescriptions);

		[Export ("initWithProjectType:title:description:image:")]
		IntPtr Constructor (NSString projectType, string localizedTitle, [NullAllowed] string localizedDescription, [NullAllowed] UIImage image);
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectRegionOfInterest : NSSecureCoding {

		[Export ("rect")]
		CGRect Rect { get; }

		[Export ("weight")]
		double Weight { get; }

		[Export ("identifier")]
		string Identifier { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectElement : NSSecureCoding {

		[Export ("weight")]
		double Weight { get; }

		[Export ("placement")]
		CGRect Placement { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[DisableDefaultCtor]
	[BaseType (typeof (PHProjectElement))]
	interface PHProjectAssetElement : NSSecureCoding {

		[Export ("cloudAssetIdentifier")]
		PHCloudIdentifier CloudAssetIdentifier { get; }

		[Export ("annotation")]
		string Annotation { get; }

		[Export ("cropRect")]
		CGRect CropRect { get; }

		[Export ("regionsOfInterest")]
		PHProjectRegionOfInterest[] RegionsOfInterest { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectInfo : NSSecureCoding {

		[Export ("creationSource")]
		PHProjectCreationSource CreationSource { get; }

		[Export ("projectType")]
		NSString ProjectType { get; }

		[Export ("sections")]
		PHProjectSection[] Sections { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectSection : NSSecureCoding {

		[Export ("sectionContents")]
		PHProjectSectionContent[] SectionContents { get; }

		[Export ("sectionType")]
		PHProjectSectionType SectionType { get; }

		[Export ("title")]
		string Title { get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PHProjectSectionContent : NSSecureCoding {

		[Export ("elements")]
		PHProjectElement[] Elements { get; }

		[Export ("numberOfColumns")]
		nint NumberOfColumns { get; }

		[Export ("aspectRatio")]
		double AspectRatio { get; }

		[Export ("cloudAssetIdentifiers")]
		PHCloudIdentifier[] CloudAssetIdentifiers { get; }
	}
}
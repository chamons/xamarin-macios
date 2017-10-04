//
// AdLib bindings.
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2010, Novell, Inc.
// Copyright 2011-2014 Xamarin Inc. All rights reserved.
//
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreGraphics;
using XamCore.UIKit;
using XamCore.MediaPlayer;
using System;
using System.ComponentModel;
using XamCore.AVKit;

namespace XamCore.iAd {

	[Introduced (PlatformName.iOS, 4, 0)]
	[Deprecated (PlatformName.iOS, 10, 0)]
	[BaseType (typeof (UIView), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] {typeof (ADBannerViewDelegate)})]
	interface ADBannerView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
		
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("adType")]
		ADAdType AdType { get;  }

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("initWithAdType:")]
		IntPtr Constructor (ADAdType type);

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ADBannerViewDelegate Delegate { get; set; }
		
		[Export ("bannerLoaded")]
		bool BannerLoaded { [Bind ("isBannerLoaded")] get;  }

		[NullAllowed] // by default this property is null
		[Export ("advertisingSection", ArgumentSemantic.Copy)]
		string AdvertisingSection { get; set;  }

		[Export ("bannerViewActionInProgress")]
		bool BannerViewActionInProgress { [Bind ("isBannerViewActionInProgress")] get;  }

		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 6, 0)]
		[NullAllowed] // by default this property is null
		[Export ("requiredContentSizeIdentifiers", ArgumentSemantic.Copy)]
		NSSet RequiredContentSizeIdentifiers { get; set;  }

		[Export ("cancelBannerViewAction")]
		void CancelBannerViewAction ();

		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 6, 0)]
		[NullAllowed] // by default this property is null
		[Export ("currentContentSizeIdentifier", ArgumentSemantic.Copy)]
		string CurrentContentSizeIdentifier { get; set; }

		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 6, 0)]
		[Static, Export ("sizeFromBannerContentSizeIdentifier:")]
		CGSize SizeFromContentSizeIdentifier (string sizeIdentifier);

#if !XAMCORE_3_0
		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 4, 2)]
		[Field ("ADBannerContentSizeIdentifier320x50")]
		NSString SizeIdentifier320x50 { get; }

		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 4, 2)]
		[Field ("ADBannerContentSizeIdentifier480x32")]
		NSString SizeIdentifier480x32 { get; }
#endif

		[Introduced (PlatformName.iOS, 4, 2), Deprecated (PlatformName.iOS, 6, 0)]
		[Field ("ADBannerContentSizeIdentifierLandscape")]
		NSString SizeIdentifierLandscape { get; }

		[Introduced (PlatformName.iOS, 4, 2), Deprecated (PlatformName.iOS, 6, 0)]
		[Field ("ADBannerContentSizeIdentifierPortrait")]
		NSString SizeIdentifierPortrait { get; }
	}

	[Introduced (PlatformName.iOS, 4, 0)]
	[Deprecated (PlatformName.iOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ADBannerViewDelegate {
		[Export ("bannerViewDidLoadAd:")]
		void AdLoaded (ADBannerView banner);

		[Export ("bannerView:didFailToReceiveAdWithError:"), EventArgs ("AdError")]
		void FailedToReceiveAd (ADBannerView banner, NSError error);

		[Export ("bannerViewActionShouldBegin:willLeaveApplication:"), DelegateName ("AdAction"), DefaultValue (true)]
		bool ActionShouldBegin (ADBannerView banner, bool willLeaveApplication);

		[Export ("bannerViewActionDidFinish:")]
		void ActionFinished (ADBannerView banner);

		[Introduced (PlatformName.iOS, 5, 0)]
		[Export ("bannerViewWillLoadAd:"), EventArgs ("EventArgs", true, true)]
		void WillLoad (ADBannerView bannerView);
	}

	[Deprecated (PlatformName.iOS, 10, 0)]
	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] {typeof (ADInterstitialAdDelegate)})]
	interface ADInterstitialAd {
		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ADInterstitialAdDelegate Delegate { get; set;  }

		[Export ("loaded")]
		bool Loaded { [Bind ("isLoaded")] get;  }

		[Export ("actionInProgress")]
		bool ActionInProgress { [Bind ("isActionInProgress")] get;  }

		[Export ("cancelAction")]
		void CancelAction ();

		[Export ("presentInView:")]
		bool PresentInView (UIView containerView);

		[Export ("presentFromViewController:")]
		[Introduced (PlatformName.iOS, 4, 3, message: "Use extension method 'UIViewController.RequestInterstitialAdPresentation' instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use extension method 'UIViewController.RequestInterstitialAdPresentation' instead.")]
		void PresentFromViewController (UIViewController viewController);
	}

	[Deprecated (PlatformName.iOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ADInterstitialAdDelegate {
		[Abstract]
		[Export ("interstitialAdDidUnload:")]
		void AdUnloaded (ADInterstitialAd interstitialAd);

		[Abstract]
		[Export ("interstitialAd:didFailWithError:"), EventArgs ("ADError")]
		void FailedToReceiveAd (ADInterstitialAd interstitialAd, NSError error);

#if !XAMCORE_4_0
		[Abstract]
#endif
		[Export ("interstitialAdDidLoad:")]
		void AdLoaded (ADInterstitialAd interstitialAd);

#if !XAMCORE_4_0
		[Abstract]
#endif
		[Export ("interstitialAdActionShouldBegin:willLeaveApplication:"), DelegateName ("ADPredicate"), DefaultValue (true)]
		bool ActionShouldBegin (ADInterstitialAd interstitialAd, bool willLeaveApplication);

#if !XAMCORE_4_0
		[Abstract]
#endif
		[Export ("interstitialAdActionDidFinish:")]
		void ActionFinished (ADInterstitialAd interstitialAd);

		[Introduced (PlatformName.iOS, 5, 0)]
		[Export ("interstitialAdWillLoad:"), EventArgs ("EventArgs", true, true)]
		void WillLoad (ADInterstitialAd interstitialAd);
	}

	[Category (allowStaticMembers: true)] // Classic isn't internal so we need this
	[BaseType (typeof (MPMoviePlayerController))]
	partial interface IAdPreroll {

#if XAMCORE_2_0
		[Internal]
#else
		[EditorBrowsable (EditorBrowsableState.Advanced)] // this is not the one we want to be seen (compat only)
#endif
		[Introduced (PlatformName.iOS, 7, 0), Static, Export ("preparePrerollAds")]
		void PreparePrerollAds ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("playPrerollAdWithCompletionHandler:")]
#if XAMCORE_2_0
		void PlayPrerollAd (Action<NSError> completionHandler);
#else
		void PlayPrerollAd (PlayPrerollAdCompletionHandler completionHandler);
#endif

		[Introduced (PlatformName.iOS, 8, 0), Export ("cancelPreroll")]
		void CancelPreroll ();
	}

#if !XAMCORE_2_0
	delegate void PlayPrerollAdCompletionHandler (NSError error);
#endif

	[Deprecated (PlatformName.iOS, 10, 0)]
	[Category (allowStaticMembers: true)] // Classic isn't internal so we need this
	[BaseType (typeof (UIViewController))]
	partial interface IAdAdditions {

#if XAMCORE_2_0
		[Internal]
#else
		[EditorBrowsable (EditorBrowsableState.Advanced)] // this is not the one we want to be seen (compat only)
#endif
		[Introduced (PlatformName.iOS, 7, 0), Static, Export ("prepareInterstitialAds")]
		void PrepareInterstitialAds ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("interstitialPresentationPolicy")]
		ADInterstitialPresentationPolicy GetInterstitialPresentationPolicy ();
		
		[Introduced (PlatformName.iOS, 7, 0), Export ("setInterstitialPresentationPolicy:")]
		void SetInterstitialPresentationPolicy (ADInterstitialPresentationPolicy policy);

		[Introduced (PlatformName.iOS, 7, 0), Export ("canDisplayBannerAds")]
		bool GetCanDisplayBannerAds ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("setCanDisplayBannerAds:")]
		void SetCanDisplayBannerAds (bool value);

		[Introduced (PlatformName.iOS, 7, 0), Export ("originalContentView")]
		[NullAllowed]
		UIView GetOriginalContentView ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("isPresentingFullScreenAd")]
		bool PresentingFullScreenAd ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("isDisplayingBannerAd")]
		bool DisplayingBannerAd ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("requestInterstitialAdPresentation")]
		bool RequestInterstitialAdPresentation ();

		[Introduced (PlatformName.iOS, 7, 0), Export ("shouldPresentInterstitialAd")]
		bool ShouldPresentInterstitialAd ();
	}

	delegate void ADConversionDetails (NSDate appPurchaseDate, NSDate iAdImpressionDate);
	
	[Introduced (PlatformName.iOS, 7, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface ADClient {
		[Static]
		[Export ("sharedClient")]
		ADClient SharedClient { get; }

		[Introduced (PlatformName.iOS, 7, 1, message: "Replaced by 'RequestAttributionDetails'."), Deprecated (PlatformName.iOS, 9, 0, message: "Replaced by 'RequestAttributionDetails'.")]
		[Export ("determineAppInstallationAttributionWithCompletionHandler:")]
		void DetermineAppInstallationAttribution (AttributedToiAdCompletionHandler completionHandler);

		[Introduced (PlatformName.iOS, 8, 0, message: "Replaced by 'RequestAttributionDetails'."), Deprecated (PlatformName.iOS, 9, 0, message: "Replaced by 'RequestAttributionDetails'.")]
		[Export ("lookupAdConversionDetails:")]
		[Async (ResultTypeName = "ADClientConversionDetailsResult")]
		void LookupAdConversionDetails (ADConversionDetails onCompleted);

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("addClientToSegments:replaceExisting:")]
		void AddClientToSegments ([NullAllowed] string [] segmentIdentifiers, bool replaceExisting);

		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("requestAttributionDetailsWithBlock:")]
		[Async]
		void RequestAttributionDetails (Action<NSDictionary, NSError> completionHandler);

#if !XAMCORE_4_0
		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("ADClientErrorDomain")]
		NSString ErrorDomain { get; }
#endif
	}

	delegate void AttributedToiAdCompletionHandler (bool attributedToiAd);

	[Category (allowStaticMembers: true)] // Classic isn't internal so we need this
	[BaseType (typeof (AVPlayerViewController))]
	interface iAdPreroll_AVPlayerViewController {
		[Introduced (PlatformName.iOS, 8, 0)]
		[Static, Export ("preparePrerollAds")]
#if XAMCORE_2_0
		[Internal]
#else
		[EditorBrowsable (EditorBrowsableState.Advanced)] // this is not the one we want to be seen (compat only)
#endif
		void PreparePrerollAds ();

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("playPrerollAdWithCompletionHandler:")]
		// [Async] - bug in generator
		void PlayPrerollAd (Action<NSError> completionHandler);

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("cancelPreroll")]
		void CancelPreroll ();
	}
}

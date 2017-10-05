//
// ReplayKit bindings
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.
//

using System;
using AVFoundation;
using CoreMedia;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace ReplayKit {

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (UIViewController))]
	interface RPPreviewViewController {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Export ("previewControllerDelegate", ArgumentSemantic.Weak)][NullAllowed]
		IRPPreviewViewControllerDelegate PreviewControllerDelegate { get; set; }

		[Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.iOS)]
		[Export ("mode", ArgumentSemantic.Assign)]
		RPPreviewViewControllerMode Mode { get; set; }
	}

	interface IRPPreviewViewControllerDelegate { }

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface RPPreviewViewControllerDelegate {

		[Export ("previewControllerDidFinish:")]
		void DidFinish (RPPreviewViewController previewController);

		[Unavailable (PlatformName.TvOS)]
		[Export ("previewController:didFinishWithActivityTypes:")]
		void DidFinish (RPPreviewViewController previewController, NSSet<NSString> activityTypes);
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
#if XAMCORE_4_0
	[Sealed]
#endif
	interface RPScreenRecorder {

		[Static]
		[Export ("sharedRecorder")]
		RPScreenRecorder SharedRecorder { get; }

		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'StartRecording (Action<NSError>)' instead.")]
		[Async]
		[Export ("startRecordingWithMicrophoneEnabled:handler:")]
		void StartRecording (bool microphoneEnabled, [NullAllowed] Action<NSError> handler);

		[Introduced (PlatformName.iOS, 10, 0)]
		[Async]
		[Export ("startRecordingWithHandler:")]
		void StartRecording ([NullAllowed] Action<NSError> handler);

		[Async]
		[Export ("stopRecordingWithHandler:")]
		void StopRecording ([NullAllowed] Action<RPPreviewViewController, NSError> handler);

		[Async]
		[Export ("discardRecordingWithHandler:")]
		void DiscardRecording ([NullAllowed] Action handler);

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IRPScreenRecorderDelegate Delegate { get; set; }

		[Export ("recording", ArgumentSemantic.Assign)]
		bool Recording { [Bind ("isRecording")] get; }

		[Unavailable (PlatformName.TvOS)]
		[Export ("microphoneEnabled", ArgumentSemantic.Assign)]
		bool MicrophoneEnabled {
			[Bind ("isMicrophoneEnabled")] get;
			[Introduced (PlatformName.iOS, 10, 0)] set;
		}

		[Export ("available", ArgumentSemantic.Assign)]
		bool Available { [Bind ("isAvailable")] get; }

		[Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 10, 0)]
		[Export ("cameraEnabled")]
		bool CameraEnabled { [Bind ("isCameraEnabled")] get; set; }

		[Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 10, 0)]
		[NullAllowed, Export ("cameraPreviewView")]
		UIView CameraPreviewView { get; }

		[Unavailable (PlatformName.TvOS)][Introduced (PlatformName.iOS, 11, 0)]
		[Export ("cameraPosition", ArgumentSemantic.Assign)]
		RPCameraPosition CameraPosition { get; set; }

		[Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.iOS, 11, 0)]
		[Async]
		[Export ("startCaptureWithHandler:completionHandler:")]
		void StartCapture ([NullAllowed] Action<CMSampleBuffer, RPSampleBufferType, NSError> captureHandler, [NullAllowed] Action<NSError> completionHandler);

		[Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
		[Async]
		[Export ("stopCaptureWithHandler:")]
		void StopCapture ([NullAllowed] Action<NSError> handler);
	}

	interface IRPScreenRecorderDelegate { }

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface RPScreenRecorderDelegate {

		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'DidStopRecording(RPScreenRecorder,RPPreviewViewController,NSError)' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'DidStopRecording(RPScreenRecorder,RPPreviewViewController,NSError)' instead.")]
		[Export ("screenRecorder:didStopRecordingWithError:previewViewController:")]
		void DidStopRecording (RPScreenRecorder screenRecorder, NSError error, [NullAllowed] RPPreviewViewController previewViewController);

		[Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.iOS, 11, 0)]
		[Export ("screenRecorder:didStopRecordingWithPreviewViewController:error:")]
		void DidStopRecording (RPScreenRecorder screenRecorder, [NullAllowed] RPPreviewViewController previewViewController, [NullAllowed] NSError error);

		[Export ("screenRecorderDidChangeAvailability:")]
		void DidChangeAvailability (RPScreenRecorder screenRecorder);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (UIViewController))]
	interface RPBroadcastActivityViewController {
		// inlined
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Static]
		[Async]
		[Export ("loadBroadcastActivityViewControllerWithHandler:")]
		void LoadBroadcastActivityViewController (Action<RPBroadcastActivityViewController, NSError> handler);

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IRPBroadcastActivityViewControllerDelegate Delegate { get; set; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Unavailable (PlatformName.TvOS)]
		[Static]
		[Async]
		[Export ("loadBroadcastActivityViewControllerWithPreferredExtension:handler:")]
		void LoadBroadcastActivityViewController ([NullAllowed] string preferredExtension, Action<RPBroadcastActivityViewController, NSError> handler);
	}

	interface IRPBroadcastActivityViewControllerDelegate {}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface RPBroadcastActivityViewControllerDelegate {
		[Abstract]
		[Export ("broadcastActivityViewController:didFinishWithBroadcastController:error:")]
		void DidFinish (RPBroadcastActivityViewController broadcastActivityViewController, [NullAllowed] RPBroadcastController broadcastController, [NullAllowed] NSError error);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	interface RPBroadcastController {
		[Export ("broadcasting")]
		bool Broadcasting { [Bind ("isBroadcasting")] get; }

		[Export ("paused")]
		bool Paused { [Bind ("isPaused")] get; }

		[Export ("broadcastURL")]
		NSUrl BroadcastUrl { get; }

		[NullAllowed, Export ("serviceInfo")]
		NSDictionary<NSString, INSCoding> ServiceInfo { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IRPBroadcastControllerDelegate Delegate { get; set; }

		[Deprecated (PlatformName.TvOS, 11, 0)]
		[Deprecated (PlatformName.iOS, 11, 0)]
		[Export ("broadcastExtensionBundleID")]
		string BroadcastExtensionBundleID { get; }

		[Async]
		[Export ("startBroadcastWithHandler:")]
		void StartBroadcast (Action<NSError> handler);

		[Export ("pauseBroadcast")]
		void PauseBroadcast ();

		[Export ("resumeBroadcast")]
		void ResumeBroadcast ();

		[Async]
		[Export ("finishBroadcastWithHandler:")]
		void FinishBroadcast (Action<NSError> handler);
	}

	interface IRPBroadcastControllerDelegate {}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface RPBroadcastControllerDelegate {
		[Export ("broadcastController:didFinishWithError:")]
		void DidFinish (RPBroadcastController broadcastController, [NullAllowed] NSError error);

		[Export ("broadcastController:didUpdateServiceInfo:")]
		void DidUpdateServiceInfo (RPBroadcastController broadcastController, NSDictionary<NSString, INSCoding> serviceInfo);

		[Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("broadcastController:didUpdateBroadcastURL:")]
		void DidUpdateBroadcastUrl (RPBroadcastController broadcastController, NSUrl broadcastUrl);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Deprecated (PlatformName.TvOS, 11, 0)]
	[Deprecated (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (NSObject))]
	interface RPBroadcastConfiguration : NSCoding, NSSecureCoding {
		[Export ("clipDuration")]
		double ClipDuration { get; set; }

		[NullAllowed, Export ("videoCompressionProperties", ArgumentSemantic.Strong)]
		NSDictionary<NSString, INSSecureCoding> WeakVideoCompressionProperties { get; set; }
	}

	delegate void LoadBroadcastingHandler (string bundleID, string displayName, UIImage appIcon);

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Category]
	[BaseType (typeof (NSExtensionContext))]
	interface NSExtensionContext_RPBroadcastExtension {
		[Export ("loadBroadcastingApplicationInfoWithCompletion:")]
		void LoadBroadcastingApplicationInfo (LoadBroadcastingHandler handler);

		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'CompleteRequest(NSUrl,NSDictionary<NSString,INSCoding>)' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'CompleteRequest(NSUrl,NSDictionary<NSString,INSCoding>)' instead.")]
		[Export ("completeRequestWithBroadcastURL:broadcastConfiguration:setupInfo:")]
		void CompleteRequest (NSUrl broadcastURL, RPBroadcastConfiguration broadcastConfiguration, [NullAllowed] NSDictionary<NSString, INSCoding> setupInfo);

		[Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.iOS, 11, 0)]
		[Export ("completeRequestWithBroadcastURL:setupInfo:")]
		void CompleteRequest (NSUrl broadcastURL, [NullAllowed] NSDictionary<NSString, INSCoding> setupInfo);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	interface RPBroadcastHandler : NSExtensionRequestHandling {
		[Export ("updateServiceInfo:")]
		void UpdateServiceInfo (NSDictionary<NSString, INSCoding> serviceInfo);

		// NSInvalidArgumentException -[RPBroadcastHandler updateBroadcastURL:]: unrecognized selector sent to instance 0x608001a4b160
		//	https://trello.com/c/eA440suj/91-33875315-rpbroadcasthandler-updatebroadcasturl-unrecognized-selector
		//[TV (11,0)][iOS (11,0)]
		//[Export ("updateBroadcastURL:")]
		//void UpdateBroadcastUrl (NSUrl broadcastUrl);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'RPBroadcastSampleHandler' instead.")]
	[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'RPBroadcastSampleHandler' instead.")]
	[BaseType (typeof (RPBroadcastHandler))]
	interface RPBroadcastMP4ClipHandler {
		[Export ("processMP4ClipWithURL:setupInfo:finished:")]
		void ProcessMP4Clip ([NullAllowed] NSUrl mp4ClipURL, [NullAllowed] NSDictionary<NSString, NSObject> setupInfo, bool finished);

		[Export ("finishedProcessingMP4ClipWithUpdatedBroadcastConfiguration:error:")]
		void FinishedProcessingMP4Clip ([NullAllowed] RPBroadcastConfiguration broadcastConfiguration, [NullAllowed] NSError error);
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[BaseType (typeof (RPBroadcastHandler))]
	interface RPBroadcastSampleHandler {
		[Export ("broadcastStartedWithSetupInfo:")]
		void BroadcastStarted ([NullAllowed] NSDictionary<NSString, NSObject> setupInfo);

		[Export ("broadcastPaused")]
		void BroadcastPaused ();

		[Export ("broadcastResumed")]
		void BroadcastResumed ();

		[Export ("broadcastFinished")]
		void BroadcastFinished ();

		[Export ("processSampleBuffer:withType:")]
		void ProcessSampleBuffer (CMSampleBuffer sampleBuffer, RPSampleBufferType sampleBufferType);

		[Introduced (PlatformName.iOS, 10, 2)][Introduced (PlatformName.TvOS, 10, 1)]
		[Export ("finishBroadcastWithError:")]
		void FinishBroadcast (NSError error);
	}
}

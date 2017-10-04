// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
// Copyright 2011, 2012, 2014 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
using System;
using System.ComponentModel;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
using System.Runtime.InteropServices;

namespace XamCore.AVFoundation {

	[Native]
	// NSInteger - AVAudioSettings.h
	public enum AVAudioQuality : long {
		Min = 0,
		Low = 0x20,
		Medium = 0x40,
		High = 0x60,
		Max = 0x7F
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVAssetExportSession.h
	public enum AVAssetExportSessionStatus : long {
		Unknown,
		Waiting,
		Exporting,
		Completed,
		Failed,
		Cancelled
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVAssetReader.h
	public enum AVAssetReaderStatus : long {
		Unknown = 0,
		Reading,
		Completed,
		Failed,
		Cancelled,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 1)]
	[Native]
	// NSInteger - AVAssetWriter.h
	public enum AVAssetWriterStatus : long {
		Unknown = 0,
		Writing,
		Completed,
		Failed,
		Cancelled,
	}

	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureSession.h
	public enum AVCaptureVideoOrientation : long {
		Portrait = 1,
		PortraitUpsideDown,
		LandscapeRight,
		LandscapeLeft,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureFlashMode : long {
		Off, On, Auto
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureTorchMode : long {
		Off, On, Auto
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureFocusMode : long {
		Locked, AutoFocus, ContinuousAutoFocus,

#if !XAMCORE_2_0
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Obsolete ("use Locked instead")]
		ModeLocked = Locked,
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Obsolete ("use AutoFocus instead")]
		ModeAutoFocus = AutoFocus,
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Obsolete ("use ContinuousAutoFocus instead")]
		ModeContinuousAutoFocus = ContinuousAutoFocus
#endif
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureDevicePosition : long {
		Unspecified = 0,
		Back = 1,
		Front = 2
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureExposureMode : long {
		Locked, AutoExpose, ContinuousAutoExposure, [Introduced (PlatformName.iOS, 8, 0)] Custom
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureWhiteBalanceMode : long {
		Locked, AutoWhiteBalance, ContinuousAutoWhiteBalance
	}

#if !MONOMAC || !XAMCORE_4_0
	[Flags]
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	[Deprecated (PlatformName.iOS, 6, 0)]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionInterruptionFlags : nuint_compat_int {
		ShouldResume = 1
	}
#endif

	// Populated in NSError.Code, an NSInteger
	// anonymous enum - AVError.h
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum AVError : long {
		Unknown = -11800,
		OutOfMemory = -11801,
		SessionNotRunning = -11803,
		DeviceAlreadyUsedByAnotherSession = -11804,
		NoDataCaptured = -11805,
		SessionConfigurationChanged = -11806,
		DiskFull = -11807,
		DeviceWasDisconnected = -11808,
		MediaChanged = -11809,
		MaximumDurationReached = -11810,
		MaximumFileSizeReached = -11811,
		MediaDiscontinuity = -11812,
		MaximumNumberOfSamplesForFileFormatReached = -11813,
		DeviceNotConnected = -11814,
		DeviceInUseByAnotherApplication = -11815,
		DeviceLockedForConfigurationByAnotherProcess = -11817,
		SessionWasInterrupted = -11818,
		MediaServicesWereReset = -11819,
		ExportFailed = -11820,
		DecodeFailed = -11821,
		InvalidSourceMedia = -11822,
		FileAlreadyExists = -11823,
		CompositionTrackSegmentsNotContiguous = -11824,
		InvalidCompositionTrackSegmentDuration = -11825,
		InvalidCompositionTrackSegmentSourceStartTime = -11826,
		InvalidCompositionTrackSegmentSourceDuration = -11827,
		FormatNotRecognized = -11828,
		FailedToParse = -11829, // Should have been FileFailedToParse
		MaximumStillImageCaptureRequestsExceeded = -11830,
		ContentIsProtected = -11831,
		NoImageAtTime = -11832,
		DecoderNotFound = -11833,
		EncoderNotFound = -11834,
		ContentIsNotAuthorized = -11835,
		ApplicationIsNotAuthorized = -11836,
		DeviceIsNotAvailableInBackground = -11837,
		OperationNotSupportedForAsset = -11838,
		DecoderTemporarilyUnavailable = -11839,
		EncoderTemporarilyUnavailable = -11840,
		InvalidVideoComposition = -11841,
		//[iOS (5,1)]
		ReferenceForbiddenByReferencePolicy = -11842,
		InvalidOutputURLPathExtension = -11843,
		ScreenCaptureFailed = -11844,
		DisplayWasDisabled = -11845,
		TorchLevelUnavailable = -11846,
		OperationInterrupted = -11847,
		IncompatibleAsset = -11848,
		FailedToLoadMediaData = -11849,
		ServerIncorrectlyConfigured = -11850,
		ApplicationIsNotAuthorizedToUseDevice = -11852,
			
		FailedToParse2 = -11853,
		FileTypeDoesNotSupportSampleReferences = -11854,
		UndecodableMediaData = -11855,

		AirPlayControllerRequiresInternet = -11856,
		AirPlayReceiverRequiresInternet = -11857,

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		VideoCompositorFailed = -11858,

#if !MONOMAC
		[Introduced (PlatformName.iOS, 9, 0)]
		RecordingAlreadyInProgress = -11859,
#endif
		[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12)]
		UnsupportedOutputSettings = -11861,
		[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12)]
		OperationNotAllowed = -11862,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVPlayer.h
	public enum AVPlayerActionAtItemEnd : long {
		Advance,
		Pause,
		None
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVPlayerItem.h
	public enum AVPlayerItemStatus : long {
		Unknown, ReadyToPlay, Failed
	}

#if !MONOMAC || !XAMCORE_4_0
	[Unavailable (PlatformName.TvOS)]
	[Flags]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	[Deprecated (PlatformName.iOS, 6, 0)]
	// declared as AVAudioSessionSetActiveOptions (NSUInteger) - AVAudioSession.h
	public enum AVAudioSessionFlags : nuint_compat_int {
		NotifyOthersOnDeactivation = 1
	}
#endif

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVAsynchronousKeyValueLoading.h
	public enum AVKeyValueStatus : long {
		Unknown, Loading, Loaded, Failed, Cancelled
	}

	[Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 4, 0)]
	[Native]
	// NSInteger - AVPlayer.h
	public enum AVPlayerStatus : long {
		Unknown,
		ReadyToPlay,
		Failed
	}

	[Unavailable (PlatformName.WatchOS)]
	[Native]
	// NSUInteger - AVAsset.h
	public enum AVAssetReferenceRestrictions : nuint_compat_int {
		ForbidNone = 0,
		ForbidRemoteReferenceToLocal = (1 << 0),
		ForbidLocalReferenceToRemote = (1 << 1),
		ForbidCrossSiteReference     = (1 << 2),
		ForbidLocalReferenceToLocal  = (1 << 3),
		ForbidAll = 0xFFFF,
	}

	[Unavailable (PlatformName.WatchOS)]
	[Native]
	// NSInteger - AVAssetImageGenerator.h
	public enum AVAssetImageGeneratorResult : long {
		Succeeded, Failed, Cancelled
	}

#if !XAMCORE_3_0 || MONOMAC
	[Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.MacOSX, 10, 7)] // N/A in iOS
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureDeviceTransportControlsPlaybackMode : long {
		NotPlaying, Playing
	}

	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.MacOSX, 10, 7)] // N/A in iOS
	[Native]
	// NSInteger - AVCaptureSession.h
	public enum AVVideoFieldMode : long {
		Both, TopOnly, BottomOnly, Deinterlace
	}
#endif

#if !MONOMAC || !XAMCORE_4_0
	[Flags]
	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionInterruptionOptions : nuint_compat_int {
		ShouldResume = 1
	}

	[Flags]
	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionSetActiveOptions : nuint_compat_int {
		NotifyOthersOnDeactivation = 1
	}

	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionPortOverride : nuint_compat_int {
		None = 0,
		[Unavailable (PlatformName.TvOS)]
		Speaker = 0x73706b72 // 'spkr'
	}

	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionRouteChangeReason : nuint_compat_int {
		Unknown,
		NewDeviceAvailable,
		OldDeviceUnavailable,
		CategoryChange,
		Override,
		WakeFromSleep = 6,
		NoSuitableRouteForCategory = 7,
		RouteConfigurationChange = 8
	}

	[Flags]
	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionCategoryOptions : nuint_compat_int {
		MixWithOthers = 1,
		DuckOthers = 2,
		[Unavailable (PlatformName.TvOS)]
		AllowBluetooth = 4,
		[Unavailable (PlatformName.TvOS)]
		DefaultToSpeaker = 8,

		[Introduced (PlatformName.iOS, 9, 0)]
		InterruptSpokenAudioAndMixWithOthers = 17,
		[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0)]
		AllowBluetoothA2DP = 32,
		[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0)]
		AllowAirPlay = 64,
	}

	[Native]
	// NSUInteger - AVAudioSession.h
	public enum AVAudioSessionInterruptionType : nuint_compat_int  {
		Ended, Began
	}

	[Native]
	// NSInteger - AVAudioSession.h
	public enum AVAudioSessionErrorCode : long {
		None = 0,
		MediaServicesFailed = 0x6D737276,
		IsBusy = 0x21616374,
		IncompatibleCategory = 0x21636174,
		CannotInterruptOthers = 0x21696e74,
		MissingEntitlement = 0x656e743f,
		SiriIsRecording = 0x73697269,
		CannotStartPlaying = 0x21706c61,
		[Introduced (PlatformName.iOS, 7, 0)]
		CannotStartRecording = 0x21726563,
		BadParam = -50,
		Unspecified = 0x77686174,
		InsufficientPriority = 0x21707269,
		[Introduced (PlatformName.iOS, 9, 0)]
		CodeResourceNotAvailable = 0x21726573
	}
#endif

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVCaptureAutoFocusRangeRestriction : long {
		None = 0,
		Near = 1,
		Far = 2
	}

	// Convenience enum for native strings (defined in AVAudioSettings.h)
	public enum AVAudioBitRateStrategy : int {
		Constant,
		LongTermAverage,
		VariableConstrained,
		Variable
	}

	// Convenience enum for native strings (defined in AVAudioSettings.h)
	public enum AVSampleRateConverterAlgorithm : int {
		Normal,
		Mastering
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Native]
	// NSInteger - AVCaptureDevice.h
	public enum AVAuthorizationStatus : long {
		NotDetermined, Restricted, Denied, Authorized
	}

#if !MONOMAC || !XAMCORE_4_0
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native]
	// NSInteger - AVSpeechSynthesis.h
	public enum AVSpeechBoundary : long {
		Immediate,
		Word
	}
#endif

	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum AVAudioCommonFormat : ulong {
		Other = 0,
		PCMFloat32 = 1,
		PCMFloat64 = 2,
		PCMInt16 = 3,
		PCMInt32 = 4
	}

	[Native]
	public enum AVAudio3DMixingRenderingAlgorithm : long {
		EqualPowerPanning = 0,
		SphericalHead = 1,
		HRTF = 2,
		SoundField = 3,
		StereoPassThrough = 5
	}

#if !MONOMAC || !XAMCORE_4_0
	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum AVAudioSessionRecordPermission : ulong {
		Undetermined = 1970168948 /*'undt'*/,
		Denied = 1684369017 /*'deny'*/,
		Granted = 1735552628 /*'grnt'*/
	}

	[Native]
	public enum AVAudioSessionSilenceSecondaryAudioHintType : ulong {
		Begin = 1,
		End = 0
	}
#endif

	[Flags]
	[Native]
	public enum AVAudioPlayerNodeBufferOptions : ulong {
		Loops            = 0x01,
		Interrupts       = 0x02,
		InterruptsAtLoop = 0x04
	}

	[Native]
	public enum AVAudioUnitEQFilterType : long {
		Parametric = 0,
		LowPass = 1,
		HighPass = 2,
		ResonantLowPass = 3,
		ResonantHighPass = 4,
		BandPass = 5,
		BandStop = 6,
		LowShelf = 7,
		HighShelf = 8,
		ResonantLowShelf = 9,
		ResonantHighShelf = 10
	}
	
	[Native]
	public enum AVAudioUnitReverbPreset : long {
		SmallRoom = 0,
		MediumRoom = 1,
		LargeRoom = 2,
		MediumHall = 3,
		LargeHall = 4,
		Plate = 5,
		MediumChamber = 6,
		LargeChamber = 7,
		Cathedral = 8,
		LargeRoom2 = 9,
		MediumHall2 = 10,
		MediumHall3 = 11,
		LargeHall2 = 12
	}

	[Native]
	public enum AVAudioUnitDistortionPreset : long {
		DrumsBitBrush = 0,
		DrumsBufferBeats = 1,
		DrumsLoFi = 2,
		MultiBrokenSpeaker = 3,
		MultiCellphoneConcert = 4,
		MultiDecimated1 = 5,
		MultiDecimated2 = 6,
		MultiDecimated3 = 7,
		MultiDecimated4 = 8,
		MultiDistortedFunk = 9,
		MultiDistortedCubed = 10,
		MultiDistortedSquared = 11,
		MultiEcho1 = 12,
		MultiEcho2 = 13,
		MultiEchoTight1 = 14,
		MultiEchoTight2 = 15,
		MultiEverythingIsBroken = 16,
		SpeechAlienChatter = 17,
		SpeechCosmicInterference = 18,
		SpeechGoldenPi = 19,
		SpeechRadioTower = 20,
		SpeechWaves = 21
	}

	[Native]
	public enum AVAudioEnvironmentDistanceAttenuationModel : long {
		Exponential = 1,
		Inverse = 2,
		Linear = 3
	}

	[Introduced (PlatformName.TvOS, 10, 2), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum AVQueuedSampleBufferRenderingStatus : long {
		Unknown, Rendering, Failed
	}

	[Unavailable (PlatformName.WatchOS)]
	[Unavailable (PlatformName.TvOS)]
	[Native]
	public enum AVCaptureVideoStabilizationMode : long {
		Off, Standard, Cinematic, Auto = -1
	}

#if XAMCORE_4_0
	[Unavailable (PlatformName.MacOSX)]
#endif
	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum AVCaptureAutoFocusSystem : long {
		None,
		ContrastDetection,
		PhaseDetection
	}

	// Convience enum
	[Flags]
	[Introduced (PlatformName.iOS, 6, 0)]
	public enum AVMetadataObjectType : ulong {
		None = 0,

		[Introduced (PlatformName.iOS, 6, 0)]
		Face = 1 << 0,

		[Introduced (PlatformName.iOS, 7, 0)]
		AztecCode = 1 << 1,

		[Introduced (PlatformName.iOS, 7, 0)]
		Code128Code = 1 << 2,

		[Introduced (PlatformName.iOS, 7, 0)]
		Code39Code = 1 << 3,

		[Introduced (PlatformName.iOS, 7, 0)]
		Code39Mod43Code = 1 << 4,

		[Introduced (PlatformName.iOS, 7, 0)]
		Code93Code = 1 << 5,

		[Introduced (PlatformName.iOS, 7, 0)]
		EAN13Code = 1 << 6,

		[Introduced (PlatformName.iOS, 7, 0)]
		EAN8Code = 1 << 7,

		[Introduced (PlatformName.iOS, 7, 0)]
		PDF417Code = 1 << 8,

		[Introduced (PlatformName.iOS, 7, 0)]
		QRCode = 1 << 9,

		[Introduced (PlatformName.iOS, 7, 0)]
		UPCECode = 1 << 10,

		[Introduced (PlatformName.iOS, 8, 0)]
		Interleaved2of5Code = 1 << 11,

		[Introduced (PlatformName.iOS, 8, 0)]
		ITF14Code = 1 << 12,

		[Introduced (PlatformName.iOS, 8, 0)]
		DataMatrixCode = 1 << 13,
	}

#if !MONOMAC
	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum AVCaptureSessionInterruptionReason : long {
		VideoDeviceNotAvailableInBackground = 1,
		AudioDeviceInUseByAnotherClient = 2,
		VideoDeviceInUseByAnotherClient = 3,
		VideoDeviceNotAvailableWithMultipleForegroundApps = 4
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum AVSpeechSynthesisVoiceQuality : long {
		Default = 1,
		Enhanced
	}
#endif

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum AVAudioConverterPrimeMethod : long {
		Pre = 0,
		Normal = 1,
		None = 2
	}

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum AVAudioConverterInputStatus : long {
		HaveData = 0,
		NoDataNow = 1,
		EndOfStream = 2
	}

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum AVAudioConverterOutputStatus : long {
		HaveData = 0,
		InputRanDry = 1,
		EndOfStream = 2,
		Error = 3
	}

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum AVMusicSequenceLoadOptions : ulong {
		PreserveTracks = 0,
		ChannelsToTracks = (1 << 0)
	}
			
#if MONOMAC
	[Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum AVMovieWritingOptions : ulong
	{
		AddMovieHeaderToDestination = 0,
		TruncateDestinationToMovieHeaderOnly = (1 << 0)
	}

	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	public enum AVContentAuthorizationStatus : long {
		Unknown,
		Completed,
		Cancelled,
		TimedOut,
		Busy,
		NotAvailable,
		NotPossible,
	}

	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	public enum AVSampleBufferRequestDirection : long {
		Forward = 1,
		None = 0,
		Reverse = -1,
	}

	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Native]
	public enum AVSampleBufferRequestMode : long {
		Immediate,
		Scheduled,
	}
#endif

	[Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum AVCaptureColorSpace : long
	{
		Srgb = 0,
		P3D65 = 1
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum AVMusicTrackLoopCount : long
	{
		Forever = -1
	}

	[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum AVPlayerTimeControlStatus : long
	{
		Paused,
		WaitingToPlayAtSpecifiedRate,
		Playing
	}

	[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 10, 0), Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum AVAudioSessionIOType : long
	{
		NotSpecified = 0,
		Aggregated = 1,
	}

	[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum AVPlayerLooperStatus : long {
		Unknown,
		Ready,
		Failed,
		Cancelled
	}
	
	[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum AVContentProposalAction : long {
		Accept,
		Reject,
		Defer
	}

	[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum AVPlayerViewControllerSkippingBehavior : long {
		Default = 0,
		SkipItem
	}

	[Introduced (PlatformName.TvOS, 10, 2), Introduced (PlatformName.MacOSX, 10, 12, 4), Introduced (PlatformName.iOS, 10, 3), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum AVContentKeyRequestStatus : long {
		Requesting,
		Received,
		Renewed,
		Retried,
		Cancelled,
		Failed
	}

	[Introduced (PlatformName.TvOS, 10, 2), Introduced (PlatformName.MacOSX, 10, 12, 4), Introduced (PlatformName.iOS, 10, 3), Unavailable (PlatformName.WatchOS)]
	public enum AVContentKeyRequestRetryReason {
		[Field ("AVContentKeyRequestRetryReasonTimedOut")]
		TimedOut,
		[Field ("AVContentKeyRequestRetryReasonReceivedResponseWithExpiredLease")]
		ReceivedResponseWithExpiredLease,
		[Field ("AVContentKeyRequestRetryReasonReceivedObsoleteContentKey")]
		ReceivedObsoleteContentKey,
	}

	[Introduced (PlatformName.TvOS, 10, 2), Introduced (PlatformName.MacOSX, 10, 12, 4), Introduced (PlatformName.iOS, 10, 3), Unavailable (PlatformName.WatchOS)]
	public enum AVContentKeySystem {
		[Field ("AVContentKeySystemFairPlayStreaming")]
		FairPlayStreaming = 0,

		[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Field ("AVContentKeySystemClearKey")]
		AVContentKeySystemClearKey = 1,
	}

	// Convience enum for native string values 
	[Unavailable (PlatformName.WatchOS)]
	public enum AVAssetExportSessionPreset {
		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("AVAssetExportPresetLowQuality")]
		LowQuality = 0, // AVAssetExportPresetLowQuality
		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("AVAssetExportPresetMediumQuality")]
		MediumQuality = 1, // AVAssetExportPresetMediumQuality
		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("AVAssetExportPresetHighestQuality")]
		HighestQuality = 2, // AVAssetExportPresetHighestQuality
		[Field ("AVAssetExportPreset640x480")]
		Preset640x480 = 3, // AVAssetExportPreset640x480
		[Field ("AVAssetExportPreset960x540")]
		Preset960x540 = 4, // AVAssetExportPreset960x540
		[Field ("AVAssetExportPreset1280x720")]
		Preset1280x720 = 5, // AVAssetExportPreset1280x720
		[Field ("AVAssetExportPreset1920x1080")]
		Preset1920x1080 = 6, // AVAssetExportPreset1920x1080

		[Introduced (PlatformName.iOS, 9, 0)]
		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Field ("AVAssetExportPreset3840x2160")]
		Preset3840x2160 = 7, // AVAssetExportPreset3840x2160

		[Field ("AVAssetExportPresetAppleM4A")]
		AppleM4A = 8, // AVAssetExportPresetAppleM4A
		[Field ("AVAssetExportPresetPassthrough")]
		Passthrough = 9, // AVAssetExportPresetPassthrough

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
		[Field ("AVOutputSettingsPresetHEVC1920x1080")]
		PresetHevc1920x1080 = 11, 

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
		[Field ("AVOutputSettingsPresetHEVC3840x2160")]
		PresetHevc3840x2160 = 12,
	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVDepthDataAccuracy : long {
		Relative = 0,
		Absolute = 1,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVAudioEngineManualRenderingMode : long {
		Offline = 0,
		Realtime = 1
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVAudioEngineManualRenderingStatus : long {
		Error = -1,
		Success = 0,
		InsufficientDataFromInputNode = 1,
		CannotDoInCurrentContext = 2
	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVAudioSessionRouteSharingPolicy : ulong {
		Default = 0,
		LongForm = 1,
		Independent = 2
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVAudioPlayerNodeCompletionCallbackType : long {
		Consumed = 0,
		Rendered = 1,
		PlayedBack = 2
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	public enum AVAudioEngineManualRenderingError
	{
		InvalidMode = -80800,
		Initialized = -80801,
		NotRunning = -80802,
	}

	[Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 11, 0)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum AVCaptureLensStabilizationStatus : long
	{
		Unsupported = 0,
		Off = 1,
		Active = 2,
		OutOfRange = 3,
		Unavailable = 4
	}

	[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVCaptureOutputDataDroppedReason : long
	{
		None = 0,
		LateData = 1,
		OutOfBuffers = 2,
		Discontinuity = 3,
	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	public enum AVVideoApertureMode {
		[Field ("AVVideoApertureModeCleanAperture")]
		CleanAperture = 0,

		[Field ("AVVideoApertureModeProductionAperture")]
		ProductionAperture = 1,

		[Field ("AVVideoApertureModeEncodedPixels")]
		EncodedPixels = 2,
	}

	/*
	// Enum values are present in header but missing rdar filed at: https://bugreport.apple.com/web/?problemID=34184435
	[NoWatch, NoTV, NoMac, iOS (11, 0)]
	public enum AVAssetDownloadedAssetEvictionPriority {
		[Field ("AVAssetDownloadedAssetEvictionPriorityDefault")]
		Default = 0,

		[Field ("AVAssetDownloadedAssetEvictionPriorityImportant")]
		Important = 1,
	}
	*/

	[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
	public enum AVAssetWriterInputMediaDataLocation {
		[Field ("AVAssetWriterInputMediaDataLocationInterleavedWithMainMediaData")]
		InterleavedWithMainMediaData = 0,

		[Field ("AVAssetWriterInputMediaDataLocationBeforeMainMediaDataNotInterleaved")]
		BeforeMainMediaDataNotInterleaved = 1,
	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	public enum AVVideoCodecType {
		[Field ("AVVideoCodecTypeH264")]
		H264 = 0,
		
		[Field ("AVVideoCodecTypeJPEG")]
		Jpeg = 1,

		[Field ("AVVideoCodecTypeAppleProRes422")]
		AppleProRes422 = 3,

		[Field ("AVVideoCodecTypeAppleProRes4444")]
		AppleProRes4444 = 4,

		[Field ("AVVideoCodecTypeHEVC")]
		Hevc = 5,

	}

	[Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum AVDepthDataQuality : long {
		Low = 0,
		High = 1
	}
}

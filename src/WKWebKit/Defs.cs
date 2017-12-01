//
// WKWebKit/Defs.cs
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//
// Copyright 2014, 2016 Xamarin Inc. All rights reserved.
//

using System;

using XamCore.ObjCRuntime;

namespace XamCore.WebKit
{
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum WKNavigationType : nint {
		LinkActivated,
		FormSubmitted,
		BackForward,
		Reload,
		FormResubmitted,
		Other = -1
	}

	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum WKNavigationActionPolicy : nint {
		Cancel,
		Allow
	}

	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum WKNavigationResponsePolicy : nint {
		Cancel,
		Allow
	}

	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum WKUserScriptInjectionTime : nint {
		AtDocumentStart,
		AtDocumentEnd
	}

	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	[ErrorDomain ("WKErrorDomain")]
	public enum WKErrorCode : nint {
		None,
		Unknown,
		WebContentProcessTerminated,
		WebViewInvalidated,
		JavaScriptExceptionOccurred,
		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		JavaScriptResultTypeIsUnsupported,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		ContentRuleListStoreCompileFailed,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		ContentRuleListStoreLookUpFailed,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		ContentRuleListStoreRemoveFailed,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		ContentRuleListStoreVersionMismatch
	}

#if !MONOMAC || !XAMCORE_4_0
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum WKSelectionGranularity : nint {
		Dynamic, Character
	}
#endif

	[Introduced (PlatformName.iOS, 10, 0)][Unavailable (PlatformName.MacOSX)]
	[Native]
	[Flags]
	public enum WKDataDetectorTypes : nuint {
		None = 0,
		PhoneNumber = 1 << 0,
		Link = 1 << 1,
		Address = 1 << 2,
		CalendarEvent = 1 << 3,
		TrackingNumber = 1 << 4,
		FlightNumber = 1 << 5,
		LookupSuggestion = 1 << 6,
		SpotlightSuggestion = LookupSuggestion,
#if XAMCORE_2_0
		All = UInt64.MaxValue
#else
		All = UInt32.MaxValue
#endif
	}

	[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Native]
	[Flags]
	public enum WKAudiovisualMediaTypes : nuint	{
		None = 0,
		Audio = 1 << 0,
		Video = 1 << 1,
#if XAMCORE_2_0
		All = UInt64.MaxValue
#else
		All = UInt32.MaxValue
#endif
	}
}

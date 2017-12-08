//
// MessageUI.cs: This file describes the API that the generator will produce for MessageUI
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2014 Xamarin, Inc.
//

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.MessageUI {

#if XAMCORE_4_0
	[Native]
	public enum MFMailComposeResult : nint {
#else
	// Before iOS 10 beta 3, this was an untyped enum -> MFMailComposeViewController.h
	// Note: now used as a NSInteger in the API.
	public enum MFMailComposeResult {
#endif
		Cancelled,
		Saved,
		Sent,
		Failed
	}

	[ErrorDomain ("MFMailComposeErrorDomain")]
#if XAMCORE_4_0
	[Native]
	public enum MFMailComposeErrorCode : nint {
#else
	// Before iOS 10 beta 3, this was an untyped enum -> MFMailComposeViewController.h
	// Note: now used as a NSInteger in the API.
	public enum MFMailComposeErrorCode {
#endif
	    SaveFailed,
	    SendFailed
	}

#if XAMCORE_4_0
	[Native]
	public enum MessageComposeResult : nint {
#else
	// Before iOS 10 beta 3, this was an untyped enum -> MFMessageComposeViewController.h
	// Note: now used as a NSInteger in the API.
	public enum MessageComposeResult {
#endif
		Cancelled, Sent, Failed
	}
}
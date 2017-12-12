//
// SLComposeViewController.cs: Extensions to the SLComposeViewController class
//
// Authors:
//    Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2012 Xamarin Inc
//
#if !MONOMAC
using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.Accounts;
using XamCore.UIKit;

namespace XamCore.Social {

	public partial class SLComposeViewController {
		public static SLComposeViewController FromService (SLServiceKind serviceKind)
		{
			return FromService (SLRequest.KindToType (serviceKind));
		}

		public static bool IsAvailable (SLServiceKind serviceKind)
		{
			return IsAvailable (SLRequest.KindToType (serviceKind));
		}
	}
}
#endif

//
// EventKitUIBundle C# bindings
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0
using System;
using System.Runtime.InteropServices;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.EventKitUI {
	public static class EKUIBundle {

		[Introduced (PlatformName.iOS, 11, 0)]
		[DllImport (Constants.EventKitUILibrary)]
		static extern IntPtr EventKitUIBundle ();

		[Introduced (PlatformName.iOS, 11, 0)]
		public static NSBundle UIBundle { get; } = Runtime.GetNSObject<NSBundle> (EventKitUIBundle ());
	}
}
#endif

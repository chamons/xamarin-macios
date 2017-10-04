//
// SCNJavaScript.cs: JSC bridge
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//
// Copyright 2014 Xamarin Inc. All rights reserved.
//

#if (XAMCORE_2_0 || !MONOMAC) && !WATCH

using System;
using System.Runtime.InteropServices;

using XamCore.ObjCRuntime;
using XamCore.JavaScriptCore;

namespace XamCore.SceneKit
{
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	public static class SCNJavaScript
	{
		[DllImport (Constants.SceneKitLibrary)]
		static extern void SCNExportJavaScriptModule (IntPtr context);

		public static void ExportModule (JSContext context)
		{
			if (context == null)
				throw new ArgumentNullException ("context");

			SCNExportJavaScriptModule (context.Handle);
		}
	}
}

#endif
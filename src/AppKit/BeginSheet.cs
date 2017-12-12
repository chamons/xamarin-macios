//
// BeginSheet.cs: Helper methods that support NSAction overloads instead of
// (NSObject target, Selector selector) overloads for BeginSheet methods.
// 
// Copyright 2010, Novell, Inc.
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
using System;
using System.Collections;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.AppKit {
	public partial class NSApplication {
		public void BeginSheet (NSWindow sheet, NSWindow docWindow)
		{
			BeginSheet (sheet, docWindow, null, null, IntPtr.Zero);
		}
		
		public void BeginSheet (NSWindow sheet, NSWindow docWindow, NSAction onEnded)
		{
			var obj = new NSAsyncActionDispatcher (onEnded);
			BeginSheet (sheet, docWindow, obj, NSActionDispatcher.Selector, IntPtr.Zero);
		}
	}

	public partial class NSOpenPanel {
		public void BeginSheet (string directory, string fileName, string []fileTypes, NSWindow modalForWindow)
		{
			BeginSheet (directory, fileName, fileTypes, modalForWindow, null, null, IntPtr.Zero);
		}
		
		public void BeginSheet (string directory, string fileName, string []fileTypes, NSWindow modalForWindow, NSAction onEnded)
		{
			var obj = new NSAsyncActionDispatcher (onEnded);
			BeginSheet (directory, fileName, fileTypes, modalForWindow, obj, NSActionDispatcher.Selector, IntPtr.Zero);
		}
	}

	public partial class NSPageLayout {
		public void BeginSheet (NSPrintInfo printInfo, NSWindow docWindow)
		{
			BeginSheet (printInfo, docWindow, null, null, IntPtr.Zero);
		}
		
		public void BeginSheet (NSPrintInfo printInfo, NSWindow docWindow, NSAction onEnded)
		{
			var obj = new NSAsyncActionDispatcher (onEnded);
			BeginSheet (printInfo, docWindow, obj, NSActionDispatcher.Selector, IntPtr.Zero);
		}
	}
}

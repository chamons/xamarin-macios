using System;
using System.Runtime.InteropServices;

using XamCore.CoreGraphics;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif

namespace XamCore.AppKit {
	public partial class NSDraggingItem {
		public NSDraggingItem (NSPasteboardWriting pasteboardWriter) : this ((INSPasteboardWriting)pasteboardWriter) {
		}
	}
}
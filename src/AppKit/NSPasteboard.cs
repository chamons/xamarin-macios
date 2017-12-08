using System;
using System.Runtime.InteropServices;

using XamCore.CoreGraphics;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.AppKit {
	public partial class NSPasteboard {
#if !XAMCORE_2_0
		// This is a stable API we can't break, even if it is all kinds of wrong
		public bool WriteObjects (NSPasteboardReading [] objects)
		{
			var nsa_pasteboardReading = NSArray.FromNSObjects (objects);
			bool result = WriteObjects (nsa_pasteboardReading.Handle);
			nsa_pasteboardReading.Dispose ();
			return result;
		}
#endif

		public bool WriteObjects (INSPasteboardWriting [] objects)
		{
			var nsa_pasteboardReading = NSArray.FromNSObjects (objects);
			bool result = WriteObjects (nsa_pasteboardReading.Handle);
			nsa_pasteboardReading.Dispose ();
			return result;
		}
		
		public bool WriteObjects (NSPasteboardWriting [] objects)
		{
			var nsa_pasteboardReading = NSArray.FromNSObjects (objects);
			bool result = WriteObjects (nsa_pasteboardReading.Handle);
			nsa_pasteboardReading.Dispose ();
			return result;
		}
	}
}

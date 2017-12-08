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
	public partial class NSSharingServiceDelegate {
		CGRect SourceFrameOnScreenForShareItem (NSSharingService sharingService, NSPasteboardWriting item)
		{
			return SourceFrameOnScreenForShareItem (sharingService, (INSPasteboardWriting)item);
		}

		NSImage TransitionImageForShareItem (NSSharingService sharingService, NSPasteboardWriting item, CGRect contentRect)
		{
			return TransitionImageForShareItem (sharingService, (INSPasteboardWriting)item, contentRect);
		}
	}
}
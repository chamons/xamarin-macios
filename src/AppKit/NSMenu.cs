using System;
using System.Runtime.InteropServices;
using XamCore.CoreFoundation;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.CoreGraphics;
using XamCore.CoreAnimation;

namespace XamCore.AppKit {
	public partial class NSMenu {
		object __mt_items_var;
		
		NSMenuItem InsertItem (string title, string charCode, nint index)
		{
			return InsertItem (title, null, charCode, index);
		}
		
	}
}
		
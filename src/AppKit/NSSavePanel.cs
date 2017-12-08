using System;
using System.Collections.Generic;

using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.AppKit
{
	public partial class NSSavePanel
	{
		[Export ("savePanel")]
		public static NSSavePanel SavePanel {
			get {
				// [NSSavePanel savePanel] will always create a new instance, so there's no need to check if there already is
				// a managed object with the same pointer.
				IntPtr ptr = Messaging.IntPtr_objc_msgSend (Class.GetHandle ("NSSavePanel"), Selector.GetHandle ("savePanel"));
				return new NSSavePanel (ptr);
			}
		}
	}
}

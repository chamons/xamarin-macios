using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.FinderSync {
	[Native]
	public enum FIMenuKind : nuint
	{
		ContextualMenuForItems = 0,
		ContextualMenuForContainer = 1,
		ContextualMenuForSidebar = 2,
		ToolbarItemMenu = 3
	}
}
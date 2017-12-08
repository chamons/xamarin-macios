using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.PhotosUI {
#if !MONOMAC
	[TV (10,0)]
	[iOS (9,1)]
	[Native]
	public enum PHLivePhotoViewPlaybackStyle : nint
	{
		Undefined = 0,
		Full,
		Hint
	}

	[TV (10,0)]
	[iOS (9,1)]
	[Native]
	[Flags] // NS_OPTIONS
	public enum PHLivePhotoBadgeOptions : nuint {
		None = 0,
		OverContent = 1 << 0,
		LiveOff = 1 << 1,
	}
#endif
}

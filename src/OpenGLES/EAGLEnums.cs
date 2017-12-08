using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.OpenGLES {

	// NSUInteger -> EAGL.h
	[Native]
	public enum EAGLRenderingAPI : nuint_compat_int {
		OpenGLES1 = 1,
		OpenGLES2 = 2,
		OpenGLES3 = 3,
	}
}

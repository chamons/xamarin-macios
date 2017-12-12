using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif

namespace XamCore.CoreMedia {

	// empty interface used as a marker to state which CM objects DO support the API
	public interface ICMAttachmentBearer : INativeObject {}

}

#if !WATCH

using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.SceneKit
{
	[iOS (9,0)][Mac (10,11)]
	public partial class SCNRenderingOptions {
		public SCNRenderingApi? RenderingApi {
			get {
				var val = GetNUIntValue (_RenderingApiKey);
				if (val != null)
					return (SCNRenderingApi)(uint) val;
				return null;
			}

			set {
				if (value.HasValue)
					SetNumberValue (_RenderingApiKey, (nuint)(uint)value.Value);
				else
					RemoveValue (_RenderingApiKey);
			}
		}
	}
}

#endif

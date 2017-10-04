#if XAMCORE_2_0 && MONOMAC
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.Metal {
	public static class IMTLRenderCommandEncoder_Extensions {
		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		public unsafe static void SetViewports (this IMTLRenderCommandEncoder This, MTLViewport [] viewports)
		{
			fixed (void* handle = viewports)
				This.SetViewports ((IntPtr)handle, (nuint)(viewports?.Length ?? 0));
		}

		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		public unsafe static void SetScissorRects (this IMTLRenderCommandEncoder This, MTLScissorRect [] scissorRects)
		{
			fixed (void* handle = scissorRects)
				This.SetScissorRects ((IntPtr)handle, (nuint)(scissorRects?.Length ?? 0));
		}

#if IOS
		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.MacOSX), Unavailable (PlatformName.WatchOS)]
		public unsafe static void SetTileBuffers (this IMTLRenderCommandEncoder This, IMTLBuffer[] buffers, nuint[] offsets, NSRange range)
		{
			fixed (void* handle = offsets)
				This.SetTileBuffers (buffers, (IntPtr)handle, range);
		}

		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.MacOSX), Unavailable (PlatformName.WatchOS)]
		public unsafe static void SetTileSamplerStates (this IMTLRenderCommandEncoder This, IMTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
		{
			fixed (void* minHandle = lodMinClamps) {
				fixed (void* maxHandle = lodMaxClamps) {
					This.SetTileSamplerStates (samplers, (IntPtr)minHandle, (IntPtr)maxHandle, range);
				}
			}
		}
#endif
	}
}
#endif

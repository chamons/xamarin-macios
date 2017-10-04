//
// CVMetalTextureCache.cs: Implementation of the CVMetalTextureCache class
//
// Author:
//   Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2012-2015 Xamarin Inc
//
//

#if IOS || TVOS

using System;
using System.Runtime.InteropServices;
using XamCore.ObjCRuntime;
using XamCore.CoreFoundation;
using XamCore.Foundation;
using XamCore.Metal;

namespace XamCore.CoreVideo {

	[Introduced (PlatformName.iOS, 8, 0)]
	public partial class CVMetalTextureCache : INativeObject, IDisposable {
		internal IntPtr handle;

		public IntPtr Handle {
			get { return handle; }
		}

		~CVMetalTextureCache ()
		{
			Dispose (false);
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (handle != IntPtr.Zero){
				CFObject.CFRelease (handle);
				handle = IntPtr.Zero;
			}
		}

		[DllImport (Constants.CoreVideoLibrary)]
		extern static int /* CVReturn = int32_t */ CVMetalTextureCacheCreate (
			/* CFAllocatorRef __nullable */ IntPtr allocator, 
			/* CFDictionaryRef __nullable */ IntPtr cacheAttributes,
			/* id<MTLDevice> __nonnull */ IntPtr metalDevice, 
			/* CFDictionaryRef __nullable */ IntPtr textureAttributes, 
			/* CVMetalTextureCacheRef __nullable * __nonnull */ out IntPtr cacheOut);

		CVMetalTextureCache (IntPtr handle)
		{
			this.handle = handle;
		}
		
		public CVMetalTextureCache (IMTLDevice metalDevice)
		{
			if (metalDevice == null)
				throw new ArgumentNullException ("metalDevice");
			
			if (CVMetalTextureCacheCreate (IntPtr.Zero,
						       IntPtr.Zero, /* change one day to support cache attributes */
						       metalDevice.Handle,
						       IntPtr.Zero, /* change one day to support texture attribuets */
						       out handle) == 0)
				return;
			
			throw new Exception ("Could not create the texture cache");
		}

		public static CVMetalTextureCache FromDevice (IMTLDevice metalDevice)
		{
			if (metalDevice == null)
				throw new ArgumentNullException ("metalDevice");
			IntPtr handle;
			if (CVMetalTextureCacheCreate (IntPtr.Zero,
						       IntPtr.Zero, /* change one day to support cache attributes */
						       metalDevice.Handle,
						       IntPtr.Zero, /* change one day to support texture attribuets */
						       out handle) == 0)
				return new CVMetalTextureCache (handle);
			return null;
		}

		public CVMetalTexture TextureFromImage (CVImageBuffer imageBuffer, MTLPixelFormat format, nint width, nint height, nint planeIndex, out CVReturn errorCode)
		{
			if (imageBuffer == null)
				throw new ArgumentNullException ("imageBuffer");
			
			IntPtr texture;
			errorCode = CVMetalTextureCacheCreateTextureFromImage (
				allocator:    IntPtr.Zero,
				textureCache: handle, /* textureCache dict, one day we might add it */
				sourceImage:  imageBuffer.Handle,
				textureAttr:  IntPtr.Zero,
				format:       (nuint) (ulong) format,
				width:        width,
				height:       height,
				planeIndex:   planeIndex,
				textureOut:   out texture);
			if (errorCode != 0)
				return null;
			return new CVMetalTexture (texture);
		}

		[DllImport (Constants.CoreVideoLibrary)]
		extern static void CVMetalTextureCacheFlush (
			/* CVMetalTextureCacheRef __nonnull */ IntPtr textureCache, CVOptionFlags flags);

		public void Flush (CVOptionFlags flags)
		{
			CVMetalTextureCacheFlush (handle, flags);
		}
			
		[DllImport (Constants.CoreVideoLibrary)]
		extern static CVReturn CVMetalTextureCacheCreateTextureFromImage (
			/* CFAllocatorRef __nullable */ IntPtr allocator,
			/* CVMetalTextureCacheRef __nonnull */ IntPtr textureCache,
			/* CVImageBufferRef __nonnull */ IntPtr sourceImage,
			/* CFDictionaryRef __nullable */ IntPtr textureAttr,
			/* MTLPixelFormat */ nuint format,	// MTLPixelFormat is nuint [Native] which will always be 64bits on managed code
			/* size_t */ nint width,
			/* size_t */ nint height,
			/* size_t */ nint planeIndex,
			/* CVMetalTextureRef __nullable * __nonnull */ out IntPtr textureOut);
	}
}

#endif // IOS || TVOS

// 
// CVPixelBufferIOSurface.cs
//
// Authors: Alex Soto (alexsoto@microsoft.com)
//
// Copyright 2017 Xamarin Inc.
//

#if XAMCORE_2_0 && !WATCH
using System;
using System.Runtime.InteropServices;
using XamCore.CoreFoundation;
using XamCore.Foundation;
using XamCore.ObjCRuntime;

namespace XamCore.CoreVideo {
	public partial class CVPixelBuffer : CVImageBuffer {

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		[DllImport (Constants.CoreVideoLibrary)]
		extern static IntPtr /* IOSurfaceRef */ CVPixelBufferGetIOSurface (
			/* CVPixelBufferRef CV_NULLABLE */ IntPtr pixelBuffer
		);

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		public XamCore.IOSurface.IOSurface GetIOSurface ()
		{
			if (Handle == IntPtr.Zero)
				throw new ObjectDisposedException ("CVPixelBuffer");

			var ret = CVPixelBufferGetIOSurface (Handle);
			if (ret == IntPtr.Zero)
				return null;

			return Runtime.GetINativeObject <XamCore.IOSurface.IOSurface> (ret, false);
		}

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		[DllImport (Constants.CoreVideoLibrary)]
		extern static CVReturn /* IOSurfaceRef */ CVPixelBufferCreateWithIOSurface (
			/* CFAllocatorRef CV_NULLABLE */ IntPtr allocator,
			/* IOSurfaceRef CV_NONNULL */ IntPtr surface,
			/* CFDictionaryRef CV_NULLABLE */ IntPtr pixelBufferAttributes,
			/* CVPixelBufferRef CV_NULLABLE * CV_NONNULL */ out IntPtr pixelBufferOut
		);

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		public static CVPixelBuffer Create (XamCore.IOSurface.IOSurface surface, out CVReturn result, CVPixelBufferAttributes pixelBufferAttributes = null)
		{
			if (surface == null)
				throw new ArgumentNullException (nameof (surface));

			IntPtr pixelBufferPtr;
			result = CVPixelBufferCreateWithIOSurface (
				allocator: IntPtr.Zero,
				surface: surface.Handle,
				pixelBufferAttributes: pixelBufferAttributes?.Dictionary.Handle ?? IntPtr.Zero,
				pixelBufferOut: out pixelBufferPtr
			);

			if (result != CVReturn.Success)
				return null;

			return new CVPixelBuffer (pixelBufferPtr, true);
		}

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		public static CVPixelBuffer Create (XamCore.IOSurface.IOSurface surface, CVPixelBufferAttributes pixelBufferAttributes = null)
		{
			CVReturn result;
			return Create (surface, out result, pixelBufferAttributes);
		}
	}
}
#endif

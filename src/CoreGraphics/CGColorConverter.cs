//
// CGColorConverter.cs: Implements the managed CGColorConverter
//
// Author: Vincent Dondain
//
// Copyright 2016 Xamarin Inc.
//

#if !MONOMAC && !WATCH

using System;
using System.Runtime.InteropServices;

using XamCore.ObjCRuntime;

#if !COREBUILD
using XamCore.CoreFoundation;
using XamCore.Foundation;
#endif

namespace XamCore.CoreGraphics {

	// uint32_t enum -> CGColorConverter.h
	[Introduced (PlatformName.TvOS, 9, 2)][Obsoleted (PlatformName.TvOS, 10, 0, message: "Replaced by 'CGColorConversionInfoTransformType'.")]
	[Introduced (PlatformName.iOS, 9, 3)][Obsoleted (PlatformName.iOS, 10, 0, message: "Replaced by 'CGColorConversionInfoTransformType'.")]
	[Obsolete ("Use 'CGColorConversionInfoTransformType'.")]
	public enum CGColorConverterTransformType : uint {
		FromSpace,
		ToSpace,
		ApplySpace
	}

	[Introduced (PlatformName.TvOS, 9, 2)][Obsoleted (PlatformName.TvOS, 10, 0, message: "Replaced by 'GColorConversionInfoTriple'.")]
	[Introduced (PlatformName.iOS, 9, 3)][Obsoleted (PlatformName.iOS, 10, 0, message: "Replaced by 'GColorConversionInfoTriple'.")]
	[StructLayout (LayoutKind.Sequential)]
	public struct CGColorConverterTriple {
		public CGColorSpace Space;
		public CGColorConverterTransformType Transform;
		public CGColorRenderingIntent Intent;
	}

	// CGColorConverter.h
	[Introduced (PlatformName.TvOS, 9, 2)][Obsoleted (PlatformName.TvOS, 10, 0, message: "Replaced by 'CGColorConversionInfo'.")]
	[Introduced (PlatformName.iOS, 9, 3)][Obsoleted (PlatformName.iOS, 10, 0, message: "Replaced by 'CGColorConversionInfo'.")]
	public class CGColorConverter : INativeObject, IDisposable
	{
		/* invoked by marshallers */
		internal CGColorConverter (IntPtr handle)
		{
		}

		[Preserve (Conditional=true)]
		internal CGColorConverter (IntPtr handle, bool owns)
		{
		}

		public CGColorConverter (NSDictionary options, params CGColorConverterTriple [] triples)
		{
		}

		~CGColorConverter ()
		{
		}

		public void Dispose ()
		{
			GC.SuppressFinalize (this);
		}

		public IntPtr Handle {
			get { return IntPtr.Zero; }
		}

		protected virtual void Dispose (bool disposing)
		{
		}
	}
}

#endif // !MONOMAC && !WATCH


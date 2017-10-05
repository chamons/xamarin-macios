// Copyright 2015 Xamarin Inc.

using System;
using System.Runtime.InteropServices;

using CoreFoundation;
using CoreMedia;
using ObjCRuntime;

namespace MediaToolbox {

	static public class MTFormatNames {

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
		[DllImport (Constants.MediaToolboxLibrary)]
		static extern /* CFStringRef CM_NULLABLE */ IntPtr MTCopyLocalizedNameForMediaType (
			CMMediaType mediaType);

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
		static public string GetLocalizedName (this CMMediaType mediaType)
		{
			return CFString.FetchString (MTCopyLocalizedNameForMediaType (mediaType), releaseHandle: true);
		}

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
		[DllImport (Constants.MediaToolboxLibrary)]
		static extern /* CFStringRef CM_NULLABLE */ IntPtr MTCopyLocalizedNameForMediaSubType (
			CMMediaType mediaType, uint mediaSubType);

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
		static public string GetLocalizedName (this CMMediaType mediaType, uint mediaSubType)
		{
			return CFString.FetchString (MTCopyLocalizedNameForMediaSubType (mediaType, mediaSubType), releaseHandle: true);
		}
	}
}

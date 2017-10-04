//
// Enums.cs
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013-2016, Xamarin Inc.
//

using System;
using XamCore.ObjCRuntime;

namespace XamCore.ImageIO {

	// untyped enum -> CGImageMetadata.h
	// note: not used in any API
	[Introduced (PlatformName.iOS, 7, 0), Introduced (PlatformName.MacOSX, 10, 8)]
	[ErrorDomain ("kCFErrorDomainCGImageMetadata")]
	public enum CGImageMetadataErrors {
		Unknown = 0,
		UnsupportedFormat = 1,
		BadArgument = 2,
		ConflictingArguments = 3,
		PrefixConflict = 4,
	}

	// untyped enum -> CGImageMetadata.h
	[Introduced (PlatformName.iOS, 7, 0), Introduced (PlatformName.MacOSX, 10, 8)]
	public enum CGImageMetadataType {
		Invalid = -1,
		Default = 0,
		String = 1,
		ArrayUnordered = 2,
		ArrayOrdered = 3,
		AlternateArray = 4,
		AlternateText = 5,
		Structure = 6
	}

	public enum CGImagePropertyOrientation {
		Up = 1,
		UpMirrored,
		Down,
		DownMirrored,
		LeftMirrored,
		Right,
		RightMirrored,
		Left
	}

	// untyped enum / #defines
	// used with kCGImagePropertyPNGCompressionFilter
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Flags]
	public enum CGImagePropertyPngFilters {
		No = 0,
		None = 0x08,
		Sub = 0x10,
		Up = 0x20,
		Average = 0x40,
		Paeth = 0x80
	}
}

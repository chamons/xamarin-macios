//
// Enums.cs: enums for AppKit
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//
// Copyright 2012 Xamarin Inc

using System;
using XamCore.ObjCRuntime;

namespace XamCore.AppKit {

	[Introduced (PlatformName.MacOSX, 10, 7)]
	[Native]
	public enum NSTextLayoutOrientation : long {
		Horizontal,
		Vertical
	}

#if !XAMCORE_2_0
	[Introduced (PlatformName.MacOSX, 10, 7), Flags]
	[Native]
	public enum NSTableViewAnimationOptions : nuint_compat_int {
		EffectFade = 0x1,
		EffectGap = 0x2,

		// these cannot be combined
		SlideUp = 0x10,
		SlideDown = 0x20,
		SlideLeft = 0x30,
		SlideRight = 0x40,
	}
#endif

	[Introduced (PlatformName.MacOSX, 10, 7)]
	[Native]
	public enum NSPrintRenderingQuality : long {
		Best,
		Responsive
	}

	[Introduced (PlatformName.MacOSX, 10, 7)]
	[Native]
	public enum NSCorrectionIndicatorType : long {
		Default = 0,
		Reversion,
		Guesses
	}

	[Introduced (PlatformName.MacOSX, 10, 7)]
	[Native]
	public enum NSCorrectionResponse : long {
		None,
		Accepted,
		Rejected,
		Ignored,
		Edited,
		Reverted
	}

	[Introduced (PlatformName.MacOSX, 10, 7)]
	[Native]
	public enum NSTextFinderMatchingType : long {
		Contains = 0,
		StartsWith = 1,
		FullWord = 2,
		EndsWith = 3
	}

	[Native]
	public enum NSCharacterCollection : nuint_compat_int {
		/// <summary>Identity mapping (CID == NSGlyph)</summary>
		IdentityMapping = 0,

		/// <summary>Adobe-CNS1</summary>
		AdobeCns1 = 1,

		/// <summary>Adobe-GB1</summary>
		AdobeGb1 = 2,

		/// <summary>Adobe-Japan1</summary>
		AdobeJapan1 = 3,

		/// <summary>Adobe-Japan2</summary>
		AdobeJapan2 = 4,

		/// <summary>Adobe-Korea1</summary>
		AdobeKorea1 = 5
	}

	// Untyped enum (NSAttributedString.h). Only used as a convience enum in our API.
	[Flags]
	public enum NSSpellingState :
#if XAMCORE_4_0
		long
#else
		int
#endif
	{
		None = 0x0,
		Spelling = 0x1,
		Grammar = 0x2
	}
}


//
// coregraphics.cs: Definitions for CoreGraphics
//
// Copyright 2014 Xamarin Inc. All rights reserved.
//

using System;
using Foundation;
using ObjCRuntime;

namespace CoreGraphics {

	[Partial]
	interface CGPDFPageInfo {

		[Internal][Field ("kCGPDFContextMediaBox")]
		IntPtr kCGPDFContextMediaBox { get; }

		[Internal][Field ("kCGPDFContextCropBox")]
		IntPtr kCGPDFContextCropBox { get; }

		[Internal][Field ("kCGPDFContextBleedBox")]
		IntPtr kCGPDFContextBleedBox { get; }

		[Internal][Field ("kCGPDFContextTrimBox")]
		IntPtr kCGPDFContextTrimBox { get; }

		[Internal][Field ("kCGPDFContextArtBox")]
		IntPtr kCGPDFContextArtBox { get; }
	}

	[Partial]
	interface CGPDFInfo {

		[Internal][Field ("kCGPDFContextTitle")]
		IntPtr kCGPDFContextTitle { get; }

		[Internal][Field ("kCGPDFContextAuthor")]
		IntPtr kCGPDFContextAuthor { get; }

		[Internal][Field ("kCGPDFContextSubject")]
		IntPtr kCGPDFContextSubject { get; }

		[Internal][Field ("kCGPDFContextKeywords")]
		IntPtr kCGPDFContextKeywords { get; }

		[Internal][Field ("kCGPDFContextCreator")]
		IntPtr kCGPDFContextCreator { get; }

		[Internal][Field ("kCGPDFContextOwnerPassword")]
		IntPtr kCGPDFContextOwnerPassword { get; }

		[Internal][Field ("kCGPDFContextUserPassword")]
		IntPtr kCGPDFContextUserPassword { get; }

		[Internal][Field ("kCGPDFContextEncryptionKeyLength")]
		IntPtr kCGPDFContextEncryptionKeyLength { get; }

		[Internal][Field ("kCGPDFContextAllowsPrinting")]
		IntPtr kCGPDFContextAllowsPrinting { get; }

		[Internal][Field ("kCGPDFContextAllowsCopying")]
		IntPtr kCGPDFContextAllowsCopying { get; }

#if false
		kCGPDFContextOutputIntent;
		kCGPDFXOutputIntentSubtype;
		kCGPDFXOutputConditionIdentifier;
		kCGPDFXOutputCondition;
		kCGPDFXRegistryName;
		kCGPDFXInfo;
		kCGPDFXDestinationOutputProfile;
		kCGPDFContextOutputIntents;
#endif
	}

	[Static]
	[Introduced (PlatformName.iOS, 9, 0)]
	interface CGColorSpaceNames {
		[Field ("kCGColorSpaceGenericGray")]
		NSString GenericGray { get; }

		[Field ("kCGColorSpaceGenericRGB")]
		NSString GenericRgb { get; }

		[Field ("kCGColorSpaceGenericCMYK")]
		NSString GenericCmyk { get; }

		[Introduced (PlatformName.iOS, 9, 3)][Introduced (PlatformName.MacOSX, 10, 11, 2)]
		[Introduced (PlatformName.TvOS, 9, 2)]
		[Field ("kCGColorSpaceDisplayP3")]
		NSString DisplayP3 { get; }

		[Field ("kCGColorSpaceGenericRGBLinear")]
		NSString GenericRgbLinear { get; }

		[Field ("kCGColorSpaceAdobeRGB1998")]
		NSString AdobeRgb1998 { get; }

		[Field ("kCGColorSpaceSRGB")]
		NSString Srgb { get; }

		[Field ("kCGColorSpaceGenericGrayGamma2_2")]
		NSString GenericGrayGamma2_2 { get; }

		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("kCGColorSpaceGenericXYZ")]
		NSString GenericXyz { get; }

		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("kCGColorSpaceACESCGLinear")]
		NSString AcesCGLinear { get; }

		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("kCGColorSpaceITUR_709")]
		NSString ItuR_709 { get; }

		[Introduced (PlatformName.MacOSX, 10, 11)]
		[Field ("kCGColorSpaceITUR_2020")]
		NSString ItuR_2020 { get; }

		[Introduced (PlatformName.iOS, 9, 3)][Introduced (PlatformName.MacOSX, 10, 11)]
		[Introduced (PlatformName.TvOS, 9, 2)]
		[Field ("kCGColorSpaceROMMRGB")]
		NSString RommRgb { get; }

		[Introduced (PlatformName.iOS, 9, 3)][Introduced (PlatformName.MacOSX, 10, 11)]
		[Introduced (PlatformName.TvOS, 9, 2)]
		[Field ("kCGColorSpaceDCIP3")]
		NSString Dcip3 { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceExtendedSRGB")]
		NSString ExtendedSrgb { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceLinearSRGB")]
		NSString LinearSrgb { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceExtendedLinearSRGB")]
		NSString ExtendedLinearSrgb { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceExtendedGray")]
		NSString ExtendedGray { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceLinearGray")]
		NSString LinearGray { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("kCGColorSpaceExtendedLinearGray")]
		NSString ExtendedLinearGray { get; }

#if MONOMAC
		[Obsolete ("Now accessible as GenericCmyk")]
		[Field ("kCGColorSpaceGenericCMYK")]
		NSString GenericCMYK { get; }

		[Obsolete ("Now accessible as AdobeRgb1998")]
		[Field ("kCGColorSpaceAdobeRGB1998")]
		NSString AdobeRGB1998 { get; }

		[Obsolete ("Now accessible as Srgb")]
		[Field ("kCGColorSpaceSRGB")]
		NSString SRGB { get; }

		[Obsolete ("Now accessible as GenericRgb")]
		[Field ("kCGColorSpaceGenericRGB")]
		NSString GenericRGB { get; }

		[Obsolete ("Now accessible as GenericRgb")]
		[Field ("kCGColorSpaceGenericRGBLinear")]
		NSString GenericRGBLinear { get; }
#endif
	}

	[Partial]
	partial interface CGColorConversionInfo {

		[Internal]
		[Field ("kCGColorConversionBlackPointCompensation")]
		NSString BlackPointCompensationKey { get; }
	}

	[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.TvOS, 10, 0)][Introduced (PlatformName.WatchOS, 3, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
	[StrongDictionary ("CGColorConversionInfo")]
	interface CGColorConversionOptions {
		bool BlackPointCompensation { get; set; }
	}
}

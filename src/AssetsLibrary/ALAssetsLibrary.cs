//
// Extensions to the ALAssetsLibrary class
//
// Authors:
//   Rolf Bjarne Kvinge
//
// Copyright 2011-2014, Xamarin Inc.
//

#if !XAMCORE_2_0

using System;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;
using XamCore.CoreGraphics;
using XamCore.CoreLocation;
using XamCore.UIKit;
using XamCore.MediaPlayer;

namespace XamCore.AssetsLibrary
{
	[Availability (Deprecated = Platform.iOS_9_0, Message = "Use the 'Photos' API instead.")]
	public partial class ALAssetsLibrary
	{
		[Obsolete ("Use the overload that takes a CGImage instead")]
		public unsafe virtual void WriteImageToSavedPhotosAlbum (UIImage imageData, NSDictionary metadata, ALAssetsLibraryWriteCompletionDelegate completionBlock)
		{
			WriteImageToSavedPhotosAlbum (imageData.CGImage, metadata, completionBlock);
		}
		
		[Obsolete ("Use the overload that takes a CGImage instead")]
		public unsafe virtual void WriteImageToSavedPhotosAlbum (UIImage imageData, ALAssetOrientation orientation, ALAssetsLibraryWriteCompletionDelegate completionBlock)
		{
			WriteImageToSavedPhotosAlbum (imageData.CGImage, orientation, completionBlock);
		}
	}
}

#endif
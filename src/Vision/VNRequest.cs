//
// VNRequest.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Vision {
	public partial class VNRequest {

		public virtual T [] GetResults<T> () where T : VNObservation
		{
			// From docs: If the request failed, this property will be nil;
			// otherwise, it will be an array of zero or more VNObservation
			// subclasses specific to the VNRequest subclass.
			// ArrayFromHandle<T> does the null checking for us.
			return NSArray.ArrayFromHandle<T> (_Results);
		}
	}
}
#endif

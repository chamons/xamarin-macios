// 
// UITraitCollection.cs: support for UITraitCollection
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2016 Xamarin Inc. All rights reserved.
//

using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.UIKit {
#if !WATCH
	public partial class UITraitCollection {
		public UITraitCollection FromPreferredContentSizeCategory (UIContentSizeCategory category)
		{
			return FromPreferredContentSizeCategory (category.GetConstant ());
		}
	}
#endif
}

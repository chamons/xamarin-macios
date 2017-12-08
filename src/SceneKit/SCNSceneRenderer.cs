//
// SCNSceneRenderer.cs
//
// Authors:
//   Rolf Bjarne Kvinge <rolf@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;
using XamCore.CoreGraphics;

namespace XamCore.SceneKit {

#if !XAMCORE_3_0
	public static partial class SCNSceneRenderer_Extensions {
		public static SCNHitTestResult[] HitTest (ISCNSceneRenderer This, CGPoint thePoint, SCNHitTestOptions options)
		{
			return This.HitTest (thePoint, options == null ? null : options.Dictionary);
		}
	}
#endif
}

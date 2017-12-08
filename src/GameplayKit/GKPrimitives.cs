//
// GKPrimitives.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2016 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0 || !MONOMAC

using System;
using System.Runtime.InteropServices;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

using Vector2 = global::OpenTK.Vector2;
using Vector3 = global::OpenTK.Vector3;

namespace XamCore.GameplayKit {

	[iOS (10,0), TV (10,0), Mac (10,12, onlyOn64: true)]
	[StructLayout (LayoutKind.Sequential)]
	public struct GKBox {
		public Vector3 Min;
		public Vector3 Max;
	}

	[iOS (10,0), TV (10,0), Mac (10,12, onlyOn64: true)]
	[StructLayout (LayoutKind.Sequential)]
	public struct GKQuad {
		public Vector2 Min;
		public Vector2 Max;
	}

	[iOS (10,0), TV (10,0), Mac (10,12, onlyOn64: true)]
	[StructLayout (LayoutKind.Sequential)]
	public struct GKTriangle {
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
		Vector3 [] points;
		public Vector3 [] Points {
			get {
				return points ?? (points = new Vector3 [3]);
			}
			set {
				if (value == null)
					throw new ArgumentNullException (nameof (value));
				if (value.Length != 3)
					throw new ArgumentOutOfRangeException (nameof (value), "The length of the Value array must be 3");
				points = value;
			}
		}
	}
}
#endif

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
using ObjCRuntime;

using Vector2 = global::OpenTK.Vector2;
using Vector3 = global::OpenTK.Vector3;

namespace GameplayKit {

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[StructLayout (LayoutKind.Sequential)]
	public struct GKBox {
		public Vector3 Min;
		public Vector3 Max;
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[StructLayout (LayoutKind.Sequential)]
	public struct GKQuad {
		public Vector2 Min;
		public Vector2 Max;
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
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

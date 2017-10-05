//
// MLMultiArray.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0

using System;
using Foundation;
using ObjCRuntime;

namespace CoreML {
	public partial class MLMultiArray {
		static NSNumber[] ConvertArray (nint[] value)
		{
			if (value == null)
				return null;

			return Array.ConvertAll<nint, NSNumber> (value, NSNumber.FromNInt);
		}

		// NSArray<NSNumber> => nint[]
		internal static nint[] ConvertArray (IntPtr handle)
		{
			return NSArray.ArrayFromHandle<nint> (handle, (v) => Messaging.nint_objc_msgSend (v, Selector.GetHandle ("integerValue")));
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public MLMultiArray (nint [] shape, MLMultiArrayDataType dataType, out NSError error)
			: this (ConvertArray (shape), dataType, out error)
		{
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public MLMultiArray (IntPtr dataPointer, nint [] shape, MLMultiArrayDataType dataType, nint [] strides, Action<IntPtr> deallocator, out NSError error)
			: this (dataPointer, ConvertArray (shape), dataType, ConvertArray (strides), deallocator, out error)
		{
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public NSNumber this [nint idx] {
			get { return GetObject (idx); }
			set { SetObject (value, idx); }
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public NSNumber this [params nint[] indices] {
			get { return GetObject (indices); }
			set { SetObject (value, indices); }
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public NSNumber this [NSNumber [] key] {
			get { return GetObject (key); }
			set { SetObject (value, key); }
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public NSNumber GetObject (params nint[] indices)
		{
			using (var arr = NSArray.FromNSObjects<nint> (NSNumber.FromNInt, indices))
				return GetObject (arr.GetHandle ());
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public void SetObject (NSNumber obj, params nint[] indices)
		{
			using (var arr = NSArray.FromNSObjects<nint> (NSNumber.FromNInt, indices))
				SetObject (obj, arr.GetHandle ());
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public nint[] Shape {
			get {
				return ConvertArray (_Shape);
			}
		}

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64), Introduced (PlatformName.iOS, 11, 0)]
		public nint[] Strides {
			get {
				return ConvertArray (_Strides);
			}
		}
	}
}
#endif

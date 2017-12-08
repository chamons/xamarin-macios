//
// NSJsonSerialization.cs
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2014, Xamarin Inc.
//
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Foundation {

	public partial class NSJsonSerialization {

#if !XAMCORE_2_0
		[Obsolete ("Use the 'Deserialize(NSData,NSJsonReadingOptions,out NSError)' overload instead.")]
		public static NSObject Deserialize (NSData data, NSJsonReadingOptions opt, NSError error)
		{
			return Deserialize (data, opt, out error);
		}
#endif
	}
}

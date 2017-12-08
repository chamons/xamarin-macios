//
// Helper methods for NSDistributedNotificationCenter
//
// Author:
//   Miguel de Icaza
//
// Copyright 2011 Xamarin Inc
//
#if !MONOMAC && !XAMCORE_3_0

using System;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Foundation {

	[Obsolete ("This is not available in iOS.")]
	public partial class NSDistributedNotificationCenter {

		[Obsolete ("This is not available in iOS.")]
		public void AddObserver (NSObject observer, Selector aSelector, string aName, string anObject)
		{
		}

		[Obsolete ("This is not available in iOS.")]
		public void RemoveObserver (NSObject observer, string aName, string anObject)
		{
		}
	}
}

#endif

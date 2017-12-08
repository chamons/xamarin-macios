// Copyright 2015 Xamarin Inc. All rights reserved.

// note: Contacts is not part of classic as several API requires generics

#if XAMCORE_2_0 && !XAMCORE_3_0

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Contacts {

	public static partial class CNGroup_PredicatesExtension {

#if !MONOMAC
		[Obsolete ("This API is only available on macOS 10.11+.")]
		public static Foundation.NSPredicate GetPredicateForSubgroupsInGroup (CNGroup This, string parentGroupIdentifier)
		{
			return null;
		}
#endif
	}
}

#endif

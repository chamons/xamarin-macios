//
// NSEntityDescription.cs
//
// Author:
//   Aaron Bockover <abock@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.

using Foundation;
using ObjCRuntime;

namespace CoreData
{
	public partial class NSEntityDescription
	{
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		public NSObject[][] UniquenessConstraints {
			get { return NSArray.FromArrayOfArray (_UniquenessConstraints); }
			set { _UniquenessConstraints = NSArray.From (value); }
		}
	}
}

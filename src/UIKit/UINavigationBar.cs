//
// uikit.cs: Extensions for MonoTouch.UINavigationBar
//
// Copyright 2011, Xamarin, Inc.
//
// Author:
//  Miguel de Icaza
//

#if IOS

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.CoreAnimation;
using XamCore.CoreGraphics;
using XamCore.MediaPlayer;

namespace XamCore.UIKit {
	public partial class UINavigationBar {

#if !XAMCORE_2_0
		[Obsolete ("Use TitleTextAttributes property with UIStringAttributes")]
		public UITextAttributes GetTitleTextAttributes ()
		{
			return new UITextAttributes (_TitleTextAttributes);
		}

		[Obsolete ("Use TitleTextAttributes with UIStringAttributes")]
		public void SetTitleTextAttributes (UITextAttributes attributes)
		{
			if (attributes == null)
				throw new ArgumentNullException ("attributes");

			_TitleTextAttributes = attributes.ToDictionary ();
		}
#endif

		public partial class UINavigationBarAppearance {
			public virtual UITextAttributes GetTitleTextAttributes ()
			{
				return new UITextAttributes (_TitleTextAttributes);
			}
	
			public virtual void SetTitleTextAttributes (UITextAttributes attributes)
			{
				if (attributes == null)
					throw new ArgumentNullException ("attributes");
					
				_TitleTextAttributes = attributes.ToDictionary ();
			}
		}
	}
}

#endif // IOS

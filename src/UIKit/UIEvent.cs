//
// UIEvent.cs: Extensions to the UIEvent class
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2012, Xamarin Inc
//

#if !WATCH

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
	public partial class UIEvent {

		public override string ToString ()
		{
			return String.Format ("[Time={0} ({1}{2})]", Timestamp, Type, Subtype != UIEventSubtype.None ? "." + Subtype : "");
		}
	}
}

#endif // !WATCH

//
// This file implements the NSUndoManager interfase
//
// Authors:
//   Paola Villarreal
//
// Copyright 2015 Xamarin Inc.
//
//

using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Foundation {
	public partial class NSUndoManager {
		public virtual void SetActionName (string actionName) {
			SetActionname (actionName);
		}
	}
}

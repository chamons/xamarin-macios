﻿//
// INSearchCallHistoryIntent.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif

namespace XamCore.Intents {
	public partial class INSearchCallHistoryIntent {

		public bool? Unseen {
			get { return WeakUnseen?.BoolValue; }
		}
	}
}
#endif

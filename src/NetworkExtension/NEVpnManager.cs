//
// NEVpnManager.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if XAMCORE_2_0 && MONOMAC
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Security;

namespace XamCore.NetworkExtension {
	public partial class NEVpnManager {

		[Mac (10,11)]
		public void SetAuthorization (Authorization authorization)
		{
			if (authorization == null)
				throw new ArgumentNullException (nameof (authorization));

			_SetAuthorization (authorization.Handle);
		}
	}
}
#endif

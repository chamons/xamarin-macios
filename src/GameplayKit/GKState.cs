﻿//
// GKState.cs: Implements some nicer methods for GKState
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.
//
#if XAMCORE_2_0 || !MONOMAC
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.GameplayKit {
	public partial class GKState {

		internal static Class GetClass (Type type, string parameterName)
		{
			if (type == null)
				throw new ArgumentNullException (parameterName);

			var klass = new Class (type);
			// most API do not accept null so we throw in managed code instead of crashing the app
			if (klass.Handle == IntPtr.Zero)
				throw new ArgumentException ("Not an type exposed to ObjC", parameterName);

			return klass;
		}

		internal static Class GetClass (NSObject instance, string parameterName)
		{
			if (instance == null)
				throw new ArgumentNullException (parameterName);
			
			var klass = instance.Class; 
			if ((klass == null) || (klass.Handle == IntPtr.Zero))
				throw new ArgumentException ("Not an type exposed to ObjC", parameterName);
			
			return klass;
		}

		// helper - cannot be virtual as it would not be called from GameplayKit/ObjC
		public bool IsValidNextState (Type stateType)
		{
			return IsValidNextState (GetClass (stateType, "stateType"));
		}

		// helper [#32844] - cannot be virtual as it would not be called from GameplayKit/ObjC
		public bool IsValidNextState (GKState state)
		{
			return IsValidNextState (GetClass (state, "state"));
		}
	}
}
#endif

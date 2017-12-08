﻿using System;
using System.Runtime.InteropServices;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.AudioUnit
{
#if XAMCORE_2_0 || !MONOMAC
	[iOS (9,0), Mac(10,11, onlyOn64 : true)]
	public partial class AUParameter
	{
		public string GetString (float? value)
		{
			unsafe {
				if (value != null && value.HasValue) {
					float f = value.Value;
					return this._GetString (new IntPtr (&f));
				}
				else {
					return this._GetString (IntPtr.Zero);
				}
			}
		}

		public void SetValue (float value, AUParameterObserverToken originator)
		{
			SetValue (value, originator.ObserverToken);
		}

		public void SetValue (float value, AUParameterObserverToken originator, ulong hostTime)
		{
			SetValue (value, originator.ObserverToken, hostTime);
		}
	}
#endif
}

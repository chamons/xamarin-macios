//
// NSDirectoryEnumerator.cs:
// Author:
//   Miguel de Icaza
//
// Copyright 2011 - 2014 Xamarin Inc
//
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using System;
using System.Collections.Generic;
using System.Collections;

namespace XamCore.Foundation {
	public partial class NSDirectoryEnumerator : IEnumerator<NSString>, IEnumerator<string>, IEnumerator {
		NSObject current;

		bool IEnumerator.MoveNext ()
		{
			current = NextObject ();
			return current != null;
		}
		
		void IEnumerator.Reset ()
		{
			throw new InvalidOperationException ();
		}

		string IEnumerator<string>.Current {
			get {
				return current.ToString ();
			}
		}

		NSString IEnumerator<NSString>.Current {
			get {
				return current as NSString;
			}
		}

		object IEnumerator.Current {
			get {
				return current;
			}
		}
	}
}
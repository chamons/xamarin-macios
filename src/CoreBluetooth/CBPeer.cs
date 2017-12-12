#if IOS
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using XamCore.Foundation;
using System;
using XamCore.CoreFoundation;

namespace XamCore.CoreBluetooth {
	public partial class CBPeer  {
		[Availability (Deprecated = Platform.iOS_7_0, Obsoleted = Platform.iOS_9_0)]
		public virtual CBUUID UUID { 
			get {
				return CBUUID.FromCFUUID (_UUID);	
			}
		}
	}
}
#endif

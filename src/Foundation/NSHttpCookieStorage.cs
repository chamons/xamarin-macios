using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using System;

namespace XamCore.Foundation {
	public partial class NSHttpCookieStorage {
#if !XAMCORE_2_0
		// sadly they were not readonly
		public static NSString CookiesChangedNotification;
		public static NSString AcceptPolicyChangedNotification;

		static NSHttpCookieStorage ()
		{
			var handle = Libraries.Foundation.Handle;
			if (handle == IntPtr.Zero)
				return;

			CookiesChangedNotification = Dlfcn.GetStringConstant (handle, "NSHTTPCookieManagerAcceptPolicyChangedNotification");
			AcceptPolicyChangedNotification = Dlfcn.GetStringConstant (handle, "NSHTTPCookieManagerCookiesChangedNotification");
		}
#endif
	}
}
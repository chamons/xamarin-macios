using System;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif

namespace XamCore.Foundation {
	public partial class NSBundle : NSObject {
		public string LocalizedString (string key, string comment) {
			return LocalizedString (key, "", "");
		}

		public string LocalizedString (string key, string val, string table, string comment) {
			return LocalizedString (key, val, table);
		}

		public string [] PathsForResources (string fileExtension) {
			return PathsForResources (fileExtension, null);
		}
	}
}

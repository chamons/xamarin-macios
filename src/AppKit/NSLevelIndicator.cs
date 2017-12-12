//
// NSLevelIndicator: Support for the NSLevelIndicator class
//
// Author:
//   Pavel Sich (pavel.sich@me.com)
//

using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.AppKit {

	public partial class NSLevelIndicator {
		public new NSLevelIndicatorCell Cell {
			get { return (NSLevelIndicatorCell)base.Cell; }
			set { base.Cell = value; }
		}
	}
}

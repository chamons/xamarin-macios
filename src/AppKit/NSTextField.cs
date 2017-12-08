//
// NSTextField.cs: Support for the NSTextField class
//
using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.AppKit {

	public partial class NSTextField {
		public new NSTextFieldCell Cell {
			get { return (NSTextFieldCell)base.Cell; }
			set { base.Cell = value; }
		}
	}
}

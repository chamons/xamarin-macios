using System;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.WebKit {
	public partial class DomHtmlSelectElement { 
		public DomNode this [string name] { get { return this.NamedItem (name); } }
		public DomNode this [uint index] { get { return this.GetItem (index); } } 
	}
	public partial class DomHtmlOptionsCollection { 
		public DomNode this [string name] { get { return this.NamedItem (name); } }
		public DomNode this [uint index] { get { return this.GetItem(index); } }
	}
}

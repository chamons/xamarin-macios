using System;

using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
#if MONOMAC
using XamCore.AppKit;
#endif
using XamCore.CoreGraphics;

namespace XamCore.CoreAnimation {
	public partial class CABasicAnimation {
		public T GetFromAs <T> () where T : class, INativeObject
		{
			return Runtime.GetINativeObject<T> (_From, false);
		}

		public void SetFrom (INativeObject value)
		{
			_From = value.Handle;
		}

		public T GetToAs <T> () where T : class, INativeObject
		{
			return Runtime.GetINativeObject<T> (_To, false);
		}

		public void SetTo (INativeObject value)
		{
			_To = value.Handle;
		}

		public T GetByAs <T> () where T : class, INativeObject
		{
			return Runtime.GetINativeObject<T> (_By, false);
		}

		public void SetBy (INativeObject value)
		{
			_By = value.Handle;
		}
	}
}
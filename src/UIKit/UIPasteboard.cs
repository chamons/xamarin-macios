#if IOS
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;

using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.Foundation;

namespace XamCore.UIKit {
	public partial class UIPasteboard {
		const string selImages = "images";
		const string selSetImages_ = "setImages:";

		UIImage [] GetImageArray (IntPtr handle)
		{
			using (var array = new NSArray (handle)) {
				var ret = new UIImage [array.Count];
				for (uint i = 0; i < ret.Length; i++) {
					var obj = Runtime.GetNSObject (array.ValueAt (i));
					var data = obj as NSData;
					UIImage img;
			
					if (data != null) {
						img = new UIImage (data);
					} else {
						img = (UIImage) obj;
					}
			
					ret [i] = img;
				}
				
				return ret;
			}
		}

		// iOS6 introduced a breaking change in UIPasteboard.Images - they don't
		// return images anymore, they return NSData objects (contrary to what
		// their documentation says). Transparently create UIImage objects from
		// the NSData objects whenever required, so that we can keep our existing
		// API and not make users change their code.

		[CompilerGenerated]
		public virtual UIImage[] Images {
			[Export ("images", ArgumentSemantic.Copy)]
			get {
				global::XamCore.UIKit.UIApplication.EnsureUIThread ();
				UIImage[] ret;
				if (IsDirectBinding) {
					ret = GetImageArray (XamCore.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle (selImages)));
				} else {
					ret = GetImageArray (XamCore.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle (selImages)));
				}
				return ret;
			}
			
			[Export ("setImages:", ArgumentSemantic.Copy)]
			set {
				global::XamCore.UIKit.UIApplication.EnsureUIThread ();
				var nsa_value = NSArray.FromNSObjects (value);
				
				if (IsDirectBinding) {
					XamCore.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle (selSetImages_), nsa_value.Handle);
				} else {
					XamCore.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle (selSetImages_), nsa_value.Handle);
				}
				nsa_value.Dispose ();
			}
		}
	}
}

#endif // IOS

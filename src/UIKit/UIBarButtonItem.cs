//
// Sanitize callbacks
//

#if !WATCH

using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif
using System;

namespace XamCore.UIKit {

	public partial class UIBarButtonItem {
		static Selector actionSel = new Selector ("InvokeAction:");

		[Register]
		internal class Callback : NSObject {
			internal UIBarButtonItem container;

			public Callback ()
			{
				IsDirectBinding = false;
			}

			[Export ("InvokeAction:")]
			[Preserve (Conditional = true)]
			public void Call (NSObject sender)
			{
				if (container.clicked != null)
					container.clicked (sender, EventArgs.Empty);
			}
		}

		public UIBarButtonItem (UIImage image, UIBarButtonItemStyle style, EventHandler handler)
		: this (image, style, new Callback () , actionSel)
		{
			callback = (Callback) Target;
			callback.container = this;
			clicked += handler;
			MarkDirty ();
		}
		
		
		public UIBarButtonItem  (string title, UIBarButtonItemStyle style, EventHandler handler)
		: this (title, style, new Callback (), actionSel)
		{
			callback = (Callback) Target;
			callback.container = this;
			clicked += handler;
			MarkDirty ();
		}
						

		public UIBarButtonItem (UIBarButtonSystemItem systemItem, EventHandler handler)
		: this (systemItem, new Callback (), actionSel)
		{
			callback = (Callback) Target;
			callback.container = this;
			clicked += handler;
			MarkDirty ();
		}

		public UIBarButtonItem (UIBarButtonSystemItem systemItem) : this (systemItem, null, null)
		{
		}

		internal EventHandler clicked;
		internal Callback callback;
		
		public event EventHandler Clicked {
			add {
				if (clicked == null){
					callback = new Callback ();
					callback.container = this;
					this.Target = callback;
					this.Action = actionSel;
					MarkDirty ();
				}
				
				clicked += value;
			}

			remove {
				clicked -= value;
			}
		}
	}
}

#endif // !WATCH

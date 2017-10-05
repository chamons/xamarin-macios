//
// NSThread.cs: extensions for NSThread
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//
// Copyright 2013 Xamarin Inc

#if MONOMAC

using System;

namespace Foundation 
{
	public partial class NSThread
	{
		class ActionThread : NSThread
		{
			global::System.Action action;
		
			public ActionThread (global::System.Action action)
			{
				this.action = action;
			}
	
			public override void Main ()
			{
				action ();
			}
		}

		public static NSThread Start (global::System.Action action)
		{
			if (action == null) {
				throw new ArgumentNullException ("action");
			}

			var thread = new ActionThread (action);
			thread.Start ();
			return thread;
		}
	}
}

#endif // MONOMAC

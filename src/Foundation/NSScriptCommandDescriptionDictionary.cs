// Copyright 2015 Xamarin, Inc.
using System;
using XamCore.Foundation;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
#endif

namespace XamCore.Foundation {

#if MONOMAC

	public static class NSScriptCommandDescriptionDictionaryKeys {
		private static NSString cmdClass = new NSString ("CommandClass");
		public static NSString CommandClassKey { 
			get { return cmdClass; }
		}
		
		public static NSString AppleEventCodeKey { 
			get { return NSScriptCommonKeys.AppleEventCodeKey; }
		}
		
		private static NSString codeClass = new NSString ("AppleEventClassCode");
		public static NSString AppleEventClassCodeKey { 
			get { return codeClass; }
		}
		
		public static NSString TypeKey {
			get { return NSScriptCommonKeys.TypeKey; }
		}
		
		private static NSString resultAppEventCode = new NSString ("ResultAppleEventCode");
		public static NSString ResultAppleEventCodeKey { 
			get { return resultAppEventCode; }
		}
		
		private static NSString args = new NSString ("Arguments");
		public static NSString ArgumentsKey {
			get { return args; }
		}
	}

	public partial class NSScriptCommandDescriptionDictionary {

		public void Add (NSScriptCommandArgumentDescription arg)
		{
			if (arg == null)
				throw new ArgumentNullException ("arg");
			if (Arguments == null)
				Arguments = new NSMutableDictionary (); 
			using (var nsName = new NSString (arg.Name)) {
				Arguments.Add (nsName, arg.Dictionary);
			}
		}

		public bool Remove (NSScriptCommandArgumentDescription arg)
		{
			if (arg == null)
				throw new ArgumentNullException ("arg");
			using (var nsName = new NSString (arg.Name)) {
				return Arguments?.Remove (nsName) ?? false;
			}
		}
	}

#endif

}

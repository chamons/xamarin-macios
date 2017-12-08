#if XAMCORE_2_0 && IOS

using XamCore.Foundation;
using XamCore.Intents;
using XamCore.ObjCRuntime;
#if !COREBUILD
using MacAttribute = XamCore.ObjCRuntime.Extensions.MacAttribute;
using iOSAttribute = XamCore.ObjCRuntime.Extensions.iOSAttribute;
using TVAttribute = XamCore.ObjCRuntime.Extensions.TVAttribute;
using WatchAttribute = XamCore.ObjCRuntime.Extensions.WatchAttribute;
#endif
using XamCore.UIKit;

namespace XamCore.Intents {

	public partial class INSetProfileInCarIntent {

		[DesignatedInitializer]
		public INSetProfileInCarIntent (NSNumber profileNumber, string profileLabel, bool? defaultProfile) :
			this (profileNumber, profileLabel, defaultProfile.HasValue ? new NSNumber (defaultProfile.Value) : null)
		{
		}

		protected INSetProfileInCarIntent (NSNumber profileNumber, string profileLabel, NSNumber defaultProfile)
		{
			// Apple created this change in 10,2
			if (UIDevice.CurrentDevice.CheckSystemVersion (10, 2))
				InitializeHandle (InitWithProfileNumberName (profileNumber, profileLabel, defaultProfile));
			else
				InitializeHandle (InitWithProfileNumberLabel (profileNumber, profileLabel, defaultProfile));
		}

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public bool? DefaultProfile {
			get { return _DefaultProfile == null ? null : (bool?) _DefaultProfile.BoolValue; }
		}
	}
}

#endif

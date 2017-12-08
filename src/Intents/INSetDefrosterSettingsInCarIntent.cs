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

namespace XamCore.Intents {

	public partial class INSetDefrosterSettingsInCarIntent {

		public INSetDefrosterSettingsInCarIntent (bool? enable, INCarDefroster defroster) :
			this (enable.HasValue ? new NSNumber (enable.Value) : null, defroster)
		{
		}

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public bool? Enable {
			get { return _Enable == null ? null : (bool?) _Enable.BoolValue; }
		}
	}
}

#endif

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

	public partial class INStartWorkoutIntent {

		public INStartWorkoutIntent (INSpeakableString workoutName, NSNumber goalValue, INWorkoutGoalUnitType workoutGoalUnitType, INWorkoutLocationType workoutLocationType, bool? isOpenEnded) :
			this (workoutName, goalValue, workoutGoalUnitType, workoutLocationType, isOpenEnded.HasValue ? new NSNumber (isOpenEnded.Value) : null)
		{
		}

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public bool? IsOpenEnded {
			get { return _IsOpenEnded == null ? null : (bool?) _IsOpenEnded.BoolValue; }
		}
	}
}

#endif

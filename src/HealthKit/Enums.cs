using XamCore.CoreFoundation;
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using System;

namespace XamCore.HealthKit
{
	// NSInteger -> HKDefines.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKUpdateFrequency : long {
		Immediate = 1,
		Hourly,
		Daily,
		Weekly
	}

	// NSInteger -> HKDefines.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKAuthorizationStatus : long {
		NotDetermined = 0,
		SharingDenied,
		SharingAuthorized
	}

	// NSInteger -> HKDefines.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKBiologicalSex : long {
		NotSet = 0,
		Female,
		Male,
		[Introduced (PlatformName.iOS, 8, 2)]
		Other
	}

	// NSInteger -> HKDefines.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKBloodType : long {
		NotSet = 0,
		APositive,
		ANegative,
		BPositive,
		BNegative,
		ABPositive,
		ABNegative,
		OPositive,
		ONegative
	}

	// NSInteger -> HKMetadata.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKBodyTemperatureSensorLocation : long {
		Other = 0,
		Armpit,
		Body,
		Ear,
		Finger,
		GastroIntestinal,
		Mouth,
		Rectum,
		Toe,
		EarDrum,
		TemporalArtery,
		Forehead
	}

	// NSInteger -> HKMetadata.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKHeartRateSensorLocation : long {
		Other = 0,
		Chest,
		Wrist,
		Finger,
		Hand,
		EarLobe,
		Foot
	}

	// NSInteger -> HKObjectType.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKQuantityAggregationStyle : long {
		Cumulative = 0,
		Discrete
	}

	// NSInteger -> HKObjectType.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKCategoryValueSleepAnalysis : long {
		InBed,
		Asleep,
		[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.iOS, 10, 0)]
		Awake,
	}

	// NSUInteger -> HKQuery.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	[Flags]
	public enum HKQueryOptions : ulong {
		None               = 0,
		StrictStartDate    = 1 << 0,
		StrictEndDate      = 1 << 1
	}

	// NSUInteger -> HKStatistics.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	[Flags]
	public enum HKStatisticsOptions : ulong {
		None              	  = 0,
		SeparateBySource          = 1 << 0,
		DiscreteAverage           = 1 << 1,
		DiscreteMin               = 1 << 2,
		DiscreteMax               = 1 << 3,
		CumulativeSum             = 1 << 4
	}

	// NSInteger -> HKUnit.h
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum HKMetricPrefix : long {
		None = 0,
		Pico,
		Nano,
		Micro,
		Milli,
		Centi,
		Deci,
		Deca,
		Hecto,
		Kilo,
		Mega,
		Giga,
		Tera
	}

	// Convenience enum, ObjC uses NSString
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	public enum HKQuantityTypeIdentifier {
		BodyMassIndex,
		BodyFatPercentage,
		Height,
		BodyMass,
		LeanBodyMass,
		HeartRate,
		StepCount,
		DistanceWalkingRunning,
		DistanceCycling,
		BasalEnergyBurned,
		ActiveEnergyBurned,
		FlightsClimbed,
		NikeFuel,
		// Blood
		OxygenSaturation,
		BloodGlucose,
		BloodPressureSystolic,
		BloodPressureDiastolic,
		BloodAlcoholContent,
		PeripheralPerfusionIndex,
		// Miscellaneous
		ForcedVitalCapacity,
		ForcedExpiratoryVolume1,
		PeakExpiratoryFlowRate,
		NumberOfTimesFallen,
		InhalerUsage,
		RespiratoryRate,
		BodyTemperature,
		// Nutrition
		DietaryFatTotal,
		DietaryFatPolyunsaturated,
		DietaryFatMonounsaturated,
		DietaryFatSaturated,
		DietaryCholesterol,
		DietarySodium,
		DietaryCarbohydrates,
		DietaryFiber,
		DietarySugar,
		DietaryEnergyConsumed,
		DietaryProtein,
		DietaryVitaminA,
		DietaryVitaminB6,
		DietaryVitaminB12,
		DietaryVitaminC,
		DietaryVitaminD,
		DietaryVitaminE,
		DietaryVitaminK,
		DietaryCalcium,
		DietaryIron,
		DietaryThiamin,
		DietaryRiboflavin,
		DietaryNiacin,
		DietaryFolate,
		DietaryBiotin,
		DietaryPantothenicAcid,
		DietaryPhosphorus,
		DietaryIodine,
		DietaryMagnesium,
		DietaryZinc,
		DietarySelenium,
		DietaryCopper,
		DietaryManganese,
		DietaryChromium,
		DietaryMolybdenum,
		DietaryChloride,
		DietaryPotassium,
		DietaryCaffeine,
		[Introduced (PlatformName.iOS, 9, 0)]
		BasalBodyTemperature,
		[Introduced (PlatformName.iOS, 9, 0)]
		DietaryWater,
		[Introduced (PlatformName.iOS, 9, 0)]
		UVExposure,
		ElectrodermalActivity,
		[Introduced (PlatformName.iOS, 9, 3), Introduced (PlatformName.WatchOS, 2, 2)]
		AppleExerciseTime,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		DistanceWheelchair,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		PushCount,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		DistanceSwimming,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		SwimmingStrokeCount,
	}

	// Convenience enum, ObjC uses NSString
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	public enum HKCategoryTypeIdentifier {
		SleepAnalysis,
		[Introduced (PlatformName.iOS, 9, 0)]
		AppleStandHour,
		[Introduced (PlatformName.iOS, 9, 0)]
		CervicalMucusQuality,
		[Introduced (PlatformName.iOS, 9, 0)]
		OvulationTestResult,
		[Introduced (PlatformName.iOS, 9, 0)]
		MenstrualFlow,
		[Introduced (PlatformName.iOS, 9, 0)]
		IntermenstrualBleeding,
		[Introduced (PlatformName.iOS, 9, 0)]
		SexualActivity,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		MindfulSession,
	}

	// Convenience enum, ObjC uses NSString
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	public enum HKCharacteristicTypeIdentifier {
		BiologicalSex,
		BloodType,
		DateOfBirth,
		[Introduced (PlatformName.iOS, 9, 0)]
		FitzpatrickSkinType,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		WheelchairUse,
	}

	// Convenience enum, ObjC uses NSString
	[Introduced (PlatformName.WatchOS, 2, 0), Introduced (PlatformName.iOS, 8, 0)]
	public enum HKCorrelationTypeIdentifier {
		BloodPressure,
		Food,
	}

	[Native]
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	public enum HKWorkoutActivityType : ulong {
		AmericanFootball = 1,
		Archery,
		AustralianFootball,
		Badminton,
		Baseball,
		Basketball,
		Bowling,
		Boxing,
		Climbing,
		Cricket,
		CrossTraining,
		Curling,
		Cycling,
		Dance,
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		DanceInspiredTraining,
		Elliptical,
		EquestrianSports,
		Fencing,
		Fishing,
		FunctionalStrengthTraining,
		Golf,
		Gymnastics,
		Handball,
		Hiking,
		Hockey,
		Hunting,
		Lacrosse,
		MartialArts,
		MindAndBody,
		MixedMetabolicCardioTraining,
		PaddleSports,
		Play,
		PreparationAndRecovery,
		Racquetball,
		Rowing,
		Rugby,
		Running,
		Sailing,
		SkatingSports,
		SnowSports,
		Soccer,
		Softball,
		Squash,
		StairClimbing,
		SurfingSports,
		Swimming,
		TableTennis,
		Tennis,
		TrackAndField,
		TraditionalStrengthTraining,
		Volleyball,
		Walking,
		WaterFitness,
		WaterPolo,
		WaterSports,
		Wrestling,
		Yoga,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Barre,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		CoreTraining,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		CrossCountrySkiing,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		DownhillSkiing,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Flexibility,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		HighIntensityIntervalTraining,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		JumpRope,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Kickboxing,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Pilates,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Snowboarding,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Stairs,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		StepTraining,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		WheelchairWalkPace,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		WheelchairRunPace,
		[Introduced (PlatformName.iOS, 8, 2)]
		Other = 3000
	}

	[Native]
	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 8, 0)]
	public enum HKWorkoutEventType : long {
		Pause = 1,
		Resume,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Lap,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		Marker,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		MotionPaused,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		MotionResumed,
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKCategoryValue : long {
		NotApplicable = 0
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKCategoryValueCervicalMucusQuality : long {
		NotApplicable = 0,
		Dry = 1,
		Sticky,
		Creamy,
		Watery,
		EggWhite
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKCategoryValueMenstrualFlow : long {
		NotApplicable = 0,
		Unspecified = 1,
		Light,
		Medium,
		Heavy
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKCategoryValueOvulationTestResult : long {
		NotApplicable = 0,
		Negative = 1,
		Positive,
		Indeterminate
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKCategoryValueAppleStandHour : long {
		Stood = 0,
		Idle
	}

	[Introduced (PlatformName.WatchOS, 2, 0)]
	[Introduced (PlatformName.iOS, 9, 0)]
	[Native]
	public enum HKFitzpatrickSkinType : long {
		NotSet = 0,
		I,
		II,
		III,
		IV,
		V,
		VI
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HKWheelchairUse : long {
		NotSet = 0,
		No,
		Yes,
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HKWeatherCondition : long {
		None = 0,
		Clear,
		Fair,
		PartlyCloudy,
		MostlyCloudy,
		Cloudy,
		Foggy,
		Haze,
		Windy,
		Blustery,
		Smoky,
		Dust,
		Snow,
		Hail,
		Sleet,
		FreezingDrizzle,
		FreezingRain,
		MixedRainAndHail,
		MixedRainAndSnow,
		MixedRainAndSleet,
		MixedSnowAndSleet,
		Drizzle,
		ScatteredShowers,
		Showers,
		Thunderstorms,
		TropicalStorm,
		Hurricane,
		Tornado,
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HKWorkoutSwimmingLocationType : long {
		Unknown = 0,
		Pool,
		OpenWater,
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HKSwimmingStrokeStyle : long {
		Unknown = 0,
		Mixed,
		Freestyle,
		Backstroke,
		Breaststroke,
		Butterfly,
	}
}

using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.HomeKit {

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMError : long {
		AlreadyExists                           = 1,
		NotFound                                = 2,
		InvalidParameter                        = 3,
		AccessoryNotReachable                   = 4,
		ReadOnlyCharacteristic                  = 5,
		WriteOnlyCharacteristic                 = 6,
		NotificationNotSupported                = 7,
		OperationTimedOut                       = 8,
		AccessoryPoweredOff                     = 9,
		AccessDenied                            = 10,
		ObjectAssociatedToAnotherHome           = 11,
		ObjectNotAssociatedToAnyHome            = 12,
		ObjectAlreadyAssociatedToHome           = 13,
		AccessoryIsBusy                         = 14,
		OperationInProgress                     = 15,
		AccessoryOutOfResources                 = 16,
		InsufficientPrivileges                  = 17,
		AccessoryPairingFailed                  = 18,
		InvalidDataFormatSpecified              = 19,
		NilParameter                            = 20,
		UnconfiguredParameter                   = 21,
		InvalidClass                            = 22,
		OperationCancelled                      = 23,
		RoomForHomeCannotBeInZone               = 24,
		NoActionsInActionSet                    = 25,
		NoRegisteredActionSets                  = 26,
		MissingParameter                        = 27,
		FireDateInPast                          = 28,
		RoomForHomeCannotBeUpdated              = 29,
		ActionInAnotherActionSet                = 30,
		ObjectWithSimilarNameExistsInHome       = 31,
		HomeWithSimilarNameExists               = 32,
		RenameWithSimilarName                   = 33,
		CannotRemoveNonBridgeAccessory          = 34,
		NameContainsProhibitedCharacters        = 35,
		NameDoesNotStartWithValidCharacters     = 36,
		UserIDNotEmailAddress                   = 37,
		UserDeclinedAddingUser                  = 38,
		UserDeclinedRemovingUser                = 39,
		UserDeclinedInvite                      = 40,
		UserManagementFailed                    = 41,
		RecurrenceTooSmall                      = 42,
		InvalidValueType                        = 43,
		ValueLowerThanMinimum                   = 44,
		ValueHigherThanMaximum                  = 45,
		StringLongerThanMaximum                 = 46,
		HomeAccessNotAuthorized                 = 47,
		OperationNotSupported                   = 48,
		MaximumObjectLimitReached               = 49,
		AccessorySentInvalidResponse            = 50,
		StringShorterThanMinimum                = 51,
		GenericError                            = 52,
		SecurityFailure                         = 53,
		CommunicationFailure                    = 54,
		MessageAuthenticationFailed             = 55,
		InvalidMessageSize                      = 56,
		AccessoryDiscoveryFailed                = 57,
		ClientRequestError                      = 58,
		AccessoryResponseError                  = 59,
		NameDoesNotEndWithValidCharacters       = 60,
		AccessoryIsBlocked                      = 61,
		InvalidAssociatedServiceType            = 62,
		ActionSetExecutionFailed                = 63,
		ActionSetExecutionPartialSuccess        = 64,
		ActionSetExecutionInProgress            = 65,
		AccessoryOutOfCompliance                = 66,
		DataResetFailure                        = 67,
		NotificationAlreadyEnabled              = 68,
		RecurrenceMustBeOnSpecifiedBoundaries   = 69,
		DateMustBeOnSpecifiedBoundaries         = 70,
		CannotActivateTriggerTooFarInFuture     = 71,
		RecurrenceTooLarge                      = 72,
		ReadWritePartialSuccess                 = 73,
		ReadWriteFailure                        = 74,
		NotSignedIntoiCloud                     = 75,
		KeychainSyncNotEnabled                  = 76,
		CloudDataSyncInProgress                 = 77,
		NetworkUnavailable                      = 78,
		AddAccessoryFailed                      = 79,
		MissingEntitlement                      = 80,
		CannotUnblockNonBridgeAccessory			= 81,
		DeviceLocked							= 82,
		CannotRemoveBuiltinActionSet			= 83,
		LocationForHomeDisabled					= 84,
		NotAuthorizedForLocationServices		= 85,
		// iOS 9.3
		ReferToUserManual						= 86,
		// iOS 10.0
		InvalidOrMissingAuthorizationData       = 87,
		BridgedAccessoryNotReachable            = 88,
		NotAuthorizedForMicrophoneAccess        = 89,
		// iOS 10.2
		IncompatibleNetwork                     = 90,
		// iOS 11
		NoHomeHub = 91,
		IncompatibleHomeHub = 92, // HMErrorCodeNoCompatibleHomeHub introduced and deprecated on iOS 11. HMErrorCodeIncompatibleHomeHub = HMErrorCodeNoCompatibleHomeHub.
	}

	
	// conveniance enum (ObjC uses NSString)
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum HMCharacteristicType {
		None,

		[Field ("HMCharacteristicTypePowerState")]
		PowerState,

		[Field ("HMCharacteristicTypeHue")]
		Hue,

		[Field ("HMCharacteristicTypeSaturation")]
		Saturation,

		[Field ("HMCharacteristicTypeBrightness")]
		Brightness,

		[Field ("HMCharacteristicTypeTemperatureUnits")]
		TemperatureUnits,

		[Field ("HMCharacteristicTypeCurrentTemperature")]
		CurrentTemperature,

		[Field ("HMCharacteristicTypeTargetTemperature")]
		TargetTemperature,

		[Field ("HMCharacteristicTypeCurrentHeatingCooling")]
		CurrentHeatingCooling,

		[Field ("HMCharacteristicTypeTargetHeatingCooling")]
		TargetHeatingCooling,

		[Field ("HMCharacteristicTypeCoolingThreshold")]
		CoolingThreshold,

		[Field ("HMCharacteristicTypeHeatingThreshold")]
		HeatingThreshold,

		[Obsolete ("This value does not exist anymore and will always return null.")]
		HeatingCoolingStatus,

		[Field ("HMCharacteristicTypeCurrentRelativeHumidity")]
		CurrentRelativeHumidity,

		[Field ("HMCharacteristicTypeTargetRelativeHumidity")]
		TargetRelativeHumidity,

		[Field ("HMCharacteristicTypeCurrentDoorState")]
		CurrentDoorState,

		[Field ("HMCharacteristicTypeTargetDoorState")]
		TargetDoorState,

		[Field ("HMCharacteristicTypeObstructionDetected")]
		ObstructionDetected,

		[Field ("HMCharacteristicTypeName")]
		Name,

		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'HMAccessory.Manufacturer' instead.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'HMAccessory.Manufacturer' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'HMAccessory.Manufacturer' instead.")]
		[Field ("HMCharacteristicTypeManufacturer")]
		Manufacturer,

		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'HMAccessory.Model' instead.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'HMAccessory.Model' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'HMAccessory.Model' instead.")]
		[Field ("HMCharacteristicTypeModel")]
		Model,

		[Deprecated (PlatformName.TvOS, 11, 0, message: "No longer supported.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "No longer supported.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "No longer supported.")]
		[Field ("HMCharacteristicTypeSerialNumber")]
		SerialNumber,

		[Field ("HMCharacteristicTypeIdentify")]
		Identify,

		[Field ("HMCharacteristicTypeRotationDirection")]
		RotationDirection,

		[Field ("HMCharacteristicTypeRotationSpeed")]
		RotationSpeed,

		[Field ("HMCharacteristicTypeOutletInUse")]
		OutletInUse,

		[Field ("HMCharacteristicTypeVersion")]
		Version,

		[Field ("HMCharacteristicTypeLogs")]
		Logs,

		[Field ("HMCharacteristicTypeAudioFeedback")]
		AudioFeedback,

		[Field ("HMCharacteristicTypeAdminOnlyAccess")]
		AdminOnlyAccess,

		[Field ("HMCharacteristicTypeMotionDetected")]
		MotionDetected,

		[Field ("HMCharacteristicTypeCurrentLockMechanismState")]
		CurrentLockMechanismState,

		[Field ("HMCharacteristicTypeTargetLockMechanismState")]
		TargetLockMechanismState,

		[Field ("HMCharacteristicTypeLockMechanismLastKnownAction")]
		LockMechanismLastKnownAction,

		[Field ("HMCharacteristicTypeLockManagementControlPoint")]
		LockManagementControlPoint,

		[Field ("HMCharacteristicTypeLockManagementAutoSecureTimeout")]
		LockManagementAutoSecureTimeout,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeAirParticulateDensity")]
		AirParticulateDensity,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeAirParticulateSize")]
		AirParticulateSize,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeAirQuality")]
		AirQuality,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeBatteryLevel")]
		BatteryLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonDioxideDetected")]
		CarbonDioxideDetected,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonDioxideLevel")]
		CarbonDioxideLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonDioxidePeakLevel")]
		CarbonDioxidePeakLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonMonoxideDetected")]
		CarbonMonoxideDetected,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonMonoxideLevel")]
		CarbonMonoxideLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCarbonMonoxidePeakLevel")]
		CarbonMonoxidePeakLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeChargingState")]
		ChargingState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeContactState")]
		ContactState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCurrentSecuritySystemState")]
		CurrentSecuritySystemState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCurrentHorizontalTilt")]
		CurrentHorizontalTilt,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCurrentLightLevel")]
		CurrentLightLevel,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCurrentPosition")]
		CurrentPosition,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeCurrentVerticalTilt")]
		CurrentVerticalTilt,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'HMAccessory.FirmwareVersion' instead.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'HMAccessory.FirmwareVersion' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'HMAccessory.FirmwareVersion' instead.")]
		[Field ("HMCharacteristicTypeFirmwareVersion")]
		FirmwareVersion,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeHardwareVersion")]
		HardwareVersion,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeHoldPosition")]
		HoldPosition,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeInputEvent")]
		InputEvent,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeLeakDetected")]
		LeakDetected,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeOccupancyDetected")]
		OccupancyDetected,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeOutputState")]
		OutputState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypePositionState")]
		PositionState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeSmokeDetected")]
		SmokeDetected,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeSoftwareVersion")]
		SoftwareVersion,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeStatusActive")]
		StatusActive,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeStatusFault")]
		StatusFault,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeStatusJammed")]
		StatusJammed,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeStatusLowBattery")]
		StatusLowBattery,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeStatusTampered")]
		StatusTampered,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeTargetSecuritySystemState")]
		TargetSecuritySystemState,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeTargetHorizontalTilt")]
		TargetHorizontalTilt,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeTargetPosition")]
		TargetPosition,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMCharacteristicTypeTargetVerticalTilt")]
		TargetVerticalTilt,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeStreamingStatus")]
		StreamingStatus,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeSetupStreamEndpoint")]
		SetupStreamEndpoint,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeSupportedVideoStreamConfiguration")]
		SupportedVideoStreamConfiguration,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeSupportedAudioStreamConfiguration")]
		SupportedAudioStreamConfiguration,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeSupportedRTPConfiguration")]
		SupportedRtpConfiguration,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeSelectedStreamConfiguration")]
		SelectedStreamConfiguration,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeVolume")]
		Volume,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeMute")]
		Mute,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeNightVision")]
		NightVision,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeOpticalZoom")]
		OpticalZoom,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeDigitalZoom")]
		DigitalZoom,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeImageRotation")]
		ImageRotation,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMCharacteristicTypeImageMirroring")]
		ImageMirroring,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeActive")]
		Active,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentAirPurifierState")]
		CurrentAirPurifierState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeTargetAirPurifierState")]
		TargetAirPurifierState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentFanState")]
		CurrentFanState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentHeaterCoolerState")]
		CurrentHeaterCoolerState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentHumidifierDehumidifierState")]
		CurrentHumidifierDehumidifierState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentSlatState")]
		CurrentSlatState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeWaterLevel")]
		WaterLevel,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeFilterChangeIndication")]
		FilterChangeIndication,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeFilterLifeLevel")]
		FilterLifeLevel,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeFilterResetChangeIndication")]
		FilterResetChangeIndication,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeLockPhysicalControls")]
		LockPhysicalControls,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeSwingMode")]
		SwingMode,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeTargetHeaterCoolerState")]
		TargetHeaterCoolerState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeTargetHumidifierDehumidifierState")]
		TargetHumidifierDehumidifierState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeTargetFanState")]
		TargetFanState,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeSlatType")]
		SlatType,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeCurrentTilt")]
		CurrentTilt,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeTargetTilt")]
		TargetTilt,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeOzoneDensity")]
		OzoneDensity,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeNitrogenDioxideDensity")]
		NitrogenDioxideDensity,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeSulphurDioxideDensity")]
		SulphurDioxideDensity,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypePM2_5Density")]
		PM2_5Density,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypePM10Density")]
		PM10Density,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeVolatileOrganicCompoundDensity")]
		VolatileOrganicCompoundDensity,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeDehumidifierThreshold")]
		DehumidifierThreshold,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMCharacteristicTypeHumidifierThreshold")]
		HumidifierThreshold,

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 2, 0), Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("HMCharacteristicTypeSecuritySystemAlarmType")]
		SecuritySystemAlarmType,

		[Introduced (PlatformName.iOS, 10, 3), Introduced (PlatformName.WatchOS, 3, 2), Introduced (PlatformName.TvOS, 10, 2)]
		[Field ("HMCharacteristicTypeLabelNamespace")]
		LabelNamespace,

		[Introduced (PlatformName.iOS, 10, 3), Introduced (PlatformName.WatchOS, 3, 2), Introduced (PlatformName.TvOS, 10, 2)]
		[Field ("HMCharacteristicTypeLabelIndex")]
		LabelIndex,

		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0)]
		[Field ("HMCharacteristicTypeColorTemperature")]
		ColorTemperature,
	}

	// conveniance enum (ObjC uses NSString)
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum HMCharacteristicMetadataUnits {
		None,
		Celsius,
		Fahrenheit,
		Percentage,
		ArcDegree,
		[Introduced (PlatformName.iOS, 8, 3)]
		Seconds,
		[Introduced (PlatformName.iOS, 9, 3)][Introduced (PlatformName.WatchOS, 2, 2)]
		Lux,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		PartsPerMillion,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		MicrogramsPerCubicMeter,
	}

	// conveniance enum (ObjC uses NSString)
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Flags]
	public enum HMServiceType {
		None,

		[Field ("HMServiceTypeLightbulb")]
		LightBulb,

		[Field ("HMServiceTypeSwitch")]
		Switch,

		[Field ("HMServiceTypeThermostat")]
		Thermostat,

		[Field ("HMServiceTypeGarageDoorOpener")]
		GarageDoorOpener,

		[Field ("HMServiceTypeAccessoryInformation")]
		AccessoryInformation,

		[Field ("HMServiceTypeFan")]
		Fan,

		[Field ("HMServiceTypeOutlet")]
		Outlet,

		[Field ("HMServiceTypeLockMechanism")]
		LockMechanism,

		[Field ("HMServiceTypeLockManagement")]
		LockManagement,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeAirQualitySensor")]
		AirQualitySensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeBattery")]
		Battery,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeCarbonDioxideSensor")]
		CarbonDioxideSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeCarbonMonoxideSensor")]
		CarbonMonoxideSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeContactSensor")]
		ContactSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeDoor")]
		Door,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeHumiditySensor")]
		HumiditySensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeLeakSensor")]
		LeakSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeLightSensor")]
		LightSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeMotionSensor")]
		MotionSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeOccupancySensor")]
		OccupancySensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeSecuritySystem")]
		SecuritySystem,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeStatefulProgrammableSwitch")]
		StatefulProgrammableSwitch,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeStatelessProgrammableSwitch")]
		StatelessProgrammableSwitch,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeSmokeSensor")]
		SmokeSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeTemperatureSensor")]
		TemperatureSensor,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeWindow")]
		Window,

		[Introduced (PlatformName.iOS, 9, 0)]
		[Field ("HMServiceTypeWindowCovering")]
		WindowCovering,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMServiceTypeCameraRTPStreamManagement")]
		CameraRtpStreamManagement,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMServiceTypeCameraControl")]
		CameraControl,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMServiceTypeMicrophone")]
		Microphone,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMServiceTypeSpeaker")]
		Speaker,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMServiceTypeDoorbell")]
		Doorbell,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeAirPurifier")]
		AirPurifier,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeVentilationFan")]
		VentilationFan,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeFilterMaintenance")]
		FilterMaintenance,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeHeaterCooler")]
		HeaterCooler,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeHumidifierDehumidifier")]
		HumidifierDehumidifier,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMServiceTypeSlats")]
		Slats,

		[Introduced (PlatformName.iOS, 10, 3), Introduced (PlatformName.WatchOS, 3, 2), Introduced (PlatformName.TvOS, 10, 2)]
		[Field ("HMServiceTypeLabel")]
		Label,
	}

	// conveniance enum (ObjC uses NSString)
	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum HMCharacteristicMetadataFormat {
		None,
		Bool,
		Int,
		Float,
		String,
		Array,
		Dictionary,
		UInt8,
		UInt16,
		UInt32,
		UInt64,
		Data,
		Tlv8
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueDoorState : long {
		Open = 0,
		Closed,
		Opening,
		Closing,
		Stopped
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueHeatingCooling : long {
		Off = 0,
		Heat,
		Cool,
		Auto
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueRotationDirection : long {
		Clockwise = 0,
		CounterClockwise
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueTemperatureUnit : long {
		Celsius = 0,
		Fahrenheit
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueLockMechanismState : long {
		Unsecured = 0,
		Secured,
		Jammed,
		Unknown
	}

	[Introduced (PlatformName.iOS, 8, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	// in iOS 8.3 this was renamed HMCharacteristicValueLockMechanismLastKnownAction but that would be a breaking change for us
	public enum HMCharacteristicValueLockMechanism : long {
		LastKnownActionSecuredUsingPhysicalMovementInterior = 0,
		LastKnownActionUnsecuredUsingPhysicalMovementInterior,
		LastKnownActionSecuredUsingPhysicalMovementExterior,
		LastKnownActionUnsecuredUsingPhysicalMovementExterior,
		LastKnownActionSecuredWithKeypad,
		LastKnownActionUnsecuredWithKeypad,
		LastKnownActionSecuredRemotely,
		LastKnownActionUnsecuredRemotely,
		LastKnownActionSecuredWithAutomaticSecureTimeout,
		LastKnownActionSecuredUsingPhysicalMovement,
		LastKnownActionUnsecuredUsingPhysicalMovement,
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueAirParticulate : long {
		Size2_5 = 0,
		Size10
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueCurrentSecuritySystemState : long {
		StayArm = 0,
		AwayArm,
		NightArm,
		Disarmed,
		Triggered
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValuePositionState : long {
		Closing = 0,
		Opening,
		Stopped
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueTargetSecuritySystemState : long {
		StayArm = 0,
		AwayArm,
		NightArm,
		Disarm
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueBatteryStatus : long {
		Normal = 0,
		Low
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueJammedStatus : long {
		None = 0,
		Jammed
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueTamperedStatus : long {
		None = 0,
		Tampered
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueLeakStatus : long {
		None = 0,
		Detected
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueSmokeDetectionStatus : long {
		None = 0,
		Detected
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueChargingState : long {
		None = 0,
		InProgress,
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.WatchOS, 3, 1, 1), Introduced (PlatformName.TvOS, 10, 1)]
		NotChargeable,
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueContactState : long {
		Detected = 0,
		None,
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueStatusFault : long {
		NoFault = 0,
		GeneralFault
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueCarbonMonoxideDetectionStatus : long {
		NotDetected = 0,
		Detected
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueCarbonDioxideDetectionStatus : long {
		NotDetected = 0,
		Detected
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueOccupancyStatus : long {
		NotOccupied = 0,
		Occupied
	}

	[Introduced (PlatformName.WatchOS, 3, 0), Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueSecuritySystemAlarmType : long {
		NoAlarm = 0,
		Unknown
	}

	// conveniance enum (ObjC uses NSString)
	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum HMActionSetType {
		Unknown = -1,
		WakeUp,
		Sleep,
		HomeDeparture,
		HomeArrival,
		UserDefined,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		TriggerOwned,
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	// conveniance enum (ObjC uses NSString)
	public enum HMAccessoryCategoryType {
		[Field ("HMAccessoryCategoryTypeOther")]
		Other = 0,

		[Field ("HMAccessoryCategoryTypeSecuritySystem")]
		SecuritySystem,

		[Field ("HMAccessoryCategoryTypeBridge")]
		Bridge,

		[Field ("HMAccessoryCategoryTypeDoor")]
		Door,

		[Field ("HMAccessoryCategoryTypeDoorLock")]
		DoorLock,

		[Field ("HMAccessoryCategoryTypeFan")]
		Fan,

		[Field ("HMAccessoryCategoryTypeGarageDoorOpener")]
		GarageDoorOpener,

#if !WATCH && !TVOS
		[Obsolete ("Use 'GarageDoorOpener' instead.")]
		DoorOpener = GarageDoorOpener,
#endif

		[Field ("HMAccessoryCategoryTypeLightbulb")]
		Lightbulb,

		[Field ("HMAccessoryCategoryTypeOutlet")]
		Outlet,

		[Field ("HMAccessoryCategoryTypeProgrammableSwitch")]
		ProgrammableSwitch,

		[Field ("HMAccessoryCategoryTypeSensor")]
		Sensor,

		[Field ("HMAccessoryCategoryTypeSwitch")]
		Switch,

		[Field ("HMAccessoryCategoryTypeThermostat")]
		Thermostat,

		[Field ("HMAccessoryCategoryTypeWindow")]
		Window,

		[Field ("HMAccessoryCategoryTypeWindowCovering")]
		WindowCovering,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMAccessoryCategoryTypeRangeExtender")]
		RangeExtender,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMAccessoryCategoryTypeIPCamera")]
		IPCamera,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.WatchOS, 3, 0)]
		[Field ("HMAccessoryCategoryTypeVideoDoorbell")]
		VideoDoorbell,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMAccessoryCategoryTypeAirPurifier")]
		AirPurifier,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMAccessoryCategoryTypeAirHeater")]
		AirHeater,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMAccessoryCategoryTypeAirConditioner")]
		AirConditioner,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMAccessoryCategoryTypeAirHumidifier")]
		AirHumidifier,

		[Introduced (PlatformName.WatchOS, 3, 1, 1)]
		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.TvOS, 10, 1)]
		[Field ("HMAccessoryCategoryTypeAirDehumidifier")]
		AirDehumidifier,
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	public enum HMSignificantEvent {

		[Field ("HMSignificantEventSunrise")]
		Sunrise,

		[Field ("HMSignificantEventSunset")]
		Sunset,
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCharacteristicValueAirQuality : long {
		Unknown = 0,
		Excellent,
		Good,
		Fair,
		Inferior,
		Poor
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCameraStreamState : ulong
	{
		Starting = 1,
		Streaming = 2,
		Stopping = 3,
		NotStreaming = 4
	}

	[Introduced (PlatformName.iOS, 10, 0)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	[Native]
	public enum HMCameraAudioStreamSetting : ulong
	{
		Muted = 1,
		IncomingAudioAllowed = 2,
		BidirectionalAudioAllowed = 3
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueLockPhysicalControlsState : long {
		NotLocked = 0,
		Locked,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueCurrentAirPurifierState : long {
		Inactive = 0,
		Idle,
		Active,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueTargetAirPurifierState : long {
		Manual = 0,
		Automatic,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueCurrentSlatState : long {
		Stationary = 0,
		Jammed,
		Oscillating,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueSlatType : long {
		Horizontal = 0,
		Vertical,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueFilterChange : long {
		NotNeeded = 0,
		Needed,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueCurrentFanState : long {
		Inactive = 0,
		Idle,
		Active,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueTargetFanState : long {
		Manual = 0,
		Automatic,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueCurrentHeaterCoolerState : long {
		Inactive = 0,
		Idle,
		Heating,
		Cooling,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueTargetHeaterCoolerState : long {
		Automatic = 0,
		Heat,
		Cool,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueCurrentHumidifierDehumidifierState : long {
		Inactive = 0,
		Idle,
		Humidifying,
		Dehumidifying,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueTargetHumidifierDehumidifierState : long {
		Automatic = 0,
		Humidify,
		Dehumidify,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueSwingMode : long {
		Disabled = 0,
		Enabled,
	}

	[Introduced (PlatformName.WatchOS, 3, 1, 1)]
	[Introduced (PlatformName.TvOS, 10, 1), Introduced (PlatformName.iOS, 10, 2)]
	[Native]
	public enum HMCharacteristicValueActivationState : long {
		Inactive = 0,
		Active,
	}

	[Introduced (PlatformName.WatchOS, 3, 2), Introduced (PlatformName.TvOS, 10, 2), Introduced (PlatformName.iOS, 10, 3)]
	[Native]
	public enum HMCharacteristicValueInputEvent : long {
		SinglePress = 0,
		DoublePress,
		LongPress,
	}

	[Introduced (PlatformName.WatchOS, 3, 2), Introduced (PlatformName.TvOS, 10, 2), Introduced (PlatformName.iOS, 10, 3)]
	[Native]
	public enum HMCharacteristicValueLabelNamespace : long {
		Dot = 0,
		Numeral,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum HMEventTriggerActivationState : ulong {
		Disabled = 0,
		DisabledNoHomeHub = 1,
		DisabledNoCompatibleHomeHub = 2,
		DisabledNoLocationServicesAuthorization = 3,
		Enabled = 4,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum HMHomeHubState : ulong {
		NotAvailable = 0,
		Connected,
		Disconnected,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum HMPresenceEventType : ulong {
		EveryEntry = 1,
		EveryExit = 2,
		FirstEntry = 3,
		LastExit = 4,
		AtHome = FirstEntry,
		NotAtHome = LastExit,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum HMPresenceEventUserType : ulong {
		CurrentUser = 1,
		HomeUsers = 2,
		CustomUsers = 3,
	}
}

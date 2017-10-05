//
// This file describes the API that the generator will produce
//
// Authors:
//   Miguel de Icaza
//
// Copyrigh 2014-2016, Xamarin Inc.
//
//
using ObjCRuntime;
using Foundation;
using CoreGraphics;
using CoreLocation;
using HealthKit;
using HomeKit;
using PassKit;
using SpriteKit;
using SceneKit;
using UIKit;
using MapKit;
using UserNotifications;
using System;
using System.ComponentModel;

namespace WatchKit {
	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (NSObject))]
	[Abstract] // <quote>To use this class, subclass it</quote> 
	[DisableDefaultCtor] // DesignatedInitializer below
	interface WKInterfaceController {

		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		[Export ("awakeWithContext:")]
		void Awake ([NullAllowed] NSObject context);

		[Export ("contentFrame")]
		CGRect ContentFrame { get; }

		// The super implementation of this method does nothing.
		[Export ("willActivate")]
		void WillActivate ();

		// The super implementation of this method does nothing.
		[Export ("didDeactivate")]
		void DidDeactivate ();

#if WATCH
		[Export ("didAppear")]
		void DidAppear ();

		[Export ("willDisappear")]
		void WillDisappear ();
#endif

		[Export ("table:didSelectRowAtIndex:")]
		void DidSelectRow (WKInterfaceTable table, nint rowIndex);

		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'UNUserNotificationCenterDelegate' instead.")]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'UNUserNotificationCenterDelegate' instead.")]
		[Export ("handleActionWithIdentifier:forRemoteNotification:")]
		void HandleRemoteNotificationAction ([NullAllowed] string identifier, NSDictionary remoteNotification);

		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'UNUserNotificationCenterDelegate' instead.")]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'UNUserNotificationCenterDelegate' instead.")]
		[Export ("handleActionWithIdentifier:forLocalNotification:")]
		void HandleLocalNotificationAction ([NullAllowed] string identifier, UILocalNotification localNotification);

		[Introduced (PlatformName.iOS, 10, 0)]
		[Unavailable (PlatformName.WatchOS)]
		[Export ("handleActionWithIdentifier:forNotification:")]
		void HandleAction ([NullAllowed] string identifier, UNNotification notification);

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'WKExtensionDelegate.HandleUserActivity' instead.")]
		[Export ("handleUserActivity:")]
		// This NSDictionary is OK, it is arbitrary and user specific
		void HandleUserActivity ([NullAllowed] NSDictionary userActivity);

		[Export ("setTitle:")]
		void SetTitle ([NullAllowed] string title);

		[ThreadSafe (false)]
		[Export ("pushControllerWithName:context:")]
		void PushController (string name, [NullAllowed] NSObject context);

		[ThreadSafe (false)]
		[Export ("popController")]
		void PopController ();

		[ThreadSafe (false)]
		[Export ("popToRootController")]
		void PopToRootController ();

		[ThreadSafe (false)]
		[Export ("becomeCurrentPage")]
		void BecomeCurrentPage ();

		[ThreadSafe (false)]
		[Export ("presentControllerWithName:context:")]
		void PresentController (string name, [NullAllowed] NSObject context);

		[ThreadSafe (false)]
		[Export ("presentControllerWithNames:contexts:")]
		void PresentController (string [] names, [NullAllowed] NSObject [] contexts);

		[ThreadSafe (false)]
		[Export ("dismissController")]
		void DismissController ();

		[Export ("dismissTextInputController")]
		void DismissTextInputController ();

		[Export ("contextForSegueWithIdentifier:")]
		NSObject GetContextForSegue (string segueIdentifier);

		[Export ("contextsForSegueWithIdentifier:")]
		NSObject [] GetContextsForSegue (string segueIdentifier);

		[Export ("contextForSegueWithIdentifier:inTable:rowIndex:")]
		NSObject GetContextForSegue (string segueIdentifier, WKInterfaceTable table, nint rowIndex);

		[Export ("contextsForSegueWithIdentifier:inTable:rowIndex:")]
		NSObject [] GetContextsForSegue (string segueIdentifier, WKInterfaceTable table, nint rowIndex);

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("addMenuItemWithImage:title:action:")]
		void AddMenuItem (UIImage image, string title, Selector action);

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("addMenuItemWithImageNamed:title:action:")]
		void AddMenuItem (string imageName, string title, Selector action);

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("addMenuItemWithItemIcon:title:action:")]
		void AddMenuItem (WKMenuItemIcon itemIcon, string title, Selector action);

		[Export ("clearAllMenuItems")]
		void ClearAllMenuItems ();

		[Export ("updateUserActivity:userInfo:webpageURL:")]
		// This NSDictionary is OK, it is arbitrary and user specific
		void UpdateUserActivity (string type, [NullAllowed] NSDictionary userInfo, [NullAllowed] NSUrl webpageURL);

		[Export ("invalidateUserActivity")]
		void InvalidateUserActivity ();

		[ThreadSafe (false)]
		[Export ("presentTextInputControllerWithSuggestions:allowedInputMode:completion:")]
		[Async]
		void PresentTextInputController ([NullAllowed] string [] suggestions, WKTextInputMode inputMode, Action<NSArray> completion);

		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("presentTextInputControllerWithSuggestionsForLanguage:allowedInputMode:completion:")]
		[Async]
		void PresentTextInputController ([NullAllowed] Func<NSString, NSArray> suggestionsHandler, WKTextInputMode inputMode, Action<NSArray> completion);

		[Unavailable (PlatformName.WatchOS)]
		[Static, Export ("openParentApplication:reply:")]
		bool OpenParentApplication (NSDictionary userInfo, [NullAllowed] Action<NSDictionary, NSError> reply);

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'ReloadRootPageControllers' instead.")]
		[Static, Export ("reloadRootControllersWithNames:contexts:")]
		void ReloadRootControllers (string [] names, [NullAllowed] NSObject [] contexts);

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Static]
		[Export ("reloadRootPageControllersWithNames:contexts:orientation:pageIndex:")]
		void ReloadRootPageControllers (string[] names, [NullAllowed] NSObject[] contexts, WKPageOrientation orientation, nint pageIndex);

#if !XAMCORE_3_0
		// now exposed with the corresponding WKErrorCode enum
		[Field ("WatchKitErrorDomain")]
		NSString ErrorDomain { get; }
#endif

#if WATCH
		[Export ("dismissMediaPlayerController")]
		void DismissMediaPlayerController ();

		[Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("presentAudioRecorderControllerWithOutputURL:preset:options:completion:")]
		[Async]
		void PresentAudioRecorderController (NSUrl outputUrl, WKAudioRecorderPreset preset, [NullAllowed] NSDictionary options, Action<bool, NSError> completion);

		[Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("dismissAudioRecorderController")]
		void DismissAudioRecorderController ();

		[Export ("animateWithDuration:animations:")]
		void AnimateWithDuration (double duration, Action animations);

		[Export ("presentAlertControllerWithTitle:message:preferredStyle:actions:")]
		void PresentAlertController ([NullAllowed] string title, [NullAllowed] string message, WKAlertControllerStyle preferredStyle, WKAlertAction[] actions);

		[Export ("presentAddPassesControllerWithPasses:completion:")]
		[Async]
		void PresentAddPassesController (PKPass[] passes, Action completion);

		[Export ("dismissAddPassesController")]
		void DismissAddPassesController ();

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Glances support was removed.")]
		[Export ("beginGlanceUpdates")]
		void BeginGlanceUpdates ();

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Glances support was removed.")]
		[Export ("endGlanceUpdates")]
		void EndGlanceUpdates ();

		[Export ("pickerDidFocus:")]
		void PickerDidFocus (WKInterfacePicker picker);

		[Export ("pickerDidResignFocus:")]
		void PickerDidResignFocus (WKInterfacePicker picker);

		[Export ("pickerDidSettle:")]
		void PickerDidSettle (WKInterfacePicker picker);
#endif
		[Unavailable (PlatformName.iOS)]
		[Export ("presentMediaPlayerControllerWithURL:options:completion:")]
		[Async (ResultType = typeof (WKPresentMediaPlayerResult))]
		void PresentMediaPlayerController (NSUrl url, [NullAllowed] NSDictionary options, Action<bool, double, NSError> completion);

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("crownSequencer", ArgumentSemantic.Strong)]
		WKCrownSequencer CrownSequencer { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("scrollToObject:atScrollPosition:animated:")]
		void ScrollTo (WKInterfaceObject @object, WKInterfaceScrollPosition scrollPosition, bool animated);

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("interfaceDidScrollToTop")]
		void InterfaceDidScrollToTop ();

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("interfaceOffsetDidScrollToTop")]
		void InterfaceOffsetDidScrollToTop ();

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("interfaceOffsetDidScrollToBottom")]
		void InterfaceOffsetDidScrollToBottom ();
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (WKInterfaceController))]
	[DisableDefaultCtor] // DesignatedInitializer below
	interface WKUserNotificationInterfaceController {

		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'DidReceiveNotification' instead.")]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'DidReceiveNotification' instead.")]
		[Export ("didReceiveRemoteNotification:withCompletion:")]
		void DidReceiveRemoteNotification (NSDictionary remoteNotification, Action<WKUserNotificationInterfaceType> completionHandler);

		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'DidReceiveNotification' instead.")]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'DidReceiveNotification' instead.")]
		[Export ("didReceiveLocalNotification:withCompletion:")]
		void DidReceiveLocalNotification (UILocalNotification localNotification, Action<WKUserNotificationInterfaceType> completionHandler);

		[Introduced (PlatformName.WatchOS, 3, 0)][Introduced (PlatformName.iOS, 10, 0)]
		[Export ("didReceiveNotification:withCompletion:")]
		void DidReceiveNotification (UNNotification notification, Action<WKUserNotificationInterfaceType> completionHandler);

		[Unavailable (PlatformName.iOS)]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use overload accepting an 'UNNotification' parameter.")]
		[Export ("suggestionsForResponseToActionWithIdentifier:forRemoteNotification:inputLanguage:")]
		string[] GetSuggestionsForResponseToAction (string identifier, NSDictionary remoteNotification, string inputLanguage);

		[Unavailable (PlatformName.iOS)]
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use overload accepting an 'UNNotification' parameter.")]
		[Export ("suggestionsForResponseToActionWithIdentifier:forLocalNotification:inputLanguage:")]
		string[] GetSuggestionsForResponseToAction (string identifier, UILocalNotification localNotification, string inputLanguage);

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("suggestionsForResponseToActionWithIdentifier:forNotification:inputLanguage:")]
		string[] GetSuggestionsForResponseToAction (string identifier, UNNotification notification, string inputLanguage);
	}
	
	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	// just like we inlined UIAccessibility into UIViewm UIImage and UIBarItem instead of stuffing it all into NSObject
	interface WKInterfaceObject : UIAccessibility {
		[Export ("interfaceProperty")]
		string InterfaceProperty { get; }

		[Export ("setHidden:")]
		void SetHidden (bool hidden);

		[Export ("setAlpha:")]
		void SetAlpha (nfloat alpha);

		[Export ("setWidth:")]
		void SetWidth (nfloat width);

		[Export ("setHeight:")]
		void SetHeight (nfloat height);

		[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
		[Export ("setSemanticContentAttribute:")]
		void SetSemanticContentAttribute (WKInterfaceSemanticContentAttribute semanticContentAttribute);

#if WATCH
		[Unavailable (PlatformName.iOS)]
		[Export ("setHorizontalAlignment:")]
		void SetHorizontalAlignment (WKInterfaceObjectHorizontalAlignment horizontalAlignment);

		[Unavailable (PlatformName.iOS)]
		[Export ("setVerticalAlignment:")]
		void SetVerticalAlignment (WKInterfaceObjectVerticalAlignment verticalAlignment);
#endif

		[Unavailable (PlatformName.iOS)]
		[Export ("setRelativeWidth:withAdjustment:")]
		void SetRelativeWidth (nfloat width, nfloat adjustment);

		[Unavailable (PlatformName.iOS)]
		[Export ("setRelativeHeight:withAdjustment:")]
		void SetRelativeHeight (nfloat height, nfloat adjustment);

		[Unavailable (PlatformName.iOS)]
		[Export ("sizeToFitWidth")]
		void SizeToFitWidth ();

		[Unavailable (PlatformName.iOS)]
		[Export ("sizeToFitHeight")]
		void SizeToFitHeight ();
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[Category]
	[BaseType (typeof (WKInterfaceObject))]
	interface WKAccessibility {
		[Export ("setAccessibilityLabel:")]
		void SetAccessibilityLabel ([NullAllowed] string accessibilityLabel);

		[Export ("setAccessibilityHint:")]
		void SetAccessibilityHint ([NullAllowed] string accessibilityHint);

		[Export ("setAccessibilityValue:")]
		void SetAccessibilityValue ([NullAllowed] string accessibilityValue);

		[Export ("setAccessibilityImageRegions:")]
		void SetAccessibilityImageRegions (WKAccessibilityImageRegion[] accessibilityImageRegions);

		[Export ("setAccessibilityTraits:")]
		void SetAccessibilityTraits (UIAccessibilityTrait accessibilityTraits);

		[Export ("setIsAccessibilityElement:")]
		void SetIsAccessibilityElement (bool isAccessibilityElement);

		[Export ("setAccessibilityIdentifier:")]
		void SetAccessibilityIdentifier ([NullAllowed] string accessibilityIdentifier);

		[Introduced (PlatformName.WatchOS, 2, 0)][Unavailable (PlatformName.iOS)]
		[Notification]
		[Field ("WKAccessibilityVoiceOverStatusChanged")]
		NSString VoiceOverStatusChanged { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Notification]
		[Field ("WKAccessibilityReduceMotionStatusDidChangeNotification")]
		NSString ReduceMotionStatusDidChangeNotification { get; }
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // does not make sense to create, it should only be used thru the singleton
	interface WKInterfaceDevice {
		[Export ("screenBounds")]
		CGRect ScreenBounds { get; }

		[Export ("screenScale")]
		nfloat ScreenScale { get; }

		[Unavailable (PlatformName.WatchOS)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("cachedImages")]
		NSDictionary WeakCachedImages { get; }

		[Internal]
		[Export ("preferredContentSizeCategory")]
		NSString _PreferredContentSizeCategory { get; }

		[Static, Export ("currentDevice")]
		WKInterfaceDevice CurrentDevice { get; }

		[Unavailable (PlatformName.WatchOS)]
		[Export ("addCachedImage:name:")]
		bool AddCachedImage (UIImage image, string name);

		[Unavailable (PlatformName.WatchOS)]
		[Export ("addCachedImageWithData:name:")]
		bool AddCachedImage (NSData imageData, string name);

		[Unavailable (PlatformName.WatchOS)]
		[Export ("removeCachedImageWithName:")]
		void RemoveCachedImage (string name);

		[Unavailable (PlatformName.WatchOS)]
		[Export ("removeAllCachedImages")]
		void RemoveAllCachedImages ();

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("systemVersion")]
		string SystemVersion { get; }

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("name")]
		string Name { get; }

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("model")]
		string Model { get; }

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("localizedModel")]
		string LocalizedModel { get; }

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.WatchOS, 2, 0)]
		[Export ("systemName")]
		string SystemName { get; }

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("waterResistanceRating")]
		WKWaterResistanceRating WaterResistanceRating { get; }

		[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
		[Export ("playHaptic:")]
		void PlayHaptic (WKHapticType type);

		[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
		[Export ("layoutDirection")]
		WKInterfaceLayoutDirection LayoutDirection { get; }

		[Introduced (PlatformName.WatchOS, 2, 1), Unavailable (PlatformName.iOS)]
		[Static]
		[Export ("interfaceLayoutDirectionForSemanticContentAttribute:")]
		WKInterfaceLayoutDirection GetInterfaceLayoutDirection (WKInterfaceSemanticContentAttribute semanticContentAttribute);

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("wristLocation")]
		WKInterfaceDeviceWristLocation WristLocation { get; }

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("crownOrientation")]
		WKInterfaceDeviceCrownOrientation CrownOrientation { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("batteryMonitoringEnabled")]
		bool BatteryMonitoringEnabled { [Bind ("isBatteryMonitoringEnabled")] get; set; }

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("batteryLevel")]
		float BatteryLevel { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)][Unavailable (PlatformName.iOS)]
		[Export ("batteryState")]
		WKInterfaceDeviceBatteryState BatteryState { get; }
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceButton {
		[Export ("setTitle:")]
		void SetTitle ([NullAllowed] string title);

		[Export ("setAttributedTitle:")]
		void SetTitle ([NullAllowed] NSAttributedString attributedTitle);

		[Export ("setBackgroundColor:")]
		void SetBackgroundColor ([NullAllowed] UIColor color);

		[Export ("setBackgroundImage:")]
		void SetBackgroundImage ([NullAllowed] UIImage image);

		[Export ("setBackgroundImageData:")]
		void SetBackgroundImage ([NullAllowed] NSData imageData);

		[Export ("setBackgroundImageNamed:")]
		void SetBackgroundImage ([NullAllowed] string imageName);

		[Export ("setEnabled:")]
		void SetEnabled (bool enabled);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceGroup : WKImageAnimatable {
		[Export ("setBackgroundColor:")]
		void SetBackgroundColor ([NullAllowed] UIColor color);

		[Export ("setBackgroundImage:")]
		void SetBackgroundImage ([NullAllowed] UIImage image);

		[Export ("setBackgroundImageData:")]
		void SetBackgroundImage ([NullAllowed] NSData imageData);

		[Export ("setBackgroundImageNamed:")]
		void SetBackgroundImage ([NullAllowed] string imageName);

		[Export ("setCornerRadius:")]
		void SetCornerRadius (nfloat cornerRadius);

		[Unavailable (PlatformName.iOS)]
		[Export ("setContentInset:")]
		void SetContentInset (UIEdgeInsets contentInset);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceImage : WKImageAnimatable {
		[Export ("setImage:")]
		void SetImage ([NullAllowed] UIImage image);

		[Export ("setImageData:")]
		void SetImage ([NullAllowed] NSData imageData);

		[Export ("setImageNamed:")]
		void SetImage ([NullAllowed] string imageName);

		[Export ("setTintColor:")]
		void SetTintColor ([NullAllowed] UIColor color);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceLabel {

		[Export ("setText:")]
		void SetText ([NullAllowed] string text);

		[Export ("setTextColor:")]
		void SetTextColor ([NullAllowed] UIColor color);

		[Export ("setAttributedText:")]
		void SetText ([NullAllowed] NSAttributedString attributedText);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceDate {
		[Export ("setTextColor:")]
		void SetTextColor ([NullAllowed] UIColor color);

		[Export ("setTimeZone:")]
		void SetTimeZone ([NullAllowed] NSTimeZone timeZone);

		[Export ("setCalendar:")]
		void SetCalendar ([NullAllowed] NSCalendar calendar);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceTimer {

		[Export ("setTextColor:")]
		void SetTextColor ([NullAllowed] UIColor color);

		[Export ("setDate:")]
		void SetDate (NSDate date);

		[Export ("start")]
		void Start ();

		[Export ("stop")]
		void Stop ();
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceTable {
		[Export ("numberOfRows")]
		nint NumberOfRows { get; }

		[Export ("setRowTypes:")]
		void SetRowTypes (string [] rowTypes);

		[Export ("setNumberOfRows:withRowType:")]
		void SetNumberOfRows (nint numberOfRows, string rowType);

		[Export ("rowControllerAtIndex:")]
		NSObject GetRowController (nint index);

		[Export ("insertRowsAtIndexes:withRowType:")]
		void InsertRows (NSIndexSet rowIndexes, string rowType);

		[Export ("removeRowsAtIndexes:")]
		void RemoveRows (NSIndexSet rowIndexes);

		[Export ("scrollToRowAtIndex:")]
		void ScrollToRow (nint index);

		[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
		[Export ("performSegueForRow:")]
		void PerformSegue (nint row);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceMap {

		[Export ("addAnnotation:withImage:centerOffset:")]
		void AddAnnotation (CLLocationCoordinate2D location, [NullAllowed] UIImage image, CGPoint offset);

		[Export ("addAnnotation:withImageNamed:centerOffset:")]
		void AddAnnotation (CLLocationCoordinate2D location, [NullAllowed] string name, CGPoint offset);

		[Export ("addAnnotation:withPinColor:")]
		void AddAnnotation (CLLocationCoordinate2D location, WKInterfaceMapPinColor pinColor);

		[Export ("setRegion:")]
		void SetRegion (MKCoordinateRegion coordinateRegion);

		[Export ("setVisibleMapRect:")]
		void SetVisible (MKMapRect mapRect);

		[Export ("removeAllAnnotations")]
		void RemoveAllAnnotations ();
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceSeparator {
		[Export ("setColor:")]
		void SetColor ([NullAllowed] UIColor color);
	}
	
	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceSlider {
		[Export ("setEnabled:")]
		void SetEnabled (bool enabled);

		[Export ("setValue:")]
		void SetValue (float value);

		[Export ("setColor:")]
		void SetColor ([NullAllowed] UIColor color);

		[Export ("setNumberOfSteps:")]
		void SetNumberOfSteps (nint numberOfSteps);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	[BaseType (typeof (WKInterfaceObject))]
	interface WKInterfaceSwitch {

		[Export ("setColor:")]
		void SetColor ([NullAllowed] UIColor color);

		[Export ("setEnabled:")]
		void SetEnabled (bool enabled);

		[Export ("setOn:")]
		void SetOn (bool on);

		[Export ("setTitle:")]
		void SetTitle ([NullAllowed] string title);

		[Export ("setAttributedTitle:")]
		void SetTitle ([NullAllowed] NSAttributedString attributedTitle);
	}

	[Introduced (PlatformName.iOS, 8, 2)]
	[BaseType (typeof (NSObject))]
	interface WKAccessibilityImageRegion {

		[Export ("frame")]
		CGRect Frame { get; set; }

		[NullAllowed]
		[Export ("label")]
		string Label { get; set; }
	}

	interface IWKImageAnimatable {}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Protocol]
	interface WKImageAnimatable {
		[Introduced (PlatformName.iOS, 8, 2)]
		[Abstract]
		[Export ("startAnimating")]
		void StartAnimating ();

		[Introduced (PlatformName.iOS, 8, 2)]
		[Abstract]
		[Export ("startAnimatingWithImagesInRange:duration:repeatCount:")]
		void StartAnimating (NSRange imageRange, double duration, nint repeatCount);

		[Introduced (PlatformName.iOS, 8, 2)]
		[Abstract]
		[Export ("stopAnimating")]
		void StopAnimating ();
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKImage : NSCopying, NSSecureCoding {
		[Static]
		[Export ("imageWithImage:")]
		WKImage CreateFromImage (UIImage image);

		[Static]
		[Export ("imageWithImageData:")]
		WKImage CreateFromData (NSData imageData);

		[Static]
		[Export ("imageWithImageName:")]
		WKImage CreateFromName (string imageName);

		[NullAllowed, Export ("image")]
		UIImage Image { get; }

		[NullAllowed, Export ("imageData")]
		NSData ImageData { get; }

		[NullAllowed, Export ("imageName")]
		string ImageName { get; }
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKAlertAction {
		[Static]
		[Export ("actionWithTitle:style:handler:")]
		WKAlertAction Create (string title, WKAlertActionStyle style, Action handler);
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKAudioFileAsset {
		[Static]
		[Export ("assetWithURL:")]
		WKAudioFileAsset Create (NSUrl url);

		[Static]
		[Export ("assetWithURL:title:albumTitle:artist:")]
		WKAudioFileAsset Create (NSUrl url, [NullAllowed] string title, [NullAllowed] string albumTitle, [NullAllowed] string artist);

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("duration")]
		double Duration { get; }

		[NullAllowed, Export ("title")]
		string Title { get; }

		[NullAllowed, Export ("albumTitle")]
		string AlbumTitle { get; }

		[NullAllowed, Export ("artist")]
		string Artist { get; }
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKAudioFilePlayer {
		[Static]
		[Export ("playerWithPlayerItem:")]
		WKAudioFilePlayer Create (WKAudioFilePlayerItem item);

		[Export ("play")]
		void Play ();

		[Export ("pause")]
		void Pause ();

		[Export ("replaceCurrentItemWithPlayerItem:")]
		void ReplaceCurrentItem ([NullAllowed] WKAudioFilePlayerItem item);

		[NullAllowed, Export ("currentItem")]
		WKAudioFilePlayerItem CurrentItem { get; }

		[Export ("status")]
		WKAudioFilePlayerStatus Status { get; }

		[NullAllowed, Export ("error")]
		NSError Error { get; }

		[Export ("rate")]
		float Rate { get; set; }

		[Export ("currentTime")]
		double CurrentTime { get; }
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKAudioFilePlayerItem {
		[Static]
		[Export ("playerItemWithAsset:")]
		WKAudioFilePlayerItem Create (WKAudioFileAsset asset);

		[Export ("asset")]
		WKAudioFileAsset Asset { get; }

		[Export ("status")]
		WKAudioFilePlayerItemStatus Status { get; }

		[NullAllowed, Export ("error")]
		NSError Error { get; }

		[Export ("currentTime")]
		double CurrentTime {
			get;
#if XAMCORE_4_0
			[Introduced (PlatformName.WatchOS, 3, 2)]
			set;
		}
#else
		}
		[Introduced (PlatformName.WatchOS, 3, 2)]
		[Export ("setCurrentTime:")]
		void SetCurrentTime (double time);
#endif

		[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
		[Notification]
		[Field ("WKAudioFilePlayerItemTimeJumpedNotification")]
		NSString TimeJumpedNotification { get; }

		[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
		[Notification]
		[Field ("WKAudioFilePlayerItemDidPlayToEndTimeNotification")]
		NSString DidPlayToEndTimeNotification { get; }

		[Introduced (PlatformName.WatchOS, 2, 0), Unavailable (PlatformName.iOS)]
		[Notification]
		[Field ("WKAudioFilePlayerItemFailedToPlayToEndTimeNotification")]
		NSString FailedToPlayToEndTimeNotification { get; }
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	interface WKExtension {
		[Static]
		[Export ("sharedExtension")]
		WKExtension SharedExtension { get; }

		[Export ("openSystemURL:")]
		void OpenSystemUrl (NSUrl url);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		[Protocolize]
		WKExtensionDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[NullAllowed, Export ("rootInterfaceController")]
		WKInterfaceController RootInterfaceController { get; }

		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Export ("applicationState")]
		WKApplicationState ApplicationState { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[NullAllowed, Export ("visibleInterfaceController")]
		WKInterfaceController VisibleInterfaceController { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("isApplicationRunningInDock")]
		bool IsApplicationRunningInDock { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("autorotating")]
		bool Autorotating { [Bind ("isAutorotating")] get; set; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("frontmostTimeoutExtended")]
		bool FrontmostTimeoutExtended { [Bind ("isFrontmostTimeoutExtended")] get; set; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("enableWaterLock")]
		void EnableWaterLock ();
	}

	[Unavailable (PlatformName.iOS)]
	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface WKExtensionDelegate {
		[Export ("applicationDidFinishLaunching")]
		void ApplicationDidFinishLaunching ();

		[Export ("applicationDidBecomeActive")]
		void ApplicationDidBecomeActive ();

		[Export ("applicationWillResignActive")]
		void ApplicationWillResignActive ();

		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Export ("applicationWillEnterForeground")]
		void ApplicationWillEnterForeground ();

		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Export ("applicationDidEnterBackground")]
		void ApplicationDidEnterBackground ();

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("handleActionWithIdentifier:forRemoteNotification:")]
		void HandleAction ([NullAllowed] string identifier, NSDictionary remoteNotification);

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("handleActionWithIdentifier:forLocalNotification:")]
		void HandleAction ([NullAllowed] string identifier, UILocalNotification localNotification);

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("handleActionWithIdentifier:forRemoteNotification:withResponseInfo:")]
		void HandleAction ([NullAllowed] string identifier, NSDictionary remoteNotification, NSDictionary responseInfo);

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("handleActionWithIdentifier:forLocalNotification:withResponseInfo:")]
		void HandleAction ([NullAllowed] string identifier, UILocalNotification localNotification, NSDictionary responseInfo);

		[Export ("handleUserActivity:")]
		void HandleUserActivity ([NullAllowed] NSDictionary userInfo);

		[Introduced (PlatformName.WatchOS, 3, 2)] // TODO: Check if this is equal/similar to HandleUserActivity once docs are available
		[Export ("handleActivity:")]
		void HandleUserActivity (NSUserActivity userActivity);

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("didReceiveRemoteNotification:")]
		void DidReceiveRemoteNotification (NSDictionary userInfo);

		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use UNUserNotificationCenterDelegate")]
		[Export ("didReceiveLocalNotification:")]
		void DidReceiveLocalNotification (UILocalNotification notification);

		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Export ("handleBackgroundTasks:")]
		void HandleBackgroundTasks (NSSet<WKRefreshBackgroundTask> backgroundTasks);

		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Export ("handleWorkoutConfiguration:")]
		void HandleWorkoutConfiguration (HKWorkoutConfiguration workoutConfiguration);

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("deviceOrientationDidChange")]
		void DeviceOrientationDidChange ();
	}

	[Introduced (PlatformName.WatchOS, 2, 2), Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // The super class' init method is unavailable.
	interface WKInterfaceActivityRing
	{
		[Export ("setActivitySummary:animated:")]
		void SetActivitySummary ([NullAllowed] HKActivitySummary activitySummary, bool animated);
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // The super class' init method is unavailable.
	interface WKInterfaceMovie {
		[Export ("setMovieURL:")]
		void SetMovieUrl (NSUrl url);

		[Export ("setVideoGravity:")]
		void SetVideoGravity (WKVideoGravity videoGravity);

		[Export ("setLoops:")]
		void SetLoops (bool loops);

		[Export ("setPosterImage:")]
		void SetPosterImage ([NullAllowed] WKImage posterImage);
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // The super class' init method is unavailable.
	interface WKInterfacePicker {
		[Export ("focus")]
		void Focus ();

		[Export ("resignFocus")]
		void ResignFocus ();

		[Export ("setSelectedItemIndex:")]
		void SetSelectedItem (nint itemIndex);

		[Export ("setItems:")]
		void SetItems ([NullAllowed] WKPickerItem[] items);

		[Export ("setCoordinatedAnimations:")]
		void SetCoordinatedAnimations ([NullAllowed] IWKImageAnimatable [] coordinatedAnimations);

		[Export ("setEnabled:")]
		void SetEnabled (bool enabled);
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	interface WKPickerItem : NSSecureCoding {
		[NullAllowed, Export ("title")]
		string Title { get; set; }

		[NullAllowed, Export ("caption")]
		string Caption { get; set; }

		[NullAllowed, Export ("accessoryImage", ArgumentSemantic.Copy)]
		WKImage AccessoryImage { get; set; }

		[NullAllowed, Export ("contentImage", ArgumentSemantic.Copy)]
		WKImage ContentImage { get; set; }
	}

	[Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKAudioFilePlayer))]
	[DisableDefaultCtor]
	interface WKAudioFileQueuePlayer {
		[Static]
		[Export ("queuePlayerWithItems:")]
		WKAudioFileQueuePlayer FromItems (WKAudioFilePlayerItem[] items);

		[Export ("advanceToNextItem")]
		void AdvanceToNextItem ();

		[Export ("appendItem:")]
		void AppendItem (WKAudioFilePlayerItem item);

		[Export ("removeItem:")]
		void RemoveItem (WKAudioFilePlayerItem item);

		[Export ("removeAllItems")]
		void RemoveAllItems ();

		[Export ("items")]
		WKAudioFilePlayerItem[] Items { get; }
	}

	// to be made [Internal] once #34656 is fixed
	[Static]
	[Introduced (PlatformName.WatchOS, 2, 0)][Unavailable (PlatformName.iOS)]
	interface WKMediaPlayerControllerOptionsKeys {
		[Field ("WKMediaPlayerControllerOptionsAutoplayKey")]
		NSString AutoplayKey { get; }

		[Field ("WKMediaPlayerControllerOptionsStartTimeKey")]
		NSString StartTimeKey { get; }

		[Field ("WKMediaPlayerControllerOptionsVideoGravityKey")]
		NSString VideoGravityKey { get; }

		[Field ("WKMediaPlayerControllerOptionsLoopsKey")]
		NSString LoopsKey { get; }
	}

	// to be made [Internal] once #34656 is fixed
	[Static]
	[Introduced (PlatformName.WatchOS, 2, 0)][Unavailable (PlatformName.iOS)]
	interface WKAudioRecorderControllerOptionsKey {
		[Field ("WKAudioRecorderControllerOptionsActionTitleKey")]
		NSString ActionTitleKey { get; }

		[Field ("WKAudioRecorderControllerOptionsAlwaysShowActionTitleKey")]
		NSString AlwaysShowActionTitleKey { get; }

		[Field ("WKAudioRecorderControllerOptionsAutorecordKey")]
		NSString AutorecordKey { get; }

		[Field ("WKAudioRecorderControllerOptionsMaximumDurationKey")]
		NSString MaximumDurationKey { get; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	interface WKRefreshBackgroundTask {
		
		[NullAllowed, Export ("userInfo")]
		INSSecureCoding UserInfo { get; }

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'SetTaskCompleted (false)' instead.")]
		[Export ("setTaskCompleted")]
		void SetTaskCompleted ();

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("setTaskCompletedWithSnapshot:")]
		void SetTaskCompleted (bool refreshSnapshot);
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKRefreshBackgroundTask))]
	interface WKApplicationRefreshBackgroundTask {
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKRefreshBackgroundTask))]
	interface WKSnapshotRefreshBackgroundTask {

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'ReasonForSnapshot' instead.")]
		[Export ("returnToDefaultState")]
		bool ReturnToDefaultState { get; }

		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("reasonForSnapshot")]
		WKSnapshotReason ReasonForSnapshot { get; }

		[Export ("setTaskCompletedWithDefaultStateRestored:estimatedSnapshotExpiration:userInfo:")]
		void SetTaskCompleted (bool restoredDefaultState, [NullAllowed] NSDate estimatedSnapshotExpiration, [NullAllowed] INSSecureCoding userInfo);
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKRefreshBackgroundTask), Name = "WKURLSessionRefreshBackgroundTask")]
	interface WKUrlSessionRefreshBackgroundTask {

		[Export ("sessionIdentifier")]
		string SessionIdentifier { get; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKRefreshBackgroundTask))]
	interface WKWatchConnectivityRefreshBackgroundTask {
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Category]
	[BaseType (typeof (WKExtension))]
	interface WKExtension_WKBackgroundTasks {

		[Export ("scheduleBackgroundRefreshWithPreferredDate:userInfo:scheduledCompletion:")]
		void ScheduleBackgroundRefresh (NSDate preferredFireDate, [NullAllowed] INSSecureCoding userInfo, Action<NSError> scheduledCompletion);

		[Export ("scheduleSnapshotRefreshWithPreferredDate:userInfo:scheduledCompletion:")]
		void ScheduleSnapshotRefresh (NSDate preferredFireDate, [NullAllowed] INSSecureCoding userInfo, Action<NSError> scheduledCompletion);
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WKCrownSequencer {

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IWKCrownDelegate Delegate { get; set; }

		[Export ("rotationsPerSecond")]
		double RotationsPerSecond { get; }

		[Export ("idle")]
		bool Idle { [Bind ("isIdle")] get; }

		[Export ("focus")]
		void Focus ();

		[Export ("resignFocus")]
		void ResignFocus ();
	}

	interface IWKCrownDelegate {}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Protocol][Model]
	[BaseType (typeof (NSObject))]
	interface WKCrownDelegate {
		[Export ("crownDidRotate:rotationalDelta:")]
		void CrownDidRotate ([NullAllowed] WKCrownSequencer crownSequencer, double rotationalDelta);

		[Export ("crownDidBecomeIdle:")]
		void CrownDidBecomeIdle ([NullAllowed] WKCrownSequencer crownSequencer);
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[Abstract]
	[BaseType (typeof (NSObject))]
	interface WKGestureRecognizer {

		[Export ("state")]
		WKGestureRecognizerState State { get; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("locationInObject")]
		CGPoint LocationInObject { get; }

		[Export ("objectBounds")]
		CGRect ObjectBounds { get; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKGestureRecognizer))]
	interface WKTapGestureRecognizer {

		[Export ("numberOfTapsRequired")]
		nuint NumberOfTapsRequired { get; set; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKGestureRecognizer))]
	interface WKLongPressGestureRecognizer {

		[Export ("minimumPressDuration")]
		double MinimumPressDuration { get; set; }

		[Export ("numberOfTapsRequired")]
		nuint NumberOfTapsRequired { get; set; }

		[Export ("allowableMovement")]
		nfloat AllowableMovement { get; set; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKGestureRecognizer))]
	interface WKSwipeGestureRecognizer {

		[Export ("direction", ArgumentSemantic.Assign)]
		WKSwipeGestureRecognizerDirection Direction { get; set; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKGestureRecognizer))]
	interface WKPanGestureRecognizer {
		[Export ("translationInObject")]
		CGPoint TranslationInObject { get; }

		[Export ("velocityInObject")]
		CGPoint VelocityInObject { get; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceHMCamera {

		[Export ("setCameraSource:")]
		void SetCameraSource ([NullAllowed] HMCameraSource cameraSource);
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceInlineMovie {

		[Export ("setMovieURL:")]
		void SetMovieUrl (NSUrl url);

		[Export ("setVideoGravity:")]
		void SetVideoGravity (WKVideoGravity videoGravity);

		[Export ("setLoops:")]
		void SetLoops (bool loops);

		[Export ("setAutoplays:")]
		void SetAutoplays (bool autoplays);

		[Export ("setPosterImage:")]
		void SetPosterImage ([NullAllowed] WKImage posterImage);

		[Export ("play")]
		void Play ();

		[Export ("playFromBeginning")]
		void PlayFromBeginning ();

		[Export ("pause")]
		void Pause ();
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfacePaymentButton {
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceSCNScene : SCNSceneRenderer {

		[Export ("snapshot")]
		UIImage GetSnapshot ();

		[Export ("preferredFramesPerSecond")]
		nint PreferredFramesPerSecond { get; set; }

		[Export ("antialiasingMode", ArgumentSemantic.Assign)]
		SCNAntialiasingMode AntialiasingMode { get; set; }
	}

	[Introduced (PlatformName.WatchOS, 3, 0)][Unavailable (PlatformName.iOS)]
	[BaseType (typeof (WKInterfaceObject))]
	[DisableDefaultCtor] // Do not subclass or create instances of this class yourself. -> Handle is nil if init is called
	interface WKInterfaceSKScene {

		[Export ("paused")]
		bool Paused { [Bind ("isPaused")] get; set; }

		[Export ("preferredFramesPerSecond")]
		nint PreferredFramesPerSecond { get; set; }

		[Export ("presentScene:")]
		void PresentScene ([NullAllowed] SKScene scene);

		[Export ("presentScene:transition:")]
		void PresentScene (SKScene scene, SKTransition transition);

		[NullAllowed, Export ("scene")]
		SKScene Scene { get; }

		[Export ("textureFromNode:")]
		[return: NullAllowed]
		SKTexture CreateTexture (SKNode node);

		[Export ("textureFromNode:crop:")]
		[return: NullAllowed]
		SKTexture CreateTexture (SKNode node, CGRect crop);
	}
}

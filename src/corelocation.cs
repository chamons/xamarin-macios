
// This file describes the API that the generator will produce
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//   Aaron Bockover
//
// Copyright 2009, Novell, Inc.
// Copyright 2011, 2013, 2015 Xamarin Inc.
//
using ObjCRuntime;
using Foundation;
using CoreGraphics;
using CoreLocation;
#if !MONOMAC
using UIKit;
#endif
#if XAMCORE_2_0 && !TVOS
using Contacts;
#endif
using System;

namespace CoreLocation {

	[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native] // NSInteger -> CLRegion.h
	public enum CLRegionState : long {
		Unknown,
		Inside,
		Outside
	}

	[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.WatchOS)]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Native] // NSInteger -> CLRegion.h
	public enum CLProximity : long {
		Unknown,
		Immediate,
		Near,
		Far
	}

	[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // will crash, see CoreLocation.cs for compatibility stubs
	[Introduced (PlatformName.MacOSX, 10, 7)]
	partial interface CLHeading : NSSecureCoding, NSCopying {
		[Export ("magneticHeading")]
		double MagneticHeading { get;  }
	
		[Export ("trueHeading")]
		double TrueHeading { get;  }
	
		[Export ("headingAccuracy")]
		double HeadingAccuracy { get;  }
	
		[Export ("x")]
		double X { get;  }
	
		[Export ("y")]
		double Y { get;  }
	
		[Export ("z")]
		double Z { get;  }

		[Export ("timestamp", ArgumentSemantic.Copy)]
		NSDate Timestamp { get;  }
	}
	
	[BaseType (typeof (NSObject))]
	partial interface CLLocation : NSSecureCoding, NSCopying {
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get;  }
	
		[Export ("altitude")]
		double Altitude { get;  }
	
		[Export ("horizontalAccuracy")]
		double HorizontalAccuracy { get;  }
	
		[Export ("verticalAccuracy")]
		double VerticalAccuracy { get;  }
	
		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.WatchOS, 3, 0)] // __WATCHOS_PROHIBITED removed in Xcode 8 beta 3
		[Export ("course")]
		double Course { get;  }
	
		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.WatchOS, 3, 0)] // __WATCHOS_PROHIBITED removed in Xcode 8 beta 3
		[Export ("speed")]
		double Speed { get;  }

		[Export ("timestamp", ArgumentSemantic.Copy)]
		NSDate Timestamp { get;  }
	
		[Export ("initWithLatitude:longitude:")]
		IntPtr Constructor (double latitude, double longitude);
	
		[Export ("initWithCoordinate:altitude:horizontalAccuracy:verticalAccuracy:timestamp:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate, double altitude, double hAccuracy, double vAccuracy, NSDate timestamp);

#if !XAMCORE_2_0
		[Export ("getDistanceFrom:")]
		[Deprecated (PlatformName.iOS, 3, 2, message: "Use 'DistanceFrom' instead.")]
		double Distancefrom (CLLocation  location);
#endif

		[Introduced (PlatformName.iOS, 3, 2)]
		[Export ("distanceFromLocation:")]
		double DistanceFrom (CLLocation location);

		[Introduced (PlatformName.iOS, 4, 2)]
		[Export ("initWithCoordinate:altitude:horizontalAccuracy:verticalAccuracy:course:speed:timestamp:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate, double altitude, double hAccuracy, double vAccuracy, double course, double speed, NSDate timestamp);

		// Apple keep changing the 'introduction' of this field (5.0->8.0->5.0) but it was not available in 6.1
		// nor in 7.0 - but it works on my iPad3 running iOS 7.1
		[Unavailable (PlatformName.TvOS)][Unavailable (PlatformName.WatchOS)]
		[Introduced (PlatformName.iOS, 7, 1)][Introduced (PlatformName.MacOSX, 10, 8)]
		[Field ("kCLErrorUserInfoAlternateRegionKey")]
		NSString ErrorUserInfoAlternateRegionKey { get; }

#if XAMCORE_2_0
		[Field ("kCLLocationAccuracyBestForNavigation")]
		double AccurracyBestForNavigation { get; }

		[Field ("kCLLocationAccuracyBest")]
		double AccuracyBest { get; }

		[Field ("kCLLocationAccuracyNearestTenMeters")]
		double AccuracyNearestTenMeters { get; }

		[Field ("kCLLocationAccuracyHundredMeters")]
		double AccuracyHundredMeters { get; }

		[Field ("kCLLocationAccuracyKilometer")]
		double AccuracyKilometer { get; }

		[Field ("kCLLocationAccuracyThreeKilometers")]
		double AccuracyThreeKilometers { get; }
#endif

#if !MONOMAC
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("floor", ArgumentSemantic.Copy)]
		CLFloor Floor { get; }
#endif        
	}

#if !MONOMAC
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (NSObject))]
	partial interface CLFloor : NSSecureCoding, NSCopying {
	        [Export ("level")]
	        nint Level { get; }
    }
#endif

	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] {typeof (CLLocationManagerDelegate)})]
	partial interface CLLocationManager {
		[Wrap ("WeakDelegate")]
		[Protocolize]
		CLLocationManagerDelegate Delegate { get; set;  }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set;  }
	
		[Export ("distanceFilter", ArgumentSemantic.Assign)]
		double DistanceFilter { get; set;  }
	
		[Export ("desiredAccuracy", ArgumentSemantic.Assign)]
		double DesiredAccuracy { get; set;  }
	
		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get;  }
	
		 // __WATCHOS_PROHIBITED removed in Xcode 8.0 beta 2, assuming it's valid for 3.0+
		[Introduced (PlatformName.WatchOS, 3, 0)]
		[Unavailable (PlatformName.TvOS)]
		[Export ("startUpdatingLocation")]
		void StartUpdatingLocation ();
	
		[Export ("stopUpdatingLocation")]
		void StopUpdatingLocation ();

		[Introduced (PlatformName.iOS, 4, 0)]
		[Export ("locationServicesEnabled"), Static]
		bool LocationServicesEnabled { get; }

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("headingFilter", ArgumentSemantic.Assign)]
		double HeadingFilter { get; set;  }
	
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("startUpdatingHeading")]
		void StartUpdatingHeading ();
	
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("stopUpdatingHeading")]
		void StopUpdatingHeading ();
	
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("dismissHeadingCalibrationDisplay")]
		void DismissHeadingCalibrationDisplay ();
#endif
	
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 3, 2)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Introduced (PlatformName.iOS, 3, 2), Deprecated (PlatformName.iOS, 6, 0)]
		// Default property value is null but it cannot be set to that value
		// it crash when a null is provided
		[Export ("purpose")]
		string Purpose { get; set; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Export ("headingAvailable"), Static]
		bool HeadingAvailable { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Export ("significantLocationChangeMonitoringAvailable"), Static]
		bool SignificantLocationChangeMonitoringAvailable { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0, message: "Use 'IsMonitoringAvailable' instead."), Introduced (PlatformName.MacOSX, 10, 8, message: "Use 'IsMonitoringAvailable' instead."), Deprecated (PlatformName.iOS, 7, 0, message: "Use 'IsMonitoringAvailable' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'IsMonitoringAvailable' instead.")]
		[Export ("regionMonitoringAvailable"), Static]
		bool RegionMonitoringAvailable { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.iOS, 4, 0, message: "Use 'IsMonitoringAvailable' and 'AuthorizationStatus' instead."), Introduced (PlatformName.MacOSX, 10, 8, message: "Use 'IsMonitoringAvailable' and 'AuthorizationStatus' instead."), Deprecated (PlatformName.iOS, 6, 0, message: "Use 'IsMonitoringAvailable' and 'AuthorizationStatus' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'IsMonitoringAvailable' and 'AuthorizationStatus' instead.")]
		[Export ("regionMonitoringEnabled"), Static]
		bool RegionMonitoringEnabled { get; }

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Export ("headingOrientation", ArgumentSemantic.Assign)]
		CLDeviceOrientation HeadingOrientation { get; set; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("heading", ArgumentSemantic.Copy)]
		[Introduced (PlatformName.iOS, 4, 0)]
		CLHeading Heading { get; }
#endif

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("maximumRegionMonitoringDistance")]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		double MaximumRegionMonitoringDistance { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("monitoredRegions", ArgumentSemantic.Copy)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		NSSet MonitoredRegions { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Export ("startMonitoringSignificantLocationChanges")]
		void StartMonitoringSignificantLocationChanges ();

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Export ("stopMonitoringSignificantLocationChanges")]
		void StopMonitoringSignificantLocationChanges ();

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.iOS, 4, 0), Deprecated (PlatformName.iOS, 6, 0)]
		[Export ("startMonitoringForRegion:desiredAccuracy:")]
		void StartMonitoring (CLRegion region, double desiredAccuracy);
#endif

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("stopMonitoringForRegion:")]
		void StopMonitoring (CLRegion region);

		[Introduced (PlatformName.iOS, 4, 2)]
		[Introduced (PlatformName.MacOSX, 10, 7)]
		[Export ("authorizationStatus")][Static]
		CLAuthorizationStatus Status { get; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("startMonitoringForRegion:")]
		void StartMonitoring (CLRegion region);

#if !MONOMAC
		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.WatchOS, 4, 0)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("activityType", ArgumentSemantic.Assign)]
		CLActivityType ActivityType  { get; set; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("pausesLocationUpdatesAutomatically", ArgumentSemantic.Assign)]
		bool PausesLocationUpdatesAutomatically { get; set; }

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("allowDeferredLocationUpdatesUntilTraveled:timeout:")]
		void AllowDeferredLocationUpdatesUntil (double distance, double timeout);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("disallowDeferredLocationUpdates")]
		void DisallowDeferredLocationUpdates ();
#endif

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Static]
		[Export ("deferredLocationUpdatesAvailable")]
		bool DeferredLocationUpdatesAvailable { get; }

#if !MONOMAC
		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("CLTimeIntervalMax")]
		double MaxTimeInterval { get; }
#endif

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Introduced (PlatformName.iOS, 7, 0), Static, Export ("isMonitoringAvailableForClass:")]
		bool IsMonitoringAvailable (Class regionClass);

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("rangedRegions", ArgumentSemantic.Copy)]
		NSSet RangedRegions { get; }
#endif

		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("requestStateForRegion:")]
		void RequestState (CLRegion region);

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("startRangingBeaconsInRegion:")]
		void StartRangingBeacons (CLBeaconRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("stopRangingBeaconsInRegion:")]
		void StopRangingBeacons (CLBeaconRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0)]
		[Static]
		[Export ("isRangingAvailable")]
		bool IsRangingAvailable { get; }
		
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("requestWhenInUseAuthorization")]
		void RequestWhenInUseAuthorization ();

		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("requestAlwaysAuthorization")]
		void RequestAlwaysAuthorization ();

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("startMonitoringVisits")]
		void StartMonitoringVisits ();

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("stopMonitoringVisits")]
		void StopMonitoringVisits ();

		[Introduced (PlatformName.iOS, 9, 0)]
		[Export ("requestLocation")]
		void RequestLocation ();

		[Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.WatchOS, 4, 0)]
		[Export ("allowsBackgroundLocationUpdates")]
		bool AllowsBackgroundLocationUpdates { get; set; }

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("showsBackgroundLocationIndicator")]
		bool ShowsBackgroundLocationIndicator { get; set; }
#endif
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface CLLocationManagerDelegate
	{
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Deprecated (PlatformName.iOS, 6, 0)]
		[Export ("locationManager:didUpdateToLocation:fromLocation:"), EventArgs ("CLLocationUpdated")]
		void UpdatedLocation (CLLocationManager  manager, CLLocation newLocation, CLLocation oldLocation);
	
#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("locationManager:didUpdateHeading:"), EventArgs ("CLHeadingUpdated")]
		void UpdatedHeading (CLLocationManager  manager, CLHeading newHeading);
#endif
	
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Export ("locationManagerShouldDisplayHeadingCalibration:"), DelegateName ("CLLocationManagerEventArgs"), DefaultValue (true)]
		bool ShouldDisplayHeadingCalibration (CLLocationManager manager);
	
		[Export ("locationManager:didFailWithError:"), EventArgs ("NSError", true)]
		void Failed (CLLocationManager manager, NSError error);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("locationManager:didEnterRegion:"), EventArgs ("CLRegion")]
		void RegionEntered (CLLocationManager manager, CLRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("locationManager:didExitRegion:"), EventArgs ("CLRegion")]
		void RegionLeft (CLLocationManager manager, CLRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 4, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("locationManager:monitoringDidFailForRegion:withError:"), EventArgs ("CLRegionError")]
		void MonitoringFailed (CLLocationManager manager, CLRegion region, NSError error);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 5, 0)]
		[Introduced (PlatformName.MacOSX, 10, 8)]
		[Export ("locationManager:didStartMonitoringForRegion:"), EventArgs ("CLRegion")]
		void DidStartMonitoringForRegion (CLLocationManager manager, CLRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.MacOSX, 10, 10)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("locationManager:didDetermineState:forRegion:"), EventArgs ("CLRegionStateDetermined")]
		void DidDetermineState (CLLocationManager manager, CLRegionState state, CLRegion region);

#if !MONOMAC
		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("locationManager:didRangeBeacons:inRegion:"), EventArgs ("CLRegionBeaconsRanged")]
		void DidRangeBeacons (CLLocationManager manager, CLBeacon [] beacons, CLBeaconRegion region);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 7, 0), Export ("locationManager:rangingBeaconsDidFailForRegion:withError:"), EventArgs ("CLRegionBeaconsFailed")]
		void RangingBeaconsDidFailForRegion (CLLocationManager manager, CLBeaconRegion region, NSError error);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("locationManager:didVisit:"), EventArgs ("CLVisited")]
		void DidVisit (CLLocationManager manager, CLVisit visit);
#endif

		[Introduced (PlatformName.iOS, 4, 2)]
		[Export ("locationManager:didChangeAuthorizationStatus:"), EventArgs ("CLAuthorizationChanged")]
		void AuthorizationChanged (CLLocationManager manager, CLAuthorizationStatus status);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("locationManager:didUpdateLocations:"), EventArgs ("CLLocationsUpdated")]
		void LocationsUpdated (CLLocationManager manager, CLLocation[] locations);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("locationManagerDidPauseLocationUpdates:"), EventArgs ("")]
		void LocationUpdatesPaused (CLLocationManager manager);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("locationManagerDidResumeLocationUpdates:"), EventArgs ("")]
		void LocationUpdatesResumed (CLLocationManager manager);

		[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("locationManager:didFinishDeferredUpdatesWithError:"), EventArgs ("NSError", true)]
		void DeferredUpdatesFinished (CLLocationManager manager, NSError error);
	}

	[Static]
	partial interface CLLocationDistance {

		[Introduced (PlatformName.iOS, 6, 0)]
		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Field ("CLLocationDistanceMax")]
		double MaxDistance { get; }

		[Field ("kCLDistanceFilterNone")]
		double FilterNone { get; }
	}
		
	[Introduced (PlatformName.iOS, 4, 0)]
	[Introduced (PlatformName.MacOSX, 10, 7)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // will crash, see CoreLocation.cs for compatibility stubs
	partial interface CLRegion : NSSecureCoding, NSCopying {
		[Unavailable (PlatformName.TvOS)]
		[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'CLCircularRegion' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'CLCircularRegion' instead.")]
		[Export ("center")]
		CLLocationCoordinate2D Center { get;  }

		[Unavailable (PlatformName.TvOS)]
		[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'CLCircularRegion' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'CLCircularRegion' instead.")]
		[Export ("radius")]
		double Radius { get;  }

		[Export ("identifier")]
		string Identifier { get;  }

		[Unavailable (PlatformName.TvOS)]
		[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'CLCircularRegion' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'CLCircularRegion' instead.")]
		[Export ("initCircularRegionWithCenter:radius:identifier:")]
		IntPtr Constructor (CLLocationCoordinate2D center, double radius, string identifier);

		[Unavailable (PlatformName.TvOS)]
		[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'CLCircularRegion' instead."), Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'CLCircularRegion' instead.")]
		[Export ("containsCoordinate:")]
		bool Contains (CLLocationCoordinate2D coordinate);

		[Introduced (PlatformName.iOS, 7, 0), Export ("notifyOnEntry", ArgumentSemantic.Assign)]
		[Introduced (PlatformName.MacOSX, 10, 10)]
		bool NotifyOnEntry { get; set; }

		[Introduced (PlatformName.iOS, 7, 0), Export ("notifyOnExit", ArgumentSemantic.Assign)]
		[Introduced (PlatformName.MacOSX, 10, 10)]
		bool NotifyOnExit { get; set; }
	}

	[Introduced (PlatformName.iOS, 5, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // will crash, see CoreLocation.cs for compatibility stubs
	interface CLPlacemark : NSSecureCoding, NSCopying {
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'CLPlacemark' properties to access data.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'CLPlacemark' properties to access data.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'CLPlacemark' properties to access data.")]
		[Export ("addressDictionary", ArgumentSemantic.Copy)]
		NSDictionary AddressDictionary { get; }

		[Export ("administrativeArea")]
		string AdministrativeArea { get; }

		[Export ("subAdministrativeArea")]
		string SubAdministrativeArea { get; }

		[Export ("subLocality")]
		string SubLocality { get; }

		[Export ("locality")]
		string Locality { get; }

		[Export ("country")]
		string Country { get; }
	
		[Export ("postalCode")]
		string PostalCode { get; }

		[Export ("thoroughfare")]
		string Thoroughfare { get; }

		[Export ("subThoroughfare")]
		string SubThoroughfare { get; }

		[Export ("ISOcountryCode")]
		string IsoCountryCode { get;  }

		[Export ("areasOfInterest")]
		string [] AreasOfInterest { get;  }

		[Export ("initWithPlacemark:")]
		IntPtr Constructor (CLPlacemark placemark);

		[Export ("inlandWater")]
		string InlandWater { get;  }

		[Export ("location", ArgumentSemantic.Copy)]
		CLLocation Location { get; }

		[Export ("name")]
		string Name { get;  }

		[Export ("ocean")]
		string Ocean { get;  }

		[Export ("region", ArgumentSemantic.Copy)]
		CLRegion Region { get; }

		[Export ("timeZone")]
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		NSTimeZone TimeZone { get; }
#if XAMCORE_2_0 && !TVOS
		// From CLPlacemark (ContactsAdditions) category.
		[Introduced (PlatformName.WatchOS, 4, 0), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[NullAllowed, Export ("postalAddress")]
		CNPostalAddress PostalAddress { get; }
#endif
	}

	[Introduced (PlatformName.MacOSX, 10, 10)]
	[Introduced (PlatformName.iOS, 7, 0), BaseType (typeof (CLRegion))]
#if MONOMAC
	[DisableDefaultCtor]
#endif
	partial interface CLCircularRegion {

		[Export ("initWithCenter:radius:identifier:")]
		IntPtr Constructor (CLLocationCoordinate2D center, double radius, string identifier);

		[Export ("center")]
		CLLocationCoordinate2D Center { get; }

		[Export ("radius")]
		double Radius { get; }

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);
	}

#if !MONOMAC
	[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.MacOSX)][Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 7, 0), BaseType (typeof (CLRegion))]
	[DisableDefaultCtor] // nil-Handle on iOS8 if 'init' is used
	partial interface CLBeaconRegion {

		[Export ("initWithProximityUUID:identifier:")]
		IntPtr Constructor (NSUuid proximityUuid, string identifier);

		[Export ("initWithProximityUUID:major:identifier:")]
		IntPtr Constructor (NSUuid proximityUuid, ushort major, string identifier);

		[Export ("initWithProximityUUID:major:minor:identifier:")]
		IntPtr Constructor (NSUuid proximityUuid, ushort major, ushort minor, string identifier);

		[Export ("peripheralDataWithMeasuredPower:")]
		NSMutableDictionary GetPeripheralData ([NullAllowed] NSNumber measuredPower);

		[Export ("proximityUUID", ArgumentSemantic.Copy)]
		NSUuid ProximityUuid { get; }

		[Export ("major", ArgumentSemantic.Copy)]
		NSNumber Major { get; }

		[Export ("minor", ArgumentSemantic.Copy)]
		NSNumber Minor { get; }

		[Export ("notifyEntryStateOnDisplay", ArgumentSemantic.Assign)]
		bool NotifyEntryStateOnDisplay { get; set; }
	}

	[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.MacOSX)][Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 7, 0), BaseType (typeof (NSObject))]
	partial interface CLBeacon : NSCopying, NSSecureCoding {

		[Export ("proximityUUID", ArgumentSemantic.Copy)]
		NSUuid ProximityUuid { get; }

		[Export ("major", ArgumentSemantic.Copy)]
		NSNumber Major { get; }

		[Export ("minor", ArgumentSemantic.Copy)]
		NSNumber Minor { get; }

		[Export ("proximity")]
		CLProximity Proximity { get; }

		[Export ("accuracy")]
		double Accuracy { get; }

		[Export ("rssi")]
		nint Rssi { get; }
	}

#endif

	delegate void CLGeocodeCompletionHandler (CLPlacemark [] placemarks, NSError error);

	[Introduced (PlatformName.MacOSX, 10, 8)]
	[Introduced (PlatformName.iOS, 5, 0)]
	[BaseType (typeof (NSObject))]
	interface CLGeocoder {
		[Export ("isGeocoding")]
		bool Geocoding { get; }

		[Export ("reverseGeocodeLocation:completionHandler:")]
		[Async]
		void ReverseGeocodeLocation (CLLocation location, CLGeocodeCompletionHandler completionHandler);

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("reverseGeocodeLocation:preferredLocale:completionHandler:")]
		[Async]
		void ReverseGeocodeLocation (CLLocation location, [NullAllowed] NSLocale locale, CLGeocodeCompletionHandler completionHandler);

		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'GeocodeAddress (string, CLRegion, NSLocale, CLGeocodeCompletionHandler)' instead.")]
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'GeocodeAddress (string, CLRegion, NSLocale, CLGeocodeCompletionHandler)' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'GeocodeAddress (string, CLRegion, NSLocale, CLGeocodeCompletionHandler)' instead.")]
		[Export ("geocodeAddressDictionary:completionHandler:")]
		[Async]
		void GeocodeAddress (NSDictionary addressDictionary, CLGeocodeCompletionHandler completionHandler);

		[Export ("geocodeAddressString:completionHandler:")]
		[Async]
		void GeocodeAddress (string addressString, CLGeocodeCompletionHandler completionHandler);

		[Export ("geocodeAddressString:inRegion:completionHandler:")]
		[Async]
		void GeocodeAddress (string addressString, CLRegion region, CLGeocodeCompletionHandler completionHandler);

		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Async]
		[Export ("geocodeAddressString:inRegion:preferredLocale:completionHandler:")]
		void GeocodeAddress (string addressString, [NullAllowed] CLRegion region, [NullAllowed] NSLocale locale, CLGeocodeCompletionHandler completionHandler);

		[Export ("cancelGeocode")]
		void CancelGeocode ();

#if XAMCORE_2_0 && !TVOS
		[Introduced (PlatformName.WatchOS, 4, 0), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("geocodePostalAddress:completionHandler:")]
		[Async]
		void GeocodePostalAddress (CNPostalAddress postalAddress, CLGeocodeCompletionHandler completionHandler);

		[Introduced (PlatformName.WatchOS, 4, 0), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("geocodePostalAddress:preferredLocale:completionHandler:")]
		[Async]
		void GeocodePostalAddress (CNPostalAddress postalAddress, [NullAllowed] NSLocale locale, CLGeocodeCompletionHandler completionHandler);
#endif
	}

#if !MONOMAC
	[Unavailable (PlatformName.WatchOS)][Unavailable (PlatformName.TvOS)]
	[Introduced (PlatformName.iOS, 8, 0)]
	[BaseType (typeof (NSObject))]
	interface CLVisit : NSSecureCoding, NSCopying {

		[Export ("arrivalDate", ArgumentSemantic.Copy)]
		NSDate ArrivalDate { get; }

		[Export ("departureDate", ArgumentSemantic.Copy)]
		NSDate DepartureDate { get; }

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("horizontalAccuracy")]
		double HorizontalAccuracy { get; }
	}
#endif
}

//
// MapKit enumerations
//
// Author:
//   Miguel de Icaza
//
// Copyright 2009 Novell, Inc.
// Copyright 2014-2016 Xamarin Inc.
//
#if XAMCORE_2_0 || !MONOMAC
using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace MapKit {

	// NSUInteger -> MKDirectionsTypes.h
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Introduced (PlatformName.iOS, 7, 0)]
	public enum MKDirectionsTransportType : ulong {
		Automobile = 1 << 0,
		Walking    = 1 << 1,
		Transit    = 1 << 2, 
		Any        = 0x0FFFFFFF,
	}

	// NSUInteger -> MKTypes.h
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MKMapType : ulong {
		Standard = 0,
		Satellite,
		Hybrid,
		SatelliteFlyover,
		HybridFlyover,
		[Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.TvOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		MutedStandard,
	}

	// NSUInteger -> MKDistanceFormatter.h
	[Native]
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Introduced (PlatformName.iOS, 7, 0)]
	public enum MKDistanceFormatterUnits : ulong {
		Default,
		Metric,
		Imperial,
		ImperialWithYards,
	}

	// NSUInteger -> MKDistanceFormatter.h
	[Native]
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Introduced (PlatformName.iOS, 7, 0)]
	public enum MKDistanceFormatterUnitStyle : ulong {
		Default = 0,
		Abbreviated,
		Full,
	}

	// NSInteger -> MKMapView.h
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	[Introduced (PlatformName.iOS, 7, 0)]
	public enum MKOverlayLevel : long {
		AboveRoads = 0,
		AboveLabels,
	}

	// NSUInteger -> MKTypes.h
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	[ErrorDomain ("MKErrorDomain")]
	public enum MKErrorCode : ulong {
		Unknown = 1,
		ServerFailure,
		LoadingThrottled,
		PlacemarkNotFound,
		DirectionsNotFound,
	}

	// NSUInteger -> MKTypes.h
	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MKAnnotationViewDragState : ulong {
		None, Starting, Dragging, Canceling, Ending
	}
	
	// NSUInteger -> MKTypes.h
	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'MKPinAnnotationView.PinTintColor' instead.")]
	public enum MKPinAnnotationColor : ulong {
		Red, Green, Purple
	}

	// NSUInteger -> MKTypes.h
	[Introduced (PlatformName.TvOS, 9, 2)]
	[Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MKUserTrackingMode : ulong {
		None, Follow, FollowWithHeading
	}

	[Introduced (PlatformName.TvOS, 9, 2)][Unavailable (PlatformName.WatchOS)][Introduced (PlatformName.iOS, 9, 3)]
	[Native]
	public enum MKSearchCompletionFilterType : long {
		AndQueries = 0,
		Only
	}

	[Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.WatchOS)][Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum MKAnnotationViewCollisionMode : long {
		Rectangle,
		Circle,
	}

	[Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.WatchOS)][Introduced (PlatformName.iOS, 11, 0)][Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum MKScaleViewAlignment : long {
		Leading,
		Trailing,
	}

	[Introduced (PlatformName.TvOS, 11, 0)][Unavailable (PlatformName.WatchOS)][Introduced (PlatformName.iOS, 11, 0)][Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
	[Native]
	public enum MKFeatureVisibility : long {
		Adaptive,
		Hidden,
		Visible,
	}
}

#endif

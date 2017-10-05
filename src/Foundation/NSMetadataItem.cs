//
// Convenience methods for NSMetadataItem
//
// Copyright 2014, 2016 Xamarin Inc
//
// Author:
//   Miguel de Icaza
//
using System;
using ObjCRuntime;

namespace Foundation {
	public partial class NSMetadataItem {

		bool GetBool (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n == null ? false : n.BoolValue;
		}

		bool? GetNullableBool (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n?.BoolValue;
		}

		double GetDouble (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n == null ? 0 : n.DoubleValue;
		}

		double? GetNullableDouble (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n?.DoubleValue;
		}

		nint? GetNInt (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
#if XAMCORE_2_0
			return n?.NIntValue;
#else
			return n?.IntValue;
#endif
		}

		// same order as NSMetadataAttributes.h

		public NSString FileSystemName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemFSNameKey));
			}
		}

		public NSString DisplayName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemDisplayNameKey));
			}
		}

		public NSUrl Url {
			get {
				return Runtime.GetNSObject<NSUrl> (GetHandle (NSMetadataQuery.ItemURLKey));
			}
		}

		public NSString Path {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemPathKey));
			}
		}

		public NSNumber FileSystemSize {
			get {
				return Runtime.GetNSObject<NSNumber> (GetHandle (NSMetadataQuery.ItemFSSizeKey));
			}
		}

		public NSDate FileSystemCreationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ItemFSCreationDateKey));
			}
		}

		public NSDate FileSystemContentChangeDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ItemFSContentChangeDateKey));
			}
		}

		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSString ContentType {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ContentTypeKey));
			}
		}

		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSString[] ContentTypeTree {
			get {
				using (var a = Runtime.GetNSObject<NSArray> (GetHandle (NSMetadataQuery.ContentTypeTreeKey)))
					return NSArray.FromArray<NSString> (a);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public bool IsUbiquitous {
			get {
				return GetBool (NSMetadataQuery.ItemIsUbiquitousKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public bool UbiquitousItemHasUnresolvedConflicts {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemHasUnresolvedConflictsKey);
			}
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
#if XAMCORE_4_0
		public NSItemDownloadingStatus UbiquitousItemDownloadingStatus {
#else
		public NSItemDownloadingStatus DownloadingStatus {
#endif
			get {
				return NSItemDownloadingStatusExtensions.GetValue (Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.UbiquitousItemDownloadingStatusKey)));
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public bool UbiquitousItemIsDownloading {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemIsDownloadingKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public bool UbiquitousItemIsUploaded {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemIsUploadedKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public bool UbiquitousItemIsUploading {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemIsUploadingKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public double UbiquitousItemPercentDownloaded {
			get {
				return GetDouble (NSMetadataQuery.UbiquitousItemPercentDownloadedKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		public double UbiquitousItemPercentUploaded {
			get {
				return GetDouble (NSMetadataQuery.UbiquitousItemPercentUploadedKey);
			}
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSError UbiquitousItemDownloadingError {
			get {
				return Runtime.GetNSObject<NSError> (GetHandle (NSMetadataQuery.UbiquitousItemDownloadingErrorKey));
			}
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSError UbiquitousItemUploadingError {
			get {
				return Runtime.GetNSObject<NSError> (GetHandle (NSMetadataQuery.UbiquitousItemUploadingErrorKey));
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 10)]
		public bool UbiquitousItemDownloadRequested {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemDownloadRequestedKey);
			}
		}

		// XAMCORE_4_0 FIXME return nullable
		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 10)]
		public bool UbiquitousItemIsExternalDocument {
			get {
				return GetBool (NSMetadataQuery.UbiquitousItemIsExternalDocumentKey);
			}
		}

		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSString UbiquitousItemContainerDisplayName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.UbiquitousItemContainerDisplayNameKey));
			}
		}

		[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSUrl UbiquitousItemUrlInLocalContainer {
			get {
				return Runtime.GetNSObject<NSUrl> (GetHandle (NSMetadataQuery.UbiquitousItemURLInLocalContainerKey));
			}
		}

#if MONOMAC
		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Keywords {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.KeywordsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Title {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.TitleKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Authors {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorsKey)); 
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Editors {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EditorsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Participants {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ParticipantsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Projects {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ProjectsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate DownloadedDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DownloadedDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] WhereFroms {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.WhereFromsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Comment {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CommentKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Copyright {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CopyrightKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate LastUsedDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.LastUsedDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate ContentCreationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ContentCreationDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate ContentModificationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ContentModificationDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate DateAdded {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DateAddedKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? DurationSeconds {
			get {
				return GetNullableDouble (NSMetadataQuery.DurationSecondsKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] ContactKeywords {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ContactKeywordsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Version {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.VersionKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? PixelHeight {
			get {
				return GetNInt (NSMetadataQuery.PixelHeightKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? PixelWidth {
			get {
				return GetNInt (NSMetadataQuery.PixelWidthKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? PixelCount {
			get {
				return GetNInt (NSMetadataQuery.PixelCountKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ColorSpace {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ColorSpaceKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? BitsPerSample {
			get {
				return GetNInt (NSMetadataQuery.BitsPerSampleKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? FlashOnOff {
			get {
				return GetNullableBool (NSMetadataQuery.FlashOnOffKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? FocalLength {
			get {
				return GetNullableDouble (NSMetadataQuery.FocalLengthKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AcquisitionMake {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AcquisitionMakeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AcquisitionModel {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AcquisitionModelKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? IsoSpeed {
			get {
				return GetNullableDouble (NSMetadataQuery.IsoSpeedKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? Orientation {
			get {
				return GetNInt (NSMetadataQuery.OrientationKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] LayerNames {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.LayerNamesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? WhiteBalance {
			get {
				return GetNullableDouble (NSMetadataQuery.WhiteBalanceKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Aperture {
			get {
				return GetNullableDouble (NSMetadataQuery.ApertureKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ProfileName {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ProfileNameKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? ResolutionWidthDpi {
			get {
				return GetNInt (NSMetadataQuery.ResolutionWidthDpiKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? ResolutionHeightDpi {
			get {
				return GetNInt (NSMetadataQuery.ResolutionHeightDpiKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? ExposureMode {
			get {
				return GetNInt (NSMetadataQuery.ExposureModeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? ExposureTimeSeconds {
			get {
				return GetNullableDouble (NSMetadataQuery.ExposureTimeSecondsKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ExifVersion {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ExifVersionKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string CameraOwner {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CameraOwnerKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? FocalLength35mm {
			get {
				return GetNInt (NSMetadataQuery.FocalLength35mmKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string LensModel {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.LensModelKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ExifGpsVersion {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ExifGpsVersionKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Altitude {
			get {
				return GetNullableDouble (NSMetadataQuery.AltitudeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Latitude {
			get {
				return GetNullableDouble (NSMetadataQuery.LatitudeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Longitude {
			get {
				return GetNullableDouble (NSMetadataQuery.LongitudeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Speed {
			get {
				return GetNullableDouble (NSMetadataQuery.SpeedKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate Timestamp {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.TimestampKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsTrack {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsTrackKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? ImageDirection {
			get {
				return GetNullableDouble (NSMetadataQuery.ImageDirectionKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string NamedLocation {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.NamedLocationKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string GpsStatus {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GpsStatusKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string GpsMeasureMode {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GpsMeasureModeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDop {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDopKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string GpsMapDatum {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GpsMapDatumKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDestLatitude {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestLatitudeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDestLongitude {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestLongitudeKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDestBearing {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestBearingKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDestDistance {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestDistanceKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string GpsProcessingMethod {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GpsProcessingMethodKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string GpsAreaInformation {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GpsAreaInformationKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate GpsDateStamp {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.GpsDateStampKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? GpsDifferental {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDifferentalKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Codecs {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.CodecsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] MediaTypes {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.MediaTypesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? Streamable {
			get {
				return GetNullableBool (NSMetadataQuery.StreamableKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? TotalBitRate {
			get {
				return GetNInt (NSMetadataQuery.TotalBitRateKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? VideoBitRate {
			get {
				return GetNInt (NSMetadataQuery.VideoBitRateKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? AudioBitRate {
			get {
				return GetNInt (NSMetadataQuery.AudioBitRateKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string DeliveryType {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.DeliveryTypeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Album {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AlbumKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? HasAlphaChannel {
			get {
				return GetNullableBool (NSMetadataQuery.HasAlphaChannelKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? RedEyeOnOff {
			get {
				return GetNullableBool (NSMetadataQuery.RedEyeOnOffKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string MeteringMode {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.MeteringModeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? MaxAperture {
			get {
				return GetNullableDouble (NSMetadataQuery.MaxApertureKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? FNumber {
			get {
				return GetNInt (NSMetadataQuery.FNumberKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ExposureProgram {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ExposureProgramKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ExposureTimeString {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ExposureTimeStringKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Headline {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.HeadlineKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Instructions {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.InstructionsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string City {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CityKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string StateOrProvince {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.StateOrProvinceKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Country {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CountryKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string TextContent {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.TextContentKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? AudioSampleRate {
			get {
				return GetNInt (NSMetadataQuery.AudioSampleRateKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? AudioChannelCount {
			get {
				return GetNInt (NSMetadataQuery.AudioChannelCountKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? Tempo {
			get {
				return GetNullableDouble (NSMetadataQuery.TempoKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string KeySignature {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.KeySignatureKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string TimeSignature {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.TimeSignatureKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AudioEncodingApplication {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AudioEncodingApplicationKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Composer {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ComposerKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Lyricist {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.LyricistKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? AudioTrackNumber {
			get {
				return GetNInt (NSMetadataQuery.AudioTrackNumberKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate RecordingDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.RecordingDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string MusicalGenre {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.MusicalGenreKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? IsGeneralMidiSequence {
			get {
				return GetNullableBool (NSMetadataQuery.IsGeneralMidiSequenceKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? RecordingYear {
			get {
				return GetNInt (NSMetadataQuery.RecordingYearKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Organizations {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.OrganizationsKey));			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Languages {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.LanguagesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Rights {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.RightsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Publishers {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PublishersKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Contributors {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ContributorsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Coverage {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.CoverageKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Subject {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.SubjectKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Theme {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ThemeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Description {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.DescriptionKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Identifier {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.IdentifierKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Audiences {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AudiencesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public nint? NumberOfPages {
			get {
				return GetNInt (NSMetadataQuery.NumberOfPagesKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? PageWidth {
			get {
				return GetNullableDouble (NSMetadataQuery.PageWidthKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? PageHeight {
			get {
				return GetNullableDouble (NSMetadataQuery.PageHeightKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string SecurityMethod {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.SecurityMethodKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Creator {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CreatorKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] EncodingApplications {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EncodingApplicationsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDate DueDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DueDateKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public double? StarRating {
			get {
				return GetNullableDouble (NSMetadataQuery.StarRatingKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] PhoneNumbers {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PhoneNumbersKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] EmailAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EmailAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] InstantMessageAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.InstantMessageAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Kind {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.KindKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Recipients {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string FinderComment {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.FinderCommentKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Fonts {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.FontsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AppleLoopsRoot {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsRootKeyKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AppleLoopsKeyFilterType {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsKeyFilterTypeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string AppleLoopsLoopMode {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsLoopModeKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] AppleLoopDescriptors {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AppleLoopDescriptorsKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string MusicalInstrumentCategory {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.MusicalInstrumentCategoryKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string MusicalInstrumentName {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.MusicalInstrumentNameKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string CFBundleIdentifier {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.CFBundleIdentifierKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Information {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.InformationKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Director {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.DirectorKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Producer {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ProducerKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string Genre {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.GenreKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] Performers {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PerformersKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string OriginalFormat {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.OriginalFormatKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string OriginalSource {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.OriginalSourceKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] AuthorEmailAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorEmailAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] RecipientEmailAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientEmailAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] AuthorAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] RecipientAddresses {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientAddressesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? IsLikelyJunk {
			get {
				return GetNullableBool (NSMetadataQuery.IsLikelyJunkKey);
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] ExecutableArchitectures {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ExecutableArchitecturesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string ExecutablePlatform {
			get {
				return NSString.FromHandle (GetHandle (NSMetadataQuery.ExecutablePlatformKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public string [] ApplicationCategories {
			get {
				return NSArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ApplicationCategoriesKey));
			}
		}

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 9)]
		public bool? IsApplicationManaged {
			get {
				return GetNullableBool (NSMetadataQuery.IsApplicationManagedKey);
			}
		}
#endif
	}
}

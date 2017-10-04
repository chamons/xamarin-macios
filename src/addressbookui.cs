//
// This file describes the API that the generator will produce
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2014-2015, Xamarin Inc.
//
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreGraphics;
using XamCore.CoreLocation;
using XamCore.UIKit;
using XamCore.AddressBook;
using System;

namespace XamCore.AddressBookUI {

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (UIViewController))]
	interface ABNewPersonViewController {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Export ("displayedPerson"), Internal]
		IntPtr _DisplayedPerson { get; set; }

		[Export ("addressBook"), Internal]
		IntPtr _AddressBook { get; set; }

		[Export ("parentGroup"), Internal]
		IntPtr _ParentGroup {get; set;}

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ABNewPersonViewControllerDelegate Delegate { get; set; }

		[Export ("newPersonViewDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ABNewPersonViewControllerDelegate {

		[Export ("newPersonViewController:didCompleteWithNewPerson:")]
#if XAMCORE_2_0
		[Abstract]
		void DidCompleteWithNewPerson (ABNewPersonViewController controller, [NullAllowed]ABPerson person);
#else
		void DidCompleteWithNewPerson (ABNewPersonViewController controller, IntPtr person);
#endif
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (UINavigationController))]
	interface ABPeoplePickerNavigationController : UIAppearance {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Export ("initWithRootViewController:")]
		[PostGet ("ViewControllers")] // that will PostGet TopViewController and VisibleViewController too
		IntPtr Constructor (UIViewController rootViewController);

		[Export ("displayedProperties", ArgumentSemantic.Copy), Internal]
		NSNumber[] _DisplayedProperties {get; set;}

		[Export ("addressBook"), Internal]
		IntPtr _AddressBook {get; set;}

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ABPeoplePickerNavigationControllerDelegate Delegate {get; set;}

		[NullAllowed] // by default this property is null
		[Export ("peoplePickerDelegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate {get; set;}

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("predicateForEnablingPerson", ArgumentSemantic.Copy)]
		[NullAllowed]
		NSPredicate PredicateForEnablingPerson { get; set; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("predicateForSelectionOfPerson", ArgumentSemantic.Copy)]
		[NullAllowed]
		NSPredicate PredicateForSelectionOfPerson { get; set; }

		[Introduced (PlatformName.iOS, 8, 0)]
		[Export ("predicateForSelectionOfProperty", ArgumentSemantic.Copy)]
		[NullAllowed]
		NSPredicate PredicateForSelectionOfProperty { get; set; }
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
#if XAMCORE_3_0
	[BaseType (typeof (NSObject))]
#else
	[BaseType (typeof (UINavigationControllerDelegate))]
#endif
	[Model]
	[Protocol]
	interface ABPeoplePickerNavigationControllerDelegate {
		[Deprecated (PlatformName.iOS, 8, 0, message: "Use 'DidSelectPerson' instead (or 'ABPeoplePickerNavigationController.PredicateForSelectionOfPerson').")]
		[Export ("peoplePickerNavigationController:shouldContinueAfterSelectingPerson:")]
#if XAMCORE_2_0
		bool ShouldContinue (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson);
#else
		bool ShouldContinue (ABPeoplePickerNavigationController peoplePicker, IntPtr selectedPerson);
#endif

		[Deprecated (PlatformName.iOS, 8, 0, message: "Use 'DidSelectPerson' instead (or 'ABPeoplePickerNavigationController.PredicateForSelectionOfProperty').")]
		[Export ("peoplePickerNavigationController:shouldContinueAfterSelectingPerson:property:identifier:")]
#if XAMCORE_2_0
		bool ShouldContinue (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson, int /* ABPropertyId = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#else
		bool ShouldContinue (ABPeoplePickerNavigationController peoplePicker, IntPtr selectedPerson, int /* ABPropertyId = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#endif

		[Export ("peoplePickerNavigationControllerDidCancel:")]
		void Cancelled (ABPeoplePickerNavigationController peoplePicker);

		[Export ("peoplePickerNavigationController:didSelectPerson:")]
		void DidSelectPerson (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson);

#if XAMCORE_2_0
		[Export ("peoplePickerNavigationController:didSelectPerson:property:identifier:")]
		void DidSelectPerson (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson, int /* ABPropertyId = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#else
		[Export ("peoplePickerNavigationController:didSelectPerson:property:identifier:")]
		void DidSelectPerson (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson, int /* ABPropertyId = int32 */ propertyId, IntPtr abMultiValueIdentifier);
#endif
		}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (UIViewController))]
	interface ABPersonViewController : UIViewControllerRestoration {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Export ("displayedPerson"), Internal]
		IntPtr _DisplayedPerson {get; set;}

		[Export ("displayedProperties", ArgumentSemantic.Copy), Internal]
		NSNumber[] _DisplayedProperties { get; set; }

		[Export ("addressBook"), Internal]
		IntPtr _AddressBook {get; set;}

		[Export ("allowsActions")]
		bool AllowsActions { get; set;}

		[Export ("allowsEditing")]
		bool AllowsEditing {get; set;}

		[Export ("shouldShowLinkedPeople")]
		bool ShouldShowLinkedPeople { get; set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ABPersonViewControllerDelegate Delegate {get; set;}

		[NullAllowed] // by default this property is null
		[Export ("personViewDelegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate {get; set;}

		// Obsolete for public use; we should "remove" this member by making
		// it [Internal] in some future release, as it's needed internally.
#if XAMCORE_2_0
		[Internal]
#endif
		[Obsolete ("Use SetHighlightedItemForProperty(ABPersonProperty,int?).")]
		[Export ("setHighlightedItemForProperty:withIdentifier:")]
		void SetHighlightedItemForProperty (int /* ABPropertyId = int32 */ property, int /* ABMultiValueIdentifier = int32 */ identifier);
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[Static, Introduced (PlatformName.iOS, 8, 0)]
	interface ABPersonPredicateKey {
		[Field ("ABPersonBirthdayProperty")]
		NSString Birthday { get; }
		
		[Field ("ABPersonDatesProperty")]
		NSString Dates { get; }
		
		[Field ("ABPersonDepartmentNameProperty")]
		NSString DepartmentName { get; }
		
		[Field ("ABPersonEmailAddressesProperty")]
		NSString EmailAddresses { get; }
		
		[Field ("ABPersonFamilyNameProperty")]
		NSString FamilyName { get; }
		
		[Field ("ABPersonGivenNameProperty")]
		NSString GivenName { get; }
		
		[Field ("ABPersonInstantMessageAddressesProperty")]
		NSString InstantMessageAddresses { get; }
		
		[Field ("ABPersonJobTitleProperty")]
		NSString JobTitle { get; }
		
		[Field ("ABPersonMiddleNameProperty")]
		NSString MiddleName { get; }
		
		[Field ("ABPersonNamePrefixProperty")]
		NSString NamePrefix { get; }
		
		[Field ("ABPersonNameSuffixProperty")]
		NSString NameSuffix { get; }
		
		[Field ("ABPersonNicknameProperty")]
		NSString Nickname { get; }
		
		[Field ("ABPersonNoteProperty")]
		NSString Note { get; }
		
		[Field ("ABPersonOrganizationNameProperty")]
		NSString OrganizationName { get; }
		
		[Field ("ABPersonPhoneNumbersProperty")]
		NSString PhoneNumbers { get; }
		
		[Field ("ABPersonPhoneticFamilyNameProperty")]
		NSString PhoneticFamilyName { get; }
		
		[Field ("ABPersonPhoneticGivenNameProperty")]
		NSString PhoneticGivenName { get; }
		
		[Field ("ABPersonPhoneticMiddleNameProperty")]
		NSString PhoneticMiddleName { get; }
		
		[Field ("ABPersonPostalAddressesProperty")]
		NSString PostalAddresses { get; }
		
		[Field ("ABPersonPreviousFamilyNameProperty")]
		NSString PreviousFamilyName { get; }
		
		[Field ("ABPersonRelatedNamesProperty")]
		NSString RelatedNames { get; }
		
		[Field ("ABPersonSocialProfilesProperty")]
		NSString SocialProfiles { get; }
		
		[Field ("ABPersonUrlAddressesProperty")]
		NSString UrlAddresses { get; }
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ABPersonViewControllerDelegate {

		[Export ("personViewController:shouldPerformDefaultActionForPerson:property:identifier:")]
#if XAMCORE_2_0
		[Abstract]
		bool ShouldPerformDefaultActionForPerson (ABPersonViewController personViewController, ABPerson person, int /* ABPropertyID = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#else
		bool ShouldPerformDefaultActionForPerson (ABPersonViewController personViewController, IntPtr person, int /* ABPropertyID = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#endif
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (UIViewController))]
	interface ABUnknownPersonViewController {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[NullAllowed] // by default this property is null
		[Export ("alternateName", ArgumentSemantic.Copy)]
		string AlternateName {get; set;}

		[NullAllowed] // by default this property is null
		[Export ("message", ArgumentSemantic.Copy)]
		string Message {get; set;}

		[Export ("displayedPerson"), Internal]
		IntPtr _DisplayedPerson {get; set;}

		[Export ("addressBook"), Internal]
		IntPtr _AddressBook {get; set;}

		[Export ("allowsActions")]
		bool AllowsActions {get; set;}

		[Export ("allowsAddingToAddressBook")]
		bool AllowsAddingToAddressBook {get; set;}

		[Wrap ("WeakDelegate")]
		[Protocolize]
		ABUnknownPersonViewControllerDelegate Delegate {get; set;}

		[NullAllowed] // by default this property is null
		[Export ("unknownPersonViewDelegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate {get; set;}
	}

	[Deprecated (PlatformName.iOS, 9, 0, message: "Use the 'Contacts' API instead.")]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ABUnknownPersonViewControllerDelegate {
		[Export ("unknownPersonViewController:didResolveToPerson:")]
#if XAMCORE_2_0
		[Abstract]
		void DidResolveToPerson (ABUnknownPersonViewController unknownPersonView, ABPerson person);
#else
		void DidResolveToPerson (ABUnknownPersonViewController unknownPersonView, IntPtr person);
#endif

		[Export ("unknownPersonViewController:shouldPerformDefaultActionForPerson:property:identifier:")]
#if XAMCORE_2_0
		bool ShouldPerformDefaultActionForPerson (ABUnknownPersonViewController personViewController, ABPerson person, int /* ABPropertyID = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#else
		bool ShouldPerformDefaultActionForPerson (ABUnknownPersonViewController personViewController, IntPtr person, int /* ABPropertyID = int32 */ propertyId, int /* ABMultiValueIdentifier = int32 */ identifier);
#endif
	}
}


//
// Contacts bindings
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.
//

using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

#if XAMCORE_2_0 // The Contacts framework uses generics heavily, which is only supported in Unified (for now at least)

namespace XamCore.Contacts {

	// NSInteger -> CNContact.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNContactType : long {
		Person,
		Organization
	}

	// NSInteger -> CNContact.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNContactSortOrder : long {
		None,
		UserDefault,
		GivenName,
		FamilyName
	}

	// NSInteger -> CNContactFormatter.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNContactFormatterStyle : long {
		FullName,
		PhoneticFullName
	}

	// NSInteger -> CNContactFormatter.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNContactDisplayNameOrder : long {
		UserDefault,
		GivenNameFirst,
		FamilyNameFirst
	}

	// NSInteger -> CNContactStore.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNEntityType : long {
		Contacts
	}

	// NSInteger -> CNContactStore.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNAuthorizationStatus : long {
		NotDetermined = 0,
		Restricted,
		Denied,
		Authorized
	}

	// NSInteger -> CNContainer.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNContainerType : long {
		Unassigned = 0,
		Local,
		Exchange,
		CardDav
	}

	// NSInteger -> CNError.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[ErrorDomain ("CNErrorDomain")]
	public enum CNErrorCode : long {
		CommunicationError = 1,
		DataAccessError = 2,
		AuthorizationDenied = 100,
		RecordDoesNotExist = 200,
		InsertedRecordAlreadyExists = 201,
		ContainmentCycle = 202,
		ContainmentScope = 203,
		ParentRecordDoesNotExist = 204,
		ValidationMultipleErrors = 300,
		ValidationTypeMismatch = 301,
		ValidationConfigurationError = 302,
		PredicateInvalid = 400,
		PolicyViolation = 500,
		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
		ClientIdentifierInvalid = 600,
		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
		ClientIdentifierDoesNotExist = 601,
		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13)]
		VCardMalformed = 700,
	}

	// NSInteger -> CNPostalAddressFormatter.h
	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum CNPostalAddressFormatterStyle : long {
		MailingAddress,
	}
}

#endif // XAMCORE_2_0



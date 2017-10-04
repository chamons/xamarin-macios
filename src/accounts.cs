//
// Copyright 2011, 2013 Xamarin, Inc.
//
#if XAMCORE_2_0 || !MONOMAC
using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.Accounts {
	
	[Introduced (PlatformName.iOS, 5, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface ACAccount : NSSecureCoding {
		[Export ("identifier", ArgumentSemantic.Weak)]
		string Identifier { get;  }

		[NullAllowed] // by default this property is null
		[Export ("accountType", ArgumentSemantic.Retain)]
		ACAccountType AccountType { get; set;  }

		[NullAllowed] // by default this property is null
		[Export ("accountDescription", ArgumentSemantic.Copy)]
		string AccountDescription { get; set;  }

		[NullAllowed] // by default this property is null
		[Export ("username", ArgumentSemantic.Copy)]
		string Username { get; set;  }

		[NullAllowed] // by default this property is null
		[Export ("credential", ArgumentSemantic.Retain)]
		ACAccountCredential Credential { get; set;  }

		[DesignatedInitializer]
		[Export ("initWithAccountType:")]
		IntPtr Constructor (ACAccountType type);

#if !XAMCORE_3_0
		// now exposed with the corresponding EABluetoothAccessoryPickerError enum
		[Field ("ACErrorDomain")]
		NSString ErrorDomain { get; }
#endif

#if !MONOMAC
		[Introduced (PlatformName.iOS, 7, 0)]
		[Export ("userFullName")]
		string UserFullName { get; }
#endif
	}

	[Introduced (PlatformName.iOS, 5, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface ACAccountCredential : NSSecureCoding {
		[Export ("initWithOAuthToken:tokenSecret:")]
		IntPtr Constructor (string oauthToken, string tokenSecret);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("initWithOAuth2Token:refreshToken:expiryDate:")]
		IntPtr Constructor (string oauth2Token, string refreshToken, NSDate expiryDate);

		[Introduced (PlatformName.iOS, 6, 0)]
		[NullAllowed] // by default this property is null
		[Export ("oauthToken", ArgumentSemantic.Copy)]
		string OAuthToken { get; set;  }
	}

	delegate void ACAccountStoreSaveCompletionHandler (bool success, NSError error);
	delegate void ACAccountStoreRemoveCompletionHandler (bool success, NSError error);
	delegate void ACRequestCompletionHandler (bool granted, NSError error);
	
	[Introduced (PlatformName.iOS, 5, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface ACAccountStore {
		[Export ("accounts", ArgumentSemantic.Weak)]
		ACAccount [] Accounts { get;  }

		[Export ("accountWithIdentifier:")]
		ACAccount FindAccount (string identifier);

		[Export ("accountTypeWithAccountTypeIdentifier:")]
		ACAccountType FindAccountType (string typeIdentifier);

		[Export ("accountsWithAccountType:")]
		ACAccount [] FindAccounts (ACAccountType accountType);

		[Export ("saveAccount:withCompletionHandler:")]
		[Async]
		void SaveAccount (ACAccount account, ACAccountStoreSaveCompletionHandler completionHandler);

		[Export ("requestAccessToAccountsWithType:withCompletionHandler:")]
		[Deprecated (PlatformName.iOS, 6, 0, message: "Use 'RequestAccess (ACAccountType, AccountStoreOptions, ACRequestCompletionHandler)' instead.")]
		[Async]
		void RequestAccess (ACAccountType accountType, ACRequestCompletionHandler completionHandler);

		[Field ("ACAccountStoreDidChangeNotification")]
		[Notification]
		NSString ChangeNotification { get; }
		
		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("renewCredentialsForAccount:completion:")]
		[Async]
		void RenewCredentials (ACAccount account, Action<ACAccountCredentialRenewResult,NSError> completionHandler);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Protected]
		[Export ("requestAccessToAccountsWithType:options:completion:")]
		[Async]
		void RequestAccess (ACAccountType accountType, [NullAllowed] NSDictionary options, ACRequestCompletionHandler completion);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Wrap ("RequestAccess (accountType, options == null ? null : options.Dictionary, completion)")]
		[Async]
		void RequestAccess (ACAccountType accountType, [NullAllowed] AccountStoreOptions options, ACRequestCompletionHandler completion);

		[Introduced (PlatformName.iOS, 6, 0)]
		[Export ("removeAccount:withCompletionHandler:")]
		[Async]
		void RemoveAccount (ACAccount account, ACAccountStoreRemoveCompletionHandler completionHandler);
	}

	[Introduced (PlatformName.iOS, 5, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface ACAccountType : NSSecureCoding {
		[Export ("accountTypeDescription")]
		string Description { get;  }

		[Export ("identifier")]
		string Identifier { get;  }

		[Export ("accessGranted")]
		bool AccessGranted { get;  }

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use Twitter SDK instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Twitter SDK instead.")]
		[Field ("ACAccountTypeIdentifierTwitter")]
		NSString Twitter { get; }

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use Sina Weibo SDK instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Sina Weibo SDK instead.")]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("ACAccountTypeIdentifierSinaWeibo")]
		NSString SinaWeibo { get; }

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use Facebook SDK instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Facebook SDK instead.")]
		[Introduced (PlatformName.iOS, 6, 0)]
		[Field ("ACAccountTypeIdentifierFacebook")]
		NSString Facebook { get; }

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use Tencent Weibo SDK instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Tencent Weibo SDK instead.")]
		[Introduced (PlatformName.iOS, 7, 0)]
		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Field ("ACAccountTypeIdentifierTencentWeibo")]
		NSString TencentWeibo { get; }

#if MONOMAC
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use LinkedIn SDK instead.")]
		[Introduced (PlatformName.MacOSX, 10, 9)]
		[Field ("ACAccountTypeIdentifierLinkedIn")]
		NSString LinkedIn { get; }
#endif
	}

	[Deprecated (PlatformName.iOS, 11, 0, message: "Use Facebook SDK instead.")]
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Facebook SDK instead.")]
	[Introduced (PlatformName.iOS, 6, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[Static]
	interface ACFacebookKey {
		[Field ("ACFacebookAppIdKey")]
		NSString AppId { get; }
		
		[Field ("ACFacebookPermissionsKey")]
		NSString Permissions { get; }

		// FIXME: does not exists in OSX 10.8 - which breaks our custom, higher level API for permissions
		[Field ("ACFacebookAudienceKey")]
		NSString Audience { get; }
	}

	[Deprecated (PlatformName.iOS, 11, 0, message: "Use Facebook SDK instead.")]
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Facebook SDK instead.")]
	[Introduced (PlatformName.iOS, 6, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8, PlatformArchitecture.Arch64)]
	[Static]
	interface ACFacebookAudienceValue
	{	
		[Field ("ACFacebookAudienceEveryone")]
		NSString Everyone { get; }

		[Field ("ACFacebookAudienceFriends")]
		NSString Friends { get; }

		[Field ("ACFacebookAudienceOnlyMe")]
		NSString OnlyMe { get; }
	}

	[Deprecated (PlatformName.iOS, 11, 0, message: "Use Tencent Weibo SDK instead.")]
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use Tencent Weibo SDK instead.")]
	[Introduced (PlatformName.iOS, 7, 0)]
	[Introduced (PlatformName.MacOSX, 10, 9, PlatformArchitecture.Arch64)]
	[Static]
	interface ACTencentWeiboKey {
		[Field ("ACTencentWeiboAppIdKey")]
		NSString AppId { get; }
	}

#if MONOMAC
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use LinkedIn SDK instead.")]
	[Introduced (PlatformName.MacOSX, 10, 9, PlatformArchitecture.Arch64)]
	[Static]
	interface ACLinkedInKey {
		[Field ("ACLinkedInAppIdKey")]
		NSString AppId { get; }

		[Field ("ACLinkedInPermissionsKey")]
		NSString Permissions { get; }
	}
#endif
}
#endif

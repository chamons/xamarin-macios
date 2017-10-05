using System;
using ObjCRuntime;
using Foundation;
using Security;

namespace LocalAuthentication {

	[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.MacOSX)]
	[Native]
	public enum LABiometryType : long {
		None,
		TouchId,
		TypeFaceId,
	}

	[Introduced (PlatformName.iOS, 8, 0), Introduced (PlatformName.MacOSX, 10, 10)]
	delegate void LAContextReplyHandler (bool success, NSError error);

	[Introduced (PlatformName.iOS, 8, 0), Introduced (PlatformName.MacOSX, 10, 10, PlatformArchitecture.Arch64)] // ".objc_class_name_LAContext", referenced from: '' not found
	[BaseType (typeof (NSObject))]
	interface LAContext {
		[NullAllowed] // by default this property is null
		[Export ("localizedFallbackTitle")]
		string LocalizedFallbackTitle { get; set; }

#if !XAMCORE_4_0
		[Introduced (PlatformName.iOS, 8, 3), Introduced (PlatformName.MacOSX, 10, 10)]
		[Field ("LAErrorDomain")]
		NSString ErrorDomain { get; }
#endif

		[Export ("canEvaluatePolicy:error:")]
		bool CanEvaluatePolicy (LAPolicy policy, out NSError error);

		[Async]
		[Export ("evaluatePolicy:localizedReason:reply:")]
		void EvaluatePolicy (LAPolicy policy, string localizedReason, LAContextReplyHandler reply);

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		[Export ("invalidate")]
		void Invalidate ();

		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		[Export ("setCredential:type:")]
		bool SetCredentialType ([NullAllowed] NSData credential, LACredentialType type);

		
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		[Export ("isCredentialSet:")]
		bool IsCredentialSet (LACredentialType type);

		
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		[Export ("evaluateAccessControl:operation:localizedReason:reply:")]
		void EvaluateAccessControl (SecAccessControl accessControl, LAAccessControlOperation operation, string localizedReason, Action<bool,NSError> reply);
		
		
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		[Export ("evaluatedPolicyDomainState")]
		[NullAllowed]
		NSData EvaluatedPolicyDomainState { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12)]
		[NullAllowed, Export ("localizedCancelTitle")]
		string LocalizedCancelTitle { get; set; }

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Field ("LATouchIDAuthenticationMaximumAllowableReuseDuration")]
		double /* NSTimeInterval */ TouchIdAuthenticationMaximumAllowableReuseDuration { get; }

		[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Export ("touchIDAuthenticationAllowableReuseDuration")]
		double /* NSTimeInterval */ TouchIdAuthenticationAllowableReuseDuration { get; set; }

#if !MONOMAC
		[Introduced (PlatformName.iOS, 8, 3), Deprecated (PlatformName.iOS, 9, 0)]
		[NullAllowed]
		[Export ("maxBiometryFailures")]
		NSNumber MaxBiometryFailures { get; set; }
#endif
		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("localizedReason")]
		string LocalizedReason { get; set; }

		[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("interactionNotAllowed")]
		bool InteractionNotAllowed { get; set; }

		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0)]
		[Export ("biometryType")]
		LABiometryType BiometryType { get; }
	}
}

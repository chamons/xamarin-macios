// 
// SecTrust.cs: Implements the managed SecTrust wrapper.
//
// Authors: 
//  Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013-2014 Xamarin Inc.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using ObjCRuntime;
using CoreFoundation;
using Foundation;

namespace Security {

	delegate void SecTrustCallback (IntPtr trustRef, SecTrustResult trustResult);

	public partial class SecTrust {

		public SecTrust (SecCertificate certificate, SecPolicy policy)
		{
			if (certificate == null)
				throw new ArgumentNullException ("certificate");

			Initialize (certificate.Handle, policy);
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustCopyPolicies (IntPtr /* SecTrustRef */ trust, ref IntPtr /* CFArrayRef* */ policies);

		[Introduced (PlatformName.iOS, 7, 0)]
		public SecPolicy[] GetPolicies ()
		{
			IntPtr p = IntPtr.Zero;
			SecStatusCode result = SecTrustCopyPolicies (handle, ref p);
			if (result != SecStatusCode.Success)
				throw new InvalidOperationException (result.ToString ());
			return NSArray.ArrayFromHandle<SecPolicy> (p);
		}

		[Introduced (PlatformName.iOS, 6, 0)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustSetPolicies (IntPtr /* SecTrustRef */ trust, IntPtr /* CFTypeRef */ policies);

		// the API accept the handle for a single policy or an array of them
		void SetPolicies (IntPtr policy)
		{
			SecStatusCode result = SecTrustSetPolicies (handle, policy);
			if (result != SecStatusCode.Success)
				throw new InvalidOperationException (result.ToString ());
		}

		[Introduced (PlatformName.iOS, 6, 0)]
		public void SetPolicy (SecPolicy policy)
		{
			if (policy == null)
				throw new ArgumentNullException ("policy");

			SetPolicies (policy.Handle);
		}

		[Introduced (PlatformName.iOS, 6, 0)]
		public void SetPolicies (IEnumerable<SecPolicy> policies)
		{
			if (policies == null)
				throw new ArgumentNullException ("policies");

			using (var array = NSArray.FromNSObjects (policies.ToArray ()))
				SetPolicies (array.Handle);
		}

		[Introduced (PlatformName.iOS, 6, 0)]
		public void SetPolicies (NSArray policies)
		{
			if (policies == null)
				throw new ArgumentNullException ("policies");

			SetPolicies (policies.Handle);
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustGetNetworkFetchAllowed (IntPtr /* SecTrustRef */ trust, out bool /* Boolean* */ allowFetch);

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustSetNetworkFetchAllowed (IntPtr /* SecTrustRef */ trust, bool /* Boolean */ allowFetch);

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public bool NetworkFetchAllowed {
			get {
				bool value;
				SecStatusCode result = SecTrustGetNetworkFetchAllowed (handle, out value);
				if (result != SecStatusCode.Success)
					throw new InvalidOperationException (result.ToString ());
				return value;
			}
			set {
				SecStatusCode result = SecTrustSetNetworkFetchAllowed (handle, value);
				if (result != SecStatusCode.Success)
					throw new InvalidOperationException (result.ToString ());
			}
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustCopyCustomAnchorCertificates (IntPtr /* SecTrustRef */ trust, out IntPtr /* CFArrayRef* */ anchors);

		[Introduced (PlatformName.iOS, 7, 0)]
		public SecCertificate[] GetCustomAnchorCertificates  ()
		{
			IntPtr p;
			SecStatusCode result = SecTrustCopyCustomAnchorCertificates (handle, out p);
			if (result != SecStatusCode.Success)
				throw new InvalidOperationException (result.ToString ());
			return NSArray.ArrayFromHandle<SecCertificate> (p);
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustEvaluateAsync (IntPtr /* SecTrustRef */ trust, IntPtr /* dispatch_queue_t */ queue, SecTrustCallback result);
		// FIXME: no `user data` parameter :( to ease MonoPInvokeCallback use

		[Introduced (PlatformName.iOS, 7, 0)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustGetTrustResult (IntPtr /* SecTrustRef */ trust, out SecTrustResult /* SecTrustResultType */ result);

		[Introduced (PlatformName.iOS, 7, 0)]
		public SecTrustResult GetTrustResult ()
		{
			SecTrustResult trust_result;
			SecStatusCode result = SecTrustGetTrustResult (handle, out trust_result);
			if (result != SecStatusCode.Success)
				throw new InvalidOperationException (result.ToString ());
			return trust_result;
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[DllImport (Constants.SecurityLibrary)]
		extern static IntPtr /* CFDictionaryRef */ SecTrustCopyResult (IntPtr /* SecTrustRef */ trust);

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		public NSDictionary GetResult ()
		{
			return new NSDictionary (SecTrustCopyResult (handle), true);
		}

		[Introduced (PlatformName.iOS, 7, 0)][Introduced (PlatformName.MacOSX, 10, 9)]
		[DllImport (Constants.SecurityLibrary)]
		extern static SecStatusCode /* OSStatus */ SecTrustSetOCSPResponse (IntPtr /* SecTrustRef */ trust, IntPtr /* CFTypeRef */ responseData);

		// the API accept the handle for a single policy or an array of them
		[Introduced (PlatformName.MacOSX, 10, 9)]
		void SetOCSPResponse (IntPtr ocsp)
		{
			SecStatusCode result = SecTrustSetOCSPResponse (handle, ocsp);
			if (result != SecStatusCode.Success)
				throw new InvalidOperationException (result.ToString ());
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		public void SetOCSPResponse (NSData ocspResponse)
		{
			if (ocspResponse == null)
				throw new ArgumentNullException ("ocspResponse");

			SetOCSPResponse (ocspResponse.Handle);
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		public void SetOCSPResponse (IEnumerable<NSData> ocspResponses)
		{
			if (ocspResponses == null)
				throw new ArgumentNullException ("ocspResponses");

			using (var array = NSArray.FromNSObjects (ocspResponses.ToArray ()))
				SetOCSPResponse (array.Handle);
		}

		[Introduced (PlatformName.iOS, 7, 0)]
		public void SetOCSPResponse (NSArray ocspResponses)
		{
			if (ocspResponses == null)
				throw new ArgumentNullException ("ocspResponses");

			SetOCSPResponse (ocspResponses.Handle);
		}
	}
}
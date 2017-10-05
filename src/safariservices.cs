//
// safariservices.cs: binding for iOS (7+) SafariServices framework
//
// Authors:
//   Aaron Bockover (abock@xamarin.com)
//   Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc.

using System;

using Foundation;
using ObjCRuntime;
#if !MONOMAC
using UIKit;
#else
using AppKit;
#endif

namespace SafariServices {
	delegate void SFExtensionValidationHandler (bool shouldHide, NSString text);

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)][Introduced (PlatformName.iOS, 10, 0)]
	[BaseType (typeof (NSObject))]
	interface SFContentBlockerState
	{
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface SFContentBlockerManager {
		[Async]
		[Static, Export ("reloadContentBlockerWithIdentifier:completionHandler:")]
		void ReloadContentBlocker (string identifier, [NullAllowed] Action<NSError> completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)]
		[Static][Async]
		[Export ("getStateOfContentBlockerWithIdentifier:completionHandler:")]
		void GetStateOfContentBlocker (string identifier, Action<SFContentBlockerState, NSError> completionHandler);
	}

#if !MONOMAC
	[Introduced (PlatformName.iOS, 7, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // NSGenericException Misuse of SSReadingList interface. Use class method defaultReadingList.
	partial interface SSReadingList {

		[NullAllowed]
		[Static, Export ("defaultReadingList")]
		SSReadingList DefaultReadingList { get; }

		[Static, Export ("supportsURL:")]
		// Apple says it's __nonnull so let's be safe and maintain compatibility with our current behaviour
		[PreSnippet ("if (url == null) return false;")]
		bool SupportsUrl ([NullAllowed] NSUrl url);

		[Export ("addReadingListItemWithURL:title:previewText:error:")]
		bool Add (NSUrl url, [NullAllowed] string title, [NullAllowed] string previewText, out NSError error);

#if !XAMCORE_4_0
		[Field ("SSReadingListErrorDomain")]
		NSString ErrorDomain { get; }
#endif
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[BaseType (typeof (UIViewController))]
	[DisableDefaultCtor] // NSGenericException Reason: Misuse of SFSafariViewController interface. Use initWithURL:entersReaderIfAvailable:
	interface SFSafariViewController {
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Introduced (PlatformName.iOS, 11, 0)]
		[Export ("initWithURL:configuration:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl url, SFSafariViewControllerConfiguration configuration);

		[Deprecated (PlatformName.iOS, 11, 0, message: "Use '.ctor (NSUrl, SFSafariViewControllerConfiguration)' instead.")]
		[DesignatedInitializer]
		[Export ("initWithURL:entersReaderIfAvailable:")]
		IntPtr Constructor (NSUrl url, bool entersReaderIfAvailable);

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[NullAllowed] // by default this property is null
		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		SFSafariViewControllerDelegate Delegate { get; set; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[NullAllowed]
		[Export ("preferredBarTintColor", ArgumentSemantic.Assign)]
		UIColor PreferredBarTintColor { get; set; }

		[Introduced (PlatformName.iOS, 10, 0)]
		[NullAllowed]
		[Export ("preferredControlTintColor", ArgumentSemantic.Assign)]
		UIColor PreferredControlTintColor { get; set; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Export ("configuration", ArgumentSemantic.Copy)]
		SFSafariViewControllerConfiguration Configuration { get; }

		[Introduced (PlatformName.iOS, 11, 0)]
		[Export ("dismissButtonStyle", ArgumentSemantic.Assign)]
		SFSafariViewControllerDismissButtonStyle DismissButtonStyle { get; set; }
	}

	[Introduced (PlatformName.iOS, 9, 0)]
	[Model]
	[BaseType (typeof (NSObject))]
	[Protocol]
	partial interface SFSafariViewControllerDelegate {
		[Export ("safariViewController:activityItemsForURL:title:")]
		UIActivity [] GetActivityItems (SFSafariViewController controller, NSUrl url, [NullAllowed] string title);

		[Export ("safariViewControllerDidFinish:")]
		void DidFinish (SFSafariViewController controller);

		[Export ("safariViewController:didCompleteInitialLoad:")]
		void DidCompleteInitialLoad (SFSafariViewController controller, bool didLoadSuccessfully);

		[Introduced (PlatformName.iOS, 11, 0)]
		[Export ("safariViewController:excludedActivityTypesForURL:title:")]
		string[] GetExcludedActivityTypes (SFSafariViewController controller, NSUrl url, [NullAllowed] string title);

		[Introduced (PlatformName.iOS, 11, 0)]
		[Export ("safariViewController:initialLoadDidRedirectToURL:")]
		void InitialLoadDidRedirectToUrl (SFSafariViewController controller, NSUrl url);
	}

	[Introduced (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (NSObject))]
	interface SFSafariViewControllerConfiguration : NSCopying {
		[Export ("entersReaderIfAvailable")]
		bool EntersReaderIfAvailable { get; set; }

		[Export ("barCollapsingEnabled")]
		bool BarCollapsingEnabled { get; set; }
	}

	[Introduced (PlatformName.iOS, 11, 0)]
	delegate void SFAuthenticationCompletionHandler ([NullAllowed] NSUrl callbackUrl, [NullAllowed] NSError error);

	[Introduced (PlatformName.iOS, 11, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFAuthenticationSession {
		[Export ("initWithURL:callbackURLScheme:completionHandler:")]
		IntPtr Constructor (NSUrl url, [NullAllowed] string callbackUrlScheme, SFAuthenticationCompletionHandler completionHandler);

		[Export ("start")]
		bool Start ();

		[Export ("cancel")]
		void Cancel ();
	}
#else
	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFSafariApplication
	{
		[Static][Async]
		[Export ("getActiveWindowWithCompletionHandler:")]
		void GetActiveWindow (Action<SFSafariWindow> completionHandler);

		[Static][Async]
		[Export ("openWindowWithURL:completionHandler:")]
		void OpenWindow (NSUrl url, [NullAllowed] Action<SFSafariWindow> completionHandler);

		[Static]
		[Export ("setToolbarItemsNeedUpdate")]
		void SetToolbarItemsNeedUpdate ();

		[Static]
		[Export ("showPreferencesForExtensionWithIdentifier:completionHandler:")]
		void ShowPreferencesForExtension (string identifier, [NullAllowed] Action<NSError> completionHandler);

		[Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Advice ("Unavailable to extensions.")]
		[Static][Async]
		[Export ("dispatchMessageWithName:toExtensionWithIdentifier:userInfo:completionHandler:")]
		void DispatchMessage (string messageName, string identifier, [NullAllowed] NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NSError> completionHandler);

		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		[Static]
		[Async]
		[Export ("getHostApplicationWithCompletionHandler:")]
		void GetHostApplication (Action<NSRunningApplication> completionHandler);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFSafariPage
	{
		[Export ("dispatchMessageToScriptWithName:userInfo:")]
		void DispatchMessageToScript (string messageName, [NullAllowed] NSDictionary userInfo);

		[Export ("reload")]
		void Reload ();

		[Async]
		[Export ("getPagePropertiesWithCompletionHandler:")]
		void GetPageProperties (Action<SFSafariPageProperties> completionHandler);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Protocol]
	interface SFSafariExtensionHandling
	{
		[Export ("messageReceivedWithName:fromPage:userInfo:")]
		void MessageReceived (string messageName, SFSafariPage page, [NullAllowed] NSDictionary userInfo);

		[Export ("toolbarItemClickedInWindow:")]
		void ToolbarItemClicked (SFSafariWindow window);

		[Async (ResultTypeName = "SFValidationResult")]
		[Export ("validateToolbarItemInWindow:validationHandler:")]
		void ValidateToolbarItem (SFSafariWindow window, Action<bool, NSString> validationHandler);

		[Export ("contextMenuItemSelectedWithCommand:inPage:userInfo:")]
		void ContextMenuItemSelected (string command, SFSafariPage page, [NullAllowed] NSDictionary userInfo);

		[Export ("popoverWillShowInWindow:")]
		void PopoverWillShow (SFSafariWindow window);

		[Export ("popoverDidCloseInWindow:")]
		void PopoverDidClose (SFSafariWindow window);

		[Export ("popoverViewController")]
		SFSafariExtensionViewController PopoverViewController { get; }

		[Introduced (PlatformName.MacOSX, 10, 12, 4)]
		[Async (ResultTypeName = "SFExtensionValidationResult")][Export ("validateContextMenuItemWithCommand:inPage:userInfo:validationHandler:")]
		void ValidateContextMenuItem (string command, SFSafariPage page, [NullAllowed] NSDictionary<NSString, NSObject> userInfo, SFExtensionValidationHandler validationHandler);

		[Introduced (PlatformName.MacOSX, 10, 12, 4)]
		[Export ("messageReceivedFromContainingAppWithName:userInfo:")]
		void MessageReceivedFromContainingApp (string messageName, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface SFSafariPageProperties
	{
		[Export ("url")]
		NSUrl Url { get; }

		[Export ("title")]
		string Title { get; }

		[Export ("usesPrivateBrowsing")]
		bool UsesPrivateBrowsing { get; }

		[Export ("active")]
		bool Active { [Bind ("isActive")] get; }
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFSafariTab
	{
		[Async]
		[Export ("getActivePageWithCompletionHandler:")]
		void GetActivePage (Action<SFSafariPage> completionHandler);

		[Async]
		[Export ("getPagesWithCompletionHandler:")]
		void GetPages (Action<SFSafariPage[]> completionHandler);

		[Async]
		[Export ("activateWithCompletionHandler:")]
		void Activate ([NullAllowed] Action completionHandler);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFSafariToolbarItem
	{
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'SetEnabled (bool)' or 'SetBadgeText' instead.")]
		[Export ("setEnabled:withBadgeText:")]
		void SetEnabled (bool enabled, [NullAllowed] string badgeText);

		[Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Export ("setEnabled:")]
		void SetEnabled (bool enabled);

		[Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Export ("setBadgeText:")]
		void SetBadgeText ([NullAllowed] string badgeText);

		[Introduced (PlatformName.MacOSX, 10, 12, 4, PlatformArchitecture.Arch64)]
		[Export ("setImage:")]
		void SetImage ([NullAllowed] NSImage image);

		[Introduced (PlatformName.MacOSX, 10, 13, PlatformArchitecture.Arch64)]
		[Export ("setLabel:")]
		void SetLabel ([NullAllowed] string label);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface SFSafariWindow
	{
		[Async]
		[Export ("getActiveTabWithCompletionHandler:")]
		void GetActiveTab (Action<SFSafariTab> completionHandler);

		[Async]
		[Export ("openTabWithURL:makeActiveIfPossible:completionHandler:")]
		void OpenTab (NSUrl url, bool activateTab, [NullAllowed] Action<SFSafariTab> completionHandler);

		[Async]
		[Export ("getToolbarItemWithCompletionHandler:")]
		void GetToolbarItem (Action<SFSafariToolbarItem> completionHandler);
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSViewController))]
	interface SFSafariExtensionViewController
	{
	}

	[Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	interface SFSafariExtensionHandler : NSExtensionRequestHandling, SFSafariExtensionHandling
	{
	}

//	TODO - Needs Safari Extension support to test
// 	[Mac (10,12)]
// 	[BaseType (typeof(NSObject))]
// 	interface SFSafariExtensionManager
// 	{
// 		[Static]
// 		[Export ("getStateOfSafariExtensionWithIdentifier:completionHandler:")]
// 		void GetStateOfSafariExtension (string identifier, Action<SFSafariExtensionState, NSError> completionHandler);
// 	}
//
// 	[Mac (10,12)]
// 	[BaseType (typeof(NSObject))]
// 	interface SFSafariExtensionState
// 	{
// 		[Export ("enabled")]
// 		bool Enabled { [Bind ("isEnabled")] get; }
// 	}
#endif
}

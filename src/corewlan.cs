// corewlan.cs: bindings for CoreWLAN
//
// Author:
//   Ashok Gelal, Chris Hamons
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using XamCore.Foundation;
using XamCore.CoreFoundation;
using XamCore.ObjCRuntime;
using XamCore.Security;
using System;

namespace XamCore.CoreWlan {

	[BaseType (typeof (NSObject))]
	interface CWChannel : NSCoding, NSSecureCoding, NSCopying {
		[Export ("channelNumber")]
		nint ChannelNumber { get; }
 
		[Export ("channelWidth")]
		CWChannelWidth ChannelWidth { get; }
 
		[Export ("channelBand")]
		CWChannelBand ChannelBand { get; }
 
		[Export ("isEqualToChannel:")]
		bool IsEqualToChannel (CWChannel channel);
	}

	[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
	[BaseType (typeof (NSObject))]
	interface CW8021XProfile : NSCoding, NSCopying {
		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("userDefinedName", ArgumentSemantic.Copy)]
		string UserDefinedName { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("ssid", ArgumentSemantic.Copy)]
		string Ssid { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("username", ArgumentSemantic.Copy)]
		string Username { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("password", ArgumentSemantic.Copy)]
		string Password { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("alwaysPromptForPassword")]
		bool AlwaysPromptForPassword{ get; set; }

		[Static]
		[Export ("profile")]
		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
		CW8021XProfile Profile { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
		[Export ("isEqualToProfile:")]
		bool IsEqualToProfile (CW8021XProfile profile);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("allUser8021XProfiles")]
		CW8021XProfile[] AllUser8021XProfiles { get; }
	}

	[BaseType (typeof (NSObject))]
	interface CWConfiguration : NSSecureCoding, NSMutableCopying {
		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("rememberedNetworks")]
		NSSet RememberedNetworks { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("preferredNetworks")]
		CWWirelessProfile[] PreferredNetworks { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("alwaysRememberNetworks")]
		bool AlwaysRememberNetworks { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("disconnectOnLogout")]
		bool DisconnectOnLogout { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("requireAdminForNetworkChange")]
		bool RequireAdminForNetworkChange { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("requireAdminForPowerChange")]
		bool RequireAdminForPowerChange { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("requireAdminForIBSSCreation")]
		bool RequireAdminForIBSSCreation { get; set; }

		[Export ("networkProfiles", ArgumentSemantic.Copy)]
		[Internal]
		NSOrderedSet _NetworkProfiles { get; }
 
		[Export ("requireAdministratorForAssociation", ArgumentSemantic.Assign)]
		bool RequireAdministratorForAssociation { get; }
 
		[Export ("requireAdministratorForPower", ArgumentSemantic.Assign)]
		bool RequireAdministratorForPower { get; }
 
		[Export ("requireAdministratorForIBSSMode", ArgumentSemantic.Assign)]
		bool RequireAdministratorForIbssMode { get; }
 
		[Export ("rememberJoinedNetworks", ArgumentSemantic.Assign)]
		bool RememberJoinedNetworks { get; }
 
		[Export ("initWithConfiguration:")]
		IntPtr Constructor (CWConfiguration configuration);

		[Export ("isEqualToConfiguration:")]
		bool IsEqualToConfiguration (CWConfiguration configuration);
	}

	[BaseType (typeof (CWConfiguration))]
	interface CWMutableConfiguration {
		[Export ("requireAdministratorForPower", ArgumentSemantic.Assign)]
		bool RequireAdministratorForPower { get; set; }

		[Export ("requireAdministratorForIBSSMode", ArgumentSemantic.Assign)]
		bool RequireAdministratorForIbssMode { get; set; }

		[Export ("rememberJoinedNetworks", ArgumentSemantic.Assign)]
		bool RememberJoinedNetworks { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface CWInterface {
		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsWoW")]
		bool SupportsWow { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsWEP")]
		bool SupportsWep { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsAES_CCM")]
		bool SupportsAesCcm { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsIBSS")]
		bool SupportsIbss { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsTKIP")]
		bool SupportsTkip { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsPMGT")]
		bool SupportsPmgt { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsHostAP")]
		bool SupportsHostAP { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsMonitorMode")]
		bool SupportsMonitorMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsWPA")]
		bool SupportsWpa { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsWPA2")]
		bool SupportsWpa2 { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsWME")]
		bool SupportsWme { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsShortGI40MHz")]
		bool SupportsShortGI40MHz { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsShortGI20MHz")]
		bool SupportsShortGI20MHz { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportsTSN")]
		bool SupportsTsn { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("power")]
		bool Power { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("powerSave")]
		bool PowerSave { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("name")]
		string Name { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportedChannels")]
		NSNumber[] SupportedChannels { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("supportedPHYModes")]
		NSNumber[] SupportedPhyModes { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("channel")]
		NSNumber Channel { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("phyMode")]
		NSNumber PhyMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("bssidData")]
		NSData BssidData { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("rssi")]
		NSNumber Rssi { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("noise")]
		NSNumber Noise { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("txRate")]
		NSNumber TxRate { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("securityMode")]
		NSNumber SecurityMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("interfaceState")]
		NSNumber InterfaceState { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("opMode")]
		NSNumber OpMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("txPower")]
		NSNumber TxPower { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Static]
		[Export ("supportedInterfaces")]
		string[] SupportedInterfaces { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Static]
		[Export ("interface")]
		CWInterface MainInterface { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Static]
		[Export ("interfaceWithName:")]
		CWInterface FromName (string name);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("isEqualToInterface:")]
		bool IsEqualToInterface (CWInterface intface);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("setChannel:error:")]
		bool SetChannel (nuint channel, out NSError error);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("scanForNetworksWithParameters:error:")]
		CWNetwork[] ScanForNetworksWithParameters ([NullAllowed] NSDictionary parameters, out NSError error);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("associateToNetwork:parameters:error:")]
		bool AssociateToNetwork (CWNetwork network, [NullAllowed] NSDictionary parameters, out NSError error);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("enableIBSSWithParameters:error:")]
		bool EnableIBSSWithParameters ([NullAllowed] NSDictionary parameters, out NSError error);

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("commitConfiguration:error:")]
		bool CommitConfiguration (CWConfiguration config, out NSError error);

		[Export ("powerOn", ArgumentSemantic.Assign)]
		bool PowerOn { get; }
		 
		[Export ("interfaceName", ArgumentSemantic.Copy)]
		string InterfaceName { get; }
		 
		[Export ("supportedWLANChannels")]
		[Internal]
		NSSet _SupportedWlanChannels { get; }

		[Export ("wlanChannel")]
		CWChannel WlanChannel { get; }
		 
		[Export ("activePHYMode")]
		CWPhyMode ActivePHYMode { get; }
		 
		[Export ("ssid")]
		string Ssid { get; }
		 
		[Export ("ssidData")]
		NSData SsidData { get; }
		 
		[Export ("bssid")]
		string Bssid { get; }
		 
		[Export ("rssiValue")]
		nint RssiValue { get; }
		 
		[Export ("noiseMeasurement")]
		nint NoiseMeasurement { get; }
		 
		[Export ("security")]
		CWSecurity Security { get; }
		 
		[Export ("transmitRate")]
		double TransmitRate { get; }
		 
		[Export ("countryCode")]
		string CountryCode { get; }
		 
		[Export ("interfaceMode")]
		CWInterfaceMode InterfaceMode { get; }
		 
		[Export ("transmitPower")]
		nint TransmitPower { get; }
		 
		[Export ("hardwareAddress")]
		string HardwareAddress { get; }
		 
		[Export ("deviceAttached", ArgumentSemantic.Assign)]
		bool DeviceAttached { get; }
		 
		[Export ("serviceActive")]
		bool ServiceActive { get; }
		 
		[Export ("cachedScanResults")]
		[Internal]
		NSSet _CachedScanResults { get; }
		 
		[Export ("configuration")]
		CWConfiguration Configuration { get; }
		 
		[Static]
		[Export ("interfaceNames")]
		[Internal]
		NSSet _InterfaceNames { get; }
		 
		[Export ("initWithInterfaceName:")]
		IntPtr Constructor (string name);
		 
		[Export ("setPower:error:")]
		bool SetPower (bool power, out NSError error);
		 
		[Export ("setWLANChannel:error:")]
		bool SetWlanChannel (CWChannel channel, out NSError error);
		 
		[Export ("setPairwiseMasterKey:error:")]
		bool SetPairwiseMasterKey (NSData key, out NSError error);
		 
		[Export ("setWEPKey:flags:index:error:")]
		bool SetWEPKey (NSData key, CWCipherKeyFlags flags, nint index, out NSError error);
		 
		[Export ("scanForNetworksWithSSID:error:")]
		[Internal]
		NSSet _ScanForNetworksWithSsid ([NullAllowed] NSData ssid, out NSError error);
		 
		[Export ("scanForNetworksWithName:error:")]
		[Internal]
		NSSet _ScanForNetworksWithName ([NullAllowed] string networkName, out NSError error);
		 
		[Export ("associateToNetwork:password:error:")]
		bool AssociateToNetwork (CWNetwork network, string password, out NSError error);
		 
		[Export ("associateToEnterpriseNetwork:identity:username:password:error:")]
		bool AssociateToEnterpriseNetwork (CWNetwork network, SecIdentity identity, string username, string password, out NSError error);
		 
		[Export ("startIBSSModeWithSSID:security:channel:password:error:")]
		bool StartIbssModeWithSsid (NSData ssidData, CWIbssModeSecurity security, nuint channel, string password, out NSError error);
		 
		[Export ("disassociate")]
		void Disassociate ();
		 
		[Export ("commitConfiguration:authorization:error:")]
		bool CommitConfiguration (CWConfiguration configuration, NSObject authorization, out NSError error);

		[Introduced (PlatformName.MacOSX, 10, 13)]
		[Export ("scanForNetworksWithSSID:includeHidden:error:")]
		[return: NullAllowed]
		[Internal]
		NSSet _ScanForNetworksWithSsid ([NullAllowed] NSData ssid, bool includeHidden, [NullAllowed] out NSError error);

		[Introduced (PlatformName.MacOSX, 10, 13)]
		[Export ("scanForNetworksWithName:includeHidden:error:")]
		[return: NullAllowed]
		[Internal]
		NSSet _ScanForNetworksWithName ([NullAllowed] string networkName, bool includeHidden, [NullAllowed] out NSError error);
	}

	[BaseType (typeof (NSObject))]
	[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
	interface CWWirelessProfile : NSCoding, NSCopying {
		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("ssid", ArgumentSemantic.Copy)]
		string Ssid { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("securityMode", ArgumentSemantic.Retain)]
		NSNumber SecurityMode { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("passphrase", ArgumentSemantic.Copy)]
		string Passphrase { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 10)]
		[Export ("user8021XProfile", ArgumentSemantic.Retain)]
		CW8021XProfile User8021XProfile { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("isEqualToProfile:")]
		bool IsEqualToProfile (CWWirelessProfile profile);
	}

	[BaseType (typeof (NSObject))]
	interface CWNetwork : NSSecureCoding, NSCopying {
		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("bssidData")]
		NSData BssidData { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("securityMode")]
		NSNumber SecurityMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("phyMode")]
		NSNumber PhyMode { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("channel")]
		NSNumber Channel { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("rssi")]
		NSNumber Rssi { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("noise")]
		NSNumber Noise { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("ieData")]
		NSData IeData { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("isIBSS")]
		bool IsIBSS { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7), Obsoleted (PlatformName.MacOSX, 10, 9)]
		[Export ("wirelessProfile")]
		CWWirelessProfile WirelessProfile { get; }

		[Export ("ssid")]
		string Ssid { get; }
		 
		[Export ("ssidData")]
		NSData SsidData { get; }
		 
		[Export ("bssid")]
		string Bssid { get; }
		 
		[Export ("wlanChannel")]
		CWChannel WlanChannel { get; }
		 
		[Export ("rssiValue")]
		nint RssiValue { get; }
		 
		[Export ("noiseMeasurement")]
		nint NoiseMeasurement { get; }
		 
		[Export ("informationElementData")]
		NSData InformationElementData { get; }
		 
		[Export ("countryCode")]
		string CountryCode { get; }
		 
		[Export ("beaconInterval")]
		nint BeaconInterval { get; }
		 
		[Export ("ibss")]
		bool Ibss { get; }
		 
		[Export ("isEqualToNetwork:")]
		bool IsEqualToNetwork (CWNetwork network);
		 
		[Export ("supportsSecurity:")]
		bool SupportsSecurity (CWSecurity security);
		 
		[Export ("supportsPHYMode:")]
		bool SupportsPhyMode (CWPhyMode phyMode);
	}

	[BaseType (typeof (NSObject))]
	interface CWNetworkProfile : NSCoding, NSSecureCoding, NSCopying, NSMutableCopying 
	{
		[Export ("ssid", ArgumentSemantic.Copy)]
		string Ssid { get; }

		[Export ("ssidData", ArgumentSemantic.Copy)]
		NSData SsidData { get; }

		[Export ("security", ArgumentSemantic.Assign)]
		CWSecurity Security { get; }

		[Static]
		[Export ("networkProfile")]
		NSObject NetworkProfile ();

		[Export ("initWithNetworkProfile:")]
		IntPtr Constructor (CWNetworkProfile networkProfile);

		[Static]
		[Export ("networkProfileWithNetworkProfile:")]
		NSObject NetworkProfileWithNetworkProfile (CWNetworkProfile networkProfile);

		[Export ("isEqualToNetworkProfile:")]
		bool IsEqualToNetworkProfile (CWNetworkProfile networkProfile);
	}

	[BaseType (typeof (CWNetworkProfile))]
	interface CWMutableNetworkProfile : NSCoding, NSSecureCoding, NSCopying, NSMutableCopying  
	{
	}

	[Introduced (PlatformName.MacOSX, 10, 10)] 
	[BaseType (typeof (NSObject))]
	interface CWWiFiClient
	{
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		ICWEventDelegate Delegate { get; set; }
		
		[Export ("interface")]
		CWInterface MainInterface { get; }

		[Export ("interfaceWithName:")]
		CWInterface FromName ([NullAllowed] string name);

		[Export ("interfaces")]
		CWInterface[] Interfaces { get; }

		[Export ("interfaceNames")]
		[Static]
		string[] InterfaceNames { get; }

		[Export ("sharedWiFiClient")]
		[Static]
		CWWiFiClient SharedWiFiClient { get; }

		[Export ("startMonitoringEventWithType:error:")]
		bool StartMonitoringEvent (CWEventType type, out NSError error);

		[Export ("stopMonitoringAllEventsAndReturnError:")]
		bool StopMonitoringAllEvents (out NSError error);

		[Export ("stopMonitoringEventWithType:error:")]
		bool StopMonitoringEvent (CWEventType type, out NSError error);
	}
	
	interface ICWEventDelegate { }
	
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface CWEventDelegate
	{
		[Export ("clientConnectionInterrupted")]
		void ClientConnectionInterrupted ();
		
		[Export ("clientConnectionInvalidated")]
		void ClientConnectionInvalidated ();
		
		[Export ("powerStateDidChangeForWiFiInterfaceWithName:")]
		void PowerStateDidChangeForWiFi (string interfaceName);
		
		[Export ("ssidDidChangeForWiFiInterfaceWithName:")]
		void SsidDidChangeForWiFi (string interfaceName);
		
		[Export ("bssidDidChangeForWiFiInterfaceWithName:")]
		void BssidDidChangeForWiFi (string interfaceName);
		
		[Export ("countryCodeDidChangeForWiFiInterfaceWithName:")]
		void CountryCodeDidChangeForWiFi (string interfaceName);
		
		[Export ("linkDidChangeForWiFiInterfaceWithName:")]
		void LinkDidChangeForWiFi (string interfaceName);
		
		[Export ("linkQualityDidChangeForWiFiInterfaceWithName:rssi:transmitRate:")]
		void LinkQualityDidChangeForWiFi (string interfaceName, int rssi, double transmitRate);
		
		[Export ("modeDidChangeForWiFiInterfaceWithName:")]
		void ModeDidChangeForWiFi (string interfaceName);
		
		[Export ("scanCacheUpdatedForWiFiInterfaceWithName:")]
		void ScanCacheUpdatedForWiFi (string interfaceName);
	}
}

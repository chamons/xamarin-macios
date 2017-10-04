using System;
using System.Threading.Tasks;
using XamCore.ObjCRuntime;

namespace XamCore.VideoSubscriberAccount {

	public partial class VSAccountMetadataRequest {

		[Introduced (PlatformName.TvOS, 10, 1)][Introduced (PlatformName.iOS, 10, 2)]
		public VSAccountProviderAuthenticationScheme[] SupportedAuthenticationSchemes {
			get {
				return VSAccountProviderAuthenticationSchemeExtensions.GetValues (SupportedAuthenticationSchemesString);
			}
			set {
				SupportedAuthenticationSchemesString = value?.GetConstants ();
			}
		}
	}
}

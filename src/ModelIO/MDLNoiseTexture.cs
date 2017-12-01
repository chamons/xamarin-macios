#if XAMCORE_2_0 || !MONOMAC
using System;
using XamCore.ObjCRuntime;
using Vector2i = global::OpenTK.Vector2i;

namespace XamCore.ModelIO {

	[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	public enum  MDLNoiseTextureType {
		Vector,
		Cellular,
	}

	public partial class MDLNoiseTexture {
		[Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
		public MDLNoiseTexture (float input, string name, Vector2i textureDimensions, MDLTextureChannelEncoding channelEncoding) : this (input, name, textureDimensions, channelEncoding, MDLNoiseTextureType.Vector)
		{
		}

		[Introduced (PlatformName.iOS, 10, 2), Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		public MDLNoiseTexture (float input, string name, Vector2i textureDimensions, MDLTextureChannelEncoding channelEncoding, MDLNoiseTextureType type)
		{
			// two different `init*` would share the same C# signature
			switch (type) {
			case MDLNoiseTextureType.Vector:
				Handle = InitVectorNoiseWithSmoothness (input, name, textureDimensions, channelEncoding);
				break;
			case MDLNoiseTextureType.Cellular:
				Handle = InitCellularNoiseWithFrequency (input, name, textureDimensions, channelEncoding);
				break;
			default:
				throw new ArgumentException ("type");
			}
		}
	}
}
#endif
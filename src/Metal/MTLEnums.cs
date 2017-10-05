#if XAMCORE_2_0 || !MONOMAC
//
// API for the Metal framework
//
// Authors:
//   Miguel de Icaza
//
// Copyrigh 2014, Xamarin Inc.
//
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Foundation;
using ModelIO;
using ObjCRuntime;

namespace Metal {

	[Native]
	public enum MTLBlendFactor : ulong {
		Zero = 0,
		One = 1,
		SourceColor = 2,
		OneMinusSourceColor = 3,
		SourceAlpha = 4,
		OneMinusSourceAlpha = 5,
		DestinationColor = 6,
		OneMinusDestinationColor = 7,
		DestinationAlpha = 8,
		OneMinusDestinationAlpha = 9,
		SourceAlphaSaturated = 10,
		BlendColor = 11,
		OneMinusBlendColor = 12,
		BlendAlpha = 13,
		OneMinusBlendAlpha = 14,
	}

	[Native]
	public enum MTLBlendOperation : ulong {
		Add = 0,
		Subtract = 1,
		ReverseSubtract = 2,
		Min = 3,
		Max = 4,
	}

	[Native]
	[Flags]
	public enum MTLColorWriteMask : ulong {
		None = 0,
		Red   = 0x1 << 3,
		Green = 0x1 << 2,
		Blue  = 0x1 << 1,
		Alpha = 0x1 << 0,
		All   = 0xf
	}

	[Native]
	public enum MTLCommandBufferStatus : ulong {
		NotEnqueued,
		Enqueued,
		Committed,
		Scheduled,
		Completed,
		Error
	}

	[Native]
	[ErrorDomain ("MTLCommandBufferErrorDomain")]
	public enum MTLCommandBufferError : ulong {
		None = 0,
		Internal = 1,
		Timeout = 2,
		PageFault = 3,
		Blacklisted = 4,
		NotPermitted = 7,
		OutOfMemory = 8,
		InvalidResource = 9,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		Memoryless = 10,
		[Introduced (PlatformName.MacOSX, 10, 13), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		DeviceRemoved = 11,
	}

	[Native]
	public enum MTLLoadAction : ulong {
		DontCare, Load, Clear
	}

	[Native]
	public enum MTLStoreAction : ulong {
		DontCare, Store, MultisampleResolve,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
		StoreAndMultisampleResolve,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
		Unknown,
		[Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13)]
		CustomSampleDepthStore,
	}

	[Native]
	public enum MTLTextureType : ulong {
		k1D = 0,
		k1DArray = 1,
		k2D = 2,
		k2DArray = 3,
		k2DMultisample = 4,
		kCube = 5,
#if MONOMAC
		kCubeArray = 6,
#endif
		k3D = 7,
	}

	[Native]
	public enum MTLSamplerMinMagFilter : ulong {
		Nearest, Linear
	}

	[Native]
	public enum MTLSamplerMipFilter : ulong {
		NotMipmapped,
		Nearest,
		Linear
	}

	[Native]
	public enum MTLSamplerAddressMode : ulong {
		ClampToEdge = 0,
#if MONOMAC
		MirrorClampToEdge = 1,
#endif
		Repeat = 2,
		MirrorRepeat = 3,
		ClampToZero = 4,
		
		[Introduced (PlatformName.MacOSX, 10, 12)]
		ClampToBorderColor = 5,
	}

	[Native]
	public enum MTLVertexFormat : ulong {
		Invalid = 0,
		
		UChar2 = 1,
		UChar3 = 2,
		UChar4 = 3,
		
		Char2 = 4,
		Char3 = 5,
		Char4 = 6,
		
		UChar2Normalized = 7,
		UChar3Normalized = 8,
		UChar4Normalized = 9,
		
		Char2Normalized = 10,
		Char3Normalized = 11,
		Char4Normalized = 12,
		
		UShort2 = 13,
		UShort3 = 14,
		UShort4 = 15,
		
		Short2 = 16,
		Short3 = 17,
		Short4 = 18,
		
		UShort2Normalized = 19,
		UShort3Normalized = 20,
		UShort4Normalized = 21,
		
		Short2Normalized = 22,
		Short3Normalized = 23,
		Short4Normalized = 24,
		
		Half2 = 25,
		Half3 = 26,
		Half4 = 27,
		
		Float = 28,
		Float2 = 29,
		Float3 = 30,
		Float4 = 31,
		Int = 32,
		Int2 = 33,
		Int3 = 34,
		Int4 = 35,
		
		UInt = 36,
		UInt2 = 37,
		UInt3 = 38,
		UInt4 = 39,
		
		Int1010102Normalized = 40,
		UInt1010102Normalized = 41,

		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UChar4NormalizedBgra = 42,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UChar = 45,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Char = 46,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UCharNormalized = 47,

		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		CharNormalized = 48,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UShort = 49,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Short = 50,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UShortNormalized = 51,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		ShortNormalized = 52,
		
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Half = 53,
	}

	[Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum MTLPixelFormat : ulong {
		Invalid = 0,
		A8Unorm = 1,
		R8Unorm = 10,
		// Mac only (but it was exposed in earlier XI versions)
#if MONOMAC
		R8Unorm_sRGB = 11,
#elif !XAMCORE_3_0
		[Obsolete ("Only available on macOS.")]
		R8Unorm_sRGB = 11,
#endif
		R8Snorm = 12,
		R8Uint = 13,
		R8Sint = 14,
		R16Unorm = 20,
		R16Snorm = 22,
		R16Uint = 23,
		R16Sint = 24,
		R16Float = 25,
		RG8Unorm = 30,
#if !MONOMAC
		RG8Unorm_sRGB = 31,
#endif
		RG8Snorm = 32,
		RG8Uint = 33,
		RG8Sint = 34,
#if !MONOMAC
		B5G6R5Unorm = 40,
		A1BGR5Unorm = 41,
		ABGR4Unorm = 42,
		BGR5A1Unorm = 43,
#endif
		R32Uint = 53,
		R32Sint = 54,
		R32Float = 55,
		RG16Unorm = 60,
		RG16Snorm = 62,
		RG16Uint = 63,
		RG16Sint = 64,
		RG16Float = 65,
		RGBA8Unorm = 70,
		RGBA8Unorm_sRGB = 71,
		RGBA8Snorm = 72,
		RGBA8Uint = 73,
		RGBA8Sint = 74,
		BGRA8Unorm = 80,
		BGRA8Unorm_sRGB = 81,
		RGB10A2Unorm = 90,
		RGB10A2Uint = 91,
		RG11B10Float = 92,
		RGB9E5Float = 93,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		BGR10A2Unorm = 94,
		RG32Uint = 103,
		RG32Sint = 104,
		RG32Float = 105,
		RGBA16Unorm = 110,
		RGBA16Snorm = 112,
		RGBA16Uint = 113,
		RGBA16Sint = 114,
		RGBA16Float = 115,
		RGBA32Uint = 123,
		RGBA32Sint = 124,
		RGBA32Float = 125,
#if MONOMAC
		BC1RGBA = 130,
		BC1_RGBA_sRGB = 131,
		BC2RGBA = 132,
		BC2_RGBA_sRGB = 133,
		BC3RGBA = 134,
		BC3_RGBA_sRGB = 135,
		BC4_RUnorm = 140,
		BC4_RSnorm = 141,
		BC5_RGUnorm = 142,
		BC5_RGSnorm = 143,
		BC6H_RGBFloat = 150,
		BC6H_RGBUFloat = 151,
		BC7_RGBAUnorm = 152,
		BC7_RGBAUnorm_sRGB = 153,
#else
		PVRTC_RGB_2BPP = 160,
		PVRTC_RGB_2BPP_sRGB = 161,
		PVRTC_RGB_4BPP = 162,
		PVRTC_RGB_4BPP_sRGB = 163,
		PVRTC_RGBA_2BPP = 164,
		PVRTC_RGBA_2BPP_sRGB = 165,
		PVRTC_RGBA_4BPP = 166,
		PVRTC_RGBA_4BPP_sRGB = 167,
		EAC_R11Unorm = 170,
		EAC_R11Snorm = 172,
		EAC_RG11Unorm = 174,
		EAC_RG11Snorm = 176,
		EAC_RGBA8 = 178,
		EAC_RGBA8_sRGB = 179,
		ETC2_RGB8 = 180,
		ETC2_RGB8_sRGB = 181,
		ETC2_RGB8A1 = 182,
		ETC2_RGB8A1_sRGB = 183,

		
		ASTC_4x4_sRGB           = 186,
		ASTC_5x4_sRGB           = 187,
		ASTC_5x5_sRGB           = 188,
		ASTC_6x5_sRGB           = 189,
		ASTC_6x6_sRGB           = 190,
		ASTC_8x5_sRGB           = 192,
		ASTC_8x6_sRGB           = 193,
		ASTC_8x8_sRGB           = 194,
		ASTC_10x5_sRGB          = 195,
		ASTC_10x6_sRGB          = 196,
		ASTC_10x8_sRGB          = 197,
		ASTC_10x10_sRGB         = 198,
		ASTC_12x10_sRGB         = 199,
		ASTC_12x12_sRGB         = 200,
		
		ASTC_4x4_LDR            = 204,
		ASTC_5x4_LDR            = 205,
		ASTC_5x5_LDR            = 206,
		ASTC_6x5_LDR            = 207,
		ASTC_6x6_LDR            = 208,
		ASTC_8x5_LDR            = 210,
		ASTC_8x6_LDR            = 211,
		ASTC_8x8_LDR            = 212,
		ASTC_10x5_LDR           = 213,
		ASTC_10x6_LDR           = 214,
		ASTC_10x8_LDR           = 215,
		ASTC_10x10_LDR          = 216,
		ASTC_12x10_LDR          = 217,
		ASTC_12x12_LDR          = 218,
#endif
			
		GBGR422 = 240,
		BGRG422 = 241,
		Depth32Float = 252,
		Stencil8 = 253,
#if MONOMAC
		Depth24Unorm_Stencil8 = 255,
#endif
		[Introduced (PlatformName.iOS, 9, 0)]
		Depth32Float_Stencil8 = 260,
	
		[Unavailable (PlatformName.WatchOS), Introduced (PlatformName.iOS, 9, 0), Introduced (PlatformName.TvOS, 9, 0), Introduced (PlatformName.MacOSX, 10, 11)]
		X32_Stencil8 = 261,
#if MONOMAC
		[Introduced (PlatformName.MacOSX, 10, 12)]
		X24_Stencil8 = 262,
#endif
	}

	[Native]
	public enum MTLFunctionType : ulong {
		Vertex = 1,
		Fragment = 2,
		Kernel = 3
	}

	[Native]
	[ErrorDomain ("MTLLibraryErrorDomain")]
	public enum MTLLibraryError : ulong {
		Unsupported = 1,
		Internal,
		CompileFailure,
		CompileWarning,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
		FunctionNotFound,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
		FileNotFound,
	}

	[Native]
	[ErrorDomain ("MTLRenderPipelineErrorDomain")]
	public enum MTLRenderPipelineError : ulong {
		Internal = 1, Unsupported, InvalidInput
	}

	[Native]
	public enum MTLCompareFunction : ulong {
		Never = 0,
		Less = 1,
		Equal = 2,
		LessEqual = 3,
		Greater = 4,
		NotEqual = 5,
		GreaterEqual = 6,
		Always = 7
	}


	[Native]
	public enum MTLStencilOperation : ulong {
		Keep = 0,
		Zero = 1,
		Replace = 2,
		IncrementClamp = 3,
		DecrementClamp = 4,
		Invert = 5,
		IncrementWrap = 6,
		DecrementWrap = 7
	}

	[Native]
	public enum MTLPrimitiveType : ulong {
		Point = 0,
		Line = 1,
		LineStrip = 2,
		Triangle = 3,
		TriangleStrip = 4
	}

	[Native]
	public enum MTLIndexType : ulong {
		UInt16, UInt32
	} 

	[Native]
	public enum MTLVisibilityResultMode : ulong {
		Disabled = 0,
		Boolean = 1,
		Counting = 2,
	}

	[Native]
	public enum MTLCullMode : ulong {
		None = 0,
		Front = 1,
		Back = 2
	}

	[Native]
	public enum MTLWinding : ulong {
		Clockwise = 0, CounterClockwise = 1
	}

	[Native]
	public enum MTLTriangleFillMode : ulong {
		Fill, Lines
	}

	[Native]
	public enum MTLPurgeableState : ulong {
		KeepCurrent = 1,
		NonVolatile = 2,
		Volatile = 3,
		Empty = 4
	}

	[Native]
	public enum MTLCpuCacheMode : ulong {
		DefaultCache, WriteCombined
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[Flags]
	public enum MTLTextureUsage : ulong {
		Unknown         = 0x0000,
		ShaderRead      = 0x0001,
		ShaderWrite     = 0x0002,
		RenderTarget    = 0x0004,
		Blit            = 0x0008,
		PixelFormatView = 0x0010,
	}

	[Introduced (PlatformName.iOS, 8, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[Flags]
	public enum MTLResourceOptions : ulong {
		CpuCacheModeDefault = MTLCpuCacheMode.DefaultCache << 0,
		CpuCacheModeWriteCombined = MTLCpuCacheMode.WriteCombined << 0,
		
		[Introduced (PlatformName.iOS, 9, 0)]
		StorageModeShared = MTLStorageMode.Shared << 4,
#if MONOMAC
		StorageModeManaged = MTLStorageMode.Managed << 4,
#endif
		[Introduced (PlatformName.iOS, 9, 0)]
		StorageModePrivate = MTLStorageMode.Private << 4,
		
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		StorageModeMemoryless = MTLStorageMode.Memoryless << 4,

		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 13)]
		HazardTrackingModeUntracked = 1 << 8,
	}

	// MTLVertexDescriptor.h
	[Native]
	public enum MTLVertexStepFunction : ulong {
		Constant, PerVertex, PerInstance,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]	
		PerPatch = 3,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]	
		PerPatchControlPoint = 4,
	}

	[Native]
	public enum MTLDataType : ulong {
		
		None = 0,
		
		Struct = 1,
		Array  = 2,
		
		Float  = 3,
		Float2 = 4,
		Float3 = 5,
		Float4 = 6,
		
		Float2x2 = 7,
		Float2x3 = 8,
		Float2x4 = 9,
		
		Float3x2 = 10,
		Float3x3 = 11,
		Float3x4 = 12,
		
		Float4x2 = 13,
		Float4x3 = 14,
		Float4x4 = 15,
		
		Half  = 16,
		Half2 = 17,
		Half3 = 18,
		Half4 = 19,
		
		Half2x2 = 20,
		Half2x3 = 21,
		Half2x4 = 22,
		
		Half3x2 = 23,
		Half3x3 = 24,
		Half3x4 = 25,
		
		Half4x2 = 26,
		Half4x3 = 27,
		Half4x4 = 28,
		
		Int  = 29,
		Int2 = 30,
		Int3 = 31,
		Int4 = 32,
		
		UInt  = 33,
		UInt2 = 34,
		UInt3 = 35,
		UInt4 = 36,
		
		Short  = 37,
		Short2 = 38,
		Short3 = 39,
		Short4 = 40,
		
		UShort = 41,
		UShort2 = 42,
		UShort3 = 43,
		UShort4 = 44,
		
		Char  = 45,
		Char2 = 46,
		Char3 = 47,
		Char4 = 48,
		
		UChar  = 49,
		UChar2 = 50,
		UChar3 = 51,
		UChar4 = 52,
		
		Bool  = 53,
		Bool2 = 54,
		Bool3 = 55,
		Bool4 = 56,

		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)] Texture = 58,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)] Sampler = 59,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)] Pointer = 60,

		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] R8Unorm = 62,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] R8Snorm = 63,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] R16Unorm = 64,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] R16Snorm = 65,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rg8Unorm = 66,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rg8Snorm = 67,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rg16Unorm = 68,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rg16Snorm = 69,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgba8Unorm = 70,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgba8Unorm_sRgb = 71,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgba8Snorm = 72,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgba16Unorm = 73,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgba16Snorm = 74,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgb10A2Unorm = 75,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rg11B10Float = 76,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Rgb9E5Float = 77,
	}

	[Native]
	public enum MTLArgumentType : ulong {
		Buffer = 0,
		ThreadgroupMemory= 1,
		Texture = 2,
		Sampler = 3,

		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] ImageblockData = 16,
		[Unavailable (PlatformName.MacOSX), Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)] Imageblock = 17,
	}

	[Native]
	public enum MTLArgumentAccess : ulong {
		ReadOnly, ReadWrite, WriteOnly
	}

	[Native]
	[Flags]
	public enum MTLPipelineOption : ulong {
		None, ArgumentInfo, BufferTypeInfo
	}

	[Native]
	public enum MTLFeatureSet : ulong {
		iOS_GPUFamily1_v1 = 0,
		iOS_GPUFamily1_v2 = 2,
		iOS_GPUFamily2_v1 = 1,
		iOS_GPUFamily2_v2 = 3,
		iOS_GPUFamily3_v1 = 4,
		[Introduced (PlatformName.iOS, 10, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily1_v3 = 5,
		[Introduced (PlatformName.iOS, 10, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily2_v3 = 6,
		[Introduced (PlatformName.iOS, 10, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily3_v2 = 7,
		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily1_v4 = 8,
		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily2_v4 = 9,
		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily3_v3 = 10,
		[Introduced (PlatformName.iOS, 11, 0), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		iOS_GPUFamily4_v1 = 11,

		[Introduced (PlatformName.MacOSX, 10, 11), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		macOS_GPUFamily1_v1 = 10000,
		
		[Introduced (PlatformName.MacOSX, 10, 11, message: "Use 'macOS_GPUFamily1_v1' instead."), Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'macOS_GPUFamily1_v1' instead.")]
		OSX_GPUFamily1_v1 = macOS_GPUFamily1_v1,
		
		[Introduced (PlatformName.MacOSX, 10, 13), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		macOS_GPUFamily1_v2 = 10001,
		[Introduced (PlatformName.MacOSX, 10, 12, message: "Use 'macOS_GPUFamily1_v2' instead."), Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'macOS_GPUFamily1_v2' instead.")]
		OSX_GPUFamily1_v2 = macOS_GPUFamily1_v2,
		
		[Introduced (PlatformName.MacOSX, 10, 13), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		macOS_ReadWriteTextureTier2 = 10002,
		[Introduced (PlatformName.MacOSX, 10, 12, message: "Use 'macOS_ReadWriteTextureTier2' instead."), Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'macOS_ReadWriteTextureTier2' instead.")]
		OSX_ReadWriteTextureTier2 = macOS_ReadWriteTextureTier2,
		
		[Introduced (PlatformName.MacOSX, 10, 13), Unavailable (PlatformName.iOS), Unavailable (PlatformName.TvOS), Unavailable (PlatformName.WatchOS)]
		macOS_GPUFamily1_v3 = 10003,

		[Introduced (PlatformName.TvOS, 9, 0)]
		TVOS_GPUFamily1_v1 = 30000,

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		tvOS_GPUFamily1_v2 = 30001,

		[Unavailable (PlatformName.iOS), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		tvOS_GPUFamily2_v1 = 30003,
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum MTLLanguageVersion : ulong {
#if !MONOMAC
		v1_0 = (1 << 16),
#endif
		v1_1 = (1 << 16) + 1,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
		v1_2 = (1 << 16) + 2,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		v2_0 = (2 << 16),
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum MTLDepthClipMode : ulong {
		Clip = 0,
		Clamp = 1
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[Flags]
	public enum MTLBlitOption : ulong {
		None = 0,
		DepthFromDepthStencil = 1 << 0,
		StencilFromDepthStencil = 1 << 1,
#if !MONOMAC
		RowLinearPvrtc = 1 << 2
#endif
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum MTLStorageMode : ulong {
		Shared = 0,
#if MONOMAC
		Managed = 1,
#endif
		Private = 2,
		[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.MacOSX)]
		Memoryless = 3,
	}

	[Native]
	public enum MTLMultisampleDepthResolveFilter : ulong{
		Sample0, Min, Max
	}

#if XAMCORE_4_0
	[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
#endif
	[Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLSamplerBorderColor : ulong {
		TransparentBlack = 0,
		OpaqueBlack = 1,
		OpaqueWhite = 2
	}

	[Unavailable (PlatformName.TvOS)]
	[Unavailable (PlatformName.iOS), Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum MTLPrimitiveTopologyClass : ulong {
		Unspecified = 0,
		Point = 1,
		Line = 2,
		Triangle = 3
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLTessellationPartitionMode : ulong {
		Pow2 = 0,
		Integer = 1,
		FractionalOdd = 2,
		FractionalEven = 3
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLTessellationFactorFormat : ulong {
		Half = 0
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLTessellationControlPointIndexType : ulong {
		None = 0,
		UInt16 = 1,
		UInt32 = 2
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLTessellationFactorStepFunction : ulong {
		Constant = 0,
		PerPatch = 1,
		PerInstance = 2,
		PerPatchAndPerInstance = 3
	}
	
	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLPatchType : ulong {
		None = 0,
		Triangle = 1,
		Quad = 2
	}
	
	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLAttributeFormat : ulong {
		Invalid = 0,
		UChar2 = 1,
		UChar3 = 2,
		UChar4 = 3,
		Char2 = 4,
		Char3 = 5,
		Char4 = 6,
		UChar2Normalized = 7,
		UChar3Normalized = 8,
		UChar4Normalized = 9,
		Char2Normalized = 10,
		Char3Normalized = 11,
		Char4Normalized = 12,
		UShort2 = 13,
		UShort3 = 14,
		UShort4 = 15,
		Short2 = 16,
		Short3 = 17,
		Short4 = 18,
		UShort2Normalized = 19,
		UShort3Normalized = 20,
		UShort4Normalized = 21,
		Short2Normalized = 22,
		Short3Normalized = 23,
		Short4Normalized = 24,
		Half2 = 25,
		Half3 = 26,
		Half4 = 27,
		Float = 28,
		Float2 = 29,
		Float3 = 30,
		Float4 = 31,
		Int = 32,
		Int2 = 33,
		Int3 = 34,
		Int4 = 35,
		UInt = 36,
		UInt2 = 37,
		UInt3 = 38,
		UInt4 = 39,
		Int1010102Normalized = 40,
		UInt1010102Normalized = 41,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UChar4Normalized_Bgra = 42,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UChar = 45,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Char = 46,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UCharNormalized = 47,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		CharNormalized = 48,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UShort = 49,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Short = 50,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		UShortNormalized = 51,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		ShortNormalized = 52,
		[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
		Half = 53,
	}
	
	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLStepFunction : ulong {
		Constant = 0,
		PerVertex = 1,
		PerInstance = 2,
		PerPatch = 3,
		PerPatchControlPoint = 4,
		ThreadPositionInGridX = 5,
		ThreadPositionInGridY = 6,
		ThreadPositionInGridXIndexed = 7,
		ThreadPositionInGridYIndexed = 8
	}

	[Introduced (PlatformName.iOS, 10, 0), Introduced (PlatformName.TvOS, 10, 0), Unavailable (PlatformName.WatchOS), Introduced (PlatformName.MacOSX, 10, 12)]
	[Native]
	public enum MTLRenderStages : ulong {
		Vertex = (1 << 0),
		Fragment = (1 << 1)
	}

	[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
	[Native, Flags]
	public enum MTLResourceUsage : ulong
	{
		Read = 1 << 0,
		Write = 1 << 1,
		Sample = 1 << 2,
	}

	[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MTLMutability : ulong
	{
		Default = 0,
		Mutable = 1,
		Immutable = 2,
	}

	[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MTLReadWriteTextureTier : ulong
	{
		None = 0,
		One = 1,
		Two = 2,
	}

	[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
	[Native]
	public enum MTLArgumentBuffersTier : ulong
	{
		One = 0,
		Two = 1,
	}

	[Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0), Introduced (PlatformName.TvOS, 11, 0), Unavailable (PlatformName.WatchOS)]
	[Native, Flags]
	public enum MTLStoreActionOptions : ulong
	{
		None = 0,
		CustomSamplePositions = 1 << 0,
	}
}
#endif

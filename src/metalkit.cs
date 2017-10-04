#if XAMCORE_2_0 || !MONOMAC
﻿using System;
using XamCore.CoreAnimation;
using XamCore.CoreGraphics;
using XamCore.Foundation;
using XamCore.Metal;
using XamCore.ModelIO;
using XamCore.ObjCRuntime;

using OpenTK;

namespace XamCore.MetalKit {

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[Static]
	interface MTKModel {

		[Field ("MTKModelErrorDomain")]
		NSString ErrorDomain { get; }

		[Field ("MTKModelErrorKey")]
		NSString ErrorKey { get; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[DisableDefaultCtor]
#if MONOMAC
	[BaseType (typeof (XamCore.AppKit.NSView))]
#else
	[BaseType (typeof (XamCore.UIKit.UIView))]
#endif
	interface MTKView : NSCoding, CALayerDelegate {

		[Export ("initWithFrame:device:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frameRect, [NullAllowed] IMTLDevice device);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		[Protocolize]
		MTKViewDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[NullAllowed, Export ("device", ArgumentSemantic.Assign)]
		IMTLDevice Device { get; set; }

		[NullAllowed, Export ("currentDrawable")]
		ICAMetalDrawable CurrentDrawable { get; }

		[Export ("framebufferOnly")]
		bool FramebufferOnly { get; set; }

		[Export ("presentsWithTransaction")]
		bool PresentsWithTransaction { get; set; }

		[Export ("colorPixelFormat", ArgumentSemantic.Assign)]
		MTLPixelFormat ColorPixelFormat { get; set; }

		[Export ("depthStencilPixelFormat", ArgumentSemantic.Assign)]
		MTLPixelFormat DepthStencilPixelFormat { get; set; }

		[Export ("sampleCount", ArgumentSemantic.Assign)]
		nuint SampleCount { get; set; }

		[Export ("clearColor", ArgumentSemantic.Assign)]
		MTLClearColor ClearColor { get; set; }

		[Export ("clearDepth")]
		double ClearDepth { get; set; }

		[Export ("clearStencil")]
		uint ClearStencil { get; set; }

		[NullAllowed, Export ("depthStencilTexture")]
		IMTLTexture DepthStencilTexture { get; }

		[NullAllowed, Export ("multisampleColorTexture")]
		IMTLTexture MultisampleColorTexture { get; }

		[Export ("releaseDrawables")]
		void ReleaseDrawables ();

		[NullAllowed, Export ("currentRenderPassDescriptor")]
		MTLRenderPassDescriptor CurrentRenderPassDescriptor { get; }

		[Export ("preferredFramesPerSecond", ArgumentSemantic.Assign)]
		nint PreferredFramesPerSecond { get; set; }

		[Export ("enableSetNeedsDisplay")]
		bool EnableSetNeedsDisplay { get; set; }

		[Export ("autoResizeDrawable")]
		bool AutoResizeDrawable { get; set; }

		[Export ("drawableSize", ArgumentSemantic.Assign)]
		CGSize DrawableSize { get; set; }

		[Export ("paused")]
		bool Paused { [Bind ("isPaused")] get; set; }

		[Export ("draw")]
		void Draw ();

		[Unavailable (PlatformName.iOS)][Unavailable (PlatformName.TvOS)]
		[Introduced (PlatformName.MacOSX, 10, 12)]
		[NullAllowed, Export ("colorspace", ArgumentSemantic.Assign)]
		CGColorSpace ColorSpace { get; set; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MTKViewDelegate {
		[Abstract]
		[Export ("mtkView:drawableSizeWillChange:")]
		void DrawableSizeWillChange (MTKView view, CGSize size);

		[Abstract]
		[Export ("drawInMTKView:")]
		void Draw (MTKView view);
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[Static]
	interface MTKTextureLoaderError {

		[Field ("MTKTextureLoaderErrorDomain")]
		NSString Domain { get; }

		[Field ("MTKTextureLoaderErrorKey")]
		NSString Key { get; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[Static, Internal]
	interface MTKTextureLoaderKeys {

		[Field ("MTKTextureLoaderOptionAllocateMipmaps")]
		NSString AllocateMipmapsKey { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MTKTextureLoaderOptionGenerateMipmaps")]
		NSString GenerateMipmapsKey { get; }

		[Field ("MTKTextureLoaderOptionSRGB")]
		NSString SrgbKey { get; }

		[Field ("MTKTextureLoaderOptionTextureUsage")]
		NSString TextureUsageKey { get; }

		[Field ("MTKTextureLoaderOptionTextureCPUCacheMode")]
		NSString TextureCpuCacheModeKey { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MTKTextureLoaderOptionTextureStorageMode")]
		NSString TextureStorageModeKey { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MTKTextureLoaderOptionCubeLayout")]
		NSString CubeLayoutKey { get; }

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Introduced (PlatformName.TvOS, 10, 0)]
		[Field ("MTKTextureLoaderOptionOrigin")]
		NSString OriginKey { get; }
	}

	[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	enum MTKTextureLoaderCubeLayout {
		[Field ("MTKTextureLoaderCubeLayoutVertical")]
		Vertical,
	}

	[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	[Introduced (PlatformName.TvOS, 10, 0)]
	enum MTKTextureLoaderOrigin {
		[Field ("MTKTextureLoaderOriginTopLeft")]
		TopLeft,
		[Field ("MTKTextureLoaderOriginBottomLeft")]
		BottomLeft,
		[Field ("MTKTextureLoaderOriginFlippedVertically")]
		FlippedVertically,
	}

	[StrongDictionary ("MTKTextureLoaderKeys")]
	interface MTKTextureLoaderOptions {
		bool AllocateMipmaps { get; set; }

		[Introduced (PlatformName.TvOS, 10, 0)]
		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		bool GenerateMipmaps { get; }

		bool Srgb { get; set; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	delegate void MTKTextureLoaderCallback ([NullAllowed] IMTLTexture texture, [NullAllowed] NSError error);

	[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
	delegate void MTKTextureLoaderArrayCallback (IMTLTexture[] textures, [NullAllowed] NSError error);

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MTKTextureLoader {
		[Export ("device")]
		IMTLDevice Device { get; }

		[Export ("initWithDevice:")]
		IntPtr Constructor (IMTLDevice device);

		[Export ("newTextureWithContentsOfURL:options:completionHandler:"), Internal]
		void FromUrl (NSUrl url, [NullAllowed] NSDictionary options, MTKTextureLoaderCallback completionHandler);

		[Wrap ("FromUrl (url, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromUrl (NSUrl url, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderCallback completionHandler);

		[Export ("newTextureWithData:options:completionHandler:"), Internal]
		void FromData (NSData data, [NullAllowed] NSDictionary options, MTKTextureLoaderCallback completionHandler);

		[Wrap ("FromData (data, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromData (NSData data, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderCallback completionHandler);

		[Export ("newTextureWithCGImage:options:completionHandler:"), Internal]
		void FromCGImage (CGImage cgImage, [NullAllowed] NSDictionary options, MTKTextureLoaderCallback completionHandler);

		[Wrap ("FromCGImage (cgImage, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromCGImage (CGImage cgImage, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderCallback completionHandler);

		[Export ("newTextureWithContentsOfURL:options:error:"), Internal]
		[return: NullAllowed]
		IMTLTexture FromUrl (NSUrl url, [NullAllowed] NSDictionary options, out NSError error);

		[Wrap ("FromUrl (url, options == null ? null : options.Dictionary, out error)")]
		[return: NullAllowed]
		IMTLTexture FromUrl (NSUrl url, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTexturesWithContentsOfURLs:options:completionHandler:")]
		[Async]
		void FromUrls (NSUrl[] urls, [NullAllowed] NSDictionary options, MTKTextureLoaderArrayCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromUrls (urls, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromUrls (NSUrl[] urls, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderArrayCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTexturesWithContentsOfURLs:options:error:")]
		IMTLTexture[] FromUrls (NSUrl[] urls, [NullAllowed] NSDictionary options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromUrls (urls, options == null ? null : options.Dictionary, out error)")]
		IMTLTexture[] FromUrls (NSUrl[] urls, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);

		[Export ("newTextureWithData:options:error:"), Internal]
		[return: NullAllowed]
		IMTLTexture FromData (NSData data, [NullAllowed] NSDictionary options, out NSError error);

		[Wrap ("FromData (data, options == null ? null : options.Dictionary, out error)")]
		[return: NullAllowed]
		IMTLTexture FromData (NSData data, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);

		[Export ("newTextureWithCGImage:options:error:"), Internal]
		[return: NullAllowed]
		IMTLTexture FromCGImage (CGImage cgImage, [NullAllowed] NSDictionary options, out NSError error);

		[Wrap ("FromCGImage (cgImage, options == null ? null : options.Dictionary, out error)")]
		[return: NullAllowed]
		IMTLTexture FromCGImage (CGImage cgImage, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTextureWithName:scaleFactor:bundle:options:completionHandler:")]
		[Async]
		void FromName (string name, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] NSDictionary options, MTKTextureLoaderCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromName (name, scaleFactor, bundle, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromName (string name, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTexturesWithNames:scaleFactor:bundle:options:completionHandler:")]
		[Async]
		void FromNames (string[] names, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] NSDictionary options, MTKTextureLoaderArrayCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromNames (names, scaleFactor, bundle, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromNames (string[] names, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderArrayCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTextureWithMDLTexture:options:completionHandler:")]
		[Async]
		void FromTexture (MDLTexture texture, [NullAllowed] NSDictionary options, MTKTextureLoaderCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromTexture (texture, options == null ? null : options.Dictionary, completionHandler)")]
		[Async]
		void FromTexture (MDLTexture texture, [NullAllowed] MTKTextureLoaderOptions options, MTKTextureLoaderCallback completionHandler);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTextureWithMDLTexture:options:error:")]
		[return: NullAllowed]
		IMTLTexture FromTexture (MDLTexture texture, [NullAllowed] NSDictionary options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromTexture (texture, options == null ? null : options.Dictionary, out error)")]
		[return: NullAllowed]
		IMTLTexture FromTexture (MDLTexture texture, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Export ("newTextureWithName:scaleFactor:bundle:options:error:")]
		[return: NullAllowed]
		IMTLTexture FromName (string name, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] NSDictionary options, out NSError error);

		[Introduced (PlatformName.iOS, 10, 0)][Introduced (PlatformName.MacOSX, 10, 12, PlatformArchitecture.Arch64)]
		[Wrap ("FromName (name, scaleFactor, bundle, options == null ? null : options.Dictionary, out error)")]
		[return: NullAllowed]
		IMTLTexture FromName (string name, nfloat scaleFactor, [NullAllowed] NSBundle bundle, [NullAllowed] MTKTextureLoaderOptions options, out NSError error);
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // init is NS_UNAVAILABLE
	interface MTKMeshBufferAllocator : MDLMeshBufferAllocator {
		[Export ("initWithDevice:")]
		IntPtr Constructor (IMTLDevice device);

		[Export ("device")]
		IMTLDevice Device { get; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MTKMeshBuffer : MDLMeshBuffer, MDLNamed {
		[Export ("buffer")]
		IMTLBuffer Buffer { get; }

		[Export ("offset")]
		nuint Offset { get; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface MTKSubmesh {
		[Export ("primitiveType")]
		MTLPrimitiveType PrimitiveType { get; }

		[Export ("indexType")]
		MTLIndexType IndexType { get; }

		[Export ("indexBuffer")]
		MTKMeshBuffer IndexBuffer { get; }

		[Export ("indexCount")]
		nuint IndexCount { get; }

		[NullAllowed, Export ("mesh", ArgumentSemantic.Weak)]
		MTKMesh Mesh { get; }

		[Export ("name")]
		string Name { get; set; }
	}

	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11, PlatformArchitecture.Arch64)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // init NS_UNAVAILABLE
	interface MTKMesh {
		[Export ("initWithMesh:device:error:")]
		IntPtr Constructor (MDLMesh mesh, IMTLDevice device, out NSError error);

		// generator does not like `out []` -> https://trello.com/c/sZYNalbB/524-generator-support-out
		[Internal] // there's another, manual, public API exposed
		[Static]
		[Export ("newMeshesFromAsset:device:sourceMeshes:error:")]
		[return: NullAllowed]
		MTKMesh[] FromAsset (MDLAsset asset, IMTLDevice device, out NSArray sourceMeshes, out NSError error);

		[Export ("vertexBuffers")]
		MTKMeshBuffer[] VertexBuffers { get; }

		[Export ("vertexDescriptor")]
		MDLVertexDescriptor VertexDescriptor { get; }

		[Export ("submeshes")]
		MTKSubmesh[] Submeshes { get; }

		[Export ("vertexCount")]
		nuint VertexCount { get; }

		[Export ("name")]
		string Name { get; set; }
	}
}
#endif

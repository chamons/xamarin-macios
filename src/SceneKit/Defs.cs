//
// Defs.cs: Enumerations and core types
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//   Aaron Bockover (abock@xamarin.com)
//
// Copyright 2012-2014, 2016 Xamarin, Inc.
//

using System;

using XamCore.ObjCRuntime;

using Vector3 = global::OpenTK.Vector3;
using Vector4 = global::OpenTK.Vector4;

namespace XamCore.SceneKit {

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native] // untyped enum (SceneKitTypes.h) but described as the value of `code` for `NSError` which is an NSInteger
	[ErrorDomain ("SCNErrorDomain")]
	public enum SCNErrorCode : nint {
		ProgramCompilationError = 1,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNGeometryPrimitiveType : nint {
		Triangles,
		TriangleStrip,
		Line,
		Point,
		[Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12), Introduced (PlatformName.iOS, 10, 0)]
		Polygon
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNTransparencyMode : nint {
		AOne,
		RgbZero,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		SingleLayer = 2,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		DualLayer = 3,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		Default = AOne,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNCullMode : nint {
		Back, Front
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNFilterMode : nint {
		None,
		Nearest,
		Linear
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNWrapMode : nint {
		Clamp = 1,
		Repeat,
		// added in iOS 8, removed in 8.3 (mistake?) but added back in 9.0 betas
		ClampToBorder,
		Mirror
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 8), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNSceneSourceStatus : nint {
		Error = -1,
		Parsing = 4,
		Validating = 8,
		Processing = 12,
		Complete = 16
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 9), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNChamferMode : nint {
		Both,
		Front,
		Back
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 9), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNMorpherCalculationMode : nint {
		Normalized,
		Additive
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNActionTimingMode : nint {
		Linear,
		EaseIn,
		EaseOut,
		EaseInEaseOut
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNShadowMode : nint {
		Forward,
		Deferred,
		Modulated
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNPhysicsBodyType : nint {
		Static,
		Dynamic,
		Kinematic
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNPhysicsFieldScope : nint {
		InsideExtent,
		OutsideExtent
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleSortingMode : nint {
		None,
		ProjectedDepth,
		Distance,
		OldestFirst,
		YoungestFirst
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleBlendMode : nint {
		Additive,
		Subtract,
		Multiply,
		Screen,
		Alpha,
		Replace
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleOrientationMode : nint {
		BillboardScreenAligned,
		BillboardViewAligned,
		Free,
		BillboardYAligned
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleBirthLocation : nint {
		Surface,
		Volume,
		Vertex
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleBirthDirection : nint {
		Constant,
		SurfaceNormal,
		Random
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleImageSequenceAnimationMode : nint {
		Repeat,
		Clamp,
		AutoReverse
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleInputMode : nint {
		OverLife,
		OverDistance,
		OverOtherProperty
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleModifierStage : nint {
		PreDynamics,
		PostDynamics,
		PreCollision,
		PostCollision
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.MacOSX, 10, 10), Introduced (PlatformName.iOS, 8, 0)]
	[Native]
	public enum SCNParticleEvent : nint {
		Birth,
		Death,
		Collision
	}

	// Utility enum
	public enum SCNGeometrySourceSemantics
	{
		Vertex,
		Normal,
		Color,
		Texcoord,
		VertexCrease,
		EdgeCrease,
		BoneWeights,
		BoneIndices
	}

	// Utility enum
	public enum SCNAnimationImportPolicy
	{
		Unknown,
		Play,
		PlayRepeatedly,
		DoNotPlay,
		PlayUsingSceneTimeBase
	}

	// Utility enum
	public enum SCNPhysicsSearchMode {
		Unknown = -1,
		Any, Closest, All, 
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Native]
	public enum SCNAntialiasingMode : nuint {
		None,
		Multisampling2X,
		Multisampling4X,
#if MONOMAC
		Multisampling8X,
		Multisampling16X,
#endif
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Native]
	public enum SCNPhysicsCollisionCategory : nuint {
		None	= 0,
		Default	= 1 << 0,
		Static	= 1 << 1,
#if XAMCORE_2_0
		All		= UInt64.MaxValue
#else
		All		= UInt32.MaxValue
#endif
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum SCNBillboardAxis : nuint {
		X = 1 << 0,
		Y = 1 << 1,
		Z = 1 << 2,
		All = (X | Y | Z)
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum SCNReferenceLoadingPolicy : nint {
		Immediate = 0,
		OnDemand = 1
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum SCNBlendMode : nint
	{
		Alpha = 0,
		Add = 1,
		Subtract = 2,
		Multiply = 3,
		Screen = 4,
		Replace = 5,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		Max = 6,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	[Flags]
	public enum SCNDebugOptions : nuint
	{
		None = 0,
		ShowPhysicsShapes = 1 << 0,
		ShowBoundingBoxes = 1 << 1,
		ShowLightInfluences = 1 << 2,
		ShowLightExtents = 1 << 3,
		ShowPhysicsFields = 1 << 4,
		ShowWireframe = 1 << 5,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		RenderAsWireframe = 1 << 6,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		ShowSkeletons = 1 << 7,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		ShowCreases = 1 << 8,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		ShowConstraints = 1 << 9,
		[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
		ShowCameras = 1 << 10,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum SCNRenderingApi : nuint
	{
		Metal,
#if !MONOMAC
		OpenGLES2,
#else
		OpenGLLegacy,
		OpenGLCore32,
		OpenGLCore41
#endif
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.iOS, 9, 0)][Introduced (PlatformName.MacOSX, 10, 11)]
	[Native]
	public enum SCNBufferFrequency : nint
	{
		Frame = 0,
		Node = 1,
		Shadable = 2,
	}

	[Introduced (PlatformName.WatchOS, 3, 0)]
	[Introduced (PlatformName.TvOS, 10, 0), Introduced (PlatformName.MacOSX, 10, 12), Introduced (PlatformName.iOS, 10, 0)]
	[Native]
	public enum SCNMovabilityHint : nint {
		Fixed,
		Movable
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	[Flags]
	public enum SCNColorMask : nint
	{
		None = 0,
		Red = 1 << 3,
		Green = 1 << 2,
		Blue = 1 << 1,
		Alpha = 1 << 0,
		All = 15,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNInteractionMode : nint
	{
		Fly,
		OrbitTurntable,
		OrbitAngleMapping,
		OrbitCenteredArcball,
		OrbitArcball,
		Pan,
		Truck,
	}
		
	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNFillMode : nuint
	{
		Fill = 0,
		Lines = 1,
	}

	[Unavailable (PlatformName.WatchOS), Unavailable (PlatformName.TvOS), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNTessellationSmoothingMode : nint
	{
		None = 0,
		PNTriangles,
		Phong,
	}
	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNHitTestSearchMode : nint
	{
		Closest = 0,
		All = 1,
		Any = 2,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNCameraProjectionDirection : nint
	{
		Vertical = 0,
		Horizontal = 1,
	}

	[Introduced (PlatformName.WatchOS, 4, 0), Introduced (PlatformName.TvOS, 11, 0), Introduced (PlatformName.MacOSX, 10, 13), Introduced (PlatformName.iOS, 11, 0)]
	[Native]
	public enum SCNNodeFocusBehavior : nint
	{
		None = 0,
		Occluding,
		Focusable,
	}
}

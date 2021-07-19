namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Texture : Surface/*
		abstract
		native*/{
	public enum TextureCompressionSettings 
	{
		TC_Default,
		TC_Normalmap,
		TC_Displacementmap,
		TC_NormalmapAlpha,
		TC_Grayscale,
		TC_HighDynamicRange,
		TC_MAX
	};
	
	public enum EPixelFormat 
	{
		PF_Unknown,
		PF_A32B32G32R32F,
		PF_A8R8G8B8,
		PF_G8,
		PF_G16,
		PF_DXT1,
		PF_DXT3,
		PF_DXT5,
		PF_UYVY,
		PF_FloatRGB,
		PF_FloatRGBA,
		PF_DepthStencil,
		PF_ShadowDepth,
		PF_FilteredShadowDepth,
		PF_R32F,
		PF_G16R16,
		PF_G16R16F,
		PF_G16R16F_FILTER,
		PF_G32R32F,
		PF_A2B10G10R10,
		PF_A16B16G16R16,
		PF_D24,
		PF_NULL,
		PF_MAX
	};
	
	public enum TextureFilter 
	{
		TF_Nearest,
		TF_Linear,
		TF_MAX
	};
	
	public enum TextureAddress 
	{
		TA_Wrap,
		TA_Clamp,
		TA_Mirror,
		TA_MAX
	};
	
	public enum TextureGroup 
	{
		TEXTUREGROUP_World,
		TEXTUREGROUP_WorldNormalMap,
		TEXTUREGROUP_WorldSpecular,
		TEXTUREGROUP_Character,
		TEXTUREGROUP_CharacterNormalMap,
		TEXTUREGROUP_CharacterSpecular,
		TEXTUREGROUP_Weapon,
		TEXTUREGROUP_WeaponNormalMap,
		TEXTUREGROUP_WeaponSpecular,
		TEXTUREGROUP_Vehicle,
		TEXTUREGROUP_VehicleNormalMap,
		TEXTUREGROUP_VehicleSpecular,
		TEXTUREGROUP_Cinematic,
		TEXTUREGROUP_Effects,
		TEXTUREGROUP_Skybox,
		TEXTUREGROUP_UI,
		TEXTUREGROUP_LightAndShadowMap,
		TEXTUREGROUP_RenderTarget,
		TEXTUREGROUP_MAX
	};
	
	[Category] public bool SRGB;
	public bool RGBE;
	[Category] public bool CompressionNoAlpha;
	public bool CompressionNone;
	public bool CompressionNoMipmaps;
	[Category] public bool CompressionFullDynamicRange;
	[Category] public bool DeferCompression;
	[Category] public bool NeverStream;
	[Category] public bool bDitherMipMapAlpha;
	[Category] public bool bPreserveBorderR;
	[Category] public bool bPreserveBorderG;
	[Category] public bool bPreserveBorderB;
	[Category] public bool bPreserveBorderA;
	[Const, transient] public/*private*/ bool bAsyncResourceReleaseHasBeenStarted;
	[transient] public/*private*/ bool bDeferredProcessing;
	[Category] public StaticArray<float, float, float, float>/*[4]*/ UnpackMin;
	[Category] public StaticArray<float, float, float, float>/*[4]*/ UnpackMax;
	[native, Const] public Object.UntypedBulkData_Mirror SourceArt;
	[Category] public Texture.TextureCompressionSettings CompressionSettings;
	[Category] public Texture.TextureFilter Filter;
	[Category] public Texture.TextureGroup LODGroup;
	[Category] public int LODBias;
	[transient] public int CachedCombinedLODBias;
	[Category] public String SourceFilePath;
	[Category] [editconst] public String SourceFileTimestamp;
	[native, Const] public Object.Pointer Resource;
	
	public Texture()
	{
		// Object Offset:0x0025D3A3
		SRGB = true;
		UnpackMax = new StaticArray<float, float, float, float>/*[4]*/()
		{ 
			[0] = 1.0f,
			[1] = 1.0f,
			[2] = 1.0f,
			[3] = 1.0f,
	 	};
		Filter = Texture.TextureFilter.TF_Linear;
	}
}
}
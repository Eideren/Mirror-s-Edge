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
	
	public/*()*/ bool SRGB;
	public bool RGBE;
	public/*()*/ bool CompressionNoAlpha;
	public bool CompressionNone;
	public bool CompressionNoMipmaps;
	public/*()*/ bool CompressionFullDynamicRange;
	public/*()*/ bool DeferCompression;
	public/*()*/ bool NeverStream;
	public/*()*/ bool bDitherMipMapAlpha;
	public/*()*/ bool bPreserveBorderR;
	public/*()*/ bool bPreserveBorderG;
	public/*()*/ bool bPreserveBorderB;
	public/*()*/ bool bPreserveBorderA;
	public /*private const transient */bool bAsyncResourceReleaseHasBeenStarted;
	public /*private transient */bool bDeferredProcessing;
	public/*()*/ StaticArray<float, float, float, float>/*[4]*/ UnpackMin;
	public/*()*/ StaticArray<float, float, float, float>/*[4]*/ UnpackMax;
	public /*native const */Object.UntypedBulkData_Mirror SourceArt;
	public/*()*/ Texture.TextureCompressionSettings CompressionSettings;
	public/*()*/ Texture.TextureFilter Filter;
	public/*()*/ Texture.TextureGroup LODGroup;
	public/*()*/ int LODBias;
	public /*transient */int CachedCombinedLODBias;
	public/*()*/ string SourceFilePath;
	public/*()*/ /*editconst */string SourceFileTimestamp;
	public /*native const */Object.Pointer Resource;
	
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
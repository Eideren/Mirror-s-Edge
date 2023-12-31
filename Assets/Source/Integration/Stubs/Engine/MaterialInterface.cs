namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInterface : Surface/*
		abstract
		native*/{
	public enum EMaterialUsage 
	{
		MATUSAGE_SkeletalMesh,
		MATUSAGE_ParticleSprites,
		MATUSAGE_BeamTrails,
		MATUSAGE_ParticleSubUV,
		MATUSAGE_Foliage,
		MATUSAGE_SpeedTree,
		MATUSAGE_StaticLighting,
		MATUSAGE_GammaCorrection,
		MATUSAGE_LensFlare,
		MATUSAGE_InstancedMeshParticles,
		MATUSAGE_MAX
	};
	
	[Category] public Object.Color BakerColor;
	[Category] public float BakerBleedBounceAmount;
	[Category] public float BakerBleedEmissiveAmount;
	[Category] public float BakerAlpha;
	[Category] public Texture BakerAlphaTexture;
	[Category] [editoronly] public String PreviewMesh;
	
	// Export UMaterialInterface::execGetMaterial(FFrame&, void* const)
	public virtual /*native final function */Material GetMaterial()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetPhysicalMaterial(FFrame&, void* const)
	public virtual /*native final function */PhysicalMaterial GetPhysicalMaterial()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetFontParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetFontParameterValue(name ParameterName, ref Font OutFontValue, ref int OutFontPage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetScalarParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetScalarParameterValue(name ParameterName, ref float OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetScalarCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetScalarCurveParameterValue(name ParameterName, ref Object.InterpCurveFloat OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetTextureParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetTextureParameterValue(name ParameterName, ref Texture OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetVectorParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetVectorParameterValue(name ParameterName, ref Object.LinearColor OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetVectorCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetVectorCurveParameterValue(name ParameterName, ref Object.InterpCurveVector OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public MaterialInterface()
	{
		// Object Offset:0x00309E88
		BakerBleedBounceAmount = 1.0f;
		BakerAlpha = 1.0f;
	}
}
}
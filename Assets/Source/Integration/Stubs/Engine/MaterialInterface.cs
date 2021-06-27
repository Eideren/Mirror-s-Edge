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
	
	public/*()*/ Object.Color BakerColor;
	public/*()*/ float BakerBleedBounceAmount;
	public/*()*/ float BakerBleedEmissiveAmount;
	public/*()*/ float BakerAlpha;
	public/*()*/ Texture BakerAlphaTexture;
	public/*()*/ /*editoronly */String PreviewMesh;
	
	// Export UMaterialInterface::execGetMaterial(FFrame&, void* const)
	public virtual /*native final function */Material GetMaterial()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetPhysicalMaterial(FFrame&, void* const)
	public virtual /*native final function */PhysicalMaterial GetPhysicalMaterial()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetFontParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetFontParameterValue(name ParameterName, ref Font OutFontValue, ref int OutFontPage)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetScalarParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetScalarParameterValue(name ParameterName, ref float OutValue)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetScalarCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetScalarCurveParameterValue(name ParameterName, ref Object.InterpCurveFloat OutValue)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetTextureParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetTextureParameterValue(name ParameterName, ref Texture OutValue)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetVectorParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetVectorParameterValue(name ParameterName, ref Object.LinearColor OutValue)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UMaterialInterface::execGetVectorCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */bool GetVectorCurveParameterValue(name ParameterName, ref Object.InterpCurveVector OutValue)
	{
		 // #warning NATIVE FUNCTION !
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
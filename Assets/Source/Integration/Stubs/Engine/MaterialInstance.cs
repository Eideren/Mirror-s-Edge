namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInstance : MaterialInterface/*
		abstract
		native*/{
	public/*()*/ PhysicalMaterial PhysMaterial;
	public/*()*/ /*const */MaterialInterface Parent;
	public bool bHasStaticPermutationResource;
	public /*native transient */bool bStaticPermutationDirty;
	public bool BakerColorOverride;
	public bool BakerBleedBounceAmountOverride;
	public bool BakerBleedEmissiveAmountOverride;
	public bool BakerAlphaOverride;
	public bool BakerAlphaTextureOverride;
	public /*private native const */bool ReentrantFlag;
	public /*duplicatetransient native const */StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ StaticParameters;
	public /*duplicatetransient native const */StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ StaticPermutationResources;
	public /*duplicatetransient native const */StaticArray<Object.Pointer, Object.Pointer>/*[2]*/ Resources;
	public /*private const */array<Texture> ReferencedTextures;
	
	// Export UMaterialInstance::execSetParent(FFrame&, void* const)
	public virtual /*native function */void SetParent(MaterialInterface NewParent)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execSetVectorParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetVectorParameterValue(name ParameterName, Object.LinearColor Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execSetScalarParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetScalarParameterValue(name ParameterName, float Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execSetScalarCurveParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetScalarCurveParameterValue(name ParameterName, Object.InterpCurveFloat Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execSetTextureParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetTextureParameterValue(name ParameterName, Texture Value)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execSetFontParameterValue(FFrame&, void* const)
	public virtual /*native function */void SetFontParameterValue(name ParameterName, Font FontValue, int FontPage)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMaterialInstance::execClearParameterValues(FFrame&, void* const)
	public virtual /*native function */void ClearParameterValues()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MeshComponent : PrimitiveComponent/*
		abstract
		native
		noexport*/{
	public/*(Rendering)*/ /*const */array<MaterialInterface> Materials;
	
	// Export UMeshComponent::execGetMaterial(FFrame&, void* const)
	public virtual /*native function */MaterialInterface GetMaterial(int ElementIndex)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UMeshComponent::execSetMaterial(FFrame&, void* const)
	public virtual /*native function */void SetMaterial(int ElementIndex, MaterialInterface Material)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UMeshComponent::execGetNumElements(FFrame&, void* const)
	public virtual /*native function */int GetNumElements()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */MaterialInstanceConstant CreateAndSetMaterialInstanceConstant(int ElementIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */MaterialInstanceTimeVarying CreateAndSetMaterialInstanceTimeVarying(int ElementIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */array<MaterialInstanceConstant> InitLOIMtrlInstances()
	{
		// stub
		return default;
	}
	
	public MeshComponent()
	{
		// Object Offset:0x002B3AA3
		bUseAsOccluder = true;
		CastShadow = true;
		bAcceptsLights = true;
		bCullModulatedShadowOnBackfaces = true;
	}
}
}
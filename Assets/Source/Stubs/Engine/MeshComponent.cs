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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UMeshComponent::execSetMaterial(FFrame&, void* const)
	public virtual /*native function */void SetMaterial(int ElementIndex, MaterialInterface Material)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UMeshComponent::execGetNumElements(FFrame&, void* const)
	public virtual /*native function */int GetNumElements()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */MaterialInstanceConstant CreateAndSetMaterialInstanceConstant(int ElementIndex)
	{
	
		return default;
	}
	
	public virtual /*function */MaterialInstanceTimeVarying CreateAndSetMaterialInstanceTimeVarying(int ElementIndex)
	{
	
		return default;
	}
	
	public virtual /*function */array<MaterialInstanceConstant> InitLOIMtrlInstances()
	{
	
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
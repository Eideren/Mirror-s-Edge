namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FracturedStaticMeshComponent : StaticMeshComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public partial struct /*native */FracturedElementRanges
	{
		public int BaseIndex;
		public int NumPrimitives;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003205DB
	//		BaseIndex = 0;
	//		NumPrimitives = 0;
	//	}
	};
	
	public partial struct /*native */FragmentGroup
	{
		public array<int> FragmentIndices;
		public bool bGroupIsRooted;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003206D3
	//		FragmentIndices = default;
	//		bGroupIsRooted = false;
	//	}
	};
	
	public /*private native const */Object.IndirectArray_Mirror LODResources;
	public /*private const */array<byte> VisibleFragments;
	public /*private const */array<FracturedStaticMeshComponent.FracturedElementRanges> ElementRanges;
	public /*private native const transient */Object.RenderCommandFence_Mirror ReleaseResourcesFence;
	public bool bUseVisibleVertsForBounds;
	
	// Export UFracturedStaticMeshComponent::execSetStaticMesh(FFrame&, void* const)
	public override /*native simulated function */bool SetStaticMesh(StaticMesh NewMesh)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execSetVisibleFragments(FFrame&, void* const)
	public virtual /*native simulated function */void SetVisibleFragments(array<byte> VisibilityFactors)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UFracturedStaticMeshComponent::execGetVisibleFragments(FFrame&, void* const)
	public virtual /*native simulated function */array<byte> GetVisibleFragments()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execIsFragmentVisible(FFrame&, void* const)
	public virtual /*native simulated function */bool IsFragmentVisible(int FragmentIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execIsFragmentDestroyable(FFrame&, void* const)
	public virtual /*native simulated function */bool IsFragmentDestroyable(int FragmentIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execIsRootFragment(FFrame&, void* const)
	public virtual /*native simulated function */bool IsRootFragment(int FragmentIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execGetFragmentBox(FFrame&, void* const)
	public virtual /*native function */Object.Box GetFragmentBox(int FragmentIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execGetFragmentAverageExteriorNormal(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetFragmentAverageExteriorNormal(int FragmentIndex)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execGetNumFragments(FFrame&, void* const)
	public virtual /*native function */int GetNumFragments()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execGetCoreFragmentIndex(FFrame&, void* const)
	public virtual /*native function */int GetCoreFragmentIndex()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UFracturedStaticMeshComponent::execGetFragmentGroups(FFrame&, void* const)
	public virtual /*native simulated function */array<FracturedStaticMeshComponent.FragmentGroup> GetFragmentGroups(array<int> IgnoreFragments, float MinConnectionArea)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}
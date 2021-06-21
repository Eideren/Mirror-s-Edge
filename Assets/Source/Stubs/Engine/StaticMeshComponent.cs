namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class StaticMeshComponent : MeshComponent/*
		native
		editinlinenew
		noexport
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public partial struct StaticMeshComponentLODInfo
	{
		public /*private const */array<ShadowMap2D> ShadowMaps;
		public /*private const */array<Object> ShadowVertexBuffers;
		public /*private native const */Object.Pointer LightMap;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B3F66
	//		ShadowMaps = default;
	//		ShadowVertexBuffers = default;
	//	}
	};
	
	public int ForcedLodModel;
	public int PreviousLODLevel;
	public/*()*/ /*const */StaticMesh StaticMesh;
	public/*()*/ Object.Color WireframeColor;
	public/*()*/ bool bIgnoreInstanceForTextureStreaming;
	public/*()*/ /*const */bool bOverrideLightMapResolution;
	public/*()*/ /*const */int OverriddenLightMapResolution;
	public/*(AdvancedLighting)*/ /*const */int SubDivisionStepSize;
	public/*(AdvancedLighting)*/ /*const */int MinSubDivisions;
	public/*(AdvancedLighting)*/ /*const */int MaxSubDivisions;
	public/*(AdvancedLighting)*/ /*const */bool bUseSubDivisions;
	public /*const */array<Object.Guid> IrrelevantLights;
	public /*private native const */array<StaticMeshComponent.StaticMeshComponentLODInfo> LODData;
	
	// Export UStaticMeshComponent::execSetStaticMesh(FFrame&, void* const)
	public virtual /*native simulated function */bool SetStaticMesh(StaticMesh NewMesh)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UStaticMeshComponent::execDisableRBCollisionWithSMC(FFrame&, void* const)
	public virtual /*native simulated function */void DisableRBCollisionWithSMC(StaticMeshComponent OtherSMC, bool bDisabled)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public StaticMeshComponent()
	{
		// Object Offset:0x002B4117
		WireframeColor = new Color
		{
			R=0,
			G=255,
			B=255,
			A=255
		};
		bOverrideLightMapResolution = true;
		SubDivisionStepSize = 16;
		MinSubDivisions = 2;
		MaxSubDivisions = 8;
		bUseSubDivisions = true;
		bAcceptsDecals = true;
		bUsePrecomputedShadows = true;
		CollideActors = true;
		BlockActors = true;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
		BlockRigidBody = true;
		TickGroup = Object.ETickingGroup.TG_PreAsyncWork;
	}
}
}
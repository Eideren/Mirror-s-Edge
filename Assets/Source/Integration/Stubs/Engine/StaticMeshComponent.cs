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
		[Const] public/*private*/ array<ShadowMap2D> ShadowMaps;
		[Const] public/*private*/ array<Object> ShadowVertexBuffers;
		[native, Const] public/*private*/ Object.Pointer LightMap;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B3F66
	//		ShadowMaps = default;
	//		ShadowVertexBuffers = default;
	//	}
	};
	
	public int ForcedLodModel;
	public int PreviousLODLevel;
	[Category] [Const] public StaticMesh StaticMesh;
	[Category] public Object.Color WireframeColor;
	[Category] public bool bIgnoreInstanceForTextureStreaming;
	[Category] [Const] public bool bOverrideLightMapResolution;
	[Category] [Const] public int OverriddenLightMapResolution;
	[Category("AdvancedLighting")] [Const] public int SubDivisionStepSize;
	[Category("AdvancedLighting")] [Const] public int MinSubDivisions;
	[Category("AdvancedLighting")] [Const] public int MaxSubDivisions;
	[Category("AdvancedLighting")] [Const] public bool bUseSubDivisions;
	[Const] public array<Object.Guid> IrrelevantLights;
	[native, Const] public/*private*/ array<StaticMeshComponent.StaticMeshComponentLODInfo> LODData;
	
	// Export UStaticMeshComponent::execSetStaticMesh(FFrame&, void* const)
	public virtual /*native simulated function */bool SetStaticMesh(StaticMesh NewMesh)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UStaticMeshComponent::execDisableRBCollisionWithSMC(FFrame&, void* const)
	public virtual /*native simulated function */void DisableRBCollisionWithSMC(StaticMeshComponent OtherSMC, bool bDisabled)
	{
		NativeMarkers.MarkUnimplemented();
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
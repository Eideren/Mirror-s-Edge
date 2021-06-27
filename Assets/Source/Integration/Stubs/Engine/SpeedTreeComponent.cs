namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public partial struct /*native */SpeedTreeStaticLight
	{
		public /*private const */Object.Guid Guid;
		public /*private const */ShadowMap1D BranchAndFrondShadowMap;
		public /*private const */ShadowMap1D LeafMeshShadowMap;
		public /*private const */ShadowMap1D LeafCardShadowMap;
		public /*private const */ShadowMap1D BillboardShadowMap;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003EC74D
	//		Guid = new Guid
	//		{
	//			A=0,
	//			B=0,
	//			C=0,
	//			D=0
	//		};
	//		BranchAndFrondShadowMap = default;
	//		LeafMeshShadowMap = default;
	//		LeafCardShadowMap = default;
	//		BillboardShadowMap = default;
	//	}
	};
	
	public partial struct LightMapRef
	{
		public /*private native const */Object.Pointer Reference;
	};
	
	public/*(SpeedTree)*/ /*const */SpeedTree SpeedTree;
	public/*(SpeedTree)*/ bool bUseLeaves;
	public/*(SpeedTree)*/ bool bUseBranches;
	public/*(SpeedTree)*/ bool bUseFronds;
	public/*(SpeedTree)*/ bool bUseBillboards;
	public/*(SpeedTree)*/ float LodNearDistance;
	public/*(SpeedTree)*/ float LodFarDistance;
	public/*(SpeedTree)*/ float LodLevelOverride;
	public/*(SpeedTree)*/ MaterialInterface BranchMaterial;
	public/*(SpeedTree)*/ MaterialInterface FrondMaterial;
	public/*(SpeedTree)*/ MaterialInterface LeafMaterial;
	public/*(SpeedTree)*/ MaterialInterface BillboardMaterial;
	public /*private editoronly */Texture2D SpeedTreeIcon;
	public /*private const */array<SpeedTreeComponent.SpeedTreeStaticLight> StaticLights;
	public /*private native const */SpeedTreeComponent.LightMapRef BranchAndFrondLightMap;
	public /*private native const */SpeedTreeComponent.LightMapRef LeafMeshLightMap;
	public /*private native const */SpeedTreeComponent.LightMapRef LeafCardLightMap;
	public /*private native const */SpeedTreeComponent.LightMapRef BillboardLightMap;
	public /*private native const */Object.Matrix RotationOnlyMatrix;
	public /*private native const */float WindMatrixOffset;
	
	public SpeedTreeComponent()
	{
		// Object Offset:0x003EC88D
		bUseLeaves = true;
		bUseBranches = true;
		bUseFronds = true;
		bUseBillboards = true;
		LodNearDistance = 500.0f;
		LodFarDistance = 3000.0f;
		LodLevelOverride = 1.0f;
		SpeedTreeIcon = LoadAsset<Texture2D>("EditorResources.SpeedTreeLogo")/*Ref Texture2D'EditorResources.SpeedTreeLogo'*/;
		bUseAsOccluder = true;
		CastShadow = true;
		bAcceptsLights = true;
		bUsePrecomputedShadows = true;
		CollideActors = true;
		BlockActors = true;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
		BlockRigidBody = true;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Collision,Rendering,Lighting)*/{
	public partial struct /*native */SpeedTreeStaticLight
	{
		[Const] public/*private*/ Object.Guid Guid;
		[Const] public/*private*/ ShadowMap1D BranchAndFrondShadowMap;
		[Const] public/*private*/ ShadowMap1D LeafMeshShadowMap;
		[Const] public/*private*/ ShadowMap1D LeafCardShadowMap;
		[Const] public/*private*/ ShadowMap1D BillboardShadowMap;
	
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
		[native, Const] public/*private*/ Object.Pointer Reference;
	};
	
	[Category("SpeedTree")] [Const] public SpeedTree SpeedTree;
	[Category("SpeedTree")] public bool bUseLeaves;
	[Category("SpeedTree")] public bool bUseBranches;
	[Category("SpeedTree")] public bool bUseFronds;
	[Category("SpeedTree")] public bool bUseBillboards;
	[Category("SpeedTree")] public float LodNearDistance;
	[Category("SpeedTree")] public float LodFarDistance;
	[Category("SpeedTree")] public float LodLevelOverride;
	[Category("SpeedTree")] public MaterialInterface BranchMaterial;
	[Category("SpeedTree")] public MaterialInterface FrondMaterial;
	[Category("SpeedTree")] public MaterialInterface LeafMaterial;
	[Category("SpeedTree")] public MaterialInterface BillboardMaterial;
	[editoronly] public/*private*/ Texture2D SpeedTreeIcon;
	[Const] public/*private*/ array<SpeedTreeComponent.SpeedTreeStaticLight> StaticLights;
	[native, Const] public/*private*/ SpeedTreeComponent.LightMapRef BranchAndFrondLightMap;
	[native, Const] public/*private*/ SpeedTreeComponent.LightMapRef LeafMeshLightMap;
	[native, Const] public/*private*/ SpeedTreeComponent.LightMapRef LeafCardLightMap;
	[native, Const] public/*private*/ SpeedTreeComponent.LightMapRef BillboardLightMap;
	[native, Const] public/*private*/ Object.Matrix RotationOnlyMatrix;
	[native, Const] public/*private*/ float WindMatrixOffset;
	
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
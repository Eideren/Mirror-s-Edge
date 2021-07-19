namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainComponent : PrimitiveComponent/*
		native
		noexport*/{
	public partial struct TerrainkDOPTree
	{
		[native, Const] public/*private*/ array<int> Nodes;
		[native, Const] public/*private*/ array<int> Triangles;
	};
	
	public partial struct TerrainBVTree
	{
		[native, Const] public/*private*/ array<int> Nodes;
	};
	
	[Const] public/*private*/ array<ShadowMap2D> ShadowMaps;
	[Const] public array<Object.Guid> IrrelevantLights;
	[native, Const, transient] public Object.Pointer TerrainObject;
	[Const] public int SectionBaseX;
	[Const] public int SectionBaseY;
	[Const] public int SectionSizeX;
	[Const] public int SectionSizeY;
	[Const] public int TrueSectionSizeX;
	[Const] public int TrueSectionSizeY;
	[native, Const] public/*private*/ Object.Pointer LightMap;
	[native, Const, transient] public/*private*/ array<int> PatchBounds;
	[native, Const, transient] public/*private*/ array<int> PatchBatches;
	[native, Const, transient] public/*private*/ array<int> BatchMaterials;
	[native, Const, transient] public/*private*/ int FullBatch;
	[native, Const, transient] public/*private*/ Object.Pointer PatchBatchOffsets;
	[native, Const, transient] public/*private*/ Object.Pointer WorkingOffsets;
	[native, Const, transient] public/*private*/ Object.Pointer PatchBatchTriangles;
	[native, Const, transient] public/*private*/ Object.Pointer PatchCachedTessellationValues;
	[native, Const, transient] public/*private*/ Object.Pointer TesselationLevels;
	[native, Const, transient] public/*private*/ TerrainComponent.TerrainBVTree BVTree;
	[native, Const, transient] public/*private*/ array<Object.Vector> CollisionVertices;
	[native, Const] public Object.Pointer RBHeightfield;
	[Const] public/*private*/ bool bDisplayCollisionLevel;
	
	public TerrainComponent()
	{
		// Object Offset:0x003FCA3A
		bAllowCullDistanceVolume = false;
		bUseAsOccluder = true;
		bAcceptsDecals = true;
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
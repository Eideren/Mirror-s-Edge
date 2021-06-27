namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainComponent : PrimitiveComponent/*
		native
		noexport*/{
	public partial struct TerrainkDOPTree
	{
		public /*private native const */array<int> Nodes;
		public /*private native const */array<int> Triangles;
	};
	
	public partial struct TerrainBVTree
	{
		public /*private native const */array<int> Nodes;
	};
	
	public /*private const */array<ShadowMap2D> ShadowMaps;
	public /*const */array<Object.Guid> IrrelevantLights;
	public /*native const transient */Object.Pointer TerrainObject;
	public /*const */int SectionBaseX;
	public /*const */int SectionBaseY;
	public /*const */int SectionSizeX;
	public /*const */int SectionSizeY;
	public /*const */int TrueSectionSizeX;
	public /*const */int TrueSectionSizeY;
	public /*private native const */Object.Pointer LightMap;
	public /*private native const transient */array<int> PatchBounds;
	public /*private native const transient */array<int> PatchBatches;
	public /*private native const transient */array<int> BatchMaterials;
	public /*private native const transient */int FullBatch;
	public /*private native const transient */Object.Pointer PatchBatchOffsets;
	public /*private native const transient */Object.Pointer WorkingOffsets;
	public /*private native const transient */Object.Pointer PatchBatchTriangles;
	public /*private native const transient */Object.Pointer PatchCachedTessellationValues;
	public /*private native const transient */Object.Pointer TesselationLevels;
	public /*private native const transient */TerrainComponent.TerrainBVTree BVTree;
	public /*private native const transient */array<Object.Vector> CollisionVertices;
	public /*native const */Object.Pointer RBHeightfield;
	public /*private const */bool bDisplayCollisionLevel;
	
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
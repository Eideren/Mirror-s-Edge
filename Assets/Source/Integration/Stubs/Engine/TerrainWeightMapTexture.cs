namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainWeightMapTexture : Texture2D/*
		native
		hidecategories(Object,Object)*/{
	public partial struct TerrainWeightedMaterial
	{
	};
	
	[Const] public Terrain ParentTerrain;
	[native, Const] public/*private*/ array<Object.Pointer> WeightedMaterials;
	
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainLayerSetup : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct FilterLimit
	{
		[Category] public bool Enabled;
		[Category] public float Base;
		[Category] public float NoiseScale;
		[Category] public float NoiseAmount;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FCCBD
	//		Enabled = false;
	//		Base = 0.0f;
	//		NoiseScale = 0.0f;
	//		NoiseAmount = 0.0f;
	//	}
	};
	
	public partial struct TerrainFilteredMaterial
	{
		[Category] public bool UseNoise;
		[Category] public float NoiseScale;
		[Category] public float NoisePercent;
		[Category] public TerrainLayerSetup.FilterLimit MinHeight;
		[Category] public TerrainLayerSetup.FilterLimit MaxHeight;
		[Category] public TerrainLayerSetup.FilterLimit MinSlope;
		[Category] public TerrainLayerSetup.FilterLimit MaxSlope;
		[Category] public float Alpha;
		[Category] public TerrainMaterial Material;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FCF05
	//		UseNoise = false;
	//		NoiseScale = 0.0f;
	//		NoisePercent = 0.0f;
	//		MinHeight = new TerrainLayerSetup.FilterLimit
	//		{
	//			Enabled = false,
	//			Base = 0.0f,
	//			NoiseScale = 0.0f,
	//			NoiseAmount = 0.0f,
	//		};
	//		MaxHeight = new TerrainLayerSetup.FilterLimit
	//		{
	//			Enabled = false,
	//			Base = 0.0f,
	//			NoiseScale = 0.0f,
	//			NoiseAmount = 0.0f,
	//		};
	//		MinSlope = new TerrainLayerSetup.FilterLimit
	//		{
	//			Enabled = false,
	//			Base = 0.0f,
	//			NoiseScale = 0.0f,
	//			NoiseAmount = 0.0f,
	//		};
	//		MaxSlope = new TerrainLayerSetup.FilterLimit
	//		{
	//			Enabled = false,
	//			Base = 0.0f,
	//			NoiseScale = 0.0f,
	//			NoiseAmount = 0.0f,
	//		};
	//		Alpha = 1.0f;
	//		Material = default;
	//	}
	};
	
	[Category] [Const] public array<TerrainLayerSetup.TerrainFilteredMaterial> Materials;
	
	// Export UTerrainLayerSetup::execSetMaterials(FFrame&, void* const)
	public virtual /*native final function */void SetMaterials(array<TerrainLayerSetup.TerrainFilteredMaterial> NewMaterials)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*simulated function */void PostBeginPlay()
	{
		// stub
	}
	
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainLayerSetup : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public partial struct FilterLimit
	{
		public/*()*/ bool Enabled;
		public/*()*/ float Base;
		public/*()*/ float NoiseScale;
		public/*()*/ float NoiseAmount;
	
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
		public/*()*/ bool UseNoise;
		public/*()*/ float NoiseScale;
		public/*()*/ float NoisePercent;
		public/*()*/ TerrainLayerSetup.FilterLimit MinHeight;
		public/*()*/ TerrainLayerSetup.FilterLimit MaxHeight;
		public/*()*/ TerrainLayerSetup.FilterLimit MinSlope;
		public/*()*/ TerrainLayerSetup.FilterLimit MaxSlope;
		public/*()*/ float Alpha;
		public/*()*/ TerrainMaterial Material;
	
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
	
	public/*()*/ /*const */array<TerrainLayerSetup.TerrainFilteredMaterial> Materials;
	
	// Export UTerrainLayerSetup::execSetMaterials(FFrame&, void* const)
	public virtual /*native final function */void SetMaterials(array<TerrainLayerSetup.TerrainFilteredMaterial> NewMaterials)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*simulated function */void PostBeginPlay()
	{
		// stub
	}
	
}
}
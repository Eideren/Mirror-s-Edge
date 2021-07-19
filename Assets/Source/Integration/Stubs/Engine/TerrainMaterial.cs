namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TerrainMaterial : Object/*
		native
		hidecategories(Object)*/{
	public enum ETerrainMappingType 
	{
		TMT_Auto,
		TMT_XY,
		TMT_XZ,
		TMT_YZ,
		TMT_MAX
	};
	
	public partial struct /*native */TerrainFoliageMesh
	{
		[Category] public StaticMesh StaticMesh;
		[Category] public MaterialInterface Material;
		[Category] public int Density;
		[Category] public float MaxDrawRadius;
		[Category] public float MinTransitionRadius;
		[Category] public float MinScale;
		[Category] public float MaxScale;
		[Category] public int Seed;
		[Category] public float SwayScale;
		[Category] public float AlphaMapThreshold;
		[Category] public float SlopeRotationBlend;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FD7F0
	//		StaticMesh = default;
	//		Material = default;
	//		Density = 0;
	//		MaxDrawRadius = 1024.0f;
	//		MinTransitionRadius = 0.0f;
	//		MinScale = 1.0f;
	//		MaxScale = 1.0f;
	//		Seed = 0;
	//		SwayScale = 1.0f;
	//		AlphaMapThreshold = 0.0f;
	//		SlopeRotationBlend = 0.0f;
	//	}
	};
	
	public Object.Matrix LocalToMapping;
	[Category("Material")] public TerrainMaterial.ETerrainMappingType MappingType;
	[Category("Material")] public float MappingScale;
	[Category("Material")] public float MappingRotation;
	[Category("Material")] public float MappingPanU;
	[Category("Material")] public float MappingPanV;
	[Category("Material")] public MaterialInterface Material;
	[Category("Displacement")] public Texture2D DisplacementMap;
	[Category("Displacement")] public float DisplacementScale;
	[Category("Foliage")] public array<TerrainMaterial.TerrainFoliageMesh> FoliageMeshes;
	
	public TerrainMaterial()
	{
		// Object Offset:0x003FD95C
		MappingScale = 4.0f;
		DisplacementScale = 0.250f;
	}
}
}
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
		public/*()*/ StaticMesh StaticMesh;
		public/*()*/ MaterialInterface Material;
		public/*()*/ int Density;
		public/*()*/ float MaxDrawRadius;
		public/*()*/ float MinTransitionRadius;
		public/*()*/ float MinScale;
		public/*()*/ float MaxScale;
		public/*()*/ int Seed;
		public/*()*/ float SwayScale;
		public/*()*/ float AlphaMapThreshold;
		public/*()*/ float SlopeRotationBlend;
	
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
	public/*(Material)*/ TerrainMaterial.ETerrainMappingType MappingType;
	public/*(Material)*/ float MappingScale;
	public/*(Material)*/ float MappingRotation;
	public/*(Material)*/ float MappingPanU;
	public/*(Material)*/ float MappingPanV;
	public/*(Material)*/ MaterialInterface Material;
	public/*(Displacement)*/ Texture2D DisplacementMap;
	public/*(Displacement)*/ float DisplacementScale;
	public/*(Foliage)*/ array<TerrainMaterial.TerrainFoliageMesh> FoliageMeshes;
	
	public TerrainMaterial()
	{
		// Object Offset:0x003FD95C
		MappingScale = 4.0f;
		DisplacementScale = 0.250f;
	}
}
}
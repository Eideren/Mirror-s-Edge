namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FoliageFactory : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public partial struct /*native */FoliageMesh
	{
		[Category] public StaticMesh InstanceStaticMesh;
		[Category] public MaterialInterface Material;
		[Category] public float MaxDrawRadius;
		[Category] public float MinTransitionRadius;
		[Category] public Object.Vector MinScale;
		[Category] public Object.Vector MaxScale;
		[Category] public float SwayScale;
		[Category] public int Seed;
		[Category] public float SurfaceAreaPerInstance;
		[Category] public bool bCreateInstancesOnBSP;
		[Category] public bool bCreateInstancesOnStaticMeshes;
		[Category] public bool bCreateInstancesOnTerrain;
		[export, editinline] public FoliageComponent Component;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0031F46E
	//		InstanceStaticMesh = default;
	//		Material = default;
	//		MaxDrawRadius = 2000.0f;
	//		MinTransitionRadius = 0.0f;
	//		MinScale = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//		MaxScale = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//		SwayScale = 1.0f;
	//		Seed = 0;
	//		SurfaceAreaPerInstance = 1000.0f;
	//		bCreateInstancesOnBSP = true;
	//		bCreateInstancesOnStaticMeshes = true;
	//		bCreateInstancesOnTerrain = true;
	//		Component = default;
	//	}
	};
	
	[Category("Foliage")] [Const] public array<FoliageFactory.FoliageMesh> Meshes;
	[Category("Foliage")] [Const] public float VolumeFalloffRadius;
	[Category("Foliage")] [Const] public float VolumeFalloffExponent;
	[Category("Foliage")] [Const] public float SurfaceDensityUpFacing;
	[Category("Foliage")] [Const] public float SurfaceDensityDownFacing;
	[Category("Foliage")] [Const] public float SurfaceDensitySideFacing;
	[Category("Foliage")] [Const] public float FacingFalloffExponent;
	[Category("Foliage")] [Const] public int MaxInstanceCount;
	
	public FoliageFactory()
	{
		var Default__FoliageFactory_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x00465FE3
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__FoliageFactory.BrushComponent0' */;
		// Object Offset:0x0031F796
		VolumeFalloffExponent = 1.0f;
		SurfaceDensityUpFacing = 1.0f;
		SurfaceDensityDownFacing = 1.0f;
		SurfaceDensitySideFacing = 1.0f;
		FacingFalloffExponent = 2.0f;
		MaxInstanceCount = 10000;
		BrushComponent = Default__FoliageFactory_BrushComponent0/*Ref BrushComponent'Default__FoliageFactory.BrushComponent0'*/;
		bHidden = false;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FoliageFactory_BrushComponent0/*Ref BrushComponent'Default__FoliageFactory.BrushComponent0'*/,
		};
		CollisionComponent = Default__FoliageFactory_BrushComponent0/*Ref BrushComponent'Default__FoliageFactory.BrushComponent0'*/;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FoliageFactory : Volume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public partial struct /*native */FoliageMesh
	{
		public/*()*/ StaticMesh InstanceStaticMesh;
		public/*()*/ MaterialInterface Material;
		public/*()*/ float MaxDrawRadius;
		public/*()*/ float MinTransitionRadius;
		public/*()*/ Object.Vector MinScale;
		public/*()*/ Object.Vector MaxScale;
		public/*()*/ float SwayScale;
		public/*()*/ int Seed;
		public/*()*/ float SurfaceAreaPerInstance;
		public/*()*/ bool bCreateInstancesOnBSP;
		public/*()*/ bool bCreateInstancesOnStaticMeshes;
		public/*()*/ bool bCreateInstancesOnTerrain;
		public /*export editinline */FoliageComponent Component;
	
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
	
	public/*(Foliage)*/ /*const */array<FoliageFactory.FoliageMesh> Meshes;
	public/*(Foliage)*/ /*const */float VolumeFalloffRadius;
	public/*(Foliage)*/ /*const */float VolumeFalloffExponent;
	public/*(Foliage)*/ /*const */float SurfaceDensityUpFacing;
	public/*(Foliage)*/ /*const */float SurfaceDensityDownFacing;
	public/*(Foliage)*/ /*const */float SurfaceDensitySideFacing;
	public/*(Foliage)*/ /*const */float FacingFalloffExponent;
	public/*(Foliage)*/ /*const */int MaxInstanceCount;
	
	public FoliageFactory()
	{
		// Object Offset:0x0031F796
		VolumeFalloffExponent = 1.0f;
		SurfaceDensityUpFacing = 1.0f;
		SurfaceDensityDownFacing = 1.0f;
		SurfaceDensitySideFacing = 1.0f;
		FacingFalloffExponent = 2.0f;
		MaxInstanceCount = 10000;
		BrushComponent = new BrushComponent
		{
			// Object Offset:0x00465FE3
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__FoliageFactory.BrushComponent0' */;
		bHidden = false;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new BrushComponent
			{
				// Object Offset:0x00465FE3
				CollideActors = false,
				BlockNonZeroExtent = false,
			}/* Reference: BrushComponent'Default__FoliageFactory.BrushComponent0' */,
		};
		CollisionComponent = new BrushComponent
		{
			// Object Offset:0x00465FE3
			CollideActors = false,
			BlockNonZeroExtent = false,
		}/* Reference: BrushComponent'Default__FoliageFactory.BrushComponent0' */;
	}
}
}
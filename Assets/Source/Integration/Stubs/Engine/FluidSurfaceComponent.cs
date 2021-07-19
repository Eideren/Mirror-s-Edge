namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FluidSurfaceComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Fluid,Test)*/{
	[Category("Fluid")] public MaterialInterface FluidMaterial;
	[Category("Fluid")] public float FluidSpeed;
	[Category("Fluid")] public float FluidDamping;
	[Category("Fluid")] public float HeightScale;
	[Category("Fluid")] public float GridSpacing;
	[Category("Fluid")] public bool bAnimate;
	[Category("Test")] [transient] public bool bDrawNormals;
	[Category("Test")] [transient] public bool bTestRipple;
	[Category("Test")] [transient] public float TestRippleSpeed;
	[Category("Test")] [transient] public float TestRippleStrength;
	[Category("Test")] [transient] public float TestRippleRadius;
	[transient] public float TestRippleAngle;
	[native, Const, transient] public/*private*/ Object.Pointer FluidSurfaceInfo;
	
	public FluidSurfaceComponent()
	{
		// Object Offset:0x0031DB02
		FluidSpeed = 100.0f;
		FluidDamping = 0.10f;
		HeightScale = 1.0f;
		GridSpacing = 6.0f;
		bAnimate = true;
		TestRippleSpeed = 1.0f;
		TestRippleStrength = 10.0f;
		TestRippleRadius = 400.0f;
		bTickInEditor = true;
	}
}
}
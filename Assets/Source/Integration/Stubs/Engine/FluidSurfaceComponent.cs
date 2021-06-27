namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FluidSurfaceComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Object)
		autoexpandcategories(Fluid,Test)*/{
	public/*(Fluid)*/ MaterialInterface FluidMaterial;
	public/*(Fluid)*/ float FluidSpeed;
	public/*(Fluid)*/ float FluidDamping;
	public/*(Fluid)*/ float HeightScale;
	public/*(Fluid)*/ float GridSpacing;
	public/*(Fluid)*/ bool bAnimate;
	public/*(Test)*/ /*transient */bool bDrawNormals;
	public/*(Test)*/ /*transient */bool bTestRipple;
	public/*(Test)*/ /*transient */float TestRippleSpeed;
	public/*(Test)*/ /*transient */float TestRippleStrength;
	public/*(Test)*/ /*transient */float TestRippleRadius;
	public /*transient */float TestRippleAngle;
	public /*private native const transient */Object.Pointer FluidSurfaceInfo;
	
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
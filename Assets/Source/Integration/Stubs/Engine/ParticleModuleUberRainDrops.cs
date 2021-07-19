namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberRainDrops : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category("Lifetime")] public float LifetimeMin;
	[Category("Lifetime")] public float LifetimeMax;
	[Category("Size")] public Object.Vector StartSizeMin;
	[Category("Size")] public Object.Vector StartSizeMax;
	[Category("Velocity")] public Object.Vector StartVelocityMin;
	[Category("Velocity")] public Object.Vector StartVelocityMax;
	[Category("Velocity")] public float StartVelocityRadialMin;
	[Category("Velocity")] public float StartVelocityRadialMax;
	[Category("Color")] public Object.Vector ColorOverLife;
	[Category("Color")] public float AlphaOverLife;
	[Category("Location")] public bool bIsUsingCylinder;
	[Category("Location")] public bool bPositive_X;
	[Category("Location")] public bool bPositive_Y;
	[Category("Location")] public bool bPositive_Z;
	[Category("Location")] public bool bNegative_X;
	[Category("Location")] public bool bNegative_Y;
	[Category("Location")] public bool bNegative_Z;
	[Category("Location")] public bool bSurfaceOnly;
	[Category("Location")] public bool bVelocity;
	[Category("Location")] public bool bRadialVelocity;
	[Category("Location")] public float PC_VelocityScale;
	[Category("Location")] public Object.Vector PC_StartLocation;
	[Category("Location")] public float PC_StartRadius;
	[Category("Location")] public float PC_StartHeight;
	[Category("Location")] public ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis PC_HeightAxis;
	[Category("Location")] public Object.Vector StartLocationMin;
	[Category("Location")] public Object.Vector StartLocationMax;
	
	public ParticleModuleUberRainDrops()
	{
		// Object Offset:0x003884AE
		LifetimeMin = 1.0f;
		LifetimeMax = 1.0f;
		StartSizeMin = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		StartSizeMax = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		StartVelocityMin = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		StartVelocityMax = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		ColorOverLife = new Vector
		{
			X=255.90f,
			Y=255.90f,
			Z=255.90f
		};
		AlphaOverLife = 255.90f;
		bPositive_X = true;
		bPositive_Y = true;
		bPositive_Z = true;
		bNegative_X = true;
		bNegative_Y = true;
		bNegative_Z = true;
		bRadialVelocity = true;
		PC_VelocityScale = 1.0f;
		PC_StartRadius = 50.0f;
		PC_StartHeight = 50.0f;
		PC_HeightAxis = ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis.PMLPC_HEIGHTAXIS_Z;
		bSpawnModule = true;
		bUpdateModule = true;
		bSupported3DDrawMode = true;
	}
}
}
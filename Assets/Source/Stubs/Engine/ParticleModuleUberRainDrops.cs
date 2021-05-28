namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ParticleModuleUberRainDrops : ParticleModuleUberBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public/*(Lifetime)*/ float LifetimeMin;
	public/*(Lifetime)*/ float LifetimeMax;
	public/*(Size)*/ Object.Vector StartSizeMin;
	public/*(Size)*/ Object.Vector StartSizeMax;
	public/*(Velocity)*/ Object.Vector StartVelocityMin;
	public/*(Velocity)*/ Object.Vector StartVelocityMax;
	public/*(Velocity)*/ float StartVelocityRadialMin;
	public/*(Velocity)*/ float StartVelocityRadialMax;
	public/*(Color)*/ Object.Vector ColorOverLife;
	public/*(Color)*/ float AlphaOverLife;
	public/*(Location)*/ bool bIsUsingCylinder;
	public/*(Location)*/ bool bPositive_X;
	public/*(Location)*/ bool bPositive_Y;
	public/*(Location)*/ bool bPositive_Z;
	public/*(Location)*/ bool bNegative_X;
	public/*(Location)*/ bool bNegative_Y;
	public/*(Location)*/ bool bNegative_Z;
	public/*(Location)*/ bool bSurfaceOnly;
	public/*(Location)*/ bool bVelocity;
	public/*(Location)*/ bool bRadialVelocity;
	public/*(Location)*/ float PC_VelocityScale;
	public/*(Location)*/ Object.Vector PC_StartLocation;
	public/*(Location)*/ float PC_StartRadius;
	public/*(Location)*/ float PC_StartHeight;
	public/*(Location)*/ ParticleModuleLocationPrimitiveCylinder.CylinderHeightAxis PC_HeightAxis;
	public/*(Location)*/ Object.Vector StartLocationMin;
	public/*(Location)*/ Object.Vector StartLocationMax;
	
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
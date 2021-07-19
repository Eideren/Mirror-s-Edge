namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeLinearHalfspaceDensityComponent : FogVolumeDensityComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] [interp] public float PlaneDistanceFactor;
	[Category] [interp] public Object.Plane HalfspacePlane;
	
	public FogVolumeLinearHalfspaceDensityComponent()
	{
		// Object Offset:0x0031E867
		PlaneDistanceFactor = 0.10f;
		HalfspacePlane = new Plane
		{
			X=-300.0f,
			Y=0.0f,
			Z=0.0f,
			W=1.0f
		};
	}
}
}
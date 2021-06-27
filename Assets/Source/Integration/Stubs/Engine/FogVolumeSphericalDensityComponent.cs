namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeSphericalDensityComponent : FogVolumeDensityComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ /*interp */float MaxDensity;
	public/*()*/ /*interp */Object.Vector SphereCenter;
	public/*()*/ /*interp */float SphereRadius;
	public /*const export editinline */DrawLightRadiusComponent PreviewSphereRadius;
	
	public FogVolumeSphericalDensityComponent()
	{
		// Object Offset:0x0031EAC1
		MaxDensity = 0.0020f;
		SphereRadius = 600.0f;
	}
}
}
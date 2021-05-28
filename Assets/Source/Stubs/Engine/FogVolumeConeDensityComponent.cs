namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConeDensityComponent : FogVolumeDensityComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ /*interp */float MaxDensity;
	public/*()*/ /*interp */Object.Vector ConeVertex;
	public/*()*/ /*interp */float ConeRadius;
	public/*()*/ /*interp */Object.Vector ConeAxis;
	public/*()*/ /*interp */float ConeMaxAngle;
	public /*const export editinline */DrawLightConeComponent PreviewCone;
	
	public FogVolumeConeDensityComponent()
	{
		// Object Offset:0x0031E0C9
		MaxDensity = 0.0020f;
		ConeRadius = 600.0f;
		ConeAxis = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-1.0f
		};
		ConeMaxAngle = 30.0f;
	}
}
}
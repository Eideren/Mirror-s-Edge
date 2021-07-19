namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConeDensityComponent : FogVolumeDensityComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] [interp] public float MaxDensity;
	[Category] [interp] public Object.Vector ConeVertex;
	[Category] [interp] public float ConeRadius;
	[Category] [interp] public Object.Vector ConeAxis;
	[Category] [interp] public float ConeMaxAngle;
	[Const, export, editinline] public DrawLightConeComponent PreviewCone;
	
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
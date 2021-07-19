namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkyLightComponent : LightComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [Const] public float LowerBrightness;
	[Category] [Const] public Object.Color LowerColor;
	
	public SkyLightComponent()
	{
		// Object Offset:0x003E8444
		LowerColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=0
		};
		CastShadows = false;
		bCastCompositeShadow = true;
	}
}
}
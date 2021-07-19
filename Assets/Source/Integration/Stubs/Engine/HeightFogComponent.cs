namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HeightFogComponent : ActorComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [Const] public bool bEnabled;
	[Const] public float Height;
	[Category] [interp, Const] public float Density;
	[Category] [interp, Const] public float LightBrightness;
	[Category] [interp, Const] public Object.Color LightColor;
	[Category] [interp, Const] public float ExtinctionDistance;
	[Category] [interp, Const] public float StartDistance;
	
	// Export UHeightFogComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public HeightFogComponent()
	{
		// Object Offset:0x0033DAD2
		bEnabled = true;
		Density = 0.000050f;
		LightBrightness = 0.10f;
		LightColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=0
		};
		ExtinctionDistance = 100000000.0f;
	}
}
}
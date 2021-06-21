namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HeightFogComponent : ActorComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ /*const */bool bEnabled;
	public /*const */float Height;
	public/*()*/ /*interp const */float Density;
	public/*()*/ /*interp const */float LightBrightness;
	public/*()*/ /*interp const */Object.Color LightColor;
	public/*()*/ /*interp const */float ExtinctionDistance;
	public/*()*/ /*interp const */float StartDistance;
	
	// Export UHeightFogComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		#warning NATIVE FUNCTION !
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
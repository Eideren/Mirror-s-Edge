namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeDensityComponent : ActorComponent/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [Const] public bool bEnabled;
	[Category] [interp] public Object.LinearColor ApproxFogLightColor;
	[Category] [interp] public float StartDistance;
	[Category] public array<Actor> FogVolumeActors;
	
	// Export UFogVolumeDensityComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public FogVolumeDensityComponent()
	{
		// Object Offset:0x0031DEE6
		bEnabled = true;
		ApproxFogLightColor = new LinearColor
		{
			R=0.70f,
			G=0.50f,
			B=0.50f,
			A=1.0f
		};
	}
}
}
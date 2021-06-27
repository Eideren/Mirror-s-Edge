namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeDensityComponent : ActorComponent/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ /*const */bool bEnabled;
	public/*()*/ /*interp */Object.LinearColor ApproxFogLightColor;
	public/*()*/ /*interp */float StartDistance;
	public/*()*/ array<Actor> FogVolumeActors;
	
	// Export UFogVolumeDensityComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bSetEnabled)
	{
		 // #warning NATIVE FUNCTION !
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
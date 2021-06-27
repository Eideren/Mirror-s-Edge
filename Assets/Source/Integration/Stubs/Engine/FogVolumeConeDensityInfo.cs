namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConeDensityInfo : FogVolumeDensityInfo/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeConeDensityInfo()
	{
		var Default__FogVolumeConeDensityInfo_DrawCone0 = new DrawLightConeComponent
		{
			// Object Offset:0x00468AEB
			ConeColor = new Color
			{
				R=200,
				G=255,
				B=255,
				A=255
			},
		}/* Reference: DrawLightConeComponent'Default__FogVolumeConeDensityInfo.DrawCone0' */;
		var Default__FogVolumeConeDensityInfo_FogVolumeComponent0 = new FogVolumeConeDensityComponent
		{
			// Object Offset:0x00468E97
			PreviewCone = Default__FogVolumeConeDensityInfo_DrawCone0/*Ref DrawLightConeComponent'Default__FogVolumeConeDensityInfo.DrawCone0'*/,
		}/* Reference: FogVolumeConeDensityComponent'Default__FogVolumeConeDensityInfo.FogVolumeComponent0' */;
		var Default__FogVolumeConeDensityInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FogVolumeConeDensityInfo.Sprite' */;
		// Object Offset:0x0031E586
		DensityComponent = Default__FogVolumeConeDensityInfo_FogVolumeComponent0/*Ref FogVolumeConeDensityComponent'Default__FogVolumeConeDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FogVolumeConeDensityInfo_Sprite/*Ref SpriteComponent'Default__FogVolumeConeDensityInfo.Sprite'*/,
			Default__FogVolumeConeDensityInfo_DrawCone0/*Ref DrawLightConeComponent'Default__FogVolumeConeDensityInfo.DrawCone0'*/,
			Default__FogVolumeConeDensityInfo_FogVolumeComponent0/*Ref FogVolumeConeDensityComponent'Default__FogVolumeConeDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
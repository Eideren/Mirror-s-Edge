namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeLinearHalfspaceDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeLinearHalfspaceDensityInfo()
	{
		var Default__FogVolumeLinearHalfspaceDensityInfo_FogVolumeComponent0 = new FogVolumeLinearHalfspaceDensityComponent
		{
		}/* Reference: FogVolumeLinearHalfspaceDensityComponent'Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0' */;
		var Default__FogVolumeLinearHalfspaceDensityInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FogVolumeLinearHalfspaceDensityInfo.Sprite' */;
		// Object Offset:0x0031E932
		DensityComponent = Default__FogVolumeLinearHalfspaceDensityInfo_FogVolumeComponent0/*Ref FogVolumeLinearHalfspaceDensityComponent'Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FogVolumeLinearHalfspaceDensityInfo_Sprite/*Ref SpriteComponent'Default__FogVolumeLinearHalfspaceDensityInfo.Sprite'*/,
			Default__FogVolumeLinearHalfspaceDensityInfo_FogVolumeComponent0/*Ref FogVolumeLinearHalfspaceDensityComponent'Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
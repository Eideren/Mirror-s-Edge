namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConstantDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeConstantDensityInfo()
	{
		var Default__FogVolumeConstantDensityInfo_FogVolumeComponent0 = new FogVolumeConstantDensityComponent
		{
		}/* Reference: FogVolumeConstantDensityComponent'Default__FogVolumeConstantDensityInfo.FogVolumeComponent0' */;
		var Default__FogVolumeConstantDensityInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FogVolumeConstantDensityInfo.Sprite' */;
		// Object Offset:0x0031E734
		DensityComponent = Default__FogVolumeConstantDensityInfo_FogVolumeComponent0/*Ref FogVolumeConstantDensityComponent'Default__FogVolumeConstantDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FogVolumeConstantDensityInfo_Sprite/*Ref SpriteComponent'Default__FogVolumeConstantDensityInfo.Sprite'*/,
			Default__FogVolumeConstantDensityInfo_FogVolumeComponent0/*Ref FogVolumeConstantDensityComponent'Default__FogVolumeConstantDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
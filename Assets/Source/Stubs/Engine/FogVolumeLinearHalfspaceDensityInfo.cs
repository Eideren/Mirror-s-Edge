namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeLinearHalfspaceDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeLinearHalfspaceDensityInfo()
	{
		// Object Offset:0x0031E932
		DensityComponent = LoadAsset<FogVolumeLinearHalfspaceDensityComponent>("Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0")/*Ref FogVolumeLinearHalfspaceDensityComponent'Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__FogVolumeLinearHalfspaceDensityInfo.Sprite")/*Ref SpriteComponent'Default__FogVolumeLinearHalfspaceDensityInfo.Sprite'*/,
			LoadAsset<FogVolumeLinearHalfspaceDensityComponent>("Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0")/*Ref FogVolumeLinearHalfspaceDensityComponent'Default__FogVolumeLinearHalfspaceDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
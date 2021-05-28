namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeConstantDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeConstantDensityInfo()
	{
		// Object Offset:0x0031E734
		DensityComponent = LoadAsset<FogVolumeConstantDensityComponent>("Default__FogVolumeConstantDensityInfo.FogVolumeComponent0")/*Ref FogVolumeConstantDensityComponent'Default__FogVolumeConstantDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__FogVolumeConstantDensityInfo.Sprite")/*Ref SpriteComponent'Default__FogVolumeConstantDensityInfo.Sprite'*/,
			LoadAsset<FogVolumeConstantDensityComponent>("Default__FogVolumeConstantDensityInfo.FogVolumeComponent0")/*Ref FogVolumeConstantDensityComponent'Default__FogVolumeConstantDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
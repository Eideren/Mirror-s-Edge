namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeSphericalDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeSphericalDensityInfo()
	{
		// Object Offset:0x0031EB78
		DensityComponent = new FogVolumeSphericalDensityComponent
		{
			// Object Offset:0x00468EFB
			PreviewSphereRadius = LoadAsset<DrawLightRadiusComponent>("Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0")/*Ref DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0'*/,
		}/* Reference: FogVolumeSphericalDensityComponent'Default__FogVolumeSphericalDensityInfo.FogVolumeComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__FogVolumeSphericalDensityInfo.Sprite")/*Ref SpriteComponent'Default__FogVolumeSphericalDensityInfo.Sprite'*/,
			LoadAsset<DrawLightRadiusComponent>("Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0")/*Ref DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0'*/,
			new FogVolumeSphericalDensityComponent
			{
				// Object Offset:0x00468EFB
				PreviewSphereRadius = LoadAsset<DrawLightRadiusComponent>("Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0")/*Ref DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0'*/,
			}/* Reference: FogVolumeSphericalDensityComponent'Default__FogVolumeSphericalDensityInfo.FogVolumeComponent0' */,
		};
	}
}
}
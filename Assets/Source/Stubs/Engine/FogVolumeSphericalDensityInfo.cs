namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeSphericalDensityInfo : FogVolumeDensityInfo/*
		native
		placeable
		hidecategories(Navigation,Collision)*/{
	public FogVolumeSphericalDensityInfo()
	{
		var Default__FogVolumeSphericalDensityInfo_DrawSphereRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0' */;
		var Default__FogVolumeSphericalDensityInfo_FogVolumeComponent0 = new FogVolumeSphericalDensityComponent
		{
			// Object Offset:0x00468EFB
			PreviewSphereRadius = Default__FogVolumeSphericalDensityInfo_DrawSphereRadius0/*Ref DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0'*/,
		}/* Reference: FogVolumeSphericalDensityComponent'Default__FogVolumeSphericalDensityInfo.FogVolumeComponent0' */;
		var Default__FogVolumeSphericalDensityInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FogVolumeSphericalDensityInfo.Sprite' */;
		// Object Offset:0x0031EB78
		DensityComponent = Default__FogVolumeSphericalDensityInfo_FogVolumeComponent0/*Ref FogVolumeSphericalDensityComponent'Default__FogVolumeSphericalDensityInfo.FogVolumeComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FogVolumeSphericalDensityInfo_Sprite/*Ref SpriteComponent'Default__FogVolumeSphericalDensityInfo.Sprite'*/,
			Default__FogVolumeSphericalDensityInfo_DrawSphereRadius0/*Ref DrawLightRadiusComponent'Default__FogVolumeSphericalDensityInfo.DrawSphereRadius0'*/,
			Default__FogVolumeSphericalDensityInfo_FogVolumeComponent0/*Ref FogVolumeSphericalDensityComponent'Default__FogVolumeSphericalDensityInfo.FogVolumeComponent0'*/,
		};
	}
}
}
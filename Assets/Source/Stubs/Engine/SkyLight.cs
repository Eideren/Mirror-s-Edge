namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkyLight : Light/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SkyLight()
	{
		// Object Offset:0x003E8517
		LightComponent = new SkyLightComponent
		{
			// Object Offset:0x003E861A
			UseDirectLightMap = true,
			bCanAffectDynamicPrimitivesOutsideDynamicChannel = true,
		}/* Reference: SkyLightComponent'Default__SkyLight.SkyLightComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x003E85E6
				Sprite = LoadAsset<Texture2D>("EngineResources.S_SkyLight")/*Ref Texture2D'EngineResources.S_SkyLight'*/,
			}/* Reference: SpriteComponent'Default__SkyLight.Sprite' */,
			new SkyLightComponent
			{
				// Object Offset:0x003E861A
				UseDirectLightMap = true,
				bCanAffectDynamicPrimitivesOutsideDynamicChannel = true,
			}/* Reference: SkyLightComponent'Default__SkyLight.SkyLightComponent0' */,
		};
	}
}
}
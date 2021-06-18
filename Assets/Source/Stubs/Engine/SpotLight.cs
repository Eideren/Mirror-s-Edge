namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLight : Light/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SpotLight()
	{
		var Default__SpotLight_SpotLightComponent0 = new SpotLightComponent
		{
			// Object Offset:0x003ED374
			PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__SpotLight.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLight.DrawInnerCone0'*/,
			PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__SpotLight.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLight.DrawOuterCone0'*/,
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__SpotLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLight.DrawLightRadius0'*/,
			CastDynamicShadows = false,
			UseDirectLightMap = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = false,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_STATIC_AFFECTING,
		}/* Reference: SpotLightComponent'Default__SpotLight.SpotLightComponent0' */;
		var Default__SpotLight_Sprite = new SpriteComponent
		{
			// Object Offset:0x003ED2D4
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Spot_Stationary_Statics")/*Ref Texture2D'EngineResources.LightIcons.Light_Spot_Stationary_Statics'*/,
		}/* Reference: SpriteComponent'Default__SpotLight.Sprite' */;
		var Default__SpotLight_DrawOuterCone0 = new DrawLightConeComponent
		{
			// Object Offset:0x003ED338
			ConeColor = new Color
			{
				R=200,
				G=255,
				B=255,
				A=255
			},
		}/* Reference: DrawLightConeComponent'Default__SpotLight.DrawOuterCone0' */;
		var Default__SpotLight_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x003ED484
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
		}/* Reference: ArrowComponent'Default__SpotLight.ArrowComponent0' */;
		// Object Offset:0x003ED16D
		LightComponent = Default__SpotLight_SpotLightComponent0;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SpotLight_Sprite,
			LoadAsset<DrawLightRadiusComponent>("Default__SpotLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLight.DrawLightRadius0'*/,
			LoadAsset<DrawLightConeComponent>("Default__SpotLight.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLight.DrawInnerCone0'*/,
			Default__SpotLight_DrawOuterCone0,
			Default__SpotLight_SpotLightComponent0,
			Default__SpotLight_ArrowComponent0,
		};
		Rotation = new Rotator
		{
			Pitch=-16384,
			Yaw=0,
			Roll=0
		};
		DesiredRotation = new Rotator
		{
			Pitch=-16384,
			Yaw=0,
			Roll=0
		};
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLight : Light/*
		native
		placeable
		hidecategories(Navigation)*/{
	public PointLight()
	{
		// Object Offset:0x003A2AA0
		LightComponent = new PointLightComponent
		{
			// Object Offset:0x003A2BAF
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__PointLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0'*/,
			CastDynamicShadows = false,
			UseDirectLightMap = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = false,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_STATIC_AFFECTING,
		}/* Reference: PointLightComponent'Default__PointLight.PointLightComponent0' */;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__PointLight.Sprite")/*Ref SpriteComponent'Default__PointLight.Sprite'*/,
			LoadAsset<DrawLightRadiusComponent>("Default__PointLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0'*/,
			//Components[2]=
			new PointLightComponent
			{
				// Object Offset:0x003A2BAF
				PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__PointLight.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0'*/,
				CastDynamicShadows = false,
				UseDirectLightMap = true,
				LightingChannels = new LightComponent.LightingChannelContainer
				{
					Dynamic = false,
				},
				LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_STATIC_AFFECTING,
			}/* Reference: PointLightComponent'Default__PointLight.PointLightComponent0' */,
		};
	}
}
}
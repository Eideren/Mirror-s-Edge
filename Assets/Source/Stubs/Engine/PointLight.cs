namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLight : Light/*
		native
		placeable
		hidecategories(Navigation)*/{
	public PointLight()
	{
		var Default__PointLight_DrawLightRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0' */;
		var Default__PointLight_PointLightComponent0 = new PointLightComponent
		{
			// Object Offset:0x003A2BAF
			PreviewLightRadius = Default__PointLight_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0'*/,
			CastDynamicShadows = false,
			UseDirectLightMap = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = false,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_STATIC_AFFECTING,
		}/* Reference: PointLightComponent'Default__PointLight.PointLightComponent0' */;
		var Default__PointLight_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PointLight.Sprite' */;
		// Object Offset:0x003A2AA0
		LightComponent = Default__PointLight_PointLightComponent0/*Ref PointLightComponent'Default__PointLight.PointLightComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PointLight_Sprite/*Ref SpriteComponent'Default__PointLight.Sprite'*/,
			Default__PointLight_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__PointLight.DrawLightRadius0'*/,
			Default__PointLight_PointLightComponent0/*Ref PointLightComponent'Default__PointLight.PointLightComponent0'*/,
		};
	}
}
}
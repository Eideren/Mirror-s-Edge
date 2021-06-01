namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightMovable : SpotLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SpotLightMovable()
	{
		// Object Offset:0x003ED4C0
		LightComponent = new SpotLightComponent
		{
			// Object Offset:0x004CF472
			PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0'*/,
			PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0'*/,
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__SpotLightMovable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0'*/,
			CastDynamicShadows = true,
			UseDirectLightMap = false,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
		}/* Reference: SpotLightComponent'Default__SpotLightMovable.SpotLightComponent0' */;
		bStatic = false;
		bHardAttach = true;
		bMovable = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004D05D6
				Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Spot_Moveable_DynamicsAndStatics")/*Ref Texture2D'EngineResources.LightIcons.Light_Spot_Moveable_DynamicsAndStatics'*/,
			}/* Reference: SpriteComponent'Default__SpotLightMovable.Sprite' */,
			LoadAsset<DrawLightRadiusComponent>("Default__SpotLightMovable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0'*/,
			LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0'*/,
			LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0'*/,
			new SpotLightComponent
			{
				// Object Offset:0x004CF472
				PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0'*/,
				PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightMovable.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0'*/,
				PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__SpotLightMovable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0'*/,
				CastDynamicShadows = true,
				UseDirectLightMap = false,
				LightingChannels = new LightComponent.LightingChannelContainer
				{
					Dynamic = true,
				},
				LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
			}/* Reference: SpotLightComponent'Default__SpotLightMovable.SpotLightComponent0' */,
			LoadAsset<ArrowComponent>("Default__SpotLightMovable.ArrowComponent0")/*Ref ArrowComponent'Default__SpotLightMovable.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
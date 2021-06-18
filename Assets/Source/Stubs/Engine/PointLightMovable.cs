namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLightMovable : PointLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public PointLightMovable()
	{
		var Default__PointLightMovable_PointLightComponent0 = new PointLightComponent
		{
			// Object Offset:0x004CADFA
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__PointLightMovable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLightMovable.DrawLightRadius0'*/,
			CastDynamicShadows = true,
			UseDirectLightMap = false,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
		}/* Reference: PointLightComponent'Default__PointLightMovable.PointLightComponent0' */;
		var Default__PointLightMovable_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D000A
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Point_Moveable_DynamicsAndStatics")/*Ref Texture2D'EngineResources.LightIcons.Light_Point_Moveable_DynamicsAndStatics'*/,
		}/* Reference: SpriteComponent'Default__PointLightMovable.Sprite' */;
		// Object Offset:0x003A2C87
		LightComponent = Default__PointLightMovable_PointLightComponent0;
		bStatic = false;
		bHardAttach = true;
		bMovable = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PointLightMovable_Sprite,
			LoadAsset<DrawLightRadiusComponent>("Default__PointLightMovable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLightMovable.DrawLightRadius0'*/,
			Default__PointLightMovable_PointLightComponent0,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
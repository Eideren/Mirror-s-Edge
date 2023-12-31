namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightMovable : SpotLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SpotLightMovable()
	{
		var Default__SpotLightMovable_DrawInnerCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0' */;
		var Default__SpotLightMovable_DrawOuterCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0' */;
		var Default__SpotLightMovable_DrawLightRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0' */;
		var Default__SpotLightMovable_SpotLightComponent0 = new SpotLightComponent
		{
			// Object Offset:0x004CF472
			PreviewInnerCone = Default__SpotLightMovable_DrawInnerCone0/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0'*/,
			PreviewOuterCone = Default__SpotLightMovable_DrawOuterCone0/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0'*/,
			PreviewLightRadius = Default__SpotLightMovable_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0'*/,
			CastDynamicShadows = true,
			UseDirectLightMap = false,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				Dynamic = true,
			},
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
		}/* Reference: SpotLightComponent'Default__SpotLightMovable.SpotLightComponent0' */;
		var Default__SpotLightMovable_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D05D6
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Spot_Moveable_DynamicsAndStatics")/*Ref Texture2D'EngineResources.LightIcons.Light_Spot_Moveable_DynamicsAndStatics'*/,
		}/* Reference: SpriteComponent'Default__SpotLightMovable.Sprite' */;
		var Default__SpotLightMovable_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__SpotLightMovable.ArrowComponent0' */;
		// Object Offset:0x003ED4C0
		LightComponent = Default__SpotLightMovable_SpotLightComponent0/*Ref SpotLightComponent'Default__SpotLightMovable.SpotLightComponent0'*/;
		bStatic = false;
		bHardAttach = true;
		bMovable = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SpotLightMovable_Sprite/*Ref SpriteComponent'Default__SpotLightMovable.Sprite'*/,
			Default__SpotLightMovable_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__SpotLightMovable.DrawLightRadius0'*/,
			Default__SpotLightMovable_DrawInnerCone0/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawInnerCone0'*/,
			Default__SpotLightMovable_DrawOuterCone0/*Ref DrawLightConeComponent'Default__SpotLightMovable.DrawOuterCone0'*/,
			Default__SpotLightMovable_SpotLightComponent0/*Ref SpotLightComponent'Default__SpotLightMovable.SpotLightComponent0'*/,
			Default__SpotLightMovable_ArrowComponent0/*Ref ArrowComponent'Default__SpotLightMovable.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
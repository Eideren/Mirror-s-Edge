namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightToggleable : SpotLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SpotLightToggleable()
	{
		var Default__SpotLightToggleable_DrawInnerCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__SpotLightToggleable.DrawInnerCone0' */;
		var Default__SpotLightToggleable_DrawOuterCone0 = new DrawLightConeComponent
		{
		}/* Reference: DrawLightConeComponent'Default__SpotLightToggleable.DrawOuterCone0' */;
		var Default__SpotLightToggleable_DrawLightRadius0 = new DrawLightRadiusComponent
		{
		}/* Reference: DrawLightRadiusComponent'Default__SpotLightToggleable.DrawLightRadius0' */;
		var Default__SpotLightToggleable_SpotLightComponent0 = new SpotLightComponent
		{
			// Object Offset:0x004CF582
			PreviewInnerCone = Default__SpotLightToggleable_DrawInnerCone0/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawInnerCone0'*/,
			PreviewOuterCone = Default__SpotLightToggleable_DrawOuterCone0/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawOuterCone0'*/,
			PreviewLightRadius = Default__SpotLightToggleable_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__SpotLightToggleable.DrawLightRadius0'*/,
			UseDirectLightMap = false,
		}/* Reference: SpotLightComponent'Default__SpotLightToggleable.SpotLightComponent0' */;
		var Default__SpotLightToggleable_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D060A
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Spot_Toggleable_Statics")/*Ref Texture2D'EngineResources.LightIcons.Light_Spot_Toggleable_Statics'*/,
		}/* Reference: SpriteComponent'Default__SpotLightToggleable.Sprite' */;
		var Default__SpotLightToggleable_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__SpotLightToggleable.ArrowComponent0' */;
		// Object Offset:0x003ED643
		LightComponent = Default__SpotLightToggleable_SpotLightComponent0/*Ref SpotLightComponent'Default__SpotLightToggleable.SpotLightComponent0'*/;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SpotLightToggleable_Sprite/*Ref SpriteComponent'Default__SpotLightToggleable.Sprite'*/,
			Default__SpotLightToggleable_DrawLightRadius0/*Ref DrawLightRadiusComponent'Default__SpotLightToggleable.DrawLightRadius0'*/,
			Default__SpotLightToggleable_DrawInnerCone0/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawInnerCone0'*/,
			Default__SpotLightToggleable_DrawOuterCone0/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawOuterCone0'*/,
			Default__SpotLightToggleable_SpotLightComponent0/*Ref SpotLightComponent'Default__SpotLightToggleable.SpotLightComponent0'*/,
			Default__SpotLightToggleable_ArrowComponent0/*Ref ArrowComponent'Default__SpotLightToggleable.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
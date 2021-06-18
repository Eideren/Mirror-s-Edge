namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpotLightToggleable : SpotLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SpotLightToggleable()
	{
		var Default__SpotLightToggleable_SpotLightComponent0 = new SpotLightComponent
		{
			// Object Offset:0x004CF582
			PreviewInnerCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightToggleable.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawInnerCone0'*/,
			PreviewOuterCone = LoadAsset<DrawLightConeComponent>("Default__SpotLightToggleable.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawOuterCone0'*/,
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__SpotLightToggleable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLightToggleable.DrawLightRadius0'*/,
			UseDirectLightMap = false,
		}/* Reference: SpotLightComponent'Default__SpotLightToggleable.SpotLightComponent0' */;
		var Default__SpotLightToggleable_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D060A
			Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Spot_Toggleable_Statics")/*Ref Texture2D'EngineResources.LightIcons.Light_Spot_Toggleable_Statics'*/,
		}/* Reference: SpriteComponent'Default__SpotLightToggleable.Sprite' */;
		// Object Offset:0x003ED643
		LightComponent = Default__SpotLightToggleable_SpotLightComponent0;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SpotLightToggleable_Sprite,
			LoadAsset<DrawLightRadiusComponent>("Default__SpotLightToggleable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__SpotLightToggleable.DrawLightRadius0'*/,
			LoadAsset<DrawLightConeComponent>("Default__SpotLightToggleable.DrawInnerCone0")/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawInnerCone0'*/,
			LoadAsset<DrawLightConeComponent>("Default__SpotLightToggleable.DrawOuterCone0")/*Ref DrawLightConeComponent'Default__SpotLightToggleable.DrawOuterCone0'*/,
			Default__SpotLightToggleable_SpotLightComponent0,
			LoadAsset<ArrowComponent>("Default__SpotLightToggleable.ArrowComponent0")/*Ref ArrowComponent'Default__SpotLightToggleable.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
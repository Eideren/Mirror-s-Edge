namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DirectionalLightToggleable : DirectionalLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public DirectionalLightToggleable()
	{
		// Object Offset:0x0030DDD1
		LightComponent = new DirectionalLightComponent
		{
			// Object Offset:0x00466927
			UseDirectLightMap = false,
			LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
		}/* Reference: DirectionalLightComponent'Default__DirectionalLightToggleable.DirectionalLightComponent0' */;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004CF942
				Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Directional_Toggleable_DynamicsAndStatics")/*Ref Texture2D'EngineResources.LightIcons.Light_Directional_Toggleable_DynamicsAndStatics'*/,
			}/* Reference: SpriteComponent'Default__DirectionalLightToggleable.Sprite' */,
			new DirectionalLightComponent
			{
				// Object Offset:0x00466927
				UseDirectLightMap = false,
				LightAffectsClassification = LightComponent.ELightAffectsClassification.LAC_DYNAMIC_AND_STATIC_AFFECTING,
			}/* Reference: DirectionalLightComponent'Default__DirectionalLightToggleable.DirectionalLightComponent0' */,
			LoadAsset<ArrowComponent>("Default__DirectionalLightToggleable.ArrowComponent0")/*Ref ArrowComponent'Default__DirectionalLightToggleable.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
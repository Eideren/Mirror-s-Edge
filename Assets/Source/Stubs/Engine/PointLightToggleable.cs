namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PointLightToggleable : PointLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public PointLightToggleable()
	{
		// Object Offset:0x003A2DDA
		LightComponent = new PointLightComponent
		{
			// Object Offset:0x004CAED2
			PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__PointLightToggleable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLightToggleable.DrawLightRadius0'*/,
			UseDirectLightMap = false,
		}/* Reference: PointLightComponent'Default__PointLightToggleable.PointLightComponent0' */;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004D003E
				Sprite = LoadAsset<Texture2D>("EngineResources.LightIcons.Light_Point_Toggleable_Statics")/*Ref Texture2D'EngineResources.LightIcons.Light_Point_Toggleable_Statics'*/,
			}/* Reference: SpriteComponent'Default__PointLightToggleable.Sprite' */,
			LoadAsset<DrawLightRadiusComponent>("Default__PointLightToggleable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLightToggleable.DrawLightRadius0'*/,
			new PointLightComponent
			{
				// Object Offset:0x004CAED2
				PreviewLightRadius = LoadAsset<DrawLightRadiusComponent>("Default__PointLightToggleable.DrawLightRadius0")/*Ref DrawLightRadiusComponent'Default__PointLightToggleable.DrawLightRadius0'*/,
				UseDirectLightMap = false,
			}/* Reference: PointLightComponent'Default__PointLightToggleable.PointLightComponent0' */,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
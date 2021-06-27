namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkyLightToggleable : SkyLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SkyLightToggleable()
	{
		var Default__SkyLightToggleable_SkyLightComponent0 = new SkyLightComponent
		{
		}/* Reference: SkyLightComponent'Default__SkyLightToggleable.SkyLightComponent0' */;
		var Default__SkyLightToggleable_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__SkyLightToggleable.Sprite' */;
		// Object Offset:0x003E8672
		LightComponent = Default__SkyLightToggleable_SkyLightComponent0/*Ref SkyLightComponent'Default__SkyLightToggleable.SkyLightComponent0'*/;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__SkyLightToggleable_Sprite/*Ref SpriteComponent'Default__SkyLightToggleable.Sprite'*/,
			Default__SkyLightToggleable_SkyLightComponent0/*Ref SkyLightComponent'Default__SkyLightToggleable.SkyLightComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
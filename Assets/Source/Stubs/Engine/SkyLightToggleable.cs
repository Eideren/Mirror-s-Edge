namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkyLightToggleable : SkyLight/*
		native
		placeable
		hidecategories(Navigation)*/{
	public SkyLightToggleable()
	{
		// Object Offset:0x003E8672
		LightComponent = LoadAsset<SkyLightComponent>("Default__SkyLightToggleable.SkyLightComponent0")/*Ref SkyLightComponent'Default__SkyLightToggleable.SkyLightComponent0'*/;
		bStatic = false;
		bHardAttach = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__SkyLightToggleable.Sprite")/*Ref SpriteComponent'Default__SkyLightToggleable.Sprite'*/,
			LoadAsset<SkyLightComponent>("Default__SkyLightToggleable.SkyLightComponent0")/*Ref SkyLightComponent'Default__SkyLightToggleable.SkyLightComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
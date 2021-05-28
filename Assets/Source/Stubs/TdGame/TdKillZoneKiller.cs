namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdKillZoneKiller : Info/*
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdKillZoneKiller()
	{
		// Object Offset:0x00580E08
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdKillZoneKiller.Sprite")/*Ref SpriteComponent'Default__TdKillZoneKiller.Sprite'*/,
		};
	}
}
}
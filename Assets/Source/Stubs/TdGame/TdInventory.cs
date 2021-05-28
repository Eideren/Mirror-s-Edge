namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInventory : Inventory/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdInventory()
	{
		// Object Offset:0x0057CFD0
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdInventory.Sprite")/*Ref SpriteComponent'Default__TdInventory.Sprite'*/,
		};
	}
}
}
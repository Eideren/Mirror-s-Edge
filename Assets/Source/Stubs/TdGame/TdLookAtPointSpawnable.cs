namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLookAtPointSpawnable : TdLookAtPoint/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdLookAtPointSpawnable()
	{
		// Object Offset:0x0058D4CB
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdLookAtPointSpawnable.Sprite")/*Ref SpriteComponent'Default__TdLookAtPointSpawnable.Sprite'*/,
		};
	}
}
}
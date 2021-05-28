namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_PatrolCop : TdAIController/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public TdAI_PatrolCop()
	{
		// Object Offset:0x004DD0B9
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAI_PatrolCop.Sprite")/*Ref SpriteComponent'Default__TdAI_PatrolCop.Sprite'*/,
		};
	}
}
}
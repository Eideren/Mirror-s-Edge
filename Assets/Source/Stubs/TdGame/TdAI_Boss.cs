namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAI_Boss : TdAIController/*
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public override /*function */bool CanSearch()
	{
	
		return default;
	}
	
	public override /*function */bool CanInvestigate()
	{
	
		return default;
	}
	
	public TdAI_Boss()
	{
		var Default__TdAI_Boss_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAI_Boss.Sprite' */;
		// Object Offset:0x004D0FA2
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAI_Boss_Sprite/*Ref SpriteComponent'Default__TdAI_Boss.Sprite'*/,
		};
	}
}
}
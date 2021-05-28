namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMeleeSecondSwing_CopRemington : TdMove_BotMeleeSecondSwing/*
		config(AIMeleeAttacks)*/{
	public TdMove_BotMeleeSecondSwing_CopRemington()
	{
		// Object Offset:0x005A43D8
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitRange = 110.0f,
			Damage = 50.0f,
		};
	}
}
}
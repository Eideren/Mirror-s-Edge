namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMeleeSecondSwing_Support : TdMove_BotMeleeSecondSwing/*
		config(AIMeleeAttacks)*/{
	public TdMove_BotMeleeSecondSwing_Support()
	{
		// Object Offset:0x005A455A
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			Damage = 60.0f,
		};
	}
}
}
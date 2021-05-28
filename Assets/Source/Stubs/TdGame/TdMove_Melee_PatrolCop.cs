namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee_PatrolCop : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public override /*simulated function */void TriggerMiss()
	{
	
	}
	
	public TdMove_Melee_PatrolCop()
	{
		// Object Offset:0x005D1276
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitRange = 110.0f,
			Damage = 40.0f,
		};
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee_SupportCop : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public TdMove_Melee_SupportCop()
	{
		// Object Offset:0x005D17FE
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			Damage = 60.0f,
		};
	}
}
}
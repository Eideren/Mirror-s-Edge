namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Melee_Assault : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public TdMove_Melee_Assault()
	{
		// Object Offset:0x005CDC90
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitRange = 80.0f,
			Damage = 50.0f,
		};
	}
}
}
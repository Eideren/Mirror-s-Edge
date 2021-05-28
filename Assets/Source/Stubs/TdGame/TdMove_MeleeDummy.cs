namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeDummy : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public TdMove_MeleeDummy()
	{
		// Object Offset:0x005D502D
		GenericAttackProperties = new TdMove_BotMelee.MeleeAttackProperties
		{
			HitAngle = 140.0f,
			HitRange = 120.0f,
			Damage = 50.0f,
			RotationSpeed = 0.0f,
		};
	}
}
}
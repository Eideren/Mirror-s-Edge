namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_ExplosionDamage : TdHudEffect/*
		native
		config(HudEffects)*/{
	public TdHudEffect_ExplosionDamage()
	{
		// Object Offset:0x0056FCE6
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"FXFScreen_ExplosionDamage",
		};
	}
}
}
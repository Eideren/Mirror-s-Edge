namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_ElectricShock : TdHudEffect_Taser/*
		native
		config(HudEffects)*/{
	public TdHudEffect_ElectricShock()
	{
		// Object Offset:0x0056FBEF
		Blur = new TdHudEffect.BlurSettings
		{
			MaxFarBlurAmount = 0.750f,
		};
		PPStrength = new TdHudEffect.PPSettings
		{
			Duration = 0.50f,
		};
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHudEffect_Saturation : TdHudEffect/*
		native
		config(HudEffects)*/{
	public virtual /*function */void SpecialActivatePP()
	{
	
	}
	
	public virtual /*function */void SpecialDeActivatePP()
	{
	
	}
	
	public TdHudEffect_Saturation()
	{
		// Object Offset:0x00570E3F
		PPStrength = new TdHudEffect.PPSettings
		{
			ParameterName = (name)"SaturationAmount",
			FadeInDuration = 0.50f,
			Duration = -1.0f,
			FadeOutDuration = 0.50f,
		};
	}
}
}
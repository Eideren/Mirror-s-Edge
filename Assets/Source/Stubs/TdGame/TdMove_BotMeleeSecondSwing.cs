namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMeleeSecondSwing : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void TriggerMove()
	{
		// stub
	}
	
	public override /*simulated function */void TriggerMiss()
	{
		// stub
	}
	
	public override /*event */void TriggerHit()
	{
		// stub
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public virtual /*private final function */void TriggerStartAnimation()
	{
		// stub
	}
	
	public virtual /*private final function */void TriggerEndAnimation()
	{
		// stub
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
		// stub
		return default;
	}
	
}
}
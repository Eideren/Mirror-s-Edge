namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMeleeSecondSwing : TdMove_BotMelee/*
		config(AIMeleeAttacks)*/{
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void TriggerMove()
	{
	
	}
	
	public override /*simulated function */void TriggerMiss()
	{
	
	}
	
	public override /*event */void TriggerHit()
	{
	
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public virtual /*private final function */void TriggerStartAnimation()
	{
	
	}
	
	public virtual /*private final function */void TriggerEndAnimation()
	{
	
	}
	
	public override /*simulated function */Core.ClassT<DamageType> GetDamageType()
	{
	
		return default;
	}
	
}
}
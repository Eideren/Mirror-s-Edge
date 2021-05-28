namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_HeadButtedByCeleste : TdMOVE_Disarm/*
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*function */void TakeDisarmedPawnsWeapon()
	{
	
	}
	
	public override /*function */void ChooseDisarmType(ref Object.Rotator YawOffset)
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*function */void TriggerHitPlayer()
	{
	
	}
	
}
}
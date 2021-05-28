namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Disarm_Tutorial : TdMOVE_Disarm/*
		config(PawnMovement)*/{
	public /*private */bool bIsFrontalDisarm;
	public /*private */TdAIController DisarmedController;
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public override /*function */void AlignPawn()
	{
	
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator PawnRotation, float DeltaTime, ref Object.Rotator DeltaRotation)
	{
	
	}
	
	public override /*function */void ChooseDisarmType(ref Object.Rotator YawOffset)
	{
	
	}
	
	public override /*function */void TakeDisarmedPawnsWeapon()
	{
	
	}
	
	public TdMove_Disarm_Tutorial()
	{
		// Object Offset:0x005B3013
		DisableMovementTime = 0.0f;
		DisableLookTime = 0.0f;
	}
}
}
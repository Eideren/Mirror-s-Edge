namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_MeleeAirAboveBot : TdMove_MeleeBase/*
		config(PawnMovement)*/{
	public virtual /*function */void PlayCannedAnim(name AnimationName)
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public override /*simulated function */void OnTimer()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public TdMove_MeleeAirAboveBot()
	{
		// Object Offset:0x005D3C2E
		bDisableCollision = true;
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_FallingBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public bool bPrepareLanding;
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public virtual /*simulated event */void CloseToGround()
	{
		// stub
	}
	
	public TdMove_FallingBot()
	{
		// Object Offset:0x005B6FE3
		bDisableCollision = false;
	}
}
}
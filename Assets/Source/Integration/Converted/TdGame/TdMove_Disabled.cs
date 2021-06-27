namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Disabled : TdMove/*
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
		return false;
	}
	
	public override /*simulated function */void StartMove()
	{
		ScriptTrace();
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotRoll : TdMove/*
		config(PawnMovement)*/{
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PawnOwner.UseRootMotion(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "RollFwd", 1.0f, 0.20f, 0.20f, true, false);
		BotOwner.myController.HeadFocus.PushEnabled(false, Class.Name);
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		BotOwner.myController.NotifyMoveFinished();
		BotOwner.myController.HeadFocus.PopEnabled(Class.Name);
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool), default(bool));
	}
	
}
}
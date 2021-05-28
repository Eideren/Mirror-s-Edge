namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotTurnRunning : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public /*private */Object.Rotator WantedDeltaRotation;
	public /*private */Object.Rotator InitialPawnRotation;
	public /*private */float RotationCompensationRate;
	public /*private */Object.Rotator DirectionOfMovement;
	public /*private */Object.Rotator PawnRotation;
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public virtual /*simulated function */void StartTurn()
	{
	
	}
	
	public virtual /*function */void SetRotationCompensationRate(float AnimationRootRotationAngle)
	{
	
	}
	
	public virtual /*function */float GetTurnAngle()
	{
	
		return default;
	}
	
	public virtual /*function */void AdjustRotation()
	{
	
	}
	
	public override /*simulated function */void RootRotationCompletedNotify()
	{
	
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
	
	}
	
}
}
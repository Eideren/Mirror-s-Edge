namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotStop : TdMove/*
		native
		config(PawnMovement)*/{
	[Category] public/*private*/ float MaxRunningStopTriggerDist;
	[Category] public/*private*/ float MinRunningStopTriggerDist;
	[Category] public/*private*/ float MaxWalkingStopTriggerDist;
	[Category] public/*private*/ float MinWalkingStopTriggerDist;
	[Category] public/*private*/ float StopMoveDistanceRunning;
	[Category] public/*private*/ float StopMoveDistanceWalking;
	public/*private*/ int DeltaPawnRotationYaw;
	public/*private*/ int InitialPawnRotationYaw;
	public/*private*/ int InitialLegRotationYaw;
	public/*private*/ int DeltaLegRotationYaw;
	public/*private*/ Object.Rotator WantedRotation;
	public/*private*/ float BlendInTime;
	public/*private*/ float BlendOutTime;
	public/*private*/ float TimeIntoRotation;
	public/*private*/ float RotationTime;
	public/*private*/ bool bStopAnimationStarted;
	public/*private*/ bool bUseLegRotation;
	public/*private*/ bool bUsePawnRotation;
	public/*private*/ bool bMoveDestinationSet;
	public/*private*/ bool bWalkingStop;
	public/*private*/ bool bUsePerfectStopDebug;
	public/*private*/ bool bShouldCheckFalling;
	public/*private*/ Object.Vector MoveDestination;
	public/*private*/ float SetMoveDestinationTimeStamp;
	
	public virtual /*function */bool GetStopAnimationStarted()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UseDebugPerfectStop(bool Input)
	{
		// stub
	}
	
	public virtual /*event */void SetMoveDestination(Object.Vector Dest)
	{
		// stub
	}
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool WillFallDown(/*optional */float? _ExtraDistance = default, /*optional */bool? _AddMoveLength = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void Fail()
	{
		// stub
	}
	
	public virtual /*private final function */bool IsWalkingStop()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool IsDistanceOk()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public virtual /*function */float GetBlendOutTime()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void CalculateBestStop(float IdealStopTime)
	{
		// stub
	}
	
	public virtual /*simulated function */void CheckFalling()
	{
		// stub
	}
	
	public override /*simulated event */void OnTimer()
	{
		// stub
	}
	
	public virtual /*simulated function */void ActivateStopMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public virtual /*private final function */void StopWalking()
	{
		// stub
	}
	
	public virtual /*private final function */void StopRunning()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
		// stub
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		// stub
	}
	
	public TdMove_BotStop()
	{
		// Object Offset:0x005A96F8
		MaxRunningStopTriggerDist = 145.0f;
		MinRunningStopTriggerDist = 105.0f;
		MaxWalkingStopTriggerDist = 90.0f;
		MinWalkingStopTriggerDist = 70.0f;
		StopMoveDistanceRunning = 145.0f;
		StopMoveDistanceWalking = 80.0f;
	}
}
}
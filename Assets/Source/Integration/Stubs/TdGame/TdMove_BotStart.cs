namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotStart : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public enum LegOffsetType 
	{
		LOT_WalkForward,
		LOT_WalkLeft60,
		LOT_WalkLeftBwd120,
		LOT_WalkRight60,
		LOT_WalkRightBwd120,
		LOT_WalkBack,
		LOT_RunForward,
		LOT_RunLeft90,
		LOT_RunLeft180,
		LOT_RunRight90,
		LOT_RunRight180,
		LOT_MAX
	};
	
	public/*private*/ int DeltaPawnRotationYaw;
	public/*private*/ int InitialPawnRotationYaw;
	public/*private*/ int InitialLegRotationYaw;
	public/*private*/ int DeltaLegRotationYaw;
	public/*private*/ Object.Rotator WantedRotation;
	public/*private*/ int AnimationTurnAngle;
	public/*private*/ float BlendInTime;
	public/*private*/ float BlendOutTime;
	public/*private*/ float TimeIntoAnimation;
	public/*private*/ float AnimationLength;
	public/*private*/ bool bUseLegRotation;
	public/*private*/ bool bUsePawnRotation;
	public/*private*/ bool bGoingStraightForwards;
	public bool bDrawDebug;
	public/*private*/ name AnimationName;
	public/*protected*/ float fMoveStartedTimeStamp;
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public virtual /*private final function */void SetInitialValues()
	{
		// stub
	}
	
	public virtual /*function */bool GoingStraightForwards()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void StartWalkingWithFocus()
	{
		// stub
	}
	
	public virtual /*private final function */void StartRunning()
	{
		// stub
	}
	
	public virtual /*function */float GetSyncOffset(TdMove_BotStart.LegOffsetType Offset)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void RootRotationCompletedNotify()
	{
		// stub
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
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
	
	public TdMove_BotStart()
	{
		// Object Offset:0x005A6F1D
		bEnableFootPlacement = true;
	}
}
}
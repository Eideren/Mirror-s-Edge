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
	
	public /*private */int DeltaPawnRotationYaw;
	public /*private */int InitialPawnRotationYaw;
	public /*private */int InitialLegRotationYaw;
	public /*private */int DeltaLegRotationYaw;
	public /*private */Object.Rotator WantedRotation;
	public /*private */int AnimationTurnAngle;
	public /*private */float BlendInTime;
	public /*private */float BlendOutTime;
	public /*private */float TimeIntoAnimation;
	public /*private */float AnimationLength;
	public /*private */bool bUseLegRotation;
	public /*private */bool bUsePawnRotation;
	public /*private */bool bGoingStraightForwards;
	public bool bDrawDebug;
	public /*private */name AnimationName;
	public /*protected */float fMoveStartedTimeStamp;
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public virtual /*private final function */void SetInitialValues()
	{
	
	}
	
	public virtual /*function */bool GoingStraightForwards()
	{
	
		return default;
	}
	
	public virtual /*private final function */void StartWalkingWithFocus()
	{
	
	}
	
	public virtual /*private final function */void StartRunning()
	{
	
	}
	
	public virtual /*function */float GetSyncOffset(TdMove_BotStart.LegOffsetType Offset)
	{
	
		return default;
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
	
	public TdMove_BotStart()
	{
		// Object Offset:0x005A6F1D
		bEnableFootPlacement = true;
	}
}
}
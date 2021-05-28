namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotTurnStanding : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public /*private */int DeltaRotationYaw;
	public /*private */int DeltaLegRotationYaw;
	public /*private */int InitialPawnRotationYaw;
	public /*private */int InitialLegRotationYaw;
	public /*private */float BlendInTime;
	public /*private */float BlendOutTime;
	public /*private */float TimeIntoRotation;
	public /*private */float RotationTime;
	public /*private */bool bRotatePawn;
	public /*private */bool bIsFocusPointSet;
	public /*private */Object.Vector FocusPoint;
	public /*private */float SetFocusPointTimeStamp;
	public /*private */float LegTurnAngle;
	
	public virtual /*event */void SetFocusPoint(Object.Vector P)
	{
	
	}
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	// Export UTdMove_BotTurnStanding::execCalculateLegTurnAngle(FFrame&, void* const)
	public virtual /*private native final function */float CalculateLegTurnAngle()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */float GetBlendOutTime()
	{
	
		return default;
	}
	
	public virtual /*function */float GetBlendInTime()
	{
	
		return default;
	}
	
	public virtual /*private final function */void StartAnimation()
	{
	
	}
	
	public override /*simulated function */void StopMove()
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
	
	public TdMove_BotTurnStanding()
	{
		// Object Offset:0x005AC55E
		bEnableFootPlacement = true;
	}
}
}
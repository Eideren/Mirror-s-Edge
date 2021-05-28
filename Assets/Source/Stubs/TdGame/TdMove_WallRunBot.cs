namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallRunBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public /*transient */bool bControlPawnMovement;
	public /*transient */Object.Vector PawnLocation;
	public /*transient */Object.Vector PawnRotation;
	public /*transient */float VerticalTranslation;
	public /*transient */float HorizontalTranslation;
	public /*transient */Object.Vector MoveStartLocation;
	public /*transient */Object.Vector MoveEndLocation;
	public /*transient */float StartTime;
	public /*transient */float EndTime;
	public /*transient */float ClimbNotifierStartTime;
	public /*transient */float ClimbNotifierEndTime;
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public virtual /*simulated function */void FindClimbNotifiers()
	{
	
	}
	
	public virtual /*simulated function */void ClimbInitiatedNotify()
	{
	
	}
	
	public virtual /*simulated function */void ClimbCompletedNotify()
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
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
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		// stub
	}
	
	public virtual /*simulated function */void FindClimbNotifiers()
	{
		// stub
	}
	
	public virtual /*simulated function */void ClimbInitiatedNotify()
	{
		// stub
	}
	
	public virtual /*simulated function */void ClimbCompletedNotify()
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
	
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallRunBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	[transient] public bool bControlPawnMovement;
	[transient] public Object.Vector PawnLocation;
	[transient] public Object.Vector PawnRotation;
	[transient] public float VerticalTranslation;
	[transient] public float HorizontalTranslation;
	[transient] public Object.Vector MoveStartLocation;
	[transient] public Object.Vector MoveEndLocation;
	[transient] public float StartTime;
	[transient] public float EndTime;
	[transient] public float ClimbNotifierStartTime;
	[transient] public float ClimbNotifierEndTime;
	
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
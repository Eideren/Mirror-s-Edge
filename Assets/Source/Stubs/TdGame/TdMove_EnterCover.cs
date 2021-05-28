namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_EnterCover : TdMove/*
		native
		config(PawnMovement)*/{
	public /*transient */bool bPerformedPhysics;
	public /*transient */bool bCheckFailCondition;
	public /*transient */Object.Vector PreviousLocation;
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
	
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public virtual /*function */void SetCoverEntered()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
	
	}
	
}
}
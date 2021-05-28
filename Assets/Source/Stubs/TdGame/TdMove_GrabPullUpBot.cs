namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_GrabPullUpBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public /*transient */bool bControlPawnMovement;
	public /*transient */Object.Vector PawnLocation;
	public /*transient */Object.Vector PawnRotation;
	public /*transient */float VerticalTranslation;
	public /*transient */float HorizontalTranslation;
	public /*transient */Object.Vector MoveStartLocation;
	public /*transient */Object.Vector MoveIntermediateLocation;
	public /*transient */Object.Vector MoveEndLocation;
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public override /*simulated function */void PostStopMove()
	{
	
	}
	
	public virtual /*simulated function */void HeaveInitiatedNotify()
	{
	
	}
	
	public virtual /*simulated function */void HeaveCompletedNotify()
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
	
	public TdMove_GrabPullUpBot()
	{
		// Object Offset:0x005BE324
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
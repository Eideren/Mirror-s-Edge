namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_GrabPullUpBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	[transient] public bool bControlPawnMovement;
	[transient] public Object.Vector PawnLocation;
	[transient] public Object.Vector PawnRotation;
	[transient] public float VerticalTranslation;
	[transient] public float HorizontalTranslation;
	[transient] public Object.Vector MoveStartLocation;
	[transient] public Object.Vector MoveIntermediateLocation;
	[transient] public Object.Vector MoveEndLocation;
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public override /*simulated function */void PostStopMove()
	{
		// stub
	}
	
	public virtual /*simulated function */void HeaveInitiatedNotify()
	{
		// stub
	}
	
	public virtual /*simulated function */void HeaveCompletedNotify()
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
	
	public TdMove_GrabPullUpBot()
	{
		// Object Offset:0x005BE324
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
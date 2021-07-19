namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StandGrabHeaveBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	[transient] public Object.Vector GrabLocation;
	[transient] public Object.Vector StartLocation;
	[transient] public Object.Vector EndLocation;
	[transient] public float ForcedSpeed;
	[transient] public float WallDistance;
	[transient] public float GrabZOffset;
	[transient] public bool bStopWhenDone;
	[transient] public bool bControlPawnMovement;
	[transient] public Object.Vector PawnLocation;
	[transient] public Object.Vector PawnRotation;
	[transient] public float VerticalTranslation;
	[transient] public float HorizontalTranslation;
	[transient] public Object.Vector StartJumpLocation;
	[transient] public float StartTime;
	[transient] public float EndTime;
	[transient] public float JumpStartTime;
	[transient] public float JumpEndTime;
	[transient] public float HeaveStartTime;
	
	public override /*simulated function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated event */void StopMove()
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
	
	public virtual /*simulated function */void JumpInitiatedNotify()
	{
		// stub
	}
	
	public virtual /*simulated function */void JumpDoneNotify()
	{
		// stub
	}
	
	public virtual /*simulated function */void HeaveNotify()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public virtual /*function */void Pause()
	{
		// stub
	}
	
	public virtual /*function */void ControllerScreenLog(String Text)
	{
		// stub
	}
	
	public TdMove_StandGrabHeaveBot()
	{
		// Object Offset:0x005E1FDD
		ForcedSpeed = 200.0f;
		WallDistance = 125.0f;
		GrabZOffset = 120.4250f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
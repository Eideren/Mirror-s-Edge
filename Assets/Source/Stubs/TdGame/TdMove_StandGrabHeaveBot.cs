namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StandGrabHeaveBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public /*transient */Object.Vector GrabLocation;
	public /*transient */Object.Vector StartLocation;
	public /*transient */Object.Vector EndLocation;
	public /*transient */float ForcedSpeed;
	public /*transient */float WallDistance;
	public /*transient */float GrabZOffset;
	public /*transient */bool bStopWhenDone;
	public /*transient */bool bControlPawnMovement;
	public /*transient */Object.Vector PawnLocation;
	public /*transient */Object.Vector PawnRotation;
	public /*transient */float VerticalTranslation;
	public /*transient */float HorizontalTranslation;
	public /*transient */Object.Vector StartJumpLocation;
	public /*transient */float StartTime;
	public /*transient */float EndTime;
	public /*transient */float JumpStartTime;
	public /*transient */float JumpEndTime;
	public /*transient */float HeaveStartTime;
	
	public override /*simulated function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public virtual /*simulated function */void FindClimbNotifiers()
	{
	
	}
	
	public virtual /*simulated function */void JumpInitiatedNotify()
	{
	
	}
	
	public virtual /*simulated function */void JumpDoneNotify()
	{
	
	}
	
	public virtual /*simulated function */void HeaveNotify()
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*function */void Pause()
	{
	
	}
	
	public virtual /*function */void ControllerScreenLog(String Text)
	{
	
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
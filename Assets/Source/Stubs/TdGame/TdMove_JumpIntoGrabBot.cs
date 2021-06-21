namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_JumpIntoGrabBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public /*transient */Object.Vector MoveStartLocation;
	public /*transient */Object.Vector MoveEndLocation;
	
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
	
	public virtual /*simulated event */void PrepareForGrab()
	{
		// stub
	}
	
	public TdMove_JumpIntoGrabBot()
	{
		// Object Offset:0x005C7EC0
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
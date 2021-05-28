namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_JumpBot_Base : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public /*transient */bool bAnticipating;
	public /*transient */bool bDoAnticipation;
	public /*transient */float ForcedSpeed;
	public float AnticipationTime;
	
	// Export UTdMove_JumpBot_Base::execGetPreciseLandingLocation(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetPreciseLandingLocation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public virtual /*simulated function */void SafetyLanding()
	{
	
	}
	
	public virtual /*simulated function */void BeginJump()
	{
	
	}
	
	public virtual /*simulated event */void StartAnticipation()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public virtual /*function */void Pause()
	{
	
	}
	
	public TdMove_JumpBot_Base()
	{
		// Object Offset:0x005C73C9
		AnticipationTime = 0.40f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bDisableCollision = false;
	}
}
}
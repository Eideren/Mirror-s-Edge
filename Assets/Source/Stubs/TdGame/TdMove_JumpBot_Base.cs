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
		// stub
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public virtual /*simulated function */void SafetyLanding()
	{
		// stub
	}
	
	public virtual /*simulated function */void BeginJump()
	{
		// stub
	}
	
	public virtual /*simulated event */void StartAnticipation()
	{
		// stub
	}
	
	public override /*simulated event */void StopMove()
	{
		// stub
	}
	
	public virtual /*function */void Pause()
	{
		// stub
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
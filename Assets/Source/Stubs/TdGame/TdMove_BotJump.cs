namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotJump : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public enum EBotJumpLength 
	{
		BJL_Short,
		BJL_Mid,
		BJL_Long,
		BJL_None,
		BJL_MAX
	};
	
	public /*transient */bool bAnticipating;
	public /*transient */bool bDoAnticipation;
	public /*transient */float ForcedSpeed;
	public TdMove_BotJump.EBotJumpLength JumpLength;
	public float AnticipationTime;
	
	// Export UTdMove_BotJump::execGetPreciseLandingLocation(FFrame&, void* const)
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
	
	public virtual /*simulated event */void StartAnticipation()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public override /*simulated function */void OnTimer()
	{
	
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public override /*simulated event */void FailedToReachPreciseLocation()
	{
	
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
	
	}
	
	public TdMove_BotJump()
	{
		// Object Offset:0x005A2110
		AnticipationTime = 0.40f;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		bCheckForGrab = true;
		bCheckForVaultOver = true;
	}
}
}
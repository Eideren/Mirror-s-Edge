namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_AnimationPlayback : TdMove/*
		config(PawnMovement)*/{
	public /*private transient */name AnimationName;
	public /*private transient */float PlayRate;
	public /*private transient */float BlendInTime;
	public /*private transient */float BlendOutTime;
	public /*private transient */bool bUseRootMotion;
	public /*private transient */bool bUseRootRotation;
	public /*private transient */bool bLoop;
	public /*private transient */bool bForceWalkingStateToIdle;
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		if(BotOwner != default)
		{
			BotOwner.UseLegRotation(false);
		}
		if(bForceWalkingStateToIdle)
		{
			BotOwner.SetOverrideWalkingState(TdPawn.WalkingState.WAS_Idle/*0*/, BlendInTime);
		}
		StartAnimation();
	}
	
	public override /*simulated function */void StopMove()
	{
		AnimationName = "None";
		CurrentCustomAnimName = "None";
		base.StopMove();
		BotOwner.SetOverrideWalkingState(TdPawn.WalkingState.WAS_None/*6*/, default(float?));
		if(BotOwner != default)
		{
			BotOwner.UseLegRotation(true);
		}
	}
	
	public virtual /*simulated function */void StartAnimation()
	{
		PawnOwner.UseRootMotion(bUseRootMotion);
		PawnOwner.UseRootRotation(bUseRootRotation);
		PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, AnimationName, PlayRate, BlendInTime, BlendOutTime, bLoop, true, bUseRootMotion, bUseRootRotation);
		CurrentCustomAnimName = AnimationName;
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(bLoop)
		{
			return;
		}
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnAnimationStopped(AnimNodeSequence SeqNode)
	{
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		if(bLoop)
		{
			return;
		}
		PawnOwner.UseRootMotion(false);
		PawnOwner.UseRootRotation(false);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
	}
	
	public override /*simulated function */void Landed(Object.Vector iNormal, Actor iActor)
	{
	
	}
	
	public virtual /*function */void SetAnimationName(name iAnimationName)
	{
		AnimationName = iAnimationName;
	}
	
	public virtual /*function */name GetAnimationName()
	{
		return AnimationName;
	}
	
	public virtual /*function */void SetPlayRate(float iPlayRate)
	{
		PlayRate = iPlayRate;
	}
	
	public virtual /*function */void SetBlendTime(float iBlendInTime, float iBlendOutTime)
	{
		BlendInTime = iBlendInTime;
		BlendOutTime = iBlendOutTime;
	}
	
	public virtual /*function */void SetLoopAnimation(bool iLoop)
	{
		bLoop = iLoop;
	}
	
	public virtual /*function */void ForceToIdle(bool bForce)
	{
		bForceWalkingStateToIdle = bForce;
	}
	
	public virtual /*function */void UseRootMotion(bool iUseRootMotion)
	{
		bUseRootMotion = iUseRootMotion;
	}
	
	public virtual /*function */void UseRootRotation(bool iRootRotation)
	{
		bUseRootRotation = iRootRotation;
	}
	
	public virtual /*function */void SetPhysics(Actor.EPhysics iPhysics)
	{
		PawnOwner.SetPhysics(((Actor.EPhysics)iPhysics));
	}
	
	public TdMove_AnimationPlayback()
	{
		// Object Offset:0x0059D529
		PlayRate = 1.0f;
	}
}
}
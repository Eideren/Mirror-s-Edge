namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_FallingUncontrolled : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
		if(!base.CanDoMove())
		{
			return false;
		}
		return true;
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		PawnOwner.GoIntoUncontrolledFall();
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
		((PawnOwner.Controller) as TdPlayerController).ClearSoundMode();
		base.StopMove();
	}
	
	public TdMove_FallingUncontrolled()
	{
		// Object Offset:0x005B7294
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerDying";
		bCheckForSoftLanding = true;
	}
}
}
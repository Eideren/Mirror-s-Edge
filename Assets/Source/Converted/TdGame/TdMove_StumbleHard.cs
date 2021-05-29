namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StumbleHard : TdMove_Stumble/*
		config(PawnMovement)*/{
	public override /*simulated function */void PlayStumbleAnimation()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_UpperBody/*4*/, 0.20f);
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PawnOwner.UseRootMotion(true);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "GetHitStumbleBwdFar2", 1.0f, 0.10f, 0.20f, true, default);
		SetTimer(0.80f);
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			ResetCameraLook(0.250f);
			PawnOwner.TossWeapon(PawnOwner.Weapon, default);
			PawnOwner.RemoveWeaponAfterDrop();
		}
	}
	
	public override /*simulated function */Object.Vector GetFocusLocation()
	{
		/*local */Object.Vector PawnRootLocation = default;
	
		PawnRootLocation = PawnOwner.Location;
		PawnRootLocation.Z -= PawnOwner.CylinderComponent.CollisionHeight;
		return PawnRootLocation + vect(0.0f, 0.0f, 150.0f);
	}
	
}
}
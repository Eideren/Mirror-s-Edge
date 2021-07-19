namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_WallKick : TdPhysicsMove/*
		config(PawnMovement)*/{
	[Category("WallKick")] [config] public float WallKickMaxDistance;
	[Category("WallKick")] [config] public float WallKickCheckHeight;
	[Category("WallKick")] [config] public float WallKickExtentWidth;
	[Category("WallKick")] [config] public float WallKickExtentHeight;
	[Category("WallKick")] [config] public float WallKickVelocity2D;
	[Category("WallKick")] [config] public float WallKickVelocityZ;
	
	public override /*function */bool CanDoMove()
	{
		return false;
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector KickVelocity = default, WallProjVelocity = default;
	
		base.StartMove();
		WallProjVelocity = PawnOwner.Velocity - (PawnOwner.MoveNormal * (Dot(PawnOwner.Velocity, PawnOwner.MoveNormal)));
		WallProjVelocity.Z = 0.0f;
		KickVelocity = PawnOwner.MoveNormal * WallKickVelocity2D;
		PawnOwner.Velocity.X = KickVelocity.X + WallProjVelocity.X;
		PawnOwner.Velocity.Y = KickVelocity.Y + WallProjVelocity.Y;
		PawnOwner.Velocity.Z += WallKickVelocityZ;
	}
	
	public TdMove_WallKick()
	{
		// Object Offset:0x005ED13E
		WallKickMaxDistance = 60.0f;
		WallKickCheckHeight = 90.0f;
		WallKickExtentWidth = 20.0f;
		WallKickExtentHeight = 10.0f;
		WallKickVelocity2D = 300.0f;
		WallKickVelocityZ = 580.0f;
		PawnPhysics = Actor.EPhysics.PHYS_Falling;
		ControllerState = (name)"PlayerWalking";
		bCheckForGrab = true;
		bCheckForVaultOver = true;
		bTriggersCompliment = true;
		RedoMoveTime = 1.0f;
	}
}
}
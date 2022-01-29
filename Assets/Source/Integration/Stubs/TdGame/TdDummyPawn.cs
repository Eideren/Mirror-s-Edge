namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDummyPawn : GamePawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public SeqAct_TdDummyWeaponFire FireAction;
	
	public virtual /*function */bool StopWeaponFiring()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void WeaponFired(bool bViaReplication, /*optional */Object.Vector? _HitLocation = default)
	{
		// stub
	}
	
	public override /*simulated function */Object.Rotator GetAdjustedAimFor(Weapon InWeapon, Object.Vector projStart)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */Object.Vector GetWeaponStartTraceLocation(/*optional */Weapon _CurrentWeapon = default)
	{
		// stub
		return default;
	}
	
	public override /*simulated function */Object.Vector GetPawnViewLocation()
	{
		// stub
		return default;
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdDummyPawn_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdDummyPawn_Tick;
	public /*simulated event */void TdDummyPawn_Tick(float DeltaTime)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
	}
	public TdDummyPawn()
	{
		var Default__TdDummyPawn_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdDummyPawn.SceneCaptureCharacterComponent0' */;
		var Default__TdDummyPawn_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdDummyPawn.DrawFrust0' */;
		var Default__TdDummyPawn_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdDummyPawn.CollisionCylinder' */;
		// Object Offset:0x00543D92
		SceneCapture = Default__TdDummyPawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdDummyPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdDummyPawn_DrawFrust0/*Ref DrawFrustumComponent'Default__TdDummyPawn.DrawFrust0'*/;
		CylinderComponent = Default__TdDummyPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdDummyPawn.CollisionCylinder'*/;
		bGameRelevant = true;
		bCollideActors = false;
		Components = default;
		RemoteRole = Actor.ENetRole.ROLE_None;
		CollisionComponent = default;
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDummyPawn : GamePawn/*
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public SeqAct_TdDummyWeaponFire FireAction;
	
	public virtual /*function */bool StopWeaponFiring()
	{
	
		return default;
	}
	
	public override /*simulated function */void WeaponFired(bool bViaReplication, /*optional */Object.Vector? _HitLocation = default)
	{
	
	}
	
	public override /*simulated function */Object.Rotator GetAdjustedAimFor(Weapon InWeapon, Object.Vector projStart)
	{
	
		return default;
	}
	
	public override /*simulated function */Object.Vector GetWeaponStartTraceLocation(/*optional */Weapon? _CurrentWeapon = default)
	{
	
		return default;
	}
	
	public override /*simulated function */Object.Vector GetPawnViewLocation()
	{
	
		return default;
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdDummyPawn_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdDummyPawn_Tick;
	public /*simulated event */void TdDummyPawn_Tick(float DeltaTime)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdDummyPawn()
	{
		// Object Offset:0x00543D92
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdDummyPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdDummyPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdDummyPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdDummyPawn.DrawFrust0'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdDummyPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdDummyPawn.CollisionCylinder'*/;
		bGameRelevant = true;
		bCollideActors = false;
		Components = default;
		RemoteRole = Actor.ENetRole.ROLE_None;
		CollisionComponent = default;
	}
}
}
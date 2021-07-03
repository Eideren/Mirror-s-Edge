namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdStashCompleter : TdStashpoint/*
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	
	protected /*singular event */void TdStashCompleter_Idle_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	(System.Action<name>, StateFlow, System.Action<name>) Stashing()/*state Stashing*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Idle": return Idle();
			case "Stashing": return Stashing();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return Idle();
	}
	public TdStashCompleter()
	{
		var Default__TdStashCompleter_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4E2E
			CollisionHeight = 50.0f,
			CollisionRadius = 150.0f,
			CollideActors = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
			},
		}/* Reference: CylinderComponent'Default__TdStashCompleter.CollisionCylinder' */;
		// Object Offset:0x00670E42
		TerritoryOfTeam = 0;
		bNotifyKismet = false;
		bCollideWorld = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdStashCompleter_CollisionCylinder/*Ref CylinderComponent'Default__TdStashCompleter.CollisionCylinder'*/,
			Default__TdStashCompleter_CollisionCylinder/*Ref CylinderComponent'Default__TdStashCompleter.CollisionCylinder'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_None;
		CollisionComponent = Default__TdStashCompleter_CollisionCylinder/*Ref CylinderComponent'Default__TdStashCompleter.CollisionCylinder'*/;
	}
}
}
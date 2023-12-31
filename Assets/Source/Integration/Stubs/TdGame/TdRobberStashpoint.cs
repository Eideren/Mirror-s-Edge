namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdRobberStashpoint : TdStashpoint/*
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	
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
	public TdRobberStashpoint()
	{
		var Default__TdRobberStashpoint_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4D76
			CollisionHeight = 100.0f,
			CollisionRadius = 300.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdRobberStashpoint.CollisionCylinder' */;
		var Default__TdRobberStashpoint_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x02EA6CEF
			bOverrideLightMapResolution = false,
			HiddenGame = true,
			CastShadow = false,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				bInitialized = true,
				Static = true,
				Dynamic = true,
			},
			CollideActors = false,
			BlockRigidBody = false,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
		}/* Reference: StaticMeshComponent'Default__TdRobberStashpoint.StaticMeshComponent0' */;
		// Object Offset:0x00654ED8
		TerritoryOfTeam = 0;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdRobberStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdRobberStashpoint.CollisionCylinder'*/,
			Default__TdRobberStashpoint_StaticMeshComponent0/*Ref StaticMeshComponent'Default__TdRobberStashpoint.StaticMeshComponent0'*/,
		};
		CollisionComponent = Default__TdRobberStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdRobberStashpoint.CollisionCylinder'*/;
	}
}
}
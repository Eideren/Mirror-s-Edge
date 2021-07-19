namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCopStashpoint : TdStashpoint/*
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	[transient] public TdPawn StashingPawn;
	
	
	protected /*singular event */void TdCopStashpoint_Idle_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		// stub
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Idle()/*auto state Idle*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*singular event */void TdCopStashpoint_Stashing_UnTouch(Actor Other)// state function
	{
		// stub
	}
	
	protected /*singular event */void TdCopStashpoint_Stashing_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)// state function
	{
		// stub
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
	public TdCopStashpoint()
	{
		var Default__TdCopStashpoint_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x01AB4A86
			CollisionHeight = 100.0f,
			CollisionRadius = 30.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__TdCopStashpoint.CollisionCylinder' */;
		// Object Offset:0x0053867A
		TerritoryOfTeam = 1;
		bNotifyKismet = false;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCopStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdCopStashpoint.CollisionCylinder'*/,
		};
		CollisionComponent = Default__TdCopStashpoint_CollisionCylinder/*Ref CylinderComponent'Default__TdCopStashpoint.CollisionCylinder'*/;
	}
}
}
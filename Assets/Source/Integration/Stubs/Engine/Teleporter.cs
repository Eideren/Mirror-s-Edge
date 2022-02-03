namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Teleporter : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	[Category] public String URL;
	[Category] public name ProductRequired;
	[Category] public bool bChangesVelocity;
	[Category] public bool bChangesYaw;
	[Category] public bool bReversesX;
	[Category] public bool bReversesY;
	[Category] public bool bReversesZ;
	[Category] public bool bEnabled;
	[Category] public bool bCanTeleportVehicles;
	[Category] public Object.Vector TargetVelocity;
	public float LastFired;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		URL, bEnabled;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		TargetVelocity, bChangesVelocity, 
	//		bChangesYaw, bReversesX, 
	//		bReversesY, bReversesZ;
	//}
	
	// Export UTeleporter::execCanTeleport(FFrame&, void* const)
	public override /*native function */bool CanTeleport(Actor A)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void eventPostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */bool Accept(Actor Incoming, Actor Source)
	{
		// stub
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? Teleporter_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => Teleporter_Touch;
	public /*event */void Teleporter_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public override /*simulated event */void PostTouch(Actor Other)
	{
		// stub
	}
	
	public override /*event */Actor SpecialHandling(Pawn Other)
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public Teleporter()
	{
		var Default__Teleporter_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00466807
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__Teleporter.CollisionCylinder' */;
		var Default__Teleporter_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D06A6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Teleport")/*Ref Texture2D'EngineResources.S_Teleport'*/,
		}/* Reference: SpriteComponent'Default__Teleporter.Sprite' */;
		var Default__Teleporter_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__Teleporter.Sprite2' */;
		var Default__Teleporter_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__Teleporter.Arrow' */;
		var Default__Teleporter_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__Teleporter.PathRenderer' */;
		// Object Offset:0x003FA344
		bChangesYaw = true;
		bEnabled = true;
		CylinderComponent = Default__Teleporter_CollisionCylinder/*Ref CylinderComponent'Default__Teleporter.CollisionCylinder'*/;
		GoodSprite = Default__Teleporter_Sprite/*Ref SpriteComponent'Default__Teleporter.Sprite'*/;
		BadSprite = Default__Teleporter_Sprite2/*Ref SpriteComponent'Default__Teleporter.Sprite2'*/;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Teleporter_Sprite/*Ref SpriteComponent'Default__Teleporter.Sprite'*/,
			Default__Teleporter_Sprite2/*Ref SpriteComponent'Default__Teleporter.Sprite2'*/,
			Default__Teleporter_Arrow/*Ref ArrowComponent'Default__Teleporter.Arrow'*/,
			Default__Teleporter_CollisionCylinder/*Ref CylinderComponent'Default__Teleporter.CollisionCylinder'*/,
			Default__Teleporter_PathRenderer/*Ref PathRenderingComponent'Default__Teleporter.PathRenderer'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = Default__Teleporter_CollisionCylinder/*Ref CylinderComponent'Default__Teleporter.CollisionCylinder'*/;
	}
}
}
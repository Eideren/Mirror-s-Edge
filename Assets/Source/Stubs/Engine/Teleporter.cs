namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Teleporter : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ String URL;
	public/*()*/ name ProductRequired;
	public/*()*/ bool bChangesVelocity;
	public/*()*/ bool bChangesYaw;
	public/*()*/ bool bReversesX;
	public/*()*/ bool bReversesY;
	public/*()*/ bool bReversesZ;
	public/*()*/ bool bEnabled;
	public/*()*/ bool bCanTeleportVehicles;
	public/*()*/ Object.Vector TargetVelocity;
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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */bool Accept(Actor Incoming, Actor Source)
	{
	
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? Teleporter_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => Teleporter_Touch;
	public /*event */void Teleporter_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public override /*simulated event */void PostTouch(Actor Other)
	{
	
	}
	
	public override /*event */Actor SpecialHandling(Pawn Other)
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public Teleporter()
	{
		// Object Offset:0x003FA344
		bChangesYaw = true;
		bEnabled = true;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x00466807
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__Teleporter.CollisionCylinder' */;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x004D06A6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Teleport")/*Ref Texture2D'EngineResources.S_Teleport'*/,
		}/* Reference: SpriteComponent'Default__Teleporter.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__Teleporter.Sprite2")/*Ref SpriteComponent'Default__Teleporter.Sprite2'*/;
		bCollideActors = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004D06A6
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Teleport")/*Ref Texture2D'EngineResources.S_Teleport'*/,
			}/* Reference: SpriteComponent'Default__Teleporter.Sprite' */,
			LoadAsset<SpriteComponent>("Default__Teleporter.Sprite2")/*Ref SpriteComponent'Default__Teleporter.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__Teleporter.Arrow")/*Ref ArrowComponent'Default__Teleporter.Arrow'*/,
			new CylinderComponent
			{
				// Object Offset:0x00466807
				CollisionHeight = 80.0f,
				CollisionRadius = 40.0f,
				CollideActors = true,
			}/* Reference: CylinderComponent'Default__Teleporter.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__Teleporter.PathRenderer")/*Ref PathRenderingComponent'Default__Teleporter.PathRenderer'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x00466807
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__Teleporter.CollisionCylinder' */;
	}
}
}
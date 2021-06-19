namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DoorMarker : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public enum EDoorType 
	{
		DOOR_Shoot,
		DOOR_Touch,
		DOOR_MAX
	};
	
	public/*()*/ InterpActor MyDoor;
	public/*()*/ DoorMarker.EDoorType DoorType;
	public/*()*/ Actor DoorTrigger;
	public/*()*/ bool bWaitUntilCompletelyOpened;
	public/*()*/ bool bInitiallyClosed;
	public/*()*/ bool bBlockedWhenClosed;
	public bool bDoorOpen;
	public /*const transient */bool bTempDisabledCollision;
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*function */void MoverOpened()
	{
	
	}
	
	public virtual /*function */void MoverClosed()
	{
	
	}
	
	public override /*event */Actor SpecialHandling(Pawn Other)
	{
	
		return default;
	}
	
	public override /*function */bool ProceedWithMove(Pawn Other)
	{
	
		return default;
	}
	
	public override /*event */bool SuggestMovePreparation(Pawn Other)
	{
	
		return default;
	}
	
	public DoorMarker()
	{
		var Default__DoorMarker_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__DoorMarker.CollisionCylinder' */;
		var Default__DoorMarker_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__DoorMarker.Sprite' */;
		var Default__DoorMarker_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__DoorMarker.Sprite2' */;
		var Default__DoorMarker_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__DoorMarker.Arrow' */;
		var Default__DoorMarker_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__DoorMarker.PathRenderer' */;
		// Object Offset:0x0030FD9C
		bInitiallyClosed = true;
		bSpecialMove = true;
		ExtraCost = 100;
		CylinderComponent = Default__DoorMarker_CollisionCylinder/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/;
		GoodSprite = Default__DoorMarker_Sprite/*Ref SpriteComponent'Default__DoorMarker.Sprite'*/;
		BadSprite = Default__DoorMarker_Sprite2/*Ref SpriteComponent'Default__DoorMarker.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DoorMarker_Sprite/*Ref SpriteComponent'Default__DoorMarker.Sprite'*/,
			Default__DoorMarker_Sprite2/*Ref SpriteComponent'Default__DoorMarker.Sprite2'*/,
			Default__DoorMarker_Arrow/*Ref ArrowComponent'Default__DoorMarker.Arrow'*/,
			Default__DoorMarker_CollisionCylinder/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/,
			Default__DoorMarker_PathRenderer/*Ref PathRenderingComponent'Default__DoorMarker.PathRenderer'*/,
		};
		CollisionComponent = Default__DoorMarker_CollisionCylinder/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/;
	}
}
}
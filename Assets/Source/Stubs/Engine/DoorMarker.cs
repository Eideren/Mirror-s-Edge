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
		// Object Offset:0x0030FD9C
		bInitiallyClosed = true;
		bSpecialMove = true;
		ExtraCost = 100;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__DoorMarker.CollisionCylinder")/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__DoorMarker.Sprite")/*Ref SpriteComponent'Default__DoorMarker.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__DoorMarker.Sprite2")/*Ref SpriteComponent'Default__DoorMarker.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__DoorMarker.Sprite")/*Ref SpriteComponent'Default__DoorMarker.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__DoorMarker.Sprite2")/*Ref SpriteComponent'Default__DoorMarker.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__DoorMarker.Arrow")/*Ref ArrowComponent'Default__DoorMarker.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__DoorMarker.CollisionCylinder")/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__DoorMarker.PathRenderer")/*Ref PathRenderingComponent'Default__DoorMarker.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__DoorMarker.CollisionCylinder")/*Ref CylinderComponent'Default__DoorMarker.CollisionCylinder'*/;
	}
}
}
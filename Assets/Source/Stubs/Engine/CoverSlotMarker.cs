namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CoverSlotMarker : NavigationPoint/*
		native
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ /*editconst */CoverLink.CoverInfo OwningSlot;
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	// Export UCoverSlotMarker::execGetSlotLocation(FFrame&, void* const)
	public virtual /*native simulated function */Object.Vector GetSlotLocation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverSlotMarker::execGetSlotRotation(FFrame&, void* const)
	public virtual /*native simulated function */Object.Rotator GetSlotRotation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UCoverSlotMarker::execIsValidClaim(FFrame&, void* const)
	public virtual /*native final function */bool IsValidClaim(Controller ChkClaim, /*optional */bool? _bSkipTeamCheck = default, /*optional */bool? _bSkipOverlapCheck = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public CoverSlotMarker()
	{
		// Object Offset:0x002ECE93
		bSpecialMove = true;
		Cost = 300;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x0046646B
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__CoverSlotMarker.CollisionCylinder' */;
		GoodSprite = LoadAsset<SpriteComponent>("Default__CoverSlotMarker.Sprite")/*Ref SpriteComponent'Default__CoverSlotMarker.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__CoverSlotMarker.Sprite2")/*Ref SpriteComponent'Default__CoverSlotMarker.Sprite2'*/;
		Abbrev = "CSM";
		bCollideWhenPlacing = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new CylinderComponent
			{
				// Object Offset:0x0046646B
				CollisionHeight = 40.0f,
				CollisionRadius = 40.0f,
			}/* Reference: CylinderComponent'Default__CoverSlotMarker.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__CoverSlotMarker.PathRenderer")/*Ref PathRenderingComponent'Default__CoverSlotMarker.PathRenderer'*/,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x0046646B
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__CoverSlotMarker.CollisionCylinder' */;
	}
}
}
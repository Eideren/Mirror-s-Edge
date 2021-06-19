namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeaponPickupFactory : PickupFactory/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ /*repnotify */Core.ClassT<TdWeapon> WeaponPickupClass;
	
	//replication
	//{
	//	 if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && bNetInitial)
	//		WeaponPickupClass;
	//}
	
	public override /*simulated function */void PreBeginPlay()
	{
	
	}
	
	public virtual /*simulated function */void PickupClassChanged()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public TdWeaponPickupFactory()
	{
		var Default__TdWeaponPickupFactory_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder' */;
		var Default__TdWeaponPickupFactory_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdWeaponPickupFactory.Sprite' */;
		var Default__TdWeaponPickupFactory_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdWeaponPickupFactory.Sprite2' */;
		var Default__TdWeaponPickupFactory_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdWeaponPickupFactory.Arrow' */;
		var Default__TdWeaponPickupFactory_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdWeaponPickupFactory.PathRenderer' */;
		// Object Offset:0x006D056D
		CylinderComponent = Default__TdWeaponPickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/;
		GoodSprite = Default__TdWeaponPickupFactory_Sprite/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite'*/;
		BadSprite = Default__TdWeaponPickupFactory_Sprite2/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdWeaponPickupFactory_Sprite/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite'*/,
			Default__TdWeaponPickupFactory_Sprite2/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite2'*/,
			Default__TdWeaponPickupFactory_Arrow/*Ref ArrowComponent'Default__TdWeaponPickupFactory.Arrow'*/,
			Default__TdWeaponPickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/,
			Default__TdWeaponPickupFactory_PathRenderer/*Ref PathRenderingComponent'Default__TdWeaponPickupFactory.PathRenderer'*/,
		};
		CollisionComponent = Default__TdWeaponPickupFactory_CollisionCylinder/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/;
	}
}
}
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
		// Object Offset:0x006D056D
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdWeaponPickupFactory.CollisionCylinder")/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdWeaponPickupFactory.Sprite")/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdWeaponPickupFactory.Sprite2")/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdWeaponPickupFactory.Sprite")/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdWeaponPickupFactory.Sprite2")/*Ref SpriteComponent'Default__TdWeaponPickupFactory.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdWeaponPickupFactory.Arrow")/*Ref ArrowComponent'Default__TdWeaponPickupFactory.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdWeaponPickupFactory.CollisionCylinder")/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdWeaponPickupFactory.PathRenderer")/*Ref PathRenderingComponent'Default__TdWeaponPickupFactory.PathRenderer'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdWeaponPickupFactory.CollisionCylinder")/*Ref CylinderComponent'Default__TdWeaponPickupFactory.CollisionCylinder'*/;
	}
}
}
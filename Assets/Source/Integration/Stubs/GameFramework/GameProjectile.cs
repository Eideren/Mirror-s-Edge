namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameProjectile : Projectile/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public GameProjectile()
	{
		var Default__GameProjectile_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__GameProjectile.CollisionCylinder' */;
		var Default__GameProjectile_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__GameProjectile.Sprite' */;
		// Object Offset:0x00007733
		CylinderComponent = Default__GameProjectile_CollisionCylinder/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__GameProjectile_Sprite/*Ref SpriteComponent'Default__GameProjectile.Sprite'*/,
			Default__GameProjectile_CollisionCylinder/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/,
		};
		CollisionComponent = Default__GameProjectile_CollisionCylinder/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/;
	}
}
}
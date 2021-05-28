namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameProjectile : Projectile/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public GameProjectile()
	{
		// Object Offset:0x00007733
		CylinderComponent = LoadAsset<CylinderComponent>("Default__GameProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__GameProjectile.Sprite")/*Ref SpriteComponent'Default__GameProjectile.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__GameProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__GameProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__GameProjectile.CollisionCylinder'*/;
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProjectile : Projectile/*
		notplaceable
		hidecategories(Navigation)*/{
	public int InnerCoreDamage;
	public int InnerCoreDamageRadius;
	public float OuterCoreDamage;
	public int OuterCoreDamageRadius;
	
	public override /*simulated function */bool HurtRadius(float BaseDamage, float InDamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor _IgnoredActor = default, /*optional */Controller _InstigatedByController = default, /*optional */bool? _bDoFullDamage = default)
	{
		// stub
		return default;
	}
	
	public TdProjectile()
	{
		var Default__TdProjectile_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdProjectile.CollisionCylinder' */;
		var Default__TdProjectile_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdProjectile.Sprite' */;
		// Object Offset:0x0064D170
		CylinderComponent = Default__TdProjectile_CollisionCylinder/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdProjectile_Sprite/*Ref SpriteComponent'Default__TdProjectile.Sprite'*/,
			Default__TdProjectile_CollisionCylinder/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/,
		};
		CollisionComponent = Default__TdProjectile_CollisionCylinder/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/;
	}
}
}
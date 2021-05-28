namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProjectile : Projectile/*
		notplaceable
		hidecategories(Navigation)*/{
	public int InnerCoreDamage;
	public int InnerCoreDamageRadius;
	public float OuterCoreDamage;
	public int OuterCoreDamageRadius;
	
	public override /*simulated function */bool HurtRadius(float BaseDamage, float InDamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor IgnoredActor = default, /*optional */Controller InstigatedByController = default, /*optional */bool bDoFullDamage = default)
	{
	
		return default;
	}
	
	public TdProjectile()
	{
		// Object Offset:0x0064D170
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdProjectile.Sprite")/*Ref SpriteComponent'Default__TdProjectile.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__TdProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdProjectile.CollisionCylinder")/*Ref CylinderComponent'Default__TdProjectile.CollisionCylinder'*/;
	}
}
}
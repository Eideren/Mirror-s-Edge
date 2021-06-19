namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProj_HeavyFlashbangGrenade : TdProj_FlashbangGrenade/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdProj_HeavyFlashbangGrenade()
	{
		var Default__TdProj_HeavyFlashbangGrenade_LightComponent0 = new PointLightComponent
		{
		}/* Reference: PointLightComponent'Default__TdProj_HeavyFlashbangGrenade.LightComponent0' */;
		var Default__TdProj_HeavyFlashbangGrenade_GrenadeMesh0 = new SkeletalMeshComponent
		{
		}/* Reference: SkeletalMeshComponent'Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0' */;
		var Default__TdProj_HeavyFlashbangGrenade_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder' */;
		var Default__TdProj_HeavyFlashbangGrenade_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdProj_HeavyFlashbangGrenade.Sprite' */;
		// Object Offset:0x0064F1A1
		LookAwayDamageScale = 0.40f;
		DynamicLightFlashLight = Default__TdProj_HeavyFlashbangGrenade_LightComponent0/*Ref PointLightComponent'Default__TdProj_HeavyFlashbangGrenade.LightComponent0'*/;
		Mesh = Default__TdProj_HeavyFlashbangGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0'*/;
		InnerCoreDamage = 8;
		InnerCoreDamageRadius = 5000;
		OuterCoreDamage = 8.0f;
		OuterCoreDamageRadius = 10000;
		DamageRadius = 100000.0f;
		MyDamageType = ClassT<TdDmgType_HeavyFlashbang>()/*Ref Class'TdDmgType_HeavyFlashbang'*/;
		CylinderComponent = Default__TdProj_HeavyFlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdProj_HeavyFlashbangGrenade_Sprite/*Ref SpriteComponent'Default__TdProj_HeavyFlashbangGrenade.Sprite'*/,
			Default__TdProj_HeavyFlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/,
			Default__TdProj_HeavyFlashbangGrenade_GrenadeMesh0/*Ref SkeletalMeshComponent'Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0'*/,
		};
		CollisionComponent = Default__TdProj_HeavyFlashbangGrenade_CollisionCylinder/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/;
	}
}
}
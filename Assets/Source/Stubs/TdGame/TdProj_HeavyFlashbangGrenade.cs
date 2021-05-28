namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdProj_HeavyFlashbangGrenade : TdProj_FlashbangGrenade/*
		notplaceable
		hidecategories(Navigation)*/{
	public TdProj_HeavyFlashbangGrenade()
	{
		// Object Offset:0x0064F1A1
		LookAwayDamageScale = 0.40f;
		DynamicLightFlashLight = LoadAsset<PointLightComponent>("Default__TdProj_HeavyFlashbangGrenade.LightComponent0")/*Ref PointLightComponent'Default__TdProj_HeavyFlashbangGrenade.LightComponent0'*/;
		Mesh = LoadAsset<SkeletalMeshComponent>("Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0")/*Ref SkeletalMeshComponent'Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0'*/;
		InnerCoreDamage = 8;
		InnerCoreDamageRadius = 5000;
		OuterCoreDamage = 8.0f;
		OuterCoreDamageRadius = 10000;
		DamageRadius = 100000.0f;
		MyDamageType = ClassT<TdDmgType_HeavyFlashbang>()/*Ref Class'TdDmgType_HeavyFlashbang'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder")/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdProj_HeavyFlashbangGrenade.Sprite")/*Ref SpriteComponent'Default__TdProj_HeavyFlashbangGrenade.Sprite'*/,
			LoadAsset<CylinderComponent>("Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder")/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/,
			LoadAsset<SkeletalMeshComponent>("Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0")/*Ref SkeletalMeshComponent'Default__TdProj_HeavyFlashbangGrenade.GrenadeMesh0'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder")/*Ref CylinderComponent'Default__TdProj_HeavyFlashbangGrenade.CollisionCylinder'*/;
	}
}
}
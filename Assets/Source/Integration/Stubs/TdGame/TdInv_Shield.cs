namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInv_Shield : TdEquipment/*
		notplaceable
		hidecategories(Navigation)*/{
	[export, editinline] public TdSkeletalMeshComponent Mesh3p;
	public int Health;
	
	public override /*function */void Activate()
	{
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdInv_Shield_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdInv_Shield_TakeDamage;
	public /*event */void TdInv_Shield_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public TdInv_Shield()
	{
		var Default__TdInv_Shield_RiotShield = new TdSkeletalMeshComponent
		{
			// Object Offset:0x03128216
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_RiotShield.SK_WP_RiotShield")/*Ref SkeletalMesh'WP_RiotShield.SK_WP_RiotShield'*/,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = true,
			BlockNonZeroExtent = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdInv_Shield.RiotShield' */;
		var Default__TdInv_Shield_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdInv_Shield.Sprite' */;
		// Object Offset:0x0057CE2A
		Mesh3p = Default__TdInv_Shield_RiotShield/*Ref TdSkeletalMeshComponent'Default__TdInv_Shield.RiotShield'*/;
		Health = 100;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdInv_Shield_Sprite/*Ref SpriteComponent'Default__TdInv_Shield.Sprite'*/,
			Default__TdInv_Shield_RiotShield/*Ref TdSkeletalMeshComponent'Default__TdInv_Shield.RiotShield'*/,
		};
	}
}
}
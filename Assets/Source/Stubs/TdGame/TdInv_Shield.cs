namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdInv_Shield : TdEquipment/*
		notplaceable
		hidecategories(Navigation)*/{
	public /*export editinline */TdSkeletalMeshComponent Mesh3p;
	public int Health;
	
	public override /*function */void Activate()
	{
	
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdInv_Shield_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdInv_Shield_TakeDamage;
	public /*event */void TdInv_Shield_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default, /*optional */Actor DamageCauser = default)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public TdInv_Shield()
	{
		// Object Offset:0x0057CE2A
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x03128216
			SkeletalMesh = LoadAsset<SkeletalMesh>("WP_RiotShield.SK_WP_RiotShield")/*Ref SkeletalMesh'WP_RiotShield.SK_WP_RiotShield'*/,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = true,
			BlockNonZeroExtent = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdInv_Shield.RiotShield' */;
		Health = 100;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdInv_Shield.Sprite")/*Ref SpriteComponent'Default__TdInv_Shield.Sprite'*/,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x03128216
				SkeletalMesh = LoadAsset<SkeletalMesh>("WP_RiotShield.SK_WP_RiotShield")/*Ref SkeletalMesh'WP_RiotShield.SK_WP_RiotShield'*/,
				CollideActors = true,
				BlockActors = true,
				BlockZeroExtent = true,
				BlockNonZeroExtent = true,
			}/* Reference: TdSkeletalMeshComponent'Default__TdInv_Shield.RiotShield' */,
		};
	}
}
}
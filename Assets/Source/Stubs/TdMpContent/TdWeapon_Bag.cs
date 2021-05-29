// NO OVERWRITE

namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdWeapon_Bag : TdWeapon_Light/*
		config(Weapons)
		notplaceable
		hidecategories(Navigation)*/{
	public const int FireModeThrowBag = 0;
	
	public /*const config */float MaxThrowVelocity;
	public /*const config */float MinThrowVelocity;
	public /*const config */float PlayerVelocityAddPct;
	public /*const config */Object.Rotator MaxPitchAssist;
	public /*const config */Object.Rotator MinPitchAssist;
	public /*const config */float StickyAimMaxVelocity;
	public /*const config */float StickyAimDefaultVelocity;
	public /*const config */float StickyAimMinVelocity;
	public /*const config */float AirResistanceBoost;
	public /*const config */float TargetVelocityMultiplier2D;
	public /*const config */float TargetVelocityMultiplierZ;
	public /*const config */float TargetHeightBooster;
	public /*const config */float BagRequestDuration;
	public bool bBagIsRequiested;
	
	public override ReloadWeapon_del ReloadWeapon { get => bfield_ReloadWeapon ?? TdWeapon_Bag_ReloadWeapon; set => bfield_ReloadWeapon = value; } ReloadWeapon_del bfield_ReloadWeapon;
	public override ReloadWeapon_del global_ReloadWeapon => TdWeapon_Bag_ReloadWeapon;
	public /*simulated function */void TdWeapon_Bag_ReloadWeapon()
	{
	
	}
	
	public /*function */static string GetLocalString(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default)
	{
	
		return default;
	}
	
	public override /*simulated function */bool IsValidCrosshairTarget(TdHUD myHUD)
	{
	
		return default;
	}
	
	public override /*simulated function */bool IsValidStickyActor(Actor PotentialStickyActor, Pawn myPawn)
	{
	
		return default;
	}
	
	public override /*function */void DropFrom(Object.Vector StartLocation, Object.Vector StartVelocity)
	{
	
	}
	
	public override /*simulated function */void CustomFire()
	{
	
	}
	
	public virtual /*function */bool SolveParablaLineProblem(Object.Vector PL, Object.Vector VL, Object.Vector P0, float Gravity, float V02d, ref Object.Vector V0)
	{
	
		return default;
	}
	
	public virtual /*function */bool SecondDegreeSolver(float A, float bx, float cx2, ref float s0, ref float s1)
	{
	
		return default;
	}
	
	public override /*simulated function */void ForceNewStickyActor(Actor NewStickyActor, TdHUD HUD, Controller Controller, TdMove CurrentMove, float DeltaTime)
	{
	
	}
	
	public virtual /*simulated function */void ClearBagRequest()
	{
	
	}
	
	public override /*simulated function */int GetFinalStickyAngle(TdMove CurrentMove, TdPawn StickyPawn)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void DrawWeaponCrosshair(HUD H)
	{
	
	}
	
	public override /*simulated function */void UpdateStickyActor(TdHUD HUD, Controller Controller, TdMove CurrentMove, float DeltaTime)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		ReloadWeapon = null;
	
	}
	
	protected /*simulated function */bool TdWeapon_Bag_Active_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Active()/*simulated state Active*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated function */bool TdWeapon_Bag_WeaponEquipping_TryPutDown()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) WeaponEquipping()/*simulated state WeaponEquipping*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*simulated event */bool TdWeapon_Bag_ThrowBag_IsFiring()// state function
	{
	
		return default;
	}
	
	protected /*simulated function */void TdWeapon_Bag_ThrowBag_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Bag_ThrowBag_RefireCheckTimer()// state function
	{
	
	}
	
	protected /*simulated function */void TdWeapon_Bag_ThrowBag_EndState(name NextStateName)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) ThrowBag()/*simulated state ThrowBag*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Active": return Active();
			case "WeaponEquipping": return WeaponEquipping();
			case "ThrowBag": return ThrowBag();
			default: return base.FindState(stateName);
		}
	}
	public TdWeapon_Bag()
	{
		// Object Offset:0x000103CD
		MaxThrowVelocity = 1200.0f;
		MinThrowVelocity = 800.0f;
		PlayerVelocityAddPct = 0.40f;
		MaxPitchAssist = new Rotator
		{
			Pitch=4000,
			Yaw=0,
			Roll=0
		};
		MinPitchAssist = new Rotator
		{
			Pitch=1000,
			Yaw=0,
			Roll=0
		};
		StickyAimMaxVelocity = 2000.0f;
		StickyAimDefaultVelocity = 1300.0f;
		StickyAimMinVelocity = 750.0f;
		AirResistanceBoost = 1.080f;
		TargetVelocityMultiplier2D = 0.90f;
		TargetVelocityMultiplierZ = 0.20f;
		TargetHeightBooster = 0.80f;
		BagRequestDuration = 5.0f;
		AimOffsetProfileNames = new array<name>
		{
			(name)"Default",
			(name)"OneHanded",
		};
		MuzzleFlashSocket = (name)"None";
		BulletTraceTemplate = default;
		MaxAmmo = 1;
		ReloadTime = 0.0f;
		BurstMax = 1;
		AmmoCount = 1;
		ClipCount = 0;
		OnTargetCrossHairColor = new LinearColor
		{
			R=1.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
		FallOffDistance = 0.0f;
		DecalTypeToUse = TdWeapon.EWeaponDecalType.EWDT_None;
		AnimationSetCharacter1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/;
		AnimationSetFemale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		AnimationSetMale3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/;
		Mesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011390
			SkeletalMesh = LoadAsset<SkeletalMesh>("Bag.SK_Bag")/*Ref SkeletalMesh'Bag.SK_Bag'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
			Rotation = new Rotator
			{
				Pitch=16000,
				Yaw=16000,
				Roll=0
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Bag.FirstPersonMesh' */;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011504
			SkeletalMesh = LoadAsset<SkeletalMesh>("Bag.SK_Bag")/*Ref SkeletalMesh'Bag.SK_Bag'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
			Rotation = new Rotator
			{
				Pitch=16000,
				Yaw=16000,
				Roll=0
			},
			Scale = 1.50f,
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Bag.ThirdPersonMesh' */;
		DefaultDecalMaterial = default;
		DefaultImpactMaterial = default;
		FiringStatesArray = new array<name>
		{
			(name)"ThrowBag",
		};
		WeaponFireTypes = new array<Weapon.EWeaponFireType>
		{
			#warning EWeaponFireType values are deserialized weird, replaced with default
			//116,
			default,
		};
		FireInterval = new array<float>
		{
			0.20f,
		};
		Spread = new array<float>
		{
			0.0f,
		};
		InstantHitDamage = new array<float>
		{
			0.0f,
		};
		InstantHitMomentum = new array<float>
		{
			0.0f,
		};
		InstantHitDamageTypes = new array< Core.ClassT<DamageType> >
		{
			default,
		};
		EquipTime = 0.50f;
		WeaponRange = 0.0f;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x00011390
			SkeletalMesh = LoadAsset<SkeletalMesh>("Bag.SK_Bag")/*Ref SkeletalMesh'Bag.SK_Bag'*/,
			PhysicsWeight = 1.0f,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
				LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
			},
			bUpdateJointsFromAnimation = true,
			bEnableFullAnimWeightBodies = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
			Rotation = new Rotator
			{
				Pitch=16000,
				Yaw=16000,
				Roll=0
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Bag.FirstPersonMesh' */;
		bDropOnDeath = true;
		InventorySlot = Inventory.EInventorySlot.EISlot_LightWeapon;
		DroppedPickupClass = default;
		DroppedPickupMesh = default;
		PickupFactoryMesh = default;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00011390
				SkeletalMesh = LoadAsset<SkeletalMesh>("Bag.SK_Bag")/*Ref SkeletalMesh'Bag.SK_Bag'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18")/*Ref TdAnimSet'AS_C1P_OneHanded_Glock18.AS_C1P_OneHanded_Glock18'*/,
				},
				bUpdateJointsFromAnimation = true,
				bEnableFullAnimWeightBodies = true,
				RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
				RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
				{
					Default = true,
					GameplayPhysics = true,
					EffectPhysics = true,
				},
				Rotation = new Rotator
				{
					Pitch=16000,
					Yaw=16000,
					Roll=0
				},
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Bag.FirstPersonMesh' */,
			//Components[1]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x00011504
				SkeletalMesh = LoadAsset<SkeletalMesh>("Bag.SK_Bag")/*Ref SkeletalMesh'Bag.SK_Bag'*/,
				PhysicsWeight = 1.0f,
				AnimSets = new array<AnimSet>
				{
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/,
					LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18")/*Ref TdAnimSet'AS_F3P_OneHanded_Glock18.AS_F3P_OneHanded_Glock18'*/,
				},
				bUpdateJointsFromAnimation = true,
				bEnableFullAnimWeightBodies = true,
				RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
				RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
				{
					Default = true,
					GameplayPhysics = true,
					EffectPhysics = true,
				},
				Rotation = new Rotator
				{
					Pitch=16000,
					Yaw=16000,
					Roll=0
				},
				Scale = 1.50f,
			}/* Reference: TdSkeletalMeshComponent'Default__TdWeapon_Bag.ThirdPersonMesh' */,
		};
	}
}
}
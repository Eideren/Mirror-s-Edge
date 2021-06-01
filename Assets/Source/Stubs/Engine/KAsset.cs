namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KAsset : Actor/*
		native
		nativereplication
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */LightEnvironmentComponent LightEnvironment;
	public/*()*/ /*const editconst export editinline */SkeletalMeshComponent SkeletalMeshComponent;
	public/*()*/ bool bDamageAppliesImpulse;
	public/*()*/ bool bWakeOnLevelStart;
	public/*()*/ bool bBlockPawns;
	public /*repnotify */SkeletalMesh ReplicatedMesh;
	public /*repnotify */PhysicsAsset ReplicatedPhysAsset;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		ReplicatedMesh, ReplicatedPhysAsset;
	//}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? KAsset_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => KAsset_TakeDamage;
	public /*event */void KAsset_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
	
	}
	
	public override /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
	
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public override /*simulated function */void OnTeleport(SeqAct_Teleport inAction)
	{
	
	}
	
	public override /*function */void DoKismetAttachment(Actor Attachment, SeqAct_AttachToActor Action)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public KAsset()
	{
		// Object Offset:0x0034BF9C
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAsset.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAsset.MyLightEnvironment'*/;
		SkeletalMeshComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x0034C2A9
			PhysicsWeight = 1.0f,
			bSkipAllUpdateWhenPhysicsAsleep = true,
			bHasPhysicsAssetInstance = true,
			bUpdateKinematicBonesFromAnimation = false,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAsset.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAsset.MyLightEnvironment'*/,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: SkeletalMeshComponent'Default__KAsset.KAssetSkelMeshComponent' */;
		bDamageAppliesImpulse = true;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bUpdateSimulatedPosition = true;
		bNetInitialRotation = true;
		bCollideActors = true;
		bBlockActors = true;
		bProjTarget = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__KAsset.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAsset.MyLightEnvironment'*/,
			new SkeletalMeshComponent
			{
				// Object Offset:0x0034C2A9
				PhysicsWeight = 1.0f,
				bSkipAllUpdateWhenPhysicsAsleep = true,
				bHasPhysicsAssetInstance = true,
				bUpdateKinematicBonesFromAnimation = false,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAsset.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAsset.MyLightEnvironment'*/,
				CollideActors = true,
				BlockActors = true,
				BlockZeroExtent = true,
				BlockRigidBody = true,
				RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
				RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
				{
					Default = true,
					GameplayPhysics = true,
					EffectPhysics = true,
				},
			}/* Reference: SkeletalMeshComponent'Default__KAsset.KAssetSkelMeshComponent' */,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		CollisionComponent = new SkeletalMeshComponent
		{
			// Object Offset:0x0034C2A9
			PhysicsWeight = 1.0f,
			bSkipAllUpdateWhenPhysicsAsleep = true,
			bHasPhysicsAssetInstance = true,
			bUpdateKinematicBonesFromAnimation = false,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KAsset.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KAsset.MyLightEnvironment'*/,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: SkeletalMeshComponent'Default__KAsset.KAssetSkelMeshComponent' */;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_ConstraintBroken>(),
			ClassT<SeqEvent_RigidBodyCollision>(),
		};
	}
}
}
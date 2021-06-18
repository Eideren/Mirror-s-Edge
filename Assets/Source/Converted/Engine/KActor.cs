namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KActor : DynamicSMActor/*
		native
		nativereplication
		placeable*/{
	public/*()*/ bool bDamageAppliesImpulse;
	public/*()*/ /*repnotify */bool bWakeOnLevelStart;
	public bool bCurrentSlide;
	public bool bSlideActive;
	public/*(Interaction)*/ /*const */bool LOIUse2DDistance;
	public /*export editinline */ParticleSystemComponent ImpactEffectComponent;
	public /*export editinline */AudioComponent ImpactSoundComponent;
	public /*export editinline */AudioComponent ImpactSoundComponent2;
	public float LastImpactTime;
	public /*export editinline */ParticleSystemComponent SlideEffectComponent;
	public /*export editinline */AudioComponent SlideSoundComponent;
	public float LastSlideTime;
	public /*native const */Actor.RigidBodyState RBState;
	public /*native const */float AngErrorAccumulator;
	public /*repnotify */float DrawScaleX;
	public /*repnotify */float DrawScaleY;
	public /*repnotify */float DrawScaleZ;
	public Object.Vector InitialLocation;
	public Object.Rotator InitialRotation;
	public/*(Interaction)*/ /*const */float LOILookAtDelay;
	public/*(Interaction)*/ /*const */float LOIProximityDelay;
	public/*(Interaction)*/ /*const */float LOIMinDuration;
	public/*(Interaction)*/ /*const */float LOIDistance;
	public/*(Interaction)*/ /*const */array<name> LOIGroups;
	public /*private */TdLOIAddOnObject TdLOIAddOn;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RBState;
	//
	//	 if(bNetInitial && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		DrawScaleX, DrawScaleY, 
	//		DrawScaleZ, bWakeOnLevelStart;
	//}
	
	// Export UKActor::execGetKActorPhysMaterial(FFrame&, void* const)
	public virtual /*native final function */PhysicalMaterial GetKActorPhysMaterial()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UKActor::execResolveRBState(FFrame&, void* const)
	public virtual /*native final function */void ResolveRBState()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		if(bLOIObject && WorldInfo.IsLOIEnabled())
		{
			InitLOI();
		}
		base.PostBeginPlay();
		if(bWakeOnLevelStart)
		{
			StaticMeshComponent.WakeRigidBody(default(name?));
		}
		DrawScaleX = DrawScale3D.X;
		DrawScaleY = DrawScale3D.Y;
		DrawScaleZ = DrawScale3D.Z;
		if(StaticMeshComponent.bNotifyRigidBodyCollision)
		{
			SetPhysicalCollisionProperties();
		}
		InitialLocation = Location;
		InitialRotation = Rotation;
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? KActor_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => KActor_FellOutOfWorld;
	public /*simulated event */void KActor_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
		ShutDown();
		/*Transformed 'base.' to specific call*/Actor_FellOutOfWorld(dmgType);
	}
	
	public virtual /*simulated function */void SetPhysicalCollisionProperties()
	{
		/*local */PhysicalMaterial PhysMat = default;
	
		PhysMat = GetKActorPhysMaterial();
		if(PhysMat.ImpactEffect != default)
		{
			ImpactEffectComponent =  ClassT<ParticleSystemComponent>().New(Outer);
			AttachComponent(ImpactEffectComponent);
			ImpactEffectComponent.bAutoActivate = false;
			ImpactEffectComponent.SetTemplate(PhysMat.ImpactEffect);
		}
		if(PhysMat.ImpactSound != default)
		{
			ImpactSoundComponent =  ClassT<AudioComponent>().New(Outer);
			ImpactSoundComponent.bAutoDestroy = true;
			AttachComponent(ImpactSoundComponent);
			ImpactSoundComponent.SoundCue = PhysMat.ImpactSound;
			ImpactSoundComponent2 =  ClassT<AudioComponent>().New(Outer);
			ImpactSoundComponent2.bAutoDestroy = true;
			AttachComponent(ImpactSoundComponent2);
			ImpactSoundComponent2.SoundCue = PhysMat.ImpactSound;
		}
		if(PhysMat.SlideEffect != default)
		{
			SlideEffectComponent =  ClassT<ParticleSystemComponent>().New(Outer);
			AttachComponent(SlideEffectComponent);
			SlideEffectComponent.bAutoActivate = false;
			SlideEffectComponent.SetTemplate(PhysMat.SlideEffect);
		}
		if(PhysMat.SlideSound != default)
		{
			SlideSoundComponent =  ClassT<AudioComponent>().New(Outer);
			SlideSoundComponent.bAutoDestroy = true;
			AttachComponent(SlideSoundComponent);
			SlideSoundComponent.SoundCue = PhysMat.SlideSound;
		}
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		/*local */Object.Vector NewDrawScale3D = default;
	
		if(VarName == "bWakeOnLevelStart")
		{
			if(bWakeOnLevelStart)
			{
				StaticMeshComponent.WakeRigidBody(default(name?));
			}		
		}
		else
		{
			if(((VarName == "DrawScaleX") || VarName == "DrawScaleY") || VarName == "DrawScaleZ")
			{
				NewDrawScale3D.X = DrawScaleX;
				NewDrawScale3D.Y = DrawScaleY;
				NewDrawScale3D.Z = DrawScaleZ;
				SetDrawScale3D(NewDrawScale3D);			
			}
			else
			{
				base.ReplicatedEvent(VarName);
			}
		}
	}
	
	public virtual /*function */void ApplyImpulse(Object.Vector ImpulseDir, float ImpulseMag, Object.Vector HitLocation, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		/*local */Object.Vector ApplyImpulse = default;
	
		var HitInfo = _HitInfo ?? default;
		ImpulseDir = Normal(ImpulseDir);
		ApplyImpulse = ImpulseDir * ImpulseMag;
		if(HitInfo.HitComponent != default)
		{
			HitInfo.HitComponent.AddImpulse(ApplyImpulse, HitLocation, HitInfo.BoneName, default(bool?));		
		}
		else
		{
			CollisionComponent.AddImpulse(ApplyImpulse, HitLocation, default(name?), default(bool?));
		}
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? KActor_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => KActor_TakeDamage;
	public /*event */void KActor_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
		/*local */Object.Vector ApplyImpulse = default;
	
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		/*Transformed 'base.' to specific call*/Actor_TakeDamage(Damage, EventInstigator, HitLocation, Momentum, DamageType, HitInfo, DamageCauser);
		if(bDamageAppliesImpulse && DamageType.DefaultAs<DamageType>().KDamageImpulse > ((float)(0)))
		{
			if(VSize(Momentum) < 0.0010f)
			{
				return;
			}
			ApplyImpulse = Normal(Momentum) * DamageType.DefaultAs<DamageType>().KDamageImpulse;
			if(HitInfo.HitComponent != default)
			{
				HitInfo.HitComponent.AddImpulse(ApplyImpulse, HitLocation, HitInfo.BoneName, default(bool?));			
			}
			else
			{
				CollisionComponent.AddImpulse(ApplyImpulse, HitLocation, default(name?), default(bool?));
			}
		}
	}
	
	public override /*simulated function */void TakeRadiusDamage(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser)
	{
		/*local */int Idx = default;
		/*local */SeqEvent_TakeDamage DmgEvt = default;
	
		Idx = 0;
		J0x07:{}
		if(Idx < GeneratedEvents.Length)
		{
			DmgEvt = ((GeneratedEvents[Idx]) as SeqEvent_TakeDamage);
			if(DmgEvt != default)
			{
				DmgEvt.HandleDamage(this, InstigatedBy, DamageType, ((int)(BaseDamage)));
			}
			++ Idx;
			goto J0x07;
		}
		if((bDamageAppliesImpulse && DamageType.DefaultAs<DamageType>().RadialDamageImpulse > ((float)(0))) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			CollisionComponent.AddRadialImpulse(HurtOrigin, DamageRadius, DamageType.DefaultAs<DamageType>().RadialDamageImpulse, PrimitiveComponent.ERadialImpulseFalloff.RIF_Linear/*1*/, DamageType.DefaultAs<DamageType>().bRadialDamageVelChange);
		}
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		if(Action.InputLinks[0].bHasImpulse)
		{
			StaticMeshComponent.WakeRigidBody(default(name?));
		}
	}
	
	public override /*simulated function */void OnTeleport(SeqAct_Teleport inAction)
	{
		/*local */array<Object> objVars = default;
		/*local */int Idx = default;
		/*local */Actor destActor = default;
	
		inAction.GetObjectVars(ref/*probably?*/ objVars, "Destination");
		Idx = 0;
		J0x29:{}
		if((Idx < objVars.Length) && destActor == default)
		{
			destActor = ((objVars[Idx]) as Actor);
			++ Idx;
			goto J0x29;
		}
		if(destActor != default)
		{
			StaticMeshComponent.SetRBPosition(destActor.Location, default(name?));
			StaticMeshComponent.SetRBRotation(destActor.Rotation, default(name?));
			PlayTeleportEffect(false, true);
		}
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? KActor_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => KActor_Reset;
	public /*simulated function */void KActor_Reset()
	{
		StaticMeshComponent.SetRBLinearVelocity(vect(0.0f, 0.0f, 0.0f), default(bool?));
		StaticMeshComponent.SetRBAngularVelocity(vect(0.0f, 0.0f, 0.0f), default(bool?));
		StaticMeshComponent.SetRBPosition(InitialLocation, default(name?));
		StaticMeshComponent.SetRBRotation(InitialRotation, default(name?));
		if(!bWakeOnLevelStart)
		{
			StaticMeshComponent.PutRigidBodyToSleep(default(name?));		
		}
		else
		{
			StaticMeshComponent.WakeRigidBody(default(name?));
		}
		ResolveRBState();
		bForceNetUpdate = true;
		/*Transformed 'base.' to specific call*/Actor_Reset();
	}
	
	public override /*function */void AssignPlayerToLOI(Actor Player)
	{
		if(TdLOIAddOn == default)
		{
			TdLOIAddOn =  ClassT<TdLOIAddOnKActor>().New(this);
		}
		TdLOIAddOn.InitLOI(Player);
	}
	
	public override /*event */void ActivateLOI()
	{
		if(TdLOIAddOn == default)
		{
			InitLOI();
		}
		TdLOIAddOn.LookAtActivationAttempt();
	}
	
	public override /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
		if(!bLOIObject || !WorldInfo.IsLOIEnabled())
		{
			return;
		}
		if(TdLOIAddOn != default)
		{
			TdLOIAddOn.OnDeactivateLOI(Sender);		
		}
	}
	
	public override /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
		if(!bLOIObject || !WorldInfo.IsLOIEnabled())
		{
			return;
		}
		if(TdLOIAddOn == default)
		{
			InitLOI();
		}
		if(TdLOIAddOn != default)
		{
			TdLOIAddOn.OnActivateLOI(Sender);
		}
	}
	protected override void RestoreDefaultFunction()
	{
		FellOutOfWorld = null;
		TakeDamage = null;
		Reset = null;
	
	}
	public KActor()
	{
		var Default__KActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x0034B244
			WireframeColor = new Color
			{
				R=0,
				G=255,
				B=128,
				A=255
			},
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KActor.MyLightEnvironment'*/,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: StaticMeshComponent'Default__KActor.StaticMeshComponent0' */;
		// Object Offset:0x0034AE1B
		bDamageAppliesImpulse = true;
		LOILookAtDelay = -1.0f;
		LOIMinDuration = 1.50f;
		LOIDistance = 1500.0f;
		StaticMeshComponent = Default__KActor_StaticMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__KActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KActor.MyLightEnvironment'*/;
		bPawnCanBaseOn = false;
		bSafeBaseIfAsleep = true;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bUpdateSimulatedPosition = true;
		bNetInitialRotation = true;
		bBlocksNavigation = true;
		bCollideActors = true;
		bBlockActors = true;
		bProjTarget = true;
		bBlocksTeleport = true;
		bNoEncroachCheck = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__KActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__KActor.MyLightEnvironment'*/,
			Default__KActor_StaticMeshComponent0,
		};
		Physics = Actor.EPhysics.PHYS_RigidBody;
		TickGroup = Object.ETickingGroup.TG_PostAsyncWork;
		CollisionComponent = Default__KActor_StaticMeshComponent0;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_RigidBodyCollision>(),
		};
	}
}
}
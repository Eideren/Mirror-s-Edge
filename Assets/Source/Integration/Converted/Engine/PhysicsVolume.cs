namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicsVolume : Volume/*
		native
		nativereplication
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	[Category] [interp] public Object.Vector ZoneVelocity;
	[Category] public bool bVelocityAffectsWalking;
	[Category] public bool bPainCausing;
	public bool BACKUP_bPainCausing;
	[Category] public bool bDestructive;
	[Category] public bool bNoInventory;
	[Category] public bool bMoveProjectiles;
	[Category] public bool bBounceVelocity;
	[Category] public bool bNeutralZone;
	[Category] public bool bCrowdAgentsPlayDeathAnim;
	[Category] public bool bPhysicsOnContact;
	public bool bWaterVolume;
	[Category] public float GroundFriction;
	[Category] public float TerminalVelocity;
	[Category] public float DamagePerSec;
	[Category] public Core.ClassT<DamageType> DamageType;
	[Category] public int Priority;
	[Category] public float FluidFriction;
	[Category] public float RigidBodyDamping;
	[Category] public float MaxDampingForce;
	public Info PainTimer;
	public Controller DamageInstigator;
	public PhysicsVolume NextPhysicsVolume;
	
	// Export UPhysicsVolume::execGetGravityZ(FFrame&, void* const)
	public override /*native function */float GetGravityZ()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*simulated event */void eventPostBeginPlay()
	{
		base.eventPostBeginPlay();
		BACKUP_bPainCausing = bPainCausing;
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		if(bPainCausing)
		{
			PainTimer = Spawn(ClassT<VolumeTimer>(), this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
		}
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? PhysicsVolume_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => PhysicsVolume_Reset;
	public /*function */void PhysicsVolume_Reset()
	{
		bPainCausing = BACKUP_bPainCausing;
		bForceNetUpdate = true;
	}
	
	public virtual /*event */void PhysicsChangedFor(Actor Other)
	{
	
	}
	
	public virtual /*event */void ActorEnteredVolume(Actor Other)
	{
	
	}
	
	public virtual /*event */void ActorLeavingVolume(Actor Other)
	{
	
	}
	
	public virtual /*event */void PawnEnteredVolume(Pawn Other)
	{
	
	}
	
	public virtual /*event */void PawnLeavingVolume(Pawn Other)
	{
	
	}
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle inAction)
	{
		base.OnToggle(inAction);
		if(inAction.InputLinks[0].bHasImpulse)
		{
			bPainCausing = BACKUP_bPainCausing;		
		}
		else
		{
			if(inAction.InputLinks[1].bHasImpulse)
			{
				bPainCausing = false;			
			}
			else
			{
				if(inAction.InputLinks[2].bHasImpulse)
				{
					bPainCausing = !bPainCausing && BACKUP_bPainCausing;
				}
			}
		}
	}
	
	public virtual /*function */void TimerPop(VolumeTimer T)
	{
		/*local */Actor A = default;
	
		if(T == PainTimer)
		{
			if(!bPainCausing)
			{
				return;
			}
			
			// foreach TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
			using var e28 = TouchingActors(ClassT<Actor>()).GetEnumerator();
			while(e28.MoveNext() && (A = (Actor)e28.Current) == A)
			{
				if(A.bCanBeDamaged && !A.bStatic)
				{
					CausePainTo(A);
				}			
			}		
		}
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? PhysicsVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => PhysicsVolume_Touch;
	public /*simulated event */void PhysicsVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		/*Transformed 'base.' to specific call*/Actor_Touch(Other, OtherComp, HitLocation, HitNormal);
		if(((Other == default) || Other.bStatic))
		{
			return;
		}
		if((bNoInventory && ((Other) as DroppedPickup) != default) && Other.Owner == default)
		{
			Other.LifeSpan = 1.50f;
			return;
		}
		if(bMoveProjectiles && ZoneVelocity != vect(0.0f, 0.0f, 0.0f))
		{
			if(((int)Other.Physics) == ((int)Actor.EPhysics.PHYS_Projectile/*6*/))
			{
				Other.Velocity += ZoneVelocity;			
			}
			else
			{
				if(((Other.Base == default) && Other.IsA("Emitter")) && ((int)Other.Physics) == ((int)Actor.EPhysics.PHYS_None/*0*/))
				{
					Other.SetPhysics(Actor.EPhysics.PHYS_Projectile/*6*/);
					Other.Velocity += ZoneVelocity;
				}
			}
		}
		if(bPainCausing)
		{
			if(Other.bDestroyInPainVolume)
			{
				Other.VolumeBasedDestroy(this);
				return;
			}
			if(Other.bCanBeDamaged)
			{
				CausePainTo(Other);
			}
		}
	}
	
	public virtual /*function */void CausePainTo(Actor Other)
	{
		if(DamagePerSec > ((float)(0)))
		{
			if(WorldInfo.bSoftKillZ && ((int)Other.Physics) != ((int)Actor.EPhysics.PHYS_Walking/*1*/))
			{
				return;
			}
			Other.TakeDamage(((int)(DamagePerSec)), DamageInstigator, Location, vect(0.0f, 0.0f, 0.0f), DamageType, default(Actor.TraceHitInfo?), default(Actor));		
		}
		else
		{
			Other.HealDamage(((int)(DamagePerSec)), DamageInstigator, DamageType);
		}
	}
	
	public virtual /*function */void ModifyPlayer(Pawn PlayerPawn)
	{
	
	}
	
	public virtual /*function */void NotifyPawnBecameViewTarget(Pawn P, PlayerController PC)
	{
	
	}
	
	public virtual /*function */void OnSetDamageInstigator(SeqAct_SetDamageInstigator Action)
	{
		DamageInstigator = Action.GetController(Action.DamageInstigator);
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Touch = null;
	
	}
	public PhysicsVolume()
	{
		var Default__PhysicsVolume_BrushComponent0 = new BrushComponent
		{
			// Object Offset:0x002B234A
			bAcceptsLights = true,
			LightingChannels = new LightComponent.LightingChannelContainer
			{
				bInitialized = true,
				Dynamic = true,
			},
			CollideActors = true,
			BlockNonZeroExtent = true,
			AlwaysLoadOnClient = true,
			AlwaysLoadOnServer = true,
			// Object Offset:0x0030CA5E
			BlockZeroExtent = true,
		}/* Reference: BrushComponent'Default__PhysicsVolume.BrushComponent0' */;
		// Object Offset:0x0030C7BB
		bVelocityAffectsWalking = true;
		GroundFriction = 8.0f;
		TerminalVelocity = 3500.0f;
		DamageType = ClassT<DamageType>()/*Ref Class'DamageType'*/;
		FluidFriction = 0.30f;
		MaxDampingForce = 1000000.0f;
		BrushComponent = Default__PhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__PhysicsVolume.BrushComponent0'*/;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__PhysicsVolume.BrushComponent0'*/,
		};
		NetUpdateFrequency = 0.10f;
		CollisionComponent = Default__PhysicsVolume_BrushComponent0/*Ref BrushComponent'Default__PhysicsVolume.BrushComponent0'*/;
	}
}
}
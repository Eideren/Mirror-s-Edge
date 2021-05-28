namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Projectile : Actor/*
		abstract
		native
		notplaceable
		hidecategories(Navigation)*/{
	public float Speed;
	public float MaxSpeed;
	public bool bSwitchToZeroCollision;
	public bool bBlockedByInstigator;
	public bool bBegunPlay;
	public bool bRotationFollowsVelocity;
	public bool bNotBlockedByShield;
	public Actor ZeroCollider;
	public /*export editinline */PrimitiveComponent ZeroColliderComponent;
	public float Damage;
	public float DamageRadius;
	public float MomentumTransfer;
	public Core.ClassT<DamageType> MyDamageType;
	public SoundCue SpawnSound;
	public SoundCue ImpactSound;
	public Controller InstigatorController;
	public Actor ImpactedActor;
	public float NetCullDistanceSquared;
	public /*export editinline */CylinderComponent CylinderComponent;
	
	public override /*event */bool EncroachingOn(Actor Other)
	{
	
		return default;
	}
	
	public override /*event */void PreBeginPlay()
	{
	
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public virtual /*function */void Init(Object.Vector Direction)
	{
	
	}
	
	// Export UProjectile::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */bool CanSplash()
	{
	
		return default;
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? Projectile_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => Projectile_Reset;
	public /*function */void Projectile_Reset()
	{
	
	}
	
	public override /*simulated function */bool HurtRadius(float DamageAmount, float InDamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor IgnoredActor = default, /*optional */Controller InstigatedByController = default, /*optional */bool bDoFullDamage = default)
	{
	
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? Projectile_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => Projectile_Touch;
	public /*singular simulated event */void Projectile_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public virtual /*simulated function */void ProcessTouch(Actor Other, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public override /*singular simulated event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
	
	}
	
	public override /*simulated event */void EncroachedBy(Actor Other)
	{
	
	}
	
	public virtual /*simulated function */void Explode(Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public virtual /*final simulated function */void RandSpin(float spinRate)
	{
	
	}
	
	public override /*function */bool IsStationary()
	{
	
		return default;
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? Projectile_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => Projectile_FellOutOfWorld;
	public /*simulated event */void Projectile_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
	
	}
	
	public virtual /*simulated function */float GetTimeToLocation(Object.Vector TargetLoc)
	{
	
		return default;
	}
	
	public /*simulated function */static float StaticGetTimeToLocation(Object.Vector TargetLoc, Object.Vector StartLoc, Controller RequestedBy)
	{
	
		return default;
	}
	
	public /*simulated function */static float GetRange()
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Touch = null;
		FellOutOfWorld = null;
	
	}
	public Projectile()
	{
		// Object Offset:0x003A94D6
		Speed = 2000.0f;
		MaxSpeed = 2000.0f;
		bBlockedByInstigator = true;
		DamageRadius = 220.0f;
		MyDamageType = ClassT<DamageType>()/*Ref Class'DamageType'*/;
		NetCullDistanceSquared = 400000000.0f;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x00466787
			CollisionHeight = 0.0f,
			CollisionRadius = 0.0f,
		}/* Reference: CylinderComponent'Default__Projectile.CollisionCylinder' */;
		bNetTemporary = true;
		bReplicateInstigator = true;
		bGameRelevant = true;
		bCanBeDamaged = true;
		bCollideActors = true;
		bCollideWorld = true;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004D0176
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__Projectile.Sprite' */,
			//Components[1]=
			new CylinderComponent
			{
				// Object Offset:0x00466787
				CollisionHeight = 0.0f,
				CollisionRadius = 0.0f,
			}/* Reference: CylinderComponent'Default__Projectile.CollisionCylinder' */,
		};
		Physics = Actor.EPhysics.PHYS_Projectile;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetPriority = 2.50f;
		LifeSpan = 14.0f;
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x00466787
			CollisionHeight = 0.0f,
			CollisionRadius = 0.0f,
		}/* Reference: CylinderComponent'Default__Projectile.CollisionCylinder' */;
	}
}
}
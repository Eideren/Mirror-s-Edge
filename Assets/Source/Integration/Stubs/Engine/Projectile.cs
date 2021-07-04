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
		// stub
		return default;
	}
	
	public override /*event */void PreBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */void Init(Object.Vector Direction)
	{
		// stub
	}
	
	// Export UProjectile::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*simulated function */bool CanSplash()
	{
		// stub
		return default;
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? Projectile_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => Projectile_Reset;
	public /*function */void Projectile_Reset()
	{
		// stub
	}
	
	public override /*simulated function */bool HurtRadius(float DamageAmount, float InDamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, /*optional */Actor _IgnoredActor = default, /*optional */Controller _InstigatedByController = default, /*optional */bool? _bDoFullDamage = default)
	{
		// stub
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? Projectile_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => Projectile_Touch;
	public /*singular simulated event */void Projectile_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public virtual /*simulated function */void ProcessTouch(Actor Other, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public override /*singular simulated event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
		// stub
	}
	
	public override /*simulated event */void EncroachedBy(Actor Other)
	{
		// stub
	}
	
	public virtual /*simulated function */void Explode(Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public virtual /*final simulated function */void RandSpin(float spinRate)
	{
		// stub
	}
	
	public override /*function */bool IsStationary()
	{
		// stub
		return default;
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? Projectile_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => Projectile_FellOutOfWorld;
	public /*simulated event */void Projectile_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
		// stub
	}
	
	public virtual /*simulated function */float GetTimeToLocation(Object.Vector TargetLoc)
	{
		// stub
		return default;
	}
	
	public /*simulated function */static float StaticGetTimeToLocation(Object.Vector TargetLoc, Object.Vector StartLoc, Controller RequestedBy)
	{
		// stub
		return default;
	}
	
	public /*simulated function */static float GetRange()
	{
		// stub
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
		var Default__Projectile_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00466787
			CollisionHeight = 0.0f,
			CollisionRadius = 0.0f,
		}/* Reference: CylinderComponent'Default__Projectile.CollisionCylinder' */;
		var Default__Projectile_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D0176
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Projectile.Sprite' */;
		// Object Offset:0x003A94D6
		Speed = 2000.0f;
		MaxSpeed = 2000.0f;
		bBlockedByInstigator = true;
		DamageRadius = 220.0f;
		MyDamageType = ClassT<DamageType>()/*Ref Class'DamageType'*/;
		NetCullDistanceSquared = 400000000.0f;
		CylinderComponent = Default__Projectile_CollisionCylinder/*Ref CylinderComponent'Default__Projectile.CollisionCylinder'*/;
		bNetTemporary = true;
		bReplicateInstigator = true;
		bGameRelevant = true;
		bCanBeDamaged = true;
		bCollideActors = true;
		bCollideWorld = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Projectile_Sprite/*Ref SpriteComponent'Default__Projectile.Sprite'*/,
			Default__Projectile_CollisionCylinder/*Ref CylinderComponent'Default__Projectile.CollisionCylinder'*/,
		};
		Physics = Actor.EPhysics.PHYS_Projectile;
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetPriority = 2.50f;
		LifeSpan = 14.0f;
		CollisionComponent = Default__Projectile_CollisionCylinder/*Ref CylinderComponent'Default__Projectile.CollisionCylinder'*/;
	}
}
}
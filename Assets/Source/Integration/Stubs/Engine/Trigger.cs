namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Trigger : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public partial struct CheckpointRecord
	{
		public bool bCollideActors;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003FF077
	//		bCollideActors = false;
	//	}
	};
	
	[Category] [Const, editconst, export, editinline] public CylinderComponent CylinderComponent;
	public bool bRecentlyTriggered;
	[Category] public float AITriggerDelay;
	
	public override Touch_del Touch { get => bfield_Touch ?? Trigger_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => Trigger_Touch;
	public /*event */void Trigger_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		// stub
	}
	
	public virtual /*function */void UnTrigger()
	{
		// stub
	}
	
	public override /*simulated function */bool StopsProjectile(Projectile P)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void CreateCheckpointRecord(ref Trigger.CheckpointRecord Record)
	{
		// stub
	}
	
	public virtual /*function */void ApplyCheckpointRecord(/*const */ref Trigger.CheckpointRecord Record)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public Trigger()
	{
		var Default__Trigger_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x003FF6C6
			CollisionHeight = 40.0f,
			CollisionRadius = 40.0f,
			CollideActors = true,
		}/* Reference: CylinderComponent'Default__Trigger.CollisionCylinder' */;
		var Default__Trigger_Sprite = new SpriteComponent
		{
			// Object Offset:0x003FF65A
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Trigger")/*Ref Texture2D'EngineResources.S_Trigger'*/,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Trigger.Sprite' */;
		// Object Offset:0x003FF47B
		CylinderComponent = Default__Trigger_CollisionCylinder/*Ref CylinderComponent'Default__Trigger.CollisionCylinder'*/;
		AITriggerDelay = 2.0f;
		bHidden = true;
		bNoDelete = true;
		bCollideActors = true;
		bProjTarget = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Trigger_Sprite/*Ref SpriteComponent'Default__Trigger.Sprite'*/,
			Default__Trigger_CollisionCylinder/*Ref CylinderComponent'Default__Trigger.CollisionCylinder'*/,
		};
		CollisionComponent = Default__Trigger_CollisionCylinder/*Ref CylinderComponent'Default__Trigger.CollisionCylinder'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_Used>(),
		};
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpActor : DynamicSMActor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public partial struct CheckpointRecord
	{
		public Object.Vector Location;
		public Object.Rotator Rotation;
		public bool bIsShutdown;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0033E272
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Rotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		bIsShutdown = false;
	//	}
	};
	
	public NavigationPoint MyMarker;
	public bool bMonitorMover;
	public bool bMonitorZVelocity;
	[Category] public bool bDestroyProjectilesOnEncroach;
	[Category] public bool bContinueOnEncroachPhysicsObject;
	[Category] public bool bStopOnEncroach;
	[Category] public bool bIsStickyWhenAimedAt;
	[Category("Interaction")] [Const] public bool LOIUse2DDistance;
	public float MaxZVelocity;
	public float StayOpenTime;
	[Category] public SoundCue OpenSound;
	[Category] public SoundCue OpeningAmbientSound;
	[Category] public SoundCue OpenedSound;
	[Category] public SoundCue CloseSound;
	[Category] public SoundCue ClosingAmbientSound;
	[Category] public SoundCue ClosedSound;
	[export, editinline] public AudioComponent AmbientSoundComponent;
	[Category("Interaction")] [Const] public float LOILookAtDelay;
	[Category("Interaction")] [Const] public float LOIProximityDelay;
	[Category("Interaction")] [Const] public float LOIMinDuration;
	[Category("Interaction")] [Const] public float LOIDistance;
	[Category("Interaction")] [Const] public array<name> LOIGroups;
	public/*private*/ TdLOIAddOnObject TdLOIAddOn;
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */bool EncroachingOn(Actor Other)
	{
		// stub
		return default;
	}
	
	public override /*event */void RanInto(Actor Other)
	{
		// stub
	}
	
	public override /*event */void Attach(Actor Other)
	{
		// stub
	}
	
	public override /*event */void Detach(Actor Other)
	{
		// stub
	}
	
	public virtual /*function */void Restart()
	{
		// stub
	}
	
	public virtual /*function */void FinishedOpen()
	{
		// stub
	}
	
	public virtual /*simulated function */void PlayMovingSound(bool bClosing)
	{
		// stub
	}
	
	public override /*simulated event */void InterpolationStarted(SeqAct_Interp InterpAction)
	{
		// stub
	}
	
	public override /*simulated event */void InterpolationFinished(SeqAct_Interp InterpAction)
	{
		// stub
	}
	
	public override /*simulated event */void InterpolationChanged(SeqAct_Interp InterpAction)
	{
		// stub
	}
	
	public virtual /*function */void CreateCheckpointRecord(ref InterpActor.CheckpointRecord Record)
	{
		// stub
	}
	
	public virtual /*function */void ApplyCheckpointRecord(/*const */ref InterpActor.CheckpointRecord Record)
	{
		// stub
	}
	
	public override /*function */void AssignPlayerToLOI(Actor Player)
	{
		// stub
	}
	
	public override /*event */void ActivateLOI()
	{
		// stub
	}
	
	public override /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
		// stub
	}
	
	public override /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
		// stub
	}
	
	public InterpActor()
	{
		var Default__InterpActor_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment' */;
		var Default__InterpActor_StaticMeshComponent0 = new StaticMeshComponent
		{
			// Object Offset:0x0057981A
			WireframeColor = new Color
			{
				R=255,
				G=0,
				B=255,
				A=255
			},
			LightEnvironment = Default__InterpActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
			},
		}/* Reference: StaticMeshComponent'Default__InterpActor.StaticMeshComponent0' */;
		// Object Offset:0x0033FB8C
		bDestroyProjectilesOnEncroach = true;
		bContinueOnEncroachPhysicsObject = true;
		bStopOnEncroach = true;
		LOILookAtDelay = -1.0f;
		LOIMinDuration = 1.50f;
		LOIDistance = 1500.0f;
		StaticMeshComponent = Default__InterpActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__InterpActor.StaticMeshComponent0'*/;
		LightEnvironment = Default__InterpActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		bBlocksTeleport = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__InterpActor_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/,
			Default__InterpActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__InterpActor.StaticMeshComponent0'*/,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
		RemoteRole = Actor.ENetRole.ROLE_None;
		NetUpdateFrequency = 1.0f;
		NetPriority = 2.70f;
		CollisionComponent = Default__InterpActor_StaticMeshComponent0/*Ref StaticMeshComponent'Default__InterpActor.StaticMeshComponent0'*/;
		SupportedEvents = new array< Core.ClassT<SequenceEvent> >
		{
			ClassT<SeqEvent_Touch>(),
			ClassT<SeqEvent_Destroyed>(),
			ClassT<SeqEvent_TakeDamage>(),
			ClassT<SeqEvent_Mover>(),
			ClassT<SeqEvent_TakeDamage>(),
		};
	}
}
}
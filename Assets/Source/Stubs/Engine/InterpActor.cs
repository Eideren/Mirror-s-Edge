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
	public/*()*/ bool bDestroyProjectilesOnEncroach;
	public/*()*/ bool bContinueOnEncroachPhysicsObject;
	public/*()*/ bool bStopOnEncroach;
	public/*()*/ bool bIsStickyWhenAimedAt;
	public/*(Interaction)*/ /*const */bool LOIUse2DDistance;
	public float MaxZVelocity;
	public float StayOpenTime;
	public/*()*/ SoundCue OpenSound;
	public/*()*/ SoundCue OpeningAmbientSound;
	public/*()*/ SoundCue OpenedSound;
	public/*()*/ SoundCue CloseSound;
	public/*()*/ SoundCue ClosingAmbientSound;
	public/*()*/ SoundCue ClosedSound;
	public /*export editinline */AudioComponent AmbientSoundComponent;
	public/*(Interaction)*/ /*const */float LOILookAtDelay;
	public/*(Interaction)*/ /*const */float LOIProximityDelay;
	public/*(Interaction)*/ /*const */float LOIMinDuration;
	public/*(Interaction)*/ /*const */float LOIDistance;
	public/*(Interaction)*/ /*const */array<name> LOIGroups;
	public /*private */TdLOIAddOnObject TdLOIAddOn;
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*event */bool EncroachingOn(Actor Other)
	{
	
		return default;
	}
	
	public override /*event */void RanInto(Actor Other)
	{
	
	}
	
	public override /*event */void Attach(Actor Other)
	{
	
	}
	
	public override /*event */void Detach(Actor Other)
	{
	
	}
	
	public virtual /*function */void Restart()
	{
	
	}
	
	public virtual /*function */void FinishedOpen()
	{
	
	}
	
	public virtual /*simulated function */void PlayMovingSound(bool bClosing)
	{
	
	}
	
	public override /*simulated event */void InterpolationStarted(SeqAct_Interp InterpAction)
	{
	
	}
	
	public override /*simulated event */void InterpolationFinished(SeqAct_Interp InterpAction)
	{
	
	}
	
	public override /*simulated event */void InterpolationChanged(SeqAct_Interp InterpAction)
	{
	
	}
	
	public virtual /*function */void CreateCheckpointRecord(ref InterpActor.CheckpointRecord Record)
	{
	
	}
	
	public virtual /*function */void ApplyCheckpointRecord(/*const */ref InterpActor.CheckpointRecord Record)
	{
	
	}
	
	public override /*function */void AssignPlayerToLOI(Actor Player)
	{
	
	}
	
	public override /*event */void ActivateLOI()
	{
	
	}
	
	public override /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
	
	}
	
	public override /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
	
	}
	
	public InterpActor()
	{
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
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__InterpActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/,
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
		StaticMeshComponent = Default__InterpActor_StaticMeshComponent0;
		LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__InterpActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/;
		bNoDelete = true;
		bAlwaysRelevant = true;
		bOnlyDirtyReplication = true;
		bBlocksTeleport = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<DynamicLightEnvironmentComponent>("Default__InterpActor.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__InterpActor.MyLightEnvironment'*/,
			Default__InterpActor_StaticMeshComponent0,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
		RemoteRole = Actor.ENetRole.ROLE_None;
		NetUpdateFrequency = 1.0f;
		NetPriority = 2.70f;
		CollisionComponent = Default__InterpActor_StaticMeshComponent0;
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
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CrowdAgent : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public enum EAgentMoveState 
	{
		EAMS_Move,
		EAMS_Idle,
		EAMS_MAX
	};
	
	public SeqAct_CrowdSpawner Spawner;
	public/*()*/ CrowdAgent.EAgentMoveState AgentState;
	public float EndActionTime;
	public float NextActionTime;
	public float VelDamping;
	public Object.Rotator ToTargetRot;
	public bool bRotateToTargetRot;
	public bool bHadNearbyTarget;
	public bool bTargetZPosInitialized;
	public Object.Vector CurrentMoveTargetPos;
	public float InterpZTranslation;
	public/*()*/ /*export editinline */SkeletalMeshComponent SkeletalMeshComponent;
	public AnimNodeBlend SpeedBlendNode;
	public AnimNodeBlend ActionBlendNode;
	public AnimNodeSequence ActionSeqNode;
	public AnimNodeSequence WalkSeqNode;
	public AnimNodeSequence RunSeqNode;
	public AnimTree AgentTree;
	public int Health;
	public/*()*/ /*const editconst export editinline */LightEnvironmentComponent LightEnvironment;
	public /*transient */int ConformTraceFrameCount;
	public /*transient */int AwareUpdateFrameCount;
	public /*transient */array<CrowdAgent> NearbyAgents;
	public /*transient */array<CrowdAttractor> RelevantAttractors;
	public /*transient */ReachSpec NearestPath;
	
	// Export UCrowdAgent::execPlayDeath(FFrame&, void* const)
	public virtual /*native function */void PlayDeath()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? CrowdAgent_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => CrowdAgent_TakeDamage;
	public /*function */void CrowdAgent_TakeDamage(int DamageAmount, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		// stub
	}
	
	public virtual /*simulated event */void SpawnActionEffect(Object.Vector ActionTarget)
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
	
	}
	public CrowdAgent()
	{
		var Default__CrowdAgent_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x00468D2F
			InvisibleUpdateTime = 5.0f,
			MinTimeBetweenFullUpdates = 2.0f,
			bCastShadows = false,
			bEnabled = false,
			TickGroup = Object.ETickingGroup.TG_DuringAsyncWork,
		}/* Reference: DynamicLightEnvironmentComponent'Default__CrowdAgent.MyLightEnvironment' */;
		var Default__CrowdAgent_SkeletalMeshComponent0 = new SkeletalMeshComponent
		{
			// Object Offset:0x004CEC22
			bUpdateSkelWhenNotRendered = false,
			bEnableLineCheckWithBounds = true,
			LightEnvironment = Default__CrowdAgent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__CrowdAgent.MyLightEnvironment'*/,
			bCastDynamicShadow = false,
			CollideActors = true,
			BlockZeroExtent = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
				GameplayPhysics = true,
				EffectPhysics = true,
			},
		}/* Reference: SkeletalMeshComponent'Default__CrowdAgent.SkeletalMeshComponent0' */;
		// Object Offset:0x002F4240
		SkeletalMeshComponent = Default__CrowdAgent_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__CrowdAgent.SkeletalMeshComponent0'*/;
		LightEnvironment = Default__CrowdAgent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__CrowdAgent.MyLightEnvironment'*/;
		bCollideActors = true;
		bProjTarget = true;
		bNoEncroachCheck = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__CrowdAgent_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__CrowdAgent.MyLightEnvironment'*/,
			Default__CrowdAgent_SkeletalMeshComponent0/*Ref SkeletalMeshComponent'Default__CrowdAgent.SkeletalMeshComponent0'*/,
		};
		Physics = Actor.EPhysics.PHYS_Interpolating;
	}
}
}
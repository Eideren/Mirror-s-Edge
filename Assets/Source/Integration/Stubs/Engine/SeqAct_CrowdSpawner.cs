namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_CrowdSpawner : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */RandomCrowdAgentData
	{
		[Category] public SkeletalMesh FlockMesh;
		[Category] public AnimTree FlockAnimTree;
		[Category] public array<MaterialInterface> RandomMaterials;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE241
	//		FlockMesh = default;
	//		FlockAnimTree = default;
	//		RandomMaterials = default;
	//	}
	};
	
	public partial struct /*native */CrowdTargetActionInfo
	{
		[Category] public name AnimName;
		[Category] public bool bFireEffects;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE325
	//		AnimName = (name)"None";
	//		bFireEffects = false;
	//	}
	};
	
	public partial struct /*native */CrowdAttachmentInfo
	{
		[Category] public StaticMesh StaticMesh;
		[Category] public float Chance;
		[Category] public Object.Vector Scale3D;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE425
	//		StaticMesh = default;
	//		Chance = 1.0f;
	//		Scale3D = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//	}
	};
	
	public partial struct /*native */CrowdAttachmentList
	{
		[Category] public name SocketName;
		[Category] public array<SeqAct_CrowdSpawner.CrowdAttachmentInfo> List;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE54D
	//		SocketName = (name)"None";
	//		List = default;
	//	}
	};
	
	public bool bSpawningActive;
	[Category] public bool bConformToBSP;
	[Category] public bool bConformToWorld;
	[Category] public bool bLineSpawner;
	[Category] public bool bSpawnAtEdge;
	[Category] public bool bFlockScaleUniform;
	[Category] public bool bDrawDebugInfo;
	[Category("Lighting")] public bool bEnableCrowdLightEnvironment;
	[Category] public float ConformTraceDist;
	[Category] public int ConformTraceInterval;
	[Category] public Object.Vector CollisionBoxScaling;
	[transient] public array<CrowdAttractor> AssignedMoveTargets;
	[transient] public array<Actor> SpawnLocs;
	[transient] public array<Actor> SafeSpawnLocs;
	[Category] public array<SeqAct_CrowdSpawner.RandomCrowdAgentData> RandomAgents;
	[Category] public float RespawnHiddenTime;
	[transient] public array<float> SpawnLocsHiddenTimes;
	[transient] public PlayerController CachedPC;
	[transient] public float HalfCameraFOVCosine;
	[transient] public int TotalSpawnNum;
	[Category] public float SpawnRate;
	[Category] public int SpawnNum;
	[Category] public float Radius;
	public float Remainder;
	public Core.ClassT<CrowdAgent> AgentClass;
	public Core.ClassT<NavigationPoint> CrowdNodeClass;
	[Category] public float AwareRadius;
	[Category] public int AwareUpdateInterval;
	[Category] public float AvoidOtherStrength;
	[Category] public float AvoidOtherRadius;
	[Category] public float MatchVelStrength;
	[Category] public float ToPathStrength;
	[Category] public float FollowPathStrength;
	[Category] public float PathDistance;
	[Category] public float ToAttractorStrength;
	[Category] public float MinVelDamping;
	[Category] public float MaxVelDamping;
	[Category("Action")] public DistributionFloat.RawDistributionFloat ActionDuration;
	[Category("Action")] public DistributionFloat.RawDistributionFloat ActionInterval;
	[Category("Action")] public DistributionFloat.RawDistributionFloat TargetActionInterval;
	[Category("Action")] public array<name> ActionAnimNames;
	public array<name> TargetActionAnimNames;
	[Category("Action")] public array<SeqAct_CrowdSpawner.CrowdTargetActionInfo> TargetActions;
	[Category("Action")] public name SpawnAnimName;
	[Category("Action")] public array<name> DeathAnimNames;
	[Category("Action")] public float ActionBlendTime;
	[Category("Action")] public float ReActionDelay;
	[Category("Action")] public float RotateToTargetSpeed;
	[Category] public float SpeedBlendStart;
	[Category] public float SpeedBlendEnd;
	[Category] public float AnimVelRate;
	[Category] public float MaxYawRate;
	public SkeletalMesh FlockMesh;
	[Category] public array<SkeletalMesh> FlockMeshes;
	[Category] public array<MaterialInterface> RandomMaterials;
	[Category] public Object.Vector FlockMeshMinScale3D;
	[Category] public Object.Vector FlockMeshMaxScale3D;
	[Category] public array<AnimSet> FlockAnimSets;
	public name WalkAnimName;
	[Category] public array<name> WalkAnimNames;
	public name RunAnimName;
	[Category] public array<name> RunAnimNames;
	[Category] public AnimTree FlockAnimTree;
	[Category] public int Health;
	[Category] public ParticleSystem ExplosiveDeathEffect;
	[Category] public float ExplosiveDeathEffectScale;
	public array<CrowdAgent> SpawnedList;
	[Category("Lighting")] public LightComponent.LightingChannelContainer FlockLighting;
	[Category] public array<SeqAct_CrowdSpawner.CrowdAttachmentList> Attachments;
	public CrowdReplicationActor RepActor;
	
	// Export USeqAct_CrowdSpawner::execKillAgents(FFrame&, void* const)
	public virtual /*native simulated function */void KillAgents()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_CrowdSpawner::execUpdateSpawning(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateSpawning(float DeltaSeconds)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	public virtual /*simulated function */void CreateAttachments(CrowdAgent Agent)
	{
		// stub
	}
	
	public virtual /*event */CrowdAgent SpawnAgent(Actor SpawnLoc)
	{
		// stub
		return default;
	}
	
	public SeqAct_CrowdSpawner()
	{
		var Default__SeqAct_CrowdSpawner_DistributionActionDuration = new DistributionFloatUniform
		{
			// Object Offset:0x0046780B
			Min = 0.80f,
			Max = 1.20f,
		}/* Reference: DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionDuration' */;
		var Default__SeqAct_CrowdSpawner_DistributionActionInterval = new DistributionFloatUniform
		{
			// Object Offset:0x0046785B
			Min = 10.0f,
			Max = 20.0f,
		}/* Reference: DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionInterval' */;
		var Default__SeqAct_CrowdSpawner_DistributionTargetActionInterval = new DistributionFloatUniform
		{
			// Object Offset:0x004678AB
			Min = 1.0f,
			Max = 5.0f,
		}/* Reference: DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionTargetActionInterval' */;
		// Object Offset:0x003BF468
		bFlockScaleUniform = true;
		ConformTraceDist = 75.0f;
		ConformTraceInterval = 10;
		CollisionBoxScaling = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		RespawnHiddenTime = 2.0f;
		SpawnRate = 10.0f;
		SpawnNum = 100;
		Radius = 200.0f;
		AgentClass = ClassT<CrowdAgent>()/*Ref Class'CrowdAgent'*/;
		CrowdNodeClass = ClassT<NavigationPoint>()/*Ref Class'NavigationPoint'*/;
		AwareRadius = 200.0f;
		AwareUpdateInterval = 15;
		AvoidOtherStrength = 1500.0f;
		AvoidOtherRadius = 100.0f;
		MatchVelStrength = 0.60f;
		ToPathStrength = 200.0f;
		FollowPathStrength = 30.0f;
		PathDistance = 300.0f;
		ToAttractorStrength = 50.0f;
		MinVelDamping = 0.0010f;
		MaxVelDamping = 0.0030f;
		ActionDuration = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SeqAct_CrowdSpawner_DistributionActionDuration/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionDuration'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				0.80f,
				1.20f,
				0.80f,
				1.20f,
				0.80f,
				1.20f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		ActionInterval = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SeqAct_CrowdSpawner_DistributionActionInterval/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionInterval'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				10.0f,
				20.0f,
				10.0f,
				20.0f,
				10.0f,
				20.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		TargetActionInterval = new DistributionFloat.RawDistributionFloat
		{
			Distribution = Default__SeqAct_CrowdSpawner_DistributionTargetActionInterval/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionTargetActionInterval'*/,
			Type = 0,
			Op = 2,
			LookupTableNumElements = 2,
			LookupTableChunkSize = 2,
			LookupTable = new array<float>
			{
				1.0f,
				5.0f,
				1.0f,
				5.0f,
				1.0f,
				5.0f,
			},
			LookupTableTimeScale = 0.0f,
			LookupTableStartTime = 0.0f,
		};
		ActionBlendTime = 0.10f;
		ReActionDelay = 1.0f;
		RotateToTargetSpeed = 0.10f;
		SpeedBlendStart = 150.0f;
		SpeedBlendEnd = 180.0f;
		AnimVelRate = 0.0070f;
		MaxYawRate = 40000.0f;
		FlockMeshMinScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		FlockMeshMaxScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		Health = 100;
		ExplosiveDeathEffectScale = 1.0f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Stop",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Destroy All",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = default;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Crowd",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Attractors",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "SafeLoc",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 3;
		ObjName = "Crowd Spawner";
		ObjCategory = "Crowd";
	}
}
}
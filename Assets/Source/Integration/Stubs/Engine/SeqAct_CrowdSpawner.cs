namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_CrowdSpawner : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */RandomCrowdAgentData
	{
		public/*()*/ SkeletalMesh FlockMesh;
		public/*()*/ AnimTree FlockAnimTree;
		public/*()*/ array<MaterialInterface> RandomMaterials;
	
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
		public/*()*/ name AnimName;
		public/*()*/ bool bFireEffects;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE325
	//		AnimName = (name)"None";
	//		bFireEffects = false;
	//	}
	};
	
	public partial struct /*native */CrowdAttachmentInfo
	{
		public/*()*/ StaticMesh StaticMesh;
		public/*()*/ float Chance;
		public/*()*/ Object.Vector Scale3D;
	
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
		public/*()*/ name SocketName;
		public/*()*/ array<SeqAct_CrowdSpawner.CrowdAttachmentInfo> List;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003BE54D
	//		SocketName = (name)"None";
	//		List = default;
	//	}
	};
	
	public bool bSpawningActive;
	public/*()*/ bool bConformToBSP;
	public/*()*/ bool bConformToWorld;
	public/*()*/ bool bLineSpawner;
	public/*()*/ bool bSpawnAtEdge;
	public/*()*/ bool bFlockScaleUniform;
	public/*()*/ bool bDrawDebugInfo;
	public/*(Lighting)*/ bool bEnableCrowdLightEnvironment;
	public/*()*/ float ConformTraceDist;
	public/*()*/ int ConformTraceInterval;
	public/*()*/ Object.Vector CollisionBoxScaling;
	public /*transient */array<CrowdAttractor> AssignedMoveTargets;
	public /*transient */array<Actor> SpawnLocs;
	public /*transient */array<Actor> SafeSpawnLocs;
	public/*()*/ array<SeqAct_CrowdSpawner.RandomCrowdAgentData> RandomAgents;
	public/*()*/ float RespawnHiddenTime;
	public /*transient */array<float> SpawnLocsHiddenTimes;
	public /*transient */PlayerController CachedPC;
	public /*transient */float HalfCameraFOVCosine;
	public /*transient */int TotalSpawnNum;
	public/*()*/ float SpawnRate;
	public/*()*/ int SpawnNum;
	public/*()*/ float Radius;
	public float Remainder;
	public Core.ClassT<CrowdAgent> AgentClass;
	public Core.ClassT<NavigationPoint> CrowdNodeClass;
	public/*()*/ float AwareRadius;
	public/*()*/ int AwareUpdateInterval;
	public/*()*/ float AvoidOtherStrength;
	public/*()*/ float AvoidOtherRadius;
	public/*()*/ float MatchVelStrength;
	public/*()*/ float ToPathStrength;
	public/*()*/ float FollowPathStrength;
	public/*()*/ float PathDistance;
	public/*()*/ float ToAttractorStrength;
	public/*()*/ float MinVelDamping;
	public/*()*/ float MaxVelDamping;
	public/*(Action)*/ DistributionFloat.RawDistributionFloat ActionDuration;
	public/*(Action)*/ DistributionFloat.RawDistributionFloat ActionInterval;
	public/*(Action)*/ DistributionFloat.RawDistributionFloat TargetActionInterval;
	public/*(Action)*/ array<name> ActionAnimNames;
	public array<name> TargetActionAnimNames;
	public/*(Action)*/ array<SeqAct_CrowdSpawner.CrowdTargetActionInfo> TargetActions;
	public/*(Action)*/ name SpawnAnimName;
	public/*(Action)*/ array<name> DeathAnimNames;
	public/*(Action)*/ float ActionBlendTime;
	public/*(Action)*/ float ReActionDelay;
	public/*(Action)*/ float RotateToTargetSpeed;
	public/*()*/ float SpeedBlendStart;
	public/*()*/ float SpeedBlendEnd;
	public/*()*/ float AnimVelRate;
	public/*()*/ float MaxYawRate;
	public SkeletalMesh FlockMesh;
	public/*()*/ array<SkeletalMesh> FlockMeshes;
	public/*()*/ array<MaterialInterface> RandomMaterials;
	public/*()*/ Object.Vector FlockMeshMinScale3D;
	public/*()*/ Object.Vector FlockMeshMaxScale3D;
	public/*()*/ array<AnimSet> FlockAnimSets;
	public name WalkAnimName;
	public/*()*/ array<name> WalkAnimNames;
	public name RunAnimName;
	public/*()*/ array<name> RunAnimNames;
	public/*()*/ AnimTree FlockAnimTree;
	public/*()*/ int Health;
	public/*()*/ ParticleSystem ExplosiveDeathEffect;
	public/*()*/ float ExplosiveDeathEffectScale;
	public array<CrowdAgent> SpawnedList;
	public/*(Lighting)*/ LightComponent.LightingChannelContainer FlockLighting;
	public/*()*/ array<SeqAct_CrowdSpawner.CrowdAttachmentList> Attachments;
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_CrowdSpawner.DistributionActionDuration")/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionDuration'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_CrowdSpawner.DistributionActionInterval")/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionActionInterval'*/,
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
			Distribution = LoadAsset<DistributionFloatUniform>("Default__SeqAct_CrowdSpawner.DistributionTargetActionInterval")/*Ref DistributionFloatUniform'Default__SeqAct_CrowdSpawner.DistributionTargetActionInterval'*/,
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
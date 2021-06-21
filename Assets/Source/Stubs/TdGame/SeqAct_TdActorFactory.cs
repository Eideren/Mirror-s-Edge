namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdActorFactory : SeqAct_ActorFactoryEx/*
		native
		hidecategories(Object)*/{
	public const int ResetLink = 4;
	public const int AllDeadLink = 2;
	public const int SpawnedOneLink = 3;
	public const int SpawnpointsLink = 0;
	public const int TemplateLink = 1;
	public const int TeamLink = 2;
	public const int CoverLink = 3;
	public const int RecycleBotLink = 4;
	public const int OneSpawnedLink = 5;
	
	public int DeathCount;
	public AITeam Team;
	public AIGroup Group;
	public CoverGroup InitialCoverGroup;
	public/*()*/ Core.ClassT<AITemplate> BotTemplate;
	public/*()*/ bool bSeePlayerOnSpawn;
	public/*()*/ bool SpawnIntoKismetState;
	public/*()*/ bool bUseRunnerVision;
	public/*()*/ bool bChaseAI;
	public/*()*/ AITeam.ESide Side;
	public/*()*/ int MainWeaponAmmoDrop_Easy;
	public/*()*/ int MainWeaponAmmoDrop_Medium;
	public/*()*/ int MainWeaponAmmoDrop_Hard;
	public/*()*/ int MainWeaponAmmoDisarm_Easy;
	public/*()*/ int MainWeaponAmmoDisarm_Medium;
	public/*()*/ int MainWeaponAmmoDisarm_Hard;
	public TdActorFactoryAI TdFactory;
	public /*private transient */int DeferState;
	public /*private transient */int DeferIndex;
	public /*private transient */TdBotPawn DeferPawn;
	public /*private transient */AITemplate DeferTemplate;
	
	// Export USeqAct_TdActorFactory::execEveryoneDied(FFrame&, void* const)
	public virtual /*native function */void EveryoneDied()
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*event */void OnSpawn(TdBotPawn NewBot)
	{
		// stub
	}
	
	public override /*function */void Reset()
	{
		// stub
	}
	
	public virtual /*function */void OnDeath(TdBotPawn Victim)
	{
		// stub
	}
	
	public SeqAct_TdActorFactory()
	{
		var Default__SeqAct_TdActorFactory_TdFactory = new TdActorFactoryAI
		{
		}/* Reference: TdActorFactoryAI'Default__SeqAct_TdActorFactory.TdFactory' */;
		// Object Offset:0x00493EC3
		BotTemplate = ClassT<AITemplate_Default>()/*Ref Class'AITemplate_Default'*/;
		MainWeaponAmmoDrop_Easy = -1;
		MainWeaponAmmoDrop_Medium = -1;
		MainWeaponAmmoDrop_Hard = -1;
		MainWeaponAmmoDisarm_Easy = -1;
		MainWeaponAmmoDisarm_Medium = -1;
		MainWeaponAmmoDisarm_Hard = -1;
		Factory = Default__SeqAct_TdActorFactory_TdFactory/*Ref TdActorFactoryAI'Default__SeqAct_TdActorFactory.TdFactory'*/;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Spawn Actor",
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
				LinkDesc = "Enable",
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
				LinkDesc = "Disable",
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
				LinkDesc = "Toggle",
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
				LinkDesc = "Reset",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Aborted",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "All Dead",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Spawned 1",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Spawn Point",
				LinkVar = (name)"None",
				PropertyName = (name)"SpawnPoints",
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
				LinkDesc = "Template",
				LinkVar = (name)"None",
				PropertyName = (name)"BotTemplate",
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
				LinkDesc = "Team",
				LinkVar = (name)"None",
				PropertyName = (name)"Team",
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
				LinkDesc = "Cover Group",
				LinkVar = (name)"None",
				PropertyName = (name)"InitialCoverGroup",
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
				LinkDesc = "RecycleBot 1",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 0,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Spawned 1",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = true,
				bHidden = false,
				MinVars = 0,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjClassVersion = 18;
		ObjName = "Takedown Bot Factory";
		ObjCategory = "AI";
	}
}
}
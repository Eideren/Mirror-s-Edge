namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_ActorFactory : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public enum EPointSelection 
	{
		PS_Normal,
		PS_Random,
		PS_Reverse,
		PS_MAX
	};
	
	public/*()*/ bool bEnabled;
	public bool bIsSpawning;
	public/*()*/ bool bCheckSpawnCollision;
	public/*()*/ /*export editinline */ActorFactory Factory;
	public/*()*/ SeqAct_ActorFactory.EPointSelection PointSelection;
	public/*()*/ array<Actor> SpawnPoints;
	public/*()*/ int SpawnCount;
	public/*()*/ float SpawnDelay;
	public int LastSpawnIdx;
	public int SpawnedCount;
	public float RemainingDelay;
	
	public SeqAct_ActorFactory()
	{
		// Object Offset:0x003B60CB
		bEnabled = true;
		bCheckSpawnCollision = true;
		SpawnCount = 1;
		SpawnDelay = 0.50f;
		LastSpawnIdx = -1;
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
				LinkDesc = "Spawned",
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
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "Spawn Count",
				LinkVar = (name)"None",
				PropertyName = (name)"SpawnCount",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Actor Factory";
		ObjCategory = "Actor";
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdSpawnPooledEmitter : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ ParticleSystem ParticleSystem;
	public/*()*/ array<Actor> SpawnPoints;
	public/*()*/ bool bRandomizeSpawnPoints;
	public /*private */int SpawnIndex;
	
	public override /*event */void Activated()
	{
	
	}
	
	public override /*function */void Reset()
	{
	
	}
	
	public SeqAct_TdSpawnPooledEmitter()
	{
		// Object Offset:0x004A082C
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Activate",
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
				LinkDesc = "SpawnPoint",
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
				LinkDesc = "SelectedSpawnPoint",
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
		ObjClassVersion = 2;
		ObjName = "Spawn Pooled Emitter";
		ObjCategory = "Takedown";
	}
}
}
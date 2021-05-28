namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdHelicopterFactory : SeqAct_ActorFactoryEx/*
		native
		hidecategories(Object)*/{
	public TdActorFactoryHelicopter TdHelicopterFactory;
	public array<Actor> SpawnedChoppers;
	
	public SeqAct_TdHelicopterFactory()
	{
		// Object Offset:0x0049BA88
		Factory = LoadAsset<TdActorFactoryHelicopter>("Default__SeqAct_TdHelicopterFactory.TdHelicopterFactory")/*Ref TdActorFactoryHelicopter'Default__SeqAct_TdHelicopterFactory.TdHelicopterFactory'*/;
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
				LinkDesc = "Crew",
				LinkVar = (name)"None",
				PropertyName = (name)"Crew",
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
		ObjName = "Takedown Helicopter Factory";
		ObjCategory = "AI";
	}
}
}
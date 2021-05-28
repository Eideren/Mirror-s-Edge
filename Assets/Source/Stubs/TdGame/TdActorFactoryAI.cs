namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdActorFactoryAI : ActorFactoryAI/*
		native
		config(Game)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public Core.ClassT<AITemplate> Template;
	public /*transient */AITemplate LastTemplate;
	
	public TdActorFactoryAI()
	{
		// Object Offset:0x0049376C
		ControllerClass = ClassT<TdAIController>()/*Ref Class'TdAIController'*/;
		NewActorClass = ClassT<TdBotPawn>()/*Ref Class'TdBotPawn'*/;
	}
}
}
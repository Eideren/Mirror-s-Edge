namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryMover : ActorFactoryDynamicSM/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactoryMover()
	{
		// Object Offset:0x002616F2
		MenuName = "Add InterpActor";
		NewActorClass = ClassT<InterpActor>()/*Ref Class'InterpActor'*/;
	}
}
}
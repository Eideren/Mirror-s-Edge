namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryPathNode : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactoryPathNode()
	{
		// Object Offset:0x002617B9
		MenuName = "Add PathNode";
		NewActorClass = ClassT<PathNode>()/*Ref Class'PathNode'*/;
	}
}
}
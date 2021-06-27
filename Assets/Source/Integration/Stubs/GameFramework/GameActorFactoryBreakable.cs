namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameActorFactoryBreakable : ActorFactoryRigidBody/*
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public GameActorFactoryBreakable()
	{
		// Object Offset:0x000056D0
		MenuName = "Add Breakable Actor";
		NewActorClass = ClassT<GameBreakableActor>()/*Ref Class'GameBreakableActor'*/;
	}
}
}
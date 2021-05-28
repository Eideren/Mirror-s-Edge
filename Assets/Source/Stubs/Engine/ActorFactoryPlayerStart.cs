namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryPlayerStart : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactoryPlayerStart()
	{
		// Object Offset:0x00261B7D
		MenuName = "Add PlayerStart";
		MenuPriority = 1;
		NewActorClass = ClassT<PlayerStart>()/*Ref Class'PlayerStart'*/;
	}
}
}
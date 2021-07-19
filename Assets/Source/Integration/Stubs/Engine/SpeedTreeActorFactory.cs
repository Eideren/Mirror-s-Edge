namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeActorFactory : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public SpeedTree SpeedTree;
	
	public SpeedTreeActorFactory()
	{
		// Object Offset:0x003ECCDB
		MenuName = "Add SpeedTree";
		NewActorClass = ClassT<SpeedTreeActor>()/*Ref Class'SpeedTreeActor'*/;
	}
}
}
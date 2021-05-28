namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactory : Object/*
		abstract
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public Core.ClassT<Actor> GameplayActorClass;
	public string MenuName;
	public /*config */int MenuPriority;
	public Core.ClassT<Actor> NewActorClass;
	public bool bPlaceable;
	public/*(Spawning)*/ bool bSpawnInSameLevel;
	public string SpecificGameName;
	
	public ActorFactory()
	{
		// Object Offset:0x002608FE
		MenuName = "Add Actor";
		NewActorClass = ClassT<Actor>()/*Ref Class'Actor'*/;
		bPlaceable = true;
	}
}
}
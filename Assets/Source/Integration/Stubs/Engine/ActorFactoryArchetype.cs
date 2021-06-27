namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryArchetype : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ Actor ArchetypeActor;
	
	public ActorFactoryArchetype()
	{
		// Object Offset:0x00260E14
		MenuName = "Add Archetype";
	}
}
}
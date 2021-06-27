namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryCoverLink : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactoryCoverLink()
	{
		// Object Offset:0x00260EB5
		MenuName = "Add CoverLink";
		NewActorClass = ClassT<CoverLink>()/*Ref Class'CoverLink'*/;
		SpecificGameName = "War";
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryLight : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactoryLight()
	{
		// Object Offset:0x00261629
		MenuName = "Add Light (Point)";
		NewActorClass = ClassT<PointLight>()/*Ref Class'PointLight'*/;
	}
}
}
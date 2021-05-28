namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryLensFlare : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ LensFlare LensFlareObject;
	
	public ActorFactoryLensFlare()
	{
		// Object Offset:0x00261564
		MenuName = "Add LensFlare";
		NewActorClass = ClassT<LensFlareSource>()/*Ref Class'LensFlareSource'*/;
	}
}
}
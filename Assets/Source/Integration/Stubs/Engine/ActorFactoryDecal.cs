namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryDecal : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ MaterialInterface DecalMaterial;
	
	public ActorFactoryDecal()
	{
		// Object Offset:0x00260FCA
		MenuName = "Add Decal";
		NewActorClass = ClassT<DecalActor>()/*Ref Class'DecalActor'*/;
	}
}
}
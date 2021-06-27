namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactorySkeletalMesh : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ SkeletalMesh SkeletalMesh;
	public/*()*/ AnimSet AnimSet;
	public/*()*/ name AnimSequenceName;
	
	public ActorFactorySkeletalMesh()
	{
		// Object Offset:0x00261FA5
		GameplayActorClass = ClassT<SkeletalMeshActorSpawnable>()/*Ref Class'SkeletalMeshActorSpawnable'*/;
		MenuName = "Add SkeletalMesh";
		NewActorClass = ClassT<SkeletalMeshActor>()/*Ref Class'SkeletalMeshActor'*/;
	}
}
}
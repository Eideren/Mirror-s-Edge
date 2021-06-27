namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactorySkeletalMeshMAT : ActorFactorySkeletalMesh/*
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public ActorFactorySkeletalMeshMAT()
	{
		// Object Offset:0x00262081
		MenuName = "Add SkeletalMeshMAT";
		NewActorClass = ClassT<SkeletalMeshActorMAT>()/*Ref Class'SkeletalMeshActorMAT'*/;
	}
}
}
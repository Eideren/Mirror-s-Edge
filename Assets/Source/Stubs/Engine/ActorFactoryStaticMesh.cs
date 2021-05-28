namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryStaticMesh : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ StaticMesh StaticMesh;
	public/*()*/ Object.Vector DrawScale3D;
	
	public ActorFactoryStaticMesh()
	{
		// Object Offset:0x002621AC
		DrawScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		MenuName = "Add StaticMesh";
		MenuPriority = 2;
		NewActorClass = ClassT<StaticMeshActor>()/*Ref Class'StaticMeshActor'*/;
	}
}
}
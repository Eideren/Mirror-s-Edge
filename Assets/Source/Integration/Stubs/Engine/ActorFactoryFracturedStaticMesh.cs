namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryFracturedStaticMesh : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public FracturedStaticMesh FracturedStaticMesh;
	[Category] public Object.Vector DrawScale3D;
	
	public ActorFactoryFracturedStaticMesh()
	{
		// Object Offset:0x00261441
		DrawScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		MenuName = "Add FracturedStaticMesh";
		NewActorClass = ClassT<FracturedStaticMeshActor>()/*Ref Class'FracturedStaticMeshActor'*/;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryDynamicSM : ActorFactory/*
		abstract
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ StaticMesh StaticMesh;
	public/*()*/ Object.Vector DrawScale3D;
	public/*()*/ bool bNoEncroachCheck;
	public/*()*/ bool bNotifyRigidBodyCollision;
	public/*()*/ bool bUseCompartment;
	public/*()*/ bool bCastDynamicShadow;
	public/*()*/ Actor.ECollisionType CollisionType;
	
	public ActorFactoryDynamicSM()
	{
		// Object Offset:0x002611C3
		DrawScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		bCastDynamicShadow = true;
		CollisionType = Actor.ECollisionType.COLLIDE_NoCollision;
	}
}
}
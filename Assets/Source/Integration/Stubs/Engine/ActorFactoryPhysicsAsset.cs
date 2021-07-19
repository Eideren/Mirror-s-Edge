namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryPhysicsAsset : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public PhysicsAsset PhysicsAsset;
	[Category] public SkeletalMesh SkeletalMesh;
	[Category] public bool bStartAwake;
	[Category] public bool bDamageAppliesImpulse;
	[Category] public bool bNotifyRigidBodyCollision;
	[Category] public bool bUseCompartment;
	[Category] public bool bCastDynamicShadow;
	[Category] public Object.Vector InitialVelocity;
	[Category] public Object.Vector DrawScale3D;
	
	public ActorFactoryPhysicsAsset()
	{
		// Object Offset:0x00261A19
		bStartAwake = true;
		bDamageAppliesImpulse = true;
		bCastDynamicShadow = true;
		DrawScale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		GameplayActorClass = ClassT<KAssetSpawnable>()/*Ref Class'KAssetSpawnable'*/;
		MenuName = "Add PhysicsAsset";
		NewActorClass = ClassT<KAsset>()/*Ref Class'KAsset'*/;
	}
}
}
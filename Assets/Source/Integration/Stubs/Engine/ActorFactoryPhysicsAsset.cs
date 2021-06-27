namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryPhysicsAsset : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ PhysicsAsset PhysicsAsset;
	public/*()*/ SkeletalMesh SkeletalMesh;
	public/*()*/ bool bStartAwake;
	public/*()*/ bool bDamageAppliesImpulse;
	public/*()*/ bool bNotifyRigidBodyCollision;
	public/*()*/ bool bUseCompartment;
	public/*()*/ bool bCastDynamicShadow;
	public/*()*/ Object.Vector InitialVelocity;
	public/*()*/ Object.Vector DrawScale3D;
	
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
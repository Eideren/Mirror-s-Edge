namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryRigidBody : ActorFactoryDynamicSM/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public bool bStartAwake;
	[Category] public bool bDamageAppliesImpulse;
	[Category] public bool bLocalSpaceInitialVelocity;
	[Category] public Object.Vector InitialVelocity;
	[Category] [export, editinline] public DistributionVector AdditionalVelocity;
	[Category] [export, editinline] public DistributionVector InitialAngularVelocity;
	[Category] public PrimitiveComponent.ERBCollisionChannel RBChannel;
	
	public ActorFactoryRigidBody()
	{
		// Object Offset:0x00261DA4
		bStartAwake = true;
		bDamageAppliesImpulse = true;
		RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_GameplayPhysics;
		bNoEncroachCheck = true;
		CollisionType = Actor.ECollisionType.COLLIDE_BlockAll;
		GameplayActorClass = ClassT<KActorSpawnable>()/*Ref Class'KActorSpawnable'*/;
		MenuName = "Add RigidBody";
		NewActorClass = ClassT<KActor>()/*Ref Class'KActor'*/;
	}
}
}
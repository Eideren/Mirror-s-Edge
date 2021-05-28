namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryRigidBody : ActorFactoryDynamicSM/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ bool bStartAwake;
	public/*()*/ bool bDamageAppliesImpulse;
	public/*()*/ bool bLocalSpaceInitialVelocity;
	public/*()*/ Object.Vector InitialVelocity;
	public/*()*/ /*export editinline */DistributionVector AdditionalVelocity;
	public/*()*/ /*export editinline */DistributionVector InitialAngularVelocity;
	public/*()*/ PrimitiveComponent.ERBCollisionChannel RBChannel;
	
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
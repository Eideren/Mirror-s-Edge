namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryEmitter : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ ParticleSystem ParticleSystem;
	public/*()*/ /*export editinline */ParticleSystemComponent ParticleSystemPhysX;
	
	public ActorFactoryEmitter()
	{
		// Object Offset:0x00261302
		GameplayActorClass = ClassT<EmitterSpawnable>()/*Ref Class'EmitterSpawnable'*/;
		MenuName = "Add Emitter";
		NewActorClass = ClassT<Emitter>()/*Ref Class'Emitter'*/;
	}
}
}
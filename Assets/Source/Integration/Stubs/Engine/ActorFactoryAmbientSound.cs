namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryAmbientSound : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ SoundCue AmbientSoundCue;
	
	public ActorFactoryAmbientSound()
	{
		// Object Offset:0x00260C1E
		MenuName = "Add AmbientSound";
		NewActorClass = ClassT<AmbientSound>()/*Ref Class'AmbientSound'*/;
	}
}
}
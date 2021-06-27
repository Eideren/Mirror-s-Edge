namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryAmbientSoundSimple : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ SoundNodeWave SoundNodeWave;
	
	public ActorFactoryAmbientSoundSimple()
	{
		// Object Offset:0x00260D16
		MenuName = "Add AmbientSoundSimple";
		NewActorClass = ClassT<AmbientSoundSimple>()/*Ref Class'AmbientSoundSimple'*/;
	}
}
}
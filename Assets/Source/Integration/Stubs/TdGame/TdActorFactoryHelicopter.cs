namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdActorFactoryHelicopter : ActorFactoryVehicle/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public Core.ClassT<TdAI_HeliController> ControllerClass;
	[Category] public SkeletalMesh HelicopterSkeletalMesh;
	
	public TdActorFactoryHelicopter()
	{
		// Object Offset:0x0049B92D
		ControllerClass = ClassT<TdAI_HeliController>()/*Ref Class'TdAI_HeliController'*/;
		VehicleClass = ClassT<TdVehicle_Helicopter>()/*Ref Class'TdVehicle_Helicopter'*/;
		NewActorClass = ClassT<TdVehicle_Helicopter>()/*Ref Class'TdVehicle_Helicopter'*/;
	}
}
}
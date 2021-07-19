namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryVehicle : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public Core.ClassT<Vehicle> VehicleClass;
	
	public ActorFactoryVehicle()
	{
		// Object Offset:0x002623A9
		VehicleClass = ClassT<Vehicle>()/*Ref Class'Vehicle'*/;
		bPlaceable = false;
	}
}
}
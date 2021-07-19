namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdActorFactoryPickup : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public Core.ClassT<Inventory> InventoryClass;
	[Category] public float LifeSpanInSeconds;
	[Category] public bool bLiveForever;
	
	public TdActorFactoryPickup()
	{
		// Object Offset:0x004A99EF
		LifeSpanInSeconds = 16.0f;
		NewActorClass = ClassT<TdPickup>()/*Ref Class'TdPickup'*/;
		bPlaceable = false;
	}
}
}
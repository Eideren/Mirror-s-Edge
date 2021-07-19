namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryAI : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public Core.ClassT<AIController> ControllerClass;
	[Category] public Core.ClassT<Pawn> PawnClass;
	[Category] public String PawnName;
	[Category] public bool bGiveDefaultInventory;
	[Category] public array< Core.ClassT<Inventory> > InventoryList;
	[Category] public int TeamIndex;
	
	public ActorFactoryAI()
	{
		// Object Offset:0x00260B23
		ControllerClass = ClassT<AIController>()/*Ref Class'AIController'*/;
		TeamIndex = 255;
		bPlaceable = false;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorFactoryAI : ActorFactory/*
		native
		config(Editor)
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ Core.ClassT<AIController> ControllerClass;
	public/*()*/ Core.ClassT<Pawn> PawnClass;
	public/*()*/ string PawnName;
	public/*()*/ bool bGiveDefaultInventory;
	public/*()*/ array< Core.ClassT<Inventory> > InventoryList;
	public/*()*/ int TeamIndex;
	
	public ActorFactoryAI()
	{
		// Object Offset:0x00260B23
		ControllerClass = ClassT<AIController>()/*Ref Class'AIController'*/;
		TeamIndex = 255;
		bPlaceable = false;
	}
}
}
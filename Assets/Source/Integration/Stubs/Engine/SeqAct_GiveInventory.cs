namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_GiveInventory : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ array< Core.ClassT<Inventory> > InventoryList;
	public/*()*/ bool bClearExisting;
	
	public SeqAct_GiveInventory()
	{
		// Object Offset:0x003C449F
		ObjName = "Give Inventory";
		ObjCategory = "Pawn";
	}
}
}
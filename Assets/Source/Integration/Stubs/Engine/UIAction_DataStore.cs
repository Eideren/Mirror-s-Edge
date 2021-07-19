namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_DataStore : UIAction/*
		abstract
		native
		hidecategories(Object)*/{
	[Category] public int BindingIndex;
	
	public UIAction_DataStore()
	{
		// Object Offset:0x00402594
		BindingIndex = -1;
		bAutoTargetOwner = true;
		ObjName = "Data Store";
		ObjCategory = "Data Store";
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PowerupDataProvider : InventoryDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public override /*event */bool IsValidDataSourceClass(Class PotentialDataSourceClass)
	{
	
		return default;
	}
	
	public PowerupDataProvider()
	{
		// Object Offset:0x003A7AC8
		DataClass = ClassT<Inventory>()/*Ref Class'Inventory'*/;
	}
}
}
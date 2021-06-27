namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class WeaponDataProvider : InventoryDataProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public WeaponDataProvider()
	{
		// Object Offset:0x002F7CF7
		DataClass = ClassT<Weapon>()/*Ref Class'Weapon'*/;
	}
}
}
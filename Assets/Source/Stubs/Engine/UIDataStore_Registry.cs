namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_Registry : UIDataStore/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*protected */UIDynamicFieldProvider RegistryDataProvider;
	
	public virtual /*final function */UIDynamicFieldProvider GetDataProvider()
	{
		// stub
		return default;
	}
	
	public UIDataStore_Registry()
	{
		// Object Offset:0x0042C7BE
		Tag = (name)"Registry";
		WriteAccessType = UIDataProvider.EProviderAccessType.ACCESS_WriteAll;
	}
}
}
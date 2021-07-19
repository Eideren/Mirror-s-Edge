namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_Strings : UIDataStore/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[transient] public array<UIConfigFileProvider> LocFileProviders;
	
	public UIDataStore_Strings()
	{
		// Object Offset:0x0042D09E
		Tag = (name)"Strings";
	}
}
}
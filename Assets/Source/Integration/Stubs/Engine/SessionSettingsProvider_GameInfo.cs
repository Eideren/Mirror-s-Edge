namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SessionSettingsProvider_GameInfo : SessionSettingsProvider/* within UIDataStore_SessionSettings*//*
		transient
		hidecategories(Object,UIRoot)*/{
	public new UIDataStore_SessionSettings Outer => base.Outer as UIDataStore_SessionSettings;
	
	public SessionSettingsProvider_GameInfo()
	{
		// Object Offset:0x003E1CD9
		ProviderClientMetaClass = ClassT<GameInfo>()/*Ref Class'GameInfo'*/;
	}
}
}
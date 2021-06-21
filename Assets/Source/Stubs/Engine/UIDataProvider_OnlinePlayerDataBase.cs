namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_OnlinePlayerDataBase : UIDataProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public LocalPlayer Player;
	
	public virtual /*event */void OnRegister(LocalPlayer InPlayer)
	{
		// stub
	}
	
	public virtual /*event */void OnUnregister()
	{
		// stub
	}
	
}
}
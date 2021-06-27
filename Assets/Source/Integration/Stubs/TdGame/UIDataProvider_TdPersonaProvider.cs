namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdPersonaProvider : UIDataProvider_TdResource/*
		transient
		native
		config(Game)
		perobjectconfig
		hidecategories(Object,UIRoot)*/{
	public array<String> Personas;
	
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
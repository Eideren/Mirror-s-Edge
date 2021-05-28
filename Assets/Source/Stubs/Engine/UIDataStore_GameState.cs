namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_GameState : UIDataStore/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*delegate*/UIDataStore_GameState.OnRefreshDataFieldValue __OnRefreshDataFieldValue__Delegate;
	
	public delegate void OnRefreshDataFieldValue();
	
	public override /*function */bool NotifyGameSessionEnded()
	{
	
		return default;
	}
	
}
}
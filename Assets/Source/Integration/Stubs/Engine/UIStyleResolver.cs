namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface UIStyleResolver : Interface/*
		abstract
		native*/{
	// Export UUIStyleResolver::execGetStyleResolverTag(FFrame&, void* const)
	public /*native function */name GetStyleResolverTag();
	
	// Export UUIStyleResolver::execSetStyleResolverTag(FFrame&, void* const)
	public /*native function */bool SetStyleResolverTag(name NewResolverTag);
	
	// Export UUIStyleResolver::execNotifyResolveStyle(FFrame&, void* const)
	public /*native function */bool NotifyResolveStyle(UISkin ActiveSkin, bool bClearExistingValue, /*optional */UIState? _CurrentMenuState = default, /*const optional */name? _StylePropertyName = default);
	
}
}
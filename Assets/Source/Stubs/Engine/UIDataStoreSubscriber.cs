namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public interface UIDataStoreSubscriber : Interface/*
		abstract
		native*/{
	// Export UUIDataStoreSubscriber::execSetDataStoreBinding(FFrame&, void* const)
	public /*native function */void SetDataStoreBinding(string MarkupText, /*optional */int? _BindingIndex = default);
	
	// Export UUIDataStoreSubscriber::execGetDataStoreBinding(FFrame&, void* const)
	public /*native function */string GetDataStoreBinding(/*optional */int? _BindingIndex = default);
	
	// Export UUIDataStoreSubscriber::execRefreshSubscriberValue(FFrame&, void* const)
	public /*native function */bool RefreshSubscriberValue(/*optional */int? _BindingIndex = default);
	
	// Export UUIDataStoreSubscriber::execNotifyDataStoreValueUpdated(FFrame&, void* const)
	public /*native function */void NotifyDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex);
	
	// Export UUIDataStoreSubscriber::execGetBoundDataStores(FFrame&, void* const)
	public /*native function */void GetBoundDataStores(ref array<UIDataStore> out_BoundDataStores);
	
	// Export UUIDataStoreSubscriber::execClearBoundDataStores(FFrame&, void* const)
	public /*native function */void ClearBoundDataStores();
	
}
}
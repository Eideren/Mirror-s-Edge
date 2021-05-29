namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore : UIDataProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public name Tag;
	public array< /*delegate*/UIDataStore.OnDataStoreValueUpdated > RefreshSubscriberNotifies;
	public /*delegate*/UIDataStore.OnDataStoreValueUpdated __OnDataStoreValueUpdated__Delegate;
	
	public delegate void OnDataStoreValueUpdated(UIDataStore SourceDataStore, bool bValuesInvalidated, name PropertyTag, UIDataProvider SourceProvider, int ArrayIndex);
	
	public virtual /*event */void Registered(LocalPlayer PlayerOwner)
	{
	
	}
	
	public virtual /*event */void Unregistered(LocalPlayer PlayerOwner)
	{
	
	}
	
	public virtual /*event */void SubscriberAttached(UIDataStoreSubscriber Subscriber)
	{
	
	}
	
	public virtual /*event */void SubscriberDetached(UIDataStoreSubscriber Subscriber)
	{
	
	}
	
	public virtual /*function */bool NotifyGameSessionEnded()
	{
	
		return default;
	}
	
	public virtual /*event */void RefreshSubscribers(/*optional */name? _PropertyTag = default, /*optional */bool? _bInvalidateValues = default, /*optional */UIDataProvider? _SourceProvider = default, /*optional */int? _ArrayIndex = default)
	{
	
	}
	
	// Export UUIDataStore::execOnCommit(FFrame&, void* const)
	public virtual /*native function */void OnCommit()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */DataStoreClient GetDataStoreClient()
	{
	
		return default;
	}
	
}
}
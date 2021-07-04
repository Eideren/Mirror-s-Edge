// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

// INITIALLY A CLASS, C# DOESN'T SUPPORT MULTI-CLASS INHERITANCE
public /*partial class*/interface UIDataStorePublisher : UIDataStoreSubscriber/*
		abstract
		native*/{
	
	
}



public static class UIDataStorePublisherExtension
{
	// Export UUIDataStorePublisher::execSaveSubscriberValue(FFrame&, void* const)
	public static /*native function */bool SaveSubscriberValue(this UIDataStorePublisher thisPub, ref array<UIDataStore> out_BoundDataStores, /*optional */int? BindingIndex = default)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
}


}
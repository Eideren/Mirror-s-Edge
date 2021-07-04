namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataStore_TdGameResource : UIDataStore_GameResource/*
		transient
		native
		config(Game)
		hidecategories(Object,UIRoot)*/{
	// Export UUIDataStore_TdGameResource::execGetProviderCount(FFrame&, void* const)
	public virtual /*native function */int GetProviderCount(name FieldName, /*optional */bool? _bDoNotFilter = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameResource::execGetValueFromProviderSet(FFrame&, void* const)
	public virtual /*native function */bool GetValueFromProviderSet(name ProviderFieldName, name SearchTag, int ListIndex, ref UIRoot.UIProviderFieldValue OutValue)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUIDataStore_TdGameResource::execGetStringValueFromProviderSet(FFrame&, void* const)
	public virtual /*native function */bool GetStringValueFromProviderSet(name ProviderFieldName, name SearchTag, int ListIndex, ref String OutString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}
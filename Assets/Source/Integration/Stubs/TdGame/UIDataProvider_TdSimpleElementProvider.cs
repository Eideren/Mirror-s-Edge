namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIDataProvider_TdSimpleElementProvider : UIDataProvider, 
		UIListElementCellProvider/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_IUIListElementCellProvider;
	
	// Export UUIDataProvider_TdSimpleElementProvider::execGetElementCount(FFrame&, void* const)
	public virtual /*native function */int GetElementCount()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}
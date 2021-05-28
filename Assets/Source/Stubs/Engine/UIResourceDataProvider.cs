namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIResourceDataProvider : UIPropertyDataProvider, 
		UIListElementCellProvider/*
		abstract
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*private native const noexport */Object.Pointer VfTable_IUIListElementCellProvider;
	
	public virtual /*event */bool IsProviderDisabled()
	{
	
		return default;
	}
	
}
}
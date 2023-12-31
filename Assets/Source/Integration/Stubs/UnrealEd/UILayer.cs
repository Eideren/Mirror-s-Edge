namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UILayer : UILayerBase/*
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */UILayerNode
	{
		[Const] public/*private*/ bool bLocked;
		[Const] public/*private*/ bool bVisible;
		[Const] public/*private*/ Object LayerObject;
		[Const] public/*private*/ UILayer ParentLayer;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002D641
	//		bLocked = false;
	//		bVisible = true;
	//		LayerObject = default;
	//		ParentLayer = default;
	//	}
	};
	
	public String LayerName;
	public array<UILayer.UILayerNode> LayerNodes;
	
	// Export UUILayer::execInsertNode(FFrame&, void* const)
	public virtual /*native final function */bool InsertNode(/*const */ref UILayer.UILayerNode NodeToInsert, /*optional */int? _InsertIndex = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUILayer::execRemoveNode(FFrame&, void* const)
	public virtual /*native final function */bool RemoveNode(/*const */ref UILayer.UILayerNode ExistingNode)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UUILayer::execFindNodeIndex(FFrame&, void* const)
	public virtual /*native final function */int FindNodeIndex(/*const */Object NodeObject)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}
namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UILayer : UILayerBase/*
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */UILayerNode
	{
		public /*private const */bool bLocked;
		public /*private const */bool bVisible;
		public /*private const */Object LayerObject;
		public /*private const */UILayer ParentLayer;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002D641
	//		bLocked = false;
	//		bVisible = true;
	//		LayerObject = default;
	//		ParentLayer = default;
	//	}
	};
	
	public string LayerName;
	public array<UILayer.UILayerNode> LayerNodes;
	
	// Export UUILayer::execInsertNode(FFrame&, void* const)
	public virtual /*native final function */bool InsertNode(/*const */ref UILayer.UILayerNode NodeToInsert, /*optional */int InsertIndex = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUILayer::execRemoveNode(FFrame&, void* const)
	public virtual /*native final function */bool RemoveNode(/*const */ref UILayer.UILayerNode ExistingNode)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUILayer::execFindNodeIndex(FFrame&, void* const)
	public virtual /*native final function */int FindNodeIndex(/*const */Object NodeObject)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefab : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native transient */ArchetypeInstancePair
	{
		public /*init transient */UIObject WidgetArchetype;
		public /*init transient */UIObject WidgetInstance;
		public /*init transient */StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ ArchetypeBounds;
		public /*init transient */StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ InstanceBounds;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00447E85
	//		WidgetArchetype = default;
	//		WidgetInstance = default;
	//		ArchetypeBounds = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	//			[3] = 0.0f,
	// 		};
	//		InstanceBounds = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
	//		{ 
	//			[0] = 0.0f,
	//			[1] = 0.0f,
	//			[2] = 0.0f,
	//			[3] = 0.0f,
	// 		};
	//	}
	};
	
	public /*const */int PrefabVersion;
	public /*private const */int InternalPrefabVersion;
	public /*editoronly const */Texture2D PrefabPreview;
	public /*const transient */int ModificationCounter;
	
	public UIPrefab()
	{
		// Object Offset:0x00448089
		EventProvider = LoadAsset<UIComp_Event>("Default__UIPrefab.WidgetEventComponent")/*Ref UIComp_Event'Default__UIPrefab.WidgetEventComponent'*/;
	}
}
}
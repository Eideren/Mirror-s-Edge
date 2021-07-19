namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIPrefab : UIObject/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public partial struct /*native transient */ArchetypeInstancePair
	{
		[init, transient] public UIObject WidgetArchetype;
		[init, transient] public UIObject WidgetInstance;
		[init, transient] public StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ ArchetypeBounds;
		[init, transient] public StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/ InstanceBounds;
	
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
	
	[Const] public int PrefabVersion;
	[Const] public/*private*/ int InternalPrefabVersion;
	[editoronly, Const] public Texture2D PrefabPreview;
	[Const, transient] public int ModificationCounter;
	
	public UIPrefab()
	{
		var Default__UIPrefab_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIPrefab.WidgetEventComponent' */;
		// Object Offset:0x00448089
		EventProvider = Default__UIPrefab_WidgetEventComponent/*Ref UIComp_Event'Default__UIPrefab.WidgetEventComponent'*/;
	}
}
}
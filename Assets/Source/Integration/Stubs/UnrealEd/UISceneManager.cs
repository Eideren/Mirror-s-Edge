namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISceneManager : Object/*
		transient
		native
		config(Editor)*/{
	public partial struct /*native transient */UIResourceInfo
	{
		[init] public Object UIResource;
		[init] public String FriendlyName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002DFB1
	//		UIResource = default;
	//		FriendlyName = "";
	//	}
	};
	
	public partial struct /*native transient */UIObjectResourceInfo// extends UIResourceInfo
	{
		[init] public Object UIResource;
		[init] public String FriendlyName;
			// Object Offset:0x0002DFB1
	//		UIResource = default;
	//		FriendlyName = "";
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native transient */UIStyleResourceInfo// extends UIResourceInfo
	{
		[init] public Object UIResource;
		[init] public String FriendlyName;
			// Object Offset:0x0002DFB1
	//		UIResource = default;
	//		FriendlyName = "";
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native transient */UIStateResourceInfo// extends UIResourceInfo
	{
		[init] public Object UIResource;
		[init] public String FriendlyName;
			// Object Offset:0x0002DFB1
	//		UIResource = default;
	//		FriendlyName = "";
	//
	//	structdefaultproperties
	//	{
	//	}
	};
	
	public partial struct /*native */UIObjectToolbarMapping
	{
		public String WidgetClassName;
		public String IconName;
		public String ToolTip;
		public String HelpText;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002E109
	//		WidgetClassName = "";
	//		IconName = "";
	//		ToolTip = "";
	//		HelpText = "";
	//	}
	};
	
	public partial struct /*native */UITitleRegions
	{
		public float RecommendedPercentage;
		public float MaxPercentage;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0002E209
	//		RecommendedPercentage = 0.0f;
	//		MaxPercentage = 0.0f;
	//	}
	};
	
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FGlobalDataStoreClientManager;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FExec;
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FCallbackEventDevice;
	[transient] public UISkin ActiveSkin;
	[Const, transient] public DataStoreClient DataStoreManager;
	[Const, transient] public array<EditorUISceneClient> SceneClients;
	[Const, transient] public array<UISceneManager.UIObjectResourceInfo> UIWidgetResources;
	[Const, config] public array</*config */UISceneManager.UIObjectToolbarMapping> UIWidgetToolbarMaps;
	[Const, transient] public array<UISceneManager.UIStyleResourceInfo> UIStyleResources;
	[Const, transient] public/*private*/ array<UISceneManager.UIStateResourceInfo> UIStateResources;
	[Const, transient] public /*map<0,0>*/map<object, object> UIStateResourceInfoMap;
	[Const, config] public UISceneManager.UITitleRegions TitleRegions;
	[native, Const, transient] public/*private*/ Object.Pointer DlgUIDataStoreBrowser;
	
	// Export UUISceneManager::execGetSupportedUIStates(FFrame&, void* const)
	public virtual /*native final function */void GetSupportedUIStates(ref array<UISceneManager.UIStateResourceInfo> out_SupportedStates, /*optional */Core.ClassT<UIScreenObject> _WidgetClass = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public UISceneManager()
	{
		// Object Offset:0x0002E354
		UIWidgetToolbarMaps = new array</*config */UISceneManager.UIObjectToolbarMapping>
		{
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIButton",
				IconName = "UI_MODE_BUTTON",
				ToolTip = "UIEditor_Widget_Button",
				HelpText = "UIEditor_HelpText_Button",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIEditBox",
				IconName = "UI_MODE_EDITBOX",
				ToolTip = "UIEditor_Widget_Editbox",
				HelpText = "UIEditor_HelpText_Editbox",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIImage",
				IconName = "UI_MODE_IMAGE",
				ToolTip = "UIEditor_Widget_Image",
				HelpText = "UIEditor_HelpText_Image",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UILabel",
				IconName = "UI_MODE_LABEL",
				ToolTip = "UIEditor_Widget_Label",
				HelpText = "UIEditor_HelpText_Label",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UILabelButton",
				IconName = "UI_MODE_LABELBUTTON",
				ToolTip = "UIEditor_Widget_LabelButton",
				HelpText = "UIEditor_HelpText_LabelButton",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIToggleButton",
				IconName = "UI_MODE_TOGGLEBUTTON",
				ToolTip = "UIEditor_Widget_ToggleButton",
				HelpText = "UIEditor_HelpText_ToggleButton",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UICheckbox",
				IconName = "UI_MODE_CHECKBOX",
				ToolTip = "UIEditor_Widget_CheckBox",
				HelpText = "UIEditor_HelpText_CheckBox",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIList",
				IconName = "UI_MODE_LIST",
				ToolTip = "UIEditor_Widget_List",
				HelpText = "UIEditor_HelpText_List",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UIPanel",
				IconName = "UI_MODE_PANEL",
				ToolTip = "UIEditor_Widget_Panel",
				HelpText = "UIEditor_HelpText_Panel",
			},
			new UISceneManager.UIObjectToolbarMapping
			{
				WidgetClassName = "Engine.UISlider",
				IconName = "UI_MODE_SLIDER",
				ToolTip = "UIEditor_Widget_Slider",
				HelpText = "UIEditor_HelpText_Slider",
			},
		};
		TitleRegions = new UISceneManager.UITitleRegions
		{
			RecommendedPercentage = 0.850f,
			MaxPercentage = 0.90f,
		};
	}
}
}
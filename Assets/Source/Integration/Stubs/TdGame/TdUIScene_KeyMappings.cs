namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_KeyMappings : TdUIScene_OptionMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */TdUITabControl KeyBindsTabControl;
	public /*transient */UIImage KeyBindsTab0BgImage;
	public /*transient */UIImage KeyBindsTab0BgTopImage;
	public /*transient */UIImage KeyBindsTab1BgImage;
	public /*transient */UIImage KeyBindsTab1BgTopImage;
	public /*transient */UIObject KeyBindButton_MoveForward;
	public /*transient */UIObject KeyBindButton_Fire;
	public /*transient */TdKeyBindingHandler KeyBindingHandler;
	public /*transient */array<TdKeyBindingHandler.KeyBindWidgetData> KeyBindWidgets;
	public /*private transient */bool bMouseSettingsChanged;
	
	// Export UTdUIScene_KeyMappings::execRebuildNavigationLinks(FFrame&, void* const)
	public override /*native function */void RebuildNavigationLinks()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
		// stub
	}
	
	public override /*function */void InitWidgets()
	{
		// stub
	}
	
	public virtual /*function */bool IsAllowedBindingKey(name Key)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetBindLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
		// stub
	}
	
	public override /*function */void DoReset()
	{
		// stub
	}
	
	public override /*function */void OnAccept()
	{
		// stub
	}
	
	public virtual /*function */void OnMessageBox_UnboundKeys(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public override /*function */void InitializeSettings()
	{
		// stub
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void OnMouseSettingsChanges()
	{
		// stub
	}
	
	public override /*function */void OnChange()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_KeyMappings()
	{
		var Default__TdUIScene_KeyMappings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_KeyMappings.SceneEventComponent' */;
		// Object Offset:0x0056D1D0
		EventProvider = Default__TdUIScene_KeyMappings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_KeyMappings.SceneEventComponent'*/;
	}
}
}
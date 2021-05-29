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
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
	
	}
	
	public override /*function */void InitWidgets()
	{
	
	}
	
	public virtual /*function */bool IsAllowedBindingKey(name Key)
	{
	
		return default;
	}
	
	public virtual /*function */void SetBindLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */void DoReset()
	{
	
	}
	
	public override /*function */void OnAccept()
	{
	
	}
	
	public virtual /*function */void OnMessageBox_UnboundKeys(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public override /*function */void InitializeSettings()
	{
	
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void OnMouseSettingsChanges()
	{
	
	}
	
	public override /*function */void OnChange()
	{
	
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUIScene_KeyMappings()
	{
		// Object Offset:0x0056D1D0
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_KeyMappings.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_KeyMappings.SceneEventComponent'*/;
	}
}
}
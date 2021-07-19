namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ControlsSettings : TdUIScene_OptionMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public String PCControllerImagePath;
	public String XBoxControllerImagePath;
	public String PS3ControllerImagePath;
	[transient] public UIPanel ControllerPanel;
	[transient] public array<UILabel> ControllerButtonLabels;
	[transient] public UILabel TitleLabel;
	[transient] public UIImage ControllerImage;
	[transient] public array<UIDataProvider_TdKeyBinding> KeyData;
	[transient] public array<Input.KeyBind> ControllerBinds;
	
	// Export UTdUIScene_ControlsSettings::execGetKeyBindingsData(FFrame&, void* const)
	public virtual /*native function */bool GetKeyBindingsData(ref array<UIDataProvider_TdKeyBinding> LabelData)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public override /*function */void InitWidgets()
	{
		// stub
	}
	
	public virtual /*private final function */void HideChild(name ChildName)
	{
		// stub
	}
	
	public override /*function */void ResetSettingsToDefault()
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
	
	public override /*function */void UpdateFocusLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState _PreviouslyActiveState = default)
	{
		// stub
	}
	
	public virtual /*function */void SetControllerButtonTags()
	{
		// stub
	}
	
	public virtual /*function */void SetControllerButtonLabel(String KeyName, String Str)
	{
		// stub
	}
	
	public TdUIScene_ControlsSettings()
	{
		var Default__TdUIScene_ControlsSettings_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ControlsSettings.SceneEventComponent' */;
		// Object Offset:0x005670D3
		PCControllerImagePath = "TdUIResources_Xbox.360Pad";
		XBoxControllerImagePath = "TdUIResources_Xbox.360Pad";
		PS3ControllerImagePath = "TdUIResources_PS3.PS3Pad";
		EventProvider = Default__TdUIScene_ControlsSettings_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ControlsSettings.SceneEventComponent'*/;
	}
}
}
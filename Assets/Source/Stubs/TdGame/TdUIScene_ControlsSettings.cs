namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ControlsSettings : TdUIScene_OptionMenu/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public String PCControllerImagePath;
	public String XBoxControllerImagePath;
	public String PS3ControllerImagePath;
	public /*transient */UIPanel ControllerPanel;
	public /*transient */array<UILabel> ControllerButtonLabels;
	public /*transient */UILabel TitleLabel;
	public /*transient */UIImage ControllerImage;
	public /*transient */array<UIDataProvider_TdKeyBinding> KeyData;
	public /*transient */array<Input.KeyBind> ControllerBinds;
	
	// Export UTdUIScene_ControlsSettings::execGetKeyBindingsData(FFrame&, void* const)
	public virtual /*native function */bool GetKeyBindingsData(ref array<UIDataProvider_TdKeyBinding> LabelData)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public override /*function */void InitWidgets()
	{
	
	}
	
	public virtual /*private final function */void HideChild(name ChildName)
	{
	
	}
	
	public override /*function */void ResetSettingsToDefault()
	{
	
	}
	
	public override /*function */void InitializeSettings()
	{
	
	}
	
	public override /*function */void OnOptionValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public override /*function */void UpdateFocusLabelState(UIScreenObject Sender, int PlayerIndex, UIState NewlyActiveState, /*optional */UIState? _PreviouslyActiveState = default)
	{
	
	}
	
	public virtual /*function */void SetControllerButtonTags()
	{
	
	}
	
	public virtual /*function */void SetControllerButtonLabel(String KeyName, String Str)
	{
	
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
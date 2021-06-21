namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIToggleButton : UILabelButton/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Data)*/ /*private */UIRoot.UIDataStoreBinding ValueDataSource;
	public/*(Value)*/ /*private */bool bIsChecked;
	public/*(Data)*/ /*noclear const export editinline */UIComp_DrawString CheckedStringRenderComponent;
	public/*(Image)*/ /*noclear const export editinline */UIComp_DrawImage CheckedBackgroundImageComponent;
	
	// Export UUIToggleButton::execSetCaption(FFrame&, void* const)
	public override /*native function */void SetCaption(String NewText)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*final function */bool IsChecked()
	{
		// stub
		return default;
	}
	
	// Export UUIToggleButton::execSetValue(FFrame&, void* const)
	public virtual /*native final function */void SetValue(bool bShouldBeChecked, /*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */bool ButtonClicked(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*final function */void OnSetBoolValue(UIAction_SetBoolValue Action)
	{
		// stub
	}
	
	public UIToggleButton()
	{
		var Default__UIToggleButton_CheckedLabelStringRenderer = new UIComp_DrawString
		{
			// Object Offset:0x005D200A
			StyleResolverTag = (name)"Caption Style (Checked)",
			StringStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultToggleButtonStyle",
			},
		}/* Reference: UIComp_DrawString'Default__UIToggleButton.CheckedLabelStringRenderer' */;
		var Default__UIToggleButton_CheckedBackgroundImageTemplate = new UIComp_DrawImage
		{
			// Object Offset:0x005D1E72
			StyleResolverTag = (name)"Background Image Style (Checked)",
			ImageStyle = new UIRoot.UIStyleReference
			{
				DefaultStyleTag = (name)"DefaultToggleButtonBackgroundStyle",
			},
		}/* Reference: UIComp_DrawImage'Default__UIToggleButton.CheckedBackgroundImageTemplate' */;
		var Default__UIToggleButton_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UIToggleButton.LabelStringRenderer' */;
		var Default__UIToggleButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIToggleButton.BackgroundImageTemplate' */;
		var Default__UIToggleButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIToggleButton.WidgetEventComponent' */;
		// Object Offset:0x00458B7D
		ValueDataSource = new UIRoot.UIDataStoreBinding
		{
			Subscriber = default,
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_Property,
			MarkupString = "",
			BindingIndex = -1,
			DataStoreName = (name)"None",
			DataStoreField = (name)"None",
			ResolvedDataStore = default,
		};
		CheckedStringRenderComponent = Default__UIToggleButton_CheckedLabelStringRenderer/*Ref UIComp_DrawString'Default__UIToggleButton.CheckedLabelStringRenderer'*/;
		CheckedBackgroundImageComponent = Default__UIToggleButton_CheckedBackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIToggleButton.CheckedBackgroundImageTemplate'*/;
		StringRenderComponent = Default__UIToggleButton_LabelStringRenderer/*Ref UIComp_DrawString'Default__UIToggleButton.LabelStringRenderer'*/;
		BackgroundImageComponent = Default__UIToggleButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIToggleButton.BackgroundImageTemplate'*/;
		__OnClicked__Delegate = (EventObject, PlayerIndex) => ButtonClicked(EventObject, PlayerIndex);
		EventProvider = Default__UIToggleButton_WidgetEventComponent/*Ref UIComp_Event'Default__UIToggleButton.WidgetEventComponent'*/;
	}
}
}
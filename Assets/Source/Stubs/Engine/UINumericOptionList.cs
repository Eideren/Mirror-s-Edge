namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UINumericOptionList : UIOptionListBase/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Data)*/ UIRoot.UIRangeData RangeValue;
	
	// Export UUINumericOptionList::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UUINumericOptionList::execGetValue(FFrame&, void* const)
	public virtual /*native final function */float GetValue(/*optional */bool? _bPercentageValue = default)
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public UINumericOptionList()
	{
		var Default__UINumericOptionList_DecrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UINumericOptionList_DecrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent' */;
		var Default__UINumericOptionList_DecrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x005D3542
			BackgroundImageComponent = Default__UINumericOptionList_DecrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = Default__UINumericOptionList_DecrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UINumericOptionList.DecrementButtonTemplate' */;
		var Default__UINumericOptionList_IncrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UINumericOptionList_IncrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent' */;
		var Default__UINumericOptionList_IncrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x005D3586
			BackgroundImageComponent = Default__UINumericOptionList_IncrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = Default__UINumericOptionList_IncrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UINumericOptionList.IncrementButtonTemplate' */;
		var Default__UINumericOptionList_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UINumericOptionList.BackgroundImageTemplate' */;
		var Default__UINumericOptionList_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UINumericOptionList.LabelStringRenderer' */;
		var Default__UINumericOptionList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UINumericOptionList.WidgetEventComponent' */;
		// Object Offset:0x00447635
		RangeValue = new UIRoot.UIRangeData
		{
			CurrentValue = 0.0f,
			MinValue = 0.0f,
			MaxValue = 0.0f,
			NudgeValue = 1.0f,
			bIntRange = false,
		};
		DecrementButton = Default__UINumericOptionList_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UINumericOptionList.DecrementButtonTemplate'*/;
		IncrementButton = Default__UINumericOptionList_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UINumericOptionList.IncrementButtonTemplate'*/;
		BackgroundImageComponent = Default__UINumericOptionList_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UINumericOptionList.BackgroundImageTemplate'*/;
		StringRenderComponent = Default__UINumericOptionList_LabelStringRenderer/*Ref UIComp_DrawString'Default__UINumericOptionList.LabelStringRenderer'*/;
		DataSource = new UIRoot.UIDataStoreBinding
		{
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_RangeProperty,
		};
		Children = new array<UIObject>
		{
			Default__UINumericOptionList_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UINumericOptionList.DecrementButtonTemplate'*/,
			Default__UINumericOptionList_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UINumericOptionList.IncrementButtonTemplate'*/,
		};
		EventProvider = Default__UINumericOptionList_WidgetEventComponent/*Ref UIComp_Event'Default__UINumericOptionList.WidgetEventComponent'*/;
	}
}
}
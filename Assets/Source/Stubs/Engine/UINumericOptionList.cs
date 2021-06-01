namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UINumericOptionList : UIOptionListBase/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public/*(Data)*/ UIRoot.UIRangeData RangeValue;
	
	// Export UUINumericOptionList::execSetValue(FFrame&, void* const)
	public virtual /*native final function */bool SetValue(/*coerce */float NewValue, /*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUINumericOptionList::execGetValue(FFrame&, void* const)
	public virtual /*native final function */float GetValue(/*optional */bool? _bPercentageValue = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public UINumericOptionList()
	{
		// Object Offset:0x00447635
		RangeValue = new UIRoot.UIRangeData
		{
			CurrentValue = 0.0f,
			MinValue = 0.0f,
			MaxValue = 0.0f,
			NudgeValue = 1.0f,
			bIntRange = false,
		};
		DecrementButton = new UIOptionListButton
		{
			// Object Offset:0x005D3542
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = LoadAsset<UIComp_Event>("Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UINumericOptionList.DecrementButtonTemplate' */;
		IncrementButton = new UIOptionListButton
		{
			// Object Offset:0x005D3586
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = LoadAsset<UIComp_Event>("Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UINumericOptionList.IncrementButtonTemplate' */;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericOptionList.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericOptionList.BackgroundImageTemplate'*/;
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__UINumericOptionList.LabelStringRenderer")/*Ref UIComp_DrawString'Default__UINumericOptionList.LabelStringRenderer'*/;
		DataSource = new UIRoot.UIDataStoreBinding
		{
			RequiredFieldType = UIRoot.EUIDataProviderFieldType.DATATYPE_RangeProperty,
		};
		Children = new array<UIObject>
		{
			new UIOptionListButton
			{
				// Object Offset:0x005D3542
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
			}/* Reference: UIOptionListButton'Default__UINumericOptionList.DecrementButtonTemplate' */,
			new UIOptionListButton
			{
				// Object Offset:0x005D3586
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UINumericOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
			}/* Reference: UIOptionListButton'Default__UINumericOptionList.IncrementButtonTemplate' */,
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__UINumericOptionList.WidgetEventComponent")/*Ref UIComp_Event'Default__UINumericOptionList.WidgetEventComponent'*/;
	}
}
}
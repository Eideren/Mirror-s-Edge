namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIOptionList : UIOptionListBase/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */int CurrentIndex;
	public /*const transient */UIListElementProvider DataProvider;
	
	// Export UUIOptionList::execGetListValue(FFrame&, void* const)
	public virtual /*native final function */bool GetListValue(int ListIndex, ref String OutValue)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIOptionList::execSetPrevValue(FFrame&, void* const)
	public virtual /*native function */void SetPrevValue()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIOptionList::execSetNextValue(FFrame&, void* const)
	public virtual /*native function */void SetNextValue()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UUIOptionList::execGetCurrentIndex(FFrame&, void* const)
	public virtual /*native function */int GetCurrentIndex()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UUIOptionList::execSetCurrentIndex(FFrame&, void* const)
	public virtual /*native function */void SetCurrentIndex(int NewIndex)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*protected final function */void OnSetListIndex(UIAction_SetListIndex Action)
	{
	
	}
	
	public UIOptionList()
	{
		var Default__UIOptionList_DecrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UIOptionList_DecrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent' */;
		var Default__UIOptionList_DecrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x005D35CA
			BackgroundImageComponent = Default__UIOptionList_DecrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = Default__UIOptionList_DecrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionList.DecrementButtonTemplate' */;
		var Default__UIOptionList_IncrementButtonTemplate_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate' */;
		var Default__UIOptionList_IncrementButtonTemplate_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent' */;
		var Default__UIOptionList_IncrementButtonTemplate = new UIOptionListButton
		{
			// Object Offset:0x005D360E
			BackgroundImageComponent = Default__UIOptionList_IncrementButtonTemplate_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = Default__UIOptionList_IncrementButtonTemplate_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionList.IncrementButtonTemplate' */;
		var Default__UIOptionList_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionList.BackgroundImageTemplate' */;
		var Default__UIOptionList_LabelStringRenderer = new UIComp_DrawString
		{
		}/* Reference: UIComp_DrawString'Default__UIOptionList.LabelStringRenderer' */;
		var Default__UIOptionList_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionList.WidgetEventComponent' */;
		// Object Offset:0x00447C2A
		DecrementButton = Default__UIOptionList_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionList.DecrementButtonTemplate'*/;
		IncrementButton = Default__UIOptionList_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionList.IncrementButtonTemplate'*/;
		BackgroundImageComponent = Default__UIOptionList_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionList.BackgroundImageTemplate'*/;
		StringRenderComponent = Default__UIOptionList_LabelStringRenderer/*Ref UIComp_DrawString'Default__UIOptionList.LabelStringRenderer'*/;
		Children = new array<UIObject>
		{
			Default__UIOptionList_DecrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionList.DecrementButtonTemplate'*/,
			Default__UIOptionList_IncrementButtonTemplate/*Ref UIOptionListButton'Default__UIOptionList.IncrementButtonTemplate'*/,
		};
		EventProvider = Default__UIOptionList_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionList.WidgetEventComponent'*/;
	}
}
}
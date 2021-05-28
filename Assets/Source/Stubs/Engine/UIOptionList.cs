namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIOptionList : UIOptionListBase/*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */int CurrentIndex;
	public /*const transient */UIListElementProvider DataProvider;
	
	// Export UUIOptionList::execGetListValue(FFrame&, void* const)
	public virtual /*native final function */bool GetListValue(int ListIndex, ref string OutValue)
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
		// Object Offset:0x00447C2A
		DecrementButton = new UIOptionListButton
		{
			// Object Offset:0x005D35CA
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionList.DecrementButtonTemplate' */;
		IncrementButton = new UIOptionListButton
		{
			// Object Offset:0x005D360E
			BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
			EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
		}/* Reference: UIOptionListButton'Default__UIOptionList.IncrementButtonTemplate' */;
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionList.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionList.BackgroundImageTemplate'*/;
		StringRenderComponent = LoadAsset<UIComp_DrawString>("Default__UIOptionList.LabelStringRenderer")/*Ref UIComp_DrawString'Default__UIOptionList.LabelStringRenderer'*/;
		Children = new array<UIObject>
		{
			//Children[0]=
			new UIOptionListButton
			{
				// Object Offset:0x005D35CA
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionList.DecrementButtonTemplate.BackgroundImageTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionList.DecrementButtonTemplate.WidgetEventComponent'*/,
			}/* Reference: UIOptionListButton'Default__UIOptionList.DecrementButtonTemplate' */,
			//Children[1]=
			new UIOptionListButton
			{
				// Object Offset:0x005D360E
				BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionList.IncrementButtonTemplate.BackgroundImageTemplate'*/,
				EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionList.IncrementButtonTemplate.WidgetEventComponent'*/,
			}/* Reference: UIOptionListButton'Default__UIOptionList.IncrementButtonTemplate' */,
		};
		EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionList.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionList.WidgetEventComponent'*/;
	}
}
}
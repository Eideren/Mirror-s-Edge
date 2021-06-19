namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIOptionListButton : UIButton/* within UIOptionListBase*//*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public new UIOptionListBase Outer => base.Outer as UIOptionListBase;
	
	// Export UUIOptionListButton::execUpdateButtonState(FFrame&, void* const)
	public virtual /*native final function */void UpdateButtonState(/*optional */int? _PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public UIOptionListButton()
	{
		var Default__UIOptionListButton_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__UIOptionListButton.BackgroundImageTemplate' */;
		var Default__UIOptionListButton_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UIOptionListButton.WidgetEventComponent' */;
		// Object Offset:0x00445AFC
		BackgroundImageComponent = Default__UIOptionListButton_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__UIOptionListButton.BackgroundImageTemplate'*/;
		PrivateFlags = 111;
		EventProvider = Default__UIOptionListButton_WidgetEventComponent/*Ref UIComp_Event'Default__UIOptionListButton.WidgetEventComponent'*/;
	}
}
}
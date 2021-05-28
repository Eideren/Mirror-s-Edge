namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIOptionListButton : UIButton/* within UIOptionListBase*//*
		native
		hidecategories(Object,UIRoot,Object)*/{
	public new UIOptionListBase Outer => base.Outer as UIOptionListBase;
	
	// Export UUIOptionListButton::execUpdateButtonState(FFrame&, void* const)
	public virtual /*native final function */void UpdateButtonState(/*optional */int PlayerIndex = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public UIOptionListButton()
	{
		// Object Offset:0x00445AFC
		BackgroundImageComponent = LoadAsset<UIComp_DrawImage>("Default__UIOptionListButton.BackgroundImageTemplate")/*Ref UIComp_DrawImage'Default__UIOptionListButton.BackgroundImageTemplate'*/;
		PrivateFlags = 111;
		EventProvider = LoadAsset<UIComp_Event>("Default__UIOptionListButton.WidgetEventComponent")/*Ref UIComp_Event'Default__UIOptionListButton.WidgetEventComponent'*/;
	}
}
}
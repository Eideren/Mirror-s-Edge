namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage : UITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public virtual /*event */void Activated()
	{
	
	}
	
	public virtual /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
	
		return default;
	}
	
	public TdUITabPage()
	{
		// Object Offset:0x006B7C29
		ButtonClass = ClassT<TdUITabButton>()/*Ref Class'TdUITabButton'*/;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabPage.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabPage.WidgetEventComponent'*/;
	}
}
}
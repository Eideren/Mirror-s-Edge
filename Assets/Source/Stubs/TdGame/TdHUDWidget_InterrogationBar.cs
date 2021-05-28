namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_InterrogationBar : TdHUDWidget_ProgressBar/*
		hidecategories(Object,UIRoot,Object)*/{
	public TdHUDWidget_InterrogationBar()
	{
		// Object Offset:0x00577A8C
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_InterrogationBar.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_InterrogationBar.WidgetEventComponent'*/;
	}
}
}
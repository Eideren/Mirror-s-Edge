namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_Health : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel healthLabel;
	
	public TdHUDWidget_Health()
	{
		// Object Offset:0x005777F2
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_Health.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_Health.WidgetEventComponent'*/;
	}
}
}
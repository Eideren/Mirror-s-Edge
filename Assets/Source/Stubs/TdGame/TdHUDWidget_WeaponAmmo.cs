namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDWidget_WeaponAmmo : TdHUDWidget/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*export editinline deprecated */UILabel ammoLabel;
	
	public TdHUDWidget_WeaponAmmo()
	{
		// Object Offset:0x0057811F
		requiresTick = true;
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDWidget_WeaponAmmo.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDWidget_WeaponAmmo.WidgetEventComponent'*/;
	}
}
}
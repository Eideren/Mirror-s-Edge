namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHUDObject : TdUIObject/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	// Export UTdHUDObject::execGetHud(FFrame&, void* const)
	public virtual /*native function */HUD GetHud()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdHUDObject()
	{
		// Object Offset:0x0057664B
		EventProvider = LoadAsset<UIComp_Event>("Default__TdHUDObject.WidgetEventComponent")/*Ref UIComp_Event'Default__TdHUDObject.WidgetEventComponent'*/;
	}
}
}
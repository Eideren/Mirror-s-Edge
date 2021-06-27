namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_SupersMessage : TdUIScene/*
		native
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel SupersLabel;
	public /*transient */float Duration;
	
	public virtual /*function */void SetupSupersMessage(String Text, float TextDuration)
	{
		// stub
	}
	
	public TdUIScene_SupersMessage()
	{
		var Default__TdUIScene_SupersMessage_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_SupersMessage.SceneEventComponent' */;
		// Object Offset:0x005621D4
		EventProvider = Default__TdUIScene_SupersMessage_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_SupersMessage.SceneEventComponent'*/;
	}
}
}
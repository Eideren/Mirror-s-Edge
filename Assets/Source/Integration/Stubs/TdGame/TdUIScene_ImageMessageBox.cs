namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ImageMessageBox : TdUIScene_MessageBox/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIImage Image;
	
	public virtual /*function */void SetImage(Surface InImage)
	{
		// stub
	}
	
	public virtual /*function */void SetImageMarkup(String Markup)
	{
		// stub
	}
	
	public TdUIScene_ImageMessageBox()
	{
		var Default__TdUIScene_ImageMessageBox_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ImageMessageBox.SceneEventComponent' */;
		// Object Offset:0x00561FFA
		EventProvider = Default__TdUIScene_ImageMessageBox_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ImageMessageBox.SceneEventComponent'*/;
	}
}
}
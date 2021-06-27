namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_ObjectivesScene : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */TdUITabControl TabControl;
	public /*transient */UILabel TitleLabel;
	public /*transient */UIImage CurrentObjectiveBGImage;
	public /*transient */UIImage CurrentObjectiveBGTopImage;
	public /*transient */UIImage FinishedObjectivesBGImage;
	public /*transient */UIImage FinishedObjectivesBGTopImage;
	public UIDataStore_TdGameObjectivesData TdGameObjectives;
	public/*()*/ name ObjectivesToReadFieldName;
	public/*()*/ name FinishedObjectivesToReadFieldName;
	public /*transient */bool bObjectiveListIsEmpty;
	
	public override /*event */void Initialized()
	{
		// stub
	}
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnTabPageActivated(UITabControl Sender, UITabPage NewlyActivePage, int PlayerIndex)
	{
		// stub
	}
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Cancel(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnCloseScene()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_ObjectivesScene()
	{
		var Default__TdUIScene_ObjectivesScene_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_ObjectivesScene.SceneEventComponent' */;
		// Object Offset:0x0068F2B2
		EventProvider = Default__TdUIScene_ObjectivesScene_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_ObjectivesScene.SceneEventComponent'*/;
	}
}
}
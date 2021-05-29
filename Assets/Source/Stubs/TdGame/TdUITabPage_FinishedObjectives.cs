namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_FinishedObjectives : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UIList FinishedObjectivesList;
	public /*transient */UILabel DescriptionLabel;
	public /*transient */UILabel NoFinishedObjectivesLabel;
	public UIDataStore_TdGameObjectivesData TdGameObjectivesData;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void OnFinishedObjectivesList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
	
	}
	
	public virtual /*function */void UpdateDescription()
	{
	
	}
	
	public virtual /*function */void FinishedObjectivesList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
	
	}
	
	public TdUITabPage_FinishedObjectives()
	{
		// Object Offset:0x006B8943
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUITabPage_FinishedObjectives.WidgetEventComponent")/*Ref UIComp_Event'Default__TdUITabPage_FinishedObjectives.WidgetEventComponent'*/;
	}
}
}
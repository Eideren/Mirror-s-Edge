namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_FinishedObjectives : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	[transient] public UIList FinishedObjectivesList;
	[transient] public UILabel DescriptionLabel;
	[transient] public UILabel NoFinishedObjectivesLabel;
	public UIDataStore_TdGameObjectivesData TdGameObjectivesData;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void OnFinishedObjectivesList_ValueChanged(UIObject Sender, int PlayerIndex)
	{
		// stub
	}
	
	public virtual /*function */void UpdateDescription()
	{
		// stub
	}
	
	public virtual /*function */void FinishedObjectivesList_OnSubmitSelection(UIList Sender, /*optional */int? _PlayerIndex = default)
	{
		// stub
	}
	
	public TdUITabPage_FinishedObjectives()
	{
		var Default__TdUITabPage_FinishedObjectives_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabPage_FinishedObjectives.WidgetEventComponent' */;
		// Object Offset:0x006B8943
		EventProvider = Default__TdUITabPage_FinishedObjectives_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabPage_FinishedObjectives.WidgetEventComponent'*/;
	}
}
}
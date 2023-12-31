namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUITabPage_CurrentObjective : TdUITabPage/*
		hidecategories(Object,UIRoot,Object)*/{
	public const int MAX_NUM_SUB_OBJECTIVES = 4;
	
	public partial struct SubObjectivesWidgetCol
	{
		[transient] public UILabel Label;
		[transient] public UIImage Image;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x006B7D84
	//		Label = default;
	//		Image = default;
	//	}
	};
	
	[transient] public UILabel MapNameLabel;
	[transient] public UILabel CurrentObjectiveLabel;
	[transient] public UIImage CurrentObjectiveImage;
	[transient] public UILabel CurrentObjectiveDescriptionLabel;
	[transient] public StaticArray<TdUITabPage_CurrentObjective.SubObjectivesWidgetCol, TdUITabPage_CurrentObjective.SubObjectivesWidgetCol, TdUITabPage_CurrentObjective.SubObjectivesWidgetCol, TdUITabPage_CurrentObjective.SubObjectivesWidgetCol>/*[4]*/ SubObjectivesWidgets;
	[transient] public TdUITabControl OwnerTabControl;
	public UIDataStore_TdGameObjectivesData TdGameObjectivesData;
	
	public override /*event */void PostInitialize()
	{
		// stub
	}
	
	public virtual /*function */void LinkSceneWidgets()
	{
		// stub
	}
	
	public virtual /*function */void ReadSubObjectiveData()
	{
		// stub
	}
	
	public TdUITabPage_CurrentObjective()
	{
		var Default__TdUITabPage_CurrentObjective_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUITabPage_CurrentObjective.WidgetEventComponent' */;
		// Object Offset:0x006B845D
		EventProvider = Default__TdUITabPage_CurrentObjective_WidgetEventComponent/*Ref UIComp_Event'Default__TdUITabPage_CurrentObjective.WidgetEventComponent'*/;
	}
}
}
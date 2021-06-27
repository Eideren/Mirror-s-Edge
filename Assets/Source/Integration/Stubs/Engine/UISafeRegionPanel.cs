namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UISafeRegionPanel : UIContainer/*
		native
		config(Game)
		hidecategories(Object,UIRoot,Object)*/{
	public enum ESafeRegionType 
	{
		ESRT_FullRegion,
		ESRT_TextSafeRegion,
		ESRT_MAX
	};
	
	public/*(Safe)*/ UISafeRegionPanel.ESafeRegionType RegionType;
	public/*(Safe)*/ /*editinline config */array</*editinline config */float> RegionPercentages;
	public/*(Safe)*/ bool bForce4x3AspectRatio;
	public/*(Safe)*/ bool bUseFullRegionIn4x3;
	public/*(Safe)*/ bool bForce16x9AspectRatio;
	
	public UISafeRegionPanel()
	{
		var Default__UISafeRegionPanel_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__UISafeRegionPanel.WidgetEventComponent' */;
		// Object Offset:0x0044C27B
		RegionPercentages = new array</*editinline config */float>
		{
			0.850f,
			0.80f,
		};
		EventProvider = Default__UISafeRegionPanel_WidgetEventComponent/*Ref UIComp_Event'Default__UISafeRegionPanel.WidgetEventComponent'*/;
	}
}
}
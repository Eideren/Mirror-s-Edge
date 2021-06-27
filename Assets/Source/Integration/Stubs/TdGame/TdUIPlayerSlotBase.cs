namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIPlayerSlotBase : UIButton/*
		abstract
		native
		hidecategories(Object,UIRoot,Object)*/{
	public TdUIPlayerSlotBase()
	{
		var Default__TdUIPlayerSlotBase_BackgroundImageTemplate = new UIComp_DrawImage
		{
		}/* Reference: UIComp_DrawImage'Default__TdUIPlayerSlotBase.BackgroundImageTemplate' */;
		var Default__TdUIPlayerSlotBase_WidgetEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIPlayerSlotBase.WidgetEventComponent' */;
		// Object Offset:0x0068C442
		BackgroundImageComponent = Default__TdUIPlayerSlotBase_BackgroundImageTemplate/*Ref UIComp_DrawImage'Default__TdUIPlayerSlotBase.BackgroundImageTemplate'*/;
		Position = new UIRoot.UIScreenValue_Bounds
		{
			Value = new StaticArray<float, float, float, float>/*[UIRoot.EUIWidgetFace.UIFACE_MAX]*/()
			{
				[2] = 0.20f,
				[3] = 0.50f,
				#warning index access seems to hint that the collection is not wholly assigned to, this should probably be changed to assigning to specific indices on the existing collection instead of assigning a whole new collection
			},
		};
		EventProvider = Default__TdUIPlayerSlotBase_WidgetEventComponent/*Ref UIComp_Event'Default__TdUIPlayerSlotBase.WidgetEventComponent'*/;
	}
}
}
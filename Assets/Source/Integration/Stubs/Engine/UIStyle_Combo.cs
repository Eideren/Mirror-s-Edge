namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStyle_Combo : UIStyle_Data/*
		native
		hidecategories(Object,UIRoot)*/{
	public partial struct /*native */StyleDataReference
	{
		public /*private */UIStyle OwnerStyle;
		public /*private */UIRoot.STYLE_ID SourceStyleID;
		public /*private transient */UIStyle SourceStyle;
		public /*private */UIState SourceState;
		public /*private */UIStyle_Data CustomStyleData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00452B4A
	//		OwnerStyle = default;
	//		SourceStyleID = new UIRoot.STYLE_ID
	//		{
	//			A = 0,
	//			B = 0,
	//			C = 0,
	//			D = 0,
	//		};
	//		SourceStyle = default;
	//		SourceState = default;
	//		CustomStyleData = default;
	//	}
	};
	
	public UIStyle_Combo.StyleDataReference ImageStyle;
	public UIStyle_Combo.StyleDataReference TextStyle;
	
	public UIStyle_Combo()
	{
		// Object Offset:0x00452CEA
		UIEditorControlClass = "WxStyleComboPropertiesGroup";
	}
}
}
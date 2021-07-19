namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdResetToDefault : UIAction/*
		native
		hidecategories(Object)*/{
	public enum ETdOptionGroup 
	{
		TDOG_AudioVideo,
		TDOG_Controls,
		TDOG_MAX
	};
	
	[Category] public UIAction_TdResetToDefault.ETdOptionGroup OptionGroup;
	
	public UIAction_TdResetToDefault()
	{
		// Object Offset:0x006D6173
		ObjName = "TdResetToDefaults";
		ObjCategory = "Takedown";
	}
}
}
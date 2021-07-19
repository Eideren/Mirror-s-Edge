namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_MultiLevelStreaming : SeqAct_LevelStreamingBase/*
		native
		hidecategories(Object)*/{
	public partial struct /*native */LevelStreamingNameCombo
	{
		[Const] public LevelStreaming Level;
		[Category] [Const] public name LevelName;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003C87F1
	//		Level = default;
	//		LevelName = (name)"None";
	//	}
	};
	
	[Category] public array<SeqAct_MultiLevelStreaming.LevelStreamingNameCombo> Levels;
	[Category] public bool bUnloadAllOtherLevels;
	[transient] public bool bStatusIsOk;
	[transient] public bool bUnloading;
	
	public SeqAct_MultiLevelStreaming()
	{
		// Object Offset:0x003C8919
		ObjName = "Stream Multiple Levels";
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_LevelStreaming : SeqAct_LevelStreamingBase/*
		native
		hidecategories(Object)*/{
	public/*()*/ /*const */LevelStreaming Level;
	public/*()*/ /*const */name LevelName;
	public /*transient */bool bStatusIsOk;
	
	public SeqAct_LevelStreaming()
	{
		// Object Offset:0x003C67D4
		ObjName = "Stream Level";
		bSuppressAutoComment = false;
	}
}
}
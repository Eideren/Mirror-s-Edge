namespace MEdge.GameFramework{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_DisplayChapterTitleBase : SequenceAction/*
		abstract
		hidecategories(Object)*/{
	[Category] public float TotalDisplayTime;
	[Category] public float TotalFadeTime;
	
	public SeqAct_DisplayChapterTitleBase()
	{
		// Object Offset:0x0000869F
		TotalDisplayTime = 6.0f;
		TotalFadeTime = 2.0f;
		bCallHandler = false;
		VariableLinks = default;
		ObjClassVersion = 2;
		ObjName = "Display Chapter Title";
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeCoverDirection : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	[Category] [editoronly, transient] public array<TdAIAnimationController.ECoverDirectionState> EnumStates;
	
	public override /*event */void OnInit()
	{
		// stub
	}
	
	public override /*event */void OverrideStateMapping()
	{
		// stub
	}
	
	public TdAnimNodeCoverDirection()
	{
		// Object Offset:0x00500E87
		EnumStringName = "ECoverDirectionState";
	}
}
}
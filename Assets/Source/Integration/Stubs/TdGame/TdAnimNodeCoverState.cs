namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeCoverState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	[Category] [editoronly, transient] public array<TdAIAnimationController.ECoverState> EnumStates;
	
	public override /*event */void OnInit()
	{
		// stub
	}
	
	public override /*event */void OverrideStateMapping()
	{
		// stub
	}
	
	public TdAnimNodeCoverState()
	{
		// Object Offset:0x005010E9
		EnumStringName = "ECoverState";
	}
}
}
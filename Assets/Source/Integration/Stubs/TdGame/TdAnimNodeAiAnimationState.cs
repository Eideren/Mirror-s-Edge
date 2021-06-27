namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeAiAnimationState : TdAnimNodeState/*
		native
		hidecategories(Object,Object,Object)*/{
	public/*()*/ /*editoronly transient */array<TdAIAnimationController.EAiAnimationState> EnumStates;
	
	public override /*event */void OnInit()
	{
		// stub
	}
	
	public override /*event */void OverrideStateMapping()
	{
		// stub
	}
	
	public TdAnimNodeAiAnimationState()
	{
		// Object Offset:0x004FC3E3
		EnumStringName = "EAiAnimationState";
	}
}
}
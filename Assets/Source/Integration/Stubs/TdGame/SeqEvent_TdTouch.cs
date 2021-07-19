namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqEvent_TdTouch : SeqEvent_Touch/*
		native
		hidecategories(Object)*/{
	[Category] public float Momentum;
	
	public virtual /*event */bool ShouldActivate(Actor InOriginator, Actor InInstigator)
	{
		// stub
		return default;
	}
	
	public SeqEvent_TdTouch()
	{
		// Object Offset:0x004A6F4C
		ObjName = "TdTouch";
	}
}
}
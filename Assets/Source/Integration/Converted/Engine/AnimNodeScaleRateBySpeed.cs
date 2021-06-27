namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeScaleRateBySpeed : AnimNodeScalePlayRate/*
		native
		hidecategories(Object,Object,Object,Object)*/{
	public/*()*/ float BaseSpeed;
	
	public AnimNodeScaleRateBySpeed()
	{
		// Object Offset:0x0029CFB7
		BaseSpeed = 350.0f;
	}
}
}
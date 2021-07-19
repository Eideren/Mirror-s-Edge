namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DOFAndBloomEffect : DOFEffect/*
		native
		hidecategories(Object)*/{
	[Category] public float BloomScale;
	
	public DOFAndBloomEffect()
	{
		// Object Offset:0x0030F38F
		BloomScale = 1.0f;
		BlurKernelSize = 16.0f;
	}
}
}
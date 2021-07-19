namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIBlurEffect : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	[Category] public float FalloffExponent;
	[Category] public float BlurKernelSize;
	[Category] public float BlurAmount;
	
	public TdUIBlurEffect()
	{
		// Object Offset:0x006807A2
		FalloffExponent = 2.0f;
		BlurKernelSize = 16.0f;
	}
}
}
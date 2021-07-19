namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureReflectComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	[Category("Capture")] public TextureRenderTarget2D TextureTarget;
	[Category("Capture")] public float ScaleFOV;
	[Category("Capture")] public float FarCullingDistance;
	[Category("Capture")] public bool bLiteReflection;
	
	public SceneCaptureReflectComponent()
	{
		// Object Offset:0x003A347C
		ScaleFOV = 1.0f;
		FarCullingDistance = 10000.0f;
		FrameRate = 1000.0f;
	}
}
}
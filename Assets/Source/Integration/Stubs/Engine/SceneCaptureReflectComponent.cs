namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureReflectComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	public/*(Capture)*/ TextureRenderTarget2D TextureTarget;
	public/*(Capture)*/ float ScaleFOV;
	public/*(Capture)*/ float FarCullingDistance;
	public/*(Capture)*/ bool bLiteReflection;
	
	public SceneCaptureReflectComponent()
	{
		// Object Offset:0x003A347C
		ScaleFOV = 1.0f;
		FarCullingDistance = 10000.0f;
		FrameRate = 1000.0f;
	}
}
}
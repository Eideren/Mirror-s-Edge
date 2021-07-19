namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCapturePortalComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	[Category("Capture")] [Const] public TextureRenderTarget2D TextureTarget;
	[Category("Capture")] [Const] public float ScaleFOV;
	[Category("Capture")] [Const] public Actor ViewDestination;
	
	// Export USceneCapturePortalComponent::execSetCaptureParameters(FFrame&, void* const)
	public virtual /*native final function */void SetCaptureParameters(/*optional */TextureRenderTarget2D _NewTextureTarget = default, /*optional */float? _NewScaleFOV = default, /*optional */Actor _NewViewDest = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public SceneCapturePortalComponent()
	{
		// Object Offset:0x003A38B2
		ScaleFOV = 1.0f;
		bSkipUpdateIfOwnerOccluded = true;
		FrameRate = 1000.0f;
	}
}
}
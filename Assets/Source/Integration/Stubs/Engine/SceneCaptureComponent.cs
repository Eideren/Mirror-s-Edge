namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureComponent : ActorComponent/*
		abstract
		native
		hidecategories(Object)*/{
	public enum ESceneCaptureViewMode 
	{
		SceneCapView_Lit,
		SceneCapView_Unlit,
		SceneCapView_LitNoShadows,
		SceneCapView_Wire,
		SceneCapView_MAX
	};
	
	[Category("Capture")] public bool bEnablePostProcess;
	[Category("Capture")] public bool bEnableFog;
	public bool bSkipUpdateIfOwnerOccluded;
	[native, Const, transient] public/*private*/ bool bNeedsSceneUpdate;
	[Category("Capture")] public Object.Color ClearColor;
	[Category("Capture")] public SceneCaptureComponent.ESceneCaptureViewMode ViewMode;
	[Category("Capture")] public int SceneLOD;
	[Category("Capture")] [Const] public float FrameRate;
	[Category("Capture")] public PostProcessChain PostProcess;
	[Category("Capture")] public float MaxUpdateDist;
	[Category("Capture")] public float MaxStreamingUpdateDist;
	[native, Const, transient] public/*private*/ Object.Pointer CaptureInfo;
	[native, Const, transient] public/*private*/ Object.Pointer ViewState;
	
	// Export USceneCaptureComponent::execSetFrameRate(FFrame&, void* const)
	public virtual /*native final function */void SetFrameRate(float NewFrameRate)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public SceneCaptureComponent()
	{
		// Object Offset:0x0038C5FF
		ClearColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		ViewMode = SceneCaptureComponent.ESceneCaptureViewMode.SceneCapView_LitNoShadows;
		FrameRate = 30.0f;
	}
}
}
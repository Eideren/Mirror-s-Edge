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
	
	public/*(Capture)*/ bool bEnablePostProcess;
	public/*(Capture)*/ bool bEnableFog;
	public bool bSkipUpdateIfOwnerOccluded;
	public /*private native const transient */bool bNeedsSceneUpdate;
	public/*(Capture)*/ Object.Color ClearColor;
	public/*(Capture)*/ SceneCaptureComponent.ESceneCaptureViewMode ViewMode;
	public/*(Capture)*/ int SceneLOD;
	public/*(Capture)*/ /*const */float FrameRate;
	public/*(Capture)*/ PostProcessChain PostProcess;
	public/*(Capture)*/ float MaxUpdateDist;
	public/*(Capture)*/ float MaxStreamingUpdateDist;
	public /*private native const transient */Object.Pointer CaptureInfo;
	public /*private native const transient */Object.Pointer ViewState;
	
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
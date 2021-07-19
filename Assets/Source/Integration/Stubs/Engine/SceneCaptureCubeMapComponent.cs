namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureCubeMapComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	[Category("Capture")] public TextureRenderTargetCube TextureTarget;
	[Category("Capture")] public float NearPlane;
	[Category("Capture")] public float FarPlane;
	[Category("Capture")] public bool bTdSpecialCubeMapLayout;
	[native, Const, transient] public/*private*/ Object.Vector WorldLocation;
	
	public SceneCaptureCubeMapComponent()
	{
		// Object Offset:0x003B24CC
		NearPlane = 20.0f;
		FarPlane = 500.0f;
	}
}
}
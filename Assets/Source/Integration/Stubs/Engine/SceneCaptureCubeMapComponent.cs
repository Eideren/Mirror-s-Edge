namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCaptureCubeMapComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	public/*(Capture)*/ TextureRenderTargetCube TextureTarget;
	public/*(Capture)*/ float NearPlane;
	public/*(Capture)*/ float FarPlane;
	public/*(Capture)*/ bool bTdSpecialCubeMapLayout;
	public /*private native const transient */Object.Vector WorldLocation;
	
	public SceneCaptureCubeMapComponent()
	{
		// Object Offset:0x003B24CC
		NearPlane = 20.0f;
		FarPlane = 500.0f;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SceneCapture2DComponent : SceneCaptureComponent/*
		native
		hidecategories(Object)*/{
	public/*(Capture)*/ /*const */TextureRenderTarget2D TextureTarget;
	public/*(Capture)*/ /*const */float FieldOfView;
	public/*(Capture)*/ /*const */float NearPlane;
	public/*(Capture)*/ /*const */float FarPlane;
	public bool bUpdateMatrices;
	public /*const transient */Object.Matrix ViewMatrix;
	public /*const transient */Object.Matrix ProjMatrix;
	
	// Export USceneCapture2DComponent::execSetCaptureParameters(FFrame&, void* const)
	public virtual /*native final function */void SetCaptureParameters(/*optional */TextureRenderTarget2D? _NewTextureTarget = default, /*optional */float? _NewFOV = default, /*optional */float? _NewNearPlane = default, /*optional */float? _NewFarPlane = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USceneCapture2DComponent::execSetView(FFrame&, void* const)
	public virtual /*native final function */void SetView(Object.Vector NewLocation, Object.Rotator NewRotation)
	{
		#warning NATIVE FUNCTION !
	}
	
	public SceneCapture2DComponent()
	{
		// Object Offset:0x003B20FE
		FieldOfView = 80.0f;
		NearPlane = 20.0f;
		FarPlane = 500.0f;
		bUpdateMatrices = true;
		ViewMatrix = new Matrix
		{
			XPlane={X=0.0f,
			Y=1.0f,
			Z=0.0f,
			W=0.0f},
			YPlane={X=0.0f,
			Y=0.0f,
			Z=1.0f,
			W=0.0f},
			ZPlane={X=0.0f,
			Y=0.0f,
			Z=0.0f,
			W=1.0f},
			WPlane={X=1.0f,
			Y=0.0f,
			Z=0.0f,
			W=0.0f}
		};
		ProjMatrix = new Matrix
		{
			XPlane={X=0.0f,
			Y=1.0f,
			Z=0.0f,
			W=0.0f},
			YPlane={X=0.0f,
			Y=0.0f,
			Z=1.0f,
			W=0.0f},
			ZPlane={X=0.0f,
			Y=0.0f,
			Z=0.0f,
			W=1.0f},
			WPlane={X=1.0f,
			Y=0.0f,
			Z=0.0f,
			W=0.0f}
		};
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimatedCamera : Camera/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public const int MAX_ACTIVE_CAMERA_ANIMS = 8;
	
	public /*protected */StaticArray<CameraAnimInst, CameraAnimInst, CameraAnimInst, CameraAnimInst, CameraAnimInst, CameraAnimInst, CameraAnimInst, CameraAnimInst>/*[8]*/ AnimInstPool;
	public /*protected */array<CameraAnimInst> ActiveAnims;
	public /*protected */array<CameraAnimInst> FreeAnims;
	public /*protected transient */DynamicCameraActor AnimCameraActor;
	public /*protected transient */DynamicCameraActor AccumulatorCameraActor;
	
	public override /*function */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*event */void Destroyed()
	{
		// stub
	}
	
	public override /*event */void ApplyCameraModifiers(float DeltaTime, ref Object.TPOV OutPOV)
	{
		// stub
	}
	
	// Export UAnimatedCamera::execApplyCameraModifiersNative(FFrame&, void* const)
	public virtual /*private native final simulated function */void ApplyCameraModifiersNative(float DeltaTime, ref Object.TPOV OutPOV)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UAnimatedCamera::execPlayCameraAnim(FFrame&, void* const)
	public virtual /*native simulated function */bool PlayCameraAnim(CameraAnim Anim, /*optional */float? _Rate = default, /*optional */float? _Scale = default, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLoop = default, /*optional */bool? _bRandomStartTime = default, /*optional */float? _Duration = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UAnimatedCamera::execStopCameraAnim(FFrame&, void* const)
	public virtual /*native simulated function */void StopCameraAnim(CameraAnim Anim, /*optional */bool? _bImmediate = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}
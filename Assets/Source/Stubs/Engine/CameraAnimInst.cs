namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CameraAnimInst : Object/*
		native*/{
	public CameraAnim CamAnim;
	public /*protected export editinline */InterpGroupInst InterpGroupInst;
	public /*protected transient */float CurTime;
	public /*protected transient */bool bLooping;
	public /*transient */bool bFinished;
	public /*protected transient */bool bBlendingIn;
	public /*protected transient */bool bBlendingOut;
	public /*protected */float BlendInTime;
	public /*protected */float BlendOutTime;
	public /*protected transient */float CurBlendInTime;
	public /*protected transient */float CurBlendOutTime;
	public /*protected */float PlayRate;
	public float PlayScale;
	public float CurrentBlendWeight;
	public /*protected transient */float RemainingTime;
	public InterpTrackMove MoveTrack;
	public InterpTrackInstMove MoveInst;
	
	// Export UCameraAnimInst::execPlay(FFrame&, void* const)
	public virtual /*native final function */void Play(CameraAnim Anim, Actor CamActor, float InRate, float InScale, float InBlendInTime, float InBlendOutTime, bool bInLoop, bool bRandomStartTime, /*optional */float? _Duration = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UCameraAnimInst::execAdvanceAnim(FFrame&, void* const)
	public virtual /*native function */void AdvanceAnim(float DeltaTime, bool bJump)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UCameraAnimInst::execStop(FFrame&, void* const)
	public virtual /*native final function */void Stop(/*optional */bool? _bImmediate = default)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public CameraAnimInst()
	{
		var Default__CameraAnimInst_InterpGroupInst0 = new InterpGroupInst
		{
		}/* Reference: InterpGroupInst'Default__CameraAnimInst.InterpGroupInst0' */;
		// Object Offset:0x002B6065
		InterpGroupInst = Default__CameraAnimInst_InterpGroupInst0/*Ref InterpGroupInst'Default__CameraAnimInst.InterpGroupInst0'*/;
		bFinished = true;
		PlayRate = 1.0f;
	}
}
}
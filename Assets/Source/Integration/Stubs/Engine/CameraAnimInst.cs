namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CameraAnimInst : Object/*
		native*/{
	public CameraAnim CamAnim;
	[export, editinline] public/*protected*/ InterpGroupInst InterpGroupInst;
	[transient] public/*protected*/ float CurTime;
	[transient] public/*protected*/ bool bLooping;
	[transient] public bool bFinished;
	[transient] public/*protected*/ bool bBlendingIn;
	[transient] public/*protected*/ bool bBlendingOut;
	public/*protected*/ float BlendInTime;
	public/*protected*/ float BlendOutTime;
	[transient] public/*protected*/ float CurBlendInTime;
	[transient] public/*protected*/ float CurBlendOutTime;
	public/*protected*/ float PlayRate;
	public float PlayScale;
	public float CurrentBlendWeight;
	[transient] public/*protected*/ float RemainingTime;
	public InterpTrackMove MoveTrack;
	public InterpTrackInstMove MoveInst;
	
	// Export UCameraAnimInst::execPlay(FFrame&, void* const)
	public virtual /*native final function */void Play(CameraAnim Anim, Actor CamActor, float InRate, float InScale, float InBlendInTime, float InBlendOutTime, bool bInLoop, bool bRandomStartTime, /*optional */float? _Duration = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UCameraAnimInst::execAdvanceAnim(FFrame&, void* const)
	public virtual /*native function */void AdvanceAnim(float DeltaTime, bool bJump)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UCameraAnimInst::execStop(FFrame&, void* const)
	public virtual /*native final function */void Stop(/*optional */bool? _bImmediate = default)
	{
		NativeMarkers.MarkUnimplemented();
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
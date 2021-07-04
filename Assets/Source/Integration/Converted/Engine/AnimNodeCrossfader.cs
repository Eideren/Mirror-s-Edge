namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeCrossfader : AnimNodeBlend/*
		native
		hidecategories(Object,Object,Object,Object)*/{
	public/*()*/ name DefaultAnimSeqName;
	public /*const */bool bDontBlendOutOneShot;
	public /*const */float PendingBlendOutTimeOneShot;
	
	// Export UAnimNodeCrossfader::execPlayOneShotAnim(FFrame&, void* const)
	public virtual /*native final function */void PlayOneShotAnim(name AnimSeqName, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bDontBlendOut = default, /*optional */float? _Rate = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNodeCrossfader::execBlendToLoopingAnim(FFrame&, void* const)
	public virtual /*native final function */void BlendToLoopingAnim(name AnimSeqName, /*optional */float? _BlendInTime = default, /*optional */float? _Rate = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNodeCrossfader::execGetAnimName(FFrame&, void* const)
	public virtual /*native final function */name GetAnimName()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UAnimNodeCrossfader::execGetActiveChild(FFrame&, void* const)
	public virtual /*native final function */AnimNodeSequence GetActiveChild()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
}
}
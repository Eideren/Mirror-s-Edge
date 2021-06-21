namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAnimationSeq : UIAnimation/*
		native
		hidecategories(Object,UIRoot)*/{
	public name SeqName;
	public float SeqDuration;
	public array<UIAnimation.UIAnimTrack> Tracks;
	public bool bAbsolutePositioning;
	
	// Export UUIAnimationSeq::execApplyAnimation(FFrame&, void* const)
	public virtual /*native function */void ApplyAnimation(UIObject TargetWidget, int TrackIndex, float Position, int LFI, int NFI, UIAnimation.UIAnimSeqRef AnimRefInst)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
}
}
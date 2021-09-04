// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNodeSequence : AnimNode/*
		native
		hidecategories(Object,Object)*/{
	public enum ERootBoneAxis 
	{
		RBA_Default,
		RBA_Discard,
		RBA_Translate,
		RBA_MAX
	};
	
	public enum ERootRotationOption 
	{
		RRO_Default,
		RRO_Discard,
		RRO_Extract,
		RRO_MAX
	};
	
	[Category] [Const] public name AnimSeqName;
	[Category] public float Rate;
	[Category] public bool bPlaying;
	[Category] public bool bLooping;
	[Category] public bool bCauseActorAnimEnd;
	[Category] public bool bCauseActorAnimPlay;
	public bool bUseLegRotationHack2;
	[Category] public bool bZeroRootRotation;
	[Category] public bool bZeroRootTranslation;
	[Category] public bool bDisableWarningWhenAnimNotFound;
	[Category] public bool bNoNotifies;
	[Category] public bool bForceRefposeWhenNotPlaying;
	[Category] public bool bIgnoreRootOffset;
	public bool bIsIssuingNotifies;
	[Category("Group")] public bool bForceAlwaysSlave;
	[Category("Group")] public bool bForceAlwaysMaster;
	[Category("Group")] [Const] public bool bSynchronize;
	[Category("Display")] public bool bShowTimeLineSlider;
	public Object.Matrix AdjustForLegRotationSpaceHack;
	[Category] [Const] public float CurrentTime;
	[Const, transient] public float PreviousTime;
	[Const, transient] public AnimSequence AnimSeq;
	[Const, transient] public int AnimLinkupIndex;
	[Category] public float NotifyWeightThreshold;
	[Category("Group")] [Const] public name SynchGroupName;
	[Category("Group")] public float SynchPosOffset;
	public Texture2D DebugTrack;
	public Texture2D DebugCarat;
	[Category] public StaticArray<AnimNodeSequence.ERootBoneAxis, AnimNodeSequence.ERootBoneAxis, AnimNodeSequence.ERootBoneAxis>/*[3]*/ RootBoneOption;
	[Category] public StaticArray<AnimNodeSequence.ERootRotationOption, AnimNodeSequence.ERootRotationOption, AnimNodeSequence.ERootRotationOption>/*[3]*/ RootRotationOption;
	
	// Export UAnimNodeSequence::execSetAnim(FFrame&, void* const)
	//public virtual /*native function */void SetAnim(name Sequence)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	//// Export UAnimNodeSequence::execPlayAnim(FFrame&, void* const)
	//public override /*native function */void PlayAnim(/*optional */bool? _bLoop = default, /*optional */float? _InRate = default, /*optional */float? _StartTime = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UAnimNodeSequence::execStopAnim(FFrame&, void* const)
	//public override /*native function */void StopAnim()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	//// Export UAnimNodeSequence::execSetPosition(FFrame&, void* const)
	//public virtual /*native function */void SetPosition(float NewTime, bool bFireNotifies)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	//
	//// Export UAnimNodeSequence::execGetNormalizedPosition(FFrame&, void* const)
	//public virtual /*native function */float GetNormalizedPosition()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UAnimNodeSequence::execFindNormalizedPositionFromGroupRelativePosition(FFrame&, void* const)
	//public virtual /*native function */float FindNormalizedPositionFromGroupRelativePosition(float GroupRelativePosition)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	//// Export UAnimNodeSequence::execGetGlobalPlayRate(FFrame&, void* const)
	//public virtual /*native function */float GetGlobalPlayRate()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	//// Export UAnimNodeSequence::execGetAnimPlaybackLength(FFrame&, void* const)
	//public virtual /*native function */float GetAnimPlaybackLength()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UAnimNodeSequence::execGetTimeLeft(FFrame&, void* const)
	//public virtual /*native function */float GetTimeLeft()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public AnimNodeSequence()
	{
		// Object Offset:0x0029D4BA
		Rate = 1.0f;
		bSynchronize = true;
		DebugTrack = LoadAsset<Texture2D>("EngineResources.AnimPlayerTrack")/*Ref Texture2D'EngineResources.AnimPlayerTrack'*/;
		DebugCarat = LoadAsset<Texture2D>("EngineResources.AnimPlayerCarat")/*Ref Texture2D'EngineResources.AnimPlayerCarat'*/;
	}
}
}
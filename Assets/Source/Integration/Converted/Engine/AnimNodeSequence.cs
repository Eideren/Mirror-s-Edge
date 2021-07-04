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
	
	public/*()*/ /*const */name AnimSeqName;
	public/*()*/ float Rate;
	public/*()*/ bool bPlaying;
	public/*()*/ bool bLooping;
	public/*()*/ bool bCauseActorAnimEnd;
	public/*()*/ bool bCauseActorAnimPlay;
	public bool bUseLegRotationHack2;
	public/*()*/ bool bZeroRootRotation;
	public/*()*/ bool bZeroRootTranslation;
	public/*()*/ bool bDisableWarningWhenAnimNotFound;
	public/*()*/ bool bNoNotifies;
	public/*()*/ bool bForceRefposeWhenNotPlaying;
	public/*()*/ bool bIgnoreRootOffset;
	public bool bIsIssuingNotifies;
	public/*(Group)*/ bool bForceAlwaysSlave;
	public/*(Group)*/ bool bForceAlwaysMaster;
	public/*(Group)*/ /*const */bool bSynchronize;
	public/*(Display)*/ bool bShowTimeLineSlider;
	public Object.Matrix AdjustForLegRotationSpaceHack;
	public/*()*/ /*const */float CurrentTime;
	public /*const transient */float PreviousTime;
	public /*const transient */AnimSequence AnimSeq;
	public /*const transient */int AnimLinkupIndex;
	public/*()*/ float NotifyWeightThreshold;
	public/*(Group)*/ /*const */name SynchGroupName;
	public/*(Group)*/ float SynchPosOffset;
	public Texture2D DebugTrack;
	public Texture2D DebugCarat;
	public/*()*/ StaticArray<AnimNodeSequence.ERootBoneAxis, AnimNodeSequence.ERootBoneAxis, AnimNodeSequence.ERootBoneAxis>/*[3]*/ RootBoneOption;
	public/*()*/ StaticArray<AnimNodeSequence.ERootRotationOption, AnimNodeSequence.ERootRotationOption, AnimNodeSequence.ERootRotationOption>/*[3]*/ RootRotationOption;
	
	// Export UAnimNodeSequence::execSetAnim(FFrame&, void* const)
	public virtual /*native function */void SetAnim(name Sequence)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNodeSequence::execPlayAnim(FFrame&, void* const)
	public override /*native function */void PlayAnim(/*optional */bool? _bLoop = default, /*optional */float? _InRate = default, /*optional */float? _StartTime = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UAnimNodeSequence::execStopAnim(FFrame&, void* const)
	public override /*native function */void StopAnim()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
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
	public virtual /*native function */float FindNormalizedPositionFromGroupRelativePosition(float GroupRelativePosition)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UAnimNodeSequence::execGetGlobalPlayRate(FFrame&, void* const)
	public virtual /*native function */float GetGlobalPlayRate()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	//// Export UAnimNodeSequence::execGetAnimPlaybackLength(FFrame&, void* const)
	//public virtual /*native function */float GetAnimPlaybackLength()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UAnimNodeSequence::execGetTimeLeft(FFrame&, void* const)
	public virtual /*native function */float GetTimeLeft()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
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
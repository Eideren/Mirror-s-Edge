namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnimNodeSequence : AnimNodeSequence/*
		native
		hidecategories(Object,Object)*/{
	public enum EScalePlayRateType 
	{
		SPRT_ActorSpeed,
		SPRT_GroundSpeed,
		SPRT_ZSpeed,
		SPRT_AverageActorSpeed,
		SPRT_GroundSpeedSize,
		SPRT_MAX
	};
	
	public enum EAnimType 
	{
		EA_None,
		EA_Fire,
		EA_Reload,
		EA_Unholster,
		EA_Holster,
		EA_ThrowAway,
		EA_WallJump,
		EA_Snatch,
		EA_Walk,
		EA_Run,
		EA_MAX
	};
	
	[native] public float AccualCurrentTime;
	[Category] public bool bSnapToKeyFrames;
	[Category] public bool bForceFullPlayback;
	[Category] public bool bLoopingWithNotify;
	public bool bHasLockedAnimation;
	public bool bCauseActorCeaseRelevant;
	[Category] public bool bResetOnBecomeRelevant;
	[Category] public bool bDeltaCameraAnimation;
	[Category] public bool bForceNoWeaponPose;
	[Category("ScalePlayRate")] public bool ScalePlayRateBySpeed;
	[Category("ScalePlayRate")] public bool InversePlayRate;
	public bool bUpdateSequenceOnAnimSetsUpdated;
	public bool bCached;
	public float NormalizedStartPosition;
	[Category("ScalePlayRate")] public TdAnimNodeSequence.EScalePlayRateType ScalePlayRateType;
	[Category] public TdAnimNodeSequence.EAnimType AnimationType;
	[Category("ScalePlayRate")] public float BaseSpeed;
	[Category("ScalePlayRate")] public float ScaleByValue;
	[Category("ScalePlayRate")] public float RateMin;
	[Category("ScalePlayRate")] public float RateMax;
	public TdAnimNodeWeaponPoseOffset WeaponPoseOffsetNode;
	[transient] public TdPawn TdPawnOwner;
	
	// Export UTdAnimNodeSequence::execUpdateBaseSpeed(FFrame&, void* const)
	public virtual /*native function */void UpdateBaseSpeed()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public override /*event */void OnBecomeRelevant()
	{
		if(AnimSeq == default)
		{
			return;
		}
		if(bResetOnBecomeRelevant)
		{
			if(bSynchronize && SynchGroupName != "None")
			{
				if((SkelComponent.Owner != default) && ((SkelComponent.Owner) as TdPawn).OverrideSynchPosOffset != -1.0f)
				{
					SetPosition(((SkelComponent.Owner) as TdPawn).OverrideSynchPosOffset * AnimSeq.SequenceLength, false);				
				}
				else
				{
					SetPosition(SynchPosOffset * AnimSeq.SequenceLength, false);
				}			
			}
			else
			{
				SetPosition(((Rate > 0.0f) ? NormalizedStartPosition * (GetAnimPlaybackLength()) : Abs(GetAnimPlaybackLength())), false);
			}
		}
		bPlaying = true;
	}
	
	public virtual /*simulated function */void ResetNodeStates()
	{
		AnimationType = ((TdAnimNodeSequence.EAnimType)DefaultAs<TdAnimNodeSequence>().AnimationType);
		bDeltaCameraAnimation = DefaultAs<TdAnimNodeSequence>().bDeltaCameraAnimation;
		ScalePlayRateBySpeed = DefaultAs<TdAnimNodeSequence>().ScalePlayRateBySpeed;
		ScalePlayRateType = ((TdAnimNodeSequence.EScalePlayRateType)DefaultAs<TdAnimNodeSequence>().ScalePlayRateType);
		RateMin = DefaultAs<TdAnimNodeSequence>().RateMin;
		RateMax = DefaultAs<TdAnimNodeSequence>().RateMax;
		BaseSpeed = DefaultAs<TdAnimNodeSequence>().BaseSpeed;
		bResetOnBecomeRelevant = DefaultAs<TdAnimNodeSequence>().bResetOnBecomeRelevant;
	}
	
	public override /*event */void OnCeaseRelevant()
	{
		if(bCauseActorCeaseRelevant)
		{
			((SkelComponent.Owner) as TdPawn)?.OnCeaseRelevantRootMotion(this);
			bCauseActorCeaseRelevant = false;
		}
		if(bHasLockedAnimation)
		{
			((SkelComponent.Owner) as TdPawn)?.PopAnimationLock();
			bHasLockedAnimation = false;
		}
	}
	
	public TdAnimNodeSequence()
	{
		// Object Offset:0x005066AF
		bResetOnBecomeRelevant = true;
		bUpdateSequenceOnAnimSetsUpdated = true;
		BaseSpeed = 350.0f;
		ScaleByValue = 1.0f;
		RateMax = 2.0f;
		NotifyWeightThreshold = 0.010f;
	}
}
}
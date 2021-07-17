namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeSequence
	{
		// Export UAnimNodeSequence::execPlayAnim(FFrame&, void* const)
		public override /*native function */void PlayAnim(/*optional */bool? _bLoop = default, /*optional */float? _InRate = default, /*optional */float? _StartTime = default)
		{
			CurrentTime		= _StartTime ?? 0f;
			PreviousTime	= _StartTime ?? CurrentTime;
			Rate			= _InRate ?? Rate;
			bLooping		= _bLoop ?? bLooping;
			bPlaying		= true;

			if( bForceRefposeWhenNotPlaying && SkelComponent.bForceRefpose != 0)
			{
				SkelComponent.SetForceRefPose(false);
			}

			if( bCauseActorAnimPlay && SkelComponent.Owner != null )
			{
				SkelComponent.Owner.OnAnimPlay(this);
			}
		}
		
		// Export UAnimNodeSequence::execSetPosition(FFrame&, void* const)
        public virtual /*native function */void SetPosition(float NewTime, bool bFireNotifies)
        {
	        // Ensure NewTime lies within sequence length.
	        var AnimLength = AnimSeq != null ? AnimSeq.SequenceLength : 0f;
	        NewTime = FClamp(NewTime, 0f, AnimLength+(1e-4f));

	        // Find the amount we are moving.
	        var DeltaTime = NewTime - CurrentTime;

	        // If moving forwards, and this node generates notifies, and is suffientlt 'in the mix', fire notifies now.
	        if( bFireNotifies && 
	            DeltaTime > 0f && 
	            !bNoNotifies && 
	            (NodeTotalWeight >= NotifyWeightThreshold) )
	        {
		        IssueNotifies(DeltaTime);		
	        }

	        // Then update the time.
	        CurrentTime = NewTime;

	        // If we don't fire notifies, it means we jump to that new position instantly, 
	        // so reset previous time
	        if( !bFireNotifies )
	        {
		        PreviousTime = CurrentTime;
	        }

	        // Clear out the cached data
	        //CachedBoneAtoms.Reset();
        }
        
        // Export UAnimNodeSequence::execGetNormalizedPosition(FFrame&, void* const)
        public virtual /*native function */float GetNormalizedPosition()
        {
	        if( AnimSeq != null && AnimSeq.SequenceLength > 0f )
	        {
		        var v = CurrentTime / AnimSeq.SequenceLength;
		        v = v < 0f ? 0f : v > 1f ? 1f : v;
		        return v;
	        }

	        return 0f;
        }
        
        // Export UAnimNodeSequence::execGetAnimPlaybackLength(FFrame&, void* const)
        public virtual /*native function */float GetAnimPlaybackLength()
        {
	        if( AnimSeq != null )
	        {
		        var GlobalPlayRate = GetGlobalPlayRate();
		        if( GlobalPlayRate != 0f )
		        {
			        return AnimSeq.SequenceLength / GlobalPlayRate;
		        }
	        }

	        return 0f;
        }


        /** Returns the global play rate of this animation. Taking into account all Rate Scales */
		// Export UAnimNodeSequence::execGetGlobalPlayRate(FFrame&, void* const)
        public virtual /*native function */float GetGlobalPlayRate()
        {
	        // AnimNodeSequence play rate
	        float GlobalRate = Rate * SkelComponent.GlobalAnimRateScale;

	        // AnimSequence play rate
	        if( AnimSeq != null )
	        {
		        GlobalRate *= AnimSeq.RateScale;
	        }

	        // AnimGroup play rate
	        if( SynchGroupName != default && SkelComponent != null )
	        {
		        var RootNode = SkelComponent.Animations as AnimTree;
		        if( RootNode != null )
		        {
			        foreach( var grp in RootNode.AnimGroups )
			        {
				        if( grp.GroupName == SynchGroupName )
				        {
					        GlobalRate *= grp.RateScale;
					        break;
				        }
			        }
		        }
	        }

	        return GlobalRate;
        }
        
        public void AdvanceBy(float MoveDelta, float DeltaSeconds, bool bFireNotifies)
		{
			if( AnimSeq == null || MoveDelta == 0f || DeltaSeconds == 0f )
			{
				return;
			}

			// Clear out the cached data
			//CachedBoneAtoms.Reset();

			// This node should try to fire notifies
			if( bFireNotifies && MoveDelta > 0f )
			{
				// Can fire notifies if part of a synchronization group and node is relevant.
				// then bFireNotifies tells us if we should actually fire notifies or not.
				bool bCanFireNotifyGroup		= SynchGroupName != default && bRelevant;
			
				// If not part of a group then we check for the weight threshold.
				bool	bCanFireNotifyNoGroup	= (NodeTotalWeight >= NotifyWeightThreshold);

				// Before we actually advance the time, issue any notifies (if desired).
				if( !bNoNotifies && (bCanFireNotifyGroup || bCanFireNotifyNoGroup) )
				{
					IssueNotifies(MoveDelta);

					// If a notification cleared the animation, stop here, don't crash.
					if( AnimSeq == null )
					{
						return;
					}
				}
			}

			// Then update internal time.
			CurrentTime	+= MoveDelta;

			// See if we passed the end of the animation.
			if( CurrentTime > AnimSeq.SequenceLength )
			{
				// If we are looping, wrap over.
				if( bLooping )
				{
					CurrentTime	%= AnimSeq.SequenceLength;
				}
				// If not, snap time to end of sequence and stop playing.
				else 
				{
					// Find Rate of this movement.
					float MoveRate = MoveDelta / DeltaSeconds;

					// figure out by how much we've reached beyond end of animation.
					// This is useful for transitions. It is made independant from play rate
					// So we can transition properly between animations of different play rates
					float ExcessTime = (CurrentTime - AnimSeq.SequenceLength) / MoveRate;
					CurrentTime = AnimSeq.SequenceLength;
					bPlaying	= false;

					// Notify that animation finished playing
					OnAnimEnd(DeltaSeconds - ExcessTime, ExcessTime);
				}
			}
			// See if we passed before the begining of the animation
			else if( CurrentTime < 0f )
			{
				// If we are looping, wrap over.
				if( bLooping )
				{
					CurrentTime	%= AnimSeq.SequenceLength;
					if( CurrentTime < 0f )
					{
						CurrentTime += AnimSeq.SequenceLength;
					}
				}
				// If not, snap time to begining of sequence and stop playing.
				else 
				{
					// Find Rate of this movement.
					float MoveRate = MoveDelta / DeltaSeconds;

					// figure out by how much we've reached beyond begining of animation.
					// This is useful for transitions.
					float ExcessTime = CurrentTime / Abs(MoveRate);
					CurrentTime = 0f;
					bPlaying	= false;

					// Notify that animation finished playing
					OnAnimEnd(DeltaSeconds + ExcessTime, ExcessTime);
				}
			}
		}
        
        void OnAnimEnd(float PlayedTime, float ExcessTime)
        {
	        // When we hit the end and stop, issue notifies to parent AnimNodeBlendBase
	        for(var i=0; i<ParentNodes.Length; i++)
	        {
		        ParentNodes[i].OnChildAnimEnd(this, PlayedTime, ExcessTime); 
	        }

	        if( bForceRefposeWhenNotPlaying && SkelComponent.bForceRefpose != 0)
	        {
		        SkelComponent.SetForceRefPose(true);
	        }

	        if( bCauseActorAnimEnd && SkelComponent.Owner != null )
	        {
		        SkelComponent.Owner.OnAnimEnd(this, PlayedTime, ExcessTime);
	        }
        }
        
        public void IssueNotifies(float DeltaTime)
        {
			// If no sequence - do nothing!
			if(AnimSeq == null)
			{
				return;
			}

			// Do nothing if there are no notifies to play.
			var NumNotifies = AnimSeq.Notifies.Length;
			if(NumNotifies == 0)
			{
				return;
			}


			// Total interval we're about to proceed CurrentTime forward  (right after this IssueNotifies routine)
			var TimeToGo = DeltaTime; 

			// First, find the next notify we are going to hit.
			var NextNotifyIndex = INDEX_NONE;
			var TimeToNextNotify = float.PositiveInfinity;
			var WorkTime = float.PositiveInfinity;

			// Note - if there are 2 notifies with the same time, it starts with the lower index one.
			for(var i=0; i<NumNotifies; i++)
			{
				var NotifyEventTime = AnimSeq.Notifies[i].Time;
				var TryTimeToNotify = NotifyEventTime - CurrentTime;
				if(TryTimeToNotify < 0.0f)
				{
					if(!bLooping)
					{
						// Not interested in notifies before current time if not looping.
						continue; 
					}
					else
					{
						// Correct TimeToNextNotify as it lies before WorkTime.
						TryTimeToNotify += AnimSeq.SequenceLength; 
					}
				}

				// Check to find soonest one.
				if(TryTimeToNotify < TimeToNextNotify)
				{
					TimeToNextNotify = TryTimeToNotify;
					NextNotifyIndex = i;
					WorkTime = NotifyEventTime;
				}
			}

			// If there is no potential next notify, do nothing.
			// This can only happen if there are no notifies (and we would have returned at start) or the anim is not looping.
			if(NextNotifyIndex == INDEX_NONE)
			{
				assert(!bLooping);
				return;
			}

			// Wind current time to first notify.
			TimeToGo -= TimeToNextNotify;

			// Set flag to show we are firing notifies.
			bIsIssuingNotifies = true;
			// Backup SeqNode, in case it gets changed during a notify, so we can process them all.
			var AnimSeqNotify = AnimSeq;

			// Then keep walking forwards until we run out of time.
			while( TimeToGo > 0.0f )
			{
				//debugf( TEXT("NOTIFY: %d %s"), NextNotifyIndex, *(AnimSeq->Notifies(NextNotifyIndex).Comment) );

				// Execute this notify. NextNotifyIndex will be the soonest notify inside the current TimeToGo interval.
				var AnimNotify = AnimSeqNotify.Notifies[NextNotifyIndex].Notify;
				if( AnimNotify != null )
				{
					// Call Notify function
					AnimNotify.Notify( this );
				}
				
				// Then find the next one.
				NextNotifyIndex = (NextNotifyIndex + 1) % NumNotifies; // Assumes notifies are ordered.
				TimeToNextNotify = AnimSeqNotify.Notifies[NextNotifyIndex].Time - WorkTime;

				// Wrap if necessary.
				if( NextNotifyIndex == 0 )
				{
					if( !bLooping )
					{
						// If not looping, nothing more to do if notify is before current working time.
						bIsIssuingNotifies = false;
						return;
					}
					else
					{
						// Correct TimeToNextNotify as it lies before WorkTime.
						TimeToNextNotify += AnimSeqNotify.SequenceLength; 
					}
				}

				// Wind on to next notify.
				TimeToGo -= TimeToNextNotify;
				WorkTime = AnimSeqNotify.Notifies[NextNotifyIndex].Time;
			}

			bIsIssuingNotifies = false;
		}
	}
}
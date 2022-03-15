namespace MEdge.Engine
{
	using System;
	using Core;
	using String = Core.String;
	using static Source.DecFn;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FVector4 = Core.Object.Vector4;
	using FRotator = Core.Object.Rotator;
	using FQuat = Core.Object.Quat;
	using FBoneAtom = AnimNode.BoneAtom;
	using UBOOL = System.Boolean;
	using FMatrix = Core.Object.Matrix;
	using BYTE = System.Byte;
	using UINT = System.UInt32;
	using static AnimNodeSequence.ERootBoneAxis;
	using static AnimNodeSequence.ERootRotationOption;



	public partial class AnimSet
	{
		public int GetMeshLinkupIndex(SkeletalMesh InSkelMesh)
		{
			NativeMarkers.MarkUnimplemented();
			return default;
			/*
			// First, see if we have a cached link-up between this animation and the given skeletal mesh.
			check(InSkelMesh);
			//check(InSkelMesh.SkelMeshGUID.IsValid());
			for(int i=0; i<LinkupCache.Num(); i++)
			{
				if( LinkupCache[i].SkelMeshLinkupGUID == InSkelMesh.SkelMeshGUID )
				{
					return i;
				}
			}

			// No linkup found - so create one here and add to cache.
			int NewLinkupIndex = LinkupCache.AddZeroed();
			ref AnimSetMeshLinkup NewLinkup = ref LinkupCache[NewLinkupIndex];
			NewLinkup.BuildLinkup(InSkelMesh, this);

			return NewLinkupIndex;*/
		}
	}



	public partial class AnimSequence
	{
		public AnimSet GetAnimSet()
		{
			return (AnimSet)GetOuter();
		}
	}



	public partial class AnimNodeSequence
{
public override void SetAnim(name InSequenceName)
{
	if (false)
	{
		debugf(TEXT("** SetAnim %s, on %s"), InSequenceName.ToString(), GetFName().ToString());
	}

	// Abort if we are in the process of firing notifies, as this can cause a crash.
	//
	//	Unless the animation is the same. This can happen if a new skeletal mesh is set, then it forces all
	// animations to be recached. If the animation is the same, then it's safe to update it.
	// Note that it can be set to NAME_None if the AnimSet has been removed as well.
	if( bIsIssuingNotifies && AnimSeqName != InSequenceName )
	{
		debugf( TEXT("UAnimNodeSequence.SetAnim : Not safe to call SetAnim from inside a Notify. AnimName: %s, Owner: %s"), InSequenceName.ToString(), SkelComponent.GetOwner().GetName() );
		return;
	}

	AnimSeqName		= InSequenceName;
	AnimSeq			= null;
	AnimLinkupIndex = INDEX_NONE;

	// Clear out the cached data
	CachedBoneAtoms.Reset();

	if( InSequenceName == NAME_None || !SkelComponent || !SkelComponent.SkeletalMesh )
	{
		return;
	}

	AnimSeq = SkelComponent.FindAnimSequence(AnimSeqName);
	if( AnimSeq != NULL )
	{
		#if UNUSED
		AnimSet AnimSet = AnimSeq.GetAnimSet();
		AnimLinkupIndex = AnimSet.GetMeshLinkupIndex( SkelComponent.SkeletalMesh );
		
		check(AnimLinkupIndex != INDEX_NONE);
		check(AnimLinkupIndex < AnimSet.LinkupCache.Num());

		AnimSet.AnimSetMeshLinkup AnimLinkup = AnimSet.LinkupCache[AnimLinkupIndex];

		//check( AnimLinkup.SkelMeshLinkupGUID == SkelComponent.SkeletalMesh.SkelMeshGUID );
		check( AnimLinkup.BoneToTrackTable.Num() == SkelComponent.SkeletalMesh.RefSkeleton.Num() );
		check( AnimLinkup.BoneUseAnimTranslation.Num() == SkelComponent.SkeletalMesh.RefSkeleton.Num() );
		#endif
	}
	else if( !bDisableWarningWhenAnimNotFound && !SkelComponent.bDisableWarningWhenAnimNotFound )
	{
		debugf( /*"NAME_DevAnim",*/ TEXT("%s - Failed to find animsequence '%s' on SkeletalMeshComponent: %s whose owner is: %s using mesh: %s" ),
			   GetName(),
			   InSequenceName.ToString(),
			   SkelComponent.GetName(),
			   SkelComponent.GetOwner().GetName(),
			   SkelComponent.SkeletalMesh.GetPathName()
			   );
	}
}

///<summary>
/// 
/// Cache results always if bCacheAnimSequenceNodes == TRUE. (Optimization if animation is not frequently updated).
/// or if node has more than a single parent.
///</summary>
public virtual bool ShouldSaveCachedResults()
{
	return (SkelComponent.bCacheAnimSequenceNodes || (ParentNodes.Num() > 1) );
}

public virtual float GetSliderPosition(int SliderIndex, int ValueIndex)
{
	check(0 == SliderIndex && 0 == ValueIndex);

	if( AnimSeq && AnimSeq.SequenceLength > 0f )
	{
		return (CurrentTime / AnimSeq.SequenceLength);
	}
	return 0f;
}

public virtual void HandleSliderMove(int SliderIndex, int ValueIndex, float NewSliderValue)
{
	check(0 == SliderIndex && 0 == ValueIndex);

	if( !AnimSeq || AnimSeq.SequenceLength == 0f )
	{
		return;
	}

	float NewTime = NewSliderValue * AnimSeq.SequenceLength;
	SetPosition(NewTime, FALSE);
}

public virtual String GetSliderDrawValue(int SliderIndex)
{
	throw new Exception();
	/*check(0 == SliderIndex);

	if( !AnimSeq || AnimSeq.SequenceLength == 0f )
	{
		return (TEXT("N/A"));
	}

	return String.Printf(TEXT("Pos: %3.2f%%, Time: %3.2fs"), (CurrentTime/AnimSeq.SequenceLength)*100f, CurrentTime);*/
}

public override void PostEditChange(Property PropertyThatChanged)
{
	SetAnim( AnimSeqName );

	if(SkelComponent && SkelComponent.IsAttached())
	{
		SkelComponent.UpdateSkelPose();
		SkelComponent.ConditionalUpdateTransform();
	}

	base.PostEditChange(PropertyThatChanged);
}

public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
{
	base.InitAnim( meshComp, Parent );

	SetAnim( AnimSeqName );
}


///<summary>
/// AnimSets have been updated, update all animations 
///</summary>
public override void AnimSetsUpdated()
{
	base.AnimSetsUpdated();

	SetAnim( AnimSeqName );
}

public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	// If this node is part of a group, animation is going to be advanced in a second pass, once all weights have been calculated in the tree.
	if( SynchGroupName == NAME_None )
	{
		// Keep track of PreviousTime before any update. This is used by Root Motion.
		PreviousTime = CurrentTime;

		// Can only do something if we are currently playing a valid AnimSequence
		if( bPlaying && AnimSeq )
		{
			// Time to move forwards by - DeltaSeconds scaled by various factors.
			float MoveDelta = Rate * AnimSeq.RateScale * SkelComponent.GlobalAnimRateScale * DeltaSeconds;
			AdvanceBy(MoveDelta, DeltaSeconds, (SkelComponent.bUseRawData) ? FALSE : TRUE);
		}
	}
}


///<summary>
/// Advance animation time. Take care of issuing notifies, looping and so on 
///</summary>
public virtual void AdvanceBy(float MoveDelta, float DeltaSeconds, bool bFireNotifies)
{
	if( !AnimSeq || MoveDelta == 0f || DeltaSeconds == 0f )
	{
		return;
	}

	// Clear out the cached data
	CachedBoneAtoms.Reset();

	// This node should try to fire notifies
	if( bFireNotifies && MoveDelta > 0f )
	{
		// Can fire notifies if part of a synchronization group and node is relevant.
		// then bFireNotifies tells us if we should actually fire notifies or not.
		bool bCanFireNotifyGroup		= SynchGroupName != NAME_None && bRelevant;
	
		// If not part of a group then we check for the weight threshold.
		bool	bCanFireNotifyNoGroup	= (NodeTotalWeight >= NotifyWeightThreshold);

		// Before we actually advance the time, issue any notifies (if desired).
		if( !bNoNotifies && (bCanFireNotifyGroup || bCanFireNotifyNoGroup) )
		{
			IssueNotifies(MoveDelta);

			// If a notification cleared the animation, stop here, don't crash.
			if( !AnimSeq )
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
			CurrentTime	= appFmod(CurrentTime, AnimSeq.SequenceLength);
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
			bPlaying	= FALSE;

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
			CurrentTime	= appFmod(CurrentTime, AnimSeq.SequenceLength);
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
			bPlaying	= FALSE;

			// Notify that animation finished playing
			OnAnimEnd(DeltaSeconds + ExcessTime, ExcessTime);
		}
	}
}


///<summary>
/// 
/// notification that current animation finished playing. 
/// @param	PlayedTime	Time in seconds of animation played. (play rate independant).
/// @param	ExcessTime	Time in seconds beyond end of animation. (play rate independant).
///</summary>
public virtual void OnAnimEnd(float PlayedTime, float ExcessTime)
{
	// When we hit the end and stop, issue notifies to parent AnimNodeBlendBase
	for(int i=0; i<ParentNodes.Num(); i++)
	{
		ParentNodes[i].OnChildAnimEnd(this, PlayedTime, ExcessTime); 
	}

	if( bForceRefposeWhenNotPlaying && SkelComponent.bForceRefpose == 0)
	{
		SkelComponent.SetForceRefPose(TRUE);
	}

	if( bCauseActorAnimEnd && SkelComponent.Owner )
	{
		SkelComponent.Owner.OnAnimEnd(this, PlayedTime, ExcessTime);
	}
}

public override void GetBoneAtoms(ref Span<BoneAtom> Atoms, ref array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	//START_GETBONEATOM_TIMER

	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		//debugf(TEXT("%2.3f: %s returning cached atoms"),GWorld.GetTimeSeconds(),*GetPathName());
		return;
	}

	GetAnimationPose(AnimSeq, ref AnimLinkupIndex, ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}


public virtual void GetAnimationPose(AnimSequence InAnimSeq, ref int InAnimLinkupIndex, ref Span<BoneAtom> Atoms, ref array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	//SCOPE_CYCLE_COUNTER(STAT_GetAnimationPose);

	check(SkelComponent);
	check(SkelComponent.SkeletalMesh);

	// Set root motion delta to identity, so it's always initialized, even when not extracted.
	RootMotionDelta = BoneAtom.Identity;
	bHasRootMotion	 = false;

	#if UNUSED
	if( !InAnimSeq || InAnimLinkupIndex == INDEX_NONE )
	#else
	if( !InAnimSeq )
	#endif
	{
#if false//0
		debugf(TEXT("GetAnimationPose - %s - No animation data!"), *GetFName());
#endif
		FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}

	// Get the reference skeleton
	ref array<FMeshBone> RefSkel = ref SkelComponent.SkeletalMesh.RefSkeleton;
	int NumBones = RefSkel.Num();
	check(NumBones == Atoms.Length);
	
	#if UNUSED
	AnimSet AnimSet = InAnimSeq.GetAnimSet();
	check(InAnimLinkupIndex < AnimSet.LinkupCache.Num());

	ref AnimSet.AnimSetMeshLinkup AnimLinkup = ref AnimSet.LinkupCache[InAnimLinkupIndex];

	// @remove me, trying to figure out why this is failing
	if( AnimLinkup.BoneToTrackTable.Num() != NumBones )
	{
		debugf(TEXT("AnimLinkup.BoneToTrackTable.Num() != NumBones, BoneToTrackTable.Num(): %d, NumBones: %d, AnimName: %s, Owner: %s, Mesh: %s"), AnimLinkup.BoneToTrackTable.Num(), NumBones, InAnimSeq.SequenceName.ToString(), SkelComponent.GetOwner().GetName(), SkelComponent.SkeletalMesh.GetName());
	}
	check(AnimLinkup.BoneToTrackTable.Num() == NumBones);
	#endif

	// Are we doing root motion for this node?
	bool bDoRootTranslation	= (RootBoneOption[0] != RBA_Default) || (RootBoneOption[1] != RBA_Default) || (RootBoneOption[2] != RBA_Default);
	bool bDoRootRotation		= (RootRotationOption[0] != RRO_Default) || (RootRotationOption[1] != RRO_Default) || (RootRotationOption[2] != RRO_Default);
	bool	bDoingRootMotion	= bDoRootTranslation || bDoRootRotation;

	// Is the skeletal mesh component requesting that raw animation data be used?
	bool bUseRawData = SkelComponent.bUseRawData;

	// Handle Last Frame to First Frame interpolation when looping.
	// It is however disabled for the Root Bone.
	// And the 'bNoLoopingInterpolation' flag on the animation can also disable that behavior.
	bool bLoopingInterpolation = bLooping && !InAnimSeq.bNoLoopingInterpolation;

	// For each desired bone...
	for( int i=0; i<DesiredBones.Num(); i++ )
	{
		int	BoneIndex = DesiredBones[i];

		// Find which track in the sequence we look in for this bones data
		int	TrackIndex = /*AnimLinkup.BoneToTrackTable[*/BoneIndex/*]*/;

		// If there is no track for this bone, we just use the reference pose.
		if( TrackIndex == INDEX_NONE )
		{
			Atoms[BoneIndex] = new BoneAtom(RefSkel[BoneIndex].BonePos.Orientation, RefSkel[BoneIndex].BonePos.Position, 1f);					
		}
		else 
		{
			// Non Root Bone
			if( BoneIndex > 0 )
			{
				// Otherwise read it from the sequence.
				InAnimSeq.GetBoneAtom(ref Atoms[BoneIndex], TrackIndex, CurrentTime, bLoopingInterpolation, bUseRawData);

				// If doing 'rotation only' case, use ref pose for all non-root bones that are not in the BoneUseAnimTranslation array.
				#if UNUSED
				if(	AnimSet.bAnimRotationOnly && !(AnimLinkup.BoneUseAnimTranslation[BoneIndex] != default) )
				{
					Atoms[BoneIndex].Translation = RefSkel[BoneIndex].BonePos.Position;
				}
				#endif

				// Apply quaternion fix for ActorX-exported quaternions.
				//Atoms[BoneIndex].Rotation.W *= -1.0f;
			}
			// Root Bone
			else
			{
				// Otherwise read it from the sequence.
				InAnimSeq.GetBoneAtom(ref Atoms[BoneIndex], TrackIndex, CurrentTime, bLoopingInterpolation && !bDoingRootMotion, bUseRawData);

				// If doing root motion for this animation, extract it!
				if( bDoingRootMotion )
				{
					ExtractRootMotion(InAnimSeq, ref TrackIndex, ref Atoms[0], ref RootMotionDelta, ref bHasRootMotion);
				}

				// If desired, zero out Root Bone rotation.
				if( bZeroRootRotation )
				{
					Atoms[0].Rotation = FQuat.Identity;
				}

				// If desired, zero out Root Bone translation.
				if( bZeroRootTranslation )
				{
					Atoms[0].Translation = FVector(0f);
				}
			}
		}
	}
}

///<summary>
///
///  Extract Root Motion for the current Animation Pose.
///</summary>
public virtual void ExtractRootMotion(AnimSequence InAnimSeq, ref int TrackIndex, ref BoneAtom CurrentFrameAtom, ref BoneAtom DeltaMotionAtom, ref bool bHasRootMotion)
{
	// SkeletalMesh has a transformation that is applied between the component and the actor, 
	// instead of being between mesh and component. 
	// So we have to take that into account when doing operations happening in component space (such as per Axis masking/locking).
	FMatrix MeshToCompTM = FRotationMatrix(SkelComponent.SkeletalMesh.RotOrigin);
	// Inverse transform, from component space to mesh space.
	FMatrix CompToMeshTM = MeshToCompTM.Inverse();

	// Get the exact translation of the root bone on the first frame of the animation
	BoneAtom FirstFrameAtom = default;
	InAnimSeq.GetBoneAtom(ref FirstFrameAtom, TrackIndex, 0f, FALSE, SkelComponent.bUseRawData);

	// Do we need to extract root motion?
	bool bExtractRootTranslation = (RootBoneOption[0] == RBA_Translate) || (RootBoneOption[1] == RBA_Translate) || (RootBoneOption[2] == RBA_Translate);
	bool bExtractRootRotation	 = (RootRotationOption[0] == RRO_Extract) || (RootRotationOption[1] == RRO_Extract) || (RootRotationOption[2] == RRO_Extract);
	bool bExtractRootMotion		 = bExtractRootTranslation || bExtractRootRotation;

	// Calculate bone motion
	if( bExtractRootMotion )
	{
		// We are extracting root motion, so set the flag to TRUE
		bHasRootMotion	 = true;
		float StartTime	= PreviousTime;
		float EndTime	= CurrentTime;

/// 
/// If FromTime == ToTime, then we can't give a root delta for this frame.
/// To avoid delaying it to next frame, because physics may need it right away,
/// see if we can make up one by simulating forward.
/// 
		if( StartTime == EndTime )
		{
			// Only try to make up movement if animation is allowed to play
			if( bPlaying && InAnimSeq )
			{
				// See how much time would have passed on this frame
				float DeltaTime = Rate * InAnimSeq.RateScale * SkelComponent.GlobalAnimRateScale * GWorld.GetDeltaSeconds();

				// If we can push back FromTime, then do so.
				if( StartTime > DeltaTime )
				{
					StartTime -= DeltaTime;
				}
				else
				{
					// otherwise, advance in time, to predict the movement
					EndTime += DeltaTime;

					// See if we passed the end of the animation.
					if( EndTime > InAnimSeq.SequenceLength )
					{
						// If we are looping, wrap over. If not, snap time to end of sequence.
						EndTime = bLooping ? appFmod(EndTime, InAnimSeq.SequenceLength) : InAnimSeq.SequenceLength;
					}
				}
			}
			else
			{
				// If animation is done playing we're not extracting root motion anymore.
				bHasRootMotion  = false;
			}
		}

		// If time has passed, compute root delta movement
		if( StartTime != EndTime )
		{
			// Get Root Bone Position of start of movement
			BoneAtom StartAtom = default;
			if( StartTime != CurrentTime )
			{
				InAnimSeq.GetBoneAtom(ref StartAtom, TrackIndex, StartTime, FALSE, SkelComponent.bUseRawData);
			}
			else
			{
				StartAtom = CurrentFrameAtom;
			}

			// Get Root Bone Position of end of movement
			BoneAtom EndAtom = default;
			if( EndTime != CurrentTime )
			{
				InAnimSeq.GetBoneAtom(ref EndAtom, TrackIndex, EndTime, FALSE, SkelComponent.bUseRawData);
			}
			else
			{
				EndAtom = CurrentFrameAtom;
			}

			// Get position on last frame if we extract translation and/or rotation
			BoneAtom LastFrameAtom = default;
			if( StartTime > EndTime && (bExtractRootTranslation || bExtractRootRotation) )
			{
				// Get the exact root position of the root bone on the last frame of the animation
				InAnimSeq.GetBoneAtom(ref LastFrameAtom, TrackIndex, InAnimSeq.SequenceLength, FALSE, SkelComponent.bUseRawData);
			}

			// We don't support scale
			DeltaMotionAtom.Scale = 0f;

			// If extracting root translation, filter out any axis
			if( bExtractRootTranslation )
			{
				// Handle case if animation looped
				if( StartTime > EndTime )
				{
					// Handle proper translation wrapping. We don't want the mesh to translate back to origin. So split that in 2 moves.
					DeltaMotionAtom.Translation = (LastFrameAtom.Translation - StartAtom.Translation) + (EndAtom.Translation - FirstFrameAtom.Translation);
				}
				else
				{
					// Delta motion of the root bone in mesh space
					DeltaMotionAtom.Translation = EndAtom.Translation - StartAtom.Translation;
				}

				// Only do that if an axis needs to be filtered out.
				if( RootBoneOption[0] != RBA_Translate || RootBoneOption[1] != RBA_Translate || RootBoneOption[2] != RBA_Translate )
				{
					// Convert Delta translation from mesh space to component space
					// We do this for axis filtering
					FVector CompDeltaTranslation = MeshToCompTM.TransformNormal(DeltaMotionAtom.Translation);

					// Filter out any of the X, Y, Z channels in mesh space
					if( RootBoneOption[0] != RBA_Translate )
					{
						CompDeltaTranslation.X = 0f;
					}
					if( RootBoneOption[1] != RBA_Translate )
					{
						CompDeltaTranslation.Y = 0f;
					}
					if( RootBoneOption[2] != RBA_Translate )
					{
						CompDeltaTranslation.Z = 0f;
					}

					// Convert back to mesh space.
					DeltaMotionAtom.Translation = MeshToCompTM.InverseTransformNormal(CompDeltaTranslation);
				}
#if false//0
				debugf(TEXT("%3.2f [%s] [%s] Extracted Root Motion Trans: %3.3f, Vect: %s, StartTime: %3.3f, EndTime: %3.3f"), GWorld.GetTimeSeconds(), *SkelComponent.GetOwner()->GetName(), *AnimSeqName.ToString(), DeltaMotionAtom.Translation.Size(), *DeltaMotionAtom.Translation.ToString(), StartTime, EndTime);
#endif
			}
			else
			{
				// Otherwise, don't extract any translation
				DeltaMotionAtom.Translation = FVector(0f);
			}

			// If extracting root translation, filter out any axis
			if( bExtractRootRotation )
			{
				// Delta rotation
				// Handle case if animation looped
				if( StartTime > EndTime )
				{
					// Handle proper Rotation wrapping. We don't want the mesh to rotate back to origin. So split that in 2 turns.
					DeltaMotionAtom.Rotation = (LastFrameAtom.Rotation * (-StartAtom.Rotation)) * (EndAtom.Rotation * (-FirstFrameAtom.Rotation));
				}
				else
				{
					// Delta motion of the root bone in mesh space
					DeltaMotionAtom.Rotation = EndAtom.Rotation * (-StartAtom.Rotation);
				}
				DeltaMotionAtom.Rotation.Normalize();

#if false//0 // DEBUG ROOT ROTATION
				debugf(TEXT("%3.2f Root Rotation StartAtom: %s, EndAtom: %s, DeltaMotionAtom: %s"), GWorld.GetTimeSeconds(), 
					*(FQuatRotationTranslationMatrix(StartAtom.Rotation, FVector(0f)).Rotator()).ToString(), 
					*(FQuatRotationTranslationMatrix(EndAtom.Rotation, FVector(0f)).Rotator()).ToString(), 
					*(FQuatRotationTranslationMatrix(DeltaMotionAtom.Rotation, FVector(0f)).Rotator()).ToString());
#endif

				// Only do that if an axis needs to be filtered out.
				if( RootRotationOption[0] != RRO_Extract || RootRotationOption[1] != RRO_Extract || RootRotationOption[2] != RRO_Extract )
				{
					FQuat	MeshToCompQuat = new(MeshToCompTM);

					// Turn delta rotation from mesh space to component space
					FQuat	CompDeltaQuat = MeshToCompQuat * DeltaMotionAtom.Rotation * (-MeshToCompQuat);
					CompDeltaQuat.Normalize();

#if false//0 // DEBUG ROOT ROTATION
					debugf(TEXT("%3.2f Mesh To Comp Delta: %s"), GWorld.GetTimeSeconds(), *(FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0f)).Rotator()).ToString());
#endif

					// Turn component space delta rotation to FRotator
					// @note going through rotators introduces some errors. See if this can be done using quaterions instead.
					FRotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0f)).Rotator();

					// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
					if( RootRotationOption[0] != RRO_Extract )
					{
						CompDeltaRot.Roll	= 0;
					}
					if( RootRotationOption[1] != RRO_Extract )
					{
						CompDeltaRot.Pitch	= 0;
					}
					if( RootRotationOption[2] != RRO_Extract )
					{
						CompDeltaRot.Yaw	= 0;
					}

					// Turn back filtered component space delta rotator to quaterion
					FQuat CompNewDeltaQuat	= CompDeltaRot.Quaternion();

					// Turn component space delta to mesh space.
					DeltaMotionAtom.Rotation = (-MeshToCompQuat) * CompNewDeltaQuat * MeshToCompQuat;
					DeltaMotionAtom.Rotation.Normalize();

#if false//0 // DEBUG ROOT ROTATION
					debugf(TEXT("%3.2f Post Comp Filter. CompDelta: %s, MeshDelta: %s"), GWorld.GetTimeSeconds(), 
						*(FQuatRotationTranslationMatrix(CompNewDeltaQuat, FVector(0f)).Rotator()).ToString(), 
						*(FQuatRotationTranslationMatrix(DeltaMotionAtom.Rotation, FVector(0f)).Rotator()).ToString());
#endif

				}

#if false//0 // DEBUG ROOT ROTATION
				FQuat	MeshToCompQuat(MeshToCompTM);

				// Transform mesh space delta rotation to component space.
				FQuat	CompDeltaQuat	= MeshToCompQuat * DeltaMotionAtom.Rotation * (-MeshToCompQuat);
				CompDeltaQuat.Normalize();

				debugf(TEXT("%3.2f Extracted Root Rotation: %s"), GWorld.GetTimeSeconds(), *(FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0f)).Rotator()).ToString());
#endif

				// Transform delta translation by this delta rotation.
				// This is to compensate the fact that the rotation will rotate the actor, and affect the translation.
				// This assumes that root rotation won't be weighted down the tree, and that Actor will actually use it...
				// Also we don't filter rotation per axis here.. what is done for delta root rotation, should be done here as well.
				if( !DeltaMotionAtom.Translation.IsZero() )
				{
					// Delta rotation since first frame
					// Remove delta we just extracted, because translation is going to be applied with current rotation, not new one.
					FQuat	MeshDeltaRotQuat = (CurrentFrameAtom.Rotation * (-FirstFrameAtom.Rotation)) * (-DeltaMotionAtom.Rotation);
					MeshDeltaRotQuat.Normalize();

					// Only do that if an axis needs to be filtered out.
					if( RootRotationOption[0] != RRO_Extract || RootRotationOption[1] != RRO_Extract || RootRotationOption[2] != RRO_Extract )
					{
						FQuat	MeshToCompQuat = new(MeshToCompTM);

						// Turn delta rotation from mesh space to component space
						FQuat	CompDeltaQuat = MeshToCompQuat * MeshDeltaRotQuat * (-MeshToCompQuat);
						CompDeltaQuat.Normalize();

						// Turn component space delta rotation to FRotator
						// @note going through rotators introduces some errors. See if this can be done using quaterions instead.
						FRotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0f)).Rotator();

						// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
						if( RootRotationOption[0] != RRO_Extract )
						{
							CompDeltaRot.Roll	= 0;
						}
						if( RootRotationOption[1] != RRO_Extract )
						{
							CompDeltaRot.Pitch	= 0;
						}
						if( RootRotationOption[2] != RRO_Extract )
						{
							CompDeltaRot.Yaw	= 0;
						}

						// Turn back filtered component space delta rotator to quaterion
						FQuat CompNewDeltaQuat = CompDeltaRot.Quaternion();

						// Turn component space delta to mesh space.
						MeshDeltaRotQuat = (-MeshToCompQuat) * CompNewDeltaQuat * MeshToCompQuat;
						MeshDeltaRotQuat.Normalize();
					}

					FMatrix	MeshDeltaRotTM		= FQuatRotationTranslationMatrix(MeshDeltaRotQuat, FVector(0f));
					DeltaMotionAtom.Translation = MeshDeltaRotTM.InverseTransformNormal( DeltaMotionAtom.Translation );
				}
			}
			else
			{			
				// If we're not extracting rotation, then set to identity
				DeltaMotionAtom.Rotation = FQuat.Identity;
			}
		}
		else // if( StartTime != EndTime )
		{
			// Root Motion cannot be extracted.
			DeltaMotionAtom = BoneAtom.Identity;
		}
	}

	// Apply bone locking, with axis filtering (in component space)
	// Bone is locked to its position on the first frame of animation.
	{
		// Lock full rotation to first frame.
		if( RootRotationOption[0] != RRO_Default && RootRotationOption[1] != RRO_Default && RootRotationOption[2] != RRO_Default)
		{
			CurrentFrameAtom.Rotation = FirstFrameAtom.Rotation;
		}
		// Do we need to lock at least one axis of the bone's rotation to the first frame's value?
		else if( RootRotationOption[0] != RRO_Default || RootRotationOption[1] != RRO_Default || RootRotationOption[2] != RRO_Default )
		{
			FQuat	MeshToCompQuat = new(MeshToCompTM);

			// Find delta between current frame and first frame
			FQuat	CompFirstQuat	= MeshToCompQuat * FirstFrameAtom.Rotation;
			FQuat	CompCurrentQuat	= MeshToCompQuat * CurrentFrameAtom.Rotation;
			FQuat	CompDeltaQuat	= CompCurrentQuat * (-CompFirstQuat);
			CompDeltaQuat.Normalize();

			FRotator CompDeltaRot = FQuatRotationTranslationMatrix(CompDeltaQuat, FVector(0f)).Rotator();

			// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) channels in mesh space
			if( RootRotationOption[0] != RRO_Default )
			{
				CompDeltaRot.Roll	= 0;
			}
			if( RootRotationOption[1] != RRO_Default )
			{
				CompDeltaRot.Pitch	= 0;
			}
			if( RootRotationOption[2] != RRO_Default )
			{
				CompDeltaRot.Yaw	= 0;
			}

			// Use new delta and first frame to find out new current rotation.
			FQuat	CompNewDeltaQuat	= CompDeltaRot.Quaternion();
			FQuat	CompNewCurrentQuat	= CompNewDeltaQuat * CompFirstQuat;
			CompNewCurrentQuat.Normalize();

			CurrentFrameAtom.Rotation	= (-MeshToCompQuat) * CompNewCurrentQuat;
			CurrentFrameAtom.Rotation.Normalize();
		}

		// Lock full bone translation to first frame
		if( RootBoneOption[0] != RBA_Default && RootBoneOption[1] != RBA_Default && RootBoneOption[2] != RBA_Default )
		{
			CurrentFrameAtom.Translation = FirstFrameAtom.Translation;

#if false//0
			debugf(TEXT("%3.2f Lock Root Bone to first frame translation: %s"), GWorld.GetTimeSeconds(), *FirstFrameAtom.Translation.ToString());
#endif
		}
		// Do we need to lock at least one axis of the bone's translation to the first frame's value?
		else if( RootBoneOption[0] != RBA_Default || RootBoneOption[1] != RBA_Default || RootBoneOption[2] != RBA_Default )
		{
			FVector CompCurrentFrameTranslation = MeshToCompTM.TransformNormal(CurrentFrameAtom.Translation);
			FVector	CompFirstFrameTranslation	= MeshToCompTM.TransformNormal(FirstFrameAtom.Translation);

			// Lock back to first frame position any of the X, Y, Z axis
			if( RootBoneOption[0] != RBA_Default  )
			{
				CompCurrentFrameTranslation.X = CompFirstFrameTranslation.X;
			}
			if( RootBoneOption[1] != RBA_Default  )
			{
				CompCurrentFrameTranslation.Y = CompFirstFrameTranslation.Y;
			}
			if( RootBoneOption[2] != RBA_Default  )
			{
				CompCurrentFrameTranslation.Z = CompFirstFrameTranslation.Z;
			}

			// convert back to mesh space
			CurrentFrameAtom.Translation = MeshToCompTM.InverseTransformNormal(CompCurrentFrameTranslation);
		}
	}				
}

public virtual void IssueNotifies(float DeltaTime)
{
	// If no sequence - do nothing!
	if(!AnimSeq)
	{
		return;
	}

	// Do nothing if there are no notifies to play.
	int NumNotifies = AnimSeq.Notifies.Num();
	if(NumNotifies == 0)
	{
		return;
	}


	// Total interval we're about to proceed CurrentTime forward  (right after this IssueNotifies routine)
	float TimeToGo = DeltaTime; 

	// First, find the next notify we are going to hit.
	int NextNotifyIndex = INDEX_NONE;
	float TimeToNextNotify = BIG_NUMBER;
	float WorkTime = BIG_NUMBER;

	// Note - if there are 2 notifies with the same time, it starts with the lower index one.
	for(int i=0; i<NumNotifies; i++)
	{
		float NotifyEventTime = AnimSeq.Notifies[i].Time;
		float TryTimeToNotify = NotifyEventTime - CurrentTime;
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
		check(!bLooping);
		return;
	}

	// Wind current time to first notify.
	TimeToGo -= TimeToNextNotify;

	// Set flag to show we are firing notifies.
	bIsIssuingNotifies = TRUE;
	// Backup SeqNode, in case it gets changed during a notify, so we can process them all.
	AnimSequence AnimSeqNotify = AnimSeq;

	// Then keep walking forwards until we run out of time.
	while( TimeToGo > 0.0f )
	{
		//debugf( TEXT("NOTIFY: %d %s"), NextNotifyIndex, *(AnimSeq.Notifies(NextNotifyIndex).Comment) );

		// Execute this notify. NextNotifyIndex will be the soonest notify inside the current TimeToGo interval.
		AnimNotify AnimNotify = AnimSeqNotify.Notifies[NextNotifyIndex].Notify;
		if( AnimNotify )
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
				bIsIssuingNotifies = FALSE;
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

	bIsIssuingNotifies = FALSE;
}

///<summary>
/// Start the current animation playing. This just sets the bPlaying flag to true, so that TickAnim will move CurrentTime forwards. 
///</summary>
public override void PlayAnim(bool bInLoop, float InRate, float StartTime)
{
	CurrentTime		= StartTime;
	PreviousTime	= StartTime;
	Rate			= InRate;
	bLooping		= bInLoop;
	bPlaying		= TRUE;

	if( bForceRefposeWhenNotPlaying && SkelComponent.bForceRefpose != 0)
	{
		SkelComponent.SetForceRefPose(FALSE);
	}

	if( bCauseActorAnimPlay && SkelComponent.Owner )
	{
		SkelComponent.Owner.OnAnimPlay(this);
	}
}

///<summary>
/// Stop playing current animation. Will set bPlaying to false. 
///</summary>
public override void StopAnim()
{
	bPlaying = false;
}

///<summary>
/// 
/// Set the CurrentTime to the supplied position. 
/// If bFireNotifies is true, this will fire any notifies between current and new time.
///</summary>
public virtual void SetPosition(float NewTime, bool bFireNotifies)
{
	// Ensure NewTime lies within sequence length.
	float AnimLength = AnimSeq ? AnimSeq.SequenceLength : 0f;
	NewTime = Clamp(NewTime, 0f, AnimLength+KINDA_SMALL_NUMBER);

	// Find the amount we are moving.
	float DeltaTime = NewTime - CurrentTime;

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
	CachedBoneAtoms.Reset();
}


///<summary>
/// 
/// Get normalized position, from 0f to 1f.
///</summary>
public virtual float GetNormalizedPosition()
{
	if( AnimSeq && AnimSeq.SequenceLength > 0f )
	{
		return Clamp(CurrentTime / AnimSeq.SequenceLength, 0f, 1f);
	}

	return 0f;
}

///<summary>
/// 
/// Finds out normalized position of a synchronized node given a relative position of a group. 
/// Takes into account node's relative SynchPosOffset.
///</summary>
public virtual float FindNormalizedPositionFromGroupRelativePosition(float GroupRelativePosition)
{
	float NormalizedPosition = appFmod(GroupRelativePosition + SynchPosOffset, 1f);
	if( NormalizedPosition < 0f )
	{
		NormalizedPosition += 1f;
	}

	return NormalizedPosition;
}


///<summary>
/// Returns the global play rate of this animation. Taking into account all Rate Scales 
///</summary>
public virtual float GetGlobalPlayRate()
{
	// AnimNodeSequence play rate
	float GlobalRate = Rate * SkelComponent.GlobalAnimRateScale;

	// AnimSequence play rate
	if( AnimSeq )
	{
		GlobalRate *= AnimSeq.RateScale;
	}

	// AnimGroup play rate
	if( SynchGroupName != NAME_None && SkelComponent )
	{
		AnimTree RootNode = (SkelComponent.Animations) as AnimTree;
		if( RootNode )
		{
			int GroupIndex = RootNode.GetGroupIndex(SynchGroupName);
			if( GroupIndex != INDEX_NONE )
			{
				GlobalRate *= RootNode.AnimGroups[GroupIndex].RateScale;
			}
		}
	}

	return GlobalRate;
}


public virtual float GetAnimPlaybackLength()
{
	if( AnimSeq )
	{
		float GlobalPlayRate = GetGlobalPlayRate();
		if( GlobalPlayRate != 0f )
		{
			return AnimSeq.SequenceLength / GlobalPlayRate;
		}
	}

	return 0f;
}

///<summary>
/// 
/// Returns in seconds the time left until the animation is done playing. 
/// This is assuming the play rate is not going to change.
///</summary>
public virtual float GetTimeLeft()
{
	if( AnimSeq )
	{
		float GlobalPlayRate = GetGlobalPlayRate();
		if( GlobalPlayRate > 0f )
		{
			return Max(AnimSeq.SequenceLength - CurrentTime, 0f) / GlobalPlayRate;
		}
	}

	return 0f;
}
}

public partial class Actor
{
////////////////////////////////
// Actor latent function
#if UNUSED
public virtual void FinishAnim(AnimNodeSequence SeqNode)
{
	GetStateFrame()->LatentAction = EPOLL_FinishAnim;
	LatentSeqNode  = SeqNode;
}

public virtual void execPollFinishAnim( ref FFrame Stack, RESULT_DECL )
{
	// Block as long as LatentSeqNode is present and playing.
	if( !LatentSeqNode || !LatentSeqNode.bPlaying )
	{
		GetStateFrame()->LatentAction = 0;
		LatentSeqNode = null;
	}
}
#endif
}
//IMPLEMENT_FUNCTION( AActor, EPOLL_FinishAnim, execPollFinishAnim );


public partial class AnimNodeSequenceBlendBase
{
///<summary>
///**********************************************************************************
/// UAnimNodeSequenceBlendBase
/// *********************************************************************************
///</summary>

public virtual void CheckAnimsUpToDate()
{
	// Make sure animations are up to date
	int		NumAnims		= Anims.Num();
			bool	bUpdatedSeqNode = FALSE;

	for(int i=0; i<NumAnims; i++)
	{
		SetAnimInfo(Anims[i].AnimName, ref Anims[i].AnimInfo);

		if( !bUpdatedSeqNode && Anims[i].AnimInfo.AnimSeq != null )
		{
			// Ensure AnimNodeSequence playback compatibility by setting one animation
			// The node will use this animation for timing and notifies.
			SetAnim(Anims[i].AnimName);
			bUpdatedSeqNode = (AnimSeq != null);
		}
	}
}


///<summary>
///
/// Init anim tree.
/// Make sure animation references are up to date.
///</summary>
public override void InitAnim(SkeletalMeshComponent MeshComp, AnimNodeBlendBase Parent)
{
	// Call Super version first, because that's where SkeletalMeshComponent reference is set (see UAnimNode.InitAnim()).
	base.InitAnim(MeshComp, Parent);

#if false//0
	debugf(TEXT("* InitAnim on %s"), *GetFName());
#endif

	// Make sure animations are up to date
	CheckAnimsUpToDate();
}


///<summary>
/// AnimSets have been updated, update all animations 
///</summary>
public override void AnimSetsUpdated()
{
	base.AnimSetsUpdated();

	// Make sure animations are up to date
	CheckAnimsUpToDate();
}

///<summary>
///
/// A property has been changed from the editor
/// Make sure animation references are up to date.
///</summary>
public override void PostEditChange(Property PropertyThatChanged)
{
#if false//0
	debugf(TEXT("* PostEditChange on %s"), *GetFName());
#endif

	// Make sure animations are up to date
	CheckAnimsUpToDate();

	base.PostEditChange(PropertyThatChanged);
}

///<summary>
/// 
/// Set a new animation by name.
/// This will find the UAnimationSequence by name, from the list of AnimSets specified in the SkeletalMeshComponent and cache it.
///</summary>
public virtual void SetAnimInfo(name InSequenceName, ref AnimInfo InAnimInfo)
{
	bool bFailed = FALSE;

#if false//0
	debugf(TEXT("** SetAnimInfo %s on %s"), InSequenceName, Name);
#endif

	// if not valid, reset
	if( InSequenceName == NAME_None || !SkelComponent || !SkelComponent.SkeletalMesh )
	{
		bFailed = TRUE;
	}

	if( !bFailed )
	{
		InAnimInfo.AnimSeq = SkelComponent.FindAnimSequence(InSequenceName);
		if( InAnimInfo.AnimSeq != null )
		{
			InAnimInfo.AnimSeqName = InSequenceName;
			#if UNUSED
			AnimSet AnimSet = InAnimInfo.AnimSeq.GetAnimSet();

			InAnimInfo.AnimLinkupIndex = AnimSet.GetMeshLinkupIndex(SkelComponent.SkeletalMesh);

			check(InAnimInfo.AnimLinkupIndex != INDEX_NONE);
			check(InAnimInfo.AnimLinkupIndex < AnimSet.LinkupCache.Num());

			ref AnimSetMeshLinkup AnimLinkup = ref AnimSet.LinkupCache[InAnimInfo.AnimLinkupIndex];

			check(AnimLinkup.SkelMeshLinkupGUID == SkelComponent.SkeletalMesh.SkelMeshGUID);
			check(AnimLinkup.BoneToTrackTable.Num() == SkelComponent.SkeletalMesh.RefSkeleton.Num());
			check(AnimLinkup.BoneUseAnimTranslation.Num() == SkelComponent.SkeletalMesh.RefSkeleton.Num());
			#endif
		}
		else
		{
			bFailed = TRUE;
		}
	}

	if( bFailed )
	{
		// If InSequenceName == NAME_None, it's not really error... it was intentional! :)
		if( InSequenceName != NAME_None )
		{
			Actor Owner = SkelComponent ? SkelComponent.Owner : null;

			debugf(/*NAME_Warning,*/ TEXT("%s - Failed, with animsequence '%s' on SkeletalMeshComponent: '%s' whose owner is: '%s' and is of type '%s'"), 
				Name, 
				InSequenceName.ToString(), 
				SkelComponent ? SkelComponent.Name : TEXT("None"),
				Owner ? Owner.Name : TEXT("None"),
				SkelComponent ? SkelComponent.TemplateName.ToString() : TEXT("None")
				);
		}

		InAnimInfo.AnimSeqName		= NAME_None;
		InAnimInfo.AnimSeq			= null;
		InAnimInfo.AnimLinkupIndex	= INDEX_NONE;
	}
}

///<summary>
///
/// Blends together the animations of this node based on the Weight in each element of the Anims array.
/// 
/// @param	Atoms			Output array of relative bone transforms.
/// @param	DesiredBones	Indices of bones that we want to return. Note that bones not in this array will not be modified, so are not safe to access! 
/// 							This array must be in strictly increasing order.
///</summary>
public override void GetBoneAtoms(ref Span<BoneAtom> Atoms, ref array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// See if results are cached.
	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	int NumAnims = Anims.Num();

#if false//!FINAL_RELEASE && 1
	if( NumAnims == 0 )
	{
		debugf(TEXT("UAnimNodeSequenceBlendBase.GetBoneAtoms - %s - Anims array is empty!"), *GetName());
		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	 = false;
		FillWithRefPose(Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}
#endif

#if false//!FINAL_RELEASE && 1
	float TotalWeight = 0f;

	for(int i=0; i<NumAnims; i++)
	{
		TotalWeight += Anims[i].Weight;
	}

	// Check all children weights sum to 1.0
	if( Abs(TotalWeight - 1f) > ZERO_ANIMWEIGHT_THRESH )
	{
		debugf(TEXT("WARNING: UAnimNodeSequenceBlendBase (%s) has Children weights which do not sum to 1.0."), *GetName());

		for(int i=0; i<NumAnims; i++)
		{
			debugf(TEXT("Pose: %d Weight: %f"), i, Anims[i].Weight);
		}

		debugf(TEXT("Total Weight: %f"), TotalWeight);
		//@todo - adjust first node weight to 

		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	 = false;
		FillWithRefPose(Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}
#endif

	// Find index of the last child with a non-zero weight.
	int LastChildIndex = INDEX_NONE;
	for(int i=0; i<NumAnims; i++)
	{
		if( Anims[i].Weight > ZERO_ANIMWEIGHT_THRESH )
		{
			// If this is the only child with any weight, pass Atoms array into it directly.
			if( Anims[i].Weight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				GetAnimationPose(Anims[i].AnimInfo.AnimSeq, ref Anims[i].AnimInfo.AnimLinkupIndex, ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
				SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
				return;
			}
			LastChildIndex = i;
		}
	}
	check(LastChildIndex != INDEX_NONE);

	// We don't allocate this array until we need it.
	Span<BoneAtom> ChildAtoms = stackalloc BoneAtom[SkelComponent.SkeletalMesh.RefSkeleton.Num()];
	bool init = false;
	bool bNoChildrenYet = TRUE;

	// Root Motion
	BoneAtom ExtractedRootMotion = default;

	// Iterate over each child getting its atoms, scaling them and adding them to output (Atoms array)
	for(int i=0; i<=LastChildIndex; i++)
	{
		// If this child has non-zero weight, blend it into accumulator.
		if( Anims[i].Weight > ZERO_ANIMWEIGHT_THRESH )
		{
			// Do need to request atoms, so allocate array here.
			if( init == false )
			{
				init = true;
				int NumAtoms = SkelComponent.SkeletalMesh.RefSkeleton.Num();
				check(NumAtoms == Atoms.Length);
				//ChildAtoms.AddCount(NumAtoms);
				for( int j = 0; j < ChildAtoms.Length; j++ )
					ChildAtoms[j] = BoneAtom.Identity;
			}

			check(ChildAtoms.Length == Atoms.Length);

			// Get Animation pose
			GetAnimationPose(Anims[i].AnimInfo.AnimSeq, ref Anims[i].AnimInfo.AnimLinkupIndex, ref ChildAtoms, ref DesiredBones, ref ExtractedRootMotion, ref bHasRootMotion);

			if( bHasRootMotion )
			{
				// Accumulate weighted Root Motion
				if( bNoChildrenYet )
				{
					RootMotionDelta = ExtractedRootMotion * Anims[i].Weight;
				}
				else
				{
					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
					if( (RootMotionDelta.Rotation | ExtractedRootMotion.Rotation) < 0f )
					{
						ExtractedRootMotion.Rotation = ExtractedRootMotion.Rotation * -1f;
					}

					RootMotionDelta.AddAssign(ExtractedRootMotion * Anims[i].Weight);
				}

				// If Last Child, normalize rotation quaternion
				if( i == LastChildIndex )
				{
					RootMotionDelta.Rotation.Normalize();
				}
		
#if false//0 // Debug Root Motion
				if( !RMD.Translation.IsZero() )
				{
					FVector RDTW = RMD.Translation * Anims[i].Weight;
					debugf(TEXT("%3.2f %s: Added weighted root motion translation: %3.2f, vect: %s"), GWorld.GetTimeSeconds(), *GetFName(), RDTW.Size(), *RDTW.ToString());
				}
#endif
			}

			for(int j=0; j<DesiredBones.Num(); j++)
			{
				int BoneIndex = DesiredBones[j];

				// We just write the first childrens atoms into the output array. Avoids zero-ing it out.
				if( bNoChildrenYet )
				{
					Atoms[BoneIndex] = ChildAtoms[BoneIndex] * Anims[i].Weight;
				}
				else
				{
					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
					if( (Atoms[BoneIndex].Rotation | ChildAtoms[BoneIndex].Rotation) < 0f )
					{
						ChildAtoms[BoneIndex].Rotation = ChildAtoms[BoneIndex].Rotation * -1f;
					}

					Atoms[BoneIndex].AddAssign(ChildAtoms[BoneIndex] * Anims[i].Weight);
				}

				// If last child - normalize the rotation quaternion now.
				if( i == LastChildIndex )
				{
					Atoms[BoneIndex].Rotation.Normalize();
				}
			}

			bNoChildrenYet = FALSE;
		}
	}

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}
}

///<summary>
///**********************************************************************************
/// UAnimNodeSequenceBlendByAim
/// *********************************************************************************
///</summary>
public partial class AnimNodeSequenceBlendByAim
{
public override void CheckAnimsUpToDate()
{
	// Make sure animations are properly set
	Anims[0].AnimName = AnimName_LU;
	Anims[1].AnimName = AnimName_LC;
	Anims[2].AnimName = AnimName_LD;
	Anims[3].AnimName = AnimName_CU;
	Anims[4].AnimName = AnimName_CC;
	Anims[5].AnimName = AnimName_CD;
	Anims[6].AnimName = AnimName_RU;
	Anims[7].AnimName = AnimName_RC;
	Anims[8].AnimName = AnimName_RD;

	base.CheckAnimsUpToDate();
}

///<summary>
/// Override this function in a subclass, and return normalized Aim from Pawn. 
///</summary>
public virtual Vector2D GetAim() 
{ 
	return Aim;
}

static float UnWindNormalizedAimAngle(float Angle)
{
	while( Angle >= 2f )
	{
		Angle -= 4f;
	}

	while( Angle < -2f )
	{
		Angle += 4f;
	}

	return Angle;
}

public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	// if not relevant enough, do not update weights
	if( !bRelevant )
	{
		base.TickAnim(DeltaSeconds, TotalWeight);
		return;
	}

	// Get Normalized Aim.
	Vector2D SafeAim = GetAim();

	// Add in rotation offset, but not in the editor
	if( /*!GIsEditor || GIsGame*/true )
	{
		if( AngleOffset.X != 0f )
		{
			SafeAim.X = UnWindNormalizedAimAngle(SafeAim.X - AngleOffset.X);
		}
		if( AngleOffset.Y != 0f )
		{
			SafeAim.Y = UnWindNormalizedAimAngle(SafeAim.Y - AngleOffset.Y);
		}
	}

	// Scale by range
	if( HorizontalRange.X != 0f && SafeAim.X < 0f )
	{
		SafeAim.X = SafeAim.X / Abs(HorizontalRange.X);
	}
	if( HorizontalRange.Y != 0f && SafeAim.X > 0f )
	{
		SafeAim.X = SafeAim.X / HorizontalRange.Y;
	}

	if( VerticalRange.X != 0f && SafeAim.Y < 0f )
	{
		SafeAim.Y = SafeAim.Y / Abs(VerticalRange.X);
	}
	if( VerticalRange.Y != 0f && SafeAim.Y > 0f )
	{
		SafeAim.Y = SafeAim.Y / VerticalRange.Y;
	}

	// Make sure we're using correct values within legal range.
	SafeAim.X = Clamp(SafeAim.X, -1f, +1f);
	SafeAim.Y = Clamp(SafeAim.Y, -1f, +1f);

	// Animation update
	if( SafeAim.X >= 0f && SafeAim.Y >= 0f ) // Up Right
	{
		// Calculate weight of each relevant animation
		Anims[4].Weight = BiLerp(1f, 0f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[7].Weight = BiLerp(0f, 1f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[3].Weight = BiLerp(0f, 0f, 1f, 0f, SafeAim.X, SafeAim.Y);
		Anims[6].Weight = BiLerp(0f, 0f, 0f, 1f, SafeAim.X, SafeAim.Y);

		// The rest is set to zero
		Anims[0].Weight = 0f;
		Anims[1].Weight = 0f;
		Anims[2].Weight = 0f;
		Anims[5].Weight = 0f;
		Anims[8].Weight = 0f;
	}
	else if( SafeAim.X >= 0f && SafeAim.Y < 0f ) // Bottom Right
	{
		SafeAim.Y += 1f;

		// Calculate weight of each relevant animation
		Anims[5].Weight = BiLerp(1f, 0f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[8].Weight = BiLerp(0f, 1f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[4].Weight = BiLerp(0f, 0f, 1f, 0f, SafeAim.X, SafeAim.Y);
		Anims[7].Weight = BiLerp(0f, 0f, 0f, 1f, SafeAim.X, SafeAim.Y);

		// The rest is set to zero
		Anims[0].Weight = 0f;
		Anims[1].Weight = 0f;
		Anims[2].Weight = 0f;
		Anims[3].Weight = 0f;
		Anims[6].Weight = 0f;
	}
	else if( SafeAim.X < 0f && SafeAim.Y >= 0f ) // Up Left
	{
		SafeAim.X += 1f;

		// Calculate weight of each relevant animation
		Anims[1].Weight = BiLerp(1f, 0f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[4].Weight = BiLerp(0f, 1f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[0].Weight = BiLerp(0f, 0f, 1f, 0f, SafeAim.X, SafeAim.Y);
		Anims[3].Weight = BiLerp(0f, 0f, 0f, 1f, SafeAim.X, SafeAim.Y);

		// The rest is set to zero
		Anims[2].Weight = 0f;
		Anims[5].Weight = 0f;
		Anims[6].Weight = 0f;
		Anims[7].Weight = 0f;
		Anims[8].Weight = 0f;
	}
	else if( SafeAim.X < 0f && SafeAim.Y < 0f ) // Bottom Left
	{
		SafeAim.X += 1f;
		SafeAim.Y += 1f;

		// Calculate weight of each relevant animation
		Anims[2].Weight = BiLerp(1f, 0f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[5].Weight = BiLerp(0f, 1f, 0f, 0f, SafeAim.X, SafeAim.Y);
		Anims[1].Weight = BiLerp(0f, 0f, 1f, 0f, SafeAim.X, SafeAim.Y);
		Anims[4].Weight = BiLerp(0f, 0f, 0f, 1f, SafeAim.X, SafeAim.Y);

		// The rest is set to zero
		Anims[0].Weight = 0f;
		Anims[3].Weight = 0f;
		Anims[6].Weight = 0f;
		Anims[7].Weight = 0f;
		Anims[8].Weight = 0f;
	}

	base.TickAnim(DeltaSeconds, TotalWeight);

	static float BiLerp(float P00, float P10, float P01, float P11, float FracX, float FracY)
	{
		return Lerp( Lerp( P00, P10, FracX ), Lerp( P01, P11, FracX ), FracY );
	}
}


public virtual float GetSliderPosition(int SliderIndex, int ValueIndex)
{
	check(SliderIndex == 0);
	check(ValueIndex == 0 || ValueIndex == 1);

	if( ValueIndex == 0 )
	{
		return (0.5f * Aim.X) + 0.5f;
	}
	else
	{
		return ((-0.5f * Aim.Y) + 0.5f);
	}
}

public virtual void HandleSliderMove(int SliderIndex, int ValueIndex, float NewSliderValue)
{
	check(SliderIndex == 0);
	check(ValueIndex == 0 || ValueIndex == 1);

	if( ValueIndex == 0 )
	{
		Aim.X = (NewSliderValue - 0.5f) * 2f;
	}
	else
	{
		Aim.Y = (NewSliderValue - 0.5f) * -2f;
	}
}

#if UNUSED
public virtual String GetSliderDrawValue(int SliderIndex)
{
	check(SliderIndex == 0);
	return String.Printf(TEXT("%0.2f,%0.2f"), Aim.X, Aim.Y);
}
#endif
}

}
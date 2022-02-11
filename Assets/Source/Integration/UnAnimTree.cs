// Uncomment if you want to implement unused stuff
//#define UNUSED

namespace MEdge.Engine
{
	using System;
	using Core;
	using static Source.DecFn;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FVector4 = Core.Object.Vector4;
	using FRotator = Core.Object.Rotator;
	using FQuat = Core.Object.Quat;
	using FBoneAtom = AnimNode.BoneAtom;
	using UBOOL = System.Boolean;
	using BoneAtom = AnimNode.BoneAtom;
	using FMatrix = Core.Object.Matrix;
	using BYTE = System.Byte;
	using UINT = System.UInt32;
	using static Actor.EPhysics;
	using static Actor.EAxis;
	using static SkelControlBase.EBoneControlSpace;
	using static SkeletalMeshComponent.ERootMotionMode;
	using static SkeletalMeshComponent.ERootMotionRotationMode;
	using static AnimNodeAimOffset.EAnimAimDir;



	public partial class SkeletalMeshComponent
	{
		public void BuildComposePriorityList(ref array<BYTE> PriorityList)
		{
			if( !SkeletalMesh || !Animations )
			{
				return;
			}

			AnimTree	Tree		= Animations as AnimTree;
			INT			NumBones	= SkeletalMesh.RefSkeleton.Num();

			// If the first node of the Animation Tree if not a UAnimTree, then skip.
			// This can happen in the AnimTree editor when previewing a node different than the root.
			if( !Tree )
			{
				return;
			}

			// reinitialize list
			PriorityList.Empty();
			PriorityList.AddZeroed(NumBones);

			const BYTE Flag = 1;

			for(INT i=0; i<Tree.PrioritizedSkelBranches.Num(); i++)
			{
				name BoneName = Tree.PrioritizedSkelBranches[i];

				if( BoneName != NAME_None )
				{
					INT BoneIndex = MatchRefBone(BoneName);

					if( BoneIndex != INDEX_NONE )
					{
						// flag selected bone.
						PriorityList[BoneIndex] = Flag;

						// flag all parents up until root node to be evaluated.
						if( BoneIndex > 0 )
						{
							INT TestBoneIndex = SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;
							PriorityList[TestBoneIndex] = Flag;
							while( TestBoneIndex > 0 )
							{
								TestBoneIndex = SkeletalMesh.RefSkeleton[TestBoneIndex].ParentIndex;
								PriorityList[TestBoneIndex] = Flag;
							}
						}

						// Flag all child bones. We rely on the fact that they are in strictly increasing order
						// so we start at the bone after BoneIndex, up until we reach the end of the list
						// or we find another bone that has a parent before BoneIndex.
						INT	Index = BoneIndex + 1;
						if(Index < NumBones)
						{
							INT ParentIndex	= SkeletalMesh.RefSkeleton[Index].ParentIndex;

							while( Index < NumBones && ParentIndex >= BoneIndex )
							{
								PriorityList[Index]	= Flag;
								ParentIndex			= SkeletalMesh.RefSkeleton[Index].ParentIndex;

								Index++;
							}
						}
					}
				}
			}

		#if false
			debugf(TEXT("USkeletalMeshComponent.BuildComposePriorityList"));
			for(INT i=0; i<PriorityList.Num(); i++)
			{
				debugf(TEXT(" Bone: %3d, Flag: %3d"), i, PriorityList(i));
			}
		#endif

		}



		// Export USkeletalMeshComponent::execMatchRefBone(FFrame&, void* const)
		public virtual /*native final function */ int MatchRefBone( name BoneName )
		{
			return Array.IndexOf(this.AnimSets[0].TrackBoneNames._items, BoneName);
			
			int BoneIndex = INDEX_NONE;
			if ( BoneName != NAME_None && SkeletalMesh )
			{
				BoneIndex = SkeletalMesh.MatchRefBone( BoneName );
			}

			return BoneIndex;
		}



		// Export USkeletalMeshComponent::execForceSkelUpdate(FFrame&, void* const)
		public virtual /*native final function */void ForceSkelUpdate()
		{
			if (IsAttached())
			{
				// easiest way to make sure everything works is to temporarily pretend we've been recently rendered
				FLOAT OldRenderTime = LastRenderTime;
				LastRenderTime = GWorld.GetWorldInfo().TimeSeconds;

				UpdateLODStatus();
				UpdateSkelPose();
				ConditionalUpdateTransform(); 

				LastRenderTime = OldRenderTime;
			}
		}
		
		
		
		public override void BeginPlay()
		{
			base.BeginPlay();

			UBOOL bNewAnim = false;
			if(!Animations && AnimTreeTemplate)
			{
				NativeMarkers.MarkUnimplemented("Would need to implement proper copy instead of straight assign but its fine for our use case");
				Animations = AnimTreeTemplate;
				//Animations = AnimTreeTemplate.CopyAnimTree(this);
				bNewAnim = true;
			}

			// If we created a new AnimTree, init it now.
			if(bNewAnim)
			{
				InitAnimTree();

				UpdateSkelPose();
				ConditionalUpdateTransform();
			}

			// Call BeginPlay on any attached components.
			for(UINT AttachmentIndex = 0;AttachmentIndex < (UINT)Attachments.Num();AttachmentIndex++)
			{
				ref Attachment Attachment = ref Attachments[AttachmentIndex];
				if(Attachment.Component)
				{
					Attachment.Component.ConditionalBeginPlay();
				}
			}
		}
		
		
		
		public void InitAnimTree(bool bForceReInit=true)
		{
			// If not already initialised (or we are forcing a re-init), and we have an AnimTree
			if((bForceReInit || !bAnimTreeInitialised) && Animations)
			{
				// Try a cast to a tree.
				AnimTree Tree = (Animations) as AnimTree;

				// Reset all nodes
				array<AnimNode> TreeNodes = new();
				Animations.GetNodes( ref TreeNodes );

				for(int i=0; i<TreeNodes.Num(); i++)
				{
					TreeNodes[i].ParentNodes.Empty();
					TreeNodes[i].SkelComponent		= null;
					TreeNodes[i].NodeTickTag		= TickTag;
					TreeNodes[i].NodeTotalWeight	= 0f;
				}

				// Initialise all nodes in tree
				Animations.InitAnim(this, null);

				// Build array in tick order. Start by adding root node and call from there.
				TickTag++;
				AnimTickArray.Reset();
				AnimTickArray.Reserve(TreeNodes.Num());
				AnimTickArray.AddItem(Animations);
				Animations.NodeTickTag = TickTag;
				Animations.BuildTickArray(ref AnimTickArray);

				// If its an AnimTree, initialise the MorphNodes.
				if(Tree)
				{
					array<MorphNodeBase> MorphNodes = new();
					Tree.GetMorphNodes(ref MorphNodes);

					for(int i=0; i<MorphNodes.Num(); i++)
					{
						MorphNodes[i].SkelComponent = null;
					}

					Tree.InitTreeMorphNodes(this);
				}
		
				// Initialise the skeletal controls on the tree.
				InitSkelControls();

				// if there's an Owner, notify it that our AnimTree was initialized so it can cache references to controllers and such
				if (Tree != null && Owner != null)
				{
					Owner.PostInitAnimTree(this);
				}

				bAnimTreeInitialised = true;
			}
		}



		public void TickSkelControls( float DeltaSeconds )
		{
			//SCOPE_CYCLE_COUNTER(STAT_SkelControlTickTime);

			bool bRenderedRecently = true;//GWorld.GetTimeSeconds() - LastRenderTime < 1.f;
			AnimTree AnimTree = (Animations) as AnimTree;
			if(AnimTree)
			{
				for(int i=0; i<AnimTree.SkelControlLists.Num(); i++)
				{
					SkelControlBase Control = AnimTree.SkelControlLists[i].ControlHead;
					while(Control)
					{
						if ( Control.ControlTickTag != TickTag && (bRenderedRecently || !Control.bIgnoreWhenNotRendered))
						{
							Control.ControlTickTag = TickTag;
							Control.TickSkelControl(DeltaSeconds, this);
						}
						Control = Control.NextControl;
					}
				}
			}
		}
		
		public void TickAnimNodes(float DeltaTime)
		{
			TickTag++;
			check(Animations.SkelComponent == this);
			Animations.TotalWeightAccumulator = 1f;

			for(int i=0; i<AnimTickArray.Num(); i++)
			{
				AnimNode Node = AnimTickArray[i];
				check(Node);

				// Ensure NodeTotalWeight is no more than 1.0. This can happen when using AnimNodeBlendPerBone etc.
				Node.NodeTotalWeight = Min(Node.TotalWeightAccumulator, 1f);

				// Reset TotalWeightAccumulator for next frame
				Node.TotalWeightAccumulator	= 0f;
				// Clear bJustBecameRelevant flag.
				Node.bJustBecameRelevant		= FALSE;

				// Call final blend relevancy notifications
				if( !Node.bRelevant )
				{
					if( Node.NodeTotalWeight > ZERO_ANIMWEIGHT_THRESH )
					{
						Node.OnBecomeRelevant();
						Node.bRelevant				= TRUE;
						Node.bJustBecameRelevant	= TRUE;
					}
				}
				else
				{
					if( Node.NodeTotalWeight <= ZERO_ANIMWEIGHT_THRESH )
					{
						Node.OnCeaseRelevant();
						Node.bRelevant = FALSE;
					}
				}

				// If we are not skipping because of zero weight, call the Tick function.
				// Also check if all anims are paused, or this is ticked anyway
				if( (Node.bRelevant || !Node.bSkipTickWhenZeroWeight) && (!bPauseAnims || Node.bTickDuringPausedAnims) )
				{
					Node.NodeTickTag = TickTag;

		#if !FINAL_RELEASE && SHOW_ANIMNODE_TICK_TIMES
					DOUBLE Start = 0.f;
					if( GShouldLogOutAFrameOfSkelCompTick )
					{
						Start = appSeconds();
					}
		#endif

					// Call Tick() on node, to update child weights.
					Node.TickAnim(DeltaTime, Node.NodeTotalWeight);

		#if !FINAL_RELEASE && SHOW_ANIMNODE_TICK_TIMES
					if( GShouldLogOutAFrameOfSkelCompTick )
					{
						DOUBLE End = appSeconds();
						debugf(TEXT("-- %s - %s:\t%fms"), SkeletalMesh?*SkeletalMesh.GetName():TEXT("None"), *Node.GetName(), (End-Start)*1000.f);
					}
		#endif
				}
			}

			// After all nodes have been ticked, and weights have been updated, take another pass for AnimNodeSequence groups.
			// (Anim Synchronization, and notification groups).
			AnimTree AnimTree = (Animations) as AnimTree;
			if( AnimTree && !bPauseAnims)
			{
				//SCOPE_CYCLE_COUNTER(STAT_AnimSyncGroupTime);
				AnimTree.UpdateAnimNodeSeqGroups(DeltaTime);
			}
		}
		
		public override void Tick(float DeltaTime)
		{
			//SCOPE_CYCLE_COUNTER(STAT_SkelComponentTickTime);

			DeltaTime *= Owner ? Owner.CustomTimeDilation : 1f;
			
			//var GWorld = UWorld.Instance;

			// If in-game, tick all animation channels in our anim nodes tree. Dont want to play animation in level editor.
			bool bHasBegunPlay = GWorld.HasBegunPlay();

			#if UNUSED
			if( MeshObject && Animations && bHasBegunPlay )
			#else
			if( Animations && bHasBegunPlay )
			#endif
			{
				//SCOPE_CYCLE_COUNTER(STAT_AnimTickTime);
				TickAnimNodes(DeltaTime);
				TickSkelControls(DeltaTime);
			}
			
			// See if this mesh was rendered recently.
			bool bRecentlyRendered = (LastRenderTime > GWorld.GetWorldInfo().TimeSeconds - 1.0f);
			
			#if UNUSED
			// If we have cloth, apply wind forces to make it flutter, each frame.
			if(ClothSim)
			{
				// Do 'auto freeezing'
				if(bAutoFreezeClothWhenNotRendered)
				{
					// If we have not been rendered for a while, and are not yet frozen, do it now
					if(!bRecentlyRendered && !bClothFrozen)
					{
						SetClothFrozen(TRUE);
					}
					// If we have been rendered recently, and are still frozen, unfreeze.
					else if(bRecentlyRendered && bClothFrozen)
					{
						SetClothFrozen(FALSE);
					}
				}

				// If not frozen - update wind forces.
				if(!bClothFrozen)
				{
					UpdateClothWindForces(DeltaTime);
				}
			}
			#endif

			// Save this off before we call BeginDeferredUpdateTransform.
			//bool bNeedsUpdateTransform = NeedsUpdateTransform();

			// See if we are going to need to update kinematics
			bool bUpdateKinematics = (bUseSingleBodyPhysics == 0 && PhysicsAssetInstance && bUpdateKinematicBonesFromAnimation && !bNotUpdatingKinematicDueToDistance);

			// If we need it, find the up-to-date transform for this component. 
			Matrix ParentTransform = FMatrix.Identity;
			if((bUpdateKinematics || bForceUpdateAttachmentsInTick) && bNeedsUpdateTransform && (Owner != NULL))
			{
				// We have a special case for when its attached to another SkelComp.
				if( AttachedToSkelComponent )
				{
					throw new Exception();
					//ParentTransform = AttachedToSkelComponent.CalcAttachedSkelCompMatrix(this);
				}
				else
				{
					ParentTransform = Owner.LocalToWorld();
				}
			}

			// Update component's LOD settings
			bool bLODHasChanged = UpdateLODStatus();

			// We can skip doing some work when using PHYS_RigidBody and we have physics that are asleep
			if(Owner && Owner.Physics == PHYS_RigidBody && (BodyInstance || PhysicsAssetInstance))
			{
				// Update count of how long physics for this actor has been asleep.
				bool bAsleep = !RigidBodyIsAwake();
				if(bAsleep)
				{
					FramesPhysicsAsleep++;
				}
				else
				{
					FramesPhysicsAsleep = 0;
				}
			}
			else
			{
				FramesPhysicsAsleep = 0;
			}

			// If we have been recently rendered, and bForceRefPose has been on for at least a frame, or the LOD changed, update bone matrices.
			if(((bRecentlyRendered || bUpdateSkelWhenNotRendered) && !(bForceRefpose.AsBool() && bOldForceRefPose.AsBool())) || bLODHasChanged)
			{
		#if SHOW_SKELETAL_MESH_COMPONENT_TICK_TIME || LOOKING_FOR_PERF_ISSUES
				DOUBLE UpdateSkelPoseStart = appSeconds();	
		#endif

				// Do not update bones if we are taking bone transforms from another SkelMeshComp
				if(!ParentAnimComponent && !bNoSkeletonUpdate.AsBool())
				{
					// Update the mesh-space bone transforms held in SpaceBases array from animation data.
					UpdateSkelPose( DeltaTime ); 
				}

				// If desired, force attachments into the correct position now.
				if(bForceUpdateAttachmentsInTick)
				{
					if(NeedsUpdateTransform() && Owner != NULL)
					{
						ConditionalUpdateTransform(ParentTransform);
					}
					else
					{
						ConditionalUpdateTransform();
					}
				}
				// Otherwise, make sure that we do call UpdateTransform later this frame, as that is where transforms are sent to rendering thread
				else
				{
					BeginDeferredUpdateTransform();
				}

		#if SHOW_SKELETAL_MESH_COMPONENT_TICK_TIME || LOOKING_FOR_PERF_ISSUES
				DOUBLE UpdateSkelPoseStop = (appSeconds() - UpdateSkelPoseStart) * 1000.f;
				if( GShouldLogOutAFrameOfSkelCompTick == TRUE )
				{
					debugf( TEXT( "USkeletalMeshComponent:  %s   SkelMesh:  %s  Owner: %s, UpdateSkelPoseS: %f" ), *this.GetPathName(), *SkeletalMesh.GetPathName(), *GetOwner().GetName(), UpdateSkelPoseStop );
				}
		#endif
			}

			// Update bOldForceRefPose
			bOldForceRefPose = bForceRefpose;

			// If desired, update physics bodies associated with skeletal mesh component to match.
			// should not be in the above bUpdateSkelWhenNotRendered block so that physics gets properly updated if the bodies are moving due to other sources (e.g. actor movement)
			if(bUpdateKinematics)
			{
				Matrix CurrentLocalToWorld;
				if(bNeedsUpdateTransform && Owner != NULL)
				{
					CurrentLocalToWorld = CalcCurrentLocalToWorld(ParentTransform);
				}
				else
				{
					CurrentLocalToWorld = LocalToWorld;
				}

				UpdateRBBonesFromSpaceBases(CurrentLocalToWorld, FALSE, FALSE);
			}
		}



		UBOOL UpdateLODStatus()
		{
			NativeMarkers.MarkUnimplemented("Not necessary");
			return false;
		}



		FMatrix CalcCurrentLocalToWorld(in FMatrix ParentMatrix)
		{
			FMatrix ResultMatrix = ParentMatrix;

			if(AbsoluteTranslation)
			{
				ResultMatrix.M[3,0] = ResultMatrix.M[3,1] = ResultMatrix.M[3,2] = 0.0f;
			}

			if(AbsoluteRotation || AbsoluteScale)
			{
				FVector	X = new(ResultMatrix.M[0,0],ResultMatrix.M[1,0],ResultMatrix.M[2,0]),
				Y = new(ResultMatrix.M[0,1],ResultMatrix.M[1,1],ResultMatrix.M[2,1]),
				Z = new(ResultMatrix.M[0,2],ResultMatrix.M[1,2],ResultMatrix.M[2,2]);

				if(AbsoluteScale)
				{
					X.Normalize();
					Y.Normalize();
					Z.Normalize();
				}

				if(AbsoluteRotation)
				{
					X = FVector(X.Size(),0,0);
					Y = FVector(0,Y.Size(),0);
					Z = FVector(0,0,Z.Size());
				}

				ResultMatrix.M[0,0] = X.X;
				ResultMatrix.M[1,0] = X.Y;
				ResultMatrix.M[2,0] = X.Z;
				ResultMatrix.M[0,1] = Y.X;
				ResultMatrix.M[1,1] = Y.Y;
				ResultMatrix.M[2,1] = Y.Z;
				ResultMatrix.M[0,2] = Z.X;
				ResultMatrix.M[1,2] = Z.Y;
				ResultMatrix.M[2,2] = Z.Z;
			}

			// If desired, take into account the transform from the Origin/RotOrigin in the SkeletalMesh (if there is one).
			// We don't do this if bTransformFromAnimParent is true and we have a parent - in that case both ResultMatrixs should be the same, including skeletal offset.
			FMatrix SkelCompOffset = FMatrix.Identity;
			if(SkeletalMesh && !bForceRawOffset.AsBool() && !(ParentAnimComponent && bTransformFromAnimParent.AsBool()))
			{
				SkelCompOffset = FTranslationMatrix( SkeletalMesh.Origin ) * FRotationMatrix(SkeletalMesh.RotOrigin);
			}

			ResultMatrix = SkelCompOffset * FScaleRotationTranslationMatrix( Scale * Scale3D, Rotation, Translation ) * ResultMatrix;
			return ResultMatrix;
		}



		public void UpdateRBBonesFromSpaceBases( in FMatrix CurrentLocalToWorld, UBOOL bMoveUnfixedBodies, UBOOL bTeleport )
		{
			NativeMarkers.MarkUnimplemented("Unnecessary");
		}



		public void UpdateSkelPose( float DeltaTime = 0f, bool bTickFaceFX = true )
		{
			//SCOPE_CYCLE_COUNTER(STAT_UpdateSkelPose);
			// Can't do anything without a SkeletalMesh
			if( !SkeletalMesh )
			{
				return;
			}

			bool bOldIgnoreControllers = bIgnoreControllers != 0;

			// Allocate transforms if not present.
			if( SpaceBases.Num() != SkeletalMesh.RefSkeleton.Num() )
			{
				SpaceBases.Empty( SkeletalMesh.RefSkeleton.Num() );
				SpaceBases.AddCount( SkeletalMesh.RefSkeleton.Num() );

				// Controls sometimes use last frames position of a bone. But if that is not valid (ie array is freshly allocated)
				// we need to turn them off.
				bIgnoreControllers = TRUE.AsInt();
			}

			if( LocalAtoms.Num() != SkeletalMesh.RefSkeleton.Num() )
			{
				LocalAtoms.Empty( SkeletalMesh.RefSkeleton.Num() );
				LocalAtoms.AddCount( SkeletalMesh.RefSkeleton.Num() );
			}

			// Do nothing more if no bones in skeleton.
			if( SpaceBases.Num() == 0 )
			{
				bIgnoreControllers = bOldIgnoreControllers.AsInt();
				return;
			}

			// Update bones transform from animations (if present)

			UBOOL bRenderedRecently = (GWorld.GetTimeSeconds() - LastRenderTime) < 1.0f;

			// See if this mesh is far enough from the viewer we should stop updating kinematic rig
			UBOOL bNewNotUpdateKinematic = FALSE;
			if(	MinDistFactorForKinematicUpdate > 0f && 
				(MaxDistanceFactor < MinDistFactorForKinematicUpdate || !bRenderedRecently) )
			{
				bNewNotUpdateKinematic = TRUE;
			}

			// Flag to indicate this is a frame where we have just turned on kinematic updating of bodies again.  
			UBOOL bJustEnabledKinematicUpdate = FALSE;  
			UBOOL bKinematicUpdateStateChanged = FALSE;  

			// Turn off BlockRigidBody when we stop updating kinematics, and turn it back on when we start again.  
			if(bNotUpdatingKinematicDueToDistance && !bNewNotUpdateKinematic)   
			{   
				bKinematicUpdateStateChanged = TRUE;  
				bJustEnabledKinematicUpdate = TRUE;   
			}  
			else if(!bNotUpdatingKinematicDueToDistance && bNewNotUpdateKinematic)  
			{  
				bKinematicUpdateStateChanged = TRUE;  
			}  
			bNotUpdatingKinematicDueToDistance = bNewNotUpdateKinematic;  

			// This also looks at bNotUpdatingKinematicDueToDistance and sets the collision state accordingly  
			if(bKinematicUpdateStateChanged)
			{
				SetBlockRigidBody(BlockRigidBody);
			}

			// Recalculate the RequiredBones array, if necessary
			if(!(bRequiredBonesUpToDate.AsBool()))
			{
				RecalcRequiredBones(PredictedLODLevel);
				bRequiredBonesUpToDate = TRUE.AsInt();
			}

			// We can skip doing some work when using PHYS_RigidBody and physics bodies asleep
			if(bSkipAllUpdateWhenPhysicsAsleep && FramesPhysicsAsleep > 5)
			{
				return;
			}

			// Root motion extracted for this call
			BoneAtom	ExtractedRootMotionDelta	= BoneAtom.Identity;
			bool			bHasRootMotion				= false;
			{
				//SCOPE_CYCLE_COUNTER(STAT_AnimBlendTime);
				if( Animations && !bForceRefpose.AsBool() )
				{
					// Check its been initialized
					checkf(Animations.SkelComponent, TEXT("! Component: %s  SkeletalMesh: %s"), /*GetPathName()*/"GetPathName()", SkeletalMesh.Name);
					// Check we don't have any nasty AnimTree sharing going on or anything.
					checkf(Animations.SkelComponent == this, TEXT("!! Component: %s  SkeletalMesh: %s"), /*GetPathName()*/"GetPathName()", SkeletalMesh.Name);

					// Increment the cache tag, so caches are invalidated on the nodes.
					CachedAtomsTag++;

		#if ENABLE_GETBONEATOM_STATS
					BoneAtomBlendStats.Empty();
		#endif
					//debugf(TEXT("%2.3f: %s GetBoneAtoms(), owner: %s"),GWorld.GetTimeSeconds(),*GetPathName(),*Owner.GetName());
					Animations.GetBoneAtoms(ref LocalAtoms, ref RequiredBones, ref ExtractedRootMotionDelta, ref bHasRootMotion);

		#if ENABLE_GETBONEATOM_STATS
					if(GShouldLogOutAFrameOfSkelCompTick)
					{
						// Sort results (slowest first)
						Sort<USE_COMPARE_CONSTREF(FAnimNodeTimeStat,UnSkeletalComponent)>( &BoneAtomBlendStats(0), BoneAtomBlendStats.Num() );

						debugf(TEXT(" ======= GetBoneAtom - TIMING - %s %s"), *GetPathName(), SkeletalMesh?*SkeletalMesh.GetName():TEXT("NONE"));
						for(INT i=0; i<BoneAtomBlendStats.Num(); i++)
						{
							debugf(TEXT("%fms\t%s"), BoneAtomBlendStats(i).NodeExclusiveTime * 1000.f, *BoneAtomBlendStats(i).NodeName.ToString());
						}
						debugf(TEXT(" ======="));
					}
		#endif
				}
				else
				{
					AnimNode.FillWithRefPose(ref LocalAtoms, RequiredBones, SkeletalMesh.RefSkeleton);
				}
			}

			// Root Motion 

			// Root motion movement is done only once per tick. 
			// Because RootMotionDelta is relative to the last time the animation was ticked. 
			// So we can't just arbitrarily call that function and have root motion work, the same offsets would be applied every time.
			// Because this function can be called at any time with a delta time of 0 to update the skeleton...
			// This is probably going to be a problem with Matinee. In that case, this system would need to refactored to support that.
			if( DeltaTime > 0f )
			{
				// If PendingRMM has changed, set it
				if( PendingRMM != OldPendingRMM )
				{
					// Already set, do nothing
					if( RootMotionMode == PendingRMM )
					{
						OldPendingRMM = PendingRMM;
					}
					// delay by a frame if setting to RMM_Ignore AND animation extracted root motion on this frame.
					// This is to force physics to process the entire root motion.
					else if( PendingRMM != ERootMotionMode.RMM_Ignore || !bHasRootMotion || bRMMOneFrameDelay == 1 )
					{
						RootMotionMode		= PendingRMM;
						OldPendingRMM		= PendingRMM;
						bRMMOneFrameDelay	= 0;
					}
					else
					{
						bRMMOneFrameDelay	= 1;
					}
				}

				// if root motion is requested, then transform it from mesh space to world space so it can be used.
				if( bHasRootMotion && RootMotionMode != ERootMotionMode.RMM_Ignore )
				{
		#if false//0 // DEBUG
					debugf(TEXT("%3.2f [%s] Extracted RM, PreProcessing, Translation: %3.3f, vect: %s, RootMotionAccelScale: %s"), 
						GWorld.GetTimeSeconds(), *Owner.GetName(), ExtractedRootMotionDelta.Translation.Size(), *ExtractedRootMotionDelta.Translation.ToString(), *RootMotionAccelScale.ToString());
		#endif
					// Transform mesh space root delta translation to world space
					ExtractedRootMotionDelta.Translation = LocalToWorld.TransformNormal(ExtractedRootMotionDelta.Translation);

					// Scale RootMotion translation in Mesh Space.
					if( RootMotionAccelScale != FVector(1f) )
					{
						ExtractedRootMotionDelta.Translation *= RootMotionAccelScale;
					}

					// If Owner required a Script event forwarded when root motion has been extracted, forward it
					if( Owner && bRootMotionExtractedNotify )
					{
						Owner.RootMotionExtracted(this, ref ExtractedRootMotionDelta);
					}

					// Root Motion delta is accumulated every time it is extracted.
					// This is because on servers using autonomous physics, physics updates and ticking are out of synch.
					// So 2 physics updates can happen in a row, or 2 animation updates, effectively
					// making client and server out of synch.
					// So root motion is accumulated, and reset when used by physics.
					RootMotionDelta.Translation	+= ExtractedRootMotionDelta.Translation;
					RootMotionVelocity			= ExtractedRootMotionDelta.Translation / DeltaTime;
				}
				else
				{
					RootMotionDelta.Translation = FVector(0f);
					RootMotionVelocity			= FVector(0f);
				}

		#if false//0 // DEBUG
				static FVector	AccumulatedRMTranslation = FVector(0.f);
				{
					if( RootMotionMode != RMM_Ignore )
					{
						AccumulatedRMTranslation	+= ExtractedRootMotionDelta.Translation;
					}
					else
					{
						AccumulatedRMTranslation	= FVector(0.f);
					}

					if( RootMotionMode != RMM_Ignore )
					{
						debugf(TEXT("%3.2f [%s] RM Translation: %3.3f, vect: %s"), GWorld.GetTimeSeconds(), *Owner.GetName(), RootMotionDelta.Translation.Size(), *RootMotionDelta.Translation.ToString());
						debugf(TEXT("%3.2f [%s] RM Velocity: %3.3f, vect: %s"), GWorld.GetTimeSeconds(), *Owner.GetName(), RootMotionVelocity.Size(), *RootMotionVelocity.ToString());
						debugf(TEXT("%3.2f [%s] RM AccumulatedRMTranslation: %3.3f, vect: %s"), GWorld.GetTimeSeconds(), *Owner.GetName(), AccumulatedRMTranslation.Size(), *AccumulatedRMTranslation.ToString());
					}
				}
		#endif

				if( bHasRootMotion && RootMotionRotationMode != ERootMotionRotationMode.RMRM_Ignore )
				{
					Quat MeshToWorldQuat = new(LocalToWorld);

					// Transform mesh space delta rotation to world space.
					RootMotionDelta.Rotation = MeshToWorldQuat * ExtractedRootMotionDelta.Rotation * (-MeshToWorldQuat);
					RootMotionDelta.Rotation.Normalize();
				}
				else
				{
					RootMotionDelta.Rotation = Quat.Identity;
				}

		#if false//0 // DEBUG ROOT ROTATION
				if( RootMotionRotationMode != RMRM_Ignore )
				{
					FRotator DeltaRotation = FQuatRotationTranslationMatrix(RootMotionDelta.Rotation, FVector(0.f)).Rotator();
					debugf(TEXT("%3.2f Root Rotation: %s"), GWorld.GetTimeSeconds(), *DeltaRotation.ToString());
				}
		#endif

				// Motion applied right away
				if( bHasRootMotion && 
					(RootMotionMode == ERootMotionMode.RMM_Translate || RootMotionRotationMode == ERootMotionRotationMode.RMRM_RotateActor || 
					(RootMotionMode == ERootMotionMode.RMM_Ignore && PreviousRMM == ERootMotionMode.RMM_Translate)) )	// If root motion was just turned off, forward remaining root motion.
				{
					/** 
					 * Delay applying instant translation for one frame
					 * So we check for PreviousRMM to be up to date with the current root motion mode.
					 * We need to do this because in-game physics have already been applied for this tick.
					 * So we want root motion to kick in for next frame.
					 */
					UBOOL		bCanDoTranslation	= (RootMotionMode == RMM_Translate && PreviousRMM == RMM_Translate);
					FVector	InstantTranslation	= bCanDoTranslation ? RootMotionDelta.Translation : FVector(0f);

					UBOOL		bCanDoRotation		= (RootMotionRotationMode == RMRM_RotateActor);
					FRotator	InstantRotation		=  bCanDoRotation ? FQuatRotationTranslationMatrix(RootMotionDelta.Rotation, FVector(0f)).Rotator() : FRotator(0,0,0);

					if( Owner && (!InstantRotation.IsZero() || InstantTranslation.SizeSquared() > SMALL_NUMBER) )
					{
		#if false//0 // DEBUG ROOT MOTION
						debugf(TEXT("%3.2f Root Motion Instant. DeltaRot: %s"), GWorld.GetTimeSeconds(), *InstantRotation.ToString());
		#endif
						// Transform mesh directly. Doesn't take in-game physics into account.
						CheckResult Hit = new(1f);
						GWorld.MoveActor(Owner, InstantTranslation, Owner.Rotation + InstantRotation, 0, ref Hit);

						// If we have used translation, reset the accumulator.
						if( bCanDoTranslation )
						{
							RootMotionDelta.Translation = FVector(0f);
						}

						if( bCanDoRotation )
						{
							Owner.DesiredRotation = Owner.Rotation;

							// Update DesiredRotation for AI Controlled Pawns
							Pawn PawnOwner = (Owner as Pawn);
							if( PawnOwner && PawnOwner.Controller && PawnOwner.Controller.bForceDesiredRotation )
							{
								PawnOwner.Controller.DesiredRotation = Owner.Rotation;
							}
						}
					}
				}

				// Track root motion mode changes
				if( RootMotionMode != PreviousRMM )
				{
					// notify owner that root motion mode changed. 
					// if RootMotionMode != RMM_Ignore, then on next frame root motion will kick in.
					if( bRootMotionModeChangeNotify && Owner )
					{
						Owner.RootMotionModeChanged(this);
					}
					PreviousRMM = RootMotionMode;
				}
			}

		#if false//0 // DEBUG root Rotation
			if( Owner )
			{
				Owner.DrawDebugLine(Owner.Location, Owner.Location + Owner.Rotation.Vector() * 200.f, 255, 0, 0, FALSE);
			}
		#endif

			if( bForceDiscardRootMotion )
			{
				LocalAtoms[0].Translation	= FVector(0f);
				LocalAtoms[0].Rotation		= FQuat.Identity;
			}

			// Remember the root bone's translation so we can move the bounds.
			RootBoneTranslation = LocalAtoms[0].Translation - SkeletalMesh.RefSkeleton[0].BonePos.Position;

			// Update the ActiveMorphs array.
			UpdateActiveMorphs();

			if( SkeletalMesh.FaceFXAsset )
			{
				//SCOPE_CYCLE_COUNTER(STAT_UpdateFaceFX);
				// Do FaceFX processing.
				UpdateFaceFX(ref LocalAtoms, bTickFaceFX);
			}

			// We need the world space bone transforms now for two reasons:
			// 1) we don't have physics, so we will not be revisiting this skeletal mesh in UpdateTransform.
			// 2) we do have physics, and want to update the physics state from the animation.
			// This will do controllers and the like.

			//const DOUBLE ComposeSkeleton_Start = appSeconds();

			ComposeSkeleton(ref LocalAtoms, RequiredBones);

		// 	if( GShouldLogOutAFrameOfSkelCompTick == TRUE )
		// 	{
		// 		DOUBLE ComposeSkeleton_Time = (appSeconds() - ComposeSkeleton_Start) * 1000.f;
		// 		debugf( TEXT( "   ComposeSkeleton_Time: %f" ), ComposeSkeleton_Time );
		// 	}

			// UpdateRBBonesFromSpaceBases, updating the physical skeleton from the animated one, is done inside UpdateTransform.

			// When we re-enable kinematic update, we teleport bodies to the right place now (handles flappy bits not getting jerked when updated).
			if(bJustEnabledKinematicUpdate)
			{
				UpdateRBBonesFromSpaceBases(LocalToWorld, TRUE, TRUE);
			}

			// If desired, pass the animation data to the physics joints so they can be used by motors.
			if(PhysicsAssetInstance && bUpdateJointsFromAnimation)
			{
				UpdateRBJointMotors();
			}

			bIgnoreControllers = bOldIgnoreControllers.AsInt();
			bHasHadPhysicsBlendedIn = FALSE;
		}
		
		void UpdateFaceFX( ref array<FBoneAtom> LocalTransforms, UBOOL bTickFaceFX )
		{
			NativeMarkers.MarkUnimplemented("Not necessary");
		}



		void UpdateRBJointMotors()
		{
			NativeMarkers.MarkUnimplemented("Not necessary");
		}
		
		
		public FMatrix CalcComponentToFrameMatrix(INT BoneIndex, SkelControlBase.EBoneControlSpace Space, name OtherBoneName)
		{
			FMatrix ComponentToFrame;
			if(Space == BCS_WorldSpace)
			{
				ComponentToFrame = LocalToWorld;
			}
			else if(Space == BCS_ActorSpace)
			{
				if(Owner)
				{
					ComponentToFrame = LocalToWorld * Owner.LocalToWorld().Inverse();
				}
				else
				{
					//ActorToWorld = FMatrix::Identity;
					ComponentToFrame = LocalToWorld;
				}
			}
			else if(Space == BCS_ComponentSpace)
			{
				ComponentToFrame = FMatrix.Identity;
			}
			else if(Space == BCS_ParentBoneSpace)
			{
				if(BoneIndex == 0)
				{
					ComponentToFrame = FMatrix.Identity;
				}
				else
				{
					INT ParentIndex = SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;
					ComponentToFrame =SpaceBases[ParentIndex].Inverse();
				}
			}
			else if(Space == BCS_BoneSpace)
			{
				ComponentToFrame = SpaceBases[BoneIndex].Inverse();
			}
			else if(Space == BCS_OtherBoneSpace)
			{
				INT OtherBoneIndex = MatchRefBone(OtherBoneName);
				if(OtherBoneIndex != INDEX_NONE)
				{
					ComponentToFrame = SpaceBases[OtherBoneIndex].Inverse();
				}
				else
				{
					debugf( TEXT("GetFrameMatrix: Invalid BoneName: %s  for Mesh: %s"), OtherBoneName.ToString(), SkeletalMesh.GetFName().ToString() );
					ComponentToFrame = FMatrix.Identity;
				}
			}
			else
			{
				debugf( TEXT("GetFrameMatrix: Unknown Frame %d  for Mesh: %s"), Space, SkeletalMesh.GetFName().ToString() );
				ComponentToFrame = FMatrix.Identity;
			}

			ComponentToFrame.RemoveScaling();
			return ComponentToFrame;
		}



		void ComposeSkeleton(ref array<FBoneAtom> LocalTransforms, in array<BYTE> RequiredBones)
		{
			//SCOPE_CYCLE_COUNTER(STAT_SkelComposeTime);

			if( !SkeletalMesh )
			{
				return;
			}

			check( SkeletalMesh.RefSkeleton.Num() == LocalTransforms.Num() );
			check( SkeletalMesh.RefSkeleton.Num() == SpaceBases.Num() );

			AnimTree Tree = (Animations) as AnimTree;

			array<INT>		AffectedBones = new();
			array<FMatrix> NewBoneTransforms = new();
			array<FLOAT>	NewBoneScales = new();

			// Cache this once
			WorldInfo WorldInfo = GWorld.GetWorldInfo();

			// If bIgnoreControllersWhenNotRendered is true, set bForceIgnore if the Owner has not been drawn recently.
			UBOOL bRenderedRecently	= (WorldInfo.TimeSeconds - LastRenderTime) < 1.0f;
			UBOOL bForceIgnore		= GIsGame && bIgnoreControllersWhenNotRendered && !bRenderedRecently;

			// Number of passes for composing
			// AnimTree defines a list of branches that should be performed before the rest of the others.
			INT PassNb = Tree && Tree.PrioritizedSkelBranches.Num() > 0 ? 1 : 0;
			while( PassNb >= 0 )
			{
				// Iterate over each bone
				for(INT i=0; i<RequiredBones.Num(); i++)
				{
					INT BoneIndex = RequiredBones[i];

					// If we should skip the bones for this pass, then do so.
					if( Tree && BoneIndex < Tree.PriorityList.Num() && Tree.PriorityList[BoneIndex] != PassNb )
					{
						continue;
					}

					// For root bone, just read bone atom as component-space transform.
					if( BoneIndex == 0 )
					{
						LocalTransforms[0].ToTransform(ref SpaceBases[0]);
					}
					// For all bones below the root, final component-space transform is relative transform * component-space transform of parent.
					else
					{
						FMatrix LocalBoneTM = default;
						LocalTransforms[BoneIndex].ToTransform(ref LocalBoneTM);

						INT ParentIndex = SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;

		#if DO_GUARD_SLOW
						// Check the precondition that Parents occur before Children in the RequiredBones array.
						INT ReqBoneParentIndex = RequiredBones.FindItemIndex(ParentIndex);
						check(ReqBoneParentIndex != INDEX_NONE);
						check(ReqBoneParentIndex < i);
		#endif
						SpaceBases[BoneIndex] = LocalBoneTM * SpaceBases[ParentIndex];
					}

					// If we have an AnimTree, and we are not ignoring controllers, apply any SkelControls in the tree now.
					if( Tree && !bIgnoreControllers.AsBool() && !bForceIgnore )
					{
						// If the SkelControlIndex is not empty, and we have controllers for this bone, apply it now.
						if( (SkelControlIndex.Num() > 0) && (SkelControlIndex[BoneIndex] != 255) )
						{
							INT ControlIndex = SkelControlIndex[BoneIndex];
							check( ControlIndex < Tree.SkelControlLists.Num() );

							// Iterate over linked list of controls, calculate desired transforms for each.
							SkelControlBase Control = Tree.SkelControlLists[ControlIndex].ControlHead;
							while( Control )
							{
								if ((bRenderedRecently || !Control.bIgnoreWhenNotRendered) && (PredictedLODLevel < Control.IgnoreAtOrAboveLOD) && Control.ControlStrength > ZERO_ANIMWEIGHT_THRESH )
								{
									//SCOPE_CYCLE_COUNTER(STAT_SkelControl);

									AffectedBones.Reset();
									Control.GetAffectedBones(BoneIndex, this, ref AffectedBones);

									// Do nothing if we are not going to affect any bones.
									if( AffectedBones.Num() > 0 )
									{
										NewBoneTransforms.Reset();
										Control.CalculateNewBoneTransforms(BoneIndex, this, ref NewBoneTransforms);
										UBOOL bTransformingAffectedBones = (NewBoneTransforms.Num() > 0);

										NewBoneScales.Reset();
										Control.CalculateNewBoneScales(BoneIndex, this, ref NewBoneScales);
										UBOOL bScalingAffectedBones = (NewBoneScales.Num() > 0);

										// Get Alpha for this control. CalculateNewBoneTransforms() may have changed it.
										FLOAT ControlAlpha = Control.GetControlAlpha();

										// This allows the SkelControl to do nothing, by returning empty arrays.
										// ControlAlpha can also return 0 to skip applying the controller.
										if( ControlAlpha > ZERO_ANIMWEIGHT_THRESH && (bTransformingAffectedBones || bScalingAffectedBones) )
										{
											// handle skelcontrol pos/rot modifications to bones
											if (bTransformingAffectedBones)
											{
												check( AffectedBones.Num() == NewBoneTransforms.Num() );

												// Now handle blending control output into skeleton.
												// We basically have to turn each transform back into a local-space FBoneAtom, interpolate between the current FBoneAtom
												// for this bone, then do the regular 'relative to parent' blend maths.

												for(INT AffectedIdx=0; AffectedIdx<AffectedBones.Num(); AffectedIdx++)
												{
													INT AffectedBoneIndex	= AffectedBones[AffectedIdx];
													INT ParentIndex		= SkeletalMesh.RefSkeleton[AffectedBoneIndex].ParentIndex;

													// Calculate transform of parent bone
													FMatrix ParentTM;
													if( AffectedBoneIndex > 0 )
													{
														// If the parent of this bone is another one affected by this controller,
														// we want to use the new parent transform from the controller as the basis for the relative-space animation atom.
														// If not, use the current SpaceBase matrix for the parent.
														INT NewBoneTransformIndex = AffectedBones.FindItemIndex(ParentIndex);
														if( NewBoneTransformIndex == INDEX_NONE )
														{
															ParentTM = SpaceBases[ParentIndex];
														}
														else
														{
															ParentTM = NewBoneTransforms[NewBoneTransformIndex];
														}
													}
													else
													{
														ParentTM = FMatrix.Identity;
													}

													// Then work out relative transform, and convert to FBoneAtom.
													FMatrix RelTM = NewBoneTransforms[AffectedIdx] * ParentTM.Inverse();
													FBoneAtom ControlRelAtom = new(RelTM);

													// faster version when we don't need to blend. Copy results directly
													if( ControlAlpha >= (1f - ZERO_ANIMWEIGHT_THRESH) )
													{
														// FBoneAtom transform from above doesn't take into account scaling. So make sure we don't here either.
														// We can't just assign NewBoneTransforms to SpaceBases, because we want to inherit scaling from parents.
														RelTM.RemoveScaling();
														if( AffectedBoneIndex > 0 )
														{
															SpaceBases[AffectedBoneIndex] = RelTM * SpaceBases[ParentIndex];
														}
														else
														{
															SpaceBases[AffectedBoneIndex] = RelTM;
														}

														LocalTransforms[AffectedBoneIndex] = ControlRelAtom;
													}
													else
													{
														// Set the new FBoneAtom to be a blend between the current one, and the one from the controller.
														FBoneAtom CurrentAtom = LocalTransforms[AffectedBoneIndex];
														LocalTransforms[AffectedBoneIndex].Blend(CurrentAtom, ControlRelAtom, ControlAlpha);

														// Then do usual hierarchical blending stuff (just like in ComposeSkeleton).
														if( AffectedBoneIndex > 0 )
														{
															FMatrix LocalBoneTM = default;
															LocalTransforms[AffectedBoneIndex].ToTransform(ref LocalBoneTM);
															SpaceBases[AffectedBoneIndex] = LocalBoneTM * SpaceBases[ParentIndex];
														}
														else
														{
															LocalTransforms[0].ToTransform(ref SpaceBases[0]);
														}
													}
												}
											}

											// handle scaling separately for now.  loops through affected bones again, but
											// should be a rarely used code path
											if (bScalingAffectedBones)
											{
												check( AffectedBones.Num() == NewBoneScales.Num() );

												for(INT AffectedIdx=0; AffectedIdx<AffectedBones.Num(); AffectedIdx++)
												{
													INT AffectedBoneIndex	= AffectedBones[AffectedIdx];
													INT ParentIndex		= SkeletalMesh.RefSkeleton[AffectedBoneIndex].ParentIndex;

													FLOAT ParentScale = 1f;
													{
														if( AffectedBoneIndex > 0 )
														{
															// If the parent of this bone is another one affected by this controller,
															// we want to use the new parent transform from the controller as the basis for the relative-space animation atom.
															// If not, use the current SpaceBase matrix for the parent.
															INT ParentBoneIndex = AffectedBones.FindItemIndex(ParentIndex);
															if( ParentBoneIndex != INDEX_NONE )
															{
																ParentScale = NewBoneScales[ParentBoneIndex];
															}
														}
													}

													FLOAT FinalScale, FinalRelScale;
													if( ControlAlpha >= (1f - ZERO_ANIMWEIGHT_THRESH) )
													{
														// faster version when we don't need to blend. Copy results directly
														FinalScale = NewBoneScales[AffectedIdx];
														FinalRelScale = (ParentScale == 0f) ? 1f : FinalScale / ParentScale;
													}
													else
													{
														// else, need to blend.  Just doing lerp here for now, instead of pushing through 
														// the FBoneAtom.Blend() call.
														FLOAT RelScale = (ParentScale == 0f) ? 1f : NewBoneScales[AffectedIdx] / ParentScale;
														FinalRelScale = Lerp(LocalTransforms[AffectedBoneIndex].Scale, RelScale, ControlAlpha);
														FinalScale = FinalRelScale * ParentScale;
													}

													// apply the scaling
													LocalTransforms[AffectedBoneIndex].Scale *= FinalRelScale;
													SpaceBases[AffectedBoneIndex] = FScaleMatrix(FinalRelScale) * SpaceBases[AffectedBoneIndex];
												}
											}

											// Calculate desired bone scaling for this bone - scaled by the ControlStrength.
											FLOAT BoneScale = Lerp(1f, Control.GetBoneScale(BoneIndex, this), ControlAlpha);

											// Apply bone scaling.
											if( BoneScale != 1f )
											{
												LocalTransforms[BoneIndex].Scale *= BoneScale;
												SpaceBases[BoneIndex] = FScaleMatrix(BoneScale) * SpaceBases[BoneIndex];
											}

											// Find the earliest bone in bones array affected by this controller. 
											// Because parents are always before children in AffectedBones, this will always be the first element.
											INT FirstAffectedBone = AffectedBones[0];

											// For any bones between that bone and the one we updated, that was not affected by the bone controller, we need to refresh it.
											for(INT UpdateBoneIndex = FirstAffectedBone+1; UpdateBoneIndex<BoneIndex; UpdateBoneIndex++)
											{
												// @todo We don't need to do this for any bones that are not in RequiredBones, but we don't want to do another ContainsItem here,
												// so should probably build an array of bools (entry for each bone) which we can quickly look up into.
												if( !AffectedBones.ContainsItem(UpdateBoneIndex) )
												{
													LocalTransforms[UpdateBoneIndex].ToTransform(ref  SpaceBases[UpdateBoneIndex] );
													INT UpdateParentIndex = SkeletalMesh.RefSkeleton[UpdateBoneIndex].ParentIndex;
													SpaceBases[UpdateBoneIndex] *= SpaceBases[UpdateParentIndex];
												}
											}
										}
									} // if( AffectedBones.Num() > 0 )
								} // if( Control.ControlStrength > KINDA_SMALL_NUMBER )

								Control = Control.NextControl;
							}
						}
					}
				}

				PassNb--;
			} // while( PassNb >= 0 )
		}



		void UpdateActiveMorphs()
		{
			ActiveMorphs.Empty();

			AnimTree AnimTree = Animations as AnimTree;
			if(AnimTree)
			{
				AnimTree.GetTreeActiveMorphs( ref ActiveMorphs );
			}
		}



		public void RecalcRequiredBones( INT LODIndex )
		{
			RequiredBones.Empty();
			for(int i = 0; i < AnimSets[0].TrackBoneNames.Count; i++)
				RequiredBones.Add((byte)i);
			NativeMarkers.MarkUnimplemented();
			#if UNUSED
			// The list of bones we want is taken from the predicted LOD level.
			FStaticLODModel& LODModel = SkeletalMesh.LODModels(LODIndex);


			// The LODModel.RequiredBones array only includes bones that are desired for that LOD level.
			// They are also in strictly increasing order, which also infers parents-before-children.
			RequiredBones = LODModel.RequiredBones;


			// Add in any bones that may be required when mirroring.
			// JTODO: This is only required if there are mirroring nodes in the tree, but hard to know...
			if(SkeletalMesh.SkelMirrorTable.Num() == LocalAtoms.Num())
			{
				array<BYTE> MirroredDesiredBones = new();
				MirroredDesiredBones.AddCount(RequiredBones.Num());

				// Look up each bone in the mirroring table.
				for(INT i=0; i<RequiredBones.Num(); i++)
				{
					MirroredDesiredBones[i] = (byte)SkeletalMesh.SkelMirrorTable[RequiredBones[i]].SourceIndex;
				}

				// Sort to ensure strictly increasing order.
				Sort<USE_COMPARE_CONSTREF(BYTE, UnSkeletalComponent)>(&MirroredDesiredBones(0), MirroredDesiredBones.Num());

				// Make sure all of these are in RequiredBones, and 
				MergeInByteArray(RequiredBones, MirroredDesiredBones);
			}

			// If we have a PhysicsAsset, we also need to make sure that all the bones used by it are always updated, as its used
			// by line checks etc. We might also want to kick in the physics, which means having valid bone transforms.
			if(PhysicsAsset)
			{
				array<BYTE> PhysAssetBones = new();
				for(INT i=0; i<PhysicsAsset.BodySetup.Num(); i++ )
				{
					INT PhysBoneIndex = SkeletalMesh.MatchRefBone( PhysicsAsset.BodySetup[i].BoneName );
					if(PhysBoneIndex != INDEX_NONE)
					{
						PhysAssetBones.AddItem((byte)PhysBoneIndex);
					}	
				}

				// Then sort array of required bones in hierarchy order
				Sort<USE_COMPARE_CONSTREF(BYTE, UnSkeletalComponent)>( &PhysAssetBones(0), PhysAssetBones.Num() );

				// Make sure all of these are in RequiredBones.
				MergeInByteArray(RequiredBones, PhysAssetBones);
			}

			// Make sure that bones with per-poly collision are also always updated.
			if(SkeletalMesh.PerPolyCollisionBones.Num() > 0)
			{
				array<BYTE> PerPolyCollisionBones = new();
				for(INT i=0; i<SkeletalMesh.PerPolyCollisionBones.Num(); i++ )
				{
					INT PerPolyBoneIndex = SkeletalMesh.MatchRefBone( SkeletalMesh.PerPolyCollisionBones[i] );
					if(PerPolyBoneIndex != INDEX_NONE)
					{
						PerPolyCollisionBones.AddItem((byte)PerPolyBoneIndex);
					}	
				}

				// Once again, sort and merge.
				Sort<USE_COMPARE_CONSTREF(BYTE, UnSkeletalComponent)>( &PerPolyCollisionBones(0), PerPolyCollisionBones.Num() );
				MergeInByteArray(RequiredBones, PerPolyCollisionBones);
			}

			// Ensure that we have a complete hierarchy down to those bones.
			UAnimNode.EnsureParentsPresent(RequiredBones, SkeletalMesh);
			#endif
		}
	}



	public partial class AnimNode
	{
		static System.Random RandInstance = new System.Random();
		protected static float appFrand() => UnityEngine.Random.value;
		protected static int appRand() => RandInstance.Next(0, 32767);
		protected static float appFmod( float a, float b ) => a % b;
		protected static float appAcos( float Value ) => MathF.Acos( ( Value < - 1f ) ? - 1f : ( ( Value < 1f ) ? Value : 1f ) );

		
		public virtual void SetAnim( name SequenceName ) {}

		public partial struct BoneAtom
		{
			public BoneAtom(Quat q, Vector v, float s)
			{
				this.Rotation = q;
				this.Translation = v;
				this.Scale = s;
			}
			
			public BoneAtom(in Matrix mat)
			{
				this.Rotation = new(mat);
				this.Translation = mat.GetOrigin();
				this.Scale = 1f;
			}



			public static BoneAtom Identity = new BoneAtom(new Quat(0f,0f,0f,1f), FVector(0f, 0f, 0f), 1f);
			
			public void ToTransform(ref FMatrix OutMatrix)
			{
				OutMatrix.M[3,0] = Translation.X;
				OutMatrix.M[3,1] = Translation.Y;
				OutMatrix.M[3,2] = Translation.Z;

				FLOAT x2 = Rotation.X + Rotation.X;	
				FLOAT y2 = Rotation.Y + Rotation.Y;  
				FLOAT z2 = Rotation.Z + Rotation.Z;
				{
					FLOAT xx2 = Rotation.X * x2;
					FLOAT yy2 = Rotation.Y * y2;			
					FLOAT zz2 = Rotation.Z * z2;

					OutMatrix.M[0,0] = (1.0f - (yy2 + zz2)) * Scale;	
					OutMatrix.M[1,1] = (1.0f - (xx2 + zz2)) * Scale;
					OutMatrix.M[2,2] = (1.0f - (xx2 + yy2)) * Scale;
				}
				{
					FLOAT yz2 = Rotation.Y * z2;   
					FLOAT wx2 = Rotation.W * x2;	

					OutMatrix.M[2,1] = (yz2 - wx2) * Scale;
					OutMatrix.M[1,2] = (yz2 + wx2) * Scale;
				}
				{
					FLOAT xy2 = Rotation.X * y2;
					FLOAT wz2 = Rotation.W * z2;

					OutMatrix.M[1,0] = (xy2 - wz2) * Scale;
					OutMatrix.M[0,1] = (xy2 + wz2) * Scale;
				}
				{
					FLOAT xz2 = Rotation.X * z2;
					FLOAT wy2 = Rotation.W * y2;   

					OutMatrix.M[2,0] = (xz2 + wy2) * Scale;
					OutMatrix.M[0,2] = (xz2 - wy2) * Scale;
				}

				OutMatrix.M[0,3] = 0.0f;
				OutMatrix.M[1,3] = 0.0f;
				OutMatrix.M[2,3] = 0.0f;
				OutMatrix.M[3,3] = 1.0f;
			}
				
				
			public void Blend(in FBoneAtom Atom1, in FBoneAtom Atom2, FLOAT Alpha)
			{
				if( Alpha <= ZERO_ANIMWEIGHT_THRESH )
				{
					// if blend is all the way for child1, then just copy its bone atoms
					this = Atom1;
				}
				else if( Alpha >= 1f - ZERO_ANIMWEIGHT_THRESH )
				{
					// if blend is all the way for child2, then just copy its bone atoms
					this = Atom2;
				}
				else
				{
					// Simple linear interpolation for translation and scale.
					Translation = VLerp(Atom1.Translation, Atom2.Translation, Alpha);
					Scale		= Lerp(Atom1.Scale, Atom2.Scale, Alpha);

					// We use a linear interpolation and a re-normalize for the rotation.
					// Treating Rotation as an accumulator, initialise to a scaled version of Atom1.
					Rotation = Atom1.Rotation * (1f - Alpha);

					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming rotation is positive.
					if( (Rotation | Atom2.Rotation) < 0f )
					{
						Rotation = (Atom2.Rotation * Alpha) - Rotation;
					}
					else
					{
						// Then add on the second rotation..
						Rotation = (Atom2.Rotation * Alpha) + Rotation;
					}

					// ..and renormalize
					Rotation.Normalize();
				}
			}

			public static FBoneAtom operator *(FBoneAtom atom, FLOAT Mult)
			{
				return new(atom.Rotation * Mult, atom.Translation * Mult, atom.Scale * Mult);
			}



			public void AddAssign( in FBoneAtom Atom )
			{
				Translation += Atom.Translation;

				Rotation.X += Atom.Rotation.X;
				Rotation.Y += Atom.Rotation.Y;
				Rotation.Z += Atom.Rotation.Z;
				Rotation.W += Atom.Rotation.W;

				Scale += Atom.Scale;
			}
		}



		public struct VJointPos
		{
			public Quat   	Orientation;  //
			public Vector		Position;     //  needed or not ?

			//public float       Length;       //  For collision testing / debugging drawing...
			//public float       XSize;
			//public float       YSize;
			//public float       ZSize;
		}



		/// <summary> Dummy </summary>
		public struct FMeshBone
		{
			public name 		Name;		  // Bone's name.
			//public int		    Flags;        // reserved
			public VJointPos	BonePos;      // reference position
			public int         ParentIndex;  // 0/NULL if this is the root bone.  
			public int 		NumChildren;  // children  // only needed in animation ?
			public int         Depth;        // Number of steps to root in the skeletal hierarcy; root=0.

			// DEBUG rendering
			//FColor		BoneColor;		// Color to use when drawing bone on screen.
		}



		public const string NAME_None = default;

	/// <summary>
	/// Reset the specified TargetWeight array to the given number of children.
	/// </summary>
	protected static void ResetTargetWeightArray(ref array<float> TargetWeight, int ChildNum)
	{
		TargetWeight.Empty();
		if( ChildNum > 0 )
		{
			TargetWeight.AddZeroed( ChildNum );
			TargetWeight[0] = 1f;
		}
	}


	public virtual void BuildTickArray(ref MEdge.array<AnimNode> OutTickArray) {}



	public virtual void TickAnim( float DeltaSeconds, float TotalWeight ) {}



	/// <summary>
/// Do any initialisation. Should not reset any state of the animation tree so should be safe to call multiple times.
/// However, the SkeletalMesh may have changed on the SkeletalMeshComponent, so should update any data that relates to that.
/// 
/// @param meshComp SkeletalMeshComponent to which this node of the tree belongs.
/// @param Parent Parent blend node (will be null for root note).
/// </summary>
public virtual void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
{
	SkelComponent = meshComp;

	OnInit();
}



/// <summary>
/// AnimSets have been updated, update all animations 
/// </summary>
public virtual void AnimSetsUpdated()
{
	// Update bNodeTickStatus flag to avoid updating several times the same nodes.
	if( SkelComponent )
	{
		NodeTickTag = SkelComponent.TickTag;
	}
}



/// <summary>
/// Fills the Atoms array with the specified skeletal mesh reference pose.
/// 
/// @param OutAtoms			[out] Output array of relative bone transforms. Must be the same length as RefSkel when calling function.
/// @param DesiredBones		Indices of bones we want to modify. Parents must occur before children.
/// @param RefSkel			Input reference skeleton to create atoms from.
/// </summary>
public static void FillWithRefPose(ref MEdge.array<BoneAtom> OutAtoms,  in MEdge.array<byte> DesiredBones,  in MEdge.array<FMeshBone> RefSkel)
{
	check( OutAtoms.Num() == RefSkel.Num() );

	for(int i=0; i<DesiredBones.Num(); i++)
	{
		int BoneIndex				= DesiredBones[i];
		ref FMeshBone RefSkelBone	= ref RefSkel[BoneIndex];
		ref BoneAtom OutAtom		= ref OutAtoms[BoneIndex];

		OutAtom.Rotation	= RefSkelBone.BonePos.Orientation;
		OutAtom.Translation	= RefSkelBone.BonePos.Position;
		OutAtom.Scale		= 1f;
		//Atoms[BoneIndex] = BoneAtom( RefSkel[BoneIndex].BonePos.Orientation, RefSkel[BoneIndex].BonePos.Position, 1f );		
	}
}


/// <summary>
/// 	tility for taking an array of bone indices and ensuring that all parents are present 
/// 	(ie. all bones between those in the array and the root are present). 
/// 	Note that this must ensure the invariant that parent occur before children in BoneIndices.
/// </summary>
public virtual void EnsureParentsPresent(ref MEdge.array<byte> BoneIndices, ref SkeletalMesh SkelMesh)
{
	// Iterate through existing array.
	int i=0;
	while( i<BoneIndices.Num() )
	{
		 byte BoneIndex = BoneIndices[i];

		// For the root bone, just move on.
		if( BoneIndex > 0 )
		{
			// Warn if we're getting bad data.
			// Bones are matched as int, and a non found bone will be set to INDEX_NONE == -1
			// This will be turned into a 255 byte
			// This should never happen, so if it does, something is wrong!
			if( BoneIndex >= SkelMesh.RefSkeleton.Num() )
			{
				debugf(TEXT("AnimNode.EnsureParentsPresent, BoneIndex >= SkelMesh.RefSkeleton.Num()."));
				i++;
				continue;
			}

			byte ParentIndex = checked((byte)SkelMesh.RefSkeleton[BoneIndex].ParentIndex);

			// If we do not have this parent in the array, we add it in this location, and leave 'i' where it is.
			if( !BoneIndices.ContainsItem(ParentIndex) )
			{
				BoneIndices.Insert(i);
				BoneIndices[i] = ParentIndex;
			}
			// If parent was in array, just move on.
			else
			{
				i++;
			}
		}
		else
		{
			i++;
		}
	}
}

/// <summary>
/// Get the set of bone 'atoms' (ie. transform of bone relative to parent bone) generated by the blend subtree starting at this node.
/// 
/// @param	Atoms			Output array of bone transforms. Must be correct size when calling function - that is one entry for each bone. Contents will be erased by function though.
/// @param	DesiredBones	Indices of bones that we want to return. Note that bones not in this array will not be modified, so are not safe to access! Parents must occur before children.
/// </summary>
public virtual void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	// No root motion here, move along, nothing to see...
	RootMotionDelta = BoneAtom.Identity;
	bHasRootMotion	= false;

	 int NumAtoms = SkelComponent.SkeletalMesh.RefSkeleton.Num();
	check(NumAtoms == Atoms.Num());
	FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
}

/// <summary>
/// 	Will copy the cached results into the OutAtoms array if they are up to date and return true 
/// 	If cache is not up to date, does nothing and returns false.
/// </summary>
protected bool GetCachedResults(ref MEdge.array<BoneAtom> OutAtoms, ref BoneAtom OutRootMotionDelta, ref bool bOutHasRootMotion)
{
	check(SkelComponent);

	// See if results are cached, and cached array is the same size as the target array.
	if( NodeCachedAtomsTag == SkelComponent.CachedAtomsTag && 
		CachedBoneAtoms.Num() == OutAtoms.Num() )
	{
		OutAtoms = CachedBoneAtoms;
		OutRootMotionDelta = CachedRootMotionDelta;
		bOutHasRootMotion = bCachedHasRootMotion;
		return true;
	}
	else
	{
		return false;
	}
}

protected bool ShouldSaveCachedResults()
{
	// Do not cache results for nodes which only have one parent- it is unnecessary.
	return (ParentNodes.Num() > 1);
}

/// <summary>
/// Save the supplied array of BoneAtoms in the CachedBoneAtoms. 
/// </summary>
public virtual void SaveCachedResults( ref MEdge.array<BoneAtom> NewAtoms,  ref BoneAtom NewRootMotionDelta, bool bNewHasRootMotion)
{
	check(SkelComponent);

	// We make sure the cache is empty.
	if( !ShouldSaveCachedResults() )
	{
		CachedBoneAtoms.Empty();
	}
	else
	{
		CachedBoneAtoms = NewAtoms;
		CachedRootMotionDelta = NewRootMotionDelta;
		bCachedHasRootMotion = bNewHasRootMotion;
	}

	// Change flag to indicate cache is up to date
	NodeCachedAtomsTag = SkelComponent.CachedAtomsTag;
}

protected static bool bNodeSearching;
protected static int CurrentSearchTag;
public virtual void GetNodes(ref MEdge.array<AnimNode> Nodes)
{
	// we can't start another search while we're already in one as it would invalidate SearchTags on the original search
	check(!bNodeSearching);

	// set flag allowing GetNodesInternal()
	bNodeSearching = true;
	// increment search tag so all nodes in the tree will consider themselves once
	CurrentSearchTag++;
	GetNodesInternal(ref Nodes);
	// reset flag
	bNodeSearching = false;
}

/// <summary>
/// Find all AnimNodes including and below this one in the tree. Results are arranged so that parents are before children in the array.
/// 
/// @param Nodes Output array of AnimNode pointers.
/// </summary>
public virtual void GetNodesInternal(ref MEdge.array<AnimNode> Nodes)
{
	// make sure we're only called from inside GetNodes() or another GetNodesInternal()
	check(bNodeSearching);

	if (SearchTag != CurrentSearchTag)
	{
		SearchTag = CurrentSearchTag;
		Nodes.AddItem(this);
	}
}

/// <summary>
/// Return an array with all AnimNodeSequence childs, including this node. 
/// </summary>
public virtual void GetAnimSeqNodes(ref MEdge.array<AnimNodeSequence> Nodes, string InSynchGroupName = NAME_None)
{
	MEdge.array<AnimNode> AllNodes = new array<AnimNode>();
	GetNodes(ref AllNodes);

	Nodes.Reserve(AllNodes.Num());
	for (int i = 0; i < AllNodes.Num(); i++)
	{
		AnimNodeSequence SeqNode = (AllNodes[i] as AnimNodeSequence);
		if (SeqNode != null && (InSynchGroupName == NAME_None || InSynchGroupName == SeqNode.SynchGroupName))
		{
			Nodes.AddItem(SeqNode);
		}
	}
}


/// <summary>
/// tility for counting the number of parents of this node that have been ticked. 
/// </summary>
public int CountNumParentsTicked()
{
	int NumParentsTicked = 0;
	for(int i=0; i<ParentNodes.Num(); i++)
	{
		if(ParentNodes[i].NodeTickTag == SkelComponent.TickTag)
		{
			NumParentsTicked++;
		}
	}
	return NumParentsTicked;
}

/// <summary>
/// Returns true if this node is a child of given Node 
/// </summary>
public bool IsChildOf(AnimNode Node)
{
	if( Node == null )
	{
		return false;
	}

	if( this == Node )
	{
		return true;
	}

	for(int i=0; i<ParentNodes.Num(); i++)
	{
		if( ParentNodes[i].IsChildOf(Node) )
		{
			return true;
		}
	}

	return false;
}

 public virtual void PlayAnim(bool bLoop, float Rate, float StartTime)
{}


public virtual void StopAnim()
{}

/// <summary>
/// Get relative position of a synchronized node. 
/// Taking into account node's relative offset.
/// </summary>
protected static float GetNodeRelativePosition(AnimNodeSequence SeqNode)
{
	if( SeqNode && SeqNode.AnimSeq && SeqNode.AnimSeq.SequenceLength > 0f )
	{
		// Find it's relative position on its time line.
		float RelativePosition = appFmod((SeqNode.CurrentTime / SeqNode.AnimSeq.SequenceLength) - SeqNode.SynchPosOffset, 1f);
		if( RelativePosition < 0f )
		{
			RelativePosition += 1f;
		}

		return RelativePosition;
	}

	return 0f;
}

/// <summary>
/// Find out position of a synchronized node given a relative position. 
/// Taking into account node's relative offset.
/// </summary>
protected static float FindNodePositionFromRelative(AnimNodeSequence SeqNode, float RelativePosition)
{
	if( SeqNode && SeqNode.AnimSeq )
	{
		float SynchedRelPosition = appFmod(RelativePosition + SeqNode.SynchPosOffset, 1f);
		if( SynchedRelPosition < 0f )
		{
			SynchedRelPosition += 1f;
		}

		return SynchedRelPosition * SeqNode.AnimSeq.SequenceLength;
	}

	return 0f;
}
}

public partial class AnimNodeBlendBase
{
/// <summary>
/// Do any initialisation. Should not reset any state of the animation tree so should be safe to call multiple times.
/// For a blend, will call InitAnim on any child nodes.
/// 
/// @param meshComp SkeletalMeshComponent to which this node of the tree belongs.
/// @param Parent Parent blend node (will be null for root note).
/// </summary>
public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(meshComp, Parent);

	for(int i=0; i<Children.Num(); i++)
	{
		if( Children[i].Anim )
		{
			// If this is the first time this node has been encountered, call InitAnim on it.
			if(Children[i].Anim.ParentNodes.Num() == 0)
			{
				Children[i].Anim.InitAnim( meshComp, this );
			}

			// Add this node as a parent of the child.
			Children[i].Anim.ParentNodes.AddItem(this);
		}
	}
}

/// <summary>
/// Used for building array of AnimNodes in 'tick' order - that is, all parents of a node are added to array before it. 
/// </summary>
public override void BuildTickArray(ref MEdge.array<AnimNode> OutTickArray)
{
	// Then iterate over calling BuildTickArray on any children who have had all parents updated.
	for(int i=0; i<Children.Num(); i++)
	{
		ref AnimNode ChildNode = ref Children[i].Anim;
		if( ChildNode )
		{
			bool bAllParentsWereTicked = (ChildNode.CountNumParentsTicked() == ChildNode.ParentNodes.Num());
			if( bAllParentsWereTicked && ChildNode.NodeTickTag != SkelComponent.TickTag )
			{
				// Add to array
				OutTickArray.AddItem(ChildNode);
				// se tick tag to indicate it was added
				ChildNode.NodeTickTag = SkelComponent.TickTag;
				// Call to add its children.
				ChildNode.BuildTickArray(ref OutTickArray);
			}
		}
	}
}

/// <summary>
/// AnimSets have been updated, update all animations 
/// </summary>
public override void AnimSetsUpdated()
{
	base.AnimSetsUpdated();

	for(int i=0; i<Children.Num(); i++)
	{
		// Forward update to nodes who haven't received it yet.
		if( Children[i].Anim && SkelComponent && Children[i].Anim.NodeTickTag != SkelComponent.TickTag )
		{
			Children[i].Anim.AnimSetsUpdated();
		}
	}
}

/// <summary>
/// Calculates total weight of children 
/// </summary>
public virtual void SetChildrenTotalWeightAccumulator( int Index)
{
	// pdate the weight of this connection
	Children[Index].TotalWeight = NodeTotalWeight * Children[Index].Weight;

	// pdate the accumulator to find out the combined weight of the child node
	Children[Index].Anim.TotalWeightAccumulator += Children[Index].TotalWeight;
}

/// <summary>
/// 	Do any time-dependent work in the blend, changing blend weights etc.
/// 	We have code here to ensure that a child node is not ticked until all of its parents have been.
/// 
/// @param DeltaSeconds Size of timestep we are advancing animation tree by. In seconds.
/// </summary>
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	// Iterate over each child, updating this nodes contribution to its weight.
	// Only if node is relevant, otherwise it's always going to be zero.
	if( bRelevant )
	{
		for(int ChildIndex=0; ChildIndex<Children.Num(); ChildIndex++)
		{
			AnimNode ChildNode = Children[ChildIndex].Anim;
			if( ChildNode )
			{
				// Calculate the 'global weight' of the connection to this child.
				SetChildrenTotalWeightAccumulator(ChildIndex);
			}
		}
	}
}

/// <summary>
/// Find all AnimNodes including and below this one in the tree. Results are arranged so that parents are before children in the array.
/// For a blend node, will recursively call GetNodes on all child nodes.
/// 
/// @param Nodes Output array of AnimNode pointers.
/// </summary>
public override void GetNodesInternal(ref MEdge.array<AnimNode> Nodes)
{
	// make sure we're only called from inside GetNodes() or another GetNodesInternal()
	check(bNodeSearching);

	if (SearchTag != CurrentSearchTag)
	{
		SearchTag = CurrentSearchTag;
		Nodes.AddItem(this);
		for (int i = 0; i < Children.Num(); i++)
		{
			if (Children[i].Anim != null)
			{
				Children[i].Anim.GetNodesInternal(ref Nodes);
			}
		}
	}
}
/// <summary>
/// Blends together the Children AnimNodes of this blend based on the Weight in each element of the Children array.
/// Instead of using SLERPs, the blend is done by taking a weighted sum of each atom, and renormalising the quaternion part at the end.
/// This allows n-way blends, and makes the code much faster, though the angular velocity will not be constant across the blend.
/// 
/// @param	Atoms			Output array of relative bone transforms.
/// @param	DesiredBones	Indices of bones that we want to return. Note that bones not in this array will not be modified, so are not safe to access! 
/// 							This array must be in strictly increasing order.
/// </summary>
public override void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	// See if results are cached.
	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	// Handle case of a blend with no children.
	if( Children.Num() == 0 )
	{
		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	= false;
		FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}

#if false //_DEBUG
	// Check all children weights sum to 1.0
	if( Abs(GetChildWeightTotal() - 1f) > ZERO_ANIMWEIGHT_THRESH )
	{
		debugf( TEXT("WARNING: AnimNodeBlendBase (%s) has Children weights which do not sum to 1.0."), *Name );

		float TotalWeight = 0f;
		for(int i=0; i<Children.Num(); i++)
		{
			debugf( TEXT("Child: %d Weight: %f"), i, Children[i].Weight );

			TotalWeight += Children[i].Weight;
		}

		debugf( TEXT("Total Weight: %f"), TotalWeight );
		//@todo - adjust first node weight to 

		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	= false;
		FillWithRefPose(Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}
#endif

	 int NumAtoms = SkelComponent.SkeletalMesh.RefSkeleton.Num();
	check( NumAtoms == Atoms.Num() );

	// Find index of the last child with a non-zero weight.
	int LastChildIndex = INDEX_NONE;
	for(int i=0; i<Children.Num(); i++)
	{
		if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
		{
			// If this is the only child with any weight, pass Atoms array into it directly.
			if( Children[i].Weight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				if( Children[i].Anim )
				{
					// EXCLUDE_CHILD_TIME
					if( Children[i].bMirrorSkeleton )
					{
						GetMirroredBoneAtoms(ref Atoms, i, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
					}
					else
					{
						Children[i].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
					}
				}
				else
				{
					RootMotionDelta = BoneAtom.Identity;
					bHasRootMotion	= false;
					FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
				}

				// If we're modifying the input, then cache results.
				// Otherwise just pass through without caching anything.
				if( Children[i].bMirrorSkeleton )
				{
					SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
				}
				return;
			}
			LastChildIndex = i;
		}
	}
	check(LastChildIndex != INDEX_NONE);

	// We don't allocate this array until we need it.
	MEdge.array<BoneAtom> ChildAtoms = new array<BoneAtom>();
	bool bNoChildrenYet = true;

	bHasRootMotion						= false;
	int		LastRootMotionChildIndex	= INDEX_NONE;
	float	AccumulatedRootMotionWeight	= 0f;

	// Iterate over each child getting its atoms, scaling them and adding them to output (Atoms array)
	for(int i=0; i<=LastChildIndex; i++)
	{
		// If this child has non-zero weight, blend it into accumulator.
		if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
		{
			// Do need to request atoms, so allocate array here.
			if( ChildAtoms.Num() == 0 )
			{
				ChildAtoms.AddCount(NumAtoms);
			}

			// Get bone atoms from child node (if no child - use ref pose).
			if( Children[i].Anim )
			{
				// EXCLUDE_CHILD_TIME
				if( Children[i].bMirrorSkeleton )
				{
					GetMirroredBoneAtoms(ref ChildAtoms, i, ref DesiredBones, ref Children[i].RootMotion, ref Children[i].bHasRootMotion);
				}
				else
				{
					Children[i].Anim.GetBoneAtoms(ref ChildAtoms, ref DesiredBones, ref Children[i].RootMotion, ref Children[i].bHasRootMotion);
				}


				// If this children received root motion information, accumulate its weight
				if( Children[i].bHasRootMotion )
				{
					bHasRootMotion				= true;
					LastRootMotionChildIndex	= i;
					AccumulatedRootMotionWeight += Children[i].Weight;
				}
			}
			else
			{	
				Children[i].RootMotion		= BoneAtom.Identity;
				Children[i].bHasRootMotion	= false;
				FillWithRefPose(ref ChildAtoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
			}

			for(int j=0; j<DesiredBones.Num(); j++)
			{
				 int BoneIndex = DesiredBones[j];

				// We just write the first childrens atoms into the output array. Avoids zero-ing it out.
				if( bNoChildrenYet )
				{
					Atoms[BoneIndex] = ChildAtoms[BoneIndex] * Children[i].Weight;
				}
				else
				{
					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
					if( (Atoms[BoneIndex].Rotation | ChildAtoms[BoneIndex].Rotation) < 0f )
					{
						ChildAtoms[BoneIndex].Rotation = ChildAtoms[BoneIndex].Rotation * -1f;
					}

					Atoms[BoneIndex].AddAssign(ChildAtoms[BoneIndex] * Children[i].Weight);
				}

				// If last child - normalize the rotation quaternion now.
				if( i == LastChildIndex )
				{
					Atoms[BoneIndex].Rotation.Normalize();
				}
			}

			bNoChildrenYet = false;
		}
	}

	// 2nd pass, iterate over all childs who received root motion
	// And blend root motion only between these childs.
	if( bHasRootMotion )
	{
		bNoChildrenYet = true;
		for(int i=0; i<=LastRootMotionChildIndex; i++)
		{
			if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH && Children[i].bHasRootMotion )
			{
				 float	Weight				= Children[i].Weight / AccumulatedRootMotionWeight;
				BoneAtom	WeightedRootMotion	= Children[i].RootMotion * Weight;


#if false // Debug Root Motion
				if( !WeightedRootMotion.Translation.IsZero() )
				{
					debugf(TEXT("%3.2f [%s]  Adding weighted (%3.2f) root motion trans: %3.2f, vect: %s. ChildWeight: %3.3f"), GWorld.GetTimeSeconds(), *SkelComponent.Owner.Name, Weight, WeightedRootMotion.Translation.Size(), *WeightedRootMotion.Translation.ToString(), Children[i].Weight);
				}
#endif

				// Accumulate Root Motion
				if( bNoChildrenYet )
				{
					RootMotionDelta = WeightedRootMotion;
					bNoChildrenYet	= false;
				}
				else
				{
					// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
					if( (RootMotionDelta.Rotation | WeightedRootMotion.Rotation) < 0f )
					{
						WeightedRootMotion.Rotation = WeightedRootMotion.Rotation * -1f;
					}

					RootMotionDelta.AddAssign(WeightedRootMotion);
				}
			}
		}

		// Normalize rotation quaternion at the end.
		RootMotionDelta.Rotation.Normalize();
	}

#if false // Debug Root Motion
	if( !RootMotionDelta.Translation.IsZero() )
	{
		debugf(TEXT("%3.2f [%s] Root Motion Trans: %3.2f, vect: %s"), GWorld.GetTimeSeconds(), *SkelComponent.Owner.Name, RootMotionDelta.Translation.Size(), *RootMotionDelta.Translation.ToString());
	}
#endif

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}

/// <summary>
/// Get mirrored bone atoms from desired child index. 
/// Bones are mirrored using the SkelMirrorTable.
/// </summary>
public virtual void GetMirroredBoneAtoms(ref MEdge.array<BoneAtom> Atoms, int ChildIndex, ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	ref SkeletalMesh SkelMesh = ref SkelComponent.SkeletalMesh;
	check(SkelMesh);

	// If mirroring is enabled, and the mirror info array is initialized correctly.
	if( SkelMesh.SkelMirrorTable.Num() == Atoms.Num() )
	{
		// Get atoms from SourceNode.
		MEdge.array<BoneAtom> ChildAtoms = new();
		ChildAtoms.AddCount(Atoms.Num());

		BoneAtom RMD = default;
		if( Children[ChildIndex].Anim )
		{
			Children[ChildIndex].Anim.GetBoneAtoms(ref ChildAtoms, ref DesiredBones, ref RMD, ref bHasRootMotion);
		}
		else
		{
			RMD				= BoneAtom.Identity;
			bHasRootMotion	= false;
			FillWithRefPose(ref ChildAtoms, DesiredBones, SkelMesh.RefSkeleton);
		}

		{
			//SCOPE_CYCLE_COUNTER(STAT_MirrorBoneAtoms);


			// We build the mesh-space matrices of the source bones.
			MEdge.array<MEdge.Core.Object.Matrix> BoneTM = new ();
			BoneTM.AddCount(SkelMesh.RefSkeleton.Num());

			for(int i=0; i<DesiredBones.Num(); i++)
			{	
				 int BoneIndex = DesiredBones[i];

				if( BoneIndex == 0 )
				{
					ChildAtoms[0].ToTransform(ref BoneTM[0]);
				}
				else
				{
					MEdge.Core.Object.Matrix LocalBoneTM = new();
					ChildAtoms[BoneIndex].ToTransform(ref LocalBoneTM);

					 int ParentIndex	= SkelMesh.RefSkeleton[BoneIndex].ParentIndex;
					BoneTM[BoneIndex]		= LocalBoneTM * BoneTM[ParentIndex];
				}
			}

			// Then we do the mirroring.

			// Make array of flags to track which bones have already been mirrored.
			MEdge.array<bool> BoneMirrored = new();
			BoneMirrored.InsertZeroed(0, Atoms.Num());

			for(int i=0; i<DesiredBones.Num(); i++)
			{
				int BoneIndex = DesiredBones[i];
				if( BoneMirrored[BoneIndex] )
				{
					continue;
				}

				int SourceIndex = SkelMesh.SkelMirrorTable[BoneIndex].SourceIndex;

				// Get 'flip axis' from SkeletalMesh, unless we have specified an override for that bone.
				var FlipAxis = SkelMesh.SkelMirrorFlipAxis;
				if( SkelMesh.SkelMirrorTable[BoneIndex].BoneFlipAxis != AXIS_NONE )
				{
					FlipAxis = SkelMesh.SkelMirrorTable[BoneIndex].BoneFlipAxis;
				}

				// Mirror the root motion delta
				// @fixme laurent -- add support for root rotation and mirroring
				if( BoneIndex == 0 )
				{
					RootMotionDelta = BoneAtom.Identity;

					if( bHasRootMotion && !RMD.Translation.IsZero() )
					{
						var RootTM = FTranslationMatrix(RMD.Translation);
						RootTM.Mirror(SkelMesh.SkelMirrorAxis, FlipAxis);
						RootMotionDelta.Translation = RootTM.GetOrigin();
					}
				}

				if( BoneIndex == SourceIndex )
				{
					BoneTM[BoneIndex].Mirror(SkelMesh.SkelMirrorAxis, FlipAxis);
					BoneMirrored[BoneIndex] = true;
				}
				else
				{
					// get source flip axis
					var SourceFlipAxis = SkelMesh.SkelMirrorFlipAxis;
					if( SkelMesh.SkelMirrorTable[SourceIndex].BoneFlipAxis != AXIS_NONE )
					{
						SourceFlipAxis = SkelMesh.SkelMirrorTable[SourceIndex].BoneFlipAxis;
					}

					MEdge.Core.Object.Matrix BoneTransform0 = BoneTM[BoneIndex];
					MEdge.Core.Object.Matrix BoneTransform1 = BoneTM[SourceIndex];
					BoneTransform0.Mirror(SkelMesh.SkelMirrorAxis, SourceFlipAxis);
					BoneTransform1.Mirror(SkelMesh.SkelMirrorAxis, FlipAxis);
					BoneTM[BoneIndex]			= BoneTransform1;
					BoneTM[SourceIndex]			= BoneTransform0;
					BoneMirrored[BoneIndex]		= true;
					BoneMirrored[SourceIndex]	= true;
				}
			}

			// Now we need to convert this back into local space transforms.
			for(int i=0; i<DesiredBones.Num(); i++)
			{
				 int BoneIndex = DesiredBones[i];

				if( BoneIndex == 0 )
				{
					Atoms[BoneIndex] = new(BoneTM[BoneIndex]);
				}
				else
				{
					Atoms[BoneIndex] = new(BoneTM[BoneIndex] * BoneTM[SkelMesh.RefSkeleton[BoneIndex].ParentIndex].Inverse());
				}
			}
		}
	}
	// Otherwise, just pass right through.
	else
	{
		if( Children[ChildIndex].Anim )
		{
			Children[ChildIndex].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
		}
		else
		{
			RootMotionDelta	= BoneAtom.Identity;
			bHasRootMotion	= false;
			FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		}
	}
}

/// <summary>
/// For debugging.
/// 
/// @return Sum weight of all children weights. Should always be 1.0
/// </summary>
protected float GetChildWeightTotal()
{
	float TotalWeight = 0f;

	for(int i=0; i<Children.Num(); i++)
	{
		TotalWeight += Children[i].Weight;
	}

	return TotalWeight;
}

/// <summary>
/// Make sure to relay OnChildAnimEnd to Parent AnimNodeBlendBase as long as it exists 
/// </summary>
public virtual void OnChildAnimEnd(AnimNodeSequence Child, float PlayedTime, float ExcessTime) 
{ 
	for(int i=0; i<ParentNodes.Num(); i++)
	{
		ParentNodes[i].OnChildAnimEnd(Child, PlayedTime, ExcessTime); 
	}
}

public override void PlayAnim(bool bLoop, float Rate, float StartTime)
{
	// pass on the call to our children
	for (int i = 0; i < Children.Num(); i++)
	{
		if (Children[i].Anim != null)
		{
			Children[i].Anim.PlayAnim(bLoop, Rate, StartTime);
		}
	}
}

public override void StopAnim()
{
	// pass on the call to our children
	for (int i = 0; i < Children.Num(); i++)
	{
		if (Children[i].Anim != null)
		{
			Children[i].Anim.StopAnim();
		}
	}
}

/// <summary>
/// Rename all child nodes upon Add/Remove, so they match their position in the array. 
/// </summary>
public virtual void RenameChildConnectors()
{
	for(int i=0; i<Children.Num(); i++)
	{
		Children[i].Name = $"Child{i + 1}";
	}
}
/// <summary>
/// A child connector has been added 
/// </summary>
public virtual void OnAddChild(int ChildNum)
{
	// Make sure name matches position in array.
	RenameChildConnectors();
}

/// <summary>
/// A child connector has been removed 
/// </summary>
public virtual void OnRemoveChild(int ChildNum)
{
	// Make sure name matches position in array.
	RenameChildConnectors();
}

}

public partial class AnimNodeBlend
{
/// <summary>
/// see AnimNode.TickAnim 
///</summary>
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	//@todo: Fix me.  Asserting should not occur here.  We should pop up an error or
	//       fix the asset in CheckErrors / 
	//check(Children.Num() == 2);
	if( Children.Num() != 2 )
	{
		base.TickAnim(DeltaSeconds, TotalWeight);
		return;
	}
	   
	if( BlendTimeToGo != 0f )
	{
		// Amount we want to change Child2Weight by.
		 float BlendDelta = Child2WeightTarget - Child2Weight; 

		if( Abs(BlendDelta) > KINDA_SMALL_NUMBER && BlendTimeToGo > DeltaSeconds )
		{
			Child2Weight	+= (BlendDelta / BlendTimeToGo) * DeltaSeconds;
			BlendTimeToGo	-= DeltaSeconds;
		}
		else
		{
			Child2Weight	= Child2WeightTarget;
			BlendTimeToGo	= 0f;
		}
	}

	// debugf(TEXT("Blender: %s (%x) Child2Weight: %f BlendTimeToGo: %f"), *GetPathName(), (int)this, Child2BoneWeights.ChannelWeight, BlendTimeToGo);
	Children[0].Weight = 1f - Child2Weight;
	Children[1].Weight = Child2Weight;

	base.TickAnim(DeltaSeconds, TotalWeight);
}

/// <summary>
/// Set desired balance of this blend.
/// 
/// @param BlendTarget Target amount of weight to put on Children[1] (second child). Between 0.0 and 1.0. 1.0 means take all animation from second child.
/// @param BlendTime How long to take to get to BlendTarget.
/// </summary>
public virtual void SetBlendTarget(float BlendTarget, float BlendTime)
{
	Child2WeightTarget = Clamp(BlendTarget, 0f, 1f);
	
	// If we want this weight NOW - update weights straight away (dont wait for TickAnim).
	if( BlendTime <= 0.0f )
	{
		Child2Weight		= Child2WeightTarget;
		Children[0].Weight	= 1f - Child2Weight;
		Children[1].Weight	= Child2Weight;
	}

	BlendTimeToGo = BlendTime;
}
}

public partial class AnimNodeCrossfader
{
/// <summary>
/// see AnimNode.InitAnim 
///</summary>
public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
{
	base.InitAnim( meshComp, Parent );
	
	AnimNodeSequence ActiveChild = GetActiveChild();
	if( ActiveChild && ActiveChild.AnimSeqName == NAME_None )
	{
		SetAnim( DefaultAnimSeqName );
	}
}

/// <summary>
/// see AnimNode.TickAnim 
///</summary>
public override void TickAnim( float DeltaSeconds, float TotalWeight )
{
	if( !bDontBlendOutOneShot && PendingBlendOutTimeOneShot > 0f )
	{
		AnimNodeSequence ActiveChild = GetActiveChild();

		if( ActiveChild && ActiveChild.AnimSeq )
		{
			float	fCountDown = ActiveChild.AnimSeq.SequenceLength - ActiveChild.CurrentTime;
			
			// if playing a one shot anim, and it's time to blend back to previous animation, do so.
			if( fCountDown <= PendingBlendOutTimeOneShot )
			{
				SetBlendTarget( 1f - Child2WeightTarget, PendingBlendOutTimeOneShot );
				PendingBlendOutTimeOneShot = 0f;
			}
		}
	}

	// Tick AnimNodeBlend
	base.TickAnim( DeltaSeconds, TotalWeight );
}

/// <summary>
/// see AnimCrossfader.GetAnimName 
///</summary>
public MEdge.Core.name GetAnimName()
{
	AnimNodeSequence ActiveChild = GetActiveChild();
	if( ActiveChild )
	{
		return ActiveChild.AnimSeqName;
	}
	else
	{
		return NAME_None;
	}
}

/// <summary>
/// Get active AnimNodeSequence child. To access animation properties and control functions.
/// 
/// @return	AnimNodeSequence currently playing.
/// </summary>
public AnimNodeSequence GetActiveChild()
{
	// requirements for the crossfader. Just exit if not met, do not crash.
	if( Children.Num() != 2 ||	// needs 2 childs
		!Children[0].Anim ||	// properly connected
		!Children[1].Anim )
	{
		return null;
	}

	return (Child2WeightTarget < 0.5f ? Children[0].Anim : Children[1].Anim) as AnimNodeSequence;
}

/// <summary>
/// see AnimNodeCrossFader.PlayOneShotAnim 
///</summary>
public virtual void /*exec*/PlayOneShotAnim(MEdge.Core.name AnimSeqName, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bDontBlendOut = default, /*optional */float? _Rate = default)
{
	float BlendInTime = _BlendInTime ?? 0f;
	float BlendOutTime = _BlendOutTime ?? 0f;
	bool bDontBlendOut = _bDontBlendOut ?? false;
	float Rate = _Rate ?? 1f;

	// requirements for the crossfader. Just exit if not met, do not crash.
	if( Children.Num() != 2 ||	// needs 2 childs
		!Children[0].Anim ||	// properly connected
		!Children[1].Anim ||
		SkelComponent == null )
	{
		return;
	}

	// Make sure AnimSeqName exists
	if( SkelComponent.FindAnimSequence( AnimSeqName ) == null )
	{
		debugf( "NAME_Warning",TEXT("%s - Failed to find animsequence '%s' on SkeletalMeshComponent: '%s' whose owner is: '%s' and is of type %s" ),
			Name,
			AnimSeqName.ToString(),
			SkelComponent.Name, 
			SkelComponent.Owner.Name,
			SkelComponent.TemplateName.ToString()
			);
		return;
	}

	AnimNodeSequence	Child = (Child2WeightTarget < 0.5f ? Children[1].Anim : Children[0].Anim) as AnimNodeSequence;

	if( Child )
	{
		float	BlendTarget			= Child2WeightTarget < 0.5f ? 1f : 0f;

		bDontBlendOutOneShot		= bDontBlendOut;
		PendingBlendOutTimeOneShot	= BlendOutTime;

		Child.SetAnim(AnimSeqName);
		Child.PlayAnim(false, Rate);
		SetBlendTarget( BlendTarget, BlendInTime );
	}
}

/// <summary>
/// see AnimNodeCrossFader.BlendToLoopingAnim 
///</summary>
public virtual void /*exec*/BlendToLoopingAnim(name AnimSeqName, /*optional */float? _BlendInTime = default, /*optional */float? _Rate = default)
{
	float BlendInTime = _BlendInTime ?? 0f;
	float Rate = _Rate ?? 1f;

	// requirements for the crossfader. Just exit if not met, do not crash.
	if( Children.Num() != 2 ||	// needs 2 childs
		!Children[0].Anim ||	// properly connected
		!Children[1].Anim ||
		SkelComponent == null )
	{
		return;
	}

	// Make sure AnimSeqName exists
	if( SkelComponent.FindAnimSequence( AnimSeqName ) == null )
	{
		debugf( "NAME_Warning",TEXT("%s - Failed to find animsequence '%s' on SkeletalMeshComponent: '%s' whose owner is: '%s' and is of type %s" ),
			Name,
			AnimSeqName.ToString(),
			SkelComponent.Name, 
			SkelComponent.Owner.Name,
			SkelComponent.TemplateName.ToString()
			);
		return;
	}

	AnimNodeSequence	Child = (Child2WeightTarget < 0.5f ? Children[1].Anim : Children[0].Anim) as AnimNodeSequence;

	if( Child )
	{
		float	BlendTarget			= Child2WeightTarget < 0.5f ? 1f : 0f;

		// One shot variables..
		bDontBlendOutOneShot		= true;
		PendingBlendOutTimeOneShot	= 0f;

		Child.SetAnim(AnimSeqName);
		Child.PlayAnim(true, Rate);
		SetBlendTarget( BlendTarget, BlendInTime );
	}
}
}


public partial class AnimNodeBlendPerBone
{

/// <summary>
/// Calculates total weight of children. 
/// Set a full weight on source, because it's potentially always feeding animations into the final blend.
/// </summary>
public override void SetChildrenTotalWeightAccumulator( int Index)
{
	if( Index == 0 )
	{
		// pdate the weight of this connection
		Children[Index].TotalWeight = NodeTotalWeight;
		// pdate the accumulator to find out the combined weight of the child node
		Children[Index].Anim.TotalWeightAccumulator += NodeTotalWeight;
	}
	else
	{
		// pdate the weight of this connection
		Children[Index].TotalWeight = NodeTotalWeight * Children[Index].Weight;
		// pdate the accumulator to find out the combined weight of the child node
		Children[Index].Anim.TotalWeightAccumulator += Children[Index].TotalWeight;
	}
}
public override void PostEditChange(MEdge.Core.Property PropertyThatChanged)
{
	if( PropertyThatChanged != null && 
		(PropertyThatChanged.GetFName() == TEXT("BranchStartBoneName")) )
	{
		BuildWeightList();
	}

	base.PostEditChange(PropertyThatChanged);
}

public virtual void BuildWeightList()
{
	if( !SkelComponent || !SkelComponent.SkeletalMesh )
	{
		return;
	}

	ref MEdge.array<FMeshBone> RefSkel	= ref SkelComponent.SkeletalMesh.RefSkeleton;
	int NumAtoms			= RefSkel.Num();

	Child2PerBoneWeight.Reset();
	Child2PerBoneWeight.AddZeroed(NumAtoms);

	MEdge.array<int> BranchStartBoneIndex = new();
	BranchStartBoneIndex.Add( BranchStartBoneName.Num() );

	for(int NameIndex=0; NameIndex<BranchStartBoneName.Num(); NameIndex++)
	{
		BranchStartBoneIndex[NameIndex] = SkelComponent.MatchRefBone( BranchStartBoneName[NameIndex] );
	}

	for(int i=0; i<NumAtoms; i++)
	{
		 int BoneIndex	= i;
		bool bBranchBone = BranchStartBoneIndex.ContainsItem(BoneIndex);

		if( bBranchBone )
		{
			Child2PerBoneWeight[BoneIndex] = 1f;
		}
		else
		{
			if( BoneIndex > 0 )
			{
				Child2PerBoneWeight[BoneIndex] = Child2PerBoneWeight[RefSkel[BoneIndex].ParentIndex];
			}
		}
	}

	// build list of required bones
	LocalToCompReqBones.Empty();

	float LastWeight = Child2PerBoneWeight[0];
	for(int i=0; i<NumAtoms; i++)
	{
		// if weight different than previous one, then this bone needs to be blended in component space
		if( Child2PerBoneWeight[i] != LastWeight )
		{
			LocalToCompReqBones.AddItem((byte)i);
			LastWeight = Child2PerBoneWeight[i];
		}
	}
	EnsureParentsPresent(ref LocalToCompReqBones, ref SkelComponent.SkeletalMesh);
}

/// <summary>
/// 	tility for taking two arrays of bytes, which must be strictly increasing, and finding the intersection between them.
/// 	That is - any item in the output should be present in both A and B. Output is strictly increasing as well.
/// </summary>
static void IntersectByteArrays(ref MEdge.array<byte> Output,  ref MEdge.array<byte> A,  ref MEdge.array<byte> B)
{
	int APos = 0;
	int BPos = 0;
	while(	APos < A.Num() && BPos < B.Num() )
	{
		// If value at APos is lower, increment APos.
		if( A[APos] < B[BPos] )
		{
			APos++;
		}
		// If value at BPos is lower, increment APos.
		else if( B[BPos] < A[APos] )
		{
			BPos++;
		}
		// If they are the same, put value into output, and increment both.
		else
		{
			Output.AddItem( A[APos] );
			APos++;
			BPos++;
		}
	}
}


public override void InitAnim(SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(meshComp, Parent);
	BuildWeightList();
}

// Arrays used for temporary bone blending
static MEdge.array<MEdge.Core.Object.Matrix> Child1CompSpace;
static MEdge.array<MEdge.Core.Object.Matrix> Child2CompSpace;
static MEdge.array<MEdge.Core.Object.Matrix> ResultCompSpace;
/// <summary>
/// see AnimNode.GetBoneAtoms. 
///</summary>
public override void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	// See if results are cached.
	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	// If drawing all from Children[0], no need to look at Children[1]. Pass Atoms array directly to Children[0].
	if( Children[0].Weight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
	{
		if( Children[0].Anim )
		{
			// EXCLUDE_CHILD_TIME
			Children[0].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
		}
		else
		{
			RootMotionDelta = BoneAtom.Identity;
			bHasRootMotion	= false;
			FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		}

		// Pass-through, no caching needed.
		return;
	}

	ref MEdge.array<FMeshBone> RefSkel = ref SkelComponent.SkeletalMesh.RefSkeleton;
	 int NumAtoms = RefSkel.Num();

	MEdge.array<BoneAtom> Child1Atoms = new(), Child2Atoms = new();

	// Get bone atoms from each child (if no child - use ref pose).
	Child1Atoms.AddCount(NumAtoms);
	BoneAtom	Child1RMD				= BoneAtom.Identity;
	bool  		bChild1HasRootMotion	= false;
	if( Children[0].Anim )
	{
		// EXCLUDE_CHILD_TIME
		Children[0].Anim.GetBoneAtoms(ref Child1Atoms, ref DesiredBones, ref Child1RMD, ref bChild1HasRootMotion);
	}
	else
	{
		FillWithRefPose(ref Child1Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
	}

	// Get only the necessary bones from child2. The ones that have a Child2PerBoneWeight[BoneIndex] > 0
	Child2Atoms.AddCount(NumAtoms);
	BoneAtom	Child2RMD				= BoneAtom.Identity;
	bool		bChild2HasRootMotion	= false;

	//debugf(TEXT("child2 went from %d bones to %d bones."), DesiredBones.Num(), Child2DesiredBones.Num() );
	if( Children[1].Anim )
	{
		// EXCLUDE_CHILD_TIME
		Children[1].Anim.GetBoneAtoms(ref Child2Atoms, ref DesiredBones, ref Child2RMD, ref bChild2HasRootMotion);
	}
	else
	{
		FillWithRefPose(ref Child2Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
	}

	// If we are doing component-space blend, ensure working buffers are big enough
	if(!bForceLocalSpaceBlend)
	{
		Child1CompSpace.Reset();
		Child1CompSpace.AddCount(NumAtoms);

		Child2CompSpace.Reset();
		Child2CompSpace.AddCount(NumAtoms);

		ResultCompSpace.Reset();
		ResultCompSpace.AddCount(NumAtoms);
	}

	int LocalToCompReqIndex = 0;

	// do blend
	for(int i=0; i<DesiredBones.Num(); i++)
	{
		 int	BoneIndex			= DesiredBones[i];
		 float Child2BoneWeight	= Children[1].Weight * Child2PerBoneWeight[BoneIndex];

		//debugf(TEXT("  (%2d) %1.1f %s"), BoneIndex, Child2PerBoneWeight[BoneIndex], *RefSkel[BoneIndex].Name);
		 bool bDoComponentSpaceBlend =	LocalToCompReqIndex < LocalToCompReqBones.Num() && 
												BoneIndex == LocalToCompReqBones[LocalToCompReqIndex];

		if( !bForceLocalSpaceBlend && bDoComponentSpaceBlend )
		{
			//debugf(TEXT("  (%2d) %1.1f %s"), BoneIndex, Child2PerBoneWeight[BoneIndex], *RefSkel[BoneIndex].Name);
			LocalToCompReqIndex++;

			 int ParentIndex	= RefSkel[BoneIndex].ParentIndex;

			// turn bone atoms to matrices
			Child1Atoms[BoneIndex].ToTransform(ref Child1CompSpace[BoneIndex]);
			Child2Atoms[BoneIndex].ToTransform(ref Child2CompSpace[BoneIndex]);

			// transform to component space
			if( BoneIndex > 0 )
			{
				Child1CompSpace[BoneIndex] *= Child1CompSpace[ParentIndex];
				Child2CompSpace[BoneIndex] *= Child2CompSpace[ParentIndex];
			}

			// everything comes from child1 copy directly
			if( Child2BoneWeight <= ZERO_ANIMWEIGHT_THRESH )
			{
				ResultCompSpace[BoneIndex] = Child1CompSpace[BoneIndex];
			}
			// everything comes from child2, copy directly
			else if( Child2BoneWeight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				ResultCompSpace[BoneIndex] = Child2CompSpace[BoneIndex];
			}
			// blend rotation in component space of both childs
			else
			{
				// convert matrices to FBoneAtoms
				BoneAtom Child1CompSpaceAtom = new BoneAtom(Child1CompSpace[BoneIndex]);
				BoneAtom Child2CompSpaceAtom = new BoneAtom(Child2CompSpace[BoneIndex]);

				// blend BoneAtom rotation. We store everything in Child1

				// We use a linear interpolation and a re-normalize for the rotation.
				// Treating Rotation as an accumulator, initialise to a scaled version of Atom1.
				Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation * (1f - Child2BoneWeight);

				// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming rotation is positive.
				if( (Child1CompSpaceAtom.Rotation | Child2CompSpaceAtom.Rotation) < 0f )
				{
					Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation * -1f;
				}

				// Then add on the second rotation..
				Child1CompSpaceAtom.Rotation = Child1CompSpaceAtom.Rotation + (Child2CompSpaceAtom.Rotation * Child2BoneWeight);

				// ..and renormalize
				Child1CompSpaceAtom.Rotation.Normalize();

				// convert back BoneAtom to MEdge.Core.Object.Matrix
				Child1CompSpaceAtom.ToTransform(ref ResultCompSpace[BoneIndex]);
			}

			// Blend Translation and Scale in local space
			if( Child2BoneWeight <= ZERO_ANIMWEIGHT_THRESH )
			{
				// if blend is all the way for child1, then just copy its bone atoms
				Atoms[BoneIndex] = Child1Atoms[BoneIndex];
			}
			else if( Child2BoneWeight >= (1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				// if blend is all the way for child2, then just copy its bone atoms
				Atoms[BoneIndex] = Child2Atoms[BoneIndex];
			}
			else
			{
				// Simple linear interpolation for translation and scale.
				Atoms[BoneIndex].Translation	= VLerp(Child1Atoms[BoneIndex].Translation, Child2Atoms[BoneIndex].Translation, Child2BoneWeight);
				Atoms[BoneIndex].Scale			= Lerp(Child1Atoms[BoneIndex].Scale, Child2Atoms[BoneIndex].Scale, Child2BoneWeight);
			}

			// and rotation was blended in component space...
			// convert bone atom back to local space
			MEdge.Core.Object.Matrix ParentTM = MEdge.Core.Object.Matrix.Identity;
			if( BoneIndex > 0 )
			{
				ParentTM = ResultCompSpace[ParentIndex];
			}

			// Then work out relative transform, and convert to BoneAtom.
			 MEdge.Core.Object.Matrix RelTM = ResultCompSpace[BoneIndex] * ParentTM.Inverse();				
			Atoms[BoneIndex].Rotation = new BoneAtom(RelTM).Rotation;
		}	
		else
		{
			// otherwise do faster local space blending.
			Atoms[BoneIndex].Blend(Child1Atoms[BoneIndex], Child2Atoms[BoneIndex], Child2BoneWeight);
		}

		// Blend root motion
		if( BoneIndex == 0 )
		{
			bHasRootMotion = bChild1HasRootMotion || bChild2HasRootMotion;

			if( bChild1HasRootMotion && bChild2HasRootMotion )
			{
				RootMotionDelta.Blend(Child1RMD, Child2RMD, Child2BoneWeight);
			}
			else if( bChild1HasRootMotion )
			{
				RootMotionDelta = Child1RMD;
			}
			else if( bChild2HasRootMotion )
			{
				RootMotionDelta = Child2RMD;
			}
		}
	}

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}
}



public partial class AnimNodeBlendDirectional
{

static float UnwindHeading( float A )
{
	const float PI2 = PI * 2f;
	float f = A % PI2;
	return 
		f > PI ? -PI2 + f : 
		f < -PI ? PI2 + f :
		f;
	// Below is the UE4 body for this function ...
	// I cannot believe that a professional developer would write something like this ...
	/*
	while(A > PI)
	{
		A -= ((FLOAT)PI * 2.0f);
	}

	while(A < -PI)
	{
		A += ((FLOAT)PI * 2.0f);
	}

	return A;*/
}

static float FindDeltaAngle(float A1, float A2)
{
	// Find the difference
	float Delta = A2 - A1;

	// If change is larger than PI
	if(Delta > PI)
	{
		// Flip to negative equivalent
		Delta = Delta - (PI * 2.0f);
	}
	else if(Delta < -PI)
	{
		// Otherwise, if change is smaller than -PI
		// Flip to positive equivalent
		Delta = Delta + (PI * 2.0f);
	}

	// Return delta in [-PI,PI] range
	return Delta;
}

/// <summary>
/// Updates weight of the 4 directional animation children by looking at the current velocity and heading of actor.
/// 
/// AnimNode.TickAnim
/// </summary>
public override void TickAnim( float DeltaSeconds, float TotalWeight )
{
	check(Children.Num() == 4);

	// Calculate DirAngle based on player velocity.
	Actor actor = SkelComponent.Owner; // Get the actor to use for acceleration/look direction etc.
	if( actor )
	{
		float TargetDirAngle = 0f;
		Vector	VelDir = actor.Velocity;
		VelDir.Z = 0.0f;

		if( VelDir.IsNearlyZero() )
		{
			TargetDirAngle = 0f;
		}
		else
		{
			VelDir = VelDir.SafeNormal();

			Vector LookDir = actor.Rotation.Vector();
			LookDir.Z = 0f;
			LookDir = LookDir.SafeNormal();

			Vector LeftDir = LookDir ^ new Vector(0f,0f,1f);
			LeftDir = LeftDir.SafeNormal();

			float ForwardPct = (LookDir | VelDir);
			float LeftPct = (LeftDir | VelDir);

			TargetDirAngle = appAcos(ForwardPct);
			if( LeftPct > 0f )
			{
				TargetDirAngle *= -1f;
			}
		}
		// Move DirAngle towards TargetDirAngle as fast as DirRadsPerSecond allows
		float DeltaDir = FindDeltaAngle(DirAngle, TargetDirAngle);
		if( DeltaDir != 0f )
		{
			float MaxDelta = DeltaSeconds * DirDegreesPerSecond * (PI/180f);
			DeltaDir = Clamp(DeltaDir, -MaxDelta, MaxDelta);
			DirAngle = UnwindHeading( DirAngle + DeltaDir );
		}
	}

	// Option to only choose one animation
	if(SkelComponent.PredictedLODLevel < SingleAnimAtOrAboveLOD)
	{
		// Work out child weights based on DirAngle.
		if(DirAngle < -0.5f*PI) // Back and left
		{
			Children[2].Weight = (DirAngle/(0.5f*PI)) + 2f;
			Children[3].Weight = 0f;

			Children[0].Weight = 0f;
			Children[1].Weight = 1f - Children[2].Weight;
		}
		else if(DirAngle < 0f) // Forward and left
		{
			Children[2].Weight = -DirAngle/(0.5f*PI);
			Children[3].Weight = 0f;

			Children[0].Weight = 1f - Children[2].Weight;
			Children[1].Weight = 0f;
		}
		else if(DirAngle < 0.5f*PI) // Forward and right
		{
			Children[2].Weight = 0f;
			Children[3].Weight = DirAngle/(0.5f*PI);

			Children[0].Weight = 1f - Children[3].Weight;
			Children[1].Weight = 0f;
		}
		else // Back and right
		{
			Children[2].Weight = 0f;
			Children[3].Weight = (-DirAngle/(0.5f*PI)) + 2f;

			Children[0].Weight = 0f;
			Children[1].Weight = 1f - Children[3].Weight;
		}
	}
	else
	{
		Children[0].Weight = 0f;
		Children[1].Weight = 0f;
		Children[2].Weight = 0f;
		Children[3].Weight = 0f;

		if(DirAngle < -0.75f*PI) // Back
		{
			Children[1].Weight = 1f;
		}
		else if(DirAngle < -0.25f*PI) // Left
		{
			Children[2].Weight = 1f;
		}
		else if(DirAngle < 0.25f*PI) // Forward
		{
			Children[0].Weight = 1f;
		}
		else if(DirAngle < 0.75f*PI) // Right
		{
			Children[3].Weight = 1f;
		}
		else // Back
		{
			Children[1].Weight = 1f;
		}
	}

	base.TickAnim(DeltaSeconds, TotalWeight);
}
}

public partial class AnimNodeBlendList
{
/// <summary>
/// Will ensure TargetWeight array is right size. If it has to resize it, will set Chidlren(0) to have a target of 1.0.
/// Also, if all Children weights are zero, will set Children[0] as the active child.
/// 
/// see AnimNode.InitAnim
/// </summary>
public override void InitAnim( SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent )
{
	base.InitAnim(meshComp, Parent);

	if( TargetWeight.Num() != Children.Num() )
	{
		TargetWeight.Reset();
		TargetWeight.AddZeroed( Children.Num() );

		if( TargetWeight.Num() > 0 )
		{
			TargetWeight[0] = 1f;
		}
	}

	// If all child weights are zero - set the first one to the active child.
	 float ChildWeightSum = GetChildWeightTotal();
	if( ChildWeightSum <= ZERO_ANIMWEIGHT_THRESH )
	{
		SetActiveChild(ActiveChildIndex, 0f);
	}
}

/// <summary>
/// see AnimNode.TickAnim 
///</summary>
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	check(Children.Num() == TargetWeight.Num());

	// Do nothing if BlendTimeToGo is zero.
	if( BlendTimeToGo > 0f )
	{
		// So we don't overshoot.
		if( BlendTimeToGo <= DeltaSeconds )
		{
			BlendTimeToGo = 0f; 

			for(int i=0; i<Children.Num(); i++)
			{
				Children[i].Weight = TargetWeight[i];
			}
		}
		else
		{
			for(int i=0; i<Children.Num(); i++)
			{
				// Amount left to blend.
				 float BlendDelta = TargetWeight[i] - Children[i].Weight;
				Children[i].Weight += (BlendDelta / BlendTimeToGo) * DeltaSeconds;
			}

			BlendTimeToGo -= DeltaSeconds;
		}
	}

	base.TickAnim(DeltaSeconds, TotalWeight);
}

/// <summary>
/// The the child to blend up to full Weight (1.0)
/// 
/// @param ChildIndex Index of child node to ramp in. If outside range of children, will set child 0 to active.
/// @param BlendTime How long for child to take to reach weight of 1.0.
/// </summary>
public virtual void SetActiveChild( int ChildIndex, float BlendTime )
{
	check(Children.Num() == TargetWeight.Num());
	
	if( ChildIndex < 0 || ChildIndex >= Children.Num() )
	{
		debugf( TEXT("AnimNodeBlendList.SetActiveChild : %s ChildIndex (%d) outside number of Children (%d)."), Name, ChildIndex, Children.Num() );
		ChildIndex = 0;
	}

	for(int i=0; i<Children.Num(); i++)
	{
		if(i == ChildIndex)
		{
			TargetWeight[i] = 1.0f;

			// If we basically want this straight away - dont wait until a tick to update weights.
			if(BlendTime == 0.0f)
			{
				Children[i].Weight = 1.0f;
			}
		}
		else
		{
			TargetWeight[i] = 0.0f;

			if(BlendTime == 0.0f)
			{
				Children[i].Weight = 0.0f;
			}
		}
	}

	BlendTimeToGo = BlendTime;
	ActiveChildIndex = ChildIndex;

	if( bPlayActiveChild )
	{
		// Play the animation if this child is a sequence
		AnimNodeSequence AnimSeq = (Children[ActiveChildIndex].Anim as AnimNodeSequence);
		if( AnimSeq )
		{
			AnimSeq.PlayAnim( AnimSeq.bLooping, AnimSeq.Rate );
		}
	}
}
/// <summary>
/// Called when we add a child to this node. We reset the TargetWeight array when this happens. 
/// </summary>
public override void OnAddChild(int ChildNum)
{
	base.OnAddChild(ChildNum);

	ResetTargetWeightArray( ref TargetWeight, Children.Num() );
}

/// <summary>
/// Called when we remove a child to this node. We reset the TargetWeight array when this happens. 
/// </summary>
public override void OnRemoveChild(int ChildNum)
{
	base.OnRemoveChild(ChildNum);

	ResetTargetWeightArray( ref TargetWeight, Children.Num() );
}
}

public partial class AnimNodeBlendByPosture
{
/// <summary>
/// Blend animations based on an Owner's posture.
/// 
/// @param DeltaSeconds	Time since last tick in seconds.
/// </summary>
public override void TickAnim( float DeltaSeconds, float TotalWeight )
{
	Pawn Owner = SkelComponent ? (SkelComponent.Owner as Pawn) : null;

	if ( Owner )
	{
		if ( Owner.bIsCrouched )
		{
			if ( ActiveChildIndex != 1 )
			{
				SetActiveChild( 1, 0.1f );
			}
		}
		else if ( ActiveChildIndex != 0 )
		{
			SetActiveChild( 0 , 0.1f );
		}
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}
}


public partial class AnimNodeBlendBySpeed
{

/// <summary>
/// Resets the last channel on becoming active.	
/// </summary>
public override void OnBecomeRelevant()
{
	base.OnBecomeRelevant();
	LastChannel = -1;
}

/// <summary>
/// Blend animations based on an Owner's velocity.
/// 
/// @param DeltaSeconds	Time since last tick in seconds.
/// </summary>
public override void TickAnim( float DeltaSeconds, float TotalWeight )
{
	int		NumChannels				= Children.Num();
	bool	SufficientChannels		= NumChannels >= 2,
			SufficientConstraints	= Constraints.Num() >= NumChannels;

	if( SufficientChannels && SufficientConstraints )
	{
		int		TargetChannel	= 0;

		// Get the speed we should use for the blend.
		Speed = CalcSpeed();

		// Find appropriate channel for current speed with "Constraints" containing an upper speed bound.
		while( (TargetChannel < NumChannels-1) && (Speed > Constraints[TargetChannel]) )
		{
			TargetChannel++;
		}

		// See if we need to blend down.
		if( TargetChannel > 0 )
		{
			float SpeedRatio = (Speed - Constraints[TargetChannel-1]) / (Constraints[TargetChannel] - Constraints[TargetChannel-1]);
			if( SpeedRatio <= BlendDownPerc )
			{
				TargetChannel--;
			}
		}

		if( TargetChannel != LastChannel )
		{
			if( TargetChannel < LastChannel )
			{
				SetActiveChild( TargetChannel, BlendDownTime );
			}
			else
			{
				SetActiveChild( TargetChannel, BlendUpTime );
			}
			LastChannel = TargetChannel;
		}
	}
	else if( !SufficientChannels )
	{
		debugf(TEXT("AnimNodeBlendBySpeed.TickAnim - Need at least two children"));
	}
	else if( !SufficientConstraints )
	{
		debugf(TEXT("AnimNodeBlendBySpeed.TickAnim - Number of constraints (%i) is lower than number of children! (%i)"), Constraints.Num(), NumChannels);
	}
	
	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);				
}

/// <summary>
/// 	Function called to calculate the speed that should be used for this node. 
/// 	Allows subclasses to easily modify the speed used.
/// </summary>
float CalcSpeed()
{
	Actor Owner = SkelComponent ? SkelComponent.Owner : null;
	if(Owner)
	{
		if( bUseAcceleration )
		{
			return Owner.Acceleration.Size();
		}
		else
		{
			return Owner.Velocity.Size();
		}
	}
	else
	{
		return Speed;
	}
}
}



public partial class AnimNodeMirror
{
public override void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	check(Children.Num() == 1);

	// If mirroring is enabled, and the mirror info array is initialized correctly.
	if( bEnableMirroring )
	{
		// EXCLUDE_CHILD_TIME
		GetMirroredBoneAtoms(ref Atoms, 0, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);

		// Save cached results if input is modified. Pass-through otherwise.
		SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
	}
	// If no mirroring is going on, just pass right through.
	else
	{
		// EXCLUDE_CHILD_TIME
		if( Children[0].Anim )
		{
			Children[0].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
		}
		else
		{
			RootMotionDelta = BoneAtom.Identity;
			bHasRootMotion	= false;
			FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		}
	}
}
}

public partial class AnimTree
{
public override void InitAnim(SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(meshComp, Parent);

	if( meshComp )
	{
		// update list of bone priorities
		meshComp.BuildComposePriorityList(ref PriorityList);
	}

	// Rebuild cached list of nodes belonging to each group
	RepopulateAnimGroups();
}

public override void PostEditChange(MEdge.Core.Property PropertyThatChanged)
{
	if( PropertyThatChanged != null && (PropertyThatChanged.GetFName() == (TEXT("PrioritizedSkelBranches"))) )
	{
		if( SkelComponent )
		{
			SkelComponent.BuildComposePriorityList(ref PriorityList);
		}
	}

	if( PropertyThatChanged != null && 
		(	PropertyThatChanged.GetFName() == (TEXT("PreviewSkelMesh")) ||
			PropertyThatChanged.GetFName() == (TEXT("PreviewAnimSets"))
		) )
	{
		if( SkelComponent )
		{
			// SkeletalMesh changed, force InitAnim() to be called on all nodes.
			SkelComponent.InitAnimTree();
		}
	}

	base.PostEditChange(PropertyThatChanged);
}

/// <summary>
/// Look up AnimNodeSequences and cache Group lists 
/// </summary>
public virtual void RepopulateAnimGroups()
{
	if( Children[0].Anim )
	{
		// get all AnimNodeSequence children and cache them to avoid over casting
		MEdge.array<AnimNodeSequence> Nodes = new array<AnimNodeSequence>();
		Children[0].Anim.GetAnimSeqNodes(ref Nodes);

		for( int GroupIdx=0; GroupIdx<AnimGroups.Num(); GroupIdx++ )
		{
			ref AnimGroup AnimGroup = ref AnimGroups[GroupIdx];

			// Clear cached nodes
			AnimGroup.SeqNodes.Empty();

			// Clear Master Nodes
			AnimGroup.SynchMaster	= null;
			AnimGroup.NotifyMaster	= null;

			// Caches nodes belonging to group
			if( AnimGroup.GroupName != NAME_None )
			{
				for( int i=0; i<Nodes.Num(); i++ )
				{
					AnimNodeSequence SeqNode = Nodes[i];
					if( SeqNode.SynchGroupName == AnimGroup.GroupName )	// need to be from the same group name
					{
						AnimGroup.SeqNodes.AddItem(SeqNode);
					}
				}

				// pdate Master Nodes
				UpdateMasterNodesForGroup(ref AnimGroup);
			}
		}
	}
}

/// <summary>
/// tility function, to check if a node is relevant for synchronization group. 
/// </summary>
static bool IsAnimNodeRelevantForSynchGroup(AnimNodeSequence SeqNode)
{
	return SeqNode && SeqNode.AnimSeq && SeqNode.bSynchronize;
}

/// <summary>
/// tility function to check if a node is relevant for notification group. 
/// </summary>
static bool IsAnimNodeRelevantForNotifyGroup(AnimNodeSequence SeqNode)
{
	return SeqNode && SeqNode.AnimSeq && !SeqNode.bNoNotifies;
}

/// <summary>
/// pdates the Master Nodes of a given group.
/// Makes sure Synchronization and Notification masters are still relevant, and the highest weight of the group.
/// </summary>
public virtual void UpdateMasterNodesForGroup(ref AnimGroup AnimGroup)
{
	// If we have a SynchMaster and it is not relevant anymore, clear it.
	if( AnimGroup.SynchMaster && (!AnimGroup.SynchMaster.bRelevant || !AnimGroup.SynchMaster.bForceAlwaysSlave || !IsAnimNodeRelevantForSynchGroup(AnimGroup.SynchMaster)) )
	{
		AnimGroup.SynchMaster = null;
	}

	// Again, make sure our notification master is still relevant. Otherwise, clear it.
	if( AnimGroup.NotifyMaster && (!AnimGroup.NotifyMaster.bRelevant || !IsAnimNodeRelevantForNotifyGroup(AnimGroup.NotifyMaster)) )
	{
		AnimGroup.NotifyMaster = null;
	}
	

	// If master nodes have full weight, then don't bother looking for new ones.
	if( (!AnimGroup.SynchMaster || (AnimGroup.SynchMaster.NodeTotalWeight < (1f - ZERO_ANIMWEIGHT_THRESH))) ||
		(!AnimGroup.NotifyMaster || (AnimGroup.NotifyMaster.NodeTotalWeight < (1f - ZERO_ANIMWEIGHT_THRESH))) || 
		!AnimGroup.SynchMaster.bForceAlwaysMaster )
	{
		// Find the node which has the highest weight... that's our master node
		float				SynchWeight		= AnimGroup.SynchMaster ? AnimGroup.SynchMaster.NodeTotalWeight : 0f;
		float				NotifyWeight	= AnimGroup.NotifyMaster ? AnimGroup.NotifyMaster.NodeTotalWeight : 0f;

		// Node with bForceAlwaysMaster set with highest weight
		AnimNodeSequence	ForcedMasterNode = null;
		// Weight of ForcedMasterNode.
		float				HighestForcedMasterWeight = 0f;

		for(int i=0; i<AnimGroup.SeqNodes.Num(); i++)
		{
			AnimNodeSequence Candidate = AnimGroup.SeqNodes[i];
			if( Candidate && Candidate.bRelevant )
			{
				// First, if bForceAlwaysMaster is set and non-zero weight, see if its the strongest 'forced master' so far.
				if( IsAnimNodeRelevantForSynchGroup(Candidate) && Candidate.bForceAlwaysMaster && Candidate.NodeTotalWeight > HighestForcedMasterWeight )
				{
					ForcedMasterNode			= Candidate;
					HighestForcedMasterWeight	= Candidate.NodeTotalWeight;
				}

				// See if this node is a candidate for synchronization master
				if( IsAnimNodeRelevantForSynchGroup(Candidate) && !Candidate.bForceAlwaysSlave && Candidate.NodeTotalWeight > SynchWeight )
				{
					AnimGroup.SynchMaster	= Candidate;
					SynchWeight				= Candidate.NodeTotalWeight;
				}

				// See if this node is a candidate for notification master
				if( IsAnimNodeRelevantForNotifyGroup(Candidate) && Candidate.NodeTotalWeight > NotifyWeight )
				{
					AnimGroup.NotifyMaster	= Candidate;
					NotifyWeight			= Candidate.NodeTotalWeight;
				}
			}
		}

		// If we found at least one relevant node marked bForceAlwaysMaster, use that
		if(ForcedMasterNode)
		{
			AnimGroup.SynchMaster = ForcedMasterNode;
		}
	}
}

/// <summary>
/// The main synchronization code... 
/// </summary>
public virtual void UpdateAnimNodeSeqGroups(float DeltaSeconds)
{
	// Force continuous update if within the editor (because we can add or remove nodes)
	// This can be improved by only doing that when a node has been added a removed from the tree.
	/*if( GIsEditor && !GIsGame )
	{
		RepopulateAnimGroups();
	}*/

	// Go through all groups, and update all nodes.
	for(int GroupIdx=0; GroupIdx<AnimGroups.Num(); GroupIdx++)
	{
		ref AnimGroup AnimGroup = ref AnimGroups[GroupIdx];

		// pdate Master Nodes
		UpdateMasterNodesForGroup(ref AnimGroup);

		// Calculate GroupDelta here, as this is common to all nodes in this group.
		 float GroupDelta = AnimGroup.RateScale * SkelComponent.GlobalAnimRateScale * DeltaSeconds;

		// If we don't have a valid synchronization master for this group, update all nodes without synchronization.
		if( !IsAnimNodeRelevantForSynchGroup(AnimGroup.SynchMaster) || !AnimGroup.SynchMaster.bRelevant )
		{
			for(int i=0; i<AnimGroup.SeqNodes.Num(); i++)
			{
				AnimNodeSequence SeqNode = AnimGroup.SeqNodes[i];
				if( SeqNode )
				{
					// Keep track of PreviousTime before any update. This is used by Root Motion.
					SeqNode.PreviousTime = SeqNode.CurrentTime;
					if( SeqNode.AnimSeq && SeqNode.bPlaying )
					{
						 float MoveDelta		= GroupDelta * SeqNode.Rate * SeqNode.AnimSeq.RateScale;
						// Fire notifies if node is notification master
						 bool	bFireNotifies	= (SeqNode == AnimGroup.NotifyMaster);

						// Advance animation.
						SeqNode.AdvanceBy(MoveDelta, DeltaSeconds, bFireNotifies);
					}
				}
			}
		}
		// Now that we have the master node, have it update all the others
		else 
		{
			AnimNodeSequence SynchMaster	= AnimGroup.SynchMaster;
			 float MasterMoveDelta		= GroupDelta * SynchMaster.Rate * SynchMaster.AnimSeq.RateScale;

			// Keep track of PreviousTime before any update. This is used by Root Motion.
			SynchMaster.PreviousTime = SynchMaster.CurrentTime;

			if( SynchMaster.bPlaying )
			{
				// Fire notifies if node is notification master
				 bool	bFireNotifies = (SynchMaster == AnimGroup.NotifyMaster);

				// Advance Synch Master Node
				SynchMaster.AdvanceBy(MasterMoveDelta, DeltaSeconds, bFireNotifies);
			}

			// SynchMaster node was changed during the tick?
			// Skip this round of updates...
			if( AnimGroup.SynchMaster != SynchMaster )
			{
				continue;
			}

			// Find it's relative position on its time line.
			 float MasterRelativePosition = GetNodeRelativePosition(SynchMaster);

			// pdate slaves to match relative position of master node.
			for(int i=0; i<AnimGroup.SeqNodes.Num(); i++)
			{
				AnimNodeSequence SeqNode = AnimGroup.SeqNodes[i];
				if( SeqNode && SeqNode != SynchMaster )
				{
					// Keep track of PreviousTime before any update. This is used by Root Motion.
					SeqNode.PreviousTime = SeqNode.CurrentTime;

					// If node should be synchronized
					if( IsAnimNodeRelevantForSynchGroup(SeqNode) && SeqNode.AnimSeq.SequenceLength > 0f )
					{
						// Slave's new time
						 float NewTime		= FindNodePositionFromRelative(SeqNode, MasterRelativePosition);
						float SlaveMoveDelta	= appFmod(NewTime - SeqNode.CurrentTime, SeqNode.AnimSeq.SequenceLength);

						// Make sure SlaveMoveDelta And MasterMoveDelta are the same sign, so they both move in the same direction.
						if( SlaveMoveDelta * MasterMoveDelta < 0f )
						{
							if( SlaveMoveDelta >= 0f )
							{
								SlaveMoveDelta -= SeqNode.AnimSeq.SequenceLength;
							}
							else
							{
								SlaveMoveDelta += SeqNode.AnimSeq.SequenceLength;
							}
						}

						// Fire notifies if node is master of notification group
						 bool	bFireNotifies = (SeqNode == AnimGroup.NotifyMaster);

						// Move slave node to correct position
						SeqNode.AdvanceBy(SlaveMoveDelta, DeltaSeconds, bFireNotifies);
					}
					// If node shouldn't be synchronized, update it normally
					else if( SeqNode.AnimSeq && SeqNode.bPlaying )
					{
						 float MoveDelta		= GroupDelta * SeqNode.Rate * SeqNode.AnimSeq.RateScale;
						// Fire notifies if node is notification master
						 bool	bFireNotifies	= (SeqNode == AnimGroup.NotifyMaster);

						// Advance animation.
						SeqNode.AdvanceBy(MoveDelta, DeltaSeconds, bFireNotifies);
					}
				}
			}
		}
	}
}

/// <summary>
/// Add a node to an existing group 
/// </summary>
bool SetAnimGroupForNode(ref AnimNodeSequence SeqNode, MEdge.Core.name GroupName, bool bCreateIfNotFound)
{
	if( !SeqNode )
	{	
		return false;
	}

	// If node is already in this group, then do nothing
	if( SeqNode.SynchGroupName == GroupName )
	{
		return true;
	}

	// If node is already part of a group, remove it from there first.
	if( SeqNode.SynchGroupName != NAME_None )
	{
		 int GroupIndex = GetGroupIndex(SeqNode.SynchGroupName);
		if( GroupIndex != INDEX_NONE )
		{
			ref AnimGroup AnimGroup	= ref AnimGroups[GroupIndex];
			SeqNode.SynchGroupName = NAME_None;
			AnimGroup.SeqNodes.RemoveItem(SeqNode);

			bool bUpdateMasterNodes = false;

			// If we're removing a Master Node, clear reference to it.
			if( AnimGroup.SynchMaster == SeqNode )
			{
				AnimGroup.SynchMaster	= null;
				bUpdateMasterNodes		= true;
			}
			// If we're removing a Master Node, clear reference to it.
			if( AnimGroup.NotifyMaster == SeqNode )
			{
				AnimGroup.NotifyMaster	= null;
				bUpdateMasterNodes		= true;
			}
			if( bUpdateMasterNodes )
			{
				UpdateMasterNodesForGroup(ref AnimGroup);
			}
		}
	}

	// See if we can move the node to the new group
	if( GroupName != NAME_None )
	{
		int GroupIndex = GetGroupIndex(GroupName);
		
		// If group wasn't found, maybe we should create it
		if( GroupIndex == INDEX_NONE && bCreateIfNotFound )
		{
			GroupIndex = AnimGroups.AddZeroed();
			AnimGroups[GroupIndex].RateScale = 1f;
			AnimGroups[GroupIndex].GroupName = GroupName;
		}

		if( GroupIndex != INDEX_NONE )
		{
			ref AnimGroup AnimGroup	= ref AnimGroups[GroupIndex];
			// Set group name
			SeqNode.SynchGroupName = GroupName;
			AnimGroup.SeqNodes.AddUniqueItem(SeqNode);

			// If node can be synchronized, then have it start at the current group position.
			// In case this node becomes the new SynchMaster, we don't want it to mess up the other nodes.
			if( IsAnimNodeRelevantForSynchGroup(SeqNode) )
			{
				SeqNode.SetPosition(FindNodePositionFromRelative(SeqNode, GetGroupRelativePosition(GroupName)), false);
			}
		}
	}

	// return true if change was successful
	return (SeqNode.SynchGroupName == GroupName);
}
/// <summary>
/// Force a group at a relative position. 
/// </summary>
public virtual void ForceGroupRelativePosition(MEdge.Core.name GroupName, float RelativePosition)
{
	for( int GroupIdx=0; GroupIdx<AnimGroups.Num(); GroupIdx++ )
	{
		 ref AnimGroup AnimGroup = ref AnimGroups[GroupIdx];
		if( AnimGroup.GroupName == GroupName )
		{
			for( int i=0; i<AnimGroup.SeqNodes.Num(); i++ )
			{
				ref AnimNodeSequence SeqNode = ref AnimGroup.SeqNodes[i];
				if( IsAnimNodeRelevantForSynchGroup(SeqNode) )
				{
					SeqNode.SetPosition(FindNodePositionFromRelative(SeqNode, RelativePosition), false);
				}
			}
			break;
		}
	}
}

/// <summary>
/// Get the relative position of a group. 
/// </summary>
float GetGroupRelativePosition(MEdge.Core.name GroupName)
{
	 int GroupIndex = GetGroupIndex(GroupName);
	if( GroupIndex != INDEX_NONE && AnimGroups[GroupIndex].SynchMaster )
	{
		return GetNodeRelativePosition(AnimGroups[GroupIndex].SynchMaster);
	}

	return 0f;
}

/// <summary>
/// Returns the master node driving synchronization for this group. 
/// </summary>
public AnimNodeSequence GetGroupSynchMaster(MEdge.Core.name GroupName)
{
	 int GroupIndex = GetGroupIndex(GroupName);
	if( GroupIndex != INDEX_NONE )
	{
		return AnimGroups[GroupIndex].SynchMaster;
	}

	return null;
}
/// <summary>
/// Returns the master node driving notifications for this group. 
/// </summary>
public AnimNodeSequence GetGroupNotifyMaster(MEdge.Core.name GroupName)
{
	 int GroupIndex = GetGroupIndex(GroupName);
	if( GroupIndex != INDEX_NONE )
	{
		return AnimGroups[GroupIndex].NotifyMaster;
	}

	return null;
}

/// <summary>
/// Adjust the Rate Scale of a group 
/// </summary>
public virtual void SetGroupRateScale(MEdge.Core.name GroupName, float NewRateScale)
{
	 int GroupIndex = GetGroupIndex(GroupName);
	if( GroupIndex != INDEX_NONE )
	{
		AnimGroups[GroupIndex].RateScale = NewRateScale;
	}
}

/// <summary>
/// Returns the index in the AnimGroups list of a given GroupName.
/// If group cannot be found, then INDEX_NONE will be returned.
/// </summary>
public int GetGroupIndex(MEdge.Core.name GroupName)
{
	if( GroupName != NAME_None )
	{
		for(int GroupIdx=0; GroupIdx<AnimGroups.Num(); GroupIdx++ )
		{
			if( AnimGroups[GroupIdx].GroupName == GroupName )
			{
				return GroupIdx;
			}
		}
	}

	return INDEX_NONE;
}

/// <summary>
/// Get all SkelControls within this AnimTree. 
/// </summary>
public virtual void GetSkelControls(ref MEdge.array<SkelControlBase> OutControls)
{
	OutControls.Empty();

	// Iterate over array of list-head structs.
	for(int i=0; i<SkelControlLists.Num(); i++)
	{
		// Then walk down each list, adding the SkelControl if its not already in the array.
		SkelControlBase Control = SkelControlLists[i].ControlHead;
		while(Control)
		{
			OutControls.AddUniqueItem(Control);
			Control = Control.NextControl;
		}
	}
}

/// <summary>
/// Get all MorphNodes within this AnimTree. 
/// </summary>
public virtual void GetMorphNodes(ref MEdge.array<MorphNodeBase> OutNodes)
{
	// Firest empty the array we will put nodes into.
	OutNodes.Empty();
	NativeMarkers.MarkUnimplemented("Not necessary");
	// Iterate over each node connected to the root.
	/*for(int i=0; i<RootMorphNodes.Num(); i++)
	{
		// If non-null, call GetNodes. This will add itself and any children.
		if( RootMorphNodes[i] )
		{
			RootMorphNodes[i].GetNodes(ref OutNodes);
		}
	}*/
}

/// <summary>
/// Calls GetActiveMorphs on each element of the RootMorphNodes array. 
/// </summary>
public virtual void GetTreeActiveMorphs(ref MEdge.array<SkeletalMeshComponent.ActiveMorph> OutMorphs)
{
	NativeMarkers.MarkUnimplemented("Not necessary");
	// Iterate over each node connected to the root.
	/*for(int i=0; i<RootMorphNodes.Num(); i++)
	{
		// If non-null, call GetNodes. This will add itself and any children.
		if( RootMorphNodes[i] )
		{
			RootMorphNodes[i].GetActiveMorphs(OutMorphs);
		}
	}*/
}

/// <summary>
/// Call InitMorph on all morph nodes attached to the tree. 
/// </summary>
public virtual void InitTreeMorphNodes(SkeletalMeshComponent InSkelComp)
{
	NativeMarkers.MarkUnimplemented("Not necessary");
	/*MEdge.array<MorphNodeBase>	AllNodes = new();
	GetMorphNodes(ref AllNodes);

	for(int i=0; i<AllNodes.Num(); i++)
	{
		if(AllNodes[i])
		{
			AllNodes[i].InitMorphNode(InSkelComp);
		}
	}*/
}

/// <summary>
/// tility for find a SkelControl in an AnimTree by name. 
/// </summary>
public SkelControlBase FindSkelControl(MEdge.Core.name InControlName)
{
	// Always return null if we did not pass in a name.
	if(InControlName == NAME_None)
	{
		return null;
	}

	// Iterate over array of list-head structs.
	for(int i=0; i<SkelControlLists.Num(); i++)
	{
		// Then walk down each list, adding the SkelControl if its not already in the array.
		SkelControlBase Control = SkelControlLists[i].ControlHead;
		while(Control)
		{
			if( Control.ControlName == InControlName )
			{
				return Control;
			}
			Control = Control.NextControl;
		}
	}

	return null;
}

/// <summary>
/// tility for find a MorphNode in an AnimTree by name. 
/// </summary>
public MorphNodeBase FindMorphNode(MEdge.Core.name InNodeName)
{
	// Always return null if we did not pass in a name.
	if(InNodeName == NAME_None)
	{
		return null;
	}

	MEdge.array<MorphNodeBase>	MorphNodes = new();
	GetMorphNodes(ref MorphNodes);

	for(int i=0; i<MorphNodes.Num(); i++)
	{
		if(MorphNodes[i].NodeName == InNodeName)
		{
			return MorphNodes[i];
		}
	}

	return null;
}
}


///////////////////////
// AnimNodeBlendMultiBone
//////////////////////////

/// <summary>
/// Calculates total weight of children. 
/// Set a full weight on source, because it's potentially always feeding animations into the final blend.
/// </summary>
public partial class AnimNodeBlendMultiBone
{
public override void SetChildrenTotalWeightAccumulator( int Index)
{
	if( Index == 0 )
	{
		// pdate the weight of this connection
		Children[Index].TotalWeight = NodeTotalWeight;
		// pdate the accumulator to find out the combined weight of the child node
		Children[Index].Anim.TotalWeightAccumulator += NodeTotalWeight;
	}
	else
	{
		// pdate the weight of this connection
		Children[Index].TotalWeight = NodeTotalWeight * Children[Index].Weight;
		// pdate the accumulator to find out the combined weight of the child node
		Children[Index].Anim.TotalWeightAccumulator += Children[Index].TotalWeight;
	}
}

/// <summary>
/// see AnimNode.InitAnim 
///</summary>
public override void InitAnim(SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(meshComp, Parent);
	for( int Idx = 0; Idx < BlendTargetList.Num(); Idx++ )
	{
		if( BlendTargetList[Idx].InitTargetStartBone != NAME_None )
		{
			SetTargetStartBone( Idx, BlendTargetList[Idx].InitTargetStartBone, BlendTargetList[Idx].InitPerBoneIncrease );
		}
	}
}

public override void PostEditChange(MEdge.Core.Property PropertyThatChanged)
{
	for( int Idx = 0; Idx < BlendTargetList.Num(); Idx++ )
	{
		if( PropertyThatChanged != null && 
			(PropertyThatChanged.GetFName() == TEXT("InitTargetStartBone") || 
			 PropertyThatChanged.GetFName() == TEXT("InitPerBoneIncrease")) )
		{
			SetTargetStartBone( Idx, BlendTargetList[Idx].InitTargetStartBone, BlendTargetList[Idx].InitPerBoneIncrease );
		}
	}

	base.PostEditChange(PropertyThatChanged);
}

/// <summary>
/// Utility for creating the Child2PerBoneWeight array. Walks down the heirarchy increasing the weight by PerBoneIncrease each step.
/// The per-bone weight is multiplied by the overall blend weight to calculate how much animation data to pull from each child.
/// 
/// @param StartBoneName Start blending in animation from Children[1] (ie second child) from this bone down.
/// @param PerBoneIncrease Amount to increase bone weight by for each bone down heirarchy.
/// </summary>
public virtual void SetTargetStartBone( int TargetIdx, MEdge.Core.name StartBoneName, float? _PerBoneIncrease = null )
{
	float PerBoneIncrease = _PerBoneIncrease ?? 1f;
	ref ChildBoneBlendInfo Info = ref BlendTargetList[TargetIdx];

	if( !SkelComponent || 
		(Info.OldStartBone	  == StartBoneName && 
		 Info.OldBoneIncrease == PerBoneIncrease &&
		 Info.TargetRequiredBones.Num() > 0 &&
		 SourceRequiredBones.Num() > 0) )
	{
		return;
	}

	Info.OldBoneIncrease		= PerBoneIncrease;
	Info.InitPerBoneIncrease	= PerBoneIncrease;
	Info.OldStartBone			= StartBoneName;
	Info.InitTargetStartBone	= StartBoneName;

	if( StartBoneName == NAME_None )
	{
		Info.TargetPerBoneWeight.Empty();
	}
	else
	{
		int StartBoneIndex = SkelComponent.MatchRefBone( StartBoneName );
		if( StartBoneIndex == INDEX_NONE )
		{
			debugf( TEXT("AnimNodeBlendPerBone.SetTargetStartBone : StartBoneName (%s) not found."), StartBoneName.ToString() );
			return;
		}

		ref MEdge.array<FMeshBone> RefSkel = ref SkelComponent.SkeletalMesh.RefSkeleton;
		Info.TargetRequiredBones.Empty();
		Info.TargetPerBoneWeight.Empty();
		Info.TargetPerBoneWeight.AddZeroed( RefSkel.Num() );
		SourceRequiredBones.Empty();

		check(PerBoneIncrease >= 0.0f && PerBoneIncrease <= 1.0f); // rather aggressive...

		// Allocate bone weights by walking heirarchy, increasing bone weight for bones below the start bone.
		Info.TargetPerBoneWeight[StartBoneIndex] = PerBoneIncrease;
		for( int i = 0; i < Info.TargetPerBoneWeight.Num(); i++ )
		{
			if( i != StartBoneIndex )
			{
				float ParentWeight = Info.TargetPerBoneWeight[ RefSkel[i].ParentIndex ];
				float BoneWeight   = (ParentWeight == 0.0f) ? 0.0f : Min( ParentWeight + PerBoneIncrease, 1.0f );

				Info.TargetPerBoneWeight[i] = BoneWeight;
			}

			if( Info.TargetPerBoneWeight[i] > ZERO_ANIMWEIGHT_THRESH )
			{
				Info.TargetRequiredBones.AddItem((byte)i);
			}
			else if( Info.TargetPerBoneWeight[i] <=(1f - ZERO_ANIMWEIGHT_THRESH) )
			{
				SourceRequiredBones.AddItem((byte)i);
			}
		}
	}
}
//public virtual void /*exec*/SetTargetStartBone( ref FFrame Stack, RESULT_DECL )
//{
//	P_GET_INT(TargetIdx);
//	P_GET_NAME(StartBoneName);
//	P_GET_FLOAT_OPTX(PerBoneIncrease, 1.0f);
//	P_FINISH;
//	
//	SetTargetStartBone( TargetIdx, StartBoneName, PerBoneIncrease );
//}
/// <summary>
/// see AnimNode.GetBoneAtoms. 
/// </summary>
public override void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	// Handle case of a blend with no children.
	if( Children.Num() == 0 )
	{
		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	= false;
		FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		return;
	}

	int NumAtoms = SkelComponent.SkeletalMesh.RefSkeleton.Num();
	check( NumAtoms == Atoms.Num() );

	// Find index of the last child with a non-zero weight.
	int LastChildIndex = INDEX_NONE;
	for(int i=0; i<Children.Num(); i++)
	{
		if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
		{
			LastChildIndex = i;
		}
	}
	check(LastChildIndex != INDEX_NONE);

	// We don't allocate this array until we need it.
	MEdge.array<BoneAtom> ChildAtoms = new();
	if( LastChildIndex == 0 )
	{
		if( Children[0].Anim )
		{
			// EXCLUDE_CHILD_TIME
			Children[0].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
		}
		else
		{
			RootMotionDelta = BoneAtom.Identity;
			bHasRootMotion	= false;
			FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
		}

		// We're acting as a pass-through, no need to cache results.
		return;
	}

	for( int j = 0; j < DesiredBones.Num(); j++ )
	{
		float AccWeight			= 0f;
		bool bNoChildrenYet	= true;
		
		// Iterate over each child getting its atoms, scaling them and adding them to output (Atoms array)
		for( int i = LastChildIndex; i >= 0; i-- )
		{
			if( Children[i].Weight > ZERO_ANIMWEIGHT_THRESH )
			{
				int		BoneIndex	= DesiredBones[j];
				float	BoneWeight;
				if( i > 0 )
				{
					BoneWeight	= Children[i].Weight * BlendTargetList[i].TargetPerBoneWeight[BoneIndex];
				}
				else
				{
					BoneWeight = 1f - AccWeight;
				}


				// Do need to request atoms, so allocate array here.
				if( ChildAtoms.Num() == 0 )
				{
					ChildAtoms.AddCount(NumAtoms);
				}

				// Get bone atoms from child node (if no child - use ref pose).
				if( Children[i].Anim )
				{
					// EXCLUDE_CHILD_TIME
					Children[i].Anim.GetBoneAtoms(ref ChildAtoms, ref DesiredBones, ref Children[i].RootMotion, ref Children[i].bHasRootMotion);

					bHasRootMotion = bHasRootMotion || Children[i].bHasRootMotion;

					if( bNoChildrenYet )
					{
						RootMotionDelta = Children[i].RootMotion * Children[i].Weight;
					}
					else
					{
						RootMotionDelta.AddAssign(Children[i].RootMotion * Children[i].Weight);
					}
				}
				else
				{
					FillWithRefPose(ref ChildAtoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
				}

				// To ensure the 'shortest route', we make sure the dot product between the accumulator and the incoming child atom is positive.
				if( (Atoms[BoneIndex].Rotation | ChildAtoms[BoneIndex].Rotation) < 0f )
				{
					ChildAtoms[BoneIndex].Rotation = ChildAtoms[BoneIndex].Rotation * -1f;
				}

				// We just write the first childrens atoms into the output array. Avoids zero-ing it out.
				if( bNoChildrenYet )
				{
					Atoms[BoneIndex] = ChildAtoms[BoneIndex] * BoneWeight;
				}
				else
				{
					Atoms[BoneIndex].AddAssign(ChildAtoms[BoneIndex] * BoneWeight);
				}

				// If last child - normalize the rotaion quaternion now.
				if( i == 0 )
				{
					Atoms[BoneIndex].Rotation.Normalize();
				}

				if( i > 0 )
				{
					AccWeight += BoneWeight;
				}
				
				bNoChildrenYet = false;
			}
		}
	}

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}
}



/// <summary>
/// sed to save pointer to AimOffset node in package, to avoid duplicating profile data. 
/// </summary>
public partial class AnimNodeAimOffset
{
	public virtual Vector2D	GetAim() { return Aim; }
	
public virtual void PostAnimNodeInstance(ref AnimNode SourceNode)
{
	TemplateNode = (AnimNodeAimOffset)(SourceNode);

	// We are going to use data from the TemplateNode, rather than keeping a copy for each instance of the node.
	Profiles.Empty();
}

public override void PostEditChange(MEdge.Core.Property PropertyThatChanged)
{
	base.PostEditChange(PropertyThatChanged);

	if( PropertyThatChanged.GetFName() == (TEXT("bBakeFromAnimations")) )
	{
		bBakeFromAnimations = false;
		BakeOffsetsFromAnimations();
	}
}

public override void InitAnim(SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(meshComp, Parent);

	// Update list of required bones
	// this is the list of bones needed for transformation and their parents.
	UpdateListOfRequiredBones();
}

public virtual void UpdateListOfRequiredBones()
{
	// Empty required bones list
	RequiredBones.Reset();
	BoneToAimCpnt.Reset();

	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if( valid == false || !SkelComponent || !SkelComponent.SkeletalMesh )
	{
		return;
	}

	 ref MEdge.array<FMeshBone>	RefSkel		= ref SkelComponent.SkeletalMesh.RefSkeleton;
	 int					NumBones	= RefSkel.Num();

	// Size look up table
	BoneToAimCpnt.Add(NumBones);

	// Iterate through all bones in the skeleton and see if we have an AimComponent defined for these
	// We do this to update AimComponent bone indices
	// but also build the RequiredBones list in increasing order.
	for(int BoneIndex=0; BoneIndex<NumBones; BoneIndex++)
	{
		// See if we can find an AimComponent for this bone..
		int AimCompIndex = INDEX_NONE;
		for(int i=0; i<P.AimComponents.Num(); i++)
		{
			if( P.AimComponents[i].BoneName == RefSkel[BoneIndex].Name )
			{
				AimCompIndex = i;
				break;
			}
		}

		// pdate look up table to find AimComponent Index from BoneIndex.
		// AimComponents are based on Bone names, because similar skeletons can be exported in
		// different bone orders, so it's not safe to refer by Index. Only Bones Names.
		// So the look up table needs to be updated when node is instanced.
		BoneToAimCpnt[BoneIndex] = AimCompIndex;

		// Build RequiredBones array in increasing order
		if( AimCompIndex != INDEX_NONE )
		{
			RequiredBones.AddItem((byte)BoneIndex);
		}
	}

	// Make sure parents are present in the array. Since we need to get the relevant bones in component space.
	// And that require the parent bones...
	EnsureParentsPresent(ref RequiredBones, ref SkelComponent.SkeletalMesh);
}

static float UnWindNormalizedAimAngle(float Angle)
{
	while( Angle > 2f )
	{
		Angle -= 4f;
	}

	while( Angle < -2f )
	{
		Angle += 4f;
	}

	return Angle;
}



static AimOffsetProfile dummyProfile;
ref AimOffsetProfile GetCurrentProfile(out bool valid)
{
	// Check profile index is not outside range.
	if(TemplateNode)
	{
		if(CurrentProfileIndex < TemplateNode.Profiles.Num())
		{
			valid = true;
			return ref TemplateNode.Profiles[CurrentProfileIndex];
		}
	}
	else
	{
		if(CurrentProfileIndex < Profiles.Num())
		{
			valid = true;
			return ref Profiles[CurrentProfileIndex];
		}
	}
	valid = false;
	return ref dummyProfile;
}

/// <summary>
/// Temporary working space used by AimOffset node. Grows to max size required by any node. 
/// </summary>
static MEdge.array<MEdge.Core.Object.Matrix> AimOffsetBoneTM;

public virtual void PostAimProcessing(ref Vector2D AimOffsetPct) {}

public override void GetBoneAtoms(ref MEdge.array<BoneAtom> Atoms,  ref MEdge.array<byte> DesiredBones, ref BoneAtom RootMotionDelta, ref bool bHasRootMotion)
{
	// START_GETBONEATOM_TIMER

	if( GetCachedResults(ref Atoms, ref RootMotionDelta, ref bHasRootMotion) )
	{
		return;
	}

	// Get local space atoms from child
	if( Children[0].Anim )
	{
		// EXCLUDE_CHILD_TIME
		Children[0].Anim.GetBoneAtoms(ref Atoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);
	}
	else
	{
		RootMotionDelta = BoneAtom.Identity;
		bHasRootMotion	= false;
		FillWithRefPose(ref Atoms, DesiredBones, SkelComponent.SkeletalMesh.RefSkeleton);
	}

	// Have the option of doing nothing if at a low LOD.
	if( !SkelComponent || RequiredBones.Num() == 0 || SkelComponent.PredictedLODLevel >= PassThroughAtOrAboveLOD )
	{
		return;
	}

	 SkeletalMesh	SkelMesh = SkelComponent.SkeletalMesh;
	 int				NumBones = SkelMesh.RefSkeleton.Num();

	// Make sure we have a valid setup
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if( BoneToAimCpnt.Num() != NumBones || valid == false )
	{
		return;
	}

	Vector2D SafeAim = this.Aim;
	
	// Add in rotation offset, but not in the editor
	if( !GIsEditor || GIsGame )
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
	if( P.HorizontalRange.X != 0f && SafeAim.X < 0f )
	{
		SafeAim.X = SafeAim.X / Abs(P.HorizontalRange.X);
	}
	if( P.HorizontalRange.Y != 0f && SafeAim.X > 0f )
	{
		SafeAim.X = SafeAim.X / P.HorizontalRange.Y;
	}
	if( P.VerticalRange.X != 0f && SafeAim.Y < 0f )
	{
		SafeAim.Y = SafeAim.Y / Abs(P.VerticalRange.X);
	}
	if( P.VerticalRange.Y != 0f && SafeAim.Y > 0f )
	{
		SafeAim.Y = SafeAim.Y / P.VerticalRange.Y;
	}

	// Make sure we're using correct values within legal range.
	SafeAim.X = Clamp(SafeAim.X, -1f, +1f);
	SafeAim.Y = Clamp(SafeAim.Y, -1f, +1f);

	// Post process final Aim.
	PostAimProcessing(ref SafeAim);

	// Bypass node if using center center position.
	if( (!bForceAimDir && SafeAim.IsNearlyZero()) || (bForceAimDir && ForcedAimDir == EAnimAimDir.ANIMAIM_CENTERCENTER) )
	{
		return;
	}

	// We build the mesh-space matrices of the source bones.
	if( AimOffsetBoneTM.Num() < NumBones )
	{
		AimOffsetBoneTM.Reset();
		AimOffsetBoneTM.AddCount(NumBones);
	}

	 int NumAimComp = P.AimComponents.Num();
	 int RequiredNum = RequiredBones.Num();
	 int DesiredNum = DesiredBones.Num();
	int DesiredPos = 0;
	int RequiredPos = 0;
	int BoneIndex = 0;
	while( DesiredPos < DesiredNum && RequiredPos < RequiredNum )
	{
		// Perform intersection of RequiredBones and DesiredBones array.
		// If they are the same, BoneIndex is relevant and we should process it.
		if( DesiredBones[DesiredPos] == RequiredBones[RequiredPos] )
		{
			BoneIndex = DesiredBones[DesiredPos];
			DesiredPos++;
			RequiredPos++;
		}
		// If value at DesiredPos is lower, increment DesiredPos.
		else if( DesiredBones[DesiredPos] < RequiredBones[RequiredPos] )
		{
			DesiredPos++;
			continue;
		}
		// If value at RequiredPos is lower, increment RequiredPos.
		else
		{
			RequiredPos++;
			continue;
		}

		// transform required bones into component space
		Atoms[BoneIndex].ToTransform(ref AimOffsetBoneTM[BoneIndex]);
		if( BoneIndex > 0 )
		{
			AimOffsetBoneTM[BoneIndex] *= AimOffsetBoneTM[SkelMesh.RefSkeleton[BoneIndex].ParentIndex];
		}

		// See if this bone should be transformed. ie there is an AimComponent defined for it
		 int AimCompIndex = BoneToAimCpnt[BoneIndex];
		if( AimCompIndex != INDEX_NONE )
		{
			Quat			QuaternionOffset = default;
			Vector			TranslationOffset = default;
			AimComponent	AimCpnt = P.AimComponents[AimCompIndex];

			// If bForceAimDir - just use whatever ForcedAimDir is set to - ignore Aim.
			if( bForceAimDir )
			{
				switch( ForcedAimDir )
				{
					case EAnimAimDir.ANIMAIM_LEFTUP			:	QuaternionOffset	= AimCpnt.LU.Quaternion; 
													TranslationOffset	= AimCpnt.LU.Translation;	
													break;
					case EAnimAimDir.ANIMAIM_CENTERUP		:	QuaternionOffset	= AimCpnt.CU.Quaternion; 
													TranslationOffset	= AimCpnt.CU.Translation;	
													break;
					case EAnimAimDir.ANIMAIM_RIGHTUP		:	QuaternionOffset	= AimCpnt.RU.Quaternion; 
													TranslationOffset	= AimCpnt.RU.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_LEFTCENTER		:	QuaternionOffset	= AimCpnt.LC.Quaternion; 
													TranslationOffset	= AimCpnt.LC.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_CENTERCENTER	:	QuaternionOffset	= AimCpnt.CC.Quaternion; 
													TranslationOffset	= AimCpnt.CC.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_RIGHTCENTER	:	QuaternionOffset	= AimCpnt.RC.Quaternion; 
													TranslationOffset	= AimCpnt.RC.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_LEFTDOWN		:	QuaternionOffset	= AimCpnt.LD.Quaternion; 
													TranslationOffset	= AimCpnt.LD.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_CENTERDOWN		:	QuaternionOffset	= AimCpnt.CD.Quaternion; 
													TranslationOffset	= AimCpnt.CD.Translation; 
													break;
					case EAnimAimDir.ANIMAIM_RIGHTDOWN		:	QuaternionOffset	= AimCpnt.RD.Quaternion; 
													TranslationOffset	= AimCpnt.RD.Translation; 
													break;
				}
			}
			else
			{
				if( SafeAim.X >= 0f && SafeAim.Y >= 0f ) // p Right
				{
					QuaternionOffset	= BiLerpQuat(AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, AimCpnt.CU.Quaternion, AimCpnt.RU.Quaternion, SafeAim.X, SafeAim.Y);
					TranslationOffset	= BiLerp(AimCpnt.CC.Translation, AimCpnt.RC.Translation, AimCpnt.CU.Translation, AimCpnt.RU.Translation, SafeAim.X, SafeAim.Y);
				}
				else if( SafeAim.X >= 0f && SafeAim.Y < 0f ) // Bottom Right
				{
					QuaternionOffset	= BiLerpQuat(AimCpnt.CD.Quaternion, AimCpnt.RD.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.RC.Quaternion, SafeAim.X, SafeAim.Y+1f);
					TranslationOffset	= BiLerp(AimCpnt.CD.Translation, AimCpnt.RD.Translation, AimCpnt.CC.Translation, AimCpnt.RC.Translation, SafeAim.X, SafeAim.Y+1f);
				}
				else if( SafeAim.X < 0f && SafeAim.Y >= 0f ) // p Left
				{
					QuaternionOffset	= BiLerpQuat(AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, AimCpnt.LU.Quaternion, AimCpnt.CU.Quaternion, SafeAim.X+1f, SafeAim.Y);
					TranslationOffset	= BiLerp(AimCpnt.LC.Translation, AimCpnt.CC.Translation, AimCpnt.LU.Translation, AimCpnt.CU.Translation, SafeAim.X+1f, SafeAim.Y);
				}
				else if( SafeAim.X < 0f && SafeAim.Y < 0f ) // Bottom Left
				{
					QuaternionOffset	= BiLerpQuat(AimCpnt.LD.Quaternion, AimCpnt.CD.Quaternion, AimCpnt.LC.Quaternion, AimCpnt.CC.Quaternion, SafeAim.X+1f, SafeAim.Y+1f);
					TranslationOffset	= BiLerp(AimCpnt.LD.Translation, AimCpnt.CD.Translation, AimCpnt.LC.Translation, AimCpnt.CC.Translation, SafeAim.X+1f, SafeAim.Y+1f);
				}

				// Normalize Resulting Quaternion
				QuaternionOffset.Normalize();
			}

			// only perform a transformation if it is significant
			// (Since it's something expensive to do)
			const float DELTA = 0.00001f;
			bool	bDoRotation	= Square(QuaternionOffset.W) < 1f - DELTA * DELTA;
			if( bDoRotation || !TranslationOffset.IsNearlyZero() )
			{
				// Find bone translation
				 Vector BoneOrigin = TranslationOffset + AimOffsetBoneTM[BoneIndex].GetOrigin();

				// Apply bone rotation
				if( bDoRotation )
				{
					AimOffsetBoneTM[BoneIndex] *= FQuatRotationTranslationMatrix(QuaternionOffset, new Vector(0f));
				}

				// Apply bone translation
				AimOffsetBoneTM[BoneIndex].SetOrigin(BoneOrigin);

				// Transform back to parent bone space
				MEdge.Core.Object.Matrix RelTM;
				if( BoneIndex == 0 )
				{
					RelTM = AimOffsetBoneTM[BoneIndex];
				}
				else
				{
					 int ParentIndex = SkelMesh.RefSkeleton[BoneIndex].ParentIndex;
					RelTM = AimOffsetBoneTM[BoneIndex] * AimOffsetBoneTM[ParentIndex].Inverse();
				}

				 BoneAtom	TransformedAtom = new BoneAtom(RelTM);
				Atoms[BoneIndex].Rotation		= TransformedAtom.Rotation;
				Atoms[BoneIndex].Translation	= TransformedAtom.Translation;
			}
		}
	}

	SaveCachedResults(ref Atoms, ref RootMotionDelta, bHasRootMotion);
}
static Quat BiLerpQuat(in Quat P00, in Quat P10, in Quat P01, in Quat P11, float FracX, float FracY)
{
	return LerpQuat( LerpQuat( P00, P10, FracX ), LerpQuat( P01, P11, FracX ), FracY );
}
static FQuat LerpQuat(in FQuat A, in FQuat B, FLOAT Alpha)
{
	// To ensure the 'shortest route', we make sure the dot product between the both rotations is positive.
	if( (A | B) < 0f )
	{
		return (B * Alpha) - (A * (1f - Alpha));
	}

	// Then add on the second rotation..
	return (B * Alpha) + (A * (1f - Alpha));
}
		
static Vector BiLerp(in Vector P00, in Vector P10, in Vector P01, in Vector P11, float FracX, float FracY)
{
	return VLerp( VLerp( P00, P10, FracX ), VLerp( P01, P11, FracX ), FracY );
}
float GetSliderPosition(int SliderIndex, int ValueIndex)
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
		Aim.Y = -1f * (NewSliderValue - 0.5f) * 2f;
	}
}

public string GetSliderDrawValue(int SliderIndex)
{
	check(SliderIndex == 0);
	return $"{Aim.X:F1},{Aim.Y:F1}";
}



static Quat DummyQuat;
/// <summary>
/// Util for finding the quaternion that corresponds to a particular direction. 
/// </summary>
static ref Quat GetAimQuatPtr(ref AimOffsetProfile P, int CompIndex, EAnimAimDir InAimDir, out bool valid)
{
	if( CompIndex < 0 || CompIndex >= P.AimComponents.Num() )
	{
		throw new Exception();
	}

	ref AimComponent	AimCpnt	= ref P.AimComponents[CompIndex];
	ref Quat			QuatPtr = ref (AimCpnt.LU.Quaternion);

	switch( InAimDir )
	{
		case EAnimAimDir.ANIMAIM_LEFTUP			: QuatPtr = ref (AimCpnt.LU.Quaternion); break;
		case EAnimAimDir.ANIMAIM_CENTERUP		: QuatPtr = ref (AimCpnt.CU.Quaternion); break;
		case EAnimAimDir.ANIMAIM_RIGHTUP		: QuatPtr = ref (AimCpnt.RU.Quaternion); break;

		case EAnimAimDir.ANIMAIM_LEFTCENTER		: QuatPtr = ref (AimCpnt.LC.Quaternion); break;
		case EAnimAimDir.ANIMAIM_CENTERCENTER	: QuatPtr = ref (AimCpnt.CC.Quaternion); break;
		case EAnimAimDir.ANIMAIM_RIGHTCENTER	: QuatPtr = ref (AimCpnt.RC.Quaternion); break;

		case EAnimAimDir.ANIMAIM_LEFTDOWN		: QuatPtr = ref (AimCpnt.LD.Quaternion); break;
		case EAnimAimDir.ANIMAIM_CENTERDOWN		: QuatPtr = ref (AimCpnt.CD.Quaternion); break;
		case EAnimAimDir.ANIMAIM_RIGHTDOWN		: QuatPtr = ref (AimCpnt.RD.Quaternion); break;
		default:
		{
			valid = false;
			return ref DummyQuat;
		}
	}

	valid = true;
	return ref QuatPtr;
}



static Vector dummyVector;

/// <summary>
/// Util for finding the translation that corresponds to a particular direction. 
/// </summary>
static ref Vector GetAimTransPtr(ref AimOffsetProfile P, int CompIndex, EAnimAimDir InAimDir, out bool valid)
{
	if( CompIndex < 0 || CompIndex >= P.AimComponents.Num() )
	{
		throw new Exception();
	}

	ref var	AimCpnt	= ref P.AimComponents[CompIndex];
	ref Vector			TransPtr	= ref (AimCpnt.LU.Translation);

	switch( InAimDir )
	{
		case EAnimAimDir.ANIMAIM_LEFTUP			: TransPtr = ref (AimCpnt.LU.Translation); break;
		case EAnimAimDir.ANIMAIM_CENTERUP		: TransPtr = ref (AimCpnt.CU.Translation); break;
		case EAnimAimDir.ANIMAIM_RIGHTUP		: TransPtr = ref (AimCpnt.RU.Translation); break;

		case EAnimAimDir.ANIMAIM_LEFTCENTER		: TransPtr = ref (AimCpnt.LC.Translation); break;
		case EAnimAimDir.ANIMAIM_CENTERCENTER	: TransPtr = ref (AimCpnt.CC.Translation); break;
		case EAnimAimDir.ANIMAIM_RIGHTCENTER	: TransPtr = ref (AimCpnt.RC.Translation); break;

		case EAnimAimDir.ANIMAIM_LEFTDOWN		: TransPtr = ref (AimCpnt.LD.Translation); break;
		case EAnimAimDir.ANIMAIM_CENTERDOWN		: TransPtr = ref (AimCpnt.CD.Translation); break;
		case EAnimAimDir.ANIMAIM_RIGHTDOWN		: TransPtr = ref (AimCpnt.RD.Translation); break;
		default:
		{
			valid = false;
			return ref dummyVector;
		}
	}

	valid = true;
	return ref TransPtr;
}

/// <summary>
/// Util for grabbing the quaternion on a specific bone in a specific direction. 
/// </summary>
protected Quat GetBoneAimQuaternion(int CompIndex, EAnimAimDir InAimDir)
{
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return Quat.Identity;
	}

	// Get the array for this pose.
	ref Quat QuatPtr = ref GetAimQuatPtr(ref P, CompIndex, InAimDir, out var valid2);

	// And return the Quaternion (if its in range).
	if( valid2 )
	{
		return QuatPtr;
	}
	else
	{
		return Quat.Identity;
	}
}
/// <summary>
/// Util for grabbing the translation on a specific bone in a specific direction. 
/// </summary>
Vector GetBoneAimTranslation(int CompIndex, EAnimAimDir InAimDir)
{
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return new(0,0,0);
	}

	// Get the translation for this pose.
	ref Vector TransPtr = ref GetAimTransPtr(ref P, CompIndex, InAimDir, out var valid2);

	// And return the Rotator (if its in range).
	if( valid2 )
	{
		return (TransPtr);
	}
	else
	{
		return new(0,0,0);
	}
}

/// <summary>
/// Util for setting the quaternion on a specific bone in a specific direction. 
/// </summary>
public virtual void SetBoneAimQuaternion(int CompIndex, EAnimAimDir InAimDir, Quat InQuat)
{
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return;
	}

	// Get the array for this pose.
	ref Quat QuatPtr = ref GetAimQuatPtr(ref P, CompIndex, InAimDir, out var valid2);

	// Set the Rotator (if BoneIndex is in range).
	if( valid2 )
	{
		QuatPtr = InQuat;
	}
}

/// <summary>
/// til for setting the translation on a specific bone in a specific direction. 
/// </summary>
public virtual void SetBoneAimTranslation(int CompIndex, EAnimAimDir InAimDir, Vector InTrans)
{
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return;
	}

	// Get the array for this pose.
	ref Vector TransPtr = ref GetAimTransPtr(ref P, CompIndex, InAimDir, out var valid2);

	// Set the Rotator (if BoneIndex is in range).
	if( valid2 )
	{
		TransPtr = InTrans;
	}
}

/// <summary>
/// Returns true if AimComponents contains specified bone 
/// </summary>
bool ContainsBone( ref MEdge.Core.name BoneName)
{
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return false;
	}

	for( int i=0; i<P.AimComponents.Num(); i++ )
	{
		if( P.AimComponents[i].BoneName == BoneName )
		{
			return true;
		}
	}
	return false;
}



/// <summary>
/// Bake in Offsets from supplied Animations. 
/// </summary>
public virtual void BakeOffsetsFromAnimations()
{
	throw new Exception();
	/*if( !SkelComponent || !SkelComponent.SkeletalMesh )
	{
		appMsgf(AMT_OK, TEXT(" No SkeletalMesh to import animations from. Aborting."));
		return;
	}

	// Check profile index is not outside range.
	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if(valid == false)
	{
		return;
	}

	// Clear current setup
	P.AimComponents.Empty();
	BoneToAimCpnt.Empty();

	// AnimNodeSequence used to extract animation data.
	AnimNodeSequence	SeqNode = ConstructObject<AnimNodeSequence>(AnimNodeSequence.StaticClass());
	SeqNode.SkelComponent = SkelComponent;

	// Extract Center/Center (reference pose)
	MEdge.array<BoneAtom>	BoneAtoms_CC;
	if( ExtractAnimationData(SeqNode, P.AnimName_CC, BoneAtoms_CC) == false )
	{
		appMsgf(AMT_OK, TEXT(" Couldn't get CenterCenter pose, this is necessary. Aborting."));
		return;;
	}

	MEdge.array<BoneAtom>	BoneAtoms;

	// Extract Left/Up
	if( ExtractAnimationData(SeqNode, P.AnimName_LU, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_LU.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_LEFTUP);
	}

	// Extract Left/Center
	if( ExtractAnimationData(SeqNode, P.AnimName_LC, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_LC.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_LEFTCENTER);
	}

	// Extract Left/Down
	if( ExtractAnimationData(SeqNode, P.AnimName_LD, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_LD.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_LEFTDOWN);
	}

	// Extract Center/Up
	if( ExtractAnimationData(SeqNode, P.AnimName_CU, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_CU.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_CENTERUP);
	}

	// Extract Center/Down
	if( ExtractAnimationData(SeqNode, P.AnimName_CD, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_CD.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_CENTERDOWN);
	}

	// Extract Right/Up
	if( ExtractAnimationData(SeqNode, P.AnimName_RU, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_RU.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_RIGHTUP);
	}

	// Extract Right/Center
	if( ExtractAnimationData(SeqNode, P.AnimName_RC, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_RC.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_RIGHTCENTER);
	}

	// Extract Right/Down
	if( ExtractAnimationData(SeqNode, P.AnimName_RD, BoneAtoms) == true )
	{
		debugf(TEXT(" Converting Animation: %s"), *P.AnimName_RD.ToString());
		ExtractOffsets(BoneAtoms_CC, BoneAtoms, ANIMAIM_RIGHTDOWN);
	}

	// Done, cache required bones
	UpdateListOfRequiredBones();

	// Clean up.
	SeqNode.SkelComponent	= null;
	SeqNode					= null;

	appMsgf(AMT_OK, TEXT(" Export finished, check log for details."));*/
}
public virtual void ExtractOffsets(ref MEdge.array<BoneAtom> RefBoneAtoms, ref MEdge.array<BoneAtom> BoneAtoms, EAnimAimDir InAimDir)
{
	MEdge.array<MEdge.Core.Object.Matrix>	TargetTM = new();
	TargetTM.AddCount(BoneAtoms.Num());

	for(int i=0; i<BoneAtoms.Num(); i++)
	{
		// Transform target pose into mesh space
		BoneAtoms[i].ToTransform(ref TargetTM[i]);
		if( i > 0 )
		{
			TargetTM[i] *= TargetTM[SkelComponent.SkeletalMesh.RefSkeleton[i].ParentIndex];
		}

		// Now get Source transform on this bone
		// But from Target parent bone in mesh space.
		MEdge.Core.Object.Matrix SourceTM = default;
		RefBoneAtoms[i].ToTransform(ref SourceTM);
		if( i > 0 )
		{
			// Transform Target Skeleton by reference transform for this bone
			SourceTM *= TargetTM[SkelComponent.SkeletalMesh.RefSkeleton[i].ParentIndex];
		}

		MEdge.Core.Object.Matrix TargetTranslationM = MEdge.Core.Object.Matrix.Identity;
		TargetTranslationM.SetOrigin( TargetTM[i].GetOrigin() );

		MEdge.Core.Object.Matrix SourceTranslationM = MEdge.Core.Object.Matrix.Identity;
		SourceTranslationM.SetOrigin( SourceTM.GetOrigin() );
		
		 MEdge.Core.Object.Matrix	TranslationTM		= SourceTranslationM.Inverse() * TargetTranslationM;
		 Vector	TranslationOffset	= TranslationTM.GetOrigin();

		if( !TranslationOffset.IsNearlyZero() )
		{
			 int CompIdx = GetComponentIdxFromBoneIdx(i, true);

			if( CompIdx != INDEX_NONE )
			{
				SetBoneAimTranslation(CompIdx, InAimDir, TranslationOffset);
			}
		}

		MEdge.Core.Object.Matrix TargetRotationM = TargetTM[i];
		TargetRotationM.RemoveScaling();
		TargetRotationM.SetOrigin(new Vector(0f));

		MEdge.Core.Object.Matrix SourceRotationM = SourceTM;
		SourceRotationM.RemoveScaling();
		SourceRotationM.SetOrigin(new Vector(0f));

		// Convert delta rotation to FRotator.
		 MEdge.Core.Object.Matrix	RotationTM		= SourceRotationM.Inverse() * TargetRotationM;
		 FRotator	RotationOffset	= RotationTM.Rotator();
		 Quat		QuaterionOffset = new Quat(RotationTM); 

		if( !RotationOffset.IsZero() )
		{
			 int CompIdx = GetComponentIdxFromBoneIdx(i, true);

			if( CompIdx != INDEX_NONE )
			{
				SetBoneAimQuaternion(CompIdx, InAimDir, QuaterionOffset);
			}
		}

	}
}

int GetComponentIdxFromBoneIdx( int BoneIndex, bool bCreateIfNotFound)
{
	if( BoneIndex == INDEX_NONE )
	{
		return INDEX_NONE;
	}

	ref AimOffsetProfile P = ref GetCurrentProfile(out var valid);
	if( valid == false )
	{
		return INDEX_NONE;
	}

	// If AimComponent exists, return it's index from the look up table
	if( BoneIndex < BoneToAimCpnt.Num() && BoneToAimCpnt[BoneIndex] != INDEX_NONE )
	{ 
		return BoneToAimCpnt[BoneIndex];
	}

	if( bCreateIfNotFound )
	{
		 MEdge.Core.name	BoneName = SkelComponent.SkeletalMesh.RefSkeleton[BoneIndex].Name;

		// If its a valid bone we want to add..
		if( BoneName != NAME_None && BoneIndex != INDEX_NONE )
		{
			int InsertPos = INDEX_NONE;

			// Iterate through current array, to find place to insert this new Bone so they stay in Bone index order.
			for(int i=0; i<P.AimComponents.Num() && InsertPos == INDEX_NONE; i++)
			{
				 MEdge.Core.name	TestName	= P.AimComponents[i].BoneName;
				 int	TestIndex	= SkelComponent.MatchRefBone(TestName);

				if( TestIndex != INDEX_NONE && TestIndex > BoneIndex )
				{
					InsertPos = i;
				}
			}

			// If we didn't find insert position - insert at end.
			// This also handles case of and empty BoneNames array.
			if( InsertPos == INDEX_NONE )
			{
				InsertPos = P.AimComponents.Num();
			}

			// Add a new component.
			P.AimComponents.InsertZeroed(InsertPos);

			// Set correct name and index.
			P.AimComponents[InsertPos].BoneName = BoneName;

			// Initialize Quaternions - InsertZeroed doesn't set them to Identity
			SetBoneAimQuaternion(InsertPos, ANIMAIM_LEFTUP,			Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_CENTERUP,		Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_RIGHTUP,		Quat.Identity);

			SetBoneAimQuaternion(InsertPos, ANIMAIM_LEFTCENTER,		Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_CENTERCENTER,	Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_RIGHTCENTER,	Quat.Identity);

			SetBoneAimQuaternion(InsertPos, ANIMAIM_LEFTDOWN,		Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_CENTERDOWN,		Quat.Identity);
			SetBoneAimQuaternion(InsertPos, ANIMAIM_RIGHTDOWN,		Quat.Identity);

			// pdate RequiredBoneIndex, this will update the LookUp Table
			UpdateListOfRequiredBones();

			return InsertPos;
		}
	}

	return INDEX_NONE;
}

/// <summary>
/// Extract Parent Space Bone Atoms from Animation Data specified by Name. 
/// Returns true if successful.
/// </summary>
bool ExtractAnimationData(AnimNodeSequence SeqNode, MEdge.Core.name AnimationName, ref MEdge.array<BoneAtom> BoneAtoms)
{
	//Set Animation
	SeqNode.SetAnim(AnimationName);

	if( SeqNode.AnimSeq == null )
	{
		debugf(TEXT(" ExtractAnimationData: Animation not found: %s, Skipping..."), AnimationName.ToString());
		return false;
	}

	 SkeletalMesh	SkelMesh = SkelComponent.SkeletalMesh;
	 int				NumBones = SkelMesh.RefSkeleton.Num();

	// initialize Bone Atoms array
	if( BoneAtoms.Num() != NumBones )
	{
		BoneAtoms.Empty();
		BoneAtoms.AddCount(NumBones);
	}

	// Initialize Desired bones array. We take all.
	MEdge.array<byte> DesiredBones = new();
	DesiredBones.Empty();
	DesiredBones.AddCount(NumBones);
	for(int i=0; i<DesiredBones.Num(); i++)
	{
		DesiredBones[i] = (byte)i;
	}

	// Extract bone atoms from animation data
	BoneAtom	RootMotionDelta = default;
	bool		bHasRootMotion = false;
	SeqNode.GetBoneAtoms(ref BoneAtoms, ref DesiredBones, ref RootMotionDelta, ref bHasRootMotion);

	return true;
}

/// <summary>
/// 	Change the currently active profile to the one with the supplied name. 
/// 	If a profile with that name does not exist, this does nothing.
/// </summary>
public virtual void SetActiveProfileByName( MEdge.Core.name ProfileName )
{
	if(TemplateNode)
	{
		// Look through profiles to find a name that matches.
		for(int i=0; i<TemplateNode.Profiles.Num(); i++)
		{
			// Found it - change to it.
			if(TemplateNode.Profiles[i].ProfileName == ProfileName)
			{
				SetActiveProfileByIndex(i);
				return;
			}
		}
	}
	else
	{
		// Look through profiles to find a name that matches.
		for(int i=0; i<Profiles.Num(); i++)
		{
			// Found it - change to it.
			if(Profiles[i].ProfileName == ProfileName)
			{
				SetActiveProfileByIndex(i);
				return;
			}
		}
	}
}

/// <summary>
/// 	Change the currently active profile to the one with the supplied index. 
/// 	If ProfileIndex is outside range, this does nothing.
/// </summary>
public virtual void SetActiveProfileByIndex(int ProfileIndex)
{
	// Check new index is in range.
	// Don't update if selecting the current profile again.
	if( TemplateNode )
	{
		if( ProfileIndex == CurrentProfileIndex || ProfileIndex < 0 || ProfileIndex >= TemplateNode.Profiles.Num() )
		{
			return;
		}
	}
	else
	{
		if( ProfileIndex == CurrentProfileIndex || ProfileIndex < 0 || ProfileIndex >= Profiles.Num() )
		{
			return;
		}
	}

	// pdate profile index
	CurrentProfileIndex = ProfileIndex;

	// We need to recalculate the bone indices modified by the new profile.
	UpdateListOfRequiredBones();
}
}

public partial class AnimNodeSynch
{
/// <summary>
/// Add a node to an existing group 
/// </summary>
public virtual void AddNodeToGroup(ref AnimNodeSequence SeqNode, MEdge.Core.name GroupName)
{
	if( !SeqNode || GroupName == NAME_None )
	{
		return;
	}

	for( int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		ref SynchGroup SynchGroup = ref Groups[GroupIdx];
		if( SynchGroup.GroupName == GroupName )
		{
			// Set group name
			SeqNode.SynchGroupName = GroupName;
			SynchGroup.SeqNodes.AddUniqueItem(SeqNode);

			break;
		}
	}
}


/// <summary>
/// Remove a node from an existing group 
/// </summary>
public virtual void RemoveNodeFromGroup(ref AnimNodeSequence SeqNode, MEdge.Core.name GroupName)
{
	if( !SeqNode || GroupName == NAME_None )
	{
		return;
	}

	for( int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		ref SynchGroup SynchGroup = ref Groups[GroupIdx];
		if( SynchGroup.GroupName == GroupName )
		{
			SeqNode.SynchGroupName = NAME_None;
			SynchGroup.SeqNodes.RemoveItem(SeqNode);

			// If we're removing the Master Node, clear reference to it.
			if( SynchGroup.MasterNode == SeqNode )
			{
				SynchGroup.MasterNode = null;
				UpdateMasterNodeForGroup(ref SynchGroup);
			}

			break;
		}
	}
}


/// <summary>
/// Force a group at a relative position. 
/// </summary>
public void ForceRelativePosition(MEdge.Core.name GroupName, float RelativePosition)
{
	for( int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		ref SynchGroup SynchGroup = ref Groups[GroupIdx];
		if( SynchGroup.GroupName == GroupName )
		{
			for( int i=0; i < SynchGroup.SeqNodes.Num(); i++ )
			{
				ref AnimNodeSequence SeqNode = ref SynchGroup.SeqNodes[i];
				if( SeqNode && SeqNode.AnimSeq )
				{
					SeqNode.SetPosition(FindNodePositionFromRelative(SeqNode, RelativePosition), false);
				}
			}
		}
	}
}


/// <summary>
/// Get the relative position of a group. 
/// </summary>
public float GetRelativePosition(MEdge.Core.name GroupName)
{
	for( int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		ref SynchGroup SynchGroup = ref Groups[GroupIdx];
		if( SynchGroup.GroupName == GroupName )
		{
			if( SynchGroup.MasterNode )
			{
				return GetNodeRelativePosition(SynchGroup.MasterNode);
			}
			else
			{
				debugf(TEXT("AnimNodeSynch.GetRelativePosition, no master node for group %s"), SynchGroup.GroupName.ToString());
			}
		}
	}

	return 0f;
}

/// <summary>
/// Accesses the Master Node driving a given group 
/// </summary>
public AnimNodeSequence GetMasterNodeOfGroup(MEdge.Core.name GroupName)
{
	for(int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		if( Groups[GroupIdx].GroupName == GroupName )
		{
			return Groups[GroupIdx].MasterNode;
		}
	}

	return null;
}

/// <summary>
/// Force a group at a relative position. 
/// </summary>
public virtual void SetGroupRateScale(MEdge.Core.name GroupName, float NewRateScale)
{
	for(int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
	{
		if( Groups[GroupIdx].GroupName == GroupName )
		{
			Groups[GroupIdx].RateScale = NewRateScale;
		}
	}
}

public override void InitAnim(SkeletalMeshComponent MeshComp, AnimNodeBlendBase Parent)
{
	// Rebuild cached list of nodes belonging to each group
	RepopulateGroups();

	base.InitAnim(MeshComp, Parent);
}

/// <summary>
/// Look up AnimNodeSequences and cache Group lists 
/// </summary>
public virtual void RepopulateGroups()
{
	if( Children[0].Anim )
	{
		// get all AnimNodeSequence children and cache them to avoid over casting
		MEdge.array<AnimNodeSequence> Nodes = new array<AnimNodeSequence>();
		Children[0].Anim.GetAnimSeqNodes(ref Nodes);

		for( int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++ )
		{
			ref SynchGroup SynchGroup = ref Groups[GroupIdx];

			// Clear cached nodes
			SynchGroup.SeqNodes.Empty();

			// Caches nodes belonging to group
			if( SynchGroup.GroupName != NAME_None )
			{
				for( int i=0; i < Nodes.Num(); i++ )
				{
					AnimNodeSequence SeqNode = Nodes[i];
					if( SeqNode.SynchGroupName == SynchGroup.GroupName )	// need to be from the same group name
					{
						SynchGroup.SeqNodes.AddItem(SeqNode);
					}
				}
			}

			// Clear Master Node
			SynchGroup.MasterNode = null;

			// pdate Master Node
			UpdateMasterNodeForGroup(ref SynchGroup);
		}
	}
}

/// <summary>
/// pdates the Master Node of a given group 
/// </summary>
public virtual void UpdateMasterNodeForGroup(ref SynchGroup SynchGroup)
{
	// start with our previous node. see if we can find better!
	AnimNodeSequence	MasterNode		= SynchGroup.MasterNode;	
	// Find the node which has the highest weight... that's our master node
	float				HighestWeight	= MasterNode ? MasterNode.NodeTotalWeight : 0f;

		// if the previous master node has a full weight, then don't bother looking for another one.
	if( !SynchGroup.MasterNode || (SynchGroup.MasterNode.NodeTotalWeight < (1f - ZERO_ANIMWEIGHT_THRESH)) )
	{
		for(int i=0; i < SynchGroup.SeqNodes.Num(); i++)
		{
			AnimNodeSequence SeqNode = SynchGroup.SeqNodes[i];
			if( SeqNode &&									
				!SeqNode.bForceAlwaysSlave && 
				SeqNode.NodeTotalWeight >= HighestWeight )  // Must be the most relevant to the final blend
			{
				MasterNode		= SeqNode;
				HighestWeight	= SeqNode.NodeTotalWeight;
			}
		}

		SynchGroup.MasterNode = MasterNode;
	}
}

/// <summary>
/// The main synchronization code... 
/// </summary>
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	base.TickAnim(DeltaSeconds, TotalWeight);

	// Force continuous update if within the editor (because we can add or remove nodes)
	// This can be improved by only doing that when a node has been added a removed from the tree.
	/*if( GIsEditor && !GIsGame )
	{
		RepopulateGroups();
	}*/

	// pdate groups
	for(int GroupIdx=0; GroupIdx<Groups.Num(); GroupIdx++)
	{
		ref SynchGroup SynchGroup = ref Groups[GroupIdx];

		// pdate Master Node
		UpdateMasterNodeForGroup(ref SynchGroup);

		// Now that we have the master node, have it update all the others
		if( SynchGroup.MasterNode && SynchGroup.MasterNode.AnimSeq )
		{
			ref AnimNodeSequence MasterNode	= ref SynchGroup.MasterNode;
			 float	OldPosition			= MasterNode.CurrentTime;
			 float MasterMoveDelta		= SynchGroup.RateScale * MasterNode.Rate * MasterNode.AnimSeq.RateScale * DeltaSeconds;

			if( MasterNode.bPlaying == true )
			{
				// Keep track of PreviousTime before any update. This is used by Root Motion.
				MasterNode.PreviousTime = MasterNode.CurrentTime;

				// pdate Master Node
				// Master Node has already been ticked, so now we advance its CurrentTime position...
				// Time to move forward by - DeltaSeconds scaled by various factors.
				MasterNode.AdvanceBy(MasterMoveDelta, DeltaSeconds, true);
			}

			// Master node was changed during the tick?
			// Skip this round of updates...
			if( SynchGroup.MasterNode != MasterNode )
			{
				continue;
			}

			// pdate slave nodes only if master node has changed.
			if( MasterNode.CurrentTime != OldPosition &&
				MasterNode.AnimSeq &&
				MasterNode.AnimSeq.SequenceLength > 0f )
			{
				// Find it's relative position on its time line.
				 float MasterRelativePosition = GetNodeRelativePosition(MasterNode);

				// pdate slaves to match relative position of master node.
				for(int i=0; i<SynchGroup.SeqNodes.Num(); i++)
				{
					AnimNodeSequence SlaveNode = SynchGroup.SeqNodes[i];

					if( SlaveNode && 
						SlaveNode != MasterNode && 
						SlaveNode.AnimSeq &&
						SlaveNode.AnimSeq.SequenceLength > 0f )
					{
						// Slave's new time
						 float NewTime		= FindNodePositionFromRelative(SlaveNode, MasterRelativePosition);
						float SlaveMoveDelta	= appFmod(NewTime - SlaveNode.CurrentTime, SlaveNode.AnimSeq.SequenceLength);

						// Make sure SlaveMoveDelta And MasterMoveDelta are the same sign, so they both move in the same direction.
						if( SlaveMoveDelta * MasterMoveDelta < 0f )
						{
							if( SlaveMoveDelta >= 0f )
							{
								SlaveMoveDelta -= SlaveNode.AnimSeq.SequenceLength;
							}
							else
							{
								SlaveMoveDelta += SlaveNode.AnimSeq.SequenceLength;
							}
						}

						// Keep track of PreviousTime before any update. This is used by Root Motion.
						SlaveNode.PreviousTime = SlaveNode.CurrentTime;

						// Move slave node to correct position
						SlaveNode.AdvanceBy(SlaveMoveDelta, DeltaSeconds, SynchGroup.bFireSlaveNotifies);
					}
				}
			}
		}
	}
}
}

//#define DEBUG_ANIMNODERANDOM 0

public partial class AnimNodeRandom
{
public override void InitAnim(SkeletalMeshComponent meshComp, AnimNodeBlendBase Parent)
{
#if false//DEBUG_ANIMNODERANDOM
	debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f InitAnim"), GWorld.GetTimeSeconds());
#endif

	base.InitAnim(meshComp, Parent);	

	// Verify that Info array is in synch with child number.
	if( RandomInfo.Num() != Children.Num() )
	{
		 int Diff = Children.Num() - RandomInfo.Num();
		if( Diff > 0 )
		{
			RandomInfo.AddZeroed(Diff);
		}
		else
		{
			RandomInfo.Remove(RandomInfo.Num() + Diff, -Diff);
		}
	}

	// Only trigger animation is none is playing currently.
	// We don't want to override an animation that is currently playing.
	bool bTriggerAnim = ActiveChildIndex < 0 || ActiveChildIndex >= Children.Num() || !Children[ActiveChildIndex].Anim;

	if( !bTriggerAnim )
	{
		bTriggerAnim = !PlayingSeqNode || !PlayingSeqNode.bPlaying || !PlayingSeqNode.IsChildOf(Children[ActiveChildIndex].Anim);
	}

	if( bTriggerAnim )
	{
		PlayPendingAnimation(0f, 0f);
	}
}

/// <summary>
/// A child has been added, update RandomInfo accordingly 
/// </summary>
public override void OnAddChild(int ChildNum)
{
	base.OnAddChild(ChildNum);

	// pdate RandomInfo to match Children array
	if( ChildNum > 0 )
	{
		if( ChildNum < RandomInfo.Num() )
		{
			RandomInfo.InsertZeroed(ChildNum, 1);
		}
		else
		{
			RandomInfo.AddZeroed(1);
		}

		// Set up new addition w/ defaults
		ref RandomAnimInfo Info = ref RandomInfo[ChildNum];
		Info.Chance			= 1f;
		Info.BlendInTime	= 0.25f;
		Info.PlayRateRange	= new(){ X = 1f, Y = 1f };
	}
}


/// <summary>
/// A child has been removed, update RandomInfo accordingly 
/// </summary>
public override void OnRemoveChild(int ChildNum)
{
	base.OnRemoveChild(ChildNum);

	if( ChildNum < RandomInfo.Num() )
	{
		// pdate Mask to match Children array
		RandomInfo.RemoveAt(ChildNum);
	}
}

public override void OnChildAnimEnd(AnimNodeSequence Child, float PlayedTime, float ExcessTime)
{
#if false//DEBUG_ANIMNODERANDOM
	debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f OnChildAnimEnd %s"), GWorld.GetTimeSeconds(), *Child.AnimSeqName.ToString());
#endif

	base.OnChildAnimEnd(Child, PlayedTime, ExcessTime);

	// Node playing current animation is done playing? For a loop certainly... So transition to pending animation!
	if( Child && Child == PlayingSeqNode )
	{
		PlayPendingAnimation(0f, ExcessTime);
	}
}

int PickNextAnimIndex()
{
#if false //DEBUG_ANIMNODERANDOM
	debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f PickNextAnimIndex"), GWorld.GetTimeSeconds());
#endif

	if( Children.Num() == 0 )
	{
		return INDEX_NONE;
	}

	// If active child is in the list
	if( PlayingSeqNode && ActiveChildIndex >= 0 && ActiveChildIndex < RandomInfo.Num() )
	{
		RandomAnimInfo Info = RandomInfo[ActiveChildIndex];

		// If we need to loop, loop!
		if( Info.LoopCount > 0 )
		{
			Info.LoopCount--;
			return ActiveChildIndex;
		}
	}

	// Build a list of valid indices to choose from
	MEdge.array<int> IndexList = new array<int>();
	float TotalWeight = 0f;
	for(int Idx=0; Idx<Children.Num(); Idx++)
	{
		if( Idx != ActiveChildIndex && Idx < RandomInfo.Num() && Children[Idx].Weight <= ZERO_ANIMWEIGHT_THRESH && Children[Idx].Anim )
		{
			IndexList.AddItem(Idx);
			TotalWeight += RandomInfo[Idx].Chance;
		}
	}

	// If we have valid children to choose from
	// (Fall through will just replay current active child)
	if( IndexList.Num() > 0 )
	{
		MEdge.array<float> Weights = new array<float>();
		Weights.Add(IndexList.Num());
	
		/** Value used to normalize weights so all childs add up to 1f */
		for(int i=0; i<IndexList.Num(); i++)
		{
			Weights[i] = RandomInfo[IndexList[i]].Chance / TotalWeight;
		}	

		float	RandomWeight	= appFrand();
		int		Index			= 0;
		int		DesiredChildIdx	= IndexList[Index];

		// This child has too much weight, so skip to next.
		while( Index < IndexList.Num() - 1 && RandomWeight > Weights[Index] )
		{
			RandomWeight -= Weights[Index];
			Index++;
			DesiredChildIdx	= IndexList[Index];
		}

		RandomAnimInfo Info = RandomInfo[DesiredChildIdx];

		// Reset loop counter
		if( Info.LoopCountMax > Info.LoopCountMin )
		{
			Info.LoopCount = (byte)(Info.LoopCountMin + appRand() % (Info.LoopCountMax - Info.LoopCountMin + 1));
		}

		return DesiredChildIdx;
	}

	// Fall back to using current one again.
	return ActiveChildIndex;
}

public virtual void PlayPendingAnimation(float BlendTime, float StartTime)
{
#if false //DEBUG_ANIMNODERANDOM
	debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f PlayPendingAnimation. PendingChildIndex: %d, BlendTime: %f, StartTime: %f"), GWorld.GetTimeSeconds(), PendingChildIndex, BlendTime, StartTime);
#endif

	// if our pending child index is not valid, pick one
	if( !(PendingChildIndex >= 0 && PendingChildIndex < Children.Num() && PendingChildIndex < RandomInfo.Num() && Children[PendingChildIndex].Anim) )
	{
		PendingChildIndex = PickNextAnimIndex();
#if false //DEBUG_ANIMNODERANDOM
		debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f PlayPendingAnimation. PendingChildIndex not valid, picked: %d"), GWorld.GetTimeSeconds(), PendingChildIndex);
#endif
		// if our pending child index is STILL not valid, abort
		if( !(PendingChildIndex >= 0 && PendingChildIndex < Children.Num() && PendingChildIndex < RandomInfo.Num() && Children[PendingChildIndex].Anim) )
		{
#if false //DEBUG_ANIMNODERANDOM
			debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f PlayPendingAnimation. PendingChildIndex still not valid, abort"), GWorld.GetTimeSeconds());
#endif
			return;
		}
	}

	// Set new active child w/ blend
	SetActiveChild(PendingChildIndex, BlendTime);

	// Play the animation if this child is a sequence
	PlayingSeqNode = (Children[ActiveChildIndex].Anim as AnimNodeSequence );
	if( PlayingSeqNode )
	{
		RandomAnimInfo Info = RandomInfo[ActiveChildIndex];

		float PlayRate = Lerp(Info.PlayRateRange.X, Info.PlayRateRange.Y, appFrand());
		if( PlayRate < KINDA_SMALL_NUMBER )
		{
			PlayRate = 1f;
		}
		PlayingSeqNode.PlayAnim(false, PlayRate, 0f);

		// Advance to proper position if needed, useful for looping animations.
		if( StartTime > 0f )
		{
			PlayingSeqNode.SetPosition(StartTime * PlayingSeqNode.GetGlobalPlayRate(), true);
		}
	}

	// Pick PendingChildIndex for next time...
	PendingChildIndex = PickNextAnimIndex();
#if false //DEBUG_ANIMNODERANDOM
	debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f PlayPendingAnimation. Picked PendingChildIndex: %d"), GWorld.GetTimeSeconds(), PendingChildIndex);
#endif
}


/// <summary>
/// Ticking, updates weights... 
/// </summary>
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	// Check for transition when a new animation is playing
	// in order to trigger blend early for smooth transitions.
	if( ActiveChildIndex >=0 && ActiveChildIndex < RandomInfo.Num() )
	{
		// Do this only when transitioning from one animation to another. not looping.
		if( ActiveChildIndex != PendingChildIndex )
		{
			RandomAnimInfo Info = RandomInfo[ActiveChildIndex];

			if( Info.BlendInTime > 0f && PlayingSeqNode && PlayingSeqNode.AnimSeq )
			{
				 float TimeLeft = PlayingSeqNode.GetTimeLeft();

				if( TimeLeft <= Info.BlendInTime )
				{
#if false //DEBUG_ANIMNODERANDOM
					debugf(TEXT("%3.public partial class AnimNodeRandom
{
2f TickAnim. Blending to pending animation. TimeLeft: %f"), GWorld.GetTimeSeconds(), TimeLeft);
#endif
					PlayPendingAnimation(TimeLeft, 0f);
				}
			}
		}
	}
	else
	{
		// we're not doing anything??
		PlayPendingAnimation(0f, 0f);
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}
}

public partial class AnimNodeBlendByPhysics
{
/// <summary>
/// Blend animations based on an Owner's physics.
/// 
/// @param DeltaSeconds	Time since last tick in seconds.
/// </summary>
public override void TickAnim( float DeltaSeconds, float TotalWeight )
{
	Pawn Owner = SkelComponent ? (SkelComponent.Owner as Pawn) : null;

	if ( Owner )
	{
		if( ActiveChildIndex != (int)Owner.Physics )
		{
			SetActiveChild( (int)Owner.Physics , 0.1f );
		}
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}
}

public partial class AnimNodeBlendByBase
{
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	Actor AOwner = SkelComponent ? SkelComponent.Owner : null;

	if( AOwner && AOwner.Base != CachedBase )
	{
		int DesiredChildIdx = 0;

		CachedBase = AOwner.Base;
		if( CachedBase )
		{
			switch( Type )
			{
				case EBaseBlendType.BBT_ByActorTag:
					if( CachedBase.Tag == ActorTag )
					{
						DesiredChildIdx = 1;
					}
					break;

				case EBaseBlendType.BBT_ByActorClass:
					if( CachedBase.Class == ActorClass )
					{
						DesiredChildIdx = 1;
					}
					break;

				default:
					break;
			}
		}
		
		if( DesiredChildIdx != ActiveChildIndex )
		{
			SetActiveChild(DesiredChildIdx, bJustBecameRelevant ? 0f : BlendTime);
		}
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}
}

public partial class AnimNodeScalePlayRate
{
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	if( Children[0].Anim )
	{
		MEdge.array<AnimNodeSequence> SeqNodes = new array<AnimNodeSequence>();
		Children[0].Anim.GetAnimSeqNodes(ref SeqNodes);

		 float Rate = GetScaleValue();

		for( int i=0; i<SeqNodes.Num(); i++ )
		{
			SeqNodes[i].Rate = Rate;
		}
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}

float GetScaleValue()
{
	return ScaleByValue;
}
}

public partial class AnimNodeScaleRateBySpeed
{
public float GetScaleValue()
{
	Actor Owner = SkelComponent ? SkelComponent.Owner : null;
	if( Owner && BaseSpeed > KINDA_SMALL_NUMBER )
	{
		return Owner.Velocity.Size() / BaseSpeed;
	}
	else
	{
		return ScaleByValue;
	}
}
}

/// <summary>
/// Main tick
/// </summary>
public partial class AnimNodePlayCustomAnim
{
public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	// check for custom animation timing, to blend out before it is over.
	if( bIsPlayingCustomAnim && CustomPendingBlendOutTime >= 0f )
	{
		AnimNodeSequence ActiveChild = (Children[1].Anim as AnimNodeSequence );
		if( ActiveChild && ActiveChild.AnimSeq )
		{
			 float TimeLeft = ActiveChild.AnimSeq.SequenceLength - ActiveChild.CurrentTime;

			// if it's time to blend back to previous animation, do so.
			if( TimeLeft <= CustomPendingBlendOutTime )
			{
				bIsPlayingCustomAnim = false;
			}
		}
	}

	 float DesiredChild2Weight = bIsPlayingCustomAnim ? 1f : 0f;

	// Child needs to be updated
	if( DesiredChild2Weight != Child2WeightTarget )
	{
		float BlendInTime = 0f;

		// if blending out from Custom animation node, use CustomPendingBlendOutTime
		if( Child2WeightTarget == 1f && CustomPendingBlendOutTime >= 0 )
		{
			BlendInTime					= CustomPendingBlendOutTime;
			CustomPendingBlendOutTime	= -1;
		}
		SetBlendTarget(DesiredChild2Weight, BlendInTime);
	}

	// pdate AnimNodeBlendList
	base.TickAnim(DeltaSeconds, TotalWeight);
}

/// <summary>
/// Play a custom animation.
/// Supports many features, including blending in and out. *
/// @param	AnimName		Name of animation to play.
/// @param	Rate			Rate the animation should be played at.
/// @param	BlendInTime		Blend duration to play anim.
/// @param	BlendOutTime	Time before animation ends (in seconds) to blend out.
/// 							-1f means no blend out. 
/// 							0f = instant switch, no blend. 
/// 							otherwise it's starting to blend out at AnimDuration - BlendOutTime seconds.
/// @param	bLooping		Should the anim loop? (and play forever until told to stop)
/// @param	bOverride		play same animation over again only if bOverride is set to true.
/// </summary>
public float PlayCustomAnim(MEdge.Core.name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride)
{
	// Pre requisites
	if( AnimName == NAME_None || Rate <= 0f )
	{
		return 0f;
	}

	AnimNodeSequence Child = (Children[1].Anim as AnimNodeSequence);
	if( Child )
	{
		SetBlendTarget(1f, BlendInTime);
		bIsPlayingCustomAnim = true;

		// when looping an animation, blend out time is not supported
		CustomPendingBlendOutTime = bLooping ? -1f : BlendOutTime;

		// if already playing the same anim, replay it again only if bOverride is set to true.
		if( Child.AnimSeqName == AnimName && Child.bPlaying && !bOverride && Child.bLooping == bLooping )
		{
			return 0f;
		}

		if( Child.AnimSeqName != AnimName )
		{
			Child.SetAnim(AnimName);
		}
		Child.PlayAnim(bLooping, Rate, 0f);
		return Child.GetAnimPlaybackLength();
	}
	return 0f;
}

/// <summary>
/// Play a custom animation. 
/// Auto adjusts the animation's rate to match a given duration in seconds.
/// Supports many features, including blending in and out.
/// 
/// @param	AnimName		Name of animation to play.
/// @param	Duration		duration in seconds the animation should be played.
/// @param	BlendInTime		Blend duration to play anim.
/// @param	BlendOutTime	Time before animation ends (in seconds) to blend out.
/// 							-1f means no blend out. 
/// 							0f = instant switch, no blend. 
/// 							otherwise it's starting to blend out at AnimDuration - BlendOutTime seconds.
/// @param	bLooping		Should the anim loop? (and play forever until told to stop)
/// @param	bOverride		play same animation over again only if bOverride is set to true.
/// </summary>
public virtual void PlayCustomAnimByDuration(MEdge.Core.name AnimName, float Duration, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride)
{
	// Pre requisites
	if( AnimName == NAME_None || Duration <= 0f )
	{
		return;
	}

	AnimSequence AnimSeq = SkelComponent.FindAnimSequence(AnimName);
	if( AnimSeq )
	{
		float NewRate = AnimSeq.SequenceLength / Duration;
		PlayCustomAnim(AnimName, NewRate, BlendInTime, BlendOutTime, bLooping, bOverride);
	}
	else
	{
		debugf(TEXT("UWarAnim_PlayCustomAnim.PlayAnim - AnimSequence for %s not found"), AnimName.ToString());
	}
}

/// <summary>
/// Stop playing a custom animation. 
/// sed for blending out of a looping custom animation.
/// </summary>
public virtual void StopCustomAnim(float BlendOutTime)
{
	if( bIsPlayingCustomAnim )
	{
		bIsPlayingCustomAnim		= false;
		CustomPendingBlendOutTime	= BlendOutTime;
	}
}

}

/// <summary>
/// Will ensure TargetWeight array is right size. If it has to resize it, will set Chidlren(0) to have a target of 1.0.
/// Also, if all Children weights are zero, will set Children[0] as the active child.
/// 
/// @public partial class AnimNode
// see UAnimNode.InitAnim
/// </summary>
public partial class AnimNodeSlot
{
public override void InitAnim(SkeletalMeshComponent MeshComp, AnimNodeBlendBase Parent)
{
	base.InitAnim(MeshComp, Parent);

	if( Children.Num() > 0 )
	{
		// If all child weights are zero - set the first one to the active child.
		if( GetChildWeightTotal() <= ZERO_ANIMWEIGHT_THRESH )
		{
			Children[0].Weight = 1f;
		}
	}

	if( TargetWeight.Num() != Children.Num() )
	{
		TargetWeight.Empty();
		TargetWeight.AddZeroed(Children.Num());

		if( TargetWeight.Num() > 0 )
		{
			TargetWeight[0] = 1f;
		}
	}

	// If all child weights are zero - set the first one to the active child.
	if( GetChildWeightTotal() <= ZERO_ANIMWEIGHT_THRESH )
	{
		SetActiveChild(TargetChildIndex, 0f);
	}

	// clear SynchNode; we find it on-demand in AddToSynchGroup() to avoid large initialization times when there are many copies of this object in the tree
	SynchNode = null;
}

/// <summary>
/// pdate position of given channel 
/// </summary>
public virtual void MAT_SetAnimPosition(int ChannelIndex, MEdge.Core.name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
{
	 int ChildNum = ChannelIndex + 1;

	if( ChildNum >= Children.Num() )
	{
		debugf(TEXT("AnimNodeSlot.MAT_SetAnimPosition, invalid ChannelIndex: %d"), ChannelIndex);
		return;
	}

	AnimNodeSequence SeqNode = (Children[ChildNum].Anim as AnimNodeSequence);
	if( SeqNode )
	{
		// pdate Animation if needed
		if( SeqNode.AnimSeqName != InAnimSeqName )
		{
			SeqNode.SetAnim(InAnimSeqName);
		}

		SeqNode.bLooping = bLooping;

		// Set new position
		SeqNode.SetPosition(InPosition, bFireNotifies);
	}
}
/// <summary>
/// pdate weight of channels 
/// </summary>
public virtual void MAT_SetAnimWeights( ref Actor.AnimSlotInfo SlotInfo)
{
	 int NumChilds = Children.Num();

	if( NumChilds == 1 )
	{
		// Only one child, not much choice here!
		Children[0].Weight = 1f;
	}
	else if( NumChilds >= 2 )
	{
		// number of channels from Matinee
		 int NumChannels	= SlotInfo.ChannelWeights.Num();
		float AccumulatedWeight = 0f;

		// Set blend weight to each child, from Matinee channels alpha.
		// Start from last to first, as we want bottom channels to have precedence over top ones.
		for(int i=Children.Num()-1; i>0; i--)
		{
			int	ChannelIndex	= i - 1;
			float ChannelWeight	= ChannelIndex < NumChannels ? Clamp(SlotInfo.ChannelWeights[ChannelIndex], 0f, 1f) : 0f;
			Children[i].Weight			= ChannelWeight * (1f - AccumulatedWeight);
			AccumulatedWeight			+= Children[i].Weight;
		}
		
		// Set remaining weight to "normal" / animtree animation.
		Children[0].Weight = 1f - AccumulatedWeight;
	}
}


/// <summary>
/// Rename all child nodes upon Add/Remove, so they match their position in the array. 
/// </summary>
public override void RenameChildConnectors()
{
	 int NumChildren = Children.Num();

	if( NumChildren > 0 )
	{
		Children[0].Name = "Source";

		for(int i=1; i<NumChildren; i++)
		{
			Children[i].Name = $"Channel {i-1}";
		}
	}
}

/// <summary>
/// When requested to play a new animation, we need to find a new child.
/// We'd like to find one that is unused for smooth blending, 
/// but that may be a luxury that is not available.
/// </summary>
int FindBestChildToPlayAnim(MEdge.Core.name AnimToPlay)
{
	float	BestWeight	= 1f;
	int		BestIndex	= INDEX_NONE;

	for(int i=1; i<Children.Num(); i++)
	{
		if( BestIndex == INDEX_NONE || Children[i].Weight < BestWeight )
		{
			BestIndex	= i;
			BestWeight	= Children[i].Weight;

			// If we've found a perfect candidate, no need to look further!
			if( BestWeight <= ZERO_ANIMWEIGHT_THRESH )
			{
				break;
			}
		}
	}

	// Send a warning if node we've picked is relevant. This is going to result in a visible pop.
	if( BestWeight > ZERO_ANIMWEIGHT_THRESH )
	{
		Actor AOwner = SkelComponent ? SkelComponent.Owner : null;
		debugf(TEXT("AnimNodeSlot.FindBestChildToPlayAnim - Best Index %d with a weight of %f, for Anim: %s and Owner: %s"), 
			BestIndex, BestWeight, AnimToPlay.ToString(), AOwner.Name);
	}

	return BestIndex;
}


/// <summary>
/// Play a custom animation.
/// Supports many features, including blending in and out.
/// 
/// @param	AnimName		Name of animation to play.
/// @param	Rate			Rate the animation should be played at.
/// @param	BlendInTime		Blend duration to play anim.
/// @param	BlendOutTime	Time before animation ends (in seconds) to blend out.
/// 							-1f means no blend out. 
/// 							0f = instant switch, no blend. 
/// 							otherwise it's starting to blend out at AnimDuration - BlendOutTime seconds.
/// @param	bLooping		Should the anim loop? (and play forever until told to stop)
/// @param	bOverride		play same animation over again only if bOverride is set to true.
/// </summary>
public float PlayCustomAnim(name AnimName, float Rate, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
{
	// Pre requisites
	if( AnimName == NAME_None || Rate <= 0f )
	{
		return 0f;
	}

	// Figure out on which child to the play the animation on.
	// If BlendInTime == 0f, then no need to look for another child to play the animation on,
	// It's fine to use the same
	if( CustomChildIndex < 1 || (_BlendInTime ?? 0f) > 0f )
	{
		CustomChildIndex = FindBestChildToPlayAnim(AnimName);
	}

	if( CustomChildIndex < 1 || CustomChildIndex >= Children.Num() )
	{
		debugf(TEXT("AnimNodeSlot.PlayCustomAnim, CustomChildIndex %d is out of bounds."), CustomChildIndex);
		return 0f;
	}

	AnimNodeSequence SeqNode = (Children[CustomChildIndex].Anim as AnimNodeSequence );
	if( SeqNode )
	{
		bool bSetAnim = true;

		// if already playing the same anim, replay it again only if bOverride is set to true.
		if( !(_bOverride ?? false) && 
			SeqNode.bPlaying && SeqNode.bLooping == (_bLooping??false) && 
			SeqNode.AnimSeqName == AnimName && SeqNode.AnimSeq != null )
		{
			bSetAnim = false;
		}

		if( bSetAnim )
		{
			if( SeqNode.AnimSeqName != AnimName || SeqNode.AnimSeq == null )
			{
				SeqNode.SetAnim(AnimName);
				if( SeqNode.AnimSeq == null )
				{
					// Animation was not found, so abort. because we wouldn't be able to blend out.
					return 0f;
				}
			}

			// Play the animation
			SeqNode.PlayAnim(_bLooping??false, Rate, 0f);
		}

		SetActiveChild(CustomChildIndex, _BlendInTime ?? 0f);
		bIsPlayingCustomAnim = true;

		// when looping an animation, blend out time is not supported
		PendingBlendOutTime = _bLooping??false ? -1f : _BlendOutTime ?? 0f;

		// Disable Actor AnimEnd notification.
		SetActorAnimEndNotification(false);

#if false // DEBUG
		ref AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();
		debugf(TEXT("PlayCustomAnim %s, CustomChildIndex: %d"), *AnimName, CustomChildIndex);
#endif
		return SeqNode.GetAnimPlaybackLength();
	}
	else
	{
		debugf(TEXT("AnimNodeSlot.PlayCustomAnim, Child %d, is not hooked up to a AnimNodeSequence."), CustomChildIndex);
	}

	return 0f;
}

/// <summary>
/// Play a custom animation. 
/// Auto adjusts the animation's rate to match a given duration in seconds.
/// Supports many features, including blending in and out.
/// 
/// @param	AnimName		Name of animation to play.
/// @param	Duration		duration in seconds the animation should be played.
/// @param	BlendInTime		Blend duration to play anim.
/// @param	BlendOutTime	Time before animation ends (in seconds) to blend out.
/// 							-1f means no blend out. 
/// 							0f = instant switch, no blend. 
/// 							otherwise it's starting to blend out at AnimDuration - BlendOutTime seconds.
/// @param	bLooping		Should the anim loop? (and play forever until told to stop)
/// @param	bOverride		play same animation over again only if bOverride is set to true.
/// </summary>
public virtual void PlayCustomAnimByDuration(name AnimName, float Duration, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default, /*optional */bool? _bLooping = default, /*optional */bool? _bOverride = default)
{
	// Pre requisites
	if( AnimName == NAME_None || Duration <= 0f )
	{
		return;
	}

	AnimSequence AnimSeq = SkelComponent.FindAnimSequence(AnimName);
	if( AnimSeq )
	{
		float NewRate = AnimSeq.SequenceLength / Duration;
		if( AnimSeq.RateScale > 0f )
		{
			NewRate /= AnimSeq.RateScale;
		}

		PlayCustomAnim(AnimName, NewRate, _BlendInTime ?? 0f, _BlendOutTime ?? 0f, _bLooping ?? false, _bOverride ?? true);
	}
	else
	{
		debugf(TEXT("AnimNodeSlot.PlayAnim - AnimSequence for %s not found"), AnimName.ToString());
	}
}

/// <summary>
/// Returns the Name of the currently played animation or NAME_None otherwise. 
/// </summary>
public MEdge.Core.name GetPlayedAnimation()
{
	AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();
	if( SeqNode )
	{	
		return SeqNode.AnimSeqName;
	}

	return NAME_None;
}


/// <summary>
/// Stop playing a custom animation. 
/// sed for blending out of a looping custom animation.
/// </summary>
public virtual void StopCustomAnim(float BlendOutTime)
{
	if( bIsPlayingCustomAnim )
	{
#if false // DEBUG
		ref AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();
		debugf(TEXT("StopCustomAnim %s, CustomChildIndex: %d"), *SeqNode.AnimSeqName, CustomChildIndex);
#endif

		bIsPlayingCustomAnim = false;
		SetActiveChild(0, BlendOutTime);
	}
}

/// <summary>
/// Stop playing a custom animation. 
/// sed for blending out of a looping custom animation.
/// </summary>
public virtual void SetCustomAnim(MEdge.Core.name AnimName)
{
	if( bIsPlayingCustomAnim )
	{
		AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();
		if( SeqNode && SeqNode.AnimSeqName != AnimName )
		{
			SeqNode.SetAnim(AnimName);
		}
	}
}

/// <summary>
/// Set bCauseActorAnimEnd flag to receive AnimEnd() notification.
/// </summary>
public virtual void SetActorAnimEndNotification(bool bNewStatus)
{
	// Set all childs but the active one to false. 
	// Active one is set to bNewStatus
	for(int i=1; i<Children.Num(); i++)
	{
		AnimNodeSequence SeqNode = (Children[i].Anim as AnimNodeSequence );

		if( SeqNode )
		{
			SeqNode.bCauseActorAnimEnd = (bIsPlayingCustomAnim && i == CustomChildIndex ? bNewStatus : false);
		}
	}
}



/// <summary>
/// Returns AnimNodeSequence currently selected for playing animations.
/// Note that calling PlayCstomAnim ref may change which node plays the animation.
/// (Depending on the blend in time, and how many nodes are available, to provide smooth transitions.
/// </summary>
public AnimNodeSequence GetCustomAnimNodeSeq()
{
	if( CustomChildIndex > 0 )
	{
		return (Children[CustomChildIndex].Anim as AnimNodeSequence);
	}

	return null;
}
	
// Export UAnimNodeSlot::execSetRootBoneAxisOption(FFrame&, void* const)
public virtual /*native final function */void SetRootBoneAxisOption(/*optional */AnimNodeSequence.ERootBoneAxis? _AxisX = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisY = default, /*optional */AnimNodeSequence.ERootBoneAxis? _AxisZ = default)
{
	AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();

	if( SeqNode )
	{
		SeqNode.RootBoneOption[0] = _AxisX ?? AnimNodeSequence.ERootBoneAxis.RBA_Default;
		SeqNode.RootBoneOption[1] = _AxisY ?? AnimNodeSequence.ERootBoneAxis.RBA_Default;
		SeqNode.RootBoneOption[2] = _AxisZ ?? AnimNodeSequence.ERootBoneAxis.RBA_Default;
	}
}
#if UNUSED
/// <summary>
/// Set custom animation root bone options.
/// </summary>
public virtual void SetRootBoneAxisOption(byte AxisX, byte AxisY, byte AxisZ)
{
	AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();

	if( SeqNode )
	{
		SeqNode.RootBoneOption[0] = (AnimNodeSequence.ERootBoneAxis)AxisX;
		SeqNode.RootBoneOption[1] = (AnimNodeSequence.ERootBoneAxis)AxisY;
		SeqNode.RootBoneOption[2] = (AnimNodeSequence.ERootBoneAxis)AxisZ;
	}
}
#endif

/// <summary>
/// Synchronize this animation with others. 
/// @param GroupName	Add node to synchronization group named group name.
/// </summary>
public virtual void AddToSynchGroup(MEdge.Core.name GroupName)
{
	AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();

	if( !SeqNode || SeqNode.SynchGroupName == GroupName )
	{
		return;
	}

	// Find synchronization node if necessary
	if (SynchNode == null)
	{
		MEdge.array<AnimNode> Nodes = new();
		SkelComponent.Animations.GetNodes(ref Nodes);
		for(int i = 0; i < Nodes.Num(); i++)
		{
			SynchNode = (Nodes[i] as AnimNodeSynch);
			if (SynchNode != null)
			{
				break;
			}
		}
	}

	if (SynchNode != null)
	{
		// If node had a group, leave it
		if( SeqNode.SynchGroupName != NAME_None )
		{
			SynchNode.RemoveNodeFromGroup(SeqNode, SeqNode.SynchGroupName);
		}

		// If a new group name is set, assign it
		if( GroupName != NAME_None )
		{
			SynchNode.AddNodeToGroup(SeqNode, GroupName);
		}
	}
}

public override void TickAnim(float DeltaSeconds, float TotalWeight)
{
	if( bIsPlayingCustomAnim   )
	{
		AnimNodeSequence SeqNode = GetCustomAnimNodeSeq();

		// Hmm there's no animations to play, so we shouldn't be here
		if( !SeqNode || !SeqNode.AnimSeq )
		{
			StopCustomAnim(0f);
		}

		// check for custom animation timing, to blend out before it is over.
		if( PendingBlendOutTime >= 0f )
		{
			if( SeqNode && SeqNode.AnimSeq )
			{
				 float TimeLeft = SeqNode.GetTimeLeft();

				// if it's time to blend back to previous animation, do so.
				if( TimeLeft <= PendingBlendOutTime )
				{
					// Blend out, and stop tracking this animations.
					StopCustomAnim(TimeLeft);

					// Force an AnimEnd notification earlier when we start blending out. Improves transitions.
					if( SeqNode.bCauseActorAnimEnd && SkelComponent.Owner )
					{
						SeqNode.bCauseActorAnimEnd = false;
						SkelComponent.Owner.OnAnimEnd(SeqNode, DeltaSeconds, 0f);
					}

				}
			}
		}
	}

	check(Children.Num() == TargetWeight.Num());

	// Do nothing if BlendTimeToGo is zero.
	if( BlendTimeToGo > 0f )
	{
		// So we don't overshoot.
		if( BlendTimeToGo <= DeltaSeconds )
		{
			BlendTimeToGo = 0f; 

			for(int i=0; i<Children.Num(); i++)
			{
				Children[i].Weight = TargetWeight[i];
			}
		}
		else
		{
			for(int i=0; i<Children.Num(); i++)
			{
				// Amount left to blend.
				 float BlendDelta = TargetWeight[i] - Children[i].Weight;
				Children[i].Weight += (BlendDelta / BlendTimeToGo) * DeltaSeconds;
			}

			BlendTimeToGo -= DeltaSeconds;
		}
	}

	base.TickAnim(DeltaSeconds, TotalWeight);
}


/// <summary>
/// The the child to blend up to full Weight (1.0)
/// 
/// @param ChildIndex Index of child node to ramp in. If outside range of children, will set child 0 to active.
/// @param BlendTime How long for child to take to reach weight of 1.0.
/// </summary>
public virtual void SetActiveChild(int ChildIndex, float BlendTime)
{
	check(Children.Num() == TargetWeight.Num());

	if( ChildIndex < 0 || ChildIndex >= Children.Num() )
	{
		debugf( TEXT("AnimNodeBlendList.SetActiveChild : %s ChildIndex (%d) outside number of Children (%d)."), this.Name, ChildIndex, Children.Num() );
		ChildIndex = 0;
	}

	// Scale blend time by weight of target child.
	BlendTime *= (1f - Children[ChildIndex].Weight);

	// If time is too small, consider instant blend
	if( BlendTime < ZERO_ANIMWEIGHT_THRESH )
	{
		BlendTime = 0f;
	}

	for(int i=0; i<Children.Num(); i++)
	{
		// Child becoming active
		if( i == ChildIndex )
		{
			TargetWeight[i] = 1.0f;

			// If we basically want this straight away - dont wait until a tick to update weights.
			if( BlendTime == 0.0f )
			{
				Children[i].Weight = 1.0f;
			}
		}
		// Others, blending to zero weight
		else
		{
			TargetWeight[i] = 0f;

			if( BlendTime == 0.0f )
			{
				Children[i].Weight = 0.0f;
			}
		}
	}

	BlendTimeToGo		= BlendTime;
	TargetChildIndex	= ChildIndex;
}

/// <summary>
/// Called when we add a child to this node. We reset the TargetWeight array when this happens. 
/// </summary>
public override void OnAddChild(int ChildNum)
{
	base.OnAddChild(ChildNum);

	ResetTargetWeightArray(ref TargetWeight, Children.Num());
}

/// <summary>
/// Called when we remove a child to this node. We reset the TargetWeight array when this happens. 
/// </summary>
public override void OnRemoveChild(int ChildNum)
{
	base.OnRemoveChild(ChildNum);

	ResetTargetWeightArray(ref TargetWeight, Children.Num());
}
}
}

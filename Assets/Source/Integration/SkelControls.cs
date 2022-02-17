namespace MEdge.Engine
{
	using Core;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using UINT = System.UInt32;
	using BOOL = System.Boolean;
	using UBOOL = System.Boolean;
	using BYTE = System.Byte;
	using FVector = MEdge.Core.Object.Vector;
	using FRotator = MEdge.Core.Object.Rotator;
	using FQuat = MEdge.Core.Object.Quat;
	using FMatrix = MEdge.Core.Object.Matrix;
	using FCheckResult = MEdge.Source.DecFn.CheckResult;
	using static Source.DecFn;



	public partial class SkelControlSingleBone
	{
		public override void GetAffectedBones(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<INT> OutBoneIndices)
		{
			check(OutBoneIndices.Num() == 0);
			OutBoneIndices.AddItem(BoneIndex);
		}
		public override void CalculateNewBoneTransforms(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<FMatrix> OutBoneTransforms)
		{
			check(OutBoneTransforms.Num() == 0);

			FMatrix NewBoneTM = SkelComp.SpaceBases[BoneIndex];

			if(bApplyRotation)
			{
				// SpaceBases are in component space - so we need to calculate the BoneRotationSpace . Component transform
				FMatrix ComponentToFrame = SkelComp.CalcComponentToFrameMatrix(BoneIndex, BoneRotationSpace, RotationSpaceBoneName);
				ComponentToFrame.SetOrigin( FVector(0f) );

				FMatrix FrameToComponent = ComponentToFrame.Inverse();

				var RotInFrame = FRotationMatrix(BoneRotation);

				// Add to existing rotation
				FMatrix RotInComp;
				if(bAddRotation)
				{
					RotInComp = NewBoneTM * (ComponentToFrame * RotInFrame * FrameToComponent);
				}
				// Replace current rotation
				else
				{
					RotInComp = RotInFrame * FrameToComponent;
				}
				RotInComp.SetOrigin( NewBoneTM.GetOrigin() );

				NewBoneTM = RotInComp;
			}

			if(bApplyTranslation)
			{
				FMatrix ComponentToFrame = SkelComp.CalcComponentToFrameMatrix(BoneIndex, BoneTranslationSpace, TranslationSpaceBoneName);

				// Add to current transform
				if(bAddTranslation)
				{
					FVector TransInComp = ComponentToFrame.InverseTransformNormal(BoneTranslation);

					FVector NewOrigin = NewBoneTM.GetOrigin() + TransInComp;
					NewBoneTM.SetOrigin(NewOrigin);
				}
				// Replace current translation
				else
				{
					// Translation in the component reference frame.
					FVector TransInComp = ComponentToFrame.InverseTransformFVector(ref BoneTranslation);

					NewBoneTM.SetOrigin(TransInComp);
				}
			}

			OutBoneTransforms.AddItem(NewBoneTM);
		}
	}



	public partial class SkelControlLookAt
	{
		public override FLOAT GetControlAlpha()
		{
			return ControlStrength * LookAtAlpha;
		}
		public override void GetAffectedBones(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<INT> OutBoneIndices)
		{
			// Bone is not allowed to rotate, early out
			if( !bAllowRotationX && !bAllowRotationY && !bAllowRotationZ )
			{
				return;
			}

			check(OutBoneIndices.Num() == 0);
			OutBoneIndices.AddItem(BoneIndex);
		}
		
		public override void CalculateNewBoneTransforms(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<FMatrix> OutBoneTransforms)
		{
			NativeMarkers.MarkUnimplemented();
			#if UNUSED
			check(OutBoneTransforms.Num() == 0);

			// Bone transform in mesh space
			FMatrix NewBoneTM = SkelComp.SpaceBases[BoneIndex];

			// Find the base look direction vector.
			BaseLookDir		= SkelComp.SpaceBases[BoneIndex].TransformNormal( GetAxisDirVector(LookAtAxis, bInvertLookAtAxis) ).SafeNormal();
			// Get bone position (will be in component space).
			BaseBonePos		= SkelComp.SpaceBases[BoneIndex].GetOrigin();
			// Keep track of when BaseLookDir was last updated.
			LastCalcTime	= GWorld.GetWorldInfo().TimeSeconds;

			// Get target location, in component space.
			FMatrix ComponentToFrame	= SkelComp.CalcComponentToFrameMatrix(BoneIndex, TargetLocationSpace, TargetSpaceBoneName);
			FVector TargetCompSpace	= ComponentToFrame.InverseTransformFVector(ref TargetLocation);

			// Find direction vector we want to look in - again in component space.
			FVector DesiredLookDir	= (TargetCompSpace - BaseBonePos).SafeNormal();

			// Use limits to update DesiredLookDir if desired.
			// We also use these to play with the 'LookAtAlpha'
			ApplyLookDirectionLimits(DesiredLookDir, BaseLookDir, BoneIndex, SkelComp);

			// Below we not touching LookAtAlpha anymore. So if it's zero, there's no point going further.
			if( GetControlAlpha() < ZERO_ANIMWEIGHT_THRESH )
			{
				return;
			}

			// If we are not defining an 'up' axis as well, we calculate the minimum rotation needed to point the axis in 
			// the right direction. This is nice because we still have some animation acting on the roll of the bone.
			if( !bDefineUpAxis )
			{
				// Calculate a quaternion that gets us from our current rotation to the desired one.
				FQuat DeltaLookQuat = FQuatFindBetween(BaseLookDir, DesiredLookDir);
				FQuatRotationTranslationMatrix DeltaLookTM( DeltaLookQuat, FVector(0f) );

				NewBoneTM.SetOrigin( FVector(0f) );
				NewBoneTM = NewBoneTM * DeltaLookTM;
				NewBoneTM.SetOrigin( BaseBonePos );
			}
			// If we are defining an 'up' axis as well, we can calculate the entire bone transform explicitly.
			else
			{
				if( UpAxis == LookAtAxis )
				{
					debugf( TEXT("USkelControlLookAt (%s): UpAxis and LookAtAxis cannot be the same."), *ControlName.ToString() );
				}

				// Invert look at direction if desired.
				if( bInvertLookAtAxis )
				{
					DesiredLookDir *= -1f;
				}

				// Calculate 'world up' (+Z) in the component ref frame.
				const FVector UpCompSpace = SkelComp.LocalToWorld.InverseTransformNormal( FVector(0,0,1) );

				// Then calculate our desired up vector using 2 cross products. Probably a more elegant way to do this...
				FVector TempRight = DesiredLookDir ^ UpCompSpace;

				// Handle case when DesiredLookDir ~= (0,0,1) ie looking straight up in this mode.
				if( TempRight.IsNearlyZero() )
				{
					TempRight = FVector(0,1,0);
				}
				else
				{
					TempRight.Normalize();
				}

				FVector DesiredUpDir = TempRight ^ DesiredLookDir;

				// Reverse direction if desired.
				if( bInvertUpAxis )
				{
					DesiredUpDir *= -1f;
				}

				// Do some sanity checking on vectors before using them to generate vectors.
				if((DesiredLookDir != DesiredUpDir) && (DesiredLookDir | DesiredUpDir) < 0.1f)
				{
					// Then build the bone matrix. 
					NewBoneTM = BuildMatrixFromVectors(LookAtAxis, DesiredLookDir, UpAxis, DesiredUpDir);
					NewBoneTM.SetOrigin( BaseBonePos );
				}
			}

			// See if we should do some per rotation axis filtering
			if( !bAllowRotationX || !bAllowRotationY || !bAllowRotationZ )
			{
				FQuat CompToFrameQuat(SkelComp.CalcComponentToFrameMatrix(BoneIndex, AllowRotationSpace, AllowRotationOtherBoneName));
				FQuat CurrentQuatRot = CompToFrameQuat * FQuat(SkelComp.SpaceBases[BoneIndex]);
				FQuat DesiredQuatRot = CompToFrameQuat * FQuat(NewBoneTM);
				CurrentQuatRot.Normalize();
				DesiredQuatRot.Normalize();

				FQuat DeltaQuat = DesiredQuatRot * (-CurrentQuatRot);
				DeltaQuat.Normalize();

				FRotator DeltaRot = FQuatRotationTranslationMatrix(DeltaQuat, FVector(0f)).Rotator();

				// Filter out any of the Roll (X), Pitch (Y), Yaw (Z) in bone relative space
				if( !bAllowRotationX )
				{
					DeltaRot.Roll	= 0;
				}
				if( !bAllowRotationY )
				{
					DeltaRot.Pitch	= 0;
				}
				if( !bAllowRotationZ )
				{
					DeltaRot.Yaw	= 0;
				}

				// Find new desired rotation
				DesiredQuatRot = DeltaRot.Quaternion() * CurrentQuatRot;
				DesiredQuatRot.Normalize();

				FQuat NewQuat = (-CompToFrameQuat) * DesiredQuatRot;
				NewQuat.Normalize();

				// Turn into new bone position.
				NewBoneTM = FQuatRotationTranslationMatrix(NewQuat, BaseBonePos);
			}

			OutBoneTransforms.AddItem(NewBoneTM);
			#endif
		}
	}



	public partial class SkelControlLimb
	{
		public override void GetAffectedBones(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<INT> OutBoneIndices)
		{
			check(OutBoneIndices.Num() == 0);

			// Get indices of the lower and upper limb bones.
			UBOOL bInvalidLimb = FALSE;
			if( BoneIndex == 0 )
			{
				bInvalidLimb = TRUE;
			}

			INT LowerLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;
			if( LowerLimbIndex == 0 )
			{
				bInvalidLimb = TRUE;
			}

			INT UpperLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[LowerLimbIndex].ParentIndex;

			// If we walked past the root, this controlled is invalid, so return no affected bones.
			if( bInvalidLimb )
			{
				debugf( TEXT("USkelControlLimb : Cannot find 2 bones above controlled bone. Too close to root.") );
				return;
			}
			else
			{
				OutBoneIndices.Add(3);
				OutBoneIndices[0] = UpperLimbIndex;
				OutBoneIndices[1] = LowerLimbIndex;
				OutBoneIndices[2] = BoneIndex;
			}
		}
		
		public override void CalculateNewBoneTransforms(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<FMatrix> OutBoneTransforms)
		{
			check(OutBoneTransforms.Num() == 0);
			OutBoneTransforms.AddCount(3); // Allocate space for bone transforms.

			// First get indices of the lower and upper limb bones. We should have checked this in GetAffectedBones so can assume its ok now.

			check(BoneIndex != 0);
			INT LowerLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;
			check(LowerLimbIndex != 0);
			INT UpperLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[LowerLimbIndex].ParentIndex;

			// If we have enough bones to work on (ie at least 2 bones between controlled hand bone and the root) continue.

			// Get current position of root of limb.
			// All position are in Component space.
			FVector RootPos			= SkelComp.SpaceBases[UpperLimbIndex].GetOrigin();
			FVector InitialJointPos	= SkelComp.SpaceBases[LowerLimbIndex].GetOrigin();
			FVector InitialEndPos		= SkelComp.SpaceBases[BoneIndex].GetOrigin();

			// If desired, calc the initial relative transform between the end effector bone and its parent.
			FMatrix EffectorRelTM = FMatrix.Identity;
			if( bMaintainEffectorRelRot ) 
			{
				EffectorRelTM = SkelComp.SpaceBases[BoneIndex] * SkelComp.SpaceBases[LowerLimbIndex].Inverse();
			}

			// Get desired position of effector.
			FMatrix			DesiredComponentToFrame	= SkelComp.CalcComponentToFrameMatrix(BoneIndex, EffectorLocationSpace, EffectorSpaceBoneName);
			FVector			DesiredPos				= DesiredComponentToFrame.InverseTransformFVector(ref EffectorLocation);
			FVector			DesiredDelta			= DesiredPos - RootPos;
			FLOAT			DesiredLength			= DesiredDelta.Size();

			// Check to handle case where DesiredPos is the same as RootPos.
			FVector			DesiredDir;
			if( DesiredLength < (FLOAT)KINDA_SMALL_NUMBER )
			{
				DesiredLength	= (FLOAT)KINDA_SMALL_NUMBER;
				DesiredDir		= FVector(1,0,0);
			}
			else
			{
				DesiredDir		= DesiredDelta/DesiredLength;
			}

			// Fix up desired position to take into account bone scaling.
			{
				// Find BoneScaling currently used. We don't support non uniform scaling.
				FLOAT BoneScaling = GetMaximumAxisScale(SkelComp.SpaceBases[UpperLimbIndex]);

				if( BoneScaling > KINDA_SMALL_NUMBER && Abs(1f - BoneScaling) > KINDA_SMALL_NUMBER )
				{
					DesiredLength	= DesiredLength / BoneScaling;
					DesiredDelta	= DesiredDir * DesiredLength;
					DesiredPos		= RootPos + DesiredDelta;
				}
			}

			// Get joint target (used for defining plane that joint should be in).
			FMatrix			JointTargetComponentToFrame	= SkelComp.CalcComponentToFrameMatrix(BoneIndex, JointTargetLocationSpace, JointTargetSpaceBoneName);
			FVector	JointTargetPos				= JointTargetComponentToFrame.InverseTransformFVector(ref JointTargetLocation);

			FVector	JointTargetDelta	= JointTargetPos - RootPos;
			FLOAT		JointTargetLength	= JointTargetDelta.Size();
			FVector JointPlaneNormal , JointBendDir = default;

			// Same check as above, to cover case when JointTarget position is the same as RootPos.
			if( JointTargetLength < (FLOAT)KINDA_SMALL_NUMBER )
			{
				JointBendDir		= FVector(0,1,0);
				JointPlaneNormal	= FVector(0,0,1);
			}
			else
			{
				JointPlaneNormal = DesiredDir ^ JointTargetDelta;

				// If we are trying to point the limb in the same direction that we are supposed to displace the joint in, 
				// we have to just pick 2 random vector perp to DesiredDir and each other.
				if( JointPlaneNormal.Size() < (FLOAT)KINDA_SMALL_NUMBER )
				{
					DesiredDir.FindBestAxisVectors(ref JointPlaneNormal, ref JointBendDir);
				}
				else
				{
					JointPlaneNormal.Normalize();

					// Find the final member of the reference frame by removing any component of JointTargetDelta along DesiredDir.
					// This should never leave a zero vector, because we've checked DesiredDir and JointTargetDelta are not parallel.
					JointBendDir = JointTargetDelta - ((JointTargetDelta | DesiredDir) * DesiredDir);
					JointBendDir.Normalize();
				}
			}

			// Find lengths of upper and lower limb in the ref skeleton.
			// Use actual sizes instead of ref skeleton, so we take into account translation and scaling from other bone controllers.
			FLOAT LowerLimbLength = SkelComp.LocalAtoms[BoneIndex].Translation.Size();			// SkelComp.SkeletalMesh.RefSkeleton[BoneIndex].BonePos.Position.Size();
			FLOAT UpperLimbLength = SkelComp.LocalAtoms[LowerLimbIndex].Translation.Size();		// SkelComp.SkeletalMesh.RefSkeleton[LowerLimbIndex].BonePos.Position.Size();
			FLOAT MaxLimbLength	= LowerLimbLength + UpperLimbLength;

			FVector OutEndPos	= DesiredPos;
			FVector OutJointPos = InitialJointPos;

			// If we are trying to reach a goal beyond the length of the limb, clamp it to something solvable and extend limb fully.
			if( DesiredLength > MaxLimbLength )
			{
				OutEndPos	= RootPos + (MaxLimbLength * DesiredDir);
				OutJointPos = RootPos + (UpperLimbLength * DesiredDir);
			}
			else
			{
				// So we have a triangle we know the side lengths of. We can work out the angle between DesiredDir and the direction of the upper limb
				// using the sin rule:
				FLOAT CosAngle = ((UpperLimbLength*UpperLimbLength) + (DesiredLength*DesiredLength) - (LowerLimbLength*LowerLimbLength))/(2 * UpperLimbLength * DesiredLength);

				// If CosAngle is less than 0, the upper arm actually points the opposite way to DesiredDir, so we handle that.
				UBOOL bReverseUpperBone = (CosAngle < 0f);

				// If CosAngle is greater than 1f, the triangle could not be made - we cannot reach the target.
				// We just have the two limbs double back on themselves, and EndPos will not equal the desired EffectorLocation.
				if( CosAngle > 1f || CosAngle < -1f )
				{
					// Because we want the effector to be a positive distance down DesiredDir, we go back by the smaller section.
					if( UpperLimbLength > LowerLimbLength )
					{
						OutJointPos = RootPos + (UpperLimbLength * DesiredDir);
						OutEndPos	= OutJointPos - (LowerLimbLength * DesiredDir);
					}
					else
					{
						OutJointPos = RootPos - (UpperLimbLength * DesiredDir);
						OutEndPos	= OutJointPos + (LowerLimbLength * DesiredDir);
					}
				}
				else
				{
					// Angle between upper limb and DesiredDir
					FLOAT Angle = appAcos(CosAngle);

					// Now we calculate the distance of the joint from the root . effector line.
					// This forms a right-angle triangle, with the upper limb as the hypotenuse.
					FLOAT JointLineDist = UpperLimbLength * appSin(Angle);

					// And the final side of that triangle - distance along DesiredDir of perpendicular.
					// ProjJointDistSqr can't be neg, because JointLineDist must be <= UpperLimbLength because appSin(Angle) is <= 1.
					FLOAT ProjJointDistSqr	= (UpperLimbLength*UpperLimbLength) - (JointLineDist*JointLineDist);
					FLOAT		ProjJointDist		= appSqrt(ProjJointDistSqr);
					if( bReverseUpperBone )
					{
						ProjJointDist *= -1f;
					}

					// So now we can work out where to put the joint!
					OutJointPos = RootPos + (ProjJointDist * DesiredDir) + (JointLineDist * JointBendDir);
				}
			}

			// Update transform for upper bone.
			FVector GraphicJointDir = JointPlaneNormal;
			if( bInvertJointAxis )
			{
				GraphicJointDir *= -1f;
			}

			FVector UpperLimbDir = (OutJointPos - RootPos).SafeNormal();
			if( bInvertBoneAxis )
			{
				UpperLimbDir *= -1f;
			}

			// Do some sanity checking, then use vectors to build upper limb matrix
			if((UpperLimbDir != GraphicJointDir) && (UpperLimbDir | GraphicJointDir) < 0.1f)
			{
				FMatrix UpperLimbTM = BuildMatrixFromVectors(BoneAxis, UpperLimbDir, JointAxis, GraphicJointDir);
				UpperLimbTM.SetOrigin(RootPos);
				OutBoneTransforms[0] = UpperLimbTM;
			}
			else
			{
				OutBoneTransforms[0] = SkelComp.SpaceBases[UpperLimbIndex];
			}

			// Update transform for lower bone.
			FVector LowerLimbDir = (OutEndPos - OutJointPos).SafeNormal();
			if( bInvertBoneAxis )
			{
				LowerLimbDir *= -1f;
			}

			// Do some sanity checking, then use vectors to build lower limb matrix
			if((LowerLimbDir != GraphicJointDir) && (LowerLimbDir | GraphicJointDir) < 0.1f)
			{
				FMatrix LowerLimbTM = BuildMatrixFromVectors(BoneAxis, LowerLimbDir, JointAxis, GraphicJointDir);
				LowerLimbTM.SetOrigin(OutJointPos);
				OutBoneTransforms[1] = LowerLimbTM;
			}
			else
			{
				OutBoneTransforms[1] = SkelComp.SpaceBases[LowerLimbIndex];
			}

			// Update transform for end bone.
			if( bTakeRotationFromEffectorSpace )
			{
				OutBoneTransforms[2] = SkelComp.SpaceBases[BoneIndex];
				FMatrix FrameToComponent = DesiredComponentToFrame.Inverse();
				CopyRotationPart(ref OutBoneTransforms[2], FrameToComponent);
			}
			else if( bMaintainEffectorRelRot )
			{
				OutBoneTransforms[2] = EffectorRelTM * OutBoneTransforms[1];
			}
			else
			{
				OutBoneTransforms[2] = SkelComp.SpaceBases[BoneIndex];
			}
			OutBoneTransforms[2].SetOrigin(OutEndPos);
		}
	}



	public partial class SkelControlFootPlacement
	{
		public override void CalculateNewBoneTransforms(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<FMatrix> OutBoneTransforms)
		{
			// First get indices of the lower and upper limb bones. 
			// We should have checked this in GetAffectedBones so can assume its ok now.

			check(BoneIndex != 0);
			INT LowerLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[BoneIndex].ParentIndex;
			check(LowerLimbIndex != 0);
			INT UpperLimbIndex = SkelComp.SkeletalMesh.RefSkeleton[LowerLimbIndex].ParentIndex;

			// Find the root and end position in world space.
			FVector RootPos = SkelComp.SpaceBases[UpperLimbIndex].GetOrigin();
			FVector WorldRootPos = SkelComp.LocalToWorld.TransformFVector(RootPos);

			FVector EndPos = SkelComp.SpaceBases[BoneIndex].GetOrigin();
			FVector WorldEndPos = SkelComp.LocalToWorld.TransformFVector(EndPos);

			FVector LegDelta = WorldEndPos - WorldRootPos;
			FVector LegDir = LegDelta.SafeNormal();

			// We do a hack here - extend length of line by 100 - to get around Unreals nasty line check fudging.
			FVector CheckEndPos = WorldEndPos + (100f + FootOffset + MaxDownAdjustment) * LegDir;

			FVector HitLocation = default, HitNormal = default;
			UBOOL bHit = SkelComp.LegLineCheck( WorldRootPos, CheckEndPos, ref HitLocation, ref HitNormal);

			FLOAT LegAdjust = 0f;
			if(bHit)
			{
				// Find how much we are adjusting the foot up or down. Postive is down, negative is up.
				LegAdjust = ((HitLocation - WorldEndPos) | LegDir);

				// Reject hits in the 100-unit dead region.
				if( bHit && LegAdjust > (FootOffset + MaxDownAdjustment) )
				{
					bHit = false;
				}
			}

			FVector DesiredPos;
			if(bHit)
			{
				LegAdjust -= FootOffset;

				// Clamp LegAdjust between MaxUp/DownAdjustment.
				LegAdjust = Clamp(LegAdjust, -MaxUpAdjustment, MaxDownAdjustment);

				// If bOnlyEnableForUpAdjustment is true, do nothing if we are not adjusting the leg up.
				if(bOnlyEnableForUpAdjustment && LegAdjust >= 0f)
				{
					return;
				}

				// ..and calculate EffectorLocation.
				DesiredPos = WorldEndPos + (LegAdjust * LegDir);
			}
			else
			{
				if(bOnlyEnableForUpAdjustment)
				{
					return;
				}	

				// No hit - we reach as far as MaxDownAdjustment will allow.
				DesiredPos = WorldEndPos + (MaxDownAdjustment * LegDir);
			}

			EffectorLocation = DesiredPos;
			EffectorLocationSpace = EBoneControlSpace.BCS_WorldSpace;

			base.CalculateNewBoneTransforms(BoneIndex, SkelComp, ref OutBoneTransforms);

			check(OutBoneTransforms.Num() == 3);

			// OutBoneTransforms[2] will be the transform for the foot here.
			FVector FootPos = (OutBoneTransforms[2] * SkelComp.LocalToWorld).GetOrigin();	

			// Now we orient the foot if desired, and its sufficiently close to our desired position.
			if(bOrientFootToGround && bHit && ((FootPos - DesiredPos).Size() < 1.0f) && !HitNormal.IsZero())
			{
				check(!OutBoneTransforms[2].ContainsNaN());

				// Find reference frame we are trying to orient to the ground. Its the foot bone transform, with the FootRotOffset applied.
				FMatrix BoneRefMatrix = FRotationMatrix(FootRotOffset) * OutBoneTransforms[2];

				// Find the 'up' vector of that reference frame, in component space.
				FVector CurrentFootDir = BoneRefMatrix.TransformNormal( GetAxisDirVector(FootUpAxis, bInvertFootUpAxis) );
				CurrentFootDir = CurrentFootDir.SafeNormal();	

				// Transform hit normal into component space.
				FVector NormalCompSpace = SkelComp.LocalToWorld.InverseTransformNormal(HitNormal).SafeNormal();

				// Calculate a quaternion that gets us from our current rotation to the desired one.
				FQuat DeltaFootQuat = FQuatFindBetween(CurrentFootDir, NormalCompSpace);
				var TempFootTM = FQuatRotationTranslationMatrix( DeltaFootQuat, FVector(0f) );
				check(!TempFootTM.ContainsNaN());

				// Limit the maximum amount we are going to correct by to 'MaxFootOrientAdjust'
				FLOAT MaxFootOrientRad = MaxFootOrientAdjust * ((FLOAT)PI/180f);
				FVector DeltaFootAxis = default;
				FLOAT DeltaFootAng = default;
				DeltaFootQuat.ToAxisAndAngle(ref DeltaFootAxis, ref DeltaFootAng);
				DeltaFootAng = Clamp(DeltaFootAng, -MaxFootOrientRad, MaxFootOrientRad);
				DeltaFootQuat = new Quat(DeltaFootAxis, DeltaFootAng);

				// Convert from quaternion to rotation matrix.
				var DeltaFootTM = FQuatRotationTranslationMatrix( DeltaFootQuat, FVector(0f) );
				check(!DeltaFootTM.ContainsNaN());

				// Apply rotation matrix to current foot matrix.
				FVector FootBonePos = OutBoneTransforms[2].GetOrigin();
				OutBoneTransforms[2].SetOrigin( FVector(0f) );
				OutBoneTransforms[2] = OutBoneTransforms[2] * DeltaFootTM;
				OutBoneTransforms[2].SetOrigin( FootBonePos );
				check(!OutBoneTransforms[2].ContainsNaN());
			}
		}
	}



	public partial class SkelControlBase
	{
		public virtual FLOAT GetControlAlpha()
		{
			// If desired, use cubic interpolation for skeletal control, to allow them to blend in more smoothly.
			if(bEnableEaseInOut)
			{
				return CubicInterp(0f, 0f, 1f, 0f, ControlStrength);
			}
			else
			{
				return ControlStrength;
			}
		}
		public virtual void CalculateNewBoneScales(INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<FLOAT> OutBoneScales) {}
		public virtual FLOAT GetBoneScale(INT BoneIndex, SkeletalMeshComponent SkelComp) { return BoneScale; }
		public FVector GetAxisDirVector(Object.EAxis InAxis, UBOOL bInvert)
		{
			FVector AxisDir;

			if(InAxis == Object.EAxis.AXIS_X)
			{
				AxisDir = FVector(1,0,0);
			}
			else if(InAxis == Object.EAxis.AXIS_Y)
			{
				AxisDir =  FVector(0,1,0);
			}
			else
			{
				AxisDir =  FVector(0,0,1);
			}

			if(bInvert)
			{
				AxisDir *= -1f;
			}

			return AxisDir;
		}
		public virtual void GetAffectedBones( INT BoneIndex, SkeletalMeshComponent SkelComp, ref array<INT> OutBoneIndices )
		{
			throw new System.NotImplementedException(this.GetType().ToString());
		}
		
		public virtual void CalculateNewBoneTransforms( int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms )
		{
			throw new System.NotImplementedException(this.GetType().ToString());
		}
		
		// Export USkelControlBase::execSetSkelControlActive(FFrame&, void* const)
		public virtual /*native final function */void SetSkelControlActive(bool bInActive)
		{
			if( bInActive )
			{
				StrengthTarget	= 1f;
				BlendTimeToGo	= BlendInTime;
			}
			else
			{
				StrengthTarget	= 0f;
				BlendTimeToGo	= BlendOutTime;
			}

			// If we want this weight NOW - update straight away (dont wait for TickSkelControl).
			if( BlendTimeToGo <= 0f )
			{
				ControlStrength = StrengthTarget;
				BlendTimeToGo	= 0f;
			}

			// If desired, send active call to next control in chain.
			if( NextControl && bPropagateSetActive )
			{
				NextControl.SetSkelControlActive(bInActive);
			}
		}
		
		// Export USkelControlBase::execSetSkelControlStrength(FFrame&, void* const)
		public virtual /*native final function */void SetSkelControlStrength(float NewStrength, float InBlendTime)
		{
			// Make sure parameters are valid
			NewStrength = Clamp(NewStrength, 0f, 1f);
			InBlendTime	= Max(InBlendTime, 0f);

			if( StrengthTarget != NewStrength || InBlendTime < BlendTimeToGo )
			{
				StrengthTarget	= NewStrength;
				BlendTimeToGo	= InBlendTime;

				// If blend time is zero, apply now and don't wait a frame.
				if( BlendTimeToGo <= 0f )
				{
					ControlStrength = StrengthTarget;
					BlendTimeToGo	= 0f;
				}
			}
		}
		
		public virtual void TickSkelControl(float DeltaSeconds, SkeletalMeshComponent SkelComp)
		{
			// Update SkelComponent pointer.
			SkelComponent = SkelComp;

			// Check if we should set the control's strength to match a set of specific anim nodes.
			if( bSetStrengthFromAnimNode && SkelComp && SkelComp.Animations )
			{
				// if node is node initialized, cache list of nodes
				// in the editor, we do this every frame to catch nodes that have been edited/added/removed
				if( !bInitializedCachedNodeList || (GIsEditor && !GIsGame) )
				{
					bInitializedCachedNodeList = TRUE;

					CachedNodeList.Reset();

					// get all nodes
					//TArray<UAnimNode*>	Nodes;
					MEdge.array<AnimNode> Nodes = new array<AnimNode>();
					SkelComp.Animations.GetNodes(ref Nodes);

					// iterate through list of nodes
					for(int i=0; i<Nodes.Num(); i++)
					{
						var Node = Nodes[i];

						if( Node && Node.NodeName != NAME_None )
						{
							// iterate through our list of names
							for(int ANodeNameIdx=0; ANodeNameIdx<StrengthAnimNodeNameList.Num(); ANodeNameIdx++)
							{
								if( Node.NodeName == StrengthAnimNodeNameList[ANodeNameIdx] )
								{
									CachedNodeList.AddItem(Node);
									break;
								}
							}
						}
					}
				}

				float Strength = 0f;

				// iterate through list of cached nodes
				for(int i=0; i<CachedNodeList.Num(); i++)
				{
					var Node = CachedNodeList[i];
					
					if( Node && Node.bRelevant )
					{
						Strength += Node.NodeTotalWeight;
					}

					/* Here is if we want to match the weight of the most relevant node.
					// if the node's weight is greater, use that
					if( Node && Node->NodeTotalWeight > Strength )
					{
						Strength = Node->NodeTotalWeight;
					}
					*/
				}

				ControlStrength	= Min(Strength, 1f);
				StrengthTarget	= ControlStrength;
			}

			if( BlendTimeToGo != 0f ||	ControlStrength != StrengthTarget )
			{
				// Update the blend status, if one is active.
				float BlendDelta = StrengthTarget - ControlStrength; // Amount we want to change ControlStrength by.

				if( BlendTimeToGo > DeltaSeconds && BlendTimeToGo != 0.0f)
				{
					ControlStrength	+= (BlendDelta / BlendTimeToGo) * DeltaSeconds;
					BlendTimeToGo	-= DeltaSeconds;
				}
				else
				{
					BlendTimeToGo	= 0f; 
					ControlStrength	= StrengthTarget;
				}

				//debugf(TEXT("%3.2f SkelControl ControlStrength: %f, StrengthTarget: %f, BlendTimeToGo: %f"), GWorld->GetTimeSeconds(), ControlStrength, StrengthTarget, BlendTimeToGo);
			}
		}
	}
}
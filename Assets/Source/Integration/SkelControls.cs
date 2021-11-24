namespace MEdge.Engine
{
	using Core;



	public partial class SkelControlSingleBone
	{
		public override void CalculateNewBoneTransforms(int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms)
		{
			NativeMarkers.MarkUnimplemented();
			/*check(OutBoneTransforms.Num() == 0);

			FMatrix NewBoneTM = SkelComp.SpaceBases(BoneIndex);

			if(bApplyRotation)
			{
				// SpaceBases are in component space - so we need to calculate the BoneRotationSpace -> Component transform
				FMatrix ComponentToFrame = SkelComp->CalcComponentToFrameMatrix(BoneIndex, BoneRotationSpace, RotationSpaceBoneName);
				ComponentToFrame.SetOrigin( FVector(0.f) );

				FMatrix FrameToComponent = ComponentToFrame.Inverse();

				FRotationMatrix RotInFrame(BoneRotation);

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
				FMatrix ComponentToFrame = SkelComp->CalcComponentToFrameMatrix(BoneIndex, BoneTranslationSpace, TranslationSpaceBoneName);

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
					FVector TransInComp = ComponentToFrame.InverseTransformFVector(BoneTranslation);

					NewBoneTM.SetOrigin(TransInComp);
				}
			}

			OutBoneTransforms.AddItem(NewBoneTM);*/
		}
	}



	public partial class SkelControlBase
	{
		public virtual void CalculateNewBoneTransforms( int BoneIndex, SkeletalMeshComponent SkelComp, ref array<Matrix> OutBoneTransforms )
		{
			NativeMarkers.MarkUnimplemented();
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
			NewStrength = Clamp<float>(NewStrength, 0f, 1f);
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
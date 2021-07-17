namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeBlendList
	{
		// Export UAnimNodeBlendList::execSetActiveChild(FFrame&, void* const)
		public virtual /*native function */void SetActiveChild(int ChildIndex, float BlendTime)
		{
			for(var i = 0; i < Children.Length; i++)
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
				if( Children[ActiveChildIndex].Anim is AnimNodeSequence AnimSeq )
				{
					AnimSeq.PlayAnim( AnimSeq.bLooping, AnimSeq.Rate );
				}
			}
		}
	}
}
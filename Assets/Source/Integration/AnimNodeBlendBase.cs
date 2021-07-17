namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeBlendBase : AnimNode
	{
		/**
		 * Make sure to relay OnChildAnimEnd to Parent AnimNodeBlendBase as long as it exists 
		 */ 
		public void OnChildAnimEnd(AnimNodeSequence Child, float PlayedTime, float ExcessTime) 
		{ 
			for(var i=0; i<ParentNodes.Length; i++)
			{
				ParentNodes[i].OnChildAnimEnd(Child, PlayedTime, ExcessTime); 
			}
		}
		
		// Export UAnimNodeBlendBase::execPlayAnim(FFrame&, void* const)
		public override /*native function */void PlayAnim(/*optional */bool? _bLoop = default, /*optional */float? _Rate = default, /*optional */float? _StartTime = default)
		{
			// pass on the call to our children
			for (var i = 0; i < Children.Num(); i++)
			{
				if (Children[i].Anim != null)
				{
					Children[i].Anim.PlayAnim(_bLoop, _Rate, _StartTime);
				}
			}
		}
	}
}
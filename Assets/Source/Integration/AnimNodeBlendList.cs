namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeBlendList
	{
		// Export UAnimNodeBlendList::execSetActiveChild(FFrame&, void* const)
		public virtual /*native function */void SetActiveChild(int ChildIndex, float BlendTime)
		{
			for( int i = 0; i < TargetWeight.Length; i++ )
			{
				TargetWeight[ i ] = 0f;
			}

			TargetWeight[ ChildIndex ] = 1f;
			BlendTimeToGo = BlendTime;
			ActiveChildIndex = ChildIndex;
			if(bPlayActiveChild)
				PlayAnim();
		}
	}
}
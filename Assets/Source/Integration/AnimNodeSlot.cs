namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeSlot
	{
		// Export UAnimNodeSlot::execGetCustomAnimNodeSeq(FFrame&, void* const)
        public virtual /*native final function */AnimNodeSequence GetCustomAnimNodeSeq()
        {
	        return Children[ 1 ].Anim as AnimNodeSequence;
        }
	}
}
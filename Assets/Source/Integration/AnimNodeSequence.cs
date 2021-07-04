namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeSequence
	{
		// Export UAnimNodeSequence::execSetPosition(FFrame&, void* const)
        public virtual /*native function */void SetPosition(float NewTime, bool bFireNotifies)
        {
	        this.CurrentTime = NewTime;
	        if(bFireNotifies == false) // I think ?
				this.PreviousTime = NewTime;
        }
        
        // Export UAnimNodeSequence::execGetNormalizedPosition(FFrame&, void* const)
        public virtual /*native function */float GetNormalizedPosition()
        {
	        return this.CurrentTime / this.AnimSeq.SequenceLength;
        }
        
        // Export UAnimNodeSequence::execGetAnimPlaybackLength(FFrame&, void* const)
        public virtual /*native function */float GetAnimPlaybackLength()
        {
	        return this.AnimSeq.SequenceLength;
        }
	}
}
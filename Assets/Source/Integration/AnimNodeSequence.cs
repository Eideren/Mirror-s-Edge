namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeSequence
	{
		// Export UAnimNodeSequence::execPlayAnim(FFrame&, void* const)
		public override /*native function */void PlayAnim(/*optional */bool? _bLoop = false, /*optional */float? _InRate = 1f, /*optional */float? _StartTime = 0f)
		{
			PlayAnim(_bLoop ?? false, _InRate ?? 1f, _StartTime ?? 0f);
		}
	}
}
namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class TdAnimNodeState
	{
		// Export UTdAnimNodeState::execSetActiveMove(FFrame&, void* const)
		public override /*native function */bool SetActiveMove(int ChildIndex, /*optional */bool? _ForceActive = default)
		{
			// Decompiled just jumps to the base function afaict
			return base.SetActiveMove( ChildIndex, _ForceActive );
		}
	}
}
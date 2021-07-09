namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class TdPlayerPawn 
	{
		// Export UTdPlayerPawn::execGetMobilityMultiplier(FFrame&, void* const)
		public override /*native function */ float GetMobilityMultiplier() => base.GetMobilityMultiplier(); // Points to the same as UTdPlayer::execGetMobilityMultiplier
	}
}
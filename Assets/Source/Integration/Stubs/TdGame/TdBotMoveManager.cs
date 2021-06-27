namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotMoveManager : TdMoveManager/* within TdBotPawn*/{
	public new TdBotPawn Outer => base.Outer as TdBotPawn;
	
	public override /*simulated function */void HandleMoveAction(TdPawn.EMovementAction Action)
	{
		// stub
	}
	
}
}
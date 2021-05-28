namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotStartWalking : TdMove_BotStart/*
		config(PawnMovement)*/{
	public const double cMinDistForStandToWalk = 95f;
	
	public float MinTimeBetweenTwoStartMoves;
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public TdMove_BotStartWalking()
	{
		// Object Offset:0x005A794C
		MinTimeBetweenTwoStartMoves = 0.50f;
	}
}
}
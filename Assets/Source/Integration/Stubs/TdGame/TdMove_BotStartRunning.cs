namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotStartRunning : TdMove_BotStart/*
		native
		config(PawnMovement)*/{
	public const double cMinDistForStandToRun = 150f;
	public const double cMinClearDist = 150f;
	
	public float MoveStartedTimeStamp;
	public float MinTimeBetweenTwoStartMoves;
	
	public virtual /*event */float TimeSinceMoveStarted()
	{
		// stub
		return default;
	}
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public TdMove_BotStartRunning()
	{
		// Object Offset:0x005A7548
		MoveStartedTimeStamp = -999.0f;
		MinTimeBetweenTwoStartMoves = 0.50f;
	}
}
}
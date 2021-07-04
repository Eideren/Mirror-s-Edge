namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotLanding : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public float ShortRunningDistance;
	public float MediumRunningDistance;
	public float LongRunningDistance;
	public float SoftLandingHeight;
	public float RollDistance;
	public /*transient */Object.Vector StartLocation;
	public TdMove_BotJump.EBotJumpLength JumpLength;
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void OnTimer()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public override /*simulated function */void PostStopMove()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	// Export UTdMove_BotLanding::execCalculateLandingStretch(FFrame&, void* const)
	public virtual /*native function */float CalculateLandingStretch()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdMove_BotLanding()
	{
		// Object Offset:0x005A2CE8
		MediumRunningDistance = 250.0f;
		LongRunningDistance = 450.0f;
		SoftLandingHeight = 420.0f;
		RollDistance = 650.0f;
		JumpLength = TdMove_BotJump.EBotJumpLength.BJL_None;
		bDisableCollision = false;
	}
}
}
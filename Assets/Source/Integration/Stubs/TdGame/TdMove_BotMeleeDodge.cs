namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_BotMeleeDodge : TdMove/*
		config(PawnMovement)*/{
	public enum EMeleeDodgeType 
	{
		EDodgeType_RollRight,
		EDodgeType_RollLeft,
		EDodgeType_MAX
	};
	
	public/*private*/ TdMove_BotMeleeDodge.EMeleeDodgeType MeleeDodgeType;
	
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
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public virtual /*function */bool IsThereRoomForMove(TdMove_BotMeleeDodge.EMeleeDodgeType MoveToDo)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */void TriggerMove(TdMove_BotMeleeDodge.EMeleeDodgeType MoveToDo)
	{
		// stub
	}
	
}
}
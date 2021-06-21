namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StumbleBot : TdMove_StumbleBase/*
		config(PawnMovement)*/{
	public /*private */bool bStandMeleeToStand;
	
	public override /*function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool DiscardHitReaction()
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
	
	public virtual /*simulated function */void PlayStumbleAnimation()
	{
		// stub
	}
	
	public virtual /*function */void EnableHeadFocus()
	{
		// stub
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
}
}
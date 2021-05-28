namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_StumbleBot : TdMove_StumbleBase/*
		config(PawnMovement)*/{
	public /*private */bool bStandMeleeToStand;
	
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public virtual /*function */bool DiscardHitReaction()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public virtual /*simulated function */void PlayStumbleAnimation()
	{
	
	}
	
	public virtual /*function */void EnableHeadFocus()
	{
	
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
}
}
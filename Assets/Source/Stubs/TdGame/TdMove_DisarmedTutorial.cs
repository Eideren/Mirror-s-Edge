namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_DisarmedTutorial : TdMove_DisarmedBot/*
		config(PawnMovement)*/{
	public override /*function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public TdMove_DisarmedTutorial()
	{
		// Object Offset:0x005B472E
		bDisableCollision = false;
	}
}
}
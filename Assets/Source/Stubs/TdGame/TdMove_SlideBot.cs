namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_SlideBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public/*(Slide)*/ /*config */float SlideAbortSpeed;
	public /*private */Object.Vector EndTarget;
	public /*private */Object.Vector startPos;
	public /*private */float DistanceToTravel;
	
	public virtual /*simulated function */void SetEndTarget(Object.Vector P)
	{
		// stub
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated function */void StopMove()
	{
		// stub
	}
	
	public virtual /*event */void AbortSlide()
	{
		// stub
	}
	
	public TdMove_SlideBot()
	{
		// Object Offset:0x005DA02D
		SlideAbortSpeed = 100.0f;
		FrictionModifier = 0.0350f;
		bDisableCollision = false;
		bDisableActorCollision = true;
		bUseCustomCollision = true;
	}
}
}
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
	
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated function */void StopMove()
	{
	
	}
	
	public virtual /*event */void AbortSlide()
	{
	
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
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitPRI : TdBagPRI/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public float LastBagRequestTime;
	public /*config */float MaxRequestDistance;
	public /*config */float AllowedBagRequestedInterval;
	public float LastBagRequestedTime;
	public Actor RequesterActor;
	
	public override /*function */void OnUseCarriedObject(Actor inActor)
	{
	
	}
	
	public override /*function */void ScoreInterceptedCarriedObject()
	{
	
	}
	
	public virtual /*reliable client simulated function */void ClientBagRequested(Actor Requester)
	{
	
	}
	
	public TdPursuitPRI()
	{
		// Object Offset:0x00653722
		LastBagRequestTime = -999.0f;
		LastBagRequestedTime = -999.0f;
	}
}
}
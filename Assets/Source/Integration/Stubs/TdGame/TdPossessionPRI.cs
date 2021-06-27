namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPossessionPRI : TdBagPRI/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public override /*function */void OnCarryObject(Actor inActor)
	{
		// stub
	}
	
	public override /*function */void OnDropCarriedObject(Actor inActor)
	{
		// stub
	}
	
}
}
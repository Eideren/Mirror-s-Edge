namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_AISpecialMove : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public TdMove_AISpecialMove()
	{
		// Object Offset:0x0059C9AA
		bDisableCollision = true;
	}
}
}
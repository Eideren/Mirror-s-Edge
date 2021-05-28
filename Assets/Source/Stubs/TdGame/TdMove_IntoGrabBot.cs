namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_IntoGrabBot : TdMove_IntoGrab/*
		config(PawnMovement)*/{
	public TdMove_IntoGrabBot()
	{
		// Object Offset:0x005C4730
		IntoGrabMaxAngle = 90.0f;
	}
}
}
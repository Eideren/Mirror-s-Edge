namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DmgType_Fell : DamageType/*
		abstract*/{
	public DmgType_Fell()
	{
		// Object Offset:0x0030ED2B
		DeathString = "`k pushed `o over the edge.";
		FemaleSuicide = "`o left a small crater";
		MaleSuicide = "`o left a small crater";
		bLocationalHit = false;
		bCausedByWorld = true;
		GibModifier = 2.0f;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class KillZDamageType : DamageType/*
		abstract
		native*/{
	public KillZDamageType()
	{
		// Object Offset:0x0030EE8C
		bCausedByWorld = true;
	}
}
}
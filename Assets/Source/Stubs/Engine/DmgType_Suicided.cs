namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DmgType_Suicided : KillZDamageType/*
		abstract*/{
	public DmgType_Suicided()
	{
		// Object Offset:0x0030EF17
		DeathString = "`o had an aneurysm.";
		FemaleSuicide = "`o had an aneurysm.";
		MaleSuicide = "`o had an aneurysm.";
		bArmorStops = false;
		bLocationalHit = false;
	}
}
}
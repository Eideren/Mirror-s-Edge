namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_Flashbang : TdDamageType{
	public float StunDamage;
	
	public TdDmgType_Flashbang()
	{
		// Object Offset:0x005428E5
		StunDamage = 0.50f;
		bCausePhysicalHitReaction = false;
	}
}
}
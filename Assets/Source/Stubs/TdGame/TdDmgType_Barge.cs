namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_Barge : TdDmgType_Melee{
	public TdDmgType_Barge()
	{
		// Object Offset:0x005425A9
		KDamageImpulse = 1000.0f;
		KImpulseRadius = 250.0f;
	}
}
}
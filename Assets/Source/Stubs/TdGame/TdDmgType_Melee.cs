namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_Melee : TdDamageType{
	public TdDmgType_Melee()
	{
		// Object Offset:0x00542502
		bCausePhysicalHitReaction = false;
		bCausesFracture = true;
	}
}
}
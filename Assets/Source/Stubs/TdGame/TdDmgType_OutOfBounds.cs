namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDmgType_OutOfBounds : DamageType{
	public TdDmgType_OutOfBounds()
	{
		// Object Offset:0x00542FD6
		bArmorStops = false;
		bCausedByWorld = true;
	}
}
}
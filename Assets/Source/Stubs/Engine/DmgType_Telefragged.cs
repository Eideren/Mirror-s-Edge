namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DmgType_Telefragged : DamageType{
	public DmgType_Telefragged()
	{
		// Object Offset:0x0030F04E
		DeathString = "`o was telefragged by `k";
		FemaleSuicide = "`o was telefragged by `k";
		MaleSuicide = "`o was telefragged by `k";
		bArmorStops = false;
		bAlwaysGibs = true;
		bLocationalHit = false;
	}
}
}
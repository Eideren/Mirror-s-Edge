namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GeomModifier_Flip : GeomModifier_Edit/*
		native
		hidecategories(Object,GeomModifier)*/{
	public GeomModifier_Flip()
	{
		// Object Offset:0x0001220E
		Description = "Flip";
		bPushButton = true;
	}
}
}
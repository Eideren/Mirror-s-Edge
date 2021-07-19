namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GeomModifier_Clip : GeomModifier_Edit/*
		native
		hidecategories(Object,GeomModifier)*/{
	[Category("Settings")] public bool bFlipNormal;
	[Category("Settings")] public bool bSplit;
	
	public GeomModifier_Clip()
	{
		// Object Offset:0x00011EBF
		Description = "Clip";
	}
}
}
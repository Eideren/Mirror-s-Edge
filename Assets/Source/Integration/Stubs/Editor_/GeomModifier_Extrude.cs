namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GeomModifier_Extrude : GeomModifier_Edit/*
		native
		hidecategories(Object,GeomModifier)*/{
	[Category("Settings")] public int Length;
	[Category("Settings")] public int Segments;
	
	public GeomModifier_Extrude()
	{
		// Object Offset:0x00012133
		Length = 16;
		Segments = 1;
		Description = "Extrude";
	}
}
}
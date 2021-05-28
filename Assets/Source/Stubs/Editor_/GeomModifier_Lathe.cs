namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GeomModifier_Lathe : GeomModifier_Edit/*
		native
		hidecategories(Object,GeomModifier)*/{
	public/*(Settings)*/ int TotalSegments;
	public/*(Settings)*/ int Segments;
	public/*(Settings)*/ Object.EAxis Axis;
	
	public GeomModifier_Lathe()
	{
		// Object Offset:0x00012352
		TotalSegments = 16;
		Segments = 4;
		Axis = Object.EAxis.AXIS_Z;
		Description = "Lathe";
	}
}
}
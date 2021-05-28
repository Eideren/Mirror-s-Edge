namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EdCoordSystem : Object/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public/*()*/ Object.Matrix M;
	public/*()*/ string Desc;
	
	public EdCoordSystem()
	{
		// Object Offset:0x0031372C
		M = new Matrix
		{
			XPlane={X=0.0f,
			Y=1.0f,
			Z=0.0f,
			W=0.0f},
			YPlane={X=0.0f,
			Y=0.0f,
			Z=1.0f,
			W=0.0f},
			ZPlane={X=0.0f,
			Y=0.0f,
			Z=0.0f,
			W=1.0f},
			WPlane={X=1.0f,
			Y=0.0f,
			Z=0.0f,
			W=0.0f}
		};
		Desc = "Coord System";
	}
}
}
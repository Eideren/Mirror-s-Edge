namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdCameraFOV : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ float NewFOV;
	public /*transient */TdPlayerPawn PlayerPawn;
	
	public SeqAct_TdCameraFOV()
	{
		// Object Offset:0x00496DAB
		NewFOV = 70.0f;
		ObjName = "Camera FOV";
		ObjCategory = "Takedown";
	}
}
}
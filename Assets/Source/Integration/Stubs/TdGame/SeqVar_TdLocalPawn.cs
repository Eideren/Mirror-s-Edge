namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_TdLocalPawn : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	public override /*function */Object GetObjectValue()
	{
		// stub
		return default;
	}
	
	public SeqVar_TdLocalPawn()
	{
		// Object Offset:0x004A96D3
		ObjName = "Local Pawn";
		ObjCategory = "Takedown";
	}
}
}
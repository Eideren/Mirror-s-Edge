namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdPlaySoundOnRandomAI : SeqAct_TdPlaySound/*
		native
		hidecategories(Object)*/{
	[Category] public float MaxDistanceToPlayer;
	[Category] public float MinDistanceToPlayer;
	
	public SeqAct_TdPlaySoundOnRandomAI()
	{
		// Object Offset:0x0049E74B
		MaxDistanceToPlayer = 5000.0f;
		ObjName = "Td Play Sound on Random AI";
	}
}
}
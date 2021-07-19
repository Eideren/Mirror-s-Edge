namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqVar_AITeam : SeqVar_Object/*
		native
		hidecategories(Object)*/{
	[Category] [editinline] public String TeamName;
	[transient] public AITeam Team;
	[Category] public AITeam.ESide Side;
	
	public SeqVar_AITeam()
	{
		// Object Offset:0x004A937A
		TeamName = "Unnamed Team";
		ObjName = "Team";
		ObjCategory = "AI";
		ObjColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
	}
}
}
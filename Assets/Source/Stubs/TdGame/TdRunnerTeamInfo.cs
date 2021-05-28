namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdRunnerTeamInfo : TdTeamInfo/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdRunnerTeamInfo()
	{
		// Object Offset:0x00654FC3
		TeamColor = new Color
		{
			R=210,
			G=0,
			B=0,
			A=255
		};
	}
}
}
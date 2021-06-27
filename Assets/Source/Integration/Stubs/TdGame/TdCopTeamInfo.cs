namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCopTeamInfo : TdTeamInfo/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdCopTeamInfo()
	{
		// Object Offset:0x00538D72
		TeamColor = new Color
		{
			R=0,
			G=100,
			B=210,
			A=255
		};
	}
}
}
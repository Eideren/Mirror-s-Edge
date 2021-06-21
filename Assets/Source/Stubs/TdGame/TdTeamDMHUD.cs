namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTeamDMHUD : TdMPHUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public/*(HUDIcons)*/ Object.Vector2D RunnerScore;
	public/*(HUDIcons)*/ Object.Vector2D CopScore;
	
	public override /*function */void DrawScore()
	{
		// stub
	}
	
	public TdTeamDMHUD()
	{
		// Object Offset:0x00674697
		RunnerScore = new Vector2D
		{
			X=-80.0f,
			Y=0.0f
		};
		CopScore = new Vector2D
		{
			X=40.0f,
			Y=0.0f
		};
		ScorePos = new Vector2D
		{
			X=640.0f,
			Y=35.0f
		};
	}
}
}
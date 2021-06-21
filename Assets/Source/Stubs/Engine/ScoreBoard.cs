namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ScoreBoard : HUD/*
		transient
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public bool bDisplayMessages;
	
	public override /*function */void DrawHUD()
	{
		// stub
	}
	
	public virtual /*function */bool UpdateGRI()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UpdateScoreBoard()
	{
		// stub
	}
	
	public virtual /*function */void ChangeState(bool bIsVisible)
	{
		// stub
	}
	
}
}
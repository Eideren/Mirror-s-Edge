namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Stumble_Boss : TdMove_StumbleBot/*
		config(PawnMovement)*/{
	public enum EStumbleStageBoss 
	{
		SSBoss_Normal,
		SSBoss_One,
		SSBoss_Two,
		SSBoss_Recover,
		SSBoss_MAX
	};
	
	public TdMove_Stumble_Boss.EStumbleStageBoss StumbleStage;
	
}
}
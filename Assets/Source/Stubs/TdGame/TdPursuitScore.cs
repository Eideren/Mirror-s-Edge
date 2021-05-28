namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitScore : Object/*
		config(Scoring)*/{
	public /*config */int Kill;
	public /*config */int Suicide;
	public /*config */int Intercept;
	public /*config */int Stash;
	public /*config */int StashAssist;
	public /*config */int Search;
	public /*config */int SearchAssist;
	public /*config */int TeamStashFirstAttempt;
	public /*config */int TeamStashSecondAttempt;
	public /*config */int TeamStashThirdAttempt;
	public /*config */int TeamHasBagAtEndOfRound;
	public /*config */int TeamSearch;
	
	public TdPursuitScore()
	{
		// Object Offset:0x00653A15
		Kill = 1;
		Suicide = -1;
		Intercept = 1;
		Stash = 3;
		StashAssist = 1;
		Search = 3;
		SearchAssist = 1;
		TeamStashFirstAttempt = 4;
		TeamStashSecondAttempt = 3;
		TeamStashThirdAttempt = 2;
		TeamHasBagAtEndOfRound = 1;
		TeamSearch = 2;
	}
}
}
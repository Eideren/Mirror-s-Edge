namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitScore : Object/*
		config(Scoring)*/{
	[config] public int Kill;
	[config] public int Suicide;
	[config] public int Intercept;
	[config] public int Stash;
	[config] public int StashAssist;
	[config] public int Search;
	[config] public int SearchAssist;
	[config] public int TeamStashFirstAttempt;
	[config] public int TeamStashSecondAttempt;
	[config] public int TeamStashThirdAttempt;
	[config] public int TeamHasBagAtEndOfRound;
	[config] public int TeamSearch;
	
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
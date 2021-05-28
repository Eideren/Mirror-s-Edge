namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PathGoalEvaluator : Object/*
		native*/{
	public /*const */PathGoalEvaluator NextEvaluator;
	public /*const */NavigationPoint GeneratedGoal;
	public /*const */int MaxPathVisits;
	
	public PathGoalEvaluator()
	{
		// Object Offset:0x0033D351
		MaxPathVisits = 768;
	}
}
}
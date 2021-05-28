namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Goal_AtActor : PathGoalEvaluator/*
		native*/{
	public Actor GoalActor;
	public float GoalDist;
	public bool bKeepPartial;
	
	public /*function */static bool AtActor(Pawn P, Actor Goal, /*optional */float Dist = default, /*optional */bool bReturnPartial = default)
	{
	
		return default;
	}
	
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Path_TowardGoal : PathConstraint/*
		native*/{
	public Actor GoalActor;
	
	public /*function */static bool TowardGoal(Pawn P, Actor Goal)
	{
		// stub
		return default;
	}
	
}
}
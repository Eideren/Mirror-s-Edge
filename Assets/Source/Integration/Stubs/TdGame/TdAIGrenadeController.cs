namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIGrenadeController : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public enum EGrenadeThrowType 
	{
		EGTT_DropAtFeet,
		EGTT_ThrowAtTarget,
		EGTT_ThrowAtTargetWhileRunning,
		EGTT_ThrowInTargetsWay,
		EGTT_MAX
	};
	
	public/*private*/ name ThrowAnimationName;
	public/*private*/ TdBotPawn MyBotPawn;
	public/*private*/ bool bAnimationStarted;
	public/*private*/ bool bDoFreeGrenadeThrow;
	public/*private*/ bool bDone;
	public/*private*/ TdGrenadeTargetArea GrenadeTargetArea;
	public/*private*/ NavigationPoint GrenadeNode;
	public/*private*/ TdProj_Grenade Grenade;
	public/*private*/ Actor TargetActor;
	public/*private*/ TdAIGrenadeController.EGrenadeThrowType ThrowType;
	public/*private*/ Core.ClassT<TdProj_Grenade> GrenadeClass;
	
	public virtual /*function */TdProj_Grenade GetGrenade()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdGrenadeTargetArea GetTargetArea()
	{
		// stub
		return default;
	}
	
	public virtual /*function */NavigationPoint GetGrenadeNode()
	{
		// stub
		return default;
	}
	
	public virtual /*function */name GetThrowAnimationName()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void ThrowInstantGrenade(TdGrenadeTargetArea TargetArea, Object.Vector FromPosition)
	{
		// stub
	}
	
	public virtual /*function */void InitGrenadeThrowToGrenadeTargetArea(TdBotPawn BotPawn, NavigationPoint GrenadeNodeIn, TdGrenadeTargetArea GrenadeTargetAreaIn)
	{
		// stub
	}
	
	public virtual /*function */void InitGrenadeThrow(TdBotPawn BotPawn, Actor inTargetActor, /*optional */TdAIGrenadeController.EGrenadeThrowType? _Drop = default, /*optional */Core.ClassT<TdProj_Grenade> _inGrenadeClass = default)
	{
		// stub
	}
	
	public virtual /*event */bool ThrowGrenadeTick()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void GrenadeAnimationOnCustomAnimEnd(AnimNodeSequence SequenceNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public virtual /*event */void AnimNotifyGrenadeThrow()
	{
		// stub
	}
	
	public virtual /*private final function */void SetThrowGrenadeInFrontValues(Object.Vector Target, Object.Vector SpawnLoc)
	{
		// stub
	}
	
	public virtual /*private final function */void SetLowThrowGrenadeValues(Object.Vector Target, Object.Vector SpawnLoc)
	{
		// stub
	}
	
	public virtual /*private final function */void SetNormalThrowGrenadeValues(Object.Vector Target, Object.Vector SpawnLoc)
	{
		// stub
	}
	
	public virtual /*private final function */void SetGrenadeDropValues(Object.Vector SpawnLoc)
	{
		// stub
	}
	
	public virtual /*private final function */void SetTrowAtTargetValues(Object.Vector Target, Object.Vector SpawnLoc)
	{
		// stub
	}
	
	public virtual /*private final function */bool SolveParabolaLineProblem(Object.Vector Target, Object.Vector TargetSpeed, Object.Vector FromPos, float Gravity, float WantedSpeedInXYPlane, ref Object.Vector ResultVelocity)
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool SecondDegreeSolver(float A, float bx, float cx2, ref float s0, ref float s1)
	{
		// stub
		return default;
	}
	
}
}
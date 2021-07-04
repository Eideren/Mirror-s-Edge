namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAimBotSniper : TdAimBotBase/* within TdAI_Sniper*//*
		native*/{
	public enum ESniperAimbotState 
	{
		ESABS_AimingAtTarget,
		ESABS_AimingAtBlindPos,
		ESABS_AimingOnTheWayToTarget,
		ESABS_MAX
	};
	
	public new TdAI_Sniper Outer => base.Outer as TdAI_Sniper;
	
	public TdAimBotSniper.ESniperAimbotState AimbotState;
	public Object.Rotator CurrentRot;
	public float CalibrateTime;
	public float RandomWalkPosition;
	public float RandomWalkTarget;
	public float EnemyInvisibleTime;
	public Object.Vector CurrentAimPoint;
	public Object.Vector BlindPosBase;
	public Object.Vector BlindPosAdjustment;
	public Object.Vector BlindPos;
	public float DistanceToLaserPoint;
	public float HeadShotAdjustment;
	public bool bPullTrigger;
	public float CheckPullTriggerTime;
	
	public virtual /*function */void NotifyWeaponFired(Weapon W, byte FireMode)
	{
		// stub
	}
	
	// Export UTdAimBotSniper::execTick(FFrame&, void* const)
	public override /*native function */void Tick(float DeltaTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAimBotSniper::execResetAiming(FFrame&, void* const)
	public virtual /*native function */void ResetAiming()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdAimBotSniper::execGetTargetPos(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetTargetPos(TdPlayerPawn Target)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAimBotSniper::execUpdateBlindPos(FFrame&, void* const)
	public virtual /*native function */void UpdateBlindPos(float DeltaTime)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */Object.Rotator GetRotation(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
	public override /*function */void Render(TdPlayerPawn Target)
	{
		// stub
	}
	
	public override /*function */Object.Vector GetAimLocation(TdPlayerPawn Target, /*optional */bool? _bUseFullDispersion = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AllowFire(TdPlayerPawn Target)
	{
		// stub
		return default;
	}
	
}
}
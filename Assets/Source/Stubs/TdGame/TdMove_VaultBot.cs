namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_VaultBot : TdMove_AISpecialMove/*
		native
		config(PawnMovement)*/{
	public bool bVaultOnto;
	public bool bHighVault;
	public Object.Vector StartLocation;
	public Object.Vector EndLocation;
	public Object.Vector HandLocation;
	
	// Export UTdMove_VaultBot::execGetPreciseLocation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetPreciseLocation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdMove_VaultBot::execGetPreciseRotation(FFrame&, void* const)
	public virtual /*native final function */Object.Rotator GetPreciseRotation()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */bool CanDoMove()
	{
	
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
	
	}
	
	public override /*simulated event */void StopMove()
	{
	
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
	
	}
	
	public virtual /*function */name GetAnimationName()
	{
	
		return default;
	}
	
	public virtual /*function */void SetRootMotionScale()
	{
	
	}
	
	public virtual /*function */void EnableHeadAim()
	{
	
	}
	
	public virtual /*function */void OnLandedTimer()
	{
	
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
	
	}
	
	public TdMove_VaultBot()
	{
		// Object Offset:0x005DFA7A
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
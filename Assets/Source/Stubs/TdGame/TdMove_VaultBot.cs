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
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	// Export UTdMove_VaultBot::execGetPreciseRotation(FFrame&, void* const)
	public virtual /*native final function */Object.Rotator GetPreciseRotation()
	{
		 // #warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public override /*simulated function */bool CanDoMove()
	{
		// stub
		return default;
	}
	
	public override /*simulated function */void StartMove()
	{
		// stub
	}
	
	public override /*simulated event */void StopMove()
	{
		// stub
	}
	
	public override /*simulated event */void ReachedPreciseLocation()
	{
		// stub
	}
	
	public virtual /*function */name GetAnimationName()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetRootMotionScale()
	{
		// stub
	}
	
	public virtual /*function */void EnableHeadAim()
	{
		// stub
	}
	
	public virtual /*function */void OnLandedTimer()
	{
		// stub
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		// stub
	}
	
	public TdMove_VaultBot()
	{
		// Object Offset:0x005DFA7A
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
	}
}
}
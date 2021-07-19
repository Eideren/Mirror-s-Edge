namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIAddOnObject : Object/*
		abstract
		native
		config(LOI)*/{
	[native, Const, noexport] public/*private*/ Object.Pointer VfTable_FTickableObject;
	[transient] public/*protected*/ PlayerController PlayerRef;
	[transient] public/*protected*/ float LookAtDelay;
	[transient] public/*protected*/ float ProximityDelay;
	[transient] public/*protected*/ float DistanceSquared;
	[transient] public/*protected*/ bool bUse2DDistance;
	public/*private*/ bool bIsKismetActivated;
	[transient] public/*private*/ bool bIsActivated;
	[transient] public Object.Vector CachedLocation;
	public/*protected*/ Object.Vector CachedDirection;
	public/*protected*/ float ActivationAngle;
	[transient] public array<MaterialInstanceConstant> LOIMaterialInstances;
	[transient] public/*private*/ float LOILevel;
	[transient] public/*private*/ float ActualLOILevel;
	[transient] public/*private*/ float LOILevelTimer;
	[transient] public/*protected*/ float LookAtTimer;
	[transient] public/*protected*/ float ProximityTimer;
	[config] public/*protected*/ float FadeInSpeed;
	[config] public/*protected*/ float FadeOutSpeed;
	public/*protected*/ float MinDuration;
	
	// Export UTdLOIAddOnObject::execRegisterLOIGroups(FFrame&, void* const)
	public virtual /*native function */void RegisterLOIGroups(array<name> LOIGroups)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UTdLOIAddOnObject::execActivateLOIGroups(FFrame&, void* const)
	public virtual /*native function */void ActivateLOIGroups(array<name> LOIGroups)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public virtual /*function */void InitLOIMtrlInstances()
	{
		// stub
	}
	
	public virtual /*event */void ActivateLOI()
	{
		// stub
	}
	
	public virtual /*function */void OnActivateLOI(SeqAct_ActivateLOI Sender)
	{
		// stub
	}
	
	public virtual /*function */void OnDeactivateLOI(SeqAct_DeactivateLOI Sender)
	{
		// stub
	}
	
	public virtual /*function */void InitLOI(Actor Player)
	{
		// stub
	}
	
	public virtual /*function */void LookAtActivationAttempt()
	{
		// stub
	}
	
	public virtual /*event */void ActivateThisLOIObject()
	{
		// stub
	}
	
	public TdLOIAddOnObject()
	{
		// Object Offset:0x003F7DD4
		FadeInSpeed = 1.0f;
		FadeOutSpeed = 4.0f;
		MinDuration = 0.50f;
	}
}
}
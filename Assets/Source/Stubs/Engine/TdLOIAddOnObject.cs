namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIAddOnObject : Object/*
		abstract
		native
		config(LOI)*/{
	public /*private native const noexport */Object.Pointer VfTable_FTickableObject;
	public /*protected transient */PlayerController PlayerRef;
	public /*protected transient */float LookAtDelay;
	public /*protected transient */float ProximityDelay;
	public /*protected transient */float DistanceSquared;
	public /*protected transient */bool bUse2DDistance;
	public /*private */bool bIsKismetActivated;
	public /*private transient */bool bIsActivated;
	public /*transient */Object.Vector CachedLocation;
	public /*protected */Object.Vector CachedDirection;
	public /*protected */float ActivationAngle;
	public /*transient */array<MaterialInstanceConstant> LOIMaterialInstances;
	public /*private transient */float LOILevel;
	public /*private transient */float ActualLOILevel;
	public /*private transient */float LOILevelTimer;
	public /*protected transient */float LookAtTimer;
	public /*protected transient */float ProximityTimer;
	public /*protected config */float FadeInSpeed;
	public /*protected config */float FadeOutSpeed;
	public /*protected */float MinDuration;
	
	// Export UTdLOIAddOnObject::execRegisterLOIGroups(FFrame&, void* const)
	public virtual /*native function */void RegisterLOIGroups(array<name> LOIGroups)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UTdLOIAddOnObject::execActivateLOIGroups(FFrame&, void* const)
	public virtual /*native function */void ActivateLOIGroups(array<name> LOIGroups)
	{
		#warning NATIVE FUNCTION !
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
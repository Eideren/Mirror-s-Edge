namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorComponent : Component/*
		abstract
		native
		noexport*/{
	public /*native const transient */Object.Pointer Scene;
	public /*const transient */Actor Owner;
	public /*native const transient */bool bAttached;
	public /*const */bool bTickInEditor;
	public /*const transient */bool bNeedsReattach;
	public /*const transient */bool bNeedsUpdateTransform;
	public /*const */Object.ETickingGroup TickGroup;
	
	// Export UActorComponent::execSetTickGroup(FFrame&, void* const)
	public virtual /*native final function */void SetTickGroup(Object.ETickingGroup NewTickGroup)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UActorComponent::execSetComponentRBFixed(FFrame&, void* const)
	public virtual /*native final function */void SetComponentRBFixed(bool bFixed)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export UActorComponent::execForceUpdate(FFrame&, void* const)
	public virtual /*native final function */void ForceUpdate(bool bTransformOnly)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public ActorComponent()
	{
		// Object Offset:0x00259519
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
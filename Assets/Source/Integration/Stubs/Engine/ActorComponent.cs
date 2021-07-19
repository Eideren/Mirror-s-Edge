namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ActorComponent : Component/*
		abstract
		native
		noexport*/{
	[native, Const, transient] public Object.Pointer Scene;
	[Const, transient] public Actor Owner;
	[native, Const, transient] public bool bAttached;
	[Const] public bool bTickInEditor;
	[Const, transient] public bool bNeedsReattach;
	[Const, transient] public bool bNeedsUpdateTransform;
	[Const] public Object.ETickingGroup TickGroup;
	
	// Export UActorComponent::execSetTickGroup(FFrame&, void* const)
	public virtual /*native final function */void SetTickGroup(Object.ETickingGroup NewTickGroup)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UActorComponent::execSetComponentRBFixed(FFrame&, void* const)
	public virtual /*native final function */void SetComponentRBFixed(bool bFixed)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export UActorComponent::execForceUpdate(FFrame&, void* const)
	public virtual /*native final function */void ForceUpdate(bool bTransformOnly)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public ActorComponent()
	{
		// Object Offset:0x00259519
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LightEnvironmentComponent : ActorComponent/*
		native*/{
	[Category] [Const] public bool bEnabled;
	[Const, transient] public float LastRenderTime;
	
	// Export ULightEnvironmentComponent::execSetEnabled(FFrame&, void* const)
	public virtual /*native final function */void SetEnabled(bool bNewEnabled)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public LightEnvironmentComponent()
	{
		// Object Offset:0x002ED150
		bEnabled = true;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_RadialImpulseComponent : PrimitiveComponent/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ PrimitiveComponent.ERadialImpulseFalloff ImpulseFalloff;
	public/*()*/ float ImpulseStrength;
	public/*()*/ float ImpulseRadius;
	public/*()*/ bool bVelChange;
	public /*export editinline */DrawSphereComponent PreviewSphere;
	
	// Export URB_RadialImpulseComponent::execFireImpulse(FFrame&, void* const)
	public virtual /*native function */void FireImpulse(Object.Vector Origin)
	{
		#warning NATIVE FUNCTION !
		// stub
	}
	
	public RB_RadialImpulseComponent()
	{
		// Object Offset:0x003AF34D
		ImpulseStrength = 900.0f;
		ImpulseRadius = 200.0f;
		TickGroup = Object.ETickingGroup.TG_PreAsyncWork;
	}
}
}
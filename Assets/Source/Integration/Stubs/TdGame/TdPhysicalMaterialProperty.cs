namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialProperty : PhysicalMaterialPropertyBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category("Footsteps")] [editinline] public TdPhysicalMaterialFootSteps TdPhysicalMaterialFootSteps;
	[Category("ImpactEffects")] [editinline] public TdPhysicalMaterialImpactEffects TdPhysicalMaterialImpactEffects;
	[Category("ImpactSounds")] [editinline] public TdPhysicalMaterialImpactSounds TdPhysicalMaterialImpactSounds;
	[Category("Decals")] [editinline] public TdPhysicalMaterialDecals TdPhysicalMaterialDecals;
	[Category("MeleeEffects")] [editinline] public TdPhysicalMaterialMelee TdPhysicalMaterialMelee;
	[Category] public bool bEnableSoftLanding;
	[Category] public bool bPreventSliding;
	[Category] public bool bEnableUncontrolledSlide;
	[Category] public bool bShouldAirBarge;
	
	// Export UTdPhysicalMaterialProperty::execGetParticleImpactSound(FFrame&, void* const)
	public virtual /*native final simulated function */SoundCue GetParticleImpactSound(TdParticleModuleCollision.ECollisionParticleType Type)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}
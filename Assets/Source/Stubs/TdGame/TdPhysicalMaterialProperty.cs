namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialProperty : PhysicalMaterialPropertyBase/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*(Footsteps)*/ /*editinline */TdPhysicalMaterialFootSteps TdPhysicalMaterialFootSteps;
	public/*(ImpactEffects)*/ /*editinline */TdPhysicalMaterialImpactEffects TdPhysicalMaterialImpactEffects;
	public/*(ImpactSounds)*/ /*editinline */TdPhysicalMaterialImpactSounds TdPhysicalMaterialImpactSounds;
	public/*(Decals)*/ /*editinline */TdPhysicalMaterialDecals TdPhysicalMaterialDecals;
	public/*(MeleeEffects)*/ /*editinline */TdPhysicalMaterialMelee TdPhysicalMaterialMelee;
	public/*()*/ bool bEnableSoftLanding;
	public/*()*/ bool bPreventSliding;
	public/*()*/ bool bEnableUncontrolledSlide;
	public/*()*/ bool bShouldAirBarge;
	
	// Export UTdPhysicalMaterialProperty::execGetParticleImpactSound(FFrame&, void* const)
	public virtual /*native final simulated function */SoundCue GetParticleImpactSound(TdParticleModuleCollision.ECollisionParticleType Type)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}
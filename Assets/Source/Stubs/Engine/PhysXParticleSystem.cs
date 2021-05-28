namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysXParticleSystem : Object/*
		native
		hidecategories(Object)*/{
	public enum ESimulationMethod 
	{
		ESM_SPH,
		ESM_NO_PARTICLE_INTERACTION,
		ESM_MIXED_MODE,
		ESM_MAX
	};
	
	public enum EPacketSizeMultiplier 
	{
		EPSM_4,
		EPSM_8,
		EPSM_16,
		EPSM_32,
		EPSM_64,
		EPSM_128,
		EPSM_MAX
	};
	
	public/*(Buffer)*/ int MaxParticles;
	public/*(Collision)*/ float CollisionDistance;
	public/*(Collision)*/ float RestitutionWithStaticShapes;
	public/*(Collision)*/ float RestitutionWithDynamicShapes;
	public/*(Collision)*/ float FrictionWithStaticShapes;
	public/*(Collision)*/ float FrictionWithDynamicShapes;
	public/*(Collision)*/ bool bDynamicCollision;
	public/*(Dynamics)*/ bool bDisableGravity;
	public/*(SdkExpert)*/ bool bStaticCollision;
	public/*(SdkExpert)*/ bool bTwoWayCollision;
	public /*transient */bool bDestroy;
	public /*transient */bool bSyncFailed;
	public /*transient */bool bIsInGame;
	public/*(Dynamics)*/ float MaxMotionDistance;
	public/*(Dynamics)*/ float Damping;
	public/*(Dynamics)*/ Object.Vector ExternalAcceleration;
	public/*(SdkExpert)*/ PhysXParticleSystem.ESimulationMethod SimulationMethod;
	public/*(SdkExpert)*/ PhysXParticleSystem.EPacketSizeMultiplier PacketSizeMultiplier;
	public/*(SdkExpert)*/ float RestParticleDistance;
	public/*(SdkExpert)*/ float RestDensity;
	public/*(SdkExpert)*/ float KernelRadiusMultiplier;
	public/*(SdkExpert)*/ float Stiffness;
	public/*(SdkExpert)*/ float Viscosity;
	public/*(SdkExpert)*/ float CollisionResponseCoefficient;
	public/*(SdkExpert)*/ int ParticleReserve;
	public /*native */Object.Pointer CascadeScene;
	public /*native */Object.Pointer PSys;
	
	public PhysXParticleSystem()
	{
		// Object Offset:0x0039CA81
		MaxParticles = 32767;
		CollisionDistance = 10.0f;
		RestitutionWithStaticShapes = 0.50f;
		RestitutionWithDynamicShapes = 0.50f;
		FrictionWithStaticShapes = 0.050f;
		FrictionWithDynamicShapes = 0.50f;
		bDynamicCollision = true;
		bStaticCollision = true;
		MaxMotionDistance = 64.0f;
		SimulationMethod = PhysXParticleSystem.ESimulationMethod.ESM_NO_PARTICLE_INTERACTION;
		PacketSizeMultiplier = PhysXParticleSystem.EPacketSizeMultiplier.EPSM_16;
		RestParticleDistance = 64.0f;
		RestDensity = 1000.0f;
		KernelRadiusMultiplier = 2.0f;
		Stiffness = 20.0f;
		Viscosity = 6.0f;
		CollisionResponseCoefficient = 0.20f;
	}
}
}
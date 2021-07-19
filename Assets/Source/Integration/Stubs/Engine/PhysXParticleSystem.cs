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
	
	[Category("Buffer")] public int MaxParticles;
	[Category("Collision")] public float CollisionDistance;
	[Category("Collision")] public float RestitutionWithStaticShapes;
	[Category("Collision")] public float RestitutionWithDynamicShapes;
	[Category("Collision")] public float FrictionWithStaticShapes;
	[Category("Collision")] public float FrictionWithDynamicShapes;
	[Category("Collision")] public bool bDynamicCollision;
	[Category("Dynamics")] public bool bDisableGravity;
	[Category("SdkExpert")] public bool bStaticCollision;
	[Category("SdkExpert")] public bool bTwoWayCollision;
	[transient] public bool bDestroy;
	[transient] public bool bSyncFailed;
	[transient] public bool bIsInGame;
	[Category("Dynamics")] public float MaxMotionDistance;
	[Category("Dynamics")] public float Damping;
	[Category("Dynamics")] public Object.Vector ExternalAcceleration;
	[Category("SdkExpert")] public PhysXParticleSystem.ESimulationMethod SimulationMethod;
	[Category("SdkExpert")] public PhysXParticleSystem.EPacketSizeMultiplier PacketSizeMultiplier;
	[Category("SdkExpert")] public float RestParticleDistance;
	[Category("SdkExpert")] public float RestDensity;
	[Category("SdkExpert")] public float KernelRadiusMultiplier;
	[Category("SdkExpert")] public float Stiffness;
	[Category("SdkExpert")] public float Viscosity;
	[Category("SdkExpert")] public float CollisionResponseCoefficient;
	[Category("SdkExpert")] public int ParticleReserve;
	[native] public Object.Pointer CascadeScene;
	[native] public Object.Pointer PSys;
	
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
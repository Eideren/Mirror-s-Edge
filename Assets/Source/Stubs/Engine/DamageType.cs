namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DamageType : Object/*
		abstract
		native*/{
	public/*()*/ /*const localized */String DeathString;
	public/*()*/ /*const localized */String FemaleSuicide;
	public/*()*/ /*const localized */String MaleSuicide;
	public/*()*/ bool bArmorStops;
	public/*()*/ bool bAlwaysGibs;
	public/*()*/ bool bNeverGibs;
	public/*()*/ bool bLocationalHit;
	public/*()*/ bool bCausesBlood;
	public/*()*/ bool bCausesBloodSplatterDecals;
	public/*()*/ bool bKUseOwnDeathVel;
	public bool bCausedByWorld;
	public bool bExtraMomentumZ;
	public/*()*/ bool bCausesFracture;
	public bool bIgnoreDriverDamageMult;
	public bool bDontHurtInstigator;
	public/*(RigidBody)*/ bool bKRadialImpulse;
	public/*(RigidBody)*/ bool bRadialDamageVelChange;
	public/*()*/ float GibModifier;
	public/*(RigidBody)*/ float KDamageImpulse;
	public/*(RigidBody)*/ float KDeathVel;
	public/*(RigidBody)*/ float KDeathUpKick;
	public/*(RigidBody)*/ float KImpulseRadius;
	public/*(RigidBody)*/ float RadialDamageImpulse;
	public float VehicleDamageScaling;
	public float VehicleMomentumScaling;
	public ForceFeedbackWaveform DamagedFFWaveform;
	public ForceFeedbackWaveform KilledFFWaveform;
	
	public /*function */static String DeathMessage(PlayerReplicationInfo Killer, PlayerReplicationInfo Victim)
	{
	
		return default;
	}
	
	public /*function */static String SuicideMessage(PlayerReplicationInfo Victim)
	{
	
		return default;
	}
	
	public /*function */static float VehicleDamageScalingFor(Vehicle V)
	{
	
		return default;
	}
	
	public DamageType()
	{
		// Object Offset:0x002F8864
		DeathString = "`o was killed by `k.";
		FemaleSuicide = "`o killed herself.";
		MaleSuicide = "`o killed himself.";
		bArmorStops = true;
		bLocationalHit = true;
		bCausesBlood = true;
		bExtraMomentumZ = true;
		GibModifier = 1.0f;
		KDamageImpulse = 800.0f;
		KImpulseRadius = 250.0f;
		VehicleDamageScaling = 1.0f;
		VehicleMomentumScaling = 1.0f;
	}
}
}
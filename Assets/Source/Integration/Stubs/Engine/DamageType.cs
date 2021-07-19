namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DamageType : Object/*
		abstract
		native*/{
	[Category] [Const, localized] public String DeathString;
	[Category] [Const, localized] public String FemaleSuicide;
	[Category] [Const, localized] public String MaleSuicide;
	[Category] public bool bArmorStops;
	[Category] public bool bAlwaysGibs;
	[Category] public bool bNeverGibs;
	[Category] public bool bLocationalHit;
	[Category] public bool bCausesBlood;
	[Category] public bool bCausesBloodSplatterDecals;
	[Category] public bool bKUseOwnDeathVel;
	public bool bCausedByWorld;
	public bool bExtraMomentumZ;
	[Category] public bool bCausesFracture;
	public bool bIgnoreDriverDamageMult;
	public bool bDontHurtInstigator;
	[Category("RigidBody")] public bool bKRadialImpulse;
	[Category("RigidBody")] public bool bRadialDamageVelChange;
	[Category] public float GibModifier;
	[Category("RigidBody")] public float KDamageImpulse;
	[Category("RigidBody")] public float KDeathVel;
	[Category("RigidBody")] public float KDeathUpKick;
	[Category("RigidBody")] public float KImpulseRadius;
	[Category("RigidBody")] public float RadialDamageImpulse;
	public float VehicleDamageScaling;
	public float VehicleMomentumScaling;
	public ForceFeedbackWaveform DamagedFFWaveform;
	public ForceFeedbackWaveform KilledFFWaveform;
	
	public /*function */static String DeathMessage(PlayerReplicationInfo Killer, PlayerReplicationInfo Victim)
	{
		// stub
		return default;
	}
	
	public /*function */static String SuicideMessage(PlayerReplicationInfo Victim)
	{
		// stub
		return default;
	}
	
	public /*function */static float VehicleDamageScalingFor(Vehicle V)
	{
		// stub
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
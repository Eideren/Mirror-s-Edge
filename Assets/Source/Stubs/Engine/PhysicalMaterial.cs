namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicalMaterial : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	public /*transient */int MaterialIndex;
	public/*()*/ float Friction;
	public/*()*/ float Restitution;
	public/*()*/ bool bForceConeFriction;
	public/*(Advanced)*/ bool bEnableAnisotropicFriction;
	public/*(Advanced)*/ Object.Vector AnisoFrictionDir;
	public/*(Advanced)*/ float FrictionV;
	public/*()*/ float Density;
	public/*()*/ float AngularDamping;
	public/*()*/ float LinearDamping;
	public/*()*/ float MagneticResponse;
	public/*()*/ float WindResponse;
	public/*(Impact)*/ float ImpactThreshold;
	public/*(Impact)*/ float ImpactReFireDelay;
	public/*(Impact)*/ ParticleSystem ImpactEffect;
	public/*(Impact)*/ SoundCue ImpactSound;
	public/*(Slide)*/ float SlideThreshold;
	public/*(Slide)*/ float SlideReFireDelay;
	public/*(Slide)*/ ParticleSystem SlideEffect;
	public/*(Slide)*/ SoundCue SlideSound;
	public/*(Parent)*/ PhysicalMaterial Parent;
	public/*(PhysicalProperties)*/ /*export editinline */PhysicalMaterialPropertyBase PhysicalMaterialProperty;
	
	public virtual /*function */PhysicalMaterialPropertyBase GetPhysicalMaterialProperty(Core.ClassT<PhysicalMaterialPropertyBase> DesiredClass)
	{
	
		return default;
	}
	
	public PhysicalMaterial()
	{
		// Object Offset:0x0039B0B6
		Friction = 0.70f;
		Restitution = 0.30f;
		Density = 1.0f;
		LinearDamping = 0.010f;
	}
}
}
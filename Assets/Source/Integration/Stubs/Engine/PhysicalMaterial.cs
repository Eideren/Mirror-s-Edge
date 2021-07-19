namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicalMaterial : Object/*
		native
		collapsecategories
		hidecategories(Object)*/{
	[transient] public int MaterialIndex;
	[Category] public float Friction;
	[Category] public float Restitution;
	[Category] public bool bForceConeFriction;
	[Category("Advanced")] public bool bEnableAnisotropicFriction;
	[Category("Advanced")] public Object.Vector AnisoFrictionDir;
	[Category("Advanced")] public float FrictionV;
	[Category] public float Density;
	[Category] public float AngularDamping;
	[Category] public float LinearDamping;
	[Category] public float MagneticResponse;
	[Category] public float WindResponse;
	[Category("Impact")] public float ImpactThreshold;
	[Category("Impact")] public float ImpactReFireDelay;
	[Category("Impact")] public ParticleSystem ImpactEffect;
	[Category("Impact")] public SoundCue ImpactSound;
	[Category("Slide")] public float SlideThreshold;
	[Category("Slide")] public float SlideReFireDelay;
	[Category("Slide")] public ParticleSystem SlideEffect;
	[Category("Slide")] public SoundCue SlideSound;
	[Category("Parent")] public PhysicalMaterial Parent;
	[Category("PhysicalProperties")] [export, editinline] public PhysicalMaterialPropertyBase PhysicalMaterialProperty;
	
	public virtual /*function */PhysicalMaterialPropertyBase GetPhysicalMaterialProperty(Core.ClassT<PhysicalMaterialPropertyBase> DesiredClass)
	{
		// stub
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
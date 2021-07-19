namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialFootSteps : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public bool bPlayOnTopOfParent;
	[Category] public SoundCue _01_Female_FootStepCrouch;
	[Category] public SoundCue _02_Female_FootStepWalk;
	[Category] public SoundCue _03_Female_FootStepRun;
	[Category] public SoundCue _04_Female_FootStepSprint;
	[Category] public SoundCue _05_Female_FootStepSprintRelease;
	[Category] public SoundCue _06_Female_FootStepWallRun;
	[Category] public SoundCue _07_Female_FootStepWallrunRelease;
	[Category] public SoundCue _08_Female_FootStepLandSoft;
	[Category] public SoundCue _09_Female_FootStepLandMedium;
	[Category] public SoundCue _10_Female_FootStepLandHard;
	[Category] public SoundCue _11_Female_FootStepAttack;
	[Category] public SoundCue _21_Female_HandStepSoft;
	[Category] public SoundCue _22_Female_HandStepMedium;
	[Category] public SoundCue _23_Female_HandStepHard;
	[Category] public SoundCue _24_Female_HandStepLongRelease;
	[Category] public SoundCue _25_Female_HandStepShortRelease;
	[Category] public SoundCue _26_Female_HandStepAttack;
	[Category] public SoundCue _31_Female_BodyAttack;
	[Category] public SoundCue _32_Female_BodyLandSoft;
	[Category] public SoundCue _33_Female_BodyLandHard;
	[Category] public SoundCue _34_Female_BodyLandRoll;
	[Category] public SoundCue _35_Female_BodyVault;
	[Category] public SoundCue _36_Female_BodySlide;
	[Category] public SoundCue _01_Pursuit_FootStepCrouch;
	[Category] public SoundCue _02_Pursuit_FootStepWalk;
	[Category] public SoundCue _03_Pursuit_FootStepRun;
	[Category] public SoundCue _04_Pursuit_FootStepSprint;
	[Category] public SoundCue _05_Pursuit_FootStepSprintRelease;
	[Category] public SoundCue _06_Pursuit_FootStepWallRun;
	[Category] public SoundCue _07_Pursuit_FootStepWallrunRelease;
	[Category] public SoundCue _08_Pursuit_FootStepLandSoft;
	[Category] public SoundCue _09_Pursuit_FootStepLandMedium;
	[Category] public SoundCue _10_Pursuit_FootStepLandHard;
	[Category] public SoundCue _11_Pursuit_FootStepAttack;
	[Category] public SoundCue SwatFootSteps;
	[Category] public ParticleSystem _03_Effect_FootStepRun;
	[Category] public ParticleSystem _06_Effect_FootStepWallRun;
	[Category] public ParticleSystem _08_Effect_FootStepLandSoft;
	[Category] public ParticleSystem _10_Effect_FootStepLandHard;
	[Category] public ParticleSystem _11_Effect_FootStepAttack;
	[Category] public ParticleSystem _12_Effect_FootStepVertigo;
	[Category] public ParticleSystem _21_Effect_HandStepSoft;
	[Category] public ParticleSystem _23_Effect_HandStepHard;
	[Category] public ParticleSystem _25_Effect_HandStepShortRelease;
	[Category] public ParticleSystem _26_Effect_HandStepAttack;
	[Category] public ParticleSystem _27_Effect_FemaleHandGrabHard;
	[Category] public ParticleSystem _28_Effect_FemaleHandStrafeSlow;
	[Category] public ParticleSystem _29_Effect_FemaleHandStrafeFast;
	[Category] public ParticleSystem _31_Effect_BodyAttack;
	[Category] public ParticleSystem _36_Effect_BodySlide;
	
}
}
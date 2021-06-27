namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPhysicalMaterialFootSteps : TdPhysicalMaterialBase/*
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ bool bPlayOnTopOfParent;
	public/*()*/ SoundCue _01_Female_FootStepCrouch;
	public/*()*/ SoundCue _02_Female_FootStepWalk;
	public/*()*/ SoundCue _03_Female_FootStepRun;
	public/*()*/ SoundCue _04_Female_FootStepSprint;
	public/*()*/ SoundCue _05_Female_FootStepSprintRelease;
	public/*()*/ SoundCue _06_Female_FootStepWallRun;
	public/*()*/ SoundCue _07_Female_FootStepWallrunRelease;
	public/*()*/ SoundCue _08_Female_FootStepLandSoft;
	public/*()*/ SoundCue _09_Female_FootStepLandMedium;
	public/*()*/ SoundCue _10_Female_FootStepLandHard;
	public/*()*/ SoundCue _11_Female_FootStepAttack;
	public/*()*/ SoundCue _21_Female_HandStepSoft;
	public/*()*/ SoundCue _22_Female_HandStepMedium;
	public/*()*/ SoundCue _23_Female_HandStepHard;
	public/*()*/ SoundCue _24_Female_HandStepLongRelease;
	public/*()*/ SoundCue _25_Female_HandStepShortRelease;
	public/*()*/ SoundCue _26_Female_HandStepAttack;
	public/*()*/ SoundCue _31_Female_BodyAttack;
	public/*()*/ SoundCue _32_Female_BodyLandSoft;
	public/*()*/ SoundCue _33_Female_BodyLandHard;
	public/*()*/ SoundCue _34_Female_BodyLandRoll;
	public/*()*/ SoundCue _35_Female_BodyVault;
	public/*()*/ SoundCue _36_Female_BodySlide;
	public/*()*/ SoundCue _01_Pursuit_FootStepCrouch;
	public/*()*/ SoundCue _02_Pursuit_FootStepWalk;
	public/*()*/ SoundCue _03_Pursuit_FootStepRun;
	public/*()*/ SoundCue _04_Pursuit_FootStepSprint;
	public/*()*/ SoundCue _05_Pursuit_FootStepSprintRelease;
	public/*()*/ SoundCue _06_Pursuit_FootStepWallRun;
	public/*()*/ SoundCue _07_Pursuit_FootStepWallrunRelease;
	public/*()*/ SoundCue _08_Pursuit_FootStepLandSoft;
	public/*()*/ SoundCue _09_Pursuit_FootStepLandMedium;
	public/*()*/ SoundCue _10_Pursuit_FootStepLandHard;
	public/*()*/ SoundCue _11_Pursuit_FootStepAttack;
	public/*()*/ SoundCue SwatFootSteps;
	public/*()*/ ParticleSystem _03_Effect_FootStepRun;
	public/*()*/ ParticleSystem _06_Effect_FootStepWallRun;
	public/*()*/ ParticleSystem _08_Effect_FootStepLandSoft;
	public/*()*/ ParticleSystem _10_Effect_FootStepLandHard;
	public/*()*/ ParticleSystem _11_Effect_FootStepAttack;
	public/*()*/ ParticleSystem _12_Effect_FootStepVertigo;
	public/*()*/ ParticleSystem _21_Effect_HandStepSoft;
	public/*()*/ ParticleSystem _23_Effect_HandStepHard;
	public/*()*/ ParticleSystem _25_Effect_HandStepShortRelease;
	public/*()*/ ParticleSystem _26_Effect_HandStepAttack;
	public/*()*/ ParticleSystem _27_Effect_FemaleHandGrabHard;
	public/*()*/ ParticleSystem _28_Effect_FemaleHandStrafeSlow;
	public/*()*/ ParticleSystem _29_Effect_FemaleHandStrafeFast;
	public/*()*/ ParticleSystem _31_Effect_BodyAttack;
	public/*()*/ ParticleSystem _36_Effect_BodySlide;
	
}
}
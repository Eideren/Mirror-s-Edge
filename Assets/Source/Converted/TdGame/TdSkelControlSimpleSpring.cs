namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlSimpleSpring : SkelControlSingleBone/*
		native
		hidecategories(Object)*/{
	public/*(Spring)*/ Object.Rotator MaxAngle;
	public/*(Spring)*/ Object.Rotator MinAngle;
	public/*(Spring)*/ float Inertia;
	public/*(Spring)*/ float Stiffness;
	public/*(Spring)*/ Object.Vector SpeedModifier;
	public/*(Spring)*/ bool bScaleByVelocity;
	public/*(Spring)*/ float MaxVelocity;
	public /*transient */Object.Rotator PreviousRotation;
	
	public TdSkelControlSimpleSpring()
	{
		// Object Offset:0x00658017
		MaxAngle = new Rotator
		{
			Pitch=1500,
			Yaw=8000,
			Roll=0
		};
		MinAngle = new Rotator
		{
			Pitch=-1500,
			Yaw=-8000,
			Roll=0
		};
		Inertia = 1.50f;
		Stiffness = 0.250f;
		SpeedModifier = new Vector
		{
			X=-0.0030f,
			Y=-0.010f,
			Z=0.0f
		};
		bScaleByVelocity = true;
		MaxVelocity = 400.0f;
		bApplyRotation = true;
		BoneRotationSpace = SkelControlBase.EBoneControlSpace.BCS_BoneSpace;
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlSimpleSpring : SkelControlSingleBone/*
		native
		hidecategories(Object)*/{
	[Category("Spring")] public Object.Rotator MaxAngle;
	[Category("Spring")] public Object.Rotator MinAngle;
	[Category("Spring")] public float Inertia;
	[Category("Spring")] public float Stiffness;
	[Category("Spring")] public Object.Vector SpeedModifier;
	[Category("Spring")] public bool bScaleByVelocity;
	[Category("Spring")] public float MaxVelocity;
	[transient] public Object.Rotator PreviousRotation;
	
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
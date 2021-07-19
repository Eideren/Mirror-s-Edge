namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleSimBase : ActorComponent/*
		native*/{
	[Category] public float WheelSuspensionStiffness;
	[Category] public float WheelSuspensionDamping;
	[Category] public float WheelSuspensionBias;
	[Category] public float WheelLongExtremumSlip;
	[Category] public float WheelLongExtremumValue;
	[Category] public float WheelLongAsymptoteSlip;
	[Category] public float WheelLongAsymptoteValue;
	[Category] public float WheelLatExtremumSlip;
	[Category] public float WheelLatExtremumValue;
	[Category] public float WheelLatAsymptoteSlip;
	[Category] public float WheelLatAsymptoteValue;
	[Category] public float WheelInertia;
	[Category] public bool bWheelSpeedOverride;
	[Category] public bool bClampedFrictionModel;
	[Category] public bool bAutoDrive;
	[Category] public float AutoDriveSteer;
	
	public SVehicleSimBase()
	{
		// Object Offset:0x003F6367
		WheelLongExtremumSlip = 0.10f;
		WheelLongExtremumValue = 1.0f;
		WheelLongAsymptoteSlip = 2.0f;
		WheelLongAsymptoteValue = 0.60f;
		WheelLatExtremumSlip = 0.350f;
		WheelLatExtremumValue = 0.850f;
		WheelLatAsymptoteSlip = 1.40f;
		WheelLatAsymptoteValue = 0.70f;
		WheelInertia = 1.0f;
	}
}
}
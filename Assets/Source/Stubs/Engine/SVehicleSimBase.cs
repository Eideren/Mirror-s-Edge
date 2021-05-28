namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleSimBase : ActorComponent/*
		native*/{
	public/*()*/ float WheelSuspensionStiffness;
	public/*()*/ float WheelSuspensionDamping;
	public/*()*/ float WheelSuspensionBias;
	public/*()*/ float WheelLongExtremumSlip;
	public/*()*/ float WheelLongExtremumValue;
	public/*()*/ float WheelLongAsymptoteSlip;
	public/*()*/ float WheelLongAsymptoteValue;
	public/*()*/ float WheelLatExtremumSlip;
	public/*()*/ float WheelLatExtremumValue;
	public/*()*/ float WheelLatAsymptoteSlip;
	public/*()*/ float WheelLatAsymptoteValue;
	public/*()*/ float WheelInertia;
	public/*()*/ bool bWheelSpeedOverride;
	public/*()*/ bool bClampedFrictionModel;
	public/*()*/ bool bAutoDrive;
	public/*()*/ float AutoDriveSteer;
	
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
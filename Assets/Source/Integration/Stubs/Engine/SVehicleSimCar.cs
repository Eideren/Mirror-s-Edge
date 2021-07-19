namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleSimCar : SVehicleSimBase/*
		native*/{
	[Category] public float ChassisTorqueScale;
	[Category] public Object.InterpCurveFloat MaxSteerAngleCurve;
	[Category] public float SteerSpeed;
	[Category] public float ReverseThrottle;
	[Category] public float EngineBrakeFactor;
	[Category] public float MaxBrakeTorque;
	[Category] public float StopThreshold;
	public bool bIsDriving;
	public float ActualSteering;
	public float TimeSinceThrottle;
	
	public SVehicleSimCar()
	{
		// Object Offset:0x003F668E
		ReverseThrottle = -1.0f;
	}
}
}
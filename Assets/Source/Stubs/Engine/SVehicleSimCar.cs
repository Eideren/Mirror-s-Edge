namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleSimCar : SVehicleSimBase/*
		native*/{
	public/*()*/ float ChassisTorqueScale;
	public/*()*/ Object.InterpCurveFloat MaxSteerAngleCurve;
	public/*()*/ float SteerSpeed;
	public/*()*/ float ReverseThrottle;
	public/*()*/ float EngineBrakeFactor;
	public/*()*/ float MaxBrakeTorque;
	public/*()*/ float StopThreshold;
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
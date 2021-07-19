namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdVehicleSimCar : SVehicleSimCar/*
		native*/{
	[Category] public Object.InterpCurveFloat TorqueVSpeedCurve;
	[Category] public Object.InterpCurveFloat EngineRPMCurve;
	[Category] public float LSDFactor;
	[Category] public float ThrottleSpeed;
	public float MinRPM;
	public float MaxRPM;
	public float ActualThrottle;
	public bool bForceThrottle;
	public bool bDriverlessBraking;
	
}
}
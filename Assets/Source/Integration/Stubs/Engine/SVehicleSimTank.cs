namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleSimTank : SVehicleSimCar/*
		native*/{
	public float LeftTrackVel;
	public float RightTrackVel;
	public float LeftTrackTorque;
	public float RightTrackTorque;
	[Category] public float MaxEngineTorque;
	[Category] public float EngineDamping;
	[Category] public float InsideTrackTorqueFactor;
	[Category] public float SteeringLatStiffnessFactor;
	[Category] public float TurnInPlaceThrottle;
	[Category] public float TurnMaxGripReduction;
	[Category] public float TurnGripScaleRate;
	[Category] public bool bTurnInPlaceOnSteer;
	
	public SVehicleSimTank()
	{
		// Object Offset:0x003F6929
		TurnMaxGripReduction = 0.970f;
		TurnGripScaleRate = 1.0f;
		bTurnInPlaceOnSteer = true;
		bWheelSpeedOverride = true;
	}
}
}
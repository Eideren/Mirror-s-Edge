namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SVehicleWheel : Component/*
		native*/{
	public enum EWheelSide 
	{
		SIDE_None,
		SIDE_Left,
		SIDE_Right,
		SIDE_MAX
	};
	
	[Category] public float Steer;
	[Category] public float MotorTorque;
	[Category] public float BrakeTorque;
	[Category] public float ChassisTorque;
	[Category] public bool bPoweredWheel;
	[Category] public bool bHoverWheel;
	[Category] public bool bCollidesVehicles;
	[Category] public bool bCollidesPawns;
	public bool bIsSquealing;
	public bool bWheelOnGround;
	[Category] public float SteerFactor;
	[Category] public name SkelControlName;
	public SkelControlWheel WheelControl;
	[Category] public name BoneName;
	[Category] public Object.Vector BoneOffset;
	[Category] public float WheelRadius;
	[Category] public float SuspensionTravel;
	[Category] public float SuspensionSpeed;
	[Category] public ParticleSystem WheelParticleSystem;
	[Category] public SVehicleWheel.EWheelSide Side;
	[Category] public float LongSlipFactor;
	[Category] public float LatSlipFactor;
	[Category] public float HandbrakeLongSlipFactor;
	[Category] public float HandbrakeLatSlipFactor;
	[Category] public float ParkedSlipFactor;
	public Object.Vector WheelPosition;
	public float SpinVel;
	public float LongSlipRatio;
	public float LatSlipAngle;
	public Object.Vector ContactNormal;
	public Object.Vector LongDirection;
	public Object.Vector LatDirection;
	public float ContactForce;
	public float LongImpulse;
	public float LatImpulse;
	public float DesiredSuspensionPosition;
	public float SuspensionPosition;
	public float CurrentRotation;
	[Const, transient] public Object.Pointer WheelShape;
	[Const, transient] public int WheelMaterialIndex;
	public Core.ClassT<ParticleSystemComponent> WheelPSCClass;
	[export, editinline] public ParticleSystemComponent WheelParticleComp;
	public name SlipParticleParamName;
	
	public SVehicleWheel()
	{
		// Object Offset:0x003F71D4
		bCollidesVehicles = true;
		WheelRadius = 35.0f;
		SuspensionTravel = 30.0f;
		SuspensionSpeed = 50.0f;
		LongSlipFactor = 4000.0f;
		LatSlipFactor = 20000.0f;
		HandbrakeLongSlipFactor = 4000.0f;
		HandbrakeLatSlipFactor = 20000.0f;
		ParkedSlipFactor = 20000.0f;
		WheelPSCClass = ClassT<ParticleSystemComponent>()/*Ref Class'ParticleSystemComponent'*/;
		SlipParticleParamName = (name)"WheelSlip";
	}
}
}
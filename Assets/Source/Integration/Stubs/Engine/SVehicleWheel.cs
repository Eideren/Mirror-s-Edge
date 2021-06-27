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
	
	public/*()*/ float Steer;
	public/*()*/ float MotorTorque;
	public/*()*/ float BrakeTorque;
	public/*()*/ float ChassisTorque;
	public/*()*/ bool bPoweredWheel;
	public/*()*/ bool bHoverWheel;
	public/*()*/ bool bCollidesVehicles;
	public/*()*/ bool bCollidesPawns;
	public bool bIsSquealing;
	public bool bWheelOnGround;
	public/*()*/ float SteerFactor;
	public/*()*/ name SkelControlName;
	public SkelControlWheel WheelControl;
	public/*()*/ name BoneName;
	public/*()*/ Object.Vector BoneOffset;
	public/*()*/ float WheelRadius;
	public/*()*/ float SuspensionTravel;
	public/*()*/ float SuspensionSpeed;
	public/*()*/ ParticleSystem WheelParticleSystem;
	public/*()*/ SVehicleWheel.EWheelSide Side;
	public/*()*/ float LongSlipFactor;
	public/*()*/ float LatSlipFactor;
	public/*()*/ float HandbrakeLongSlipFactor;
	public/*()*/ float HandbrakeLatSlipFactor;
	public/*()*/ float ParkedSlipFactor;
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
	public /*const transient */Object.Pointer WheelShape;
	public /*const transient */int WheelMaterialIndex;
	public Core.ClassT<ParticleSystemComponent> WheelPSCClass;
	public /*export editinline */ParticleSystemComponent WheelParticleComp;
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
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerInputConsole : TdPlayerInput/* within TdPlayerController*//*
		transient
		config(Input)
		hidecategories(Object,UIRoot)*/{
	public new TdPlayerController Outer => base.Outer as TdPlayerController;
	
	public TdPawn AATarget;
	public TdPawn AAStrafeTarget;
	public int AAStrafeOrigin;
	public/*(AimAssist)*/ bool bAAEnabled;
	public/*(AimAssist)*/ int AAStrafeAssistRelease;
	public Object.Vector DeltaAim;
	public float DeltaAimDistZ;
	public float DeltaAimDistY;
	public TdWeapon CurrentWeapon;
	public float AssistYawBias;
	public float AssistPitchBias;
	public float YawAccelerationTime;
	
	public override /*simulated function */void InitInputSystem(Class GameInfoClass)
	{
		// stub
	}
	
	public virtual /*exec function */void EnableAA()
	{
		// stub
	}
	
	public override /*function */void PreProcessInput(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */bool EqualSigns(float A, float B)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void AimAssist(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void PerformResponseMapping(float DeltaTime)
	{
		// stub
	}
	
	public override /*function */void ViewAcceleration(float DeltaTime)
	{
		// stub
	}
	
	public TdPlayerInputConsole()
	{
		// Object Offset:0x0062809F
		bAAEnabled = true;
		AAStrafeAssistRelease = 3000;
		AssistYawBias = 1.0f;
		AssistPitchBias = 1.0f;
	}
}
}
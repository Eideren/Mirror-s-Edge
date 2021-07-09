// NO OVERWRITE

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
		switch(GameInfoClass)
		{
			case ClassT<TdSPGame> _:
				AssistYawBias = ClassT<TdGameTypeSPSettings>().DefaultAs<TdGameTypeSettings>().AimAssistYawBias;
				AssistPitchBias = ClassT<TdGameTypeSPSettings>().DefaultAs<TdGameTypeSettings>().AimAssistPitchBias;
				break;
			case ClassT<TdMPTeamDMGame> _:
			case ClassT<TdMPTeamPursuitGame> _:
				AssistYawBias = ClassT<TdGameTypeMPSettings>().DefaultAs<TdGameTypeSettings>().AimAssistYawBias;
				AssistPitchBias = ClassT<TdGameTypeMPSettings>().DefaultAs<TdGameTypeSettings>().AimAssistPitchBias;
				break;
			default:
				break;
		}
	}
	
	public virtual /*exec function */void EnableAA()
	{
		bAAEnabled = !bAAEnabled;
	}
	
	public override /*function */void PreProcessInput(float DeltaTime)
	{
		PerformResponseMapping(DeltaTime);
		if(Outer.Pawn != default)
		{
			CurrentWeapon = ((Outer.Pawn.Weapon) as TdWeapon);
			if(CurrentWeapon != default)
			{
				AATarget = Outer.GetAATarget(((float)(CurrentWeapon.MaxAssistDistance)));
				if(((AATarget != default) && bAAEnabled) && ((((aTurn != ((float)(0))) || aLookUp != ((float)(0)))) || aStrafe != ((float)(0))))
				{
					AimAssist(DeltaTime);				
				}
				else
				{
					if((AAStrafeTarget != default) && aStrafe == ((float)(0)))
					{
						AAStrafeTarget = default;
					}
				}
			}
		}
		if(aTurn == ((float)(0)))
		{
			YawAccelerationTime = 0.0f;
		}
		base.PreProcessInput(DeltaTime);
	}
	
	public virtual /*function */bool EqualSigns(float A, float B)
	{
		return (((A < ((float)(0))) && B < ((float)(0))) || (A >= ((float)(0))) && B >= ((float)(0)));
	}
	
	public virtual /*function */void AimAssist(float DeltaTime)
	{
		/*local */Object.Vector CameraLocation = default, CamRotX = default, CamRotY = default, CamRotZ = default, AimLocation = default, TargetLocation = default,
			TargetLocTemp = default;
	
		/*local */Object.Rotator CameraOrientation = default;
		/*local */float TargetHeight = default, TargetRadius = default, DistanceToTarget = default, YawMultiplier = default, PitchMultiplier = default;
	
		TargetLocation = AATarget.Location + (/*>>*/ShiftR(vect(0.0f, 0.0f, 50.0f), CameraOrientation));
		TargetRadius = ((AATarget.CollisionComponent) as CylinderComponent).CollisionRadius;
		TargetHeight = ((AATarget.CollisionComponent) as CylinderComponent).CollisionHeight;
		Outer.GetPlayerViewPoint(ref/*probably?*/ CameraLocation, ref/*probably?*/ CameraOrientation);
		GetAxes(CameraOrientation, ref/*probably?*/ CamRotX, ref/*probably?*/ CamRotY, ref/*probably?*/ CamRotZ);
		DistanceToTarget = VSize(TargetLocation - CameraLocation);
		AimLocation = CameraLocation + (CamRotX * DistanceToTarget);
		TargetLocTemp = TargetLocation;
		TargetLocTemp.Z = AimLocation.Z;
		DeltaAimDistY = PointDistToLine(AimLocation, TargetLocTemp - CameraLocation, CameraLocation, ref/*probably?*/ DeltaAim);
		TargetLocTemp = TargetLocation;
		TargetLocTemp.X = AimLocation.X;
		TargetLocTemp.Y = AimLocation.Y;
		DeltaAimDistZ = PointDistToLine(AimLocation, TargetLocTemp - CameraLocation, CameraLocation, ref/*probably?*/ /*null*/NullRef.Object_Vector);
		DeltaAim = DeltaAim - AimLocation;
		if(((DeltaAimDistY > TargetRadius) || DeltaAimDistZ > TargetHeight))
		{
			return;
		}
		YawMultiplier = Lerp(CurrentWeapon.MaxAssistValueYaw, 0.0f, Abs(DeltaAimDistY / TargetRadius));
		PitchMultiplier = Lerp(CurrentWeapon.MaxAssistValuePitch, 0.0f, Abs(DeltaAimDistZ / TargetHeight));
		aTurn *= (1.0f - (YawMultiplier * AssistYawBias));
		aLookUp *= (1.0f - (PitchMultiplier * AssistPitchBias));
	}
	
	public virtual /*function */void PerformResponseMapping(float DeltaTime)
	{
	
	}
	
	public override /*function */void ViewAcceleration(float DeltaTime)
	{
		/*local */float absturn = default;
	
		absturn = Abs(aTurn);
		if(absturn > YawAccelThreshold)
		{
			absturn -= YawAccelThreshold;
			absturn /= (1.0f - YawAccelThreshold);
			absturn = Exponentiation(absturn, 2.0f);
			if(AATarget != default)
			{			
			}
			else
			{
				absturn *= 1.50f;
			}
			aTurn *= (1.0f + absturn);
		}
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
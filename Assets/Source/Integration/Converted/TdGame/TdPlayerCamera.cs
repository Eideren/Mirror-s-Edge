namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerCamera : Camera/*
		config(Camera)
		notplaceable
		hidecategories(Navigation)*/{
	public Object.Vector FreeflightPosition;
	public Object.Rotator FreeflightRotation;
	[config] public float FreeflightScale;
	public float FixedPersonDistance;
	public Object.Rotator FixedPersonVectorRelativeRotator;
	public int ThirdPerson360Yaw;
	
	public override /*function */void eventPostBeginPlay()
	{
		base.eventPostBeginPlay();
		if(FreeflightScale <= 0.0f)
		{
			FreeflightScale = 1.0f;
		}
	}
	
	public override /*function */void UpdateViewTarget(ref Camera.TViewTarget OutVT, float DeltaTime)
	{
		/*local */Object.Vector Loc = default, pos = default, HitLocation = default, HitNormal = default;
		/*local */Object.Rotator Rot = default;
		/*local */Actor HitActor = default;
		/*local */CameraActor CamActor = default;
		/*local */bool bDoNotApplyModifiers = default;
		/*local */Object.TPOV OrigPOV = default;
		/*local */TdPlayerController TPC = default;
		/*local */Object.Vector X = default, Y = default, Z = default, TargetLocation = default;
	
		if(CameraStyle == "FreeFlight")
		{
			DeltaTime = WorldInfo.SavedDeltaSeconds;
		}
		OrigPOV = OutVT.POV;
		OutVT.POV.FOV = DefaultFOV;
		CamActor = ((OutVT.Target) as CameraActor);
		if(CamActor != default)
		{
			CamActor.GetCameraView(DeltaTime, ref/*probably?*/ OutVT.POV);
			bConstrainAspectRatio = (bConstrainAspectRatio || CamActor.bConstrainAspectRatio);
			OutVT.AspectRatio = CamActor.AspectRatio;		
		}
		else
		{
			if((((OutVT.Target != default) && ((OutVT.Target) as Pawn) == default) || !((OutVT.Target) as Pawn).CalcCamera(DeltaTime, ref/*probably?*/ OutVT.POV.Location, ref/*probably?*/ OutVT.POV.Rotation, ref/*probably?*/ OutVT.POV.FOV)))
			{
				if(((OutVT.Target) as TdPawn) != default)
				{
					TPC = ((((OutVT.Target) as TdPawn).Controller) as TdPlayerController);
				}
				if(((OutVT.Target) as TdPawn) != default)
				{
					TargetLocation = ((OutVT.Target) as TdPawn).Mesh.GetBoneLocation("Hips", default(int?));				
				}
				else
				{
					TargetLocation = OutVT.Target.Location;
				}
				bDoNotApplyModifiers = true;
				switch(CameraStyle)
				{
					case "Fixed":
						OutVT.POV = OrigPOV;
						break;
					case "FreeFlight":
						if(TPC != default)
						{
							GetAxes(FreeflightRotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
							FreeflightRotation.Pitch += ((int)(((TPC.MouseY - ((TPC.PlayerInput.RawJoyLookUp * DeltaTime) * ((float)(15000)))) * ((float)(2))) * ((float)(((TPC.PlayerInput.bInvertMouse) ? -1 : 1)))));
							FreeflightRotation.Yaw += ((int)((TPC.MouseX + ((TPC.PlayerInput.RawJoyLookRight * DeltaTime) * ((float)(15000)))) * ((float)(2))));
							FreeflightPosition += ((((((Square(TPC.PlayerInput.RawJoyUp) * TPC.PlayerInput.RawJoyUp) * DeltaTime) * ((float)(5000))) * X) * FreeflightScale) + (((((Square(TPC.PlayerInput.RawJoyRight) * TPC.PlayerInput.RawJoyRight) * DeltaTime) * ((float)(1500))) * Y) * FreeflightScale));
							OutVT.POV.Location = FreeflightPosition;
							OutVT.POV.Rotation = FreeflightRotation;
						}
						break;
					case "FixedPerson":
						OutVT.POV.Location = OutVT.Target.Location + ((/*>>*/ShiftR(FreeflightPosition, (OutVT.Target.Rotation - FixedPersonVectorRelativeRotator))) * FixedPersonDistance);
						OutVT.POV.Rotation = OutVT.Target.Rotation + FreeflightRotation;
						break;
					case "ThirdPerson360":
					case "ThirdPerson":
					case "FreeCam":
						Loc = TargetLocation;
						Rot = OutVT.Target.Rotation;
						if(CameraStyle == "FreeCam")
						{
							Rot = PCOwner.Rotation;						
						}
						else
						{
							if(CameraStyle == "ThirdPerson360")
							{
								ThirdPerson360Yaw += ((int)(((float)(32000)) * DeltaTime));
								Rot.Yaw += ThirdPerson360Yaw;							
							}
							else
							{
								ThirdPerson360Yaw = 0;
							}
						}
						Loc += (/*>>*/ShiftR(FreeCamOffset, Rot));
						pos = Loc - (((Vector)(Rot)) * FreeCamDistance);
						HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, pos, Loc, false, vect(0.0f, 0.0f, 0.0f), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default(int?));
						if(HitActor != default)
						{
							Loc = HitLocation + (HitNormal * ((float)(2)));						
						}
						else
						{
							Loc = pos;
						}
						OutVT.POV.Location = Loc;
						OutVT.POV.Rotation = Rot;
						break;
					case "FirstPerson":
					default:
						OutVT.Target.GetActorEyesViewPoint(ref/*probably?*/ OutVT.POV.Location, ref/*probably?*/ OutVT.POV.Rotation);
						break;
				}
			}
		}
		if(!bDoNotApplyModifiers)
		{
			ApplyCameraModifiers(DeltaTime, ref/*probably?*/ OutVT.POV);
		}
	}
	
	public TdPlayerCamera()
	{
		// Object Offset:0x00611478
		FreeflightScale = 1.0f;
	}
}
}
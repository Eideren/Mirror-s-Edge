namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_ZipLine : TdPhysicsMove/*
		native
		config(PawnMovement)*/{
	public enum EZipLineStatus 
	{
		ZLS_Moving,
		ZLS_CloseToEnd,
		ZLS_Impact,
		ZLS_MAX
	};
	
	public TdZiplineVolume ZipLine;
	public/*(ZipLine)*/ Object.Vector HangOffset;
	public/*(ZipLine)*/ /*config */float MinZipVelocity;
	public/*(ZipLine)*/ /*config */float MinZipAcceleration;
	public float CurrentParamOnCurve;
	public /*export editinline */AudioComponent ZippingSoundComponent;
	public SoundCue ZippingSound;
	public/*(ZipLineSound)*/ /*config */float ZipFadeInTime;
	public/*(ZipLineSound)*/ /*config */float ZipFadeOutTime;
	public /*private */ForceFeedbackWaveform ZiplineWaveform;
	public /*private transient */Object.Vector CurrentLookAtPoint;
	public /*private transient */bool bZipLineLookAssist;
	public TdMove_ZipLine.EZipLineStatus ZipLineStatus;
	
	public override /*function */bool CanDoMove()
	{
		return base.CanDoMove();
	}
	
	public override /*simulated function */void StartMove()
	{
		/*local */Object.Vector StartPosition = default;
	
		base.StartMove();
		StartPosition = PawnOwner.Location;
		StartPosition.Z -= HangOffset.Z;
		ZipLine.FindClosestPointOnDSpline(StartPosition, ref/*probably?*/ StartPosition, ref/*probably?*/ CurrentParamOnCurve, default);
		((PawnOwner.Controller) as TdPlayerController).ClientPlayForceFeedbackWaveform(ZiplineWaveform);
		if(ZippingSoundComponent == default)
		{
			ZippingSoundComponent = PawnOwner.CreateAudioComponent(ZippingSound, false, true, default, default, default);
		}
		if(ZippingSoundComponent != default)
		{
			ZippingSoundComponent.bUseOwnerLocation = true;
			ZippingSoundComponent.bAllowSpatialization = true;
			ZippingSoundComponent.bAutoDestroy = true;
			PawnOwner.AttachComponent(ZippingSoundComponent);
			ZippingSoundComponent.FadeIn(ZipFadeInTime, 1.0f);
		}
		bZipLineLookAssist = true;
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		if(((int)ZipLineStatus) == ((int)TdMove_ZipLine.EZipLineStatus.ZLS_Impact/*2*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.30f);		
		}
		else
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("SwingJumpOff")), 1.0f, 0.20f, 0.20f, false, default);
		}
		ZipLine = default;
		ZipLineStatus = TdMove_ZipLine.EZipLineStatus.ZLS_Moving/*0*/;
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		PawnOwner.EnterFallingHeight -= 80.0f;
		((PawnOwner.Controller) as TdPlayerController).ClientStopForceFeedbackWaveform(ZiplineWaveform);
		if(ZippingSoundComponent != default)
		{
			ZippingSoundComponent.FadeOut(ZipFadeOutTime, 0.0f);
		}
		bZipLineLookAssist = false;
	}
	
	public override /*simulated function */void HitWall(Object.Vector HitNormal, Actor Wall)
	{
		if((HitNormal.Z > 0.10f) && PawnOwner.Moves[35].CanDoMove())
		{
			((PawnOwner.Moves[35]) as TdMove_Stumble).InstigatorLocation = PawnOwner.Location - (10.0f * Normal(PawnOwner.Velocity));
			((PawnOwner.Moves[35]) as TdMove_Stumble).damageMomentum = Normal(PawnOwner.Velocity);
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Stumble/*35*/, default, default);		
		}
		else
		{
			if(VSize2D(PawnOwner.Velocity) > 100.0f)
			{
				PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
				PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
			}
		}
	}
	
	public virtual /*simulated event */void PlayForwardImpact()
	{
		PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.20f);
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, ((name)("ziplinehitwall")), 1.0f, 0.10f, 0.20f, default, default);
		if(ZippingSoundComponent != default)
		{
			ZippingSoundComponent.FadeOut(ZipFadeOutTime, 0.0f);
		}
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_Falling/*2*/, default);
		ZipLineStatus = TdMove_ZipLine.EZipLineStatus.ZLS_Impact/*2*/;
		PawnOwner.SetIgnoreLookInput(0.80f);
		PawnOwner.SetIgnoreMoveInput(0.80f);
		SetTimer(0.80f);
	}
	
	public virtual /*simulated event */void PrepareForForwardImpact()
	{
		if(((int)ZipLineStatus) == ((int)TdMove_ZipLine.EZipLineStatus.ZLS_Moving/*0*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, 0.10f);
			PawnOwner.PlayCustomAnim(TdPawn.CustomNodeType.CNT_FullBody/*2*/, "ziplineintohitwall", 1.0f, 0.30f, 0.20f, true, true, false, default);
			ZipLineStatus = TdMove_ZipLine.EZipLineStatus.ZLS_CloseToEnd/*1*/;
		}
	}
	
	public override /*simulated function */void OnTimer()
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
	}
	
	public override /*simulated function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		if(PawnOwner.Moves[2].CanDoMove())
		{
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
		}
	}
	
	public override /*simulated function */int HandleDeath(int Damage)
	{
		PawnOwner.SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default, default);
		PawnOwner.SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default);
		return base.HandleDeath(Damage);
	}
	
	public override /*simulated function */void UpdateViewRotation(ref Object.Rotator out_Rotation, float DeltaTime, ref Object.Rotator DeltaRot)
	{
		base.UpdateViewRotation(ref/*probably?*/ out_Rotation, DeltaTime, ref/*probably?*/ DeltaRot);
		if((DeltaRot.Yaw > 0) || DeltaRot.Yaw < 0)
		{
			AbortLookAtTarget();
			bZipLineLookAssist = false;		
		}
		else
		{
			if(bZipLineLookAssist)
			{
				SetLookAtTargetLocation(CurrentLookAtPoint, 0.20f, -1.0f);
			}
		}
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_ZipLine()
	{
		// Object Offset:0x005F2314
		HangOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-90.0f
		};
		MinZipVelocity = 300.0f;
		MinZipAcceleration = 400.0f;
		ZippingSound = LoadAsset<SoundCue>("A_Kits.ZipLine.ZipLine")/*Ref SoundCue'A_Kits.ZipLine.ZipLine'*/;
		ZipFadeInTime = 0.10f;
		ZipFadeOutTime = 0.50f;
		ZiplineWaveform = new ForceFeedbackWaveform
		{
			// Object Offset:0x01B6CF0A
			bIsLooping = true,
			Samples = new array<ForceFeedbackWaveform.WaveformSample>
			{
				new ForceFeedbackWaveform.WaveformSample
				{
					LeftAmplitude = 0,
					RightAmplitude = 30,
					LeftFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Constant,
					RightFunction = ForceFeedbackWaveform.EWaveformFunction.WF_Sin90to180,
					Duration = 1.0f,
				},
			},
		}/* Reference: ForceFeedbackWaveform'Default__TdMove_ZipLine.ZiplineWaveformObj' */;
		PawnPhysics = Actor.EPhysics.PHYS_Flying;
		ControllerState = (name)"PlayerGrabbing";
		bShouldHolsterWeapon = true;
		bConstrainLook = true;
		bDisableFaceRotation = true;
		AiAimPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 0.010f,
			Medium = 0.10f,
			Hard = 0.30f,
		};
		AiAimOneShotPenalties = new TdMove.AIAimingModifierSettings
		{
			Easy = 200.0f,
			Medium = 200.0f,
			Hard = 200.0f,
		};
		MovementGroup = TdMove.EMovementGroup.MG_TwoHandsBusy;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		MinLookConstraint = new Rotator
		{
			Pitch=-3200,
			Yaw=-7000,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=7000,
			Roll=32768
		};
	}
}
}
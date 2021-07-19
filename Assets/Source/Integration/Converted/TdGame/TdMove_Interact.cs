namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMove_Interact : TdPhysicsMove/*
		config(PawnMovement)*/{
	public float AnimationInteractionDelay;
	public/*private*/ float EventDelay;
	public/*private*/ TdTrigger CurrentTrigger;
	public/*private*/ SeqEvent_TdUsed CurrentEvent;
	public Object.Vector MoveLocation;
	public Object.Vector NormalFromTrigger2D;
	[config] public float DistanceToAButton;
	[config] public float DistanceToAValve;
	public/*private*/ float DistanceToInteractableObject;
	public bool bReverseRev;
	public bool bReachedTrigger;
	
	public override /*function */bool CanDoMove()
	{
		/*local */Object.Vector X = default, Y = default, Z = default, DeltaPosition = default;
		/*local */float DegDiff = default;
	
		if(!base.CanDoMove())
		{
			return false;
		}
		if(((CurrentTrigger == default) || CurrentEvent == default))
		{
			return false;
		}
		if(((int)PawnOwner.MovementState) != ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			return false;
		}
		PawnOwner.GetAxes(CurrentTrigger.Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		DeltaPosition = CurrentTrigger.Location - PawnOwner.Location;
		DeltaPosition.Z = 0.0f;
		DeltaPosition = Normal(DeltaPosition);
		DegDiff = Dot(((Vector)(PawnOwner.Rotation)), -Y);
		DegDiff = (Acos(DegDiff) * 180.0f) / 3.1415930f;
		if(Abs(DegDiff) > (CurrentTrigger.AngleLimit / ((float)(2))))
		{
			return false;
		}
		if(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) || ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_ButtonHigh/*2*/)))
		{
			NormalFromTrigger2D = Normal(Y);
			DistanceToInteractableObject = DistanceToAButton;		
		}
		else
		{
			if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
			{
				NormalFromTrigger2D = Normal(Y);
				DistanceToInteractableObject = DistanceToAValve;
			}
		}
		NormalFromTrigger2D.Z = 0.0f;
		MoveLocation = CurrentTrigger.Location + (NormalFromTrigger2D * DistanceToInteractableObject);
		MoveLocation.Z = PawnOwner.Location.Z;
		if(MovementTraceForBlocking(MoveLocation, PawnOwner.Location, PawnOwner.GetCollisionExtent()))
		{
			return false;
		}
		return true;
	}
	
	public virtual /*simulated function */void ReleaseCurrentTriggerAndEvent()
	{
		CurrentTrigger = default;
		CurrentEvent = default;
	}
	
	public virtual /*simulated function */void SetCurrentTrigger(TdTrigger ActiveTrigger)
	{
		CurrentTrigger = ActiveTrigger;
		if(CurrentTrigger.GetRevCount() == CurrentTrigger.NumberOfRevs)
		{
			bReverseRev = true;		
		}
		else
		{
			bReverseRev = false;
		}
	}
	
	public virtual /*simulated function */void SetCurrentEvent(SeqEvent_TdUsed ActiveUsedEvent)
	{
		CurrentEvent = ActiveUsedEvent;
		CurrentEvent.bInteract = true;
	}
	
	public virtual /*private final simulated function */void UpdateEventDelay()
	{
		if(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) || ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_ButtonHigh/*2*/)))
		{
			AnimationInteractionDelay = 0.60f;		
		}
		else
		{
			AnimationInteractionDelay = 0.0f;
		}
		EventDelay = AnimationInteractionDelay;
	}
	
	public virtual /*simulated event */void StartInteract()
	{
		/*local */float WalkSpeed = default, WalkTime = default;
		/*local */TdPawn.EWeaponType WeaponType = default;
	
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		bReachedTrigger = false;
		if(PawnOwner.OkToInteract())
		{
			PawnOwner.Interacted();
		}
		if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
		{
			WalkTime = 0.30f;
			WalkSpeed = ((float)(Clamp(((int)(VSize2D(MoveLocation - PawnOwner.Location) / WalkTime)), 100, 1000)));
			((PawnOwner) as TdPlayerPawn).SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup.SDPG_Intermediate/*2*/);		
		}
		else
		{
			if(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) || ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_ButtonHigh/*2*/)))
			{
				WalkTime = 0.20f;
				WalkSpeed = ((float)(Clamp(((int)(VSize2D(MoveLocation - PawnOwner.Location) / WalkTime)), 100, 1000)));
			}
		}
		ResetCameraLook(WalkTime);
		SetPreciseRotation(Normalize(((Rotator)(-NormalFromTrigger2D))), WalkTime);
		SetPreciseLocation(MoveLocation, TdMove.EPreciseLocationMode.PLM_Walk/*1*/, WalkSpeed);
		WeaponType = ((TdPawn.EWeaponType)PawnOwner.GetWeaponType());
		if(((((int)WeaponType) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) || (((int)WeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) && ((int)PawnOwner.WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Ready/*2*/)))
		{
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, "unholster", -1.80f, 0.20f, -1.0f, default(bool?), default(bool?));
			PawnOwner.SetCustomAnimsBlendOutTime(TdPawn.CustomNodeType.CNT_Weapon/*7*/, -1.0f);
		}
	}
	
	public override /*simulated event */void ReachedPreciseLocationAndRotation()
	{
		/*local */Object.Rotator ControllerAlignRotation = default;
	
		if(bReachedTrigger)
		{
			PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
			PawnOwner.SetLocation(MoveLocation);
			return;
		}
		bReachedTrigger = true;
		CurrentEvent.OutputLinks[0].ActivateDelay = EventDelay;
		if(PawnOwner.Weapon != default)
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.20f);
			PawnOwner.SetUnarmed();
		}
		AbortLookAtTarget();
		ResetCameraLook(0.0f);
		PawnOwner.Velocity = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.Acceleration = vect(0.0f, 0.0f, 0.0f);
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, false, default(bool?));
		PawnOwner.bCollideWorld = false;
		PawnOwner.SetLocation(MoveLocation);
		PawnOwner.SetRotation(Normalize(((Rotator)(-NormalFromTrigger2D))));
		ControllerAlignRotation = PawnOwner.Controller.Rotation;
		ControllerAlignRotation.Yaw = PawnOwner.Rotation.Yaw;
		PawnOwner.Controller.SetRotation(ControllerAlignRotation);
		PawnOwner.SetCollision(PawnOwner.bCollideActors, true, default(bool?));
		PawnOwner.bCollideWorld = true;
		PawnOwner.SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		if(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) || ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_ButtonHigh/*2*/)))
		{
			PlayInteractAnimation(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) ? "interactbutton" : "interactbuttonhigh"), 1.0f, 0.20f, 0.450f);
			PawnOwner.SetIgnoreLookInput(-1.0f);
			SetTimer(0.850f);
			SetMoveTimer(EventDelay, false, "ActivateFirstOuputLink");		
		}
		else
		{
			if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
			{
				PawnOwner.SetIgnoreLookInput(-1.0f);
				SetTimer(0.10f);
			}
		}
	}
	
	public virtual /*simulated function */void ActivateFirstOuputLink()
	{
		ActivateOutputLink(0);
	}
	
	public override /*simulated function */void OnTimer()
	{
		if(!bReachedTrigger)
		{
			if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
			{
				PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, 0.30f);
			}
			PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));		
		}
		else
		{
			if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
			{
				if(bReverseRev)
				{
					if(CurrentTrigger.GetRevCount() == 1)
					{
						PlayInteractAnimation("interactvalveend", 1.0f, 0.20f, 0.0f);
						ActivateOutputLink(2);					
					}
					else
					{
						PlayInteractAnimation("interactvalveloop", -1.0f, 0.20f, 0.0f);
						ActivateOutputLink(0);
					}				
				}
				else
				{
					PlayInteractAnimation("interactvalvestart", 1.0f, 0.20f, 0.0f);
					ActivateOutputLink(0);
				}
				PawnOwner.SetIgnoreLookInput(-1.0f);			
			}
			else
			{
				ActivateOutputLink(3);
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			}
		}
	}
	
	public override /*simulated function */void StartMove()
	{
		base.StartMove();
		UpdateEventDelay();
		StartInteract();
	}
	
	public override /*simulated function */void StopMove()
	{
		base.StopMove();
		CurrentEvent.bInteract = false;
		CurrentTrigger = default;
		CurrentEvent = default;
		bReachedTrigger = false;
		if(((int)PawnOwner.GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			PawnOwner.StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
			PlayMoveAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, "unholster", 1.0f, 0.0f, 0.20f, default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated function */void PlayInteractAnimation(name AnimSeqName, float Rate, float BlendInTime, float BlendOutTime)
	{
		PlayMoveAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, AnimSeqName, Rate, BlendInTime, BlendOutTime, default(bool?), default(bool?));
		if(((CurrentEvent != default) && ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/)) && CurrentEvent.InteractSkelMeshRef != default)
		{
			CurrentEvent.InteractSkelMeshRef.PlayAnimation(AnimSeqName, Rate);
		}
	}
	
	public override /*simulated function */void OnCustomAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		if(SeqNode.AnimSeqName == "unholster")
		{
			return;
		}
		if(((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Valve/*1*/))
		{
			if(bReverseRev)
			{
				CurrentTrigger.DecreaseRevCount();
				if(CurrentTrigger.GetRevCount() == 1)
				{
					PlayInteractAnimation("interactvalveend", 1.0f, 0.0f, 0.30f);
					ActivateOutputLink(2);				
				}
				else
				{
					if(CurrentTrigger.GetRevCount() > 0)
					{
						DecreaseValveRotation();
						PlayInteractAnimation("interactvalveloop", -1.0f, 0.0f, 0.0f);
						ActivateOutputLink(1);					
					}
					else
					{
						ActivateOutputLink(3);
						PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
					}
				}			
			}
			else
			{
				CurrentTrigger.IncreaseRevCount();
				if(CurrentTrigger.GetRevCount() == (CurrentTrigger.NumberOfRevs - 1))
				{
					IncreaseValveRotation();
					PlayInteractAnimation("interactvalveloop", 1.0f, 0.0f, 0.0f);
					ActivateOutputLink(2);				
				}
				else
				{
					if(CurrentTrigger.GetRevCount() < CurrentTrigger.NumberOfRevs)
					{
						if(CurrentTrigger.GetRevCount() > 1)
						{
							IncreaseValveRotation();
						}
						PlayInteractAnimation("interactvalveloop", 1.0f, 0.0f, 0.0f);
						ActivateOutputLink(1);					
					}
					else
					{
						ActivateOutputLink(3);
						PlayMoveAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "interactvalveloop", 1.0f, 0.0f, 0.40f, default(bool?), default(bool?));
						bReachedTrigger = false;
						SetTimer(0.30f);
					}
				}
			}		
		}
		else
		{
			if(((((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_Button/*0*/)) || ((int)CurrentTrigger.TriggerType) == ((int)TdTrigger.ETriggerInteractType.TIT_ButtonHigh/*2*/)))
			{
				ActivateOutputLink(3);
				PawnOwner.SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			}
		}
	}
	
	public virtual /*simulated function */void IncreaseValveRotation()
	{
		if((CurrentEvent != default) && CurrentEvent.InteractSkelMeshRef != default)
		{
			CurrentEvent.InteractSkelMeshRef.AddValveRoll(16384);
		}
	}
	
	public virtual /*simulated function */void DecreaseValveRotation()
	{
		if((CurrentEvent != default) && CurrentEvent.InteractSkelMeshRef != default)
		{
			CurrentEvent.InteractSkelMeshRef.AddValveRoll(-16384);
		}
	}
	
	public virtual /*simulated function */void ActivateOutputLink(int OutputLinkNumber)
	{
		if((CurrentEvent != default) && OutputLinkNumber < CurrentEvent.OutputLinks.Length)
		{
			CurrentEvent.OutputLinks[OutputLinkNumber].bHasImpulse = true;
		}
	}
	
	public override /*simulated function */bool CanUseLookAtHint()
	{
		return false;
	}
	
	public override /*function */void DrawAnimDebugInfo(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public TdMove_Interact()
	{
		// Object Offset:0x005C1640
		DistanceToAButton = 48.0f;
		DistanceToAValve = 40.0f;
		ControllerState = (name)"PlayerWalking";
		bDisableFaceRotation = true;
		bTwoHandedFullBodyAnimations = true;
		MovementGroup = TdMove.EMovementGroup.MG_NonInteractive;
		AimMode = TdPawn.MoveAimMode.MAM_NoHands;
		DisableMovementTime = -1.0f;
		DisableLookTime = -1.0f;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Pawn : Actor/*
		abstract
		native
		nativereplication
		config(Game)
		placeable
		hidecategories(Navigation)*/{
	public enum EPathSearchType 
	{
		PST_Default,
		PST_Breadth,
		PST_NewBestPathTo,
		PST_Constraint,
		PST_MAX
	};
	
	public /*const */float MaxStepHeight;
	public /*const */float MaxJumpHeight;
	public float WalkableFloorZ;
	public /*repnotify */Controller Controller;
	public /*const */Pawn NextPawn;
	public float NetRelevancyTime;
	public PlayerController LastRealViewer;
	public Actor LastViewer;
	public bool bUpAndOut;
	public /*protected */bool bIsWalking;
	public bool bWantsToCrouch;
	public /*const */bool bIsCrouched;
	public /*const */bool bTryToUncrouch;
	public/*()*/ bool bCanCrouch;
	public bool bCrawler;
	public /*const */bool bReducedSpeed;
	public bool bJumpCapable;
	public bool bCanJump;
	public bool bCanWalk;
	public bool bCanSwim;
	public bool bCanFly;
	public bool bCanClimbLadders;
	public bool bCanStrafe;
	public bool bAvoidLedges;
	public bool bStopAtLedges;
	public /*const */bool bSimulateGravity;
	public bool bIgnoreForces;
	public bool bCanWalkOffLedges;
	public bool bCanBeBaseForPawns;
	public /*const */bool bSimGravityDisabled;
	public bool bDirectHitWall;
	public /*const */bool bPushesRigidBodies;
	public bool bForceFloorCheck;
	public bool bForceKeepAnchor;
	public /*config */bool bCanMantle;
	public bool bCanClimbCeilings;
	public /*config */bool bCanSwatTurn;
	public /*config */bool bCanLeap;
	public /*config */bool bCanCoverSlip;
	public /*globalconfig */bool bDisplayPathErrors;
	public bool bIsFemale;
	public bool bCanPickupInventory;
	public bool bAmbientCreature;
	public/*(AI)*/ bool bLOSHearing;
	public/*(AI)*/ bool bMuffledHearing;
	public/*(AI)*/ bool bDontPossess;
	public bool bAutoFire;
	public bool bRollToDesired;
	public bool bStationary;
	public bool bCachedRelevant;
	public bool bSpecialHUD;
	public bool bNoWeaponFiring;
	public bool bCanUse;
	public bool bModifyReachSpecCost;
	public bool bPathfindsAsVehicle;
	public bool bRunPhysicsWithNoController;
	public bool bForceMaxAccel;
	public bool bForceRMVelocity;
	public bool bForceRegularVelocity;
	public bool bPlayedDeath;
	public /*const */float UncrouchTime;
	public float CrouchHeight;
	public float CrouchRadius;
	public /*const */int FullHeight;
	public float NonPreferredVehiclePathMultiplier;
	public Pawn.EPathSearchType PathSearchType;
	public /*const */byte RemoteViewPitch;
	public /*repnotify */byte FlashCount;
	public /*repnotify */byte FiringMode;
	public PathConstraint PathConstraintList;
	public PathGoalEvaluator PathGoalList;
	public float DesiredSpeed;
	public float MaxDesiredSpeed;
	public/*(AI)*/ float HearingThreshold;
	public/*(AI)*/ float Alertness;
	public/*(AI)*/ float SightRadius;
	public/*(AI)*/ float PeripheralVision;
	public /*const */float AvgPhysicsTime;
	public float Mass;
	public float Buoyancy;
	public float MeleeRange;
	public /*const */NavigationPoint Anchor;
	public /*const */NavigationPoint LastAnchor;
	public float FindAnchorFailedTime;
	public float LastValidAnchorTime;
	public float DestinationOffset;
	public float NextPathRadius;
	public Object.Vector SerpentineDir;
	public float SerpentineDist;
	public float SerpentineTime;
	public float SpawnTime;
	public int MaxPitchLimit;
	public float GroundSpeed;
	public float WaterSpeed;
	public float AirSpeed;
	public float LadderSpeed;
	public float AccelRate;
	public float JumpZ;
	public float OutofWaterZ;
	public float MaxOutOfWaterStepHeight;
	public float AirControl;
	public float WalkingPct;
	public float CrouchedPct;
	public float MaxFallSpeed;
	public float AIMaxFallSpeedFactor;
	public/*(Camera)*/ float BaseEyeHeight;
	public/*(Camera)*/ float EyeHeight;
	public Object.Vector Floor;
	public float SplashTime;
	public float OldZ;
	public /*transient */PhysicsVolume HeadVolume;
	public/*()*/ int Health;
	public/*()*/ int HealthMax;
	public float BreathTime;
	public float UnderWaterTime;
	public float LastPainTime;
	public Object.Vector RMVelocity;
	public /*export editinline */SceneCaptureCharacterComponent SceneCapture;
	public /*const export editinline */DrawFrustumComponent DrawFrustum;
	public /*const */Object.Vector noise1spot;
	public /*const */float noise1time;
	public /*const */Pawn noise1other;
	public /*const */float noise1loudness;
	public /*const */Object.Vector noise2spot;
	public /*const */float noise2time;
	public /*const */Pawn noise2other;
	public /*const */float noise2loudness;
	public float SoundDampening;
	public float DamageScaling;
	public /*const localized */String MenuName;
	public Core.ClassT<AIController> ControllerClass;
	public /*repnotify */PlayerReplicationInfo PlayerReplicationInfo;
	public LadderVolume OnLadder;
	public name LandMovementState;
	public name WaterMovementState;
	public PlayerStart LastStartSpot;
	public float LastStartTime;
	public Object.Vector TakeHitLocation;
	public Core.ClassT<DamageType> HitDamageType;
	public Object.Vector TearOffMomentum;
	public/*()*/ /*export editinline */SkeletalMeshComponent Mesh;
	public /*export editinline */CylinderComponent CylinderComponent;
	public/*()*/ float RBPushRadius;
	public/*()*/ float RBPushStrength;
	public /*repnotify */Vehicle DrivenVehicle;
	public float AlwaysRelevantDistanceSquared;
	public/*()*/ float VehicleCheckRadius;
	public Controller LastHitBy;
	public/*()*/ float ViewPitchMin;
	public/*()*/ float ViewPitchMax;
	public int AllowedYawError;
	public Core.ClassT<InventoryManager> InventoryManagerClass;
	public /*repnotify */InventoryManager InvManager;
	public/*()*/ Weapon Weapon;
	public /*repnotify */Object.Vector FlashLocation;
	public Object.Vector LastFiringFlashLocation;
	public int ShotCount;
	public /*export editinline */PrimitiveComponent PreRagdollCollisionComponent;
	public /*native const */Object.Pointer PhysicsPushBody;
	public int FailedLandingCount;
	
	//replication
	//{
	//	 if(bNetDirty && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		DrivenVehicle, FlashLocation, 
	//		Health, HitDamageType, 
	//		PlayerReplicationInfo, TakeHitLocation, 
	//		bIsWalking, bSimulateGravity;
	//
	//	 if((bNetDirty && bNetOwner) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		AccelRate, AirControl, 
	//		AirSpeed, Controller, 
	//		GroundSpeed, InvManager, 
	//		JumpZ, WaterSpeed;
	//
	//	 if((bNetDirty && (!bNetOwner || bDemoRecording)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		FiringMode, FlashCount, 
	//		bIsCrouched;
	//
	//	 if((bTearOff && bNetDirty) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		TearOffMomentum;
	//
	//	 if(((!bNetOwner || bDemoRecording)) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		RemoteViewPitch;
	//}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		base.ReplicatedEvent(VarName);
		if(VarName == "FlashCount")
		{
			FlashCountUpdated(true);		
		}
		else
		{
			if(VarName == "FlashLocation")
			{
				FlashLocationUpdated(true);			
			}
			else
			{
				if(VarName == "FiringMode")
				{
					FiringModeUpdated(true);				
				}
				else
				{
					if(VarName == "DrivenVehicle")
					{
						if(DrivenVehicle != default)
						{
							NotifyTeamChanged();
						}					
					}
					else
					{
						if(VarName == "PlayerReplicationInfo")
						{
							NotifyTeamChanged();						
						}
						else
						{
							if(VarName == "Controller")
							{
								if((Controller != default) && Controller.Pawn == default)
								{
									Controller.Pawn = this;
									if((((Controller) as PlayerController) != default) && ((Controller) as PlayerController).ViewTarget == Controller)
									{
										((Controller) as PlayerController).SetViewTarget(this, default(Camera.ViewTargetTransitionParams?));
									}
								}
							}
						}
					}
				}
			}
		}
	}
	
	// Export UPawn::execValidAnchor(FFrame&, void* const)
	public virtual /*native function */bool ValidAnchor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execSuggestJumpVelocity(FFrame&, void* const)
	public virtual /*native function */bool SuggestJumpVelocity(ref Object.Vector JumpVelocity, Object.Vector Destination, Object.Vector Start)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execIsValidTargetFor(FFrame&, void* const)
	public virtual /*native function */bool IsValidTargetFor(/*const */Controller C)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execIsValidEnemyTargetFor(FFrame&, void* const)
	public virtual /*native function */bool IsValidEnemyTargetFor(/*const */PlayerReplicationInfo PRI, bool bNoPRIisEnemy)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execIsInvisible(FFrame&, void* const)
	public virtual /*native function */bool IsInvisible()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execSetRemoteViewPitch(FFrame&, void* const)
	public virtual /*native final function */void SetRemoteViewPitch(int NewRemoteViewPitch)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execSetAnchor(FFrame&, void* const)
	public virtual /*native function */void SetAnchor(NavigationPoint NewAnchor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execGetBestAnchor(FFrame&, void* const)
	public virtual /*native function */NavigationPoint GetBestAnchor(Actor TestActor, Object.Vector TestLocation, bool bStartPoint, bool bOnlyCheckVisible, ref float out_Dist)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execReachedDestination(FFrame&, void* const)
	public virtual /*native function */bool ReachedDestination(Actor Goal)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execReachedPoint(FFrame&, void* const)
	public virtual /*native function */bool ReachedPoint(Object.Vector Point, Actor NewAnchor)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execForceCrouch(FFrame&, void* const)
	public virtual /*native function */void ForceCrouch()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execSetPushesRigidBodies(FFrame&, void* const)
	public virtual /*native function */void SetPushesRigidBodies(bool NewPush)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execGetBoundingCylinder(FFrame&, void* const)
	public override /*native function */void GetBoundingCylinder(ref float CollisionRadius, ref float CollisionHeight)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */int SpecialCostForPath(ReachSpec Path)
	{
		return Path.End.Nav.Cost;
	}
	
	public virtual /*simulated function */bool IsValidEnemy()
	{
		return true;
	}
	
	// Export UPawn::execInitRagdoll(FFrame&, void* const)
	public virtual /*native function */bool InitRagdoll()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPawn::execTermRagdoll(FFrame&, void* const)
	public virtual /*native function */bool TermRagdoll()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool SpecialMoveTo(NavigationPoint Start, NavigationPoint End, Actor Next)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void SetBaseEyeheight()
	{
		if(!bIsCrouched)
		{
			BaseEyeHeight = DefaultAs<Pawn>().BaseEyeHeight;		
		}
		else
		{
			BaseEyeHeight = FMin(0.80f * CrouchHeight, CrouchHeight - ((float)(10)));
		}
	}
	
	public virtual /*function */void PlayerChangedTeam()
	{
		Died(default, ClassT<DamageType>(), Location);
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? Pawn_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => Pawn_Reset;
	public /*function */void Pawn_Reset()
	{
		if(((Controller == default) || Controller.bIsPlayer))
		{
			DetachFromController(default(bool?));
			Destroy();		
		}
		else
		{
			/*Transformed 'base.' to specific call*/Actor_Reset();
		}
	}
	
	public virtual /*function */bool StopFiring()
	{
		if(Weapon != default)
		{
			Weapon.StopFire((byte)Weapon.CurrentFireMode);
		}
		return true;
	}
	
	// Export UPawn::execCreateHemiTexture(FFrame&, void* const)
	public virtual /*native final function */TextureRenderTarget2D CreateHemiTexture()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */void StartFire(byte FireModeNum)
	{
		if(bNoWeaponFiring)
		{
			return;
		}
		if(InvManager != default)
		{
			InvManager.StartFire((byte)FireModeNum);
		}
	}
	
	public virtual /*simulated function */void StopFire(byte FireModeNum)
	{
		if(InvManager != default)
		{
			InvManager.StopFire((byte)FireModeNum);
		}
	}
	
	public virtual /*simulated function */void SetFiringMode(byte FiringModeNum)
	{
		if(((int)FiringModeNum) != ((int)FiringMode))
		{
			FiringMode = (byte)FiringModeNum;
			bForceNetUpdate = true;
			FiringModeUpdated(false);
		}
	}
	
	public virtual /*simulated function */void FiringModeUpdated(bool bViaReplication)
	{
		if(Weapon != default)
		{
			Weapon.FireModeUpdated((byte)FiringMode, bViaReplication);
		}
	}
	
	public virtual /*simulated function */void IncrementFlashCount(Weapon Who, byte FireModeNum)
	{
		bForceNetUpdate = true;
		++ FlashCount;
		if(((int)FlashCount) == ((int)0))
		{
			FlashCount += 2;
		}
		SetFiringMode((byte)FireModeNum);
		FlashCountUpdated(false);
	}
	
	public virtual /*simulated function */void ClearFlashCount(Weapon Who)
	{
		if(((int)FlashCount) != ((int)0))
		{
			bForceNetUpdate = true;
			FlashCount = (byte)0;
			FlashCountUpdated(false);
		}
	}
	
	public virtual /*function */void SetFlashLocation(Weapon Who, byte FireModeNum, Object.Vector NewLoc)
	{
		if(NewLoc == LastFiringFlashLocation)
		{
			NewLoc += vect(0.0f, 0.0f, 1.0f);
		}
		if(NewLoc == vect(0.0f, 0.0f, 0.0f))
		{
			NewLoc = vect(0.0f, 0.0f, 1.0f);
		}
		bForceNetUpdate = true;
		FlashLocation = NewLoc;
		LastFiringFlashLocation = NewLoc;
		SetFiringMode((byte)FireModeNum);
		FlashLocationUpdated(false);
	}
	
	public virtual /*function */void ClearFlashLocation(Weapon Who)
	{
		if(!IsZero(FlashLocation))
		{
			bForceNetUpdate = true;
			FlashLocation = vect(0.0f, 0.0f, 0.0f);
			FlashLocationUpdated(false);
		}
	}
	
	public virtual /*simulated function */void FlashCountUpdated(bool bViaReplication)
	{
		if(((int)FlashCount) > ((int)0))
		{
			WeaponFired(bViaReplication, default(Object.Vector?));		
		}
		else
		{
			WeaponStoppedFiring(bViaReplication);
		}
	}
	
	public virtual /*simulated function */void FlashLocationUpdated(bool bViaReplication)
	{
		if(!IsZero(FlashLocation))
		{
			WeaponFired(bViaReplication, FlashLocation);		
		}
		else
		{
			WeaponStoppedFiring(bViaReplication);
		}
	}
	
	public virtual /*simulated function */void WeaponFired(bool bViaReplication, /*optional */Object.Vector? _HitLocation = default)
	{
		var HitLocation = _HitLocation ?? default;
		++ ShotCount;
		if(Weapon != default)
		{
			Weapon.PlayFireEffects((byte)FiringMode, HitLocation);
		}
	}
	
	public virtual /*simulated function */void WeaponStoppedFiring(bool bViaReplication)
	{
		ShotCount = 0;
		if(Weapon != default)
		{
			Weapon.StopFireEffects((byte)FiringMode);
		}
	}
	
	public virtual /*function */bool BotFire(bool bFinished)
	{
		StartFire((byte)ChooseFireMode());
		return true;
	}
	
	public virtual /*function */byte ChooseFireMode()
	{
		return 0;
	}
	
	public virtual /*function */bool CanAttack(Actor Other)
	{
		if(Weapon == default)
		{
			return false;
		}
		return Weapon.CanAttack(Other);
	}
	
	public virtual /*function */bool TooCloseToAttack(Actor Other)
	{
		return false;
	}
	
	public virtual /*function */bool FireOnRelease()
	{
		if(Weapon != default)
		{
			return Weapon.FireOnRelease();
		}
		return false;
	}
	
	public virtual /*function */bool HasRangedAttack()
	{
		return Weapon != default;
	}
	
	public virtual /*function */bool IsFiring()
	{
		if(Weapon != default)
		{
			return Weapon.IsFiring();
		}
		return false;
	}
	
	public virtual /*function */bool NeedToTurn(Object.Vector targ)
	{
		/*local */Object.Vector LookDir = default, AimDir = default;
	
		LookDir = ((Vector)(Rotation));
		LookDir.Z = 0.0f;
		LookDir = Normal(LookDir);
		AimDir = targ - Location;
		AimDir.Z = 0.0f;
		AimDir = Normal(AimDir);
		return (Dot(LookDir, AimDir)) < 0.930f;
	}
	
	public override /*simulated function */String GetHumanReadableName()
	{
		if(PlayerReplicationInfo != default)
		{
			return PlayerReplicationInfo.PlayerName;
		}
		return MenuName;
	}
	
	public override /*function */void PlayTeleportEffect(bool bOut, bool bSound)
	{
		MakeNoise(1.0f, default(name?));
	}
	
	public virtual /*simulated function */void NotifyTeamChanged()
	{
	
	}
	
	public virtual /*function */void PossessedBy(Controller C, bool bVehicleTransition)
	{
		Controller = C;
		NetPriority = 3.0f;
		NetUpdateFrequency = 100.0f;
		bForceNetUpdate = true;
		if(C.PlayerReplicationInfo != default)
		{
			PlayerReplicationInfo = C.PlayerReplicationInfo;
		}
		UpdateControllerOnPossess(bVehicleTransition);
		SetOwner(Controller);
		EyeHeight = BaseEyeHeight;
		if(C.IsA("PlayerController"))
		{
			if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_Standalone/*0*/))
			{
				RemoteRole = Actor.ENetRole.ROLE_AutonomousProxy/*2*/;
			}
			if(Weapon != default)
			{
				Weapon.ClientWeaponSet(false);
			}		
		}
		else
		{
			RemoteRole = ((Actor.ENetRole)DefaultAs<Actor>().RemoteRole);
		}
	}
	
	public virtual /*function */void UpdateControllerOnPossess(bool bVehicleTransition)
	{
		if(!bVehicleTransition)
		{
			Controller.SetRotation(Rotation);
		}
	}
	
	public virtual /*function */void UnPossessed()
	{
		bForceNetUpdate = true;
		if(DrivenVehicle != default)
		{
			NetUpdateFrequency = 5.0f;
		}
		PlayerReplicationInfo = default;
		SetOwner(default);
		Controller = default;
	}
	
	public virtual /*simulated function */name GetDefaultCameraMode(PlayerController RequestedBy)
	{
		if(((RequestedBy != default) && RequestedBy.PlayerCamera != default) && RequestedBy.PlayerCamera.CameraStyle == "Fixed")
		{
			return "Fixed";
		}
		return "FirstPerson";
	}
	
	public virtual /*function */void DropToGround()
	{
		bCollideWorld = true;
		if(Health > 0)
		{
			SetCollision(true, true, default(bool?));
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
			if(IsHumanControlled())
			{
				Controller.GotoState(LandMovementState, default(name?), default(bool?), default(bool?));
			}
		}
	}
	
	public virtual /*function */bool CanGrabLadder()
	{
		return ((bCanClimbLadders && Controller != default) && ((int)Physics) != ((int)Actor.EPhysics.PHYS_Ladder/*9*/)) && ((((int)Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/)) || Abs(Velocity.Z) <= JumpZ);
	}
	
	public virtual /*function */bool RecommendLongRangedAttack()
	{
		return false;
	}
	
	public virtual /*function */float RangedAttackTime()
	{
		return 0.0f;
	}
	
	public virtual /*event */void SetWalking(bool bNewIsWalking)
	{
		if(bNewIsWalking != bIsWalking)
		{
			bIsWalking = bNewIsWalking;
		}
	}
	
	public virtual /*event */bool GetIsWalkingFlagSet()
	{
		return bIsWalking;
	}
	
	public override /*simulated function */bool CanSplash()
	{
		if((((WorldInfo.TimeSeconds - SplashTime) > 0.150f) && ((((int)Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/)) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Flying/*4*/))) && Abs(Velocity.Z) > ((float)(100)))
		{
			SplashTime = WorldInfo.TimeSeconds;
			return true;
		}
		return false;
	}
	
	public virtual /*function */void EndClimbLadder(LadderVolume OldLadder)
	{
		if(Controller != default)
		{
			Controller.EndClimbLadder();
		}
		if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/))
		{
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		}
	}
	
	public virtual /*function */void ClimbLadder(LadderVolume L)
	{
		OnLadder = L;
		SetRotation(OnLadder.WallDir);
		SetPhysics(Actor.EPhysics.PHYS_Ladder/*9*/);
		if(IsHumanControlled())
		{
			Controller.GotoState("PlayerClimbing", default(name?), default(bool?), default(bool?));
		}
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */String T = default;
		/*local */Canvas Canvas = default;
		/*local */AnimTree AnimTreeRootNode = default;
		/*local */int I = default;
	
		Canvas = HUD.Canvas;
		if(PlayerReplicationInfo == default)
		{
			Canvas.DrawText("NO PLAYERREPLICATIONINFO", false, default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);		
		}
		else
		{
			PlayerReplicationInfo.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		}
		base.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		Canvas.SetDrawColor(255, 255, 255, (byte)default(byte?));
		Canvas.DrawText("Health " + ((Health)).ToString(), default(bool?), default(float?), default(float?));
		out_YPos += out_YL;
		Canvas.SetPos(4.0f, out_YPos);
		if(HUD.ShouldDisplayDebug("AI"))
		{
			Canvas.DrawText((((("Anchor " + ((Anchor)).ToString()) + " Serpentine Dist ") + ((SerpentineDist)).ToString()) + " Time ") + ((SerpentineTime)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
		if(HUD.ShouldDisplayDebug("Physics"))
		{
			T = (((("Floor " + ((Floor)).ToString()) + " DesiredSpeed ") + ((DesiredSpeed)).ToString()) + " Crouched ") + ((bIsCrouched)).ToString();
			if(((OnLadder != default) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/)))
			{
				T = (T + " on ladder ") + ((OnLadder)).ToString();
			}
			Canvas.DrawText(T, default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			T = "Collision Component:" + " " + ((CollisionComponent)).ToString();
			Canvas.DrawText(T, default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			T = "bForceMaxAccel:" + " " + ((bForceMaxAccel)).ToString();
			Canvas.DrawText(T, default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			if(Mesh != default)
			{
				T = (("RootMotionMode:" + " " + ((Mesh.RootMotionMode)).ToString()) + " " + "RootMotionVelocity:") + " " + ((Mesh.RootMotionVelocity)).ToString();
				Canvas.DrawText(T, default(bool?), default(float?), default(float?));
				out_YPos += out_YL;
				Canvas.SetPos(4.0f, out_YPos);
			}
		}
		if(HUD.ShouldDisplayDebug("Camera"))
		{
			Canvas.DrawText((("EyeHeight " + ((EyeHeight)).ToString()) + " BaseEyeHeight ") + ((BaseEyeHeight)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
		}
		if(Controller == default)
		{
			Canvas.SetDrawColor(255, 0, 0, (byte)default(byte?));
			Canvas.DrawText("NO CONTROLLER", default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			HUD.PlayerOwner.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);		
		}
		else
		{
			Controller.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
		}
		if(HUD.ShouldDisplayDebug("Weapon"))
		{
			if(Weapon == default)
			{
				Canvas.SetDrawColor(0, 255, 0, (byte)default(byte?));
				Canvas.DrawText("NO WEAPON", default(bool?), default(float?), default(float?));
				out_YPos += out_YL;
				Canvas.SetPos(4.0f, out_YPos);			
			}
			else
			{
				Weapon.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
			}
		}
		if(HUD.ShouldDisplayDebug("Animation"))
		{
			if((Mesh != default) && Mesh.Animations != default)
			{
				AnimTreeRootNode = ((Mesh.Animations) as AnimTree);
				if(AnimTreeRootNode != default)
				{
					Canvas.DrawText("AnimGroups count:" + " " + ((AnimTreeRootNode.AnimGroups.Length)).ToString(), default(bool?), default(float?), default(float?));
					out_YPos += out_YL;
					Canvas.SetPos(4.0f, out_YPos);
					I = 0;
					J0x6B4:{}
					if(I < AnimTreeRootNode.AnimGroups.Length)
					{
						Canvas.DrawText(((((" GroupName:" + " " + ((AnimTreeRootNode.AnimGroups[I].GroupName)).ToString()) + " " + "NodeCount:") + " " + ((AnimTreeRootNode.AnimGroups[I].SeqNodes.Length)).ToString()) + " " + "RateScale:") + " " + ((AnimTreeRootNode.AnimGroups[I].RateScale)).ToString(), default(bool?), default(float?), default(float?));
						out_YPos += out_YL;
						Canvas.SetPos(4.0f, out_YPos);
						++ I;
						goto J0x6B4;
					}
				}
			}
		}
	}
	
	//// Export UPawn::execIsHumanControlled(FFrame&, void* const)
	//public virtual /*native final simulated function */bool IsHumanControlled()
	//{
	//	#warning NATIVE FUNCTION !
	//	return default;
	//}
	//
	//// Export UPawn::execIsLocallyControlled(FFrame&, void* const)
	//public virtual /*native final simulated function */bool IsLocallyControlled()
	//{
	//	#warning NATIVE FUNCTION !
	//	return default;
	//}
	//
	//// Export UPawn::execIsPlayerPawn(FFrame&, void* const)
	//public virtual /*native simulated function */bool IsPlayerPawn()
	//{
	//	#warning NATIVE FUNCTION !
	//	return default;
	//}
	
	public virtual /*simulated function */bool WasPlayerPawn()
	{
		return false;
	}
	
	public virtual /*simulated function */bool IsFirstPerson()
	{
		/*local */PlayerController PC = default;
	
		PC = ((Controller) as PlayerController);
		return (PC != default) && PC.UsingFirstPersonCamera();
	}
	
	public virtual /*simulated function */void ProcessViewRotation(float DeltaTime, ref Object.Rotator out_ViewRotation, ref Object.Rotator out_DeltaRot)
	{
		out_ViewRotation += out_DeltaRot;
		out_DeltaRot = rot(0, 0, 0);
		if(((Controller) as PlayerController) != default)
		{
			out_ViewRotation = ((Controller) as PlayerController).LimitViewRotation(out_ViewRotation, ViewPitchMin, ViewPitchMax);
		}
	}
	
	public override /*simulated event */void GetActorEyesViewPoint(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
		out_Location = GetPawnViewLocation();
		out_Rotation = GetViewRotation();
	}
	
	public virtual /*simulated event */Object.Rotator GetViewRotation()
	{
		/*local */PlayerController PC = default;
	
		if(Controller != default)
		{
			return Controller.Rotation;		
		}
		else
		{
			if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				
				// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
				using var e46 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
				while(e46.MoveNext() && (PC = (PlayerController)e46.Current) == PC)
				{
					if(PC.ViewTarget == this)
					{					
						return PC.BlendedTargetViewRotation;
					}				
				}			
			}
		}
		return Rotation;
	}
	
	public virtual /*simulated event */Object.Vector GetPawnViewLocation()
	{
		return Location + (vect(0.0f, 0.0f, 1.0f) * BaseEyeHeight);
	}
	
	public virtual /*simulated function */Object.Vector GetWeaponStartTraceLocation(/*optional */Weapon? _CurrentWeapon = default)
	{
		/*local */Object.Vector POVLoc = default;
		/*local */Object.Rotator POVRot = default;
	
		var CurrentWeapon = _CurrentWeapon ?? default;
		if(Controller != default)
		{
			Controller.GetPlayerViewPoint(ref/*probably?*/ POVLoc, ref/*probably?*/ POVRot);
			return POVLoc;
		}
		return GetPawnViewLocation();
	}
	
	public virtual /*singular simulated function */Object.Rotator GetBaseAimRotation()
	{
		/*local */Object.Vector POVLoc = default;
		/*local */Object.Rotator POVRot = default;
	
		if((Controller != default) && !InFreeCam())
		{
			Controller.GetPlayerViewPoint(ref/*probably?*/ POVLoc, ref/*probably?*/ POVRot);
			return POVRot;
		}
		POVRot = Rotation;
		if(POVRot.Pitch == 0)
		{
			POVRot.Pitch = /*<<*/ShiftL(((int)RemoteViewPitch), ((int)8));
		}
		return POVRot;
	}
	
	public virtual /*simulated event */bool InFreeCam()
	{
		/*local */PlayerController PC = default;
	
		PC = ((Controller) as PlayerController);
		return ((PC != default) && PC.PlayerCamera != default) && PC.PlayerCamera.CameraStyle == "FreeCam";
	}
	
	public virtual /*simulated function */Object.Rotator GetAdjustedAimFor(Weapon W, Object.Vector StartFireLoc)
	{
		if(((Controller == default) || ((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/)))
		{
			return GetBaseAimRotation();
		}
		return Controller.GetAdjustedAimFor(W, StartFireLoc);
	}
	
	public virtual /*simulated function */void SetViewRotation(Object.Rotator NewRotation)
	{
		if(Controller != default)
		{
			Controller.SetRotation(NewRotation);		
		}
		else
		{
			SetRotation(NewRotation);
		}
	}
	
	public virtual /*simulated function */bool PawnCalcCamera(float fDeltaTime, ref Object.Vector out_CamLoc, ref Object.Rotator out_CamRot, ref float out_FOV)
	{
		return CalcCamera(fDeltaTime, ref/*probably?*/ out_CamLoc, ref/*probably?*/ out_CamRot, ref/*probably?*/ out_FOV);
	}
	
	public virtual /*function */bool InGodMode()
	{
		return (Controller != default) && Controller.bGodMode;
	}
	
	public virtual /*simulated function */bool AffectedByHitEffects()
	{
		return ((Controller == default) || Controller.bAffectedByHitEffects);
	}
	
	public virtual /*function */bool NearMoveTarget()
	{
		if(((Controller == default) || Controller.MoveTarget == default))
		{
			return false;
		}
		return ReachedDestination(Controller.MoveTarget);
	}
	
	public virtual /*function */Actor GetMoveTarget()
	{
		if(Controller == default)
		{
			return default;
		}
		return Controller.MoveTarget;
	}
	
	public virtual /*function */void SetMoveTarget(Actor NewTarget)
	{
		if(Controller != default)
		{
			Controller.MoveTarget = NewTarget;
		}
	}
	
	public virtual /*function */bool LineOfSightTo(Actor Other)
	{
		return (Controller != default) && Controller.LineOfSightTo(Other, default(Object.Vector?), default(bool?));
	}
	
	public virtual /*function */float AdjustedStrength()
	{
		return 0.0f;
	}
	
	public virtual /*function */void HandlePickup(Inventory Inv)
	{
		MakeNoise(0.20f, default(name?));
		if(Controller != default)
		{
			Controller.HandlePickup(Inv);
		}
	}
	
	public virtual /*function */void ReceiveLocalizedMessage(Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		var Switch = _Switch ?? default;
		var RelatedPRI_1 = _RelatedPRI_1 ?? default;
		var RelatedPRI_2 = _RelatedPRI_2 ?? default;
		var OptionalObject = _OptionalObject ?? default;
		if(((Controller) as PlayerController) != default)
		{
			((Controller) as PlayerController).ReceiveLocalizedMessage(Message, Switch, RelatedPRI_1, RelatedPRI_2, OptionalObject);
		}
	}
	
	public virtual /*event */void ClientMessage(/*coerce */String S, /*optional */name? _Type = default)
	{
		var Type = _Type ?? default;
		if(((Controller) as PlayerController) != default)
		{
			((Controller) as PlayerController).ClientMessage(S, Type, default(float?));
		}
	}
	
	public virtual /*function */void FinishedInterpolation()
	{
		DropToGround();
	}
	
	public virtual /*function */void JumpOutOfWater(Object.Vector jumpDir)
	{
		Falling();
		Velocity = jumpDir * WaterSpeed;
		Acceleration = jumpDir * AccelRate;
		Velocity.Z = OutofWaterZ;
		bUpAndOut = true;
	}
	
	public virtual /*simulated event */void ModifyVelocity(float DeltaTime, Object.Vector OldVelocity)
	{
	
	}
	
	public override FellOutOfWorld_del FellOutOfWorld { get => bfield_FellOutOfWorld ?? Pawn_FellOutOfWorld; set => bfield_FellOutOfWorld = value; } FellOutOfWorld_del bfield_FellOutOfWorld;
	public override FellOutOfWorld_del global_FellOutOfWorld => Pawn_FellOutOfWorld;
	public /*simulated event */void Pawn_FellOutOfWorld(Core.ClassT<DamageType> dmgType)
	{
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			Health = -1;
			Died(default, dmgType, Location);
			if(dmgType == default)
			{
				SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
				SetHidden(true);
				LifeSpan = FMin(LifeSpan, 1.0f);
			}
		}
	}
	
	public override OutsideWorldBounds_del OutsideWorldBounds { get => bfield_OutsideWorldBounds ?? Pawn_OutsideWorldBounds; set => bfield_OutsideWorldBounds = value; } OutsideWorldBounds_del bfield_OutsideWorldBounds;
	public override OutsideWorldBounds_del global_OutsideWorldBounds => Pawn_OutsideWorldBounds;
	public /*singular simulated event */void Pawn_OutsideWorldBounds()
	{
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			KilledBy(this);
		}
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetHidden(true);
		LifeSpan = FMin(LifeSpan, 1.0f);
	}
	
	public virtual /*simulated function */void UnCrouch()
	{
		if((bIsCrouched || bWantsToCrouch))
		{
			ShouldCrouch(false);
		}
	}
	
	public virtual /*function */void ShouldCrouch(bool bCrouch)
	{
		bWantsToCrouch = bCrouch;
	}
	
	public virtual /*simulated event */void EndCrouch(float HeightAdjust)
	{
		EyeHeight -= HeightAdjust;
		OldZ += HeightAdjust;
		SetBaseEyeheight();
	}
	
	public virtual /*simulated event */void StartCrouch(float HeightAdjust)
	{
		EyeHeight += HeightAdjust;
		OldZ -= HeightAdjust;
		SetBaseEyeheight();
	}
	
	public virtual /*function */void RestartPlayer()
	{
	
	}
	
	public virtual /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		var HitInfo = _HitInfo ?? default;
		if((bIgnoreForces || NewVelocity == vect(0.0f, 0.0f, 0.0f)))
		{
			return;
		}
		if(((((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || (((((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/)) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Spider/*8*/))) && NewVelocity.Z > DefaultAs<Pawn>().JumpZ))
		{
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		}
		if((Velocity.Z > DefaultAs<Pawn>().JumpZ) && NewVelocity.Z > ((float)(0)))
		{
			NewVelocity.Z *= 0.50f;
		}
		Velocity += NewVelocity;
	}
	
	public override KilledBy_del KilledBy { get => bfield_KilledBy ?? Pawn_KilledBy; set => bfield_KilledBy = value; } KilledBy_del bfield_KilledBy;
	public override KilledBy_del global_KilledBy => Pawn_KilledBy;
	public /*function */void Pawn_KilledBy(Pawn EventInstigator)
	{
		/*local */Controller Killer = default;
	
		Health = 0;
		if(EventInstigator != default)
		{
			Killer = EventInstigator.Controller;
			LastHitBy = default;
		}
		Died(Killer, ClassT<DmgType_Suicided>(), Location);
	}
	
	public virtual /*function */void TakeFallingDamage()
	{
		/*local */float EffectiveSpeed = default;
	
		if(Velocity.Z < (-0.50f * MaxFallSpeed))
		{
			if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				MakeNoise(1.0f, default(name?));
				if(Velocity.Z < (((float)(-1)) * MaxFallSpeed))
				{
					EffectiveSpeed = Velocity.Z;
					if(TouchingWaterVolume())
					{
						EffectiveSpeed += ((float)(100));
					}
					if(EffectiveSpeed < (((float)(-1)) * MaxFallSpeed))
					{
						TakeDamage(((int)((((float)(-100)) * (EffectiveSpeed + MaxFallSpeed)) / MaxFallSpeed)), default, Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Fell>(), default(Actor.TraceHitInfo?), default(Actor?));
					}
				}
			}		
		}
		else
		{
			if(Velocity.Z < (-1.40f * JumpZ))
			{
				MakeNoise(0.50f, default(name?));			
			}
			else
			{
				if(Velocity.Z < (-0.80f * JumpZ))
				{
					MakeNoise(0.20f, default(name?));
				}
			}
		}
	}
	
	public virtual /*function */void Restart()
	{
	
	}
	
	public virtual /*simulated function */void ClientRestart()
	{
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		SetBaseEyeheight();
	}
	
	public virtual /*function */void ClientSetLocation(Object.Vector NewLocation, Object.Rotator NewRotation)
	{
		if(Controller != default)
		{
			Controller.ClientSetLocation(NewLocation, NewRotation);
		}
	}
	
	public virtual /*function */void ClientSetRotation(Object.Rotator NewRotation)
	{
		if(Controller != default)
		{
			Controller.ClientSetRotation(NewRotation, default(bool?));
		}
	}
	
	public virtual /*simulated function */void FaceRotation(Object.Rotator NewRotation, float DeltaTime)
	{
		if(!InFreeCam())
		{
			if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/))
			{
				NewRotation = OnLadder.WallDir;			
			}
			else
			{
				if(((((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/)))
				{
					NewRotation.Pitch = 0;
				}
			}
			SetRotation(NewRotation);
		}
	}
	
	public override /*event */bool EncroachingOn(Actor Other)
	{
		if((Other.bWorldGeometry || Other.bBlocksTeleport))
		{
			return true;
		}
		if((((Controller == default) || !Controller.bIsPlayer)) && ((Other) as Pawn) != default)
		{
			return true;
		}
		return false;
	}
	
	public override /*event */void EncroachedBy(Actor Other)
	{
		if((((Other) as Pawn) != default) && ((Other) as Vehicle) == default)
		{
			gibbedBy(Other);
		}
	}
	
	public virtual /*function */void gibbedBy(Actor Other)
	{
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		if(((Other) as Pawn) != default)
		{
			Died(((Other) as Pawn).Controller, ClassT<DmgType_Telefragged>(), Location);		
		}
		else
		{
			Died(default, ClassT<DmgType_Telefragged>(), Location);
		}
	}
	
	public virtual /*function */void JumpOffPawn()
	{
		Velocity += ((((float)(100)) + CylinderComponent.CollisionRadius) * VRand());
		if(VSize2D(Velocity) > FMax(500.0f, GroundSpeed))
		{
			Velocity = FMax(500.0f, GroundSpeed) * Normal(Velocity);
		}
		Velocity.Z = 200.0f + CylinderComponent.CollisionHeight;
		SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
	}
	
	public virtual /*event */void StuckOnPawn(Pawn OtherPawn)
	{
	
	}
	
	public override BaseChange_del BaseChange { get => bfield_BaseChange ?? Pawn_BaseChange; set => bfield_BaseChange = value; } BaseChange_del bfield_BaseChange;
	public override BaseChange_del global_BaseChange => Pawn_BaseChange;
	public /*singular event */void Pawn_BaseChange()
	{
		/*local */DynamicSMActor Dyn = default;
	
		if((((Base) as Pawn) != default) && ((DrivenVehicle == default) || !DrivenVehicle.IsBasedOn(Base)))
		{
			if(!((Base) as Pawn).CanBeBaseForPawn(this))
			{
				((Base) as Pawn).CrushedBy(this);
				JumpOffPawn();
			}
		}
		Dyn = ((Base) as DynamicSMActor);
		if((Dyn != default) && !Dyn.CanBasePawn(this))
		{
			JumpOffPawn();
		}
	}
	
	public virtual /*simulated function */bool CanBeBaseForPawn(Pawn aPawn)
	{
		return bCanBeBaseForPawns;
	}
	
	public virtual /*function */void CrushedBy(Pawn OtherPawn)
	{
		TakeDamage(((int)(((((float)(1)) - (OtherPawn.Velocity.Z / ((float)(400)))) * OtherPawn.Mass) / Mass)), OtherPawn.Controller, Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Crushed>(), default(Actor.TraceHitInfo?), default(Actor?));
	}
	
	public virtual /*function */void DetachFromController(/*optional */bool? _bDestroyController = default)
	{
		/*local */Controller OldController = default;
	
		var bDestroyController = _bDestroyController ?? default;
		if((Controller != default) && Controller.Pawn == this)
		{
			OldController = Controller;
			Controller.PawnDied(this);
			if(Controller != default)
			{
				Controller.UnPossess();
			}
			if(((bDestroyController && OldController != default) && !OldController.bDeleteMe) && !OldController.bIsPlayer)
			{
				OldController.Destroy();
			}
			Controller = default;
		}
	}
	
	public override /*simulated event */void Destroyed()
	{
		DetachFromController(default(bool?));
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))
		{
			return;
		}
		if(InvManager != default)
		{
			InvManager.Destroy();
		}
		SetAnchor(default);
		SetWeapon(default);
		ClearPathStep();
		base.Destroyed();
	}
	
	public virtual /*simulated function */void SetWeapon(Weapon W)
	{
		Weapon = W;
	}
	
	public override /*simulated event */void PreBeginPlay()
	{
		if(HealthMax == 0)
		{
			HealthMax = DefaultAs<Pawn>().Health;
		}
		base.PreBeginPlay();
		Instigator = this;
		DesiredRotation = Rotation;
		EyeHeight = BaseEyeHeight;
	}
	
	public override /*event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		SplashTime = 0.0f;
		SpawnTime = WorldInfo.TimeSeconds;
		EyeHeight = BaseEyeHeight;
		if((WorldInfo.bStartup && Health > 0) && !bDontPossess)
		{
			SpawnDefaultController();
		}
		if(((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && InvManager == default) && InventoryManagerClass != default)
		{
			InvManager = Spawn(InventoryManagerClass, this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
			if(InvManager == default)
			{			
			}
			else
			{
				InvManager.SetupFor(this);
			}
		}
		ClearPathStep();
	}
	
	public virtual /*function */void SpawnDefaultController()
	{
		if(Controller != default)
		{
			return;
		}
		if(ControllerClass != default)
		{
			Controller = Spawn(ControllerClass, default(Actor?), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
		}
		if(Controller != default)
		{
			Controller.Possess(this, false);
		}
	}
	
	public virtual /*function */void OnAssignController(SeqAct_AssignController inAction)
	{
		if(inAction.ControllerClass != default)
		{
			if(Controller != default)
			{
				DetachFromController(true);
			}
			Controller = Spawn(inAction.ControllerClass, default(Actor?), default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
			Controller.Possess(this, false);
			if(Controller.IsA("AIController"))
			{
				ControllerClass = ((Controller.Class) as ClassT<AIController>);
			}		
		}
	}
	
	public virtual /*simulated function */void OnGiveInventory(SeqAct_GiveInventory inAction)
	{
		/*local */int Idx = default;
		/*local */Core.ClassT<Inventory> InvClass = default;
	
		if(inAction.bClearExisting)
		{
			InvManager.DiscardInventory();
		}
		if(inAction.InventoryList.Length > 0)
		{
			Idx = 0;
			J0x44:{}
			if(Idx < inAction.InventoryList.Length)
			{
				InvClass = inAction.InventoryList[Idx];
				if(InvClass != default)
				{
					if(FindInventoryType(InvClass, false) == default)
					{
						CreateInventory(InvClass, default(bool?));
					}
					goto J0xE3;
				}
				inAction.ScriptLog("WARNING: Attempting to give NULL inventory!", default(bool?));
				J0xE3:{}
				++ Idx;
				goto J0x44;
			}		
		}
		else
		{
			inAction.ScriptLog("WARNING: Give Inventory without any inventory specified!", default(bool?));
		}
	}
	
	public virtual /*function */void Gasp()
	{
	
	}
	
	public virtual /*function */void SetMovementPhysics()
	{
		if(PhysicsVolume.bWaterVolume)
		{
			SetPhysics(Actor.EPhysics.PHYS_Swimming/*3*/);		
		}
		else
		{
			if(((int)Physics) != ((int)Actor.EPhysics.PHYS_Falling/*2*/))
			{
				SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
			}
		}
	}
	
	public virtual /*function */void AdjustDamage(ref int inDamage, ref Object.Vector Momentum, Controller InstigatedBy, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		var HitInfo = _HitInfo ?? default;
	}
	
	public override /*function */bool HealDamage(int Amount, Controller Healer, Core.ClassT<DamageType> DamageType)
	{
		if((Health > 0) && Health < HealthMax)
		{
			Health = Min(HealthMax, Health + Amount);
			return true;		
		}
		else
		{
			return false;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */void PruneDamagedBoneList(ref array<name> Bones)
	{
	
	}
	
	public virtual /*event */bool TakeRadiusDamageOnBones(Controller InstigatedBy, float BaseDamage, float DamageRadius, Core.ClassT<DamageType> DamageType, float Momentum, Object.Vector HurtOrigin, bool bFullDamage, Actor DamageCauser, array<name> Bones)
	{
		/*local */int Idx = default;
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */bool bResult = default;
		/*local */float DamageScale = default, Dist = default;
		/*local */Object.Vector Dir = default, BoneLoc = default;
	
		PruneDamagedBoneList(ref/*probably?*/ Bones);
		Idx = 0;
		J0x16:{}
		if(Idx < Bones.Length)
		{
			HitInfo.BoneName = Bones[Idx];
			HitInfo.HitComponent = Mesh;
			BoneLoc = Mesh.GetBoneLocation(Bones[Idx], default(int?));
			Dir = BoneLoc - HurtOrigin;
			Dist = VSize(Dir);
			Dir = Normal(Dir);
			if(bFullDamage)
			{
				DamageScale = 1.0f;			
			}
			else
			{
				DamageScale = 1.0f - (Dist / DamageRadius);
			}
			if(DamageScale > 0.0f)
			{
				TakeDamage(((int)(DamageScale * BaseDamage)), InstigatedBy, BoneLoc, (DamageScale * Momentum) * Dir, DamageType, HitInfo, DamageCauser);
			}
			bResult = true;
			++ Idx;
			goto J0x16;
		}
		return bResult;
	}
	
	public virtual /*function */void NotifyTakeHit(Controller InstigatedBy, Object.Vector HitLocation, int Damage, Core.ClassT<DamageType> DamageType, Object.Vector Momentum)
	{
		if(Controller != default)
		{
			Controller.NotifyTakeHit(InstigatedBy, HitLocation, Damage, DamageType, Momentum);
		}
	}
	
	public virtual /*function */Controller SetKillInstigator(Controller InstigatedBy, Core.ClassT<DamageType> DamageType)
	{
		if((InstigatedBy != default) && InstigatedBy != Controller)
		{
			return InstigatedBy;		
		}
		else
		{
			if(DamageType.DefaultAs<DamageType>().bCausedByWorld && LastHitBy != default)
			{
				return LastHitBy;
			}
		}
		return InstigatedBy;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? Pawn_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => Pawn_TakeDamage;
	public /*event */void Pawn_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
		/*local */int actualDamage = default;
		/*local */PlayerController PC = default;
		/*local */Controller Killer = default;
	
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		if(((((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/)) || Health <= 0))
		{
			return;
		}
		if(DamageType == default)
		{
			DamageType = ClassT<DamageType>();
		}
		Damage = Max(Damage, 0);
		if((((int)Physics) == ((int)Actor.EPhysics.PHYS_None/*0*/)) && DrivenVehicle == default)
		{
			SetMovementPhysics();
		}
		if((((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) && DamageType.DefaultAs<DamageType>().bExtraMomentumZ)
		{
			Momentum.Z = FMax(Momentum.Z, 0.40f * VSize(Momentum));
		}
		Momentum = Momentum / Mass;
		if(DrivenVehicle != default)
		{
			DrivenVehicle.AdjustDriverDamage(ref/*probably?*/ Damage, InstigatedBy, HitLocation, ref/*probably?*/ Momentum, DamageType);
		}
		actualDamage = Damage;
		WorldInfo.Game.ReduceDamage(ref/*probably?*/ actualDamage, this, InstigatedBy, HitLocation, ref/*probably?*/ Momentum, DamageType);
		AdjustDamage(ref/*probably?*/ actualDamage, ref/*probably?*/ Momentum, InstigatedBy, HitLocation, DamageType, HitInfo);
		/*Transformed 'base.' to specific call*/Actor_TakeDamage(actualDamage, InstigatedBy, HitLocation, Momentum, DamageType, HitInfo, DamageCauser);
		Health -= actualDamage;
		if(HitLocation == vect(0.0f, 0.0f, 0.0f))
		{
			HitLocation = Location;
		}
		if(Health <= 0)
		{
			PC = ((Controller) as PlayerController);
			if(PC != default)
			{
				PC.ClientPlayForceFeedbackWaveform(DamageType.DefaultAs<DamageType>().KilledFFWaveform);
			}
			Killer = SetKillInstigator(InstigatedBy, DamageType);
			TearOffMomentum = Momentum;
			Died(Killer, DamageType, HitLocation);		
		}
		else
		{
			AddVelocity(Momentum, HitLocation, DamageType, HitInfo);
			NotifyTakeHit(InstigatedBy, HitLocation, actualDamage, DamageType, Momentum);
			if(DrivenVehicle != default)
			{
				DrivenVehicle.NotifyDriverTakeHit(InstigatedBy, HitLocation, actualDamage, DamageType, Momentum);
			}
			if((InstigatedBy != default) && InstigatedBy != Controller)
			{
				LastHitBy = InstigatedBy;
			}
		}
		PlayHit(((float)(actualDamage)), InstigatedBy, HitLocation, DamageType, Momentum, HitInfo);
		MakeNoise(1.0f, default(name?));
	}
	
	// Export UPawn::execGetTeamNum(FFrame&, void* const)
	public override /*native simulated function */byte GetTeamNum()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*simulated function */TeamInfo GetTeam()
	{
		if((Controller != default) && Controller.PlayerReplicationInfo != default)
		{
			return Controller.PlayerReplicationInfo.Team;		
		}
		else
		{
			if(PlayerReplicationInfo != default)
			{
				return PlayerReplicationInfo.Team;			
			}
			else
			{
				if((DrivenVehicle != default) && DrivenVehicle.PlayerReplicationInfo != default)
				{
					return DrivenVehicle.PlayerReplicationInfo.Team;				
				}
				else
				{
					return default;
				}
			}
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*simulated event */bool IsSameTeam(Pawn Other)
	{
		return ((Other != default) && Other.GetTeam() != default) && Other.GetTeam() == (GetTeam());
	}
	
	public delegate bool Died_del(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation);
	public virtual Died_del Died { get => bfield_Died ?? Pawn_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public virtual Died_del global_Died => Pawn_Died;
	public /*function */bool Pawn_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		/*local */SeqAct_Latent Action = default;
	
		if(Killer != default)
		{
			Killer = Killer.GetKillerController();
		}
		if(DamageType == default)
		{
			DamageType = ClassT<DamageType>();
		}
		if((((bDeleteMe || WorldInfo.Game == default)) || WorldInfo.Game.bLevelChange))
		{
			return false;
		}
		if((DamageType.DefaultAs<DamageType>().bCausedByWorld && ((Killer == default) || Killer == Controller)) && LastHitBy != default)
		{
			Killer = LastHitBy;
		}
		if(WorldInfo.Game.PreventDeath(this, Killer, DamageType, HitLocation))
		{
			Health = Max(Health, 1);
			return false;
		}
		Health = Min(0, Health);
		TriggerEventClass(ClassT<SeqEvent_Death>(), this, default(int?), default(bool?), ref/*probably?*/ /*null*/NullRef.array_SequenceEvent_);
		using var v = LatentActions.GetEnumerator();while(v.MoveNext() && (Action = (SeqAct_Latent)v.Current) == Action)
		{
			Action.AbortFor(this);		
		}	
		LatentActions.Length = 0;
		if(DrivenVehicle != default)
		{
			Velocity = DrivenVehicle.Velocity;
			DrivenVehicle.DriverDied();		
		}
		else
		{
			if(Weapon != default)
			{
				Weapon.HolderDied();
				ThrowActiveWeapon(DamageType);
			}
		}
		if(Controller != default)
		{
			WorldInfo.Game.Killed(Killer, Controller, this, DamageType);		
		}
		else
		{
			WorldInfo.Game.Killed(Killer, ((Owner) as Controller), this, DamageType);
		}
		DrivenVehicle = default;
		if(InvManager != default)
		{
			InvManager.OwnerEvent("Died");
		}
		Velocity.Z *= 1.30f;
		if(IsHumanControlled())
		{
			((Controller) as PlayerController).ForceDeathUpdate();
		}
		NetUpdateFrequency = DefaultAs<Actor>().NetUpdateFrequency;
		PlayDying(DamageType, HitLocation);
		return true;
	}
	
	public override /*event */void Falling()
	{
	
	}
	
	public override /*event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
	
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? Pawn_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => Pawn_Landed;
	public /*event */void Pawn_Landed(Object.Vector HitNormal, Actor FloorActor)
	{
		TakeFallingDamage();
		if(Health > 0)
		{
			PlayLanded(Velocity.Z);
		}
		LastHitBy = default;
	}
	
	public virtual /*event */void HeadVolumeChange(PhysicsVolume newHeadVolume)
	{
		if(((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/)) || Controller == default))
		{
			return;
		}
		if(HeadVolume.bWaterVolume)
		{
			if(!newHeadVolume.bWaterVolume)
			{
				if((Controller.bIsPlayer && BreathTime > ((float)(0))) && BreathTime < ((float)(8)))
				{
					Gasp();
				}
				BreathTime = -1.0f;
			}		
		}
		else
		{
			if(newHeadVolume.bWaterVolume)
			{
				BreathTime = UnderWaterTime;
			}
		}
	}
	
	public virtual /*function */bool TouchingWaterVolume()
	{
		/*local */PhysicsVolume V = default;
	
		
		// foreach TouchingActors(ClassT<PhysicsVolume>(), ref/*probably?*/ V)
		using var e0 = TouchingActors(ClassT<PhysicsVolume>()).GetEnumerator();
		while(e0.MoveNext() && (V = (PhysicsVolume)e0.Current) == V)
		{
			if(V.bWaterVolume)
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public override /*function */bool IsInPain()
	{
		/*local */PhysicsVolume V = default;
	
		
		// foreach TouchingActors(ClassT<PhysicsVolume>(), ref/*probably?*/ V)
		using var e0 = TouchingActors(ClassT<PhysicsVolume>()).GetEnumerator();
		while(e0.MoveNext() && (V = (PhysicsVolume)e0.Current) == V)
		{
			if(V.bPainCausing && V.DamagePerSec > ((float)(0)))
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public delegate void BreathTimer_del();
	public virtual BreathTimer_del BreathTimer { get => bfield_BreathTimer ?? Pawn_BreathTimer; set => bfield_BreathTimer = value; } BreathTimer_del bfield_BreathTimer;
	public virtual BreathTimer_del global_BreathTimer => Pawn_BreathTimer;
	public /*event */void Pawn_BreathTimer()
	{
		if(HeadVolume.bWaterVolume)
		{
			if(((((Health < 0) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_Client/*3*/))) || DrivenVehicle != default))
			{
				return;
			}
			TakeDrowningDamage();
			if(Health > 0)
			{
				BreathTime = 2.0f;
			}		
		}
		else
		{
			BreathTime = 0.0f;
		}
	}
	
	public virtual /*function */void TakeDrowningDamage()
	{
	
	}
	
	public virtual /*function */bool CheckWaterJump(ref Object.Vector WallNormal)
	{
		/*local */Actor HitActor = default;
		/*local */Object.Vector HitLocation = default, HitNormal = default, Checkpoint = default, Start = default, checkNorm = default, Extent = default;
	
		if(((Controller) as AIController) != default)
		{
			if((Controller.InLatentExecution(/*maybe?*/Controller.LATENT_MOVETOWARD) && Controller.MoveTarget != default) && !Controller.MoveTarget.PhysicsVolume.bWaterVolume)
			{
				Checkpoint = Normal(Controller.MoveTarget.Location - Location);			
			}
			else
			{
				Checkpoint = Acceleration;
			}
			Checkpoint.Z = 0.0f;
		}
		if(Checkpoint == vect(0.0f, 0.0f, 0.0f))
		{
			Checkpoint = ((Vector)(Rotation));
		}
		Checkpoint.Z = 0.0f;
		checkNorm = Normal(Checkpoint);
		Checkpoint = Location + ((1.20f * CylinderComponent.CollisionRadius) * checkNorm);
		Extent = CylinderComponent.CollisionRadius * vect(1.0f, 1.0f, 0.0f);
		Extent.Z = CylinderComponent.CollisionHeight;
		HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, Checkpoint, Location, true, Extent, ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, 8);
		if((HitActor != default) && ((HitActor) as Pawn) == default)
		{
			WallNormal = ((float)(-1)) * HitNormal;
			Start = Location;
			Start.Z += MaxOutOfWaterStepHeight;
			Checkpoint = Start + ((3.20f * CylinderComponent.CollisionRadius) * WallNormal);
			HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, Checkpoint, Start, true, default(Object.Vector?), ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, 8);
			if(((HitActor == default) || HitNormal.Z > 0.70f))
			{
				return true;
			}
		}
		return false;
	}
	
	public virtual /*function */bool DoJump(bool bUpdating)
	{
		if(((bJumpCapable && !bIsCrouched) && !bWantsToCrouch) && ((((((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/))) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Spider/*8*/)))
		{
			if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Spider/*8*/))
			{
				Velocity = JumpZ * Floor;			
			}
			else
			{
				if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/))
				{
					Velocity.Z = 0.0f;				
				}
				else
				{
					if(bIsWalking)
					{
						Velocity.Z = DefaultAs<Pawn>().JumpZ;					
					}
					else
					{
						Velocity.Z = JumpZ;
					}
				}
			}
			if(((Base != default) && !Base.bWorldGeometry) && Base.Velocity.Z > 0.0f)
			{
				Velocity.Z += Base.Velocity.Z;
			}
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
			return true;
		}
		return false;
	}
	
	public virtual /*function */void PlayDyingSound()
	{
	
	}
	
	public virtual /*function */void PlayHit(float Damage, Controller InstigatedBy, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, Object.Vector Momentum, Actor.TraceHitInfo HitInfo)
	{
		if((Damage <= ((float)(0))) && ((Controller == default) || !Controller.bGodMode))
		{
			return;
		}
		LastPainTime = WorldInfo.TimeSeconds;
	}
	
	public virtual /*simulated function */void TurnOff()
	{
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy/*1*/;
		}
		if((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) && Mesh != default)
		{
			Mesh.bPauseAnims = true;
			if(((int)Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
			{
				Mesh.PhysicsWeight = 1.0f;
				Mesh.bUpdateKinematicBonesFromAnimation = false;
			}
		}
		SetCollision(true, false, default(bool?));
		bNoWeaponFiring = true;
		Velocity = vect(0.0f, 0.0f, 0.0f);
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		bIgnoreForces = true;
		if(Weapon != default)
		{
			Weapon.StopFire((byte)Weapon.CurrentFireMode);
		}
	}
	
	public virtual /*simulated function */void PlayDying(Core.ClassT<DamageType> DamageType, Object.Vector HitLoc)
	{
		GotoState("Dying", default(name?), default(bool?), default(bool?));
		bReplicateMovement = false;
		bTearOff = true;
		Velocity += TearOffMomentum;
		SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		bPlayedDeath = true;
	}
	
	public override /*simulated event */void TornOff()
	{
		if(!bPlayedDeath)
		{
			PlayDying(HitDamageType, TakeHitLocation);
		}
	}
	
	public virtual /*event */void PlayFootStepSound(int FootDown)
	{
	
	}
	
	public virtual /*function */bool CannotJumpNow()
	{
		return false;
	}
	
	public virtual /*function */void PlayLanded(float ImpactVel)
	{
	
	}
	
	// Export UPawn::execGetVehicleBase(FFrame&, void* const)
	public virtual /*native function */Vehicle GetVehicleBase()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void Suicide()
	{
		KilledBy(this);
	}
	
	public virtual /*simulated function */bool CanThrowWeapon()
	{
		return (Weapon != default) && Weapon.CanThrow();
	}
	
	public virtual /*simulated event */void StartDriving(Vehicle V)
	{
		StopFiring();
		if(Health <= 0)
		{
			return;
		}
		DrivenVehicle = V;
		bForceNetUpdate = true;
		ShouldCrouch(false);
		bIgnoreForces = true;
		bCanTeleport = false;
		BreathTime = 0.0f;
		V.AttachDriver(this);
	}
	
	public virtual /*simulated event */void StopDriving(Vehicle V)
	{
		if(Mesh != default)
		{
			Mesh.SetCullDistance(DefaultAs<Pawn>().Mesh.CachedCullDistance);
			Mesh.SetShadowParent(default);
		}
		bForceNetUpdate = true;
		if(V != default)
		{
			V.StopFiring();
		}
		if(((int)Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			return;
		}
		DrivenVehicle = default;
		bIgnoreForces = false;
		SetHardAttach(false);
		bCanTeleport = true;
		bCollideWorld = true;
		if(V != default)
		{
			V.DetachDriver(this);
		}
		SetCollision(true, true, default(bool?));
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			if(PhysicsVolume.bWaterVolume && Health > 0)
			{
				SetPhysics(Actor.EPhysics.PHYS_Swimming/*3*/);			
			}
			else
			{
				SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
			}
			SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent?), default(name?));
			SetHidden(false);
		}
	}
	
	public virtual /*function */void AddDefaultInventory()
	{
	
	}
	
	public virtual /*final event */Inventory CreateInventory(Core.ClassT<Inventory> NewInvClass, /*optional */bool? _bDoNotActivate = default)
	{
		var bDoNotActivate = _bDoNotActivate ?? default;
		if(InvManager != default)
		{
			return InvManager.CreateInventory(NewInvClass, bDoNotActivate);
		}
		return default;
	}
	
	public virtual /*final simulated function */Inventory FindInventoryType(Core.ClassT<Inventory> DesiredClass, /*optional */bool? _bAllowSubclass = default)
	{
		var bAllowSubclass = _bAllowSubclass ?? default;
		return ((InvManager != default) ? InvManager.FindInventoryType(DesiredClass, bAllowSubclass) : default);
	}
	
	public virtual /*simulated function */void DrawHUD(HUD H)
	{
		if(InvManager != default)
		{
			InvManager.DrawHUD(H);
		}
	}
	
	public virtual /*function */void ThrowActiveWeapon(/*optional */Core.ClassT<DamageType>? _DamageType = default)
	{
		var DamageType = _DamageType ?? default;
		if(Weapon != default)
		{
			TossInventory(Weapon, default(Object.Vector?), DamageType);
		}
	}
	
	public virtual /*function */void TossInventory(Inventory Inv, /*optional */Object.Vector? _ForceVelocity = default, /*optional */Core.ClassT<DamageType>? _DamageType = default)
	{
		/*local */Object.Vector POVLoc = default, TossVel = default;
		/*local */Object.Rotator POVRot = default;
		/*local */Object.Vector X = default, Y = default, Z = default;
	
		var ForceVelocity = _ForceVelocity ?? default;
		var DamageType = _DamageType ?? default;
		if(ForceVelocity != vect(0.0f, 0.0f, 0.0f))
		{
			TossVel = ForceVelocity;		
		}
		else
		{
			GetActorEyesViewPoint(ref/*probably?*/ POVLoc, ref/*probably?*/ POVRot);
			TossVel = ((Vector)(POVRot));
			TossVel = (TossVel * ((Dot(Velocity, TossVel)) + ((float)(500)))) + vect(0.0f, 0.0f, 200.0f);
		}
		GetAxes(Rotation, ref/*probably?*/ X, ref/*probably?*/ Y, ref/*probably?*/ Z);
		Inv.DropFrom((Location + ((0.80f * CylinderComponent.CollisionRadius) * X)) - ((0.50f * CylinderComponent.CollisionRadius) * Y), TossVel);
	}
	
	public virtual /*simulated function */void SetActiveWeapon(Weapon NewWeapon)
	{
		if(InvManager != default)
		{
			InvManager.SetCurrentWeapon(NewWeapon);
		}
	}
	
	public delegate void PlayWeaponSwitch_del(Weapon OldWeapon, Weapon NewWeapon);
	public virtual PlayWeaponSwitch_del PlayWeaponSwitch { get => bfield_PlayWeaponSwitch ?? Pawn_PlayWeaponSwitch; set => bfield_PlayWeaponSwitch = value; } PlayWeaponSwitch_del bfield_PlayWeaponSwitch;
	public virtual PlayWeaponSwitch_del global_PlayWeaponSwitch => Pawn_PlayWeaponSwitch;
	public /*simulated function */void Pawn_PlayWeaponSwitch(Weapon OldWeapon, Weapon NewWeapon)
	{
	
	}
	
	public virtual /*function */bool CheatWalk()
	{
		UnderWaterTime = DefaultAs<Pawn>().UnderWaterTime;
		SetCollision(true, true, default(bool?));
		SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		bCollideWorld = true;
		SetPushesRigidBodies(DefaultAs<Pawn>().bPushesRigidBodies);
		return true;
	}
	
	public virtual /*function */bool CheatGhost()
	{
		UnderWaterTime = -1.0f;
		SetCollision(false, false, default(bool?));
		bCollideWorld = false;
		SetPushesRigidBodies(false);
		return true;
	}
	
	public virtual /*function */bool CheatFly()
	{
		UnderWaterTime = DefaultAs<Pawn>().UnderWaterTime;
		SetCollision(true, true, default(bool?));
		bCollideWorld = true;
		return true;
	}
	
	public virtual /*simulated function */float GetCollisionRadius()
	{
		return ((CylinderComponent != default) ? CylinderComponent.CollisionRadius : 0.0f);
	}
	
	public virtual /*simulated function */float GetCollisionHeight()
	{
		return ((CylinderComponent != default) ? CylinderComponent.CollisionHeight : 0.0f);
	}
	
	public virtual /*final simulated function */Object.Vector GetCollisionExtent()
	{
		/*local */Object.Vector Extent = default;
	
		Extent = (GetCollisionRadius()) * vect(1.0f, 1.0f, 0.0f);
		Extent.Z = GetCollisionHeight();
		return Extent;
	}
	
	public override /*function */bool IsStationary()
	{
		return false;
	}
	
	public override /*event */void SpawnedByKismet()
	{
		if(Controller != default)
		{
			Controller.SpawnedByKismet();
		}
	}
	
	public override /*function */void DoKismetAttachment(Actor Attachment, SeqAct_AttachToActor Action)
	{
		/*local */bool bOldCollideActors = default, bOldBlockActors = default, bValidBone = default, bValidSocket = default;
	
		if((Mesh != default) && Action.BoneName != "None")
		{
			bValidSocket = Mesh.GetSocketByName(Action.BoneName) != default;
			bValidBone = Mesh.MatchRefBone(Action.BoneName) != -1;
			if(!bValidBone && !bValidSocket)
			{
			}
		}
		if((bValidBone || bValidSocket))
		{
			bOldCollideActors = Attachment.bCollideActors;
			bOldBlockActors = Attachment.bBlockActors;
			Attachment.SetCollision(false, false, default(bool?));
			Attachment.SetHardAttach(Action.bHardAttach);
			if(bValidBone && !bValidSocket)
			{
				if(Action.bUseRelativeOffset)
				{
					Attachment.SetLocation(Mesh.GetBoneLocation(Action.BoneName, default(int?)));
				}
				if(Action.bUseRelativeRotation)
				{
					Attachment.SetRotation(QuatToRotator(Mesh.GetBoneQuaternion(Action.BoneName, default(int?))));
				}
			}
			Attachment.SetBase(this, default(Object.Vector?), Mesh, Action.BoneName);
			if(Action.bUseRelativeRotation)
			{
				Attachment.SetRelativeRotation(Attachment.RelativeRotation + Action.RelativeRotation);
			}
			if(Action.bUseRelativeOffset)
			{
				Attachment.SetRelativeLocation(Attachment.RelativeLocation + Action.RelativeOffset);
			}
			Attachment.SetCollision(bOldCollideActors, bOldBlockActors, default(bool?));		
		}
		else
		{
			base.DoKismetAttachment(Attachment, Action);
		}
	}
	
	public virtual /*function */float GetDamageScaling()
	{
		return DamageScaling;
	}
	
	public virtual /*function */bool PoweredUp()
	{
		return DamageScaling > ((float)(1));
	}
	
	public virtual /*function */bool InCombat()
	{
		return false;
	}
	
	public virtual /*event */void OnSetMaterial(SeqAct_SetMaterial Action)
	{
		if(Mesh != default)
		{
			Mesh.SetMaterial(Action.MaterialIndex, Action.NewMaterial);
		}
	}
	
	public override /*simulated function */void OnTeleport(SeqAct_Teleport Action)
	{
		/*local */array<Object> objVars = default;
		/*local */int Idx = default;
		/*local */Actor destActor = default;
		/*local */Controller C = default;
	
		Action.GetObjectVars(ref/*probably?*/ objVars, "Destination");
		Idx = 0;
		J0x29:{}
		if((Idx < objVars.Length) && destActor == default)
		{
			destActor = ((objVars[Idx]) as Actor);
			C = ((destActor) as Controller);
			if((C != default) && C.Pawn != default)
			{
				destActor = C.Pawn;
			}
			++ Idx;
			goto J0x29;
		}
		if((destActor != default) && SetLocation(destActor.Location))
		{
			PlayTeleportEffect(false, true);
			if(Action.bUpdateRotation)
			{
				SetRotation(destActor.Rotation);
				if(Controller != default)
				{
					Controller.SetRotation(destActor.Rotation);
					Controller.ClientSetRotation(destActor.Rotation, default(bool?));
				}
			}		
		}
		if(Controller != default)
		{
			Controller.OnTeleport(default);
		}
	}
	
	public override /*simulated function */bool EffectIsRelevant(Object.Vector SpawnLocation, bool bForceDedicated, /*optional */float? _CullDistance = default)
	{
		/*local */PlayerController P = default;
	
		var CullDistance = _CullDistance ?? default;
		if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
		{
			return bForceDedicated;
		}
		if((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/)) && (WorldInfo.Game.NumPlayers + WorldInfo.Game.NumSpectators) > 1)
		{
			if(bForceDedicated)
			{
				return true;
			}
			if(IsHumanControlled() && IsLocallyControlled())
			{
				return true;
			}		
		}
		else
		{
			if(IsHumanControlled())
			{
				return true;
			}
		}
		if(((SpawnLocation != Location) || (WorldInfo.TimeSeconds - LastRenderTime) < 1.0f))
		{
			
			// foreach LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
			using var e216 = LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e216.MoveNext() && (P = (PlayerController)e216.Current) == P)
			{
				if((P.ViewTarget != default) && ((P.Pawn == this) || CheckMaxEffectDistance(P, SpawnLocation, CullDistance)))
				{				
					return true;
				}			
			}		
		}
		return false;
	}
	
	public virtual /*final event */void MessagePlayer(/*coerce */String msg)
	{
	
	}
	
	public virtual /*simulated function */void AdjustCameraScale(bool bMoveCameraIn)
	{
	
	}
	
	public override /*simulated event */void BecomeViewTarget(PlayerController PC)
	{
		if(PhysicsVolume != default)
		{
			PhysicsVolume.NotifyPawnBecameViewTarget(this, PC);
		}
	}
	
	public virtual /*event */void SoakPause()
	{
		/*local */PlayerController PC = default;
	
		
		// foreach WorldInfo.LocalPlayerControllers(ClassT<PlayerController>(), ref/*probably?*/ PC)
		using var e0 = WorldInfo.LocalPlayerControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (PC = (PlayerController)e0.Current) == PC)
		{
			PC.SoakPause(this);
			break;		
		}	
	}
	
	// Export UPawn::execClearConstraints(FFrame&, void* const)
	public virtual /*native function */void ClearConstraints()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execAddPathConstraint(FFrame&, void* const)
	public virtual /*native function */void AddPathConstraint(PathConstraint Constraint)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execAddGoalEvaluator(FFrame&, void* const)
	public virtual /*native function */void AddGoalEvaluator(PathGoalEvaluator Evaluator)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execIncrementPathStep(FFrame&, void* const)
	public virtual /*native function */void IncrementPathStep(int Cnt, Canvas C)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execIncrementPathChild(FFrame&, void* const)
	public virtual /*native function */void IncrementPathChild(int Cnt, Canvas C)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execDrawPathStep(FFrame&, void* const)
	public virtual /*native function */void DrawPathStep(Canvas C)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UPawn::execClearPathStep(FFrame&, void* const)
	public virtual /*native function */void ClearPathStep()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */float GetRunSpeed()
	{
		return GroundSpeed;
	}
	
	public virtual /*event */float GetWalkSpeed()
	{
		return GroundSpeed * WalkingPct;
	}
	
	public delegate void PlayNextAnimation_del();
	public virtual PlayNextAnimation_del PlayNextAnimation { get => bfield_PlayNextAnimation ?? (()=>{}); set => bfield_PlayNextAnimation = value; } PlayNextAnimation_del bfield_PlayNextAnimation;
	public virtual PlayNextAnimation_del global_PlayNextAnimation => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		FellOutOfWorld = null;
		OutsideWorldBounds = null;
		KilledBy = null;
		BaseChange = null;
		TakeDamage = null;
		Died = null;
		Landed = null;
		BreathTimer = null;
		PlayWeaponSwitch = null;
	
	}
	
	protected /*singular simulated event */void Pawn_Dying_OutsideWorldBounds()// state function
	{
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetHidden(true);
		LifeSpan = FMin(LifeSpan, 1.0f);
	}
	
	protected /*event */void Pawn_Dying_Timer()// state function
	{
		if(!PlayerCanSeeMe())
		{
			Destroy();		
		}
		else
		{
			SetTimer(2.0f, false, default(name?), default(Object?));
		}
	}
	
	protected /*event */void Pawn_Dying_TakeDamage(int Damage, Controller EventInstigator, Object.Vector HitLocation, Object.Vector Momentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)// state function
	{
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		if((((int)Physics) == ((int)Actor.EPhysics.PHYS_None/*0*/)) && Momentum.Z < ((float)(0)))
		{
			Momentum.Z *= ((float)(-1));
		}
		Velocity += ((((float)(3)) * Momentum) / (Mass + ((float)(200))));
		if(DamageType == default)
		{
			DamageType = ClassT<DamageType>();
		}
		Damage = /*initially 'intX *= floatY' */IntFloat_Mult(Damage, DamageType.DefaultAs<DamageType>().GibModifier);
		Health -= Damage;
	}
	
	protected /*event */void Pawn_Dying_BeginState(name PreviousStateName)// state function
	{
		/*local */Actor A = default;
		/*local */array<SequenceEvent> TouchEvents = default;
		/*local */int I = default;
	
		if(bTearOff && ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
		{
			LifeSpan = 2.0f;		
		}
		else
		{
			SetTimer(5.0f, false, default(name?), default(Object?));
		}
		if(((int)Physics) != ((int)Actor.EPhysics.PHYS_RigidBody/*10*/))
		{
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		}
		SetCollision(true, false, default(bool?));
		if(Controller != default)
		{
			if(Controller.bIsPlayer)
			{
				DetachFromController(default(bool?));			
			}
			else
			{
				Controller.Destroy();
			}
		}
		
		// foreach TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e146 = TouchingActors(ClassT<Actor>()).GetEnumerator();
		while(e146.MoveNext() && (A = (Actor)e146.Current) == A)
		{
			if(A.FindEventsOfClass(ClassT<SeqEvent_Touch>(), ref/*probably?*/ TouchEvents, default(bool?)))
			{
				I = 0;
				J0xC7:{}
				if(I < TouchEvents.Length)
				{
					((TouchEvents[I]) as SeqEvent_Touch).NotifyTouchingPawnDied(this);
					++ I;
					goto J0xC7;
				}
				TouchEvents.Length = 0;
			}		
		}	
		
		// foreach BasedActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e267 = BasedActors(ClassT<Actor>()).GetEnumerator();
		while(e267.MoveNext() && (A = (Actor)e267.Current) == A)
		{
			A.PawnBaseDied();		
		}	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dying()/*state Dying*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ BreathTimer = ()=>{}; FellOutOfWorld = (_a)=>{}; PlayWeaponSwitch = (_1,_a)=>{}; PlayNextAnimation = ()=>{}; BaseChange = ()=>{}; Landed = (_1,_a)=>{}; Died = (_1,_2,_a)=>default;
	
			OutsideWorldBounds = Pawn_Dying_OutsideWorldBounds;
			Timer = Pawn_Dying_Timer;
			TakeDamage = Pawn_Dying_TakeDamage;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Sleep(0.20f);
			PlayDyingSound();
			yield return Flow.Stop;				
		}
	
		return (Pawn_Dying_BeginState, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Dying": return Dying();
			default: return base.FindState(stateName);
		}
	}
	public Pawn()
	{
		var Default__Pawn_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
			// Object Offset:0x003B3E02
			FieldOfView = 160.0f,
			FarPlane = 1000.0f,
		}/* Reference: SceneCaptureCharacterComponent'Default__Pawn.SceneCaptureCharacterComponent0' */;
		var Default__Pawn_DrawFrust0 = new DrawFrustumComponent
		{
			// Object Offset:0x003B3E52
			FrustumColor = new Color
			{
				R=255,
				G=255,
				B=255,
				A=255
			},
			HiddenGame = false,
		}/* Reference: DrawFrustumComponent'Default__Pawn.DrawFrust0' */;
		var Default__Pawn_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x003B3EAA
			CollisionHeight = 78.0f,
			CollisionRadius = 34.0f,
			CollideActors = true,
			BlockActors = true,
		}/* Reference: CylinderComponent'Default__Pawn.CollisionCylinder' */;
		var Default__Pawn_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFF22
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Pawn.Sprite' */;
		var Default__Pawn_Arrow = new ArrowComponent
		{
			// Object Offset:0x00465C47
			ArrowColor = new Color
			{
				R=150,
				G=200,
				B=255,
				A=255
			},
		}/* Reference: ArrowComponent'Default__Pawn.Arrow' */;
		// Object Offset:0x00399A1F
		MaxStepHeight = 35.0f;
		MaxJumpHeight = 96.0f;
		WalkableFloorZ = 0.70f;
		bJumpCapable = true;
		bCanJump = true;
		bCanWalk = true;
		bSimulateGravity = true;
		bLOSHearing = true;
		bCanUse = true;
		CrouchHeight = 40.0f;
		CrouchRadius = 34.0f;
		NonPreferredVehiclePathMultiplier = 1.0f;
		DesiredSpeed = 1.0f;
		MaxDesiredSpeed = 1.0f;
		HearingThreshold = 2800.0f;
		SightRadius = 5000.0f;
		AvgPhysicsTime = 0.10f;
		Mass = 100.0f;
		MaxPitchLimit = 3072;
		GroundSpeed = 600.0f;
		WaterSpeed = 300.0f;
		AirSpeed = 600.0f;
		LadderSpeed = 200.0f;
		AccelRate = 2048.0f;
		JumpZ = 420.0f;
		OutofWaterZ = 420.0f;
		MaxOutOfWaterStepHeight = 40.0f;
		AirControl = 0.050f;
		WalkingPct = 0.50f;
		CrouchedPct = 0.50f;
		MaxFallSpeed = 1200.0f;
		AIMaxFallSpeedFactor = 1.0f;
		BaseEyeHeight = 64.0f;
		EyeHeight = 54.0f;
		Health = 100;
		SceneCapture = Default__Pawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__Pawn_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn.DrawFrust0'*/;
		noise1time = -10.0f;
		noise2time = -10.0f;
		SoundDampening = 1.0f;
		DamageScaling = 1.0f;
		ControllerClass = ClassT<AIController>()/*Ref Class'AIController'*/;
		LandMovementState = (name)"PlayerWalking";
		WaterMovementState = (name)"PlayerSwimming";
		CylinderComponent = Default__Pawn_CollisionCylinder/*Ref CylinderComponent'Default__Pawn.CollisionCylinder'*/;
		RBPushRadius = 10.0f;
		RBPushStrength = 50.0f;
		VehicleCheckRadius = 150.0f;
		ViewPitchMin = -16384.0f;
		ViewPitchMax = 16383.0f;
		AllowedYawError = 2000;
		InventoryManagerClass = ClassT<InventoryManager>()/*Ref Class'InventoryManager'*/;
		bUpdateSimulatedPosition = true;
		bCanBeDamaged = true;
		bShouldBaseAtStartup = true;
		bCanTeleport = true;
		bCollideActors = true;
		bCollideWorld = true;
		bBlockActors = true;
		bProjTarget = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Pawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__Pawn.SceneCaptureCharacterComponent0'*/,
			Default__Pawn_DrawFrust0/*Ref DrawFrustumComponent'Default__Pawn.DrawFrust0'*/,
			Default__Pawn_Sprite/*Ref SpriteComponent'Default__Pawn.Sprite'*/,
			Default__Pawn_CollisionCylinder/*Ref CylinderComponent'Default__Pawn.CollisionCylinder'*/,
			Default__Pawn_Arrow/*Ref ArrowComponent'Default__Pawn.Arrow'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		NetPriority = 2.0f;
		CollisionComponent = Default__Pawn_CollisionCylinder/*Ref CylinderComponent'Default__Pawn.CollisionCylinder'*/;
		RotationRate = new Rotator
		{
			Pitch=20000,
			Yaw=20000,
			Roll=20000
		};
	}
}
}
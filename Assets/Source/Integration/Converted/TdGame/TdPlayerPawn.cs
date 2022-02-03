// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerPawn : TdPawn/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public enum MorphNodeWeightTypes1p 
	{
		MN_RightForeArmRoll,
		MN_RightForeArmRollNegative,
		MN_LeftForeArmRoll,
		MN_LeftForeArmRollNegative,
		MN_NumMorphNodes,
		MN_MAX
	};
	
	public enum BoneNamesTypes1p 
	{
		RightForeArm,
		RightForeArmRoll,
		RightIndex0,
		RightIndex1,
		RightMiddle0,
		RightMiddle1,
		LeftForeArm,
		LeftForeArmRoll,
		LeftIndex0,
		LeftIndex1,
		LeftMiddle0,
		LeftMiddle1,
		BoneNamesTypes1p_MAX
	};
	
	public enum HandNormalMapMasks 
	{
		RightThumb,
		RightIndex,
		RightMiddle,
		RightRing,
		RightPinky,
		LeftThumb,
		LeftIndex,
		LeftMiddle,
		LeftRing,
		LeftPinky,
		HandNormalMapMasks_MAX
	};
	
	public array<MorphNodeWeight> MorphNodeWeight1p;
	public bool bHasMorphNodes;
	public bool bStuckOnGround;
	[transient] public bool bPlayerDiedHoldingTheBag;
	public bool bIsInShadowAlteringMoveState;
	[Category] public bool bEnableHairPhysics;
	public bool bLockBase;
	public bool bCutsceneIsSkippable;
	public array<name> BoneNames1p;
	public array<name> HandNormalMapNames1p;
	public SkelControlSingleBone BlinkControl;
	public TdSkelControlRandom CameraNoiseControlRoll1p;
	public TdSkelControlRandom CameraNoiseControlPitch1p;
	public Scene.ESceneDepthPriorityGroup FirstPersonDPG;
	public Scene.ESceneDepthPriorityGroup FirstPersonLowerBodyDPG;
	[export, editinline] public AudioComponent WindSound;
	public SoundCue WindSoundSC;
	[export, editinline] public AudioComponent FallingSound;
	[Category("Movement")] [config] public float VertigoEdgeProbingHeight;
	[Category("Movement")] [config] public float VertigoEdgeProbingDistance;
	[Category("Movement")] [config] public float VertigoEffectThreshold;
	[Category("Movement")] [config] public float EdgeCheckMaxSpeed;
	[Category("Movement")] [config] public float EdgeCheckDistance;
	[Category("Movement")] [config] public float EdgeStopMinHeight;
	[transient] public float LastEnemyHitTimeOut;
	[Category("Sounds")] public TdReverbVolume CurrentReverbVolume;
	[transient] public float ReverbVolumeTimer;
	[Category("Sounds")] [config] public float ReverbVolumePollTime;
	[Category("Sounds")] [config] public float OcclusionDuckLevel;
	[Category("Sounds")] [config] public float OcclusionDuckFadeTime;
	[transient] public int IndoorSoundGroupIndex;
	[transient] public array<int> OutdoorSoundGroupIndexes;
	[transient] public int IndoorMixGroupIndex;
	[transient] public int OutdoorMixGroupIndex;
	[transient] public TdCarriable CarriedObject;
	[Const, config] public float MovementStringAllowedGap;
	[transient] public float MovementStringGapTimer;
	[transient] public array< Class > MovementStringHistory;
	[Const, config] public float PlayerBulletDamageMultiplier;
	[transient] public Object.Vector FocusLocation;
	public/*private*/ Object.Vector PlayerCameraLocation;
	public/*private*/ Object.Rotator PlayerCameraRotation;
	[transient] public array<name> HairBones;
	public int DebugPlayerGraph;
	public float LastDebugGraphValue;
	public int SimulatedBadFPS;
	[config] public float FocusLocationInterpolationSpeed;
	public float LastResetTimeStamp;
	
	// Export UTdPlayerPawn::execCheckValidFloor(FFrame&, void* const)
	//public virtual /*native function */bool CheckValidFloor(Object.Vector CurrentDelta, Object.Vector CheckFloor, bool bSlideOff)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UTdPlayerPawn::execUpdate1pArms(FFrame&, void* const)
	//public virtual /*native final function */void Update1pArms(float DeltaTime)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdPlayerPawn::execCheckAgainstWall(FFrame&, void* const)
	//public virtual /*native final function */TdPawn.EAgainstWallState CheckAgainstWall()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export UTdPlayerPawn::execUpdateAgainstWall(FFrame&, void* const)
	//public virtual /*native final function */void UpdateAgainstWall()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	//// Export UTdPlayerPawn::execGetMobilityMultiplier(FFrame&, void* const)
	//public override /*native function */float GetMobilityMultiplier()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	public virtual /*function */Scene.ESceneDepthPriorityGroup GetFirstPersonDPG()
	{
		return ((Scene.ESceneDepthPriorityGroup)FirstPersonDPG);
	}
	
	public virtual /*function */Scene.ESceneDepthPriorityGroup GetFirstPersonLowerBodyDPG()
	{
		return ((Scene.ESceneDepthPriorityGroup)FirstPersonLowerBodyDPG);
	}
	
	public virtual /*function */void SetAmbientShadowDirection(Object.Vector Direction, bool isShadowAlteringMove)
	{
		/*local *//*editinline */DynamicLightEnvironmentComponent Mesh3pLightEnv = default;
	
		if(bIsInShadowAlteringMoveState && !isShadowAlteringMove)
		{
			return;
		}
		Mesh3pLightEnv = ((Mesh3p.LightEnvironment) as DynamicLightEnvironmentComponent);
		Mesh3pLightEnv.AmbientShadowSourceDirection = Direction;
		bIsInShadowAlteringMoveState = isShadowAlteringMove;
	}
	
	public virtual /*function */void ResetAmbientShadowDirection(bool isShadowAlteringMove)
	{
		/*local *//*editinline */DynamicLightEnvironmentComponent Mesh3pLightEnv = default;
		/*local */Object.Vector defaultDir = default;
	
		if(bIsInShadowAlteringMoveState && !isShadowAlteringMove)
		{
			return;
		}
		defaultDir = Normal(vect(0.0f, 0.0f, 10.0f) - ((Vector)(Rotation)));
		Mesh3pLightEnv = ((Mesh3p.LightEnvironment) as DynamicLightEnvironmentComponent);
		Mesh3pLightEnv.AmbientShadowSourceDirection = defaultDir;
		if(isShadowAlteringMove)
		{
			bIsInShadowAlteringMoveState = false;
		}
	}
	
	public virtual /*function */void SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup DPG)
	{
		if(Mesh1p == default)
		{
			return;
		}
		if(((int)FirstPersonDPG) != ((int)DPG))
		{
			FirstPersonDPG = ((Scene.ESceneDepthPriorityGroup)DPG);
			Mesh1p.SetDepthPriorityGroup(((Scene.ESceneDepthPriorityGroup)FirstPersonDPG));
			if(MyWeapon != default)
			{
				Weapon.Mesh.SetDepthPriorityGroup(((Scene.ESceneDepthPriorityGroup)FirstPersonDPG));
				if(MyWeapon.MuzzleFlashPSC != default)
				{
					MyWeapon.MuzzleFlashPSC.SetDepthPriorityGroup(((Scene.ESceneDepthPriorityGroup)FirstPersonDPG));
				}
			}
		}
	}
	
	public virtual /*function */void SetFirstPersonLowerBodyDPG(Scene.ESceneDepthPriorityGroup DPG)
	{
		if(Mesh1pLowerBody == default)
		{
			return;
		}
		if(((int)FirstPersonLowerBodyDPG) != ((int)DPG))
		{
			FirstPersonLowerBodyDPG = ((Scene.ESceneDepthPriorityGroup)DPG);
			Mesh1pLowerBody.SetDepthPriorityGroup(((Scene.ESceneDepthPriorityGroup)FirstPersonLowerBodyDPG));
		}
	}
	
	public virtual /*function */Pawn GetCarryingPawn()
	{
		return this;
	}
	
	public virtual /*function */bool IsCarryingBag()
	{
		return (CarriedObject != default) && CarriedObject.GetCarriedActor().IsA("TdBagKActor");
	}
	
	public virtual /*function */bool IsCarryingObject()
	{
		return CarriedObject != default;
	}
	
	public virtual /*function */bool CarryObject(TdCarriable InCarriable)
	{
		if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && CarriedObject == default)
		{
			if(InCarriable.OnCarried(this))
			{
				CarriedObject = InCarriable;
				return true;
			}
		}
		return false;
	}
	
	public virtual /*function */bool DropCarriedObject(Object.Vector StartLocation, Object.Rotator StartRotation, Object.Vector WithForce)
	{
		if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) && CarriedObject != default)
		{
			if(CarriedObject.OnDropped(this, StartLocation, StartRotation, WithForce))
			{
				CarriedObject = default;
				return true;
			}
		}
		return false;
	}
	
	public virtual /*simulated function */void ForceDropBag(/*optional */Object.Vector? _Force = default)
	{
		/*local */Object.Vector WeaponLocation = default;
		/*local */Object.Rotator WeaponRotation = default;
		/*local */Inventory Bag = default;
		/*local */Core.ClassT<TdWeapon> BagClass = default;
	
		var Force = _Force ?? default;
		if(((int)Role) < ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			return;
		}
		BagClass = ((DynamicLoadObject("TdMpContent.TdWeapon_Bag", ClassT<Class>(), default(bool?))) as ClassT<TdWeapon>);
		
		// foreach InvManager.InventoryActors(BagClass, ref/*probably?*/ Bag)
		using var e68 = InvManager.InventoryActors(BagClass).GetEnumerator();
		while(e68.MoveNext() && (Bag = (Inventory)e68.Current) == Bag)
		{
			GetWeaponJointPosition(ref/*probably?*/ WeaponLocation, ref/*probably?*/ WeaponRotation);
			Bag.DropFrom(WeaponLocation, (Velocity * 0.50f) + Force);		
		}	
	}
	
	public override /*function */void SetMovementPhysics()
	{
	
	}
	
	public virtual /*function */void SlideOffLedge()
	{
		if((bAvoidLedges && Moves[((int)MovementState)].bAvoidLedges) && Floor.Z > WalkableFloorZ)
		{
			if(!CheckValidFloor(Normal(Velocity), Floor, true))
			{
				SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
				SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), true);
			}
		}
	}
	
	public override /*function */void SetDifficultyLevel(int Level)
	{
		/*local */TdMove Move = default;
	
		base.SetDifficultyLevel(Level);
		using var v = Moves.GetEnumerator();while(v.MoveNext() && (Move = (TdMove)v.Current) == Move)
		{
			if(Move != default)
			{
				Move.SetDifficulty(Level);
			}		
		}	
	}
	
	public virtual /*function */void OnTdEnableReactionTime(SeqAct_TdEnableReactionTime Action)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).OnTdEnableReactionTime(Action);
		}
	}
	
	public virtual /*function */void OnTdDisableReactionTime(SeqAct_TdDisableReactionTime Action)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).OnTdDisableReactionTime(Action);
		}
	}
	
	public virtual /*function */void OnTdGiveFullReactionEnergy(SeqAct_TdGiveFullReactionEnergy Action)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).OnTdGiveFullReactionEnergy(Action);
		}
	}
	
	public virtual /*function */void OnTdEnablePlayerInput(SeqAct_TdEnablePlayerInput Action)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).OnTdEnablePlayerInput(Action);
		}
	}
	
	public virtual /*function */void OnTdDisablePlayerInput(SeqAct_TdDisablePlayerInput Action)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).OnTdDisablePlayerInput(Action);
		}
	}
	
	public virtual /*function */void OnTdInElevator(SeqAct_TdInElevator Action)
	{
		/*local */array<Object> ObjectVariables = default;
	
		Action.GetObjectVars(ref/*probably?*/ ObjectVariables, "Elevator");
		if(Action.InputLinks[0].bHasImpulse)
		{
			if(((ObjectVariables[0]) as Actor) == default)
			{
				return;
			}
			SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
			SetBase(((ObjectVariables[0]) as Actor), default(Object.Vector?), default(SkeletalMeshComponent), default(name?));
			bLockBase = true;
			bAllowMoveChange = false;		
		}
		else
		{
			bLockBase = false;
			bAllowMoveChange = true;
		}
	}
	
	public virtual /*function */void OnTdPauseTimer(SeqAct_TdPauseTimer Action)
	{
		bSRPauseTimer = Action.InputLinks[0].bHasImpulse;
		if(bSRPauseTimer && ((Controller) as TdPlayerController).IsLoadingLevel())
		{
			((Controller) as TdPlayerController).ConditionalBlockWhileLoading();
		}
	}
	
	public virtual /*function */void OnTdFallOnBack(SeqAct_TdFallOnBack Action)
	{
		if(CanDoMove(TdPawn.EMovement.MOVE_LayOnGround/*26*/))
		{
			SetMove(TdPawn.EMovement.MOVE_LayOnGround/*26*/, default(bool?), default(bool?));
		}
	}
	
	public virtual /*function */void OnTdPause(SeqAct_TdPause Action)
	{
		WorldInfo.Game.TdPause();
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdPlayerPawn_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdPlayerPawn_TakeDamage;
	public /*event */void TdPlayerPawn_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor _DamageCauser = default)
	{
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		if(((InstigatedBy) as TdAIController) != default)
		{
			if(!((InstigatedBy) as TdAIController).IsHitRelevant(DamageType, HitInfo.BoneName))
			{
				return;
			}
		}
		if(DamageType.IsA("TdDmgType_Bullet"))
		{
			Damage = /*initially 'intX *= floatY' */IntFloat_Mult(Damage, PlayerBulletDamageMultiplier);
		}
		if(!DamageType.IsA("TdDmgType_Fell"))
		{
			PlaySound(ObjectConst<SoundCue>("Hard"), false, true, false, Location, default(bool?), default(bool?));
		}
		/*Transformed 'base.' to specific call*/TdPawn_TakeDamage(Damage, InstigatedBy, HitLocation, damageMomentum, DamageType, HitInfo, DamageCauser);
		if((Health < 40) && Weapon != default)
		{
			((Controller) as TdPlayerController).UnZoom();
		}
	}
	
	public override /*function */void PlayMeleeImpact(PhysicalMaterial PhysMat, TdPawn.EMeleeImpactType Type, Object.Vector TargetHitLocation, Object.Vector TargetHitNormal, Object.Vector TargetHitMomentum, name TargetHitBone, /*optional */Core.ClassT<DamageType> _DamageType = default)
	{
		var DamageType = _DamageType ?? default;
		PlaySound(ObjectConst<SoundCue>("Fist_Head"), false, true, false, TargetHitLocation, default(bool?), default(bool?));
	}
	
	public override Died_del Died { get => bfield_Died ?? TdPlayerPawn_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => TdPlayerPawn_Died;
	public /*function */bool TdPlayerPawn_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		NotifyPlayerDeath();
		return /*Transformed 'base.' to specific call*/TdPawn_Died(Killer, DamageType, HitLocation);
	}
	
	public virtual /*function */void NotifyPlayerDeath()
	{
		/*local */int Index = default;
		/*local */Sequence GameSequence = default;
		/*local */array<SequenceObject> SequenceEvents = default;
		/*local */SeqEvt_TdPlayerDeath DeathEvent = default;
	
		GameSequence = WorldInfo.GetGameSequence();
		GameSequence.FindSeqObjectsByClass(ClassT<SeqEvt_TdPlayerDeath>(), true, ref/*probably?*/ SequenceEvents);
		Index = 0;
		J0x38:{}
		if(Index < SequenceEvents.Length)
		{
			DeathEvent = ((SequenceEvents[Index]) as SeqEvt_TdPlayerDeath);
			DeathEvent.CheckActivate(this, this, false, ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
			++ Index;
			goto J0x38;
		}
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? TdPlayerPawn_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => TdPlayerPawn_Landed;
	public /*event */void TdPlayerPawn_Landed(Object.Vector aNormal, Actor anActor)
	{
		if(bTakeFallDamage)
		{
			TakeFallingDamage();
		}
		Moves[((int)MovementState)].Landed(aNormal, anActor);
		EnterFallingHeight = Location.Z;
	}
	
	public override /*function */void TakeFallingDamage()
	{
		/*local */float Damage = default, FallHeight = default;
		/*local */bool bLandedOnSoftSurface = default, bDeathFall = default;
	
		FallHeight = EnterFallingHeight - Location.Z;
		bLandedOnSoftSurface = ((Moves[20]) as TdMove_Landing).IsLandingOnSoftObject();
		bDeathFall = (((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/)) && IsInState("UncontrolledFall", default(bool?))) || FallHeight >= FallingUncontrolledHeight);
		if((bLandedOnSoftSurface || ((!bDeathFall && FallHeight < ((Moves[20]) as TdMove_Landing).HardLandingHeight) || CanSkillRoll())))
		{
			MakeNoise(0.50f, "PlayerMovementNoise");		
		}
		else
		{
			if(bDeathFall)
			{
				Damage = 100.0f;			
			}
			else
			{
				Damage = ((Moves[20]) as TdMove_Landing).HardLandingDamage;
			}
			TakeDamage(((int)(Damage)), default, Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Fell>(), default(Actor.TraceHitInfo?), default(Actor));
		}
	}
	
	public override /*simulated function */void GoIntoUncontrolledFall()
	{
		if(!IsInState("UncontrolledFall", default(bool?)))
		{
			((Controller) as TdPlayerController).SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_FALLING_TO_DEATH/*6*/, default(float?), default(bool?), 0.50f);
			GotoState("UncontrolledFall", default(name?), default(bool?), default(bool?));
		}
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdPlayerPawn_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdPlayerPawn_Tick;
	public /*simulated function */void TdPlayerPawn_Tick(float DeltaTime)
	{
		/*local */TdPlayerController PlayerController = default;
		/*local */bool bAllowAgainstWall = default;
	
		if(BlinkControl.ControlStrength >= 1.0f)
		{
			BlinkControl.SetSkelControlStrength(0.0f, 0.250f);		
		}
		else
		{
			if(BlinkControl.BlendInTime < WorldInfo.TimeSeconds)
			{
				BlinkControl.SetSkelControlStrength(1.0f, 0.030f);
				BlinkControl.BlendInTime = (WorldInfo.TimeSeconds + 1.0f) + (FRand() * 5.0f);
			}
		}
		bAllowAgainstWall = ((Moves[((int)MovementState)].bEnableAgainstWall && !IsInState("UncontrolledFall", default(bool?))) && !IsInState("Dying", default(bool?))) && ((int)WeaponAnimState) != ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/);
		if((((int)Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/)) && VSize2D(Velocity) > 400.0f)
		{
			bAllowAgainstWall = false;
		}
		if(bAllowAgainstWall)
		{
			UpdateAgainstWall();		
		}
		else
		{
			AgainstWallState = TdPawn.EAgainstWallState.AW_None/*0*/;
		}
		if(IsLocallyControlled())
		{
			SyncLegMovement();
		}
		if(WindSound == default)
		{
			WindSound = this.CreateAudioComponent(WindSoundSC, false, true, default(bool?), default(Object.Vector?), default(bool?));
			if(WindSound != default)
			{
				AttachComponent(WindSound);
				WindSound.bShouldRemainActiveIfDropped = true;
				WindSound.bUseOwnerLocation = true;
				WindSound.bAllowSpatialization = true;
				WindSound.bAutoDestroy = true;
				WindSound.Play();
			}
		}
		UpdateWeaponAnimState(DeltaTime);
		if(IsLocallyControlled())
		{
			if(((int)AgainstWallState) == ((int)TdPawn.EAgainstWallState.AW_AgainstWall/*1*/))
			{
				SetAmbientShadowDirection(AgainstWallNormal, false);			
			}
			else
			{
				ResetAmbientShadowDirection(false);
			}
			if(Mesh1p != default)
			{
				Update1pArms(DeltaTime);
			}
			if(SwanNeck1p != default)
			{
				SwanNeck1p.UpdateSwanNeck(WorldInfo.SavedDeltaSeconds, GetViewRotation().Pitch);
			}
		}
		PlayerController = ((Controller) as TdPlayerController);
		if((PlayerController != default) && !(IsInState("UncontrolledFall", default(bool?)) || IsInState("Dying", default(bool?))))
		{
			if(!RollTriggerPressed && ((int)PlayerController.bDuck) == ((int)1))
			{
				if((RollTriggerTime + 0.60f) < WorldInfo.TimeSeconds)
				{
					RollTriggerTime = WorldInfo.TimeSeconds;
				}
				RollTriggerPressed = true;			
			}
			else
			{
				if(((int)PlayerController.bDuck) == ((int)0))
				{
					RollTriggerPressed = false;
				}
			}
		}
		UpdateMovementString(DeltaTime);
		UpdateFocusLocation(DeltaTime);
		/*Transformed 'base.' to specific call*/TdPawn_Tick(DeltaTime);
	}
	
	public virtual /*function */void ReleaseCameraConstraintsAgainstWall()
	{
		MinLookConstraint = DefaultAs<TdPawn>().MinLookConstraint;
		MaxLookConstraint = DefaultAs<TdPawn>().MaxLookConstraint;
		bConstrainLook = false;
	}
	
	public virtual /*function */void StopAgainstWall()
	{
		/*local */TdPawn.EAgainstWallState WallState = default;
	
		WallState = ((TdPawn.EAgainstWallState)CheckAgainstWall());
		if(((int)WallState) == ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
		{
			AgainstWallState = TdPawn.EAgainstWallState.AW_None/*0*/;
			ReleaseCameraConstraintsAgainstWall();		
		}
		else
		{
			SetTimer(0.150f, false, "StopAgainstWall", default(Object));
		}
	}
	
	public virtual /*function */void UpdateMovementString(float DeltaTime)
	{
		if(MovementStringGapTimer > 0.0f)
		{
			MovementStringGapTimer -= DeltaTime;
			if((MovementStringHistory.Length > 0) && MovementStringGapTimer <= 0.0f)
			{
				MovementStringGapTimer = 0.0f;
				MovementStringHistory.Remove(0, MovementStringHistory.Length);
			}
		}
	}
	
	public virtual /*function */void StartStringableMove(Class CL)
	{
		/*local */int StringLength = default;
		/*local */bool Reset = default;
	
		Reset = false;
		MovementStringHistory.AddItem(CL);
		MovementStringGapTimer = -1.0f;
		StringLength = MovementStringHistory.Length;
		if((StringLength >= 3) && CL == ClassT<TdMove_VaultOver>())
		{
			if((MovementStringHistory[StringLength - 2] == ClassT<TdMove_WallrunJump>()) && MovementStringHistory[StringLength - 3] == ClassT<TdMove_WallRun>())
			{
				((Controller) as TdPlayerController).UnlockAchievement(39);
				Reset = true;
			}		
		}
		else
		{
			if((StringLength >= 3) && CL == ClassT<TdMove_Slide>())
			{
				if((MovementStringHistory[StringLength - 2] == ClassT<TdMove_Coil>()) && MovementStringHistory[StringLength - 3] == ClassT<TdMove_Jump>())
				{
					((Controller) as TdPlayerController).UnlockAchievement(38);
					Reset = true;
				}			
			}
			else
			{
				if((StringLength >= 5) && CL == ClassT<TdMove_WallClimb180TurnJump>())
				{
					if(((((MovementStringHistory[StringLength - 2] == ClassT<TdMove_WallClimb180TurnJump>()) && MovementStringHistory[StringLength - 3] == ClassT<TdMove_WallClimb>()) && MovementStringHistory[StringLength - 4] == ClassT<TdMove_WallrunJump>()) && MovementStringHistory[StringLength - 5] == ClassT<TdMove_WallRun>()) && MovementStringHistory[StringLength - 6] == ClassT<TdMove_WallRun>())
					{
						((Controller) as TdPlayerController).UnlockAchievement(40);
						Reset = true;
					}				
				}
				else
				{
					if((StringLength >= 4) && CL == ClassT<TdMove_SkillRoll>())
					{
						if(((MovementStringHistory[StringLength - 2] == ClassT<TdMove_Coil>()) && MovementStringHistory[StringLength - 3] == ClassT<TdMove_WallrunJump>()) && MovementStringHistory[StringLength - 4] == ClassT<TdMove_WallRun>())
						{
							((Controller) as TdPlayerController).UnlockAchievement(41);
							Reset = true;
						}
					}
				}
			}
		}
		if(Reset)
		{
			MovementStringGapTimer = 0.0f;
			MovementStringHistory.Remove(0, MovementStringHistory.Length);
		}
	}
	
	public virtual /*function */void StartUnStringableMove()
	{
		if(MovementStringGapTimer < 0.0f)
		{
			MovementStringGapTimer = FMax(MovementStringAllowedGap, 0.010f);
		}
	}
	
	public override /*simulated function */void SetHipsOffset(Object.Vector Offset, /*optional */float? _BlendTime = default, /*optional */bool? _bFirstPersonMeshOnly = default)
	{
		var BlendTime = _BlendTime ?? 0.30f;
		var bFirstPersonMeshOnly = _bFirstPersonMeshOnly ?? false;
		if(VSize(Offset) > 0.10f)
		{
			if(HipsControl1p != default)
			{
				HipsControl1p.BoneTranslation = Offset;
				HipsControl1p.SetSkelControlStrength(1.0f, BlendTime);
			}
			if((HipsControl3p != default) && !bFirstPersonMeshOnly)
			{
				HipsControl3p.BoneTranslation = Offset;
				HipsControl3p.SetSkelControlStrength(1.0f, BlendTime);
			}		
		}
		else
		{
			if(HipsControl1p != default)
			{
				HipsControl1p.SetSkelControlStrength(0.0f, BlendTime);
			}
			if((HipsControl3p != default) && !bFirstPersonMeshOnly)
			{
				HipsControl3p.SetSkelControlStrength(0.0f, BlendTime);
			}
		}
	}
	
	public override /*simulated event */Object.Vector GetPawnViewLocation()
	{
		/*local */Object.Vector CamLoc = default;
	
		if(((IsFirstPerson()) || Mesh == Mesh1p))
		{
			CamLoc = PlayerCameraLocation;		
		}
		else
		{
			if(Mesh == Mesh3p)
			{
				CamLoc = Mesh3p.GetBoneLocation("EyeJoint", 0);			
			}
			else
			{
				CamLoc = Location + (BaseEyeHeight * vect(0.0f, 0.0f, 1.0f));
			}
		}
		return CamLoc;
	}
	
	public virtual /*simulated event */Object.Rotator GetPawnViewRotation()
	{
		/*local */Object.Rotator CamRot = default;
	
		if(((IsFirstPerson()) || Mesh == Mesh1p))
		{
			CamRot = PlayerCameraRotation;		
		}
		else
		{
			CamRot = GetViewRotation();
		}
		return CamRot;
	}
	
	public override /*simulated function */bool CalcCamera(float DeltaTime, ref Object.Vector out_Location, ref Object.Rotator out_Rotation, ref float out_FOV)
	{
		/*local */Object.Vector CameraAnimLocation = default;
		/*local */Object.Rotator CameraAnimRotation = default, SwanNeckRotationRef = default;
	
		base.CalcCamera(DeltaTime, ref/*probably?*/ out_Location, ref/*probably?*/ out_Rotation, ref/*probably?*/ out_FOV);
		if(Mesh == Mesh3p)
		{
			return false;
		}
		out_Location = Mesh1p.GetBoneLocation("EyeJoint", 0);
		out_Rotation = GetViewRotation();
		GetCameraAnimation(ref/*probably?*/ CameraAnimLocation, ref/*probably?*/ CameraAnimRotation);
		out_Rotation.Pitch += -CameraAnimRotation.Roll;
		out_Rotation.Yaw += CameraAnimRotation.Pitch;
		out_Rotation.Roll += -CameraAnimRotation.Yaw;
		if(SwanNeck1p != default)
		{
			SwanNeckRotationRef = out_Rotation;
			SwanNeckRotationRef.Pitch = 0;
			SwanNeckRotationRef.Roll = 0;
			out_Location += SwanNeck1p.GetSwanNeckPos(Normalize(SwanNeckRotationRef));
		}
		if(Moves[((int)MovementState)].bUseCameraCollision && !((Controller) as PlayerController).bCinematicMode)
		{
			Moves[((int)MovementState)].CheckForCameraCollision(out_Location, out_Rotation);
		}
		PlayerCameraLocation = out_Location;
		PlayerCameraRotation = out_Rotation;
		if(Controller != default)
		{
			out_FOV = ((Controller) as TdPlayerController).FOVAngle;
		}
		return IsFirstPerson();
	}
	
	public virtual /*event */void SetFOV(float NewFOV, float Rate)
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).StartZoom(NewFOV, Rate, 0.0f);
		}
	}
	
	public virtual /*event */void SetDefaultFov()
	{
		if(Controller != default)
		{
			((Controller) as TdPlayerController).UnZoom();
		}
	}
	
	public virtual /*function */void UpdateFocusLocation(float DeltaTime)
	{
		/*local */Object.Vector MoveFocusLocation = default;
	
		MoveFocusLocation = Moves[((int)MovementState)].GetFocusLocation();
		FocusLocation.X = FInterpTo(FocusLocation.X, MoveFocusLocation.X, DeltaTime, FocusLocationInterpolationSpeed);
		FocusLocation.Y = FInterpTo(FocusLocation.Y, MoveFocusLocation.Y, DeltaTime, FocusLocationInterpolationSpeed);
		FocusLocation.Z = FInterpTo(FocusLocation.Z, MoveFocusLocation.Z, DeltaTime, FocusLocationInterpolationSpeed);
	}
	
	public virtual /*function */Object.Vector GetFocusLocation()
	{
		return FocusLocation;
	}
	
	public virtual /*function */void SetFocusLocation(Object.Vector iFocusLocation)
	{
		FocusLocation = iFocusLocation;
	}
	
	public override /*function */SoundCue GetSpecificFootStepSound(TdPhysicalMaterialFootSteps FootStepSounds, int FootDown)
	{
		/*local */SoundCue retval = default;
	
		switch(FootDown)
		{
			case 0:
				retval = ObjectConst<SoundCue>("Fire");
				break;
			case 1:
				retval = FootStepSounds._01_Female_FootStepCrouch;
				break;
			case 2:
				retval = FootStepSounds._02_Female_FootStepWalk;
				break;
			case 3:
				retval = FootStepSounds._03_Female_FootStepRun;
				break;
			case 4:
				retval = FootStepSounds._04_Female_FootStepSprint;
				break;
			case 5:
				retval = FootStepSounds._05_Female_FootStepSprintRelease;
				break;
			case 6:
				retval = FootStepSounds._06_Female_FootStepWallRun;
				break;
			case 7:
				retval = FootStepSounds._07_Female_FootStepWallrunRelease;
				break;
			case 8:
				retval = FootStepSounds._08_Female_FootStepLandSoft;
				break;
			case 9:
				retval = FootStepSounds._09_Female_FootStepLandMedium;
				break;
			case 10:
				retval = FootStepSounds._10_Female_FootStepLandHard;
				break;
			case 11:
				retval = FootStepSounds._11_Female_FootStepAttack;
				break;
			case 21:
				retval = FootStepSounds._21_Female_HandStepSoft;
				break;
			case 22:
				retval = FootStepSounds._22_Female_HandStepMedium;
				break;
			case 23:
				retval = FootStepSounds._23_Female_HandStepHard;
				break;
			case 24:
				retval = FootStepSounds._24_Female_HandStepLongRelease;
				break;
			case 25:
				retval = FootStepSounds._25_Female_HandStepShortRelease;
				break;
			case 26:
				retval = FootStepSounds._26_Female_HandStepAttack;
				break;
			case 31:
				retval = FootStepSounds._31_Female_BodyAttack;
				break;
			case 32:
				retval = FootStepSounds._32_Female_BodyLandSoft;
				break;
			case 33:
				retval = FootStepSounds._33_Female_BodyLandHard;
				break;
			case 34:
				retval = FootStepSounds._34_Female_BodyLandRoll;
				break;
			case 35:
				retval = FootStepSounds._35_Female_BodyVault;
				break;
			case 36:
				retval = FootStepSounds._36_Female_BodySlide;
				break;
			default:
				break;
		}
		return retval;
	}
	
	public override /*function */ParticleSystem GetSpecificFootStepEffect(TdPhysicalMaterialFootSteps FootStepEffects, int FootDown)
	{
		/*local */ParticleSystem retval = default;
	
		switch(FootDown)
		{
			case 3:
				retval = FootStepEffects._03_Effect_FootStepRun;
				break;
			case 4:
				retval = FootStepEffects._03_Effect_FootStepRun;
				break;
			case 6:
				retval = FootStepEffects._06_Effect_FootStepWallRun;
				break;
			case 8:
				retval = FootStepEffects._08_Effect_FootStepLandSoft;
				break;
			case 10:
				retval = FootStepEffects._10_Effect_FootStepLandHard;
				break;
			case 11:
				retval = FootStepEffects._11_Effect_FootStepAttack;
				break;
			case 12:
				retval = FootStepEffects._12_Effect_FootStepVertigo;
				break;
			case 21:
				retval = FootStepEffects._21_Effect_HandStepSoft;
				break;
			case 23:
				retval = FootStepEffects._23_Effect_HandStepHard;
				break;
			case 25:
				retval = FootStepEffects._25_Effect_HandStepShortRelease;
				break;
			case 26:
				retval = FootStepEffects._26_Effect_HandStepAttack;
				break;
			case 27:
				retval = FootStepEffects._27_Effect_FemaleHandGrabHard;
				break;
			case 28:
				retval = FootStepEffects._28_Effect_FemaleHandStrafeSlow;
				break;
			case 29:
				retval = FootStepEffects._29_Effect_FemaleHandStrafeFast;
				break;
			case 31:
				retval = FootStepEffects._31_Effect_BodyAttack;
				break;
			case 36:
				retval = FootStepEffects._36_Effect_BodySlide;
				break;
			default:
				break;
		}
		return retval;
	}
	
	public override /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		var HitInfo = _HitInfo ?? default;
		return;
	}
	
	public virtual /*exec function */void BargeHitNotify()
	{
		((Moves[19]) as TdMove_Barge).BargeHitNotify();
	}
	
	public virtual /*exec function */void MoveRumbleNotify()
	{
		Moves[((int)MovementState)].MoveRumbleNotify();
	}
	
	public virtual /*exec function */void ToggleFootPlacement()
	{
		if(bEnableFootPlacement)
		{
			DisableFootPlacement();		
		}
		else
		{
			EnableFootPlacement(default(float?));
		}
	}
	
	public virtual /*simulated function */void EnableFootPlacement(/*optional */float? _BlendTime = default)
	{
		var BlendTime = _BlendTime ?? 0.20f;
		if((LeftLegControl3p != default) && RightLegControl3p != default)
		{
			LeftLegControl3p.SetSkelControlStrength(1.0f, BlendTime);
			RightLegControl3p.SetSkelControlStrength(1.0f, BlendTime);
		}
		if((LeftLegControl1p != default) && RightLegControl1p != default)
		{
			LeftLegControl1p.SetSkelControlStrength(1.0f, BlendTime);
			RightLegControl1p.SetSkelControlStrength(1.0f, BlendTime);
		}
		bEnableFootPlacement = true;
	}
	
	public virtual /*simulated function */void DisableFootPlacement()
	{
		if((LeftLegControl3p != default) && RightLegControl3p != default)
		{
			LeftLegControl3p.SetSkelControlStrength(0.0f, 0.20f);
			RightLegControl3p.SetSkelControlStrength(0.0f, 0.20f);
		}
		if((LeftLegControl1p != default) && RightLegControl1p != default)
		{
			LeftLegControl1p.SetSkelControlStrength(0.0f, 0.20f);
			RightLegControl1p.SetSkelControlStrength(0.0f, 0.20f);
		}
		bEnableFootPlacement = false;
	}
	
	public virtual /*exec function */void ToggleBlendShapes()
	{
		bHasMorphNodes = !bHasMorphNodes;
		if(!bHasMorphNodes)
		{
			MorphNodeWeight1p[0].SetNodeWeight(0.0f);
			MorphNodeWeight1p[1].SetNodeWeight(0.0f);
			MorphNodeWeight1p[2].SetNodeWeight(0.0f);
			MorphNodeWeight1p[3].SetNodeWeight(0.0f);
		}
	}
	
	public override /*simulated event */void eventPostBeginPlay()
	{
		NativeMarkers.MarkUnimplemented( "See Dec/TdPlayerPawn PostBeginPlay, weird stuff" );
		base.eventPostBeginPlay();
		if(WorldInfo.Game.IsA("TdSPGame"))
		{
			((WorldInfo.Game) as TdSPGame).AIManager.SetPlayer(this);
		}
		SetAimOffsetNodesProfile("OneHanded");
		if(bEnableHairPhysics)
		{
			EnableHairRagdoll();
		}
		SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		LastEnemyHitTimeOut = WorldInfo.TimeSeconds;
		DisableFootPlacement();
	}
	
	public override /*function */void Restart()
	{
		base.Restart();
		Init1P();
	}
	
	public override /*simulated function */void ClientRestart()
	{
		base.ClientRestart();
		Init1P();
	}
	
	public virtual /*simulated function */void Init1P()
	{
		/*local */bool bIsFirstPerson = default, bIsServer = default;
	
		bIsFirstPerson = IsLocallyControlled();
		bIsServer = ((((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) || ((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/));
		if((bIsFirstPerson || bIsServer))
		{
			Enable1P();		
		}
		else
		{
			Mesh1p = default;
			Mesh1pLowerBody = default;
		}
	}
	
	public virtual /*simulated function */void Enable1P()
	{
		AttachComponent(Mesh1p);
		AttachComponent(Mesh1pLowerBody);
		CacheAnimNodes1P();
		Init1pArms();
		InitSwanNeck();
		SetFirstPerson(true);
	}
	
	public virtual /*simulated function */void CacheAnimNodes1P()
	{
		/*local */AnimNode Node = default;
	
		RootControl1p = ((Mesh1p.FindSkelControl("RootControl")) as SkelControlSingleBone);
		HipsControl1p = ((Mesh1p.FindSkelControl("HipsControl")) as SkelControlSingleBone);
		HipsControl3p = ((Mesh3p.FindSkelControl("HipsControl")) as SkelControlSingleBone);
		SwingControl1p = ((Mesh1p.FindSkelControl("SwingControl")) as SkelControlSingleBone);
		CameraControl1p = ((Mesh1p.FindSkelControl("CameraSpring")) as TdSkelControlSimpleSpring);
		RecoilControl1p = ((Mesh1p.FindSkelControl("RightHandRecoil")) as TdSkelControlRecoil);
		CameraNoiseControlRoll1p = ((Mesh1p.FindSkelControl("CameraNoiseControlRoll")) as TdSkelControlRandom);
		CameraNoiseControlPitch1p = ((Mesh1p.FindSkelControl("CameraNoiseControlPitch")) as TdSkelControlRandom);
		LeftLegControl1p = ((Mesh1p.FindSkelControl("LeftFootPlacementControl")) as TdSkelControlFootPlacement);
		RightLegControl1p = ((Mesh1p.FindSkelControl("RightFootPlacementControl")) as TdSkelControlFootPlacement);
		OneHandedRightShoulderOffset1p = ((Mesh1p.FindSkelControl("OneHandedRightShoulderOffset")) as SkelControlSingleBone);
		BlinkControl = ((Mesh3p.FindSkelControl("BlinkControl")) as SkelControlSingleBone);
		RecoilControl1p.SetSkelControlStrength(0.0f, 0.0f);
		OneHandedRightShoulderOffset1p.SetSkelControlStrength(0.0f, 0.0f);
		LeftHandWorldIKController = ((Mesh1p.FindSkelControl("LeftHandWorldIKController")) as TdSkelControlLimb);
		RightHandWorldIKController = ((Mesh1p.FindSkelControl("RightHandWorldIKController")) as TdSkelControlLimb);
		LeftHandLocalIKController = ((Mesh1p.FindSkelControl("LeftHandLocalIKController")) as SkelControlLimb);
		RightHandLocalIKController = ((Mesh1p.FindSkelControl("RightHandLocalIKController")) as SkelControlLimb);
		LeftHandRotationController = ((Mesh1p.FindSkelControl("LeftHandRotation")) as SkelControlSingleBone);
		RightHandRotationController = ((Mesh1p.FindSkelControl("RightHandRotation")) as SkelControlSingleBone);
		HeavyWeaponSpringController = ((Mesh1p.FindSkelControl("HeavyWeaponSpringController")) as TdSkelControlSpring);
		LeftForeArmRollRotationController = ((Mesh1p.FindSkelControl("LeftForeArmRollRotation")) as SkelControlSingleBone);
		RightForeArmRollRotationController = ((Mesh1p.FindSkelControl("RightForeArmRollRotation")) as SkelControlSingleBone);
		LeftHandWorldIKController.SetSkelControlStrength(0.0f, 0.0f);
		RightHandWorldIKController.SetSkelControlStrength(0.0f, 0.0f);
		LeftLegControl1p.SetSkelControlStrength(0.0f, 0.0f);
		RightLegControl1p.SetSkelControlStrength(0.0f, 0.0f);
		RootControl1p.SetSkelControlStrength(0.0f, 0.0f);
		
		// foreach Mesh1p.AllAnimNodes(ClassT<AnimNode>(), ref/*probably?*/ Node)
		using var e938 = Mesh1p.AllAnimNodes(ClassT<AnimNode>()).GetEnumerator();
		while(e938.MoveNext() && (Node = (AnimNode)e938.Current) == Node)
		{
			if(Node.NodeName == "None")
			{
				continue;			
				continue;
			}
			if(Node.NodeName == "MasterSync")
			{
				MasterSync1p = ((Node) as AnimNodeSynch);
				continue;
			}
			if(Node.NodeName == "WeaponPoseOffset")
			{
				WeaponPoseOffset1p = ((Node) as TdAnimNodePoseOffset);
				continue;
			}
			if(Node.NodeName == "Custom_Canned")
			{
				CustomCannedNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_CannedUpperBody")
			{
				CustomCannedUpperBodyNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_FullBody")
			{
				CustomFullBodyNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_FullBody_Dir")
			{
				CustomFullBodyDirNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_UpperBody")
			{
				CustomUpperBodyNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_LowerBody")
			{
				CustomLowerBodyNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_Camera")
			{
				CustomCameraNode = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_Weapon")
			{
				CustomWeaponNode1p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "LandNode")
			{
				LandNode1p = ((Node) as TdAnimNodeLandOffset);
				continue;
			}
			if(Node.NodeName == "GrabNode")
			{
				GrabAnimNode1p = ((Node) as TdAnimNodeGrabbing);
				continue;
			}
			if(Node.NodeName == "ZipLine")
			{
				((Moves[27]) as TdMove_IntoZipLine).SetIdleAnimationReference1p(((Node) as TdAnimNodeSequence));
			}		
		}	
	}
	
	public virtual /*simulated function */void Init1pArms()
	{
		/*local */int Idx = default;
	
		if(Mesh1p == default)
		{
			return;
		}
		BoneNames1p[0] = "RightForeArm";
		BoneNames1p[1] = "RightForeArmRoll";
		BoneNames1p[2] = "RightHandIndex0";
		BoneNames1p[3] = "RightHandIndex1";
		BoneNames1p[4] = "RightHandMiddle0";
		BoneNames1p[5] = "RightHandMiddle1";
		BoneNames1p[6] = "LeftForeArm";
		BoneNames1p[7] = "LeftForeArmRoll";
		BoneNames1p[8] = "LeftHandIndex0";
		BoneNames1p[9] = "LeftHandIndex1";
		BoneNames1p[10] = "LeftHandMiddle0";
		BoneNames1p[11] = "LeftHandMiddle1";
		HandNormalMapNames1p[0] = "Right";
		HandNormalMapNames1p[1] = "Right";
		HandNormalMapNames1p[2] = "Right";
		HandNormalMapNames1p[3] = "Right";
		HandNormalMapNames1p[4] = "Right";
		HandNormalMapNames1p[5] = "Left";
		HandNormalMapNames1p[6] = "Left";
		HandNormalMapNames1p[7] = "Left";
		HandNormalMapNames1p[8] = "Left";
		HandNormalMapNames1p[9] = "Left";
		MorphNodeWeight1p[0] = ((Mesh1p.FindMorphNode("RightForeArmRollBlend90")) as MorphNodeWeight);
		MorphNodeWeight1p[1] = ((Mesh1p.FindMorphNode("RightForeArmRollBlend90m")) as MorphNodeWeight);
		MorphNodeWeight1p[2] = ((Mesh1p.FindMorphNode("LeftForeArmRollBlend90")) as MorphNodeWeight);
		MorphNodeWeight1p[3] = ((Mesh1p.FindMorphNode("LeftForeArmRollBlend90m")) as MorphNodeWeight);
		bHasMorphNodes = true;
		Idx = 0;
		J0x23E:{}
		if(Idx < 4)
		{
			if(MorphNodeWeight1p[Idx] == default)
			{
				bHasMorphNodes = false;
				goto J0x270;
			}
			++ Idx;
			goto J0x23E;
		}
		J0x270:{}
	}
	
	public virtual /*simulated event */void EnableHairRagdoll()
	{
		/*local */int I = default, J = default;
	
		if(bEnableHairPhysics)
		{
			Mesh3p.PhysicsAssetInstance.SetNamedBodiesFixed(false, HairBones.NewCopy(), Mesh3p, false);
			I = 0;
			J0x36:{}
			if(I < Mesh3p.PhysicsAsset.BodySetup.Length)
			{
				J = 0;
				J0x61:{}
				if(J < HairBones.Length)
				{
					if(Mesh3p.PhysicsAsset.BodySetup[I].BoneName == HairBones[J])
					{
						Mesh3p.PhysicsAsset.BodySetup[I].bAlwaysFullAnimWeight = true;
						goto J0xE3;
					}
					++ J;
					goto J0x61;
				}
				J0xE3:{}
				++ I;
				goto J0x36;
			}
		}
	}
	
	public virtual /*simulated event */void DisableHairRagdoll()
	{
		Mesh3p.PhysicsAssetInstance.SetNamedBodiesFixed(true, HairBones.NewCopy(), Mesh3p, false);
	}
	
	public override /*simulated function */void PlayDying(Core.ClassT<DamageType> DamageType, Object.Vector HitLoc)
	{
		SetIgnoreMoveInput(default(float?));
		SetIgnoreLookInput(default(float?));
		UpdateAnimSets(default);
		if(((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/)) || ((int)MovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/)))
		{
			((Controller) as TdPlayerController).SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_DEATH_BY_FALLING/*8*/, default(float?), default(bool?), 1.50f);
			SetTimer(0.010f, false, "PlayDeathAnim", default(Object));		
		}
		else
		{
			((Controller) as TdPlayerController).SetSoundMode(AudioDevice.ESoundMode.SOUNDMODE_GENERIC_DEATH/*9*/, default(float?), default(bool?), 1.0f);
			SetTimer(0.50f, false, "PlayDeathAnim", default(Object));
		}
		bCollideWorld = true;
		SetCollision(bCollideActors, true, default(bool?));
		Controller.GotoState("PlayerDying", default(name?), default(bool?), default(bool?));
		base.PlayDying(DamageType, HitLoc);
	}
	
	public virtual /*function */void PlayDeathAnim()
	{
		/*local */TdPawn.EMovement DeathMove = default;
		/*local */bool bUseRootMotion = default;
	
		bUseRootMotion = false;
		DeathMove = ((TdPawn.EMovement)MovementState);
		if(((int)MovementState) != ((int)TdPawn.EMovement.MOVE_LayOnGround/*26*/))
		{
			SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		}
		Moves[((int)MovementState)].ResetCameraLook(0.20f);
		switch(DeathMove)
		{
			case TdPawn.EMovement.MOVE_180TurnInAir/*25*/:
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "FallingLandDieBwd", 1.0f, 0.30f, -1.0f, false, true, false, default(bool));
				SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
				break;
			case TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/:
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "FallingLandDie", 1.0f, 0.30f, -1.0f, false, true, false, default(bool));
				SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
				break;
			case TdPawn.EMovement.MOVE_Crouch/*15*/:
			case TdPawn.EMovement.MOVE_Slide/*16*/:
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "diecrouch", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));
				bUseRootMotion = true;
				break;
			case TdPawn.EMovement.MOVE_LayOnGround/*26*/:
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "DiePursuitFinish", 1.0f, 0.30f, -1.0f, false, true, false, default(bool));
				SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
				bUseRootMotion = true;
				break;
			case TdPawn.EMovement.MOVE_Falling/*2*/:
				SetAnimationMovementState(TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/, default(float?));
				break;
			case TdPawn.EMovement.MOVE_LedgeWalk/*30*/:
				if(((int)AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/))
				{
					SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
					break;
				}
				goto default;// UnrealScript fallthrough
			default:
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "die", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));
				bUseRootMotion = true;
				break;
		}
		if(bUseRootMotion)
		{
			Velocity = vect(0.0f, 0.0f, 0.0f);
			SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
			UseRootMotion(true);
			SetTimer(2.0f, false, "TurnOffRootMotion", default(Object));
		}
	}
	
	public virtual /*function */void TurnOffRootMotion()
	{
		Velocity = vect(0.0f, 0.0f, 0.0f);
		CustomCannedNode1p.SetRootBoneAxisOption(AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/, AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/, AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/);
		CustomCannedNode3p.SetRootBoneAxisOption(AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/, AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/, AnimNodeSequence.ERootBoneAxis.RBA_Default/*0*/);
	}
	
	// Export UTdPlayerPawn::execMAT_BeginAnimControl(FFrame&, void* const)
	//public virtual /*native function */void MAT_BeginAnimControl(array<AnimSet> InAnimSets)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdPlayerPawn::execMAT_SetAnimPosition(FFrame&, void* const)
	//public virtual /*native function */void MAT_SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdPlayerPawn::execMAT_SetAnimWeights(FFrame&, void* const)
	//public virtual /*native function */void MAT_SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export UTdPlayerPawn::execMAT_FinishAnimControl(FFrame&, void* const)
	//public virtual /*native function */void MAT_FinishAnimControl()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	public override /*event */void BeginAnimControl(array<AnimSet> InAnimSets)
	{
		SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetCollision(bCollideActors, false, default(bool?));
		bCollideWorld = false;
		if(InAnimSets.Length > 0)
		{
			Mesh1p.AnimSets[4] = InAnimSets[0];
		}
		if(InAnimSets.Length > 1)
		{
			Mesh3p.AnimSets[4] = InAnimSets[1];
		}
		SetFirstPersonDPG(Scene.ESceneDepthPriorityGroup.SDPG_Intermediate/*2*/);
		MAT_BeginAnimControl(InAnimSets.NewCopy());
		SetTimer(0.50f, false, "CheckForSkippableCutscene", default(Object));
	}
	
	public virtual /*simulated function */void CheckForSkippableCutscene()
	{
		bCutsceneIsSkippable = ((Controller) as TdPlayerController).CheckCutsceneSkippable();
	}
	
	public override /*simulated event */void SetAnimPosition(name SlotName, int ChannelIndex, name InAnimSeqName, float InPosition, bool bFireNotifies, bool bLooping)
	{
		if(!((Controller) as PlayerController).bCinematicMode)
		{
			return;
		}
		MAT_SetAnimPosition(SlotName, ChannelIndex, InAnimSeqName, InPosition, bFireNotifies, bLooping);
	}
	
	public override /*simulated event */void SetAnimWeights(array<Actor.AnimSlotInfo> SlotInfos)
	{
		if(!((Controller) as PlayerController).bCinematicMode)
		{
			return;
		}
		MAT_SetAnimWeights(SlotInfos.NewCopy());
	}
	
	public override /*event */void FinishAnimControl()
	{
		MAT_FinishAnimControl();
		SetMove(TdPawn.EMovement.MOVE_Walking/*1*/, default(bool?), default(bool?));
		SetCollision(bCollideActors, true, default(bool?));
		bCollideWorld = true;
		UseRootMotion(false);
		UseRootRotation(false);
		SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
		if(((Controller) as TdPlayerController) != default)
		{
			((Controller) as TdPlayerController).UnZoom();
		}
		Mesh1p.AnimSets[4] = default;
		Mesh3p.AnimSets[4] = default;
		SetFirstPersonDPG(((Scene.ESceneDepthPriorityGroup)Moves[((int)MovementState)].FirstPersonDPG));
		UpdateAnimSets(((Weapon) as TdWeapon));
		bCutsceneIsSkippable = false;
	}
	
	public override /*simulated function */void UpdateDPG(MeshComponent MeshComp)
	{
		MeshComp.SetDepthPriorityGroup(((Scene.ESceneDepthPriorityGroup)FirstPersonDPG));
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
		/*local */Canvas Canvas = default;
	
		Canvas = HUD.Canvas;
		Canvas.SetDrawColor(0, 255, 0, (byte)default(byte?));
		if(HUD.ShouldDisplayDebug("Health"))
		{
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText("timeSinceLastDamage: " + ((TimeSinceLastDamage)).ToString(), default(bool?), default(float?), default(float?));
			out_YPos += out_YL;
			Canvas.SetPos(4.0f, out_YPos);
			Canvas.DrawText("healthFrac: " + ((HealthFrac)).ToString(), default(bool?), default(float?), default(float?));
		}
		base.DisplayDebug(HUD, ref/*probably?*/ out_YL, ref/*probably?*/ out_YPos);
	}
	
	public override PlayWeaponSwitch_del PlayWeaponSwitch { get => bfield_PlayWeaponSwitch ?? TdPlayerPawn_PlayWeaponSwitch; set => bfield_PlayWeaponSwitch = value; } PlayWeaponSwitch_del bfield_PlayWeaponSwitch;
	public override PlayWeaponSwitch_del global_PlayWeaponSwitch => TdPlayerPawn_PlayWeaponSwitch;
	public /*simulated function */void TdPlayerPawn_PlayWeaponSwitch(Weapon OldWeapon, Weapon NewWeapon)
	{
		/*Transformed 'base.' to specific call*/TdPawn_PlayWeaponSwitch(OldWeapon, NewWeapon);
		NotifyPlayerSwitchedWeapon(NewWeapon);
	}
	
	public virtual /*function */void NotifyPlayerSwitchedWeapon(Weapon PlayerWeapon)
	{
		/*local */int Index = default;
		/*local */Sequence GameSequence = default;
		/*local */array<SequenceObject> SequenceEvents = default;
		/*local */SeqEvt_TdPlayerSwitchedWeapon PlayerSwitchedWeaponEvent = default;
	
		GameSequence = WorldInfo.GetGameSequence();
		GameSequence.FindSeqObjectsByClass(ClassT<SeqEvt_TdPlayerSwitchedWeapon>(), true, ref/*probably?*/ SequenceEvents);
		Index = 0;
		J0x38:{}
		if(Index < SequenceEvents.Length)
		{
			PlayerSwitchedWeaponEvent = ((SequenceEvents[Index]) as SeqEvt_TdPlayerSwitchedWeapon);
			if(!ClassIsChildOf(PlayerWeapon.Class, PlayerSwitchedWeaponEvent.ConditionalWeaponClass))
			{
				goto J0xD8;
			}
			if((PlayerSwitchedWeaponEvent.ConditionalVolume != default) && !IsTouchingVolume(PlayerSwitchedWeaponEvent.ConditionalVolume))
			{
				goto J0xD8;
			}
			PlayerSwitchedWeaponEvent.CheckActivate(this, PlayerWeapon, default(bool?), ref/*probably?*/ /*null*/NullRef.array_int_, default(bool?));
			J0xD8:{}
			++ Index;
			goto J0x38;
		}
	}
	
	public virtual /*function */void SetShadowType(SkeletalMeshComponent MyMesh, LightComponent.ELightShadowMode ShadowMode)
	{
		/*local *//*editinline */DynamicLightEnvironmentComponent Env = default;
	
		Env = ((MyMesh.LightEnvironment) as DynamicLightEnvironmentComponent);
		if(Env != default)
		{
			Env.LightShadowMode = ((LightComponent.ELightShadowMode)ShadowMode);
		}
	}
	protected override void RestoreDefaultFunction()
	{
		TakeDamage = null;
		Died = null;
		Landed = null;
		eventTick = null;
		PlayWeaponSwitch = null;
	
	}
	
	protected /*event */void TdPlayerPawn_Dying_BeginState(name PreviousStateName)// state function
	{
		if(PreviousStateName == "UncontrolledFall")
		{
			SetTimer(0.40f, false, "DestroyPawn", default(Object));		
		}
		else
		{
			PlayDeathEffect();
			SetTimer(2.50f, false, "DestroyPawn", default(Object));
		}
	}
	
	protected /*simulated function */void TdPlayerPawn_Dying_PlayDeathEffect()// state function
	{
		/*local */TdPlayerController PC = default;
	
		if((Controller != default) && Controller.IsA("TdPlayerController"))
		{
			PC = ((Controller) as TdPlayerController);
			if(PC.myHUD != default)
			{
				PC.myHUD.PlayerOwnerDied();
			}
		}
	}
	
	protected /*event */void TdPlayerPawn_Dying_Landed(Object.Vector aNormal, Actor anActor)// state function
	{
		/*Transformed 'base.' to specific call*/Pawn_Landed(aNormal, anActor);
		SetPhysics(Actor.EPhysics.PHYS_Flying/*4*/);
		UseRootMotion(true);
		Velocity = vect(0.0f, 0.0f, 0.0f);
		SetTimer(2.0f, false, "TurnOffRootMotion", default(Object));
		if(((((int)OldMovementState) == ((int)TdPawn.EMovement.MOVE_Grabbing/*3*/)) || ((int)OldMovementState) == ((int)TdPawn.EMovement.MOVE_Climb/*21*/)))
		{
			PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "die", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));		
		}
		else
		{
			if(((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_Falling/*2*/)) || ((int)MovementState) == ((int)TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/)))
			{
				PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "FallingLandDie", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));			
			}
			else
			{
				if(((int)MovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/))
				{
					PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "FallingLandDieBwd", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));				
				}
				else
				{
					PlayCustomAnim(TdPawn.CustomNodeType.CNT_Canned/*0*/, "die", 1.0f, 0.30f, -1.0f, false, true, true, default(bool));
				}
			}
		}
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) Dying()/*simulated state Dying*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			PlayDeathEffect = TdPlayerPawn_Dying_PlayDeathEffect;
			Landed = TdPlayerPawn_Dying_Landed;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerPawn_Dying_BeginState, StateFlow, null);
	}
	
	
	protected /*simulated event */bool TdPlayerPawn_UncontrolledFall_SetMove(TdPawn.EMovement NewMove, /*optional */bool? _bViaReplication = default, /*optional */bool? _bCheckCanDo = default)// state function
	{
		var bViaReplication = _bViaReplication ?? false;
		var bCheckCanDo = _bCheckCanDo ?? false;
		if((((int)NewMove) != ((int)TdPawn.EMovement.MOVE_Landing/*20*/)) && ((int)NewMove) != ((int)TdPawn.EMovement.MOVE_SoftLanding/*78*/))
		{
			return false;
		}
		return /*Transformed 'base.' to specific call*/TdPawn_SetMove(((TdPawn.EMovement)NewMove), bViaReplication, bCheckCanDo);
	}
	
	protected /*function */void TdPlayerPawn_UncontrolledFall_BeginState(name PreviousStateName)// state function
	{
		SetIgnoreMoveInput(-1.0f);
		SetIgnoreLookInput(-1.0f);
		FallingSound = CreateAudioComponent(ObjectConst<SoundCue>("Death_Fall"), true, true, default(bool?), default(Object.Vector?), default(bool?));
	}
	
	protected /*function */void TdPlayerPawn_UncontrolledFall_EndState(name NextStateName)// state function
	{
		FallingSound.FadeOut(0.10f, 0.0f);
	}
	
	protected /*event */void TdPlayerPawn_UncontrolledFall_Landed(Object.Vector aNormal, Actor anActor)// state function
	{
		if((bTakeFallDamage || ((int)MovementState) != ((int)TdPawn.EMovement.MOVE_SoftLanding/*78*/)))
		{
			TakeFallingDamage();
		}
		if(Moves[20].CanDoMove())
		{
			SetMove(TdPawn.EMovement.MOVE_Landing/*20*/, default(bool?), default(bool?));
		}
		if(Health > 0)
		{
			GotoState("None", default(name?), default(bool?), default(bool?));		
		}
		else
		{
			PlaySound(ObjectConst<SoundCue>("Death_Impact"), true, false, false, default(Object.Vector?), default(bool?), default(bool?));
		}
	}
	
	protected /*simulated function */bool TdPlayerPawn_UncontrolledFall_CanSkillRoll()// state function
	{
		return false;
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) UncontrolledFall()/*simulated state UncontrolledFall*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ HandleMoveAction = (_a)=>{};
	
			SetMove = TdPlayerPawn_UncontrolledFall_SetMove;
			Landed = TdPlayerPawn_UncontrolledFall_Landed;
			CanSkillRoll = TdPlayerPawn_UncontrolledFall_CanSkillRoll;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdPlayerPawn_UncontrolledFall_BeginState, StateFlow, TdPlayerPawn_UncontrolledFall_EndState);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Dying": return Dying();
			case "UncontrolledFall": return UncontrolledFall();
			default: return base.FindState(stateName);
		}
	}
	public TdPlayerPawn()
	{
		var Default__TdPlayerPawn_MyLightEnvironment1P = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x0067F618
			LightDistance = 8.0f,
			ShadowDistance = 2.50f,
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment1P' */;
		var Default__TdPlayerPawn_TdPawnMesh1p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0067F668
			FOV = 90.0f,
			SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer_1P.SK_UpperBody")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer_1P.SK_UpperBody'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_C1P.AT_C1P")/*Ref AnimTree'AT_C1P.AT_C1P'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Crim_Fixer_1P.Female1p_UpperBody_Physics")/*Ref PhysicsAsset'CH_TKY_Crim_Fixer_1P.Female1p_UpperBody_Physics'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_C1P_Unarmed.AS_C1P_Unarmed")/*Ref TdAnimSet'AS_C1P_Unarmed.AS_C1P_Unarmed'*/,
				default,
				default,
				default,
				default,
			},
			MorphSets = new array<MorphTargetSet>
			{
				LoadAsset<MorphTargetSet>("CH_TKY_Crim_Fixer_1P.Female1p_UpperBody_MorphSet")/*Ref MorphTargetSet'CH_TKY_Crim_Fixer_1P.Female1p_UpperBody_MorphSet'*/,
			},
			bHasPhysicsAssetInstance = true,
			bDisableWarningWhenAnimNotFound = true,
			LightEnvironment = Default__TdPlayerPawn_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment1P'*/,
			DepthPriorityGroup = Scene.ESceneDepthPriorityGroup.SDPG_Foreground,
			bOnlyOwnerSee = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh1p' */;
		var Default__TdPlayerPawn_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment' */;
		var Default__TdPlayerPawn_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0067F510
			SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer'*/,
			AnimTreeTemplate = LoadAsset<AnimTree>("AT_C3P.AT_C3P")/*Ref AnimTree'AT_C3P.AT_C3P'*/,
			PhysicsAsset = LoadAsset<PhysicsAsset>("CH_TKY_Crim_Fixer.Faith3p_Physics")/*Ref PhysicsAsset'CH_TKY_Crim_Fixer.Faith3p_Physics'*/,
			AnimSets = new array<AnimSet>
			{
				LoadAsset<TdAnimSet>("AS_F3P_Unarmed.AS_F3P_Unarmed")/*Ref TdAnimSet'AS_F3P_Unarmed.AS_F3P_Unarmed'*/,
				default,
				default,
				LoadAsset<TdAnimSet>("AS_F3P_Face.AS_F3P_Face")/*Ref TdAnimSet'AS_F3P_Face.AS_F3P_Face'*/,
				default,
			},
			bEnableFullAnimWeightBodies = true,
			LightEnvironment = Default__TdPlayerPawn_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment'*/,
			bRenderInLiteMirror = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh3p' */;
		var Default__TdPlayerPawn_TdPawnMesh1pLowerBody = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0067F7D0
			FOV = 90.0f,
			SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer_1P.SK_LowerBody")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer_1P.SK_LowerBody'*/,
			ParentAnimComponent = Default__TdPlayerPawn_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh1p'*/,
			bUpdateSkelWhenNotRendered = false,
			bIgnoreControllersWhenNotRendered = true,
			bDisableWarningWhenAnimNotFound = true,
			LightEnvironment = Default__TdPlayerPawn_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment'*/,
			DepthPriorityGroup = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate,
			bOnlyOwnerSee = true,
		}/* Reference: TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh1pLowerBody' */;
		// Object Offset:0x00630A38
		bEnableHairPhysics = true;
		FirstPersonDPG = Scene.ESceneDepthPriorityGroup.SDPG_Foreground;
		FirstPersonLowerBodyDPG = Scene.ESceneDepthPriorityGroup.SDPG_Intermediate;
		WindSoundSC = LoadAsset<SoundCue>("A_Character_Effects.Movement.RunWind")/*Ref SoundCue'A_Character_Effects.Movement.RunWind'*/;
		VertigoEdgeProbingHeight = 1000.0f;
		VertigoEdgeProbingDistance = 70.0f;
		VertigoEffectThreshold = 0.90f;
		EdgeCheckMaxSpeed = 300.0f;
		EdgeCheckDistance = 20.0f;
		EdgeStopMinHeight = 36.0f;
		ReverbVolumePollTime = 0.40f;
		OcclusionDuckLevel = 0.150f;
		OcclusionDuckFadeTime = 0.60f;
		IndoorSoundGroupIndex = -1;
		IndoorMixGroupIndex = -1;
		OutdoorMixGroupIndex = -1;
		MovementStringAllowedGap = 0.90f;
		PlayerBulletDamageMultiplier = 1.0f;
		HairBones = new array<name>
		{
			(name)"RagdollJoint01",
			(name)"RagdollJoint02",
			(name)"RagdollJoint03",
			(name)"RagdollJoint04",
			(name)"RagdollJoint05",
			(name)"RagdollJoint06",
		};
		FocusLocationInterpolationSpeed = 20.0f;
		CommonArmedLight1p = LoadAsset<TdAnimSet>("AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common")/*Ref TdAnimSet'AS_C1P_OneHanded_Common.AS_C1P_OneHanded_Common'*/;
		CommonArmedHeavy1p = LoadAsset<TdAnimSet>("AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common")/*Ref TdAnimSet'AS_C1P_TwoHanded_Common.AS_C1P_TwoHanded_Common'*/;
		CommonArmedLight3p = LoadAsset<TdAnimSet>("AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common")/*Ref TdAnimSet'AS_F3P_OneHanded_Common.AS_F3P_OneHanded_Common'*/;
		CommonArmedHeavy3p = LoadAsset<TdAnimSet>("AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common")/*Ref TdAnimSet'AS_F3P_TwoHanded_Common.AS_F3P_TwoHanded_Common'*/;
		OldMovementState = TdPawn.EMovement.MOVE_None;
		MovementState = TdPawn.EMovement.MOVE_None;
		NoOfBreathingSounds = 8;
		Mesh1p = Default__TdPlayerPawn_TdPawnMesh1p/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh1p'*/;
		Mesh3p = Default__TdPlayerPawn_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh3p'*/;
		Mesh1pLowerBody = Default__TdPlayerPawn_TdPawnMesh1pLowerBody/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh1pLowerBody'*/;
		BrakingFrictionStrength = 0.50f;
		ArmorBulletsHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.70f,
			Medium = 0.50f,
			Hard = 0.30f,
		};
		ArmorBulletsBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.70f,
			Medium = 0.50f,
			Hard = 0.30f,
		};
		ArmorBulletsLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.70f,
			Medium = 0.50f,
			Hard = 0.30f,
		};
		ArmorMeleeHeadSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Hard = -0.30f,
		};
		ArmorMeleeBodySettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Hard = -0.30f,
		};
		ArmorMeleeLegsSettings = new TdPawn.ArmorSettings
		{
			Easy = 0.30f,
			Hard = -0.30f,
		};
		CharacterSoundCues = new array<SoundCue>
		{
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Soft.Breath_Soft_Short_In")/*Ref SoundCue'A_Character_Female_01.Breath_Soft.Breath_Soft_Short_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Soft.Breath_Soft_Short_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Soft.Breath_Soft_Short_Out'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Soft.Breath_Soft_Long_In")/*Ref SoundCue'A_Character_Female_01.Breath_Soft.Breath_Soft_Long_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Soft.Breath_Soft_Long_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Soft.Breath_Soft_Long_Out'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Medium.Breath_Medium_Short_In")/*Ref SoundCue'A_Character_Female_01.Breath_Medium.Breath_Medium_Short_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Medium.Breath_Medium_Short_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Medium.Breath_Medium_Short_Out'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Medium.Breath_Medium_Long_In")/*Ref SoundCue'A_Character_Female_01.Breath_Medium.Breath_Medium_Long_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Medium.Breath_Medium_Long_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Medium.Breath_Medium_Long_Out'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Hard.Breath_Hard_Short_In")/*Ref SoundCue'A_Character_Female_01.Breath_Hard.Breath_Hard_Short_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Hard.Breath_Hard_Short_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Hard.Breath_Hard_Short_Out'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Hard.Breath_Hard_Long_In")/*Ref SoundCue'A_Character_Female_01.Breath_Hard.Breath_Hard_Long_In'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Breath_Hard.Breath_Hard_Long_Out")/*Ref SoundCue'A_Character_Female_01.Breath_Hard.Breath_Hard_Long_Out'*/,
			default,
			default,
			default,
			default,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Impact.Soft")/*Ref SoundCue'A_Character_Female_01.Oral_Impact.Soft'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Impact.Medium")/*Ref SoundCue'A_Character_Female_01.Oral_Impact.Medium'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Impact.Hard")/*Ref SoundCue'A_Character_Female_01.Oral_Impact.Hard'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Strain.Soft")/*Ref SoundCue'A_Character_Female_01.Oral_Strain.Soft'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Strain.Medium")/*Ref SoundCue'A_Character_Female_01.Oral_Strain.Medium'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Strain.Hard")/*Ref SoundCue'A_Character_Female_01.Oral_Strain.Hard'*/,
			default,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Snatch.Snatch")/*Ref SoundCue'A_Character_Female_01.Oral_Snatch.Snatch'*/,
			default,
			LoadAsset<SoundCue>("A_Character_Female_01.Oral_Death.Death")/*Ref SoundCue'A_Character_Female_01.Oral_Death.Death'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Cloth.Crouch")/*Ref SoundCue'A_Character_Female_01.Cloth.Crouch'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Cloth.Walk")/*Ref SoundCue'A_Character_Female_01.Cloth.Walk'*/,
			LoadAsset<SoundCue>("A_Character_Female_01.Cloth.Run")/*Ref SoundCue'A_Character_Female_01.Cloth.Run'*/,
			LoadAsset<SoundCue>("A_Character_Effects.Movement.Vault")/*Ref SoundCue'A_Character_Effects.Movement.Vault'*/,
		};
		RegenerateDelay = 5.0f;
		RegenerateHealthPerSecond = 25.0f;
		bAvoidLedges = true;
		bDirectHitWall = true;
		Mesh = Default__TdPlayerPawn_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh3p'*/;
		Components.Add(Default__TdPlayerPawn_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment'*/);
		Components.Add(Default__TdPlayerPawn_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdPlayerPawn.TdPawnMesh3p'*/);
		Components.Add(Default__TdPlayerPawn_MyLightEnvironment1P/*Ref DynamicLightEnvironmentComponent'Default__TdPlayerPawn.MyLightEnvironment1P'*/);
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdKillZoneVolume : Volume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public partial struct LaserInfo
	{
		public TdEmitter Source;
		public TdEmitter Beam;
		public TdEmitter Hit;
		public Object.Vector Location;
		public Object.Rotator CurrentAim;
		public Object.Vector HitLocation;
		public float AimingTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00581377
	//		Source = default;
	//		Beam = default;
	//		Hit = default;
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		CurrentAim = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		HitLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		AimingTime = 0.0f;
	//	}
	};
	
	public/*(KillKillKill)*/ array<TdKillZoneKiller> LaserShooters;
	public/*(KillKillKill)*/ float DamagePerShot;
	public ParticleSystem LaserBeamTemplate;
	public ParticleSystem LaserHitTemplate;
	public ParticleSystem LaserSourceTemplate;
	public array<TdKillZoneVolume.LaserInfo> LaserInfos;
	public int CurrentFire;
	public bool bFire;
	public /*private transient */bool bActive;
	public float TimeToAim;
	public SoundCue WeaponSound;
	public SoundCue WeaponReverbSound;
	public SoundCue WeaponSlapBackSound;
	public int MaxNumberOfSlapBackRays;
	public int NumberOfSlapBacks;
	public float RangeOfSlapBackRays;
	public /*private transient */TdPlayerPawn Player;
	
	public override /*event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		SetupLasers();
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdKillZoneVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdKillZoneVolume_Touch;
	public /*event */void TdKillZoneVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		if(Other.IsA("TdPlayerPawn"))
		{
			Player = ((Other) as TdPlayerPawn);
			StartLasers();
			if(LaserInfos.Length > 0)
			{
				PlayFireSound(LaserInfos[0]);
			}
		}
	}
	
	public override UnTouch_del UnTouch { get => bfield_UnTouch ?? TdKillZoneVolume_UnTouch; set => bfield_UnTouch = value; } UnTouch_del bfield_UnTouch;
	public override UnTouch_del global_UnTouch => TdKillZoneVolume_UnTouch;
	public /*event */void TdKillZoneVolume_UnTouch(Actor Other)
	{
	
	}
	
	public virtual /*private final function */void SetupLasers()
	{
		/*local */int I = default;
		/*local */Object.Vector Loc = default;
	
		I = 0;
		J0x07:{}
		if(I < LaserShooters.Length)
		{
			Loc = LaserShooters[I].Location + vect(0.0f, 0.0f, 65.0f);
			LaserInfos[I] = CreateLaser(Loc);
			++ I;
			goto J0x07;
		}
	}
	
	public virtual /*private final function */TdKillZoneVolume.LaserInfo CreateLaser(Object.Vector Loc)
	{
		/*local */TdKillZoneVolume.LaserInfo Info = default;
	
		Info.Source = CreateEmitter(LaserSourceTemplate, Loc);
		Info.Beam = CreateEmitter(LaserBeamTemplate, Loc);
		Info.Hit = CreateEmitter(LaserHitTemplate, Loc);
		Info.Location = Loc;
		return Info;
	}
	
	public virtual /*private final function */TdEmitter CreateEmitter(ParticleSystem Template, Object.Vector Loc)
	{
		/*local */TdEmitter TheEmitter = default;
	
		TheEmitter = Spawn(ClassT<TdEmitter>(), default, default, default, default, default, default);
		TheEmitter.SetTemplate(Template, false);
		TheEmitter.bDestroyOnSystemFinish = false;
		TheEmitter.LifeSpan = 0.0f;
		TheEmitter.bStasis = false;
		TheEmitter.SetHidden(true);
		TheEmitter.SetLocation(Loc);
		TheEmitter.SetDrawScale3D(vect(1.0f, 1.0f, 1.0f));
		TheEmitter.ParticleSystemComponent.ActivateSystem(default);
		return TheEmitter;
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdKillZoneVolume_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdKillZoneVolume_Tick;
	public /*event */void TdKillZoneVolume_Tick(float DeltaTime)
	{
		if(!bActive)
		{
			return;
		}
		if(Player.Health <= 0)
		{
			StopLasers();
		}
		/*Transformed 'base.' to specific call*/Actor_Tick(DeltaTime);
		UpdateLasers(DeltaTime);
	}
	
	public virtual /*private final function */void Fire(TdKillZoneVolume.LaserInfo LI)
	{
		PlayFireSound(LI);
		if(Player != default)
		{
			Player.TakeDamage(((int)(DamagePerShot)), default, LI.HitLocation, (LI.HitLocation - LI.Location) * 700.0f, ClassT<TdDmgType_Sniper_Bullet>(), default, default);
		}
	}
	
	public virtual /*function */void PlayFireSound(TdKillZoneVolume.LaserInfo LI)
	{
		PlaySound(WeaponSound, false, true, false, LI.Location, default, false);
		PlaySound(WeaponReverbSound, false, true, false, LI.Location, default, false);
		PlaySlapback(LI, WeaponSlapBackSound);
	}
	
	public virtual /*function */void PlaySlapback(TdKillZoneVolume.LaserInfo LI, SoundCue SC)
	{
		/*local */Object.Vector EndTrace = default, AimDir = default, RealStartLoc = default, HitNormal = default, HitLocation = default;
	
		/*local */int I = default, Counter = default;
		/*local */float Angle = default, AngleLimit = default, usedangle = default;
		/*local */Actor HitObject = default;
	
		AngleLimit = 3.1415930f * 1.50f;
		RealStartLoc = LI.Location;
		AimDir = ((Vector)(LI.CurrentAim));
		AimDir.Z = 0.0f;
		Angle = (((float)(((Rotator)(AimDir)).Yaw)) * (3.1415930f / ((float)(32768)))) - (AngleLimit * 0.50f);
		Counter = 0;
		I = 0;
		J0x9C:{}
		if((I < MaxNumberOfSlapBackRays) && Counter < NumberOfSlapBacks)
		{
			usedangle = Angle + RandRange(0.0f, AngleLimit);
			AimDir.X = Cos(usedangle);
			AimDir.Y = Sin(usedangle);
			EndTrace = RealStartLoc + (AimDir * RangeOfSlapBackRays);
			HitObject = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, EndTrace, RealStartLoc, false, default, ref/*probably?*/ /*null*/NullRef.Actor_TraceHitInfo, default);
			if(HitObject != default)
			{
				++ Counter;
				if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
				{
					PlaySound(SC, false, true, false, HitLocation, default, default);
					goto J0x19C;
				}
				PlaySound(SC, false, false, false, HitLocation, default, default);
			}
			J0x19C:{}
			++ I;
			goto J0x9C;
		}
	}
	
	public virtual /*private final function */void TimedFire()
	{
		bFire = true;
		Fire(LaserInfos[CurrentFire]);
		++ CurrentFire;
		CurrentFire = CurrentFire % LaserInfos.Length;
		SetTimer(0.30f + (0.30f * FRand()), false, "TimedFire", default);
	}
	
	public virtual /*private final function */void StartLasers()
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < LaserInfos.Length)
		{
			Show(LaserInfos[I]);
			LaserInfos[I].CurrentAim = CalculateAim(LaserInfos[I], 500.0f);
			LaserInfos[I].AimingTime = 0.0f;
			++ I;
			goto J0x07;
		}
		bActive = true;
		SetTimer(1.0f, false, "TimedFire", default);
	}
	
	public virtual /*private final function */void StopLasers()
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < LaserInfos.Length)
		{
			Hide(LaserInfos[I]);
			++ I;
			goto J0x07;
		}
		ClearTimer("TimedFire", default);
		bActive = false;
	}
	
	public virtual /*private final function */void Show(TdKillZoneVolume.LaserInfo LI)
	{
		LI.Source.SetHidden(false);
		LI.Beam.SetHidden(false);
		LI.Hit.SetHidden(false);
	}
	
	public virtual /*private final function */void Hide(TdKillZoneVolume.LaserInfo LI)
	{
		LI.Source.SetHidden(true);
		LI.Beam.SetHidden(true);
		LI.Hit.SetHidden(true);
	}
	
	public virtual /*private final function */Object.Rotator CalculateAim(TdKillZoneVolume.LaserInfo LI, float Dist)
	{
		/*local */Object.Rotator PlayerRot = default;
		/*local */Object.Vector PlayerLoc = default, AimLoc = default;
	
		PlayerLoc = Player.Location;
		PlayerRot = Player.Rotation;
		AimLoc = PlayerLoc + (Dist * ((Vector)(PlayerRot)));
		return ((Rotator)(AimLoc - LI.Location));
	}
	
	public virtual /*private final function */Object.Rotator UpdateAim(TdKillZoneVolume.LaserInfo LI, Object.Vector TargetLoc, float DeltaTime)
	{
		/*local */Object.Rotator TargetRotation = default;
	
		if(bFire)
		{
			return ((Rotator)(TargetLoc - LI.Location));
		}
		TargetRotation = CalculateAim(LI, 500.0f - (FMin(LI.AimingTime / TimeToAim, 1.0f) * 500.0f));
		return TargetRotation;
	}
	
	public virtual /*private final function */void UpdateLasers(float DeltaTime)
	{
		/*local */int I = default;
		/*local */Object.Vector PlayerLoc = default;
	
		PlayerLoc = Player.Location;
		I = 0;
		J0x1C:{}
		if(I < LaserInfos.Length)
		{
			LaserInfos[I].AimingTime += DeltaTime;
			LaserInfos[I].CurrentAim = UpdateAim(LaserInfos[I], PlayerLoc, DeltaTime);
			UpdateBeam(PlayerLoc, LaserInfos[I], DeltaTime);
			++ I;
			goto J0x1C;
		}
	}
	
	public virtual /*private final function */void UpdateBeam(Object.Vector PlayerLoc, TdKillZoneVolume.LaserInfo LI, float DeltaTime)
	{
		/*local */Object.Vector HitLocation = default, HitNormal = default;
		/*local */float TracedDistance = default;
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */Actor HitActor = default;
		/*local */Object.Vector ScaleVec = default, LaserDir = default, TargetLocation = default;
		/*local */TdEmitter Beam = default, Hit = default;
	
		Beam = LI.Beam;
		Hit = LI.Hit;
		LaserDir = ((Vector)(LI.CurrentAim));
		TargetLocation = LI.Location + (LaserDir * 100000.0f);
		HitActor = Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TargetLocation, LI.Location, true, vect(0.0f, 0.0f, 0.0f), ref/*probably?*/ HitInfo, 8);
		if(HitActor == default)
		{
			TracedDistance = 100000.0f;
			Hit.SetHidden(true);		
		}
		else
		{
			TracedDistance = VSize(HitLocation - LI.Location);
			Hit.SetHidden(false);
			if(HitActor.IsA("TdPlayerPawn"))
			{
				Hit.SetHidden(true);
			}
			Hit.SetLocation(HitLocation);
			Hit.SetRotation(((Rotator)(HitNormal)));
			LI.HitLocation = HitLocation;
		}
		ScaleVec = vect(1.0f, 0.250f, 0.250f);
		ScaleVec.X = TracedDistance / 6000.0f;
		Beam.SetRotation(((Rotator)(LaserDir)));
		Beam.SetDrawScale3D(ScaleVec);
		Beam.SetFloatParameter("TilingScale", ScaleVec.X);
		Beam.SetFloatParameter("FXFScreen_LaserMaterialTile", TracedDistance / 1000.0f);
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
		UnTouch = null;
		Tick = null;
	
	}
	public TdKillZoneVolume()
	{
		// Object Offset:0x00582E87
		DamagePerShot = 40.0f;
		LaserBeamTemplate = LoadAsset<ParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserBeam_01")/*Ref ParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserBeam_01'*/;
		LaserHitTemplate = LoadAsset<TdParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserDot_01")/*Ref TdParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserDot_01'*/;
		LaserSourceTemplate = LoadAsset<TdParticleSystem>("FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserFlare_01")/*Ref TdParticleSystem'FX_WeaponEffects.Effects.PS_FX_WeaponFX_LaserFlare_01'*/;
		TimeToAim = 1.0f;
		WeaponSound = LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Fire.Fire3P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Fire.Fire3P'*/;
		WeaponReverbSound = LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Reverb.Reverb3P")/*Ref SoundCue'A_WP_Sniper_BarretM95.Reverb.Reverb3P'*/;
		WeaponSlapBackSound = LoadAsset<SoundCue>("A_WP_Sniper_BarretM95.Slapback.Slapback")/*Ref SoundCue'A_WP_Sniper_BarretM95.Slapback.Slapback'*/;
		MaxNumberOfSlapBackRays = 7;
		NumberOfSlapBacks = 5;
		RangeOfSlapBackRays = 15000.0f;
		BrushColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
		bColored = true;
		BrushComponent = LoadAsset<BrushComponent>("Default__TdKillZoneVolume.BrushComponent0")/*Ref BrushComponent'Default__TdKillZoneVolume.BrushComponent0'*/;
		bStatic = false;
		bSkipActorPropertyReplication = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__TdKillZoneVolume.BrushComponent0")/*Ref BrushComponent'Default__TdKillZoneVolume.BrushComponent0'*/,
		};
		CollisionComponent = LoadAsset<BrushComponent>("Default__TdKillZoneVolume.BrushComponent0")/*Ref BrushComponent'Default__TdKillZoneVolume.BrushComponent0'*/;
	}
}
}
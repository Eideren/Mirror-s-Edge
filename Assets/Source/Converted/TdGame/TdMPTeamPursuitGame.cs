namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPTeamPursuitGame : TdMPTeamGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public const int RUNNER_TEAM_INDEX = 0;
	public const int POLICE_TEAM_INDEX = 1;
	
	public /*transient */TdPursuitLogic PursuitLogic;
	public /*const config */int RunnerRespawnTime;
	public /*const config */int CopRespawnTime;
	public /*const config */int CopOffsetSpawnTime;
	public /*const config */int MinBagSpawnRaduis;
	public /*const config */int FriendOrFoeScoringDistance;
	public /*private transient */Core.ClassT<TdLocalMessage> TdPursuitMessageClass;
	
	public override /*event */void PreBeginPlay()
	{
		base.PreBeginPlay();
		PursuitLogic =  ClassT<TdPursuitLogic>().New();
		PursuitLogic.Initialize(this);
		TdPursuitMessageClass = ((DynamicLoadObject("TdMpContent.TdPursuitMessage", ClassT<Class>(), default(bool?))) as ClassT<TdLocalMessage>);
	}
	
	public override /*function */void EndGame(PlayerReplicationInfo Winner, String Reason)
	{
		base.EndGame(Winner, Reason);
	}
	
	public override /*function */PlayerStart ChoosePlayerStart(Controller Player, /*optional */byte? _InTeam = default)
	{
		/*local */PlayerStart P = default, BestStart = default;
		/*local */float BestRating = default, NewRating = default;
		/*local */int Idx = default;
		/*local */byte Team = default;
	
		var InTeam = _InTeam ?? default;
		BestRating = -1.0f;
		Team = (byte)((((Player != default) && Player.PlayerReplicationInfo != default) && Player.PlayerReplicationInfo.Team != default) ? ((byte)(Player.PlayerReplicationInfo.Team.TeamIndex)) : InTeam);
		Idx = 0;
		J0x88:{}
		if(Idx < StartPoints.Length)
		{
			P = StartPoints[Idx];
			NewRating = RatePlayerStart(P, (byte)Team, Player);
			if(NewRating > BestRating)
			{
				BestRating = NewRating;
				BestStart = P;
			}
			++ Idx;
			goto J0x88;
		}
		return BestStart;
	}
	
	public override RatePlayerStart_del RatePlayerStart { get => bfield_RatePlayerStart ?? TdMPTeamPursuitGame_RatePlayerStart; set => bfield_RatePlayerStart = value; } RatePlayerStart_del bfield_RatePlayerStart;
	public override RatePlayerStart_del global_RatePlayerStart => TdMPTeamPursuitGame_RatePlayerStart;
	public /*function */float TdMPTeamPursuitGame_RatePlayerStart(PlayerStart P, byte Team, Controller Player)
	{
		/*local */float Score = default;
		/*local */TdTeamPlayerStart TeamPlayerStart = default;
	
		Score = 0.0f;
		TeamPlayerStart = ((P) as TdTeamPlayerStart);
		if((TeamPlayerStart != default) && TeamPlayerStart.TeamNumber == ((int)Team))
		{
			Score += ((float)(100 + Rand(50)));
			if(PursuitLogic.ActiveStashpointID == TeamPlayerStart.SpawnPointID)
			{
				Score += ((float)(100 + Rand(50)));
			}
		}
		return ((float)(Max(0, ((int)(Score)))));
	}
	
	public override /*function */void ScoreKill(Controller Killer, Controller Other)
	{
		if((Killer == Other) || Killer == default)
		{
			if((Other != default) && Other.PlayerReplicationInfo != default)
			{
				Other.PlayerReplicationInfo.Score += ((float)(ClassT<TdPursuitScore>().DefaultAs<TdPursuitScore>().Suicide));
				Other.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
			}		
		}
		else
		{
			if(Killer.PlayerReplicationInfo != default)
			{
				Killer.PlayerReplicationInfo.Score += ((float)(ClassT<TdPursuitScore>().DefaultAs<TdPursuitScore>().Kill));
				Killer.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
				++ Killer.PlayerReplicationInfo.Kills;
			}
		}
	}
	
	public override /*function */void BroadcastDeathMessage(Controller Killer, Controller Other, Core.ClassT<DamageType> DamageType)
	{
		if(Killer == Other)
		{
			TdAnnouncerBase.Play3DLocationalAnnouncement(Other.Pawn, DeathMessageClass, 12, true, true, Other.PlayerReplicationInfo, default(PlayerReplicationInfo?));
			BroadcastLocalized(this, DeathMessageClass, 14, default, Other.PlayerReplicationInfo, DamageType);		
		}
		else
		{
			if(Killer == default)
			{
				TdAnnouncerBase.Play3DLocationalAnnouncement(Other.Pawn, DeathMessageClass, 12, true, true, Other.PlayerReplicationInfo, default(PlayerReplicationInfo?));
				BroadcastLocalized(this, DeathMessageClass, 13, default, Other.PlayerReplicationInfo, DamageType);			
			}
			else
			{
				if((Other.Pawn != default) && ((Other.Pawn) as TdPlayerPawn).bPlayerDiedHoldingTheBag)
				{
					BroadcastLocalized(this, DeathMessageClass, 17, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);				
				}
				else
				{
					if((((Other.PlayerReplicationInfo) as TdBagPRI).LastBagCarrierDamageTime + 10.0f) > WorldInfo.TimeSeconds)
					{
						BroadcastLocalized(this, DeathMessageClass, 18, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);					
					}
					else
					{
						if(Killer.PlayerReplicationInfo.Team == Other.PlayerReplicationInfo.Team)
						{
							TdAnnouncerBase.Play3DLocationalAnnouncement(Other.Pawn, DeathMessageClass, 12, true, true, Other.PlayerReplicationInfo, default(PlayerReplicationInfo?));
							BroadcastLocalized(this, DeathMessageClass, 15, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);						
						}
						else
						{
							if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
							{
								TdAnnouncerBase.Play3DLocationalAnnouncement(Killer.Pawn, DeathMessageClass, 16, true, true, Killer.PlayerReplicationInfo, default(PlayerReplicationInfo?));
								BroadcastLocalized(this, DeathMessageClass, 16, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);							
							}
							else
							{
								TdAnnouncerBase.Play3DLocationalAnnouncement(Other.Pawn, DeathMessageClass, 12, true, true, Other.PlayerReplicationInfo, default(PlayerReplicationInfo?));
								BroadcastLocalized(this, DeathMessageClass, 12, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);
							}
						}
					}
				}
			}
		}
	}
	
	public override /*function */Core.ClassT<Pawn> GetDefaultPlayerClass(Controller C)
	{
		/*local */Core.ClassT<Pawn> ResultClass = default;
		/*local */int RandIndex = default;
		/*local */String ClassName = default;
	
		ResultClass = ((C) as TdPlayerController).CharacterClass;
		if(ResultClass == default)
		{
			if((CriminalClasses.Length == 0) || PoliceClasses.Length == 0)
			{
				ResultClass = DefaultPawnClass;			
			}
			else
			{
				if((C.PlayerReplicationInfo != default) && C.PlayerReplicationInfo.Team != default)
				{
					if(C.PlayerReplicationInfo.Team.TeamIndex == 0)
					{
						RandIndex = Rand(CriminalClasses.Length);
						ClassName = CriminalClasses[RandIndex];					
					}
					else
					{
						if(C.PlayerReplicationInfo.Team.TeamIndex == 1)
						{
							RandIndex = Rand(PoliceClasses.Length);
							ClassName = PoliceClasses[RandIndex];
						}
					}
					ResultClass = ((DynamicLoadObject(ClassName, ClassT<Class>(), default(bool?))) as ClassT<Pawn>);
				}
			}
			if(ResultClass == default)
			{
				ResultClass = DefaultPawnClass;
			}
		}
		return ResultClass;
	}
	
	public delegate void RunnerInitialSpawn_del();
	public virtual RunnerInitialSpawn_del RunnerInitialSpawn { get => bfield_RunnerInitialSpawn ?? (()=>{}); set => bfield_RunnerInitialSpawn = value; } RunnerInitialSpawn_del bfield_RunnerInitialSpawn;
	public virtual RunnerInitialSpawn_del global_RunnerInitialSpawn => ()=>{};
	
	public delegate void CopInitialSpawn_del();
	public virtual CopInitialSpawn_del CopInitialSpawn { get => bfield_CopInitialSpawn ?? (()=>{}); set => bfield_CopInitialSpawn = value; } CopInitialSpawn_del bfield_CopInitialSpawn;
	public virtual CopInitialSpawn_del global_CopInitialSpawn => ()=>{};
	
	public delegate void CopRespawnTimer_del();
	public virtual CopRespawnTimer_del CopRespawnTimer { get => bfield_CopRespawnTimer ?? (()=>{}); set => bfield_CopRespawnTimer = value; } CopRespawnTimer_del bfield_CopRespawnTimer;
	public virtual CopRespawnTimer_del global_CopRespawnTimer => ()=>{};
	
	public delegate void RunnerRespawnTimer_del();
	public virtual RunnerRespawnTimer_del RunnerRespawnTimer { get => bfield_RunnerRespawnTimer ?? (()=>{}); set => bfield_RunnerRespawnTimer = value; } RunnerRespawnTimer_del bfield_RunnerRespawnTimer;
	public virtual RunnerRespawnTimer_del global_RunnerRespawnTimer => ()=>{};
	
	public delegate void InitialTeamSpawn_del(int TeamIndex);
	public virtual InitialTeamSpawn_del InitialTeamSpawn { get => bfield_InitialTeamSpawn ?? ((a)=>{}); set => bfield_InitialTeamSpawn = value; } InitialTeamSpawn_del bfield_InitialTeamSpawn;
	public virtual InitialTeamSpawn_del global_InitialTeamSpawn => (a)=>{};
	
	public delegate void TeamRespawnTimer_del(int TeamIndex);
	public virtual TeamRespawnTimer_del TeamRespawnTimer { get => bfield_TeamRespawnTimer ?? ((a)=>{}); set => bfield_TeamRespawnTimer = value; } TeamRespawnTimer_del bfield_TeamRespawnTimer;
	public virtual TeamRespawnTimer_del global_TeamRespawnTimer => (a)=>{};
	protected override void RestoreDefaultFunction()
	{
		RatePlayerStart = null;
	
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_BeginState(name PreviousStateName)// state function
	{
		PursuitLogic.OnStartMatchInProgress();
		DeadControllers.Remove(0, DeadControllers.Length);
		RunnerInitialSpawn();
		SetTimer(((float)(CopOffsetSpawnTime)), false, "CopInitialSpawn", default(Object?));
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_RunnerInitialSpawn()// state function
	{
		bInitialSpawn = true;
		InitialTeamSpawn(0);
		bInitialSpawn = false;
		SetTimer(((float)(RunnerRespawnTime)), true, "RunnerRespawnTimer", default(Object?));
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_CopInitialSpawn()// state function
	{
		bInitialSpawn = true;
		InitialTeamSpawn(1);
		bInitialSpawn = false;
		SetTimer(((float)(CopRespawnTime)), true, "CopRespawnTimer", default(Object?));
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_CopRespawnTimer()// state function
	{
		TeamRespawnTimer(1);
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_RunnerRespawnTimer()// state function
	{
		TeamRespawnTimer(0);
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_InitialTeamSpawn(int TeamIndex)// state function
	{
		/*local */TdPlayerController C = default;
		/*local */int SpawnAttempts = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ C)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (C = (TdPlayerController)e0.Current) == C)
		{
			if(C.PlayerReplicationInfo.Team.TeamIndex == TeamIndex)
			{
				SpawnAttempts = 0;
				J0x51:{}
				if(C.IsDead() && !C.PlayerReplicationInfo.bOnlySpectator)
				{
					RestartPlayer(C);
					if(SpawnAttempts >= 3)
					{
						AddToRespawnList(C);
						goto J0xC0;
					}
					++ SpawnAttempts;
					goto J0x51;
				}
				J0xC0:{}
				C.ClientPlayAnnouncement(TdPursuitMessageClass, 23, C.PlayerReplicationInfo, default(PlayerReplicationInfo?));
			}		
		}	
	}
	
	protected /*function */void TdMPTeamPursuitGame_MatchInProgress_TeamRespawnTimer(int TeamIndex)// state function
	{
		/*local */int SpawnAttempts = default, Idx = default;
		/*local */TdPlayerController C = default;
	
		assert(DeadControllers.Length > MaxPlayers);
		Idx = 0;
		J0x18:{}
		if(Idx < DeadControllers.Length)
		{
			C = DeadControllers[Idx].C;
			if(C.PlayerReplicationInfo.Team.TeamIndex == TeamIndex)
			{
				if(DeadControllers[Idx].TimeToRespawn <= WorldInfo.TimeSeconds)
				{
					SpawnAttempts = 0;
					J0xA2:{}
					if(SpawnAttempts <= 3)
					{
						RestartPlayer(C);
						++ SpawnAttempts;
						if(!C.IsDead())
						{
							DeadControllers.Remove(-- Idx, 1);
							goto J0xF1;
						}
						goto J0xA2;
					}
					J0xF1:{}
					goto J0xF7;
				}
				goto J0x101;
			}
			J0xF7:{}
			++ Idx;
			goto J0x18;
		}
		J0x101:{}
	}
	
	protected /*simulated function */void TdMPTeamPursuitGame_MatchInProgress_EndState(name NextStateName)// state function
	{
		PursuitLogic.OnEndMatchInProgress();
		/*Transformed 'base.' to specific call*/TdMPGame_MatchInProgress_EndState(NextStateName);
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MatchInProgress()/*state MatchInProgress*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			RunnerInitialSpawn = TdMPTeamPursuitGame_MatchInProgress_RunnerInitialSpawn;
			CopInitialSpawn = TdMPTeamPursuitGame_MatchInProgress_CopInitialSpawn;
			CopRespawnTimer = TdMPTeamPursuitGame_MatchInProgress_CopRespawnTimer;
			RunnerRespawnTimer = TdMPTeamPursuitGame_MatchInProgress_RunnerRespawnTimer;
			InitialTeamSpawn = TdMPTeamPursuitGame_MatchInProgress_InitialTeamSpawn;
			TeamRespawnTimer = TdMPTeamPursuitGame_MatchInProgress_TeamRespawnTimer;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdMPTeamPursuitGame_MatchInProgress_BeginState, StateFlow, TdMPTeamPursuitGame_MatchInProgress_EndState);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "MatchInProgress": return MatchInProgress();
			default: return base.FindState(stateName);
		}
	}
	public TdMPTeamPursuitGame()
	{
		// Object Offset:0x005FFDCC
		VictoryMessageClass = ClassT<TdPursuitVictoryMessage>()/*Ref Class'TdPursuitVictoryMessage'*/;
		DefaultInventory = new array<TdGameInfo.DefaultInvItem>
		{
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceRiotUnit",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_Colt1911",
				Ammo = 0,
				Clips = 0,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceUndercover",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_Colt1911",
				Ammo = 0,
				Clips = 0,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceSWAT",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_Colt1911",
				Ammo = 0,
				Clips = 0,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceRiotUnit",
				InventoryClassName = "TdSharedContent.TdWeapon_ShotGun_Remington870",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceUndercover",
				InventoryClassName = "TdSharedContent.TdWeapon_AssaultRifle_MP5K",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceSWAT",
				InventoryClassName = "TdSharedContent.TdWeapon_Machinegun_FNMinimi",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalHeavy",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = 1,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalFixer",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = 1,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalProwler",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = 1,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
		};
		HUDType = ClassT<TdPursuitHUD>()/*Ref Class'TdPursuitHUD'*/;
		PlayerReplicationInfoClass = ClassT<TdPursuitPRI>()/*Ref Class'TdPursuitPRI'*/;
		GameReplicationInfoClass = ClassT<TdPursuitGRI>()/*Ref Class'TdPursuitGRI'*/;
	}
}
}
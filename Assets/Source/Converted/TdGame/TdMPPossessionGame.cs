namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPPossessionGame : TdMPGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*transient */TdPossessionLogic PossessionLogic;
	public /*config */float MinBagSpawnRaduis;
	
	public override /*function */PlayerStart ChoosePlayerStart(Controller Player, /*optional */byte? _InTeam = default)
	{
		/*local */PlayerStart BestStart = default;
		/*local */float BestRating = default, NewRating = default;
		/*local */int Idx = default;
	
		var InTeam = _InTeam ?? default;
		BestRating = -1.0f;
		Idx = 0;
		J0x13:{}
		if(Idx < StartPoints.Length)
		{
			NewRating = RatePlayerStart(StartPoints[Idx], (byte)InTeam, Player);
			if(NewRating > BestRating)
			{
				BestRating = NewRating;
				BestStart = StartPoints[Idx];
			}
			++ Idx;
			goto J0x13;
		}
		return BestStart;
	}
	
	public override RatePlayerStart_del RatePlayerStart { get => bfield_RatePlayerStart ?? TdMPPossessionGame_RatePlayerStart; set => bfield_RatePlayerStart = value; } RatePlayerStart_del bfield_RatePlayerStart;
	public override RatePlayerStart_del global_RatePlayerStart => TdMPPossessionGame_RatePlayerStart;
	public /*function */float TdMPPossessionGame_RatePlayerStart(PlayerStart P, byte Team, Controller Player)
	{
		/*local */Actor Bag = default;
		/*local */float Score = default, DistanceToBag = default, DistanceToOtherPlayer = default;
		/*local */Controller OtherPlayer = default;
	
		Bag = PossessionLogic.GetBagActor();
		Score = 0.0f;
		if(Bag != default)
		{
			DistanceToBag = VSize2D(Bag.Location - P.Location);
			if(DistanceToBag > MinBagSpawnRaduis)
			{
				Score += ((float)(50));
				Score += ((MinBagSpawnRaduis - DistanceToBag) / ((float)(100)));
			}		
		}
		else
		{
			if(P.bPrimaryStart)
			{
				Score += ((float)(50));
			}
		}
		
		// foreach WorldInfo.AllControllers(ClassT<Controller>(), ref/*probably?*/ OtherPlayer)
		using var e176 = WorldInfo.AllControllers(ClassT<Controller>()).GetEnumerator();
		while(e176.MoveNext() && (OtherPlayer = (Controller)e176.Current) == OtherPlayer)
		{
			if(OtherPlayer.bIsPlayer && OtherPlayer.Pawn != default)
			{
				DistanceToOtherPlayer = VSize(OtherPlayer.Pawn.Location - P.Location);
				if(DistanceToOtherPlayer < ((float)(3000)))
				{
					Score -= ((float)(5));
				}
			}		
		}	
		return ((float)(Max(0, ((int)(Score)))));
	}
	
	public override /*event */void PreBeginPlay()
	{
		base.PreBeginPlay();
		PossessionLogic =  ClassT<TdPossessionLogic>().New();
		PossessionLogic.Initialize(this);
	}
	
	public override /*function */void EndGame(PlayerReplicationInfo Winner, string Reason)
	{
		/*local */TdPlayerController Player = default;
		/*local */int Index = default;
		/*local */float BestScore = default;
	
		
		// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ Player)
		using var e0 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
		while(e0.MoveNext() && (Player = (TdPlayerController)e0.Current) == Player)
		{
			Player.ShowAchievementStats();		
		}	
		Index = 0;
		J0x3A:{}
		if(Index < GameReplicationInfo.PRIArray.Length)
		{
			if(GameReplicationInfo.PRIArray[Index].Score > BestScore)
			{
				Winner = GameReplicationInfo.PRIArray[Index];
				BestScore = GameReplicationInfo.PRIArray[Index].Score;
			}
			++ Index;
			goto J0x3A;
		}
		base.EndGame(Winner, Reason);
	}
	
	public override /*function */void BroadcastDeathMessage(Controller Killer, Controller Other, Core.ClassT<DamageType> DamageType)
	{
		if(Killer == Other)
		{
			BroadcastLocalized(this, DeathMessageClass, 14, default, Other.PlayerReplicationInfo, DamageType);		
		}
		else
		{
			if(Killer == default)
			{
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
					if(Killer.PlayerReplicationInfo.Team == Other.PlayerReplicationInfo.Team)
					{
						BroadcastLocalized(this, DeathMessageClass, 15, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);					
					}
					else
					{
						if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
						{
							BroadcastLocalized(this, DeathMessageClass, 16, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);						
						}
						else
						{
							BroadcastLocalized(this, DeathMessageClass, 12, Killer.PlayerReplicationInfo, Other.PlayerReplicationInfo, DamageType);
						}
					}
				}
			}
		}
	}
	protected override void RestoreDefaultFunction()
	{
		RatePlayerStart = null;
	
	}
	
	protected /*function */void TdMPPossessionGame_MatchInProgress_BeginState(name PreviousStateName)// state function
	{
		/*Transformed 'base.' to specific call*/TdMPGame_MatchInProgress_BeginState(PreviousStateName);
		PossessionLogic.OnStartMatchInProgress();
	}
	
	protected /*simulated function */void TdMPPossessionGame_MatchInProgress_EndState(name NextStateName)// state function
	{
		/*Transformed 'base.' to specific call*/TdMPGame_MatchInProgress_EndState(NextStateName);
		PossessionLogic.OnEndMatchInProgress();
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MatchInProgress()/*state MatchInProgress*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
		{
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdMPPossessionGame_MatchInProgress_BeginState, StateFlow, TdMPPossessionGame_MatchInProgress_EndState);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "MatchInProgress": return MatchInProgress();
			default: return base.FindState(stateName);
		}
	}
	public TdMPPossessionGame()
	{
		// Object Offset:0x005F9DBA
		DefaultInventory = new array<TdGameInfo.DefaultInvItem>
		{
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceRiotUnit",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalProwler",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceSWAT",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceUndercover",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalHeavy",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalFixer",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_TaserContent",
				Ammo = -2,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
		};
		HUDType = ClassT<TdPossessionHUD>()/*Ref Class'TdPossessionHUD'*/;
		PlayerReplicationInfoClass = ClassT<TdBagPRI>()/*Ref Class'TdBagPRI'*/;
		GameReplicationInfoClass = ClassT<TdPossessionGRI>()/*Ref Class'TdPossessionGRI'*/;
	}
}
}
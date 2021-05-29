namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPTeamDMGame : TdMPTeamGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public override /*function */void EndGame(PlayerReplicationInfo Winner, string Reason)
	{
		base.EndGame(Winner, Reason);
	}
	
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
	
	public override RatePlayerStart_del RatePlayerStart { get => bfield_RatePlayerStart ?? TdMPTeamDMGame_RatePlayerStart; set => bfield_RatePlayerStart = value; } RatePlayerStart_del bfield_RatePlayerStart;
	public override RatePlayerStart_del global_RatePlayerStart => TdMPTeamDMGame_RatePlayerStart;
	public /*function */float TdMPTeamDMGame_RatePlayerStart(PlayerStart P, byte Team, Controller Player)
	{
		/*local */float Score = default, Distance = default;
		/*local */TdTeamPlayerStart Tps = default;
		/*local */TdPlayerController PlayerController = default;
	
		Score = 0.0f;
		if(bInitialSpawn)
		{
			Tps = ((P) as TdTeamPlayerStart);
			if(Tps != default)
			{
				if((Tps.RobberSpawn && ((int)Team) == ((int)0)) || Tps.CopSpawn && ((int)Team) == ((int)1))
				{
					return ((float)(((P.bPrimaryStart) ? 1000 : 20)));
				}
			}		
		}
		else
		{
			
			// foreach WorldInfo.AllControllers(ClassT<TdPlayerController>(), ref/*probably?*/ PlayerController)
			using var e157 = WorldInfo.AllControllers(ClassT<TdPlayerController>()).GetEnumerator();
			while(e157.MoveNext() && (PlayerController = (TdPlayerController)e157.Current) == PlayerController)
			{
				if(PlayerController.Pawn != default)
				{
					Distance = FMax(1000.0f, VSize(PlayerController.Pawn.Location - P.Location));
					if(PlayerController.PlayerReplicationInfo.Team.TeamIndex == ((int)Team))
					{
						Score += Distance;
						continue;
					}
					Score -= (((float)(1)) + ((((float)(1000)) - Distance) * ((float)(2))));
				}			
			}		
		}
		return Score;
	}
	
	public override /*function */void ScoreKill(Controller Killer, Controller Other)
	{
		if((Killer == Other) || Killer == default)
		{
			if((Other != default) && Other.PlayerReplicationInfo != default)
			{
				Other.PlayerReplicationInfo.Score -= ((float)(1));
				Other.PlayerReplicationInfo.Team.Score -= ((float)(1));
				Other.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
			}		
		}
		else
		{
			if(Killer.PlayerReplicationInfo != default)
			{
				Killer.PlayerReplicationInfo.Score += ((float)(1));
				Killer.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
				Killer.PlayerReplicationInfo.Team.Score += ((float)(1));
				++ Killer.PlayerReplicationInfo.Kills;
			}
		}
		CheckScore(Killer.PlayerReplicationInfo);
	}
	
	public override /*function */bool CheckScore(PlayerReplicationInfo Scorer)
	{
		if(Scorer != default)
		{
			if((GoalScore > 0) && Scorer.Team.Score >= ((float)(GoalScore)))
			{
				EndGame(Scorer, "fraglimit");
			}
		}
		return true;
	}
	protected override void RestoreDefaultFunction()
	{
		RatePlayerStart = null;
	
	}
	public TdMPTeamDMGame()
	{
		// Object Offset:0x005FDC92
		DefaultInventory = new array<TdGameInfo.DefaultInvItem>
		{
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceRiotUnit",
				InventoryClassName = "TdSharedContent.TdWeapon_SMG_MP7",
				Ammo = -2,
				Clips = 3,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalProwler",
				InventoryClassName = "TdSharedContent.TdWeapon_SMG_MiniUzi",
				Ammo = -2,
				Clips = 3,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceSWAT",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_BerettaM93R",
				Ammo = -2,
				Clips = 4,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceUndercover",
				InventoryClassName = "TdSharedContent.TdWeapon_SMG_SteyrTMP",
				Ammo = -2,
				Clips = 3,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalHeavy",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_Glock18c",
				Ammo = -2,
				Clips = 4,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalFixer",
				InventoryClassName = "TdSharedContent.TdWeapon_Pistol_Taurus44Magnum",
				Ammo = -2,
				Clips = 3,
				Slot = Inventory.EInventorySlot.EISlot_LightWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceUndercover",
				InventoryClassName = "TdSharedContent.TdWeapon_Sniper_BarretM95",
				Ammo = 10,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceSWAT",
				InventoryClassName = "TdSharedContent.TdWeapon_AssaultRifle_HKG36",
				Ammo = 30,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_PoliceRiotUnit",
				InventoryClassName = "TdSharedContent.TdWeapon_ShotGun_Neostead",
				Ammo = 10,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalProwler",
				InventoryClassName = "TdSharedContent.TdWeapon_Sniper_BarretM95",
				Ammo = 10,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalHeavy",
				InventoryClassName = "TdSharedContent.TdWeapon_Machinegun_FNMinimi",
				Ammo = 50,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
			new TdGameInfo.DefaultInvItem
			{
				PawnClassName = (name)"Pawn_CriminalFixer",
				InventoryClassName = "TdSharedContent.TdWeapon_ShotGun_Remington870",
				Ammo = 10,
				Clips = -1,
				Slot = Inventory.EInventorySlot.EISlot_HeavyWeapon,
			},
		};
		HUDType = ClassT<TdTeamDMHUD>()/*Ref Class'TdTeamDMHUD'*/;
	}
}
}
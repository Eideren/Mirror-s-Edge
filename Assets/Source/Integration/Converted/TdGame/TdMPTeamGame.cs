namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPTeamGame : TdMPGame/*
		abstract
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct TdTeamData
	{
		public Core.ClassT<TdTeamInfo> TeamClass;
		public int MaxMembers;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x005FC1B9
	//		TeamClass = default;
	//		MaxMembers = 0;
	//	}
	};
	
	public array<TdTeamInfo> Teams;
	public array<TdMPTeamGame.TdTeamData> TeamData;
	public int NumTeams;
	public bool bAutoBalanceTeams;
	public bool bSwitchSides;
	[config] public byte FriendlyFireScale;
	
	public override /*function */void InitGame(String Options, ref String ErrorMessage)
	{
		/*local */String Value = default;
	
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
		Value = ParseOption(Options, "FriendlyFire");
		Value = ParseOption(Options, "SwitchSides");
		bSwitchSides = Value != "";
	}
	
	public override /*function */void PreBeginPlay()
	{
		base.PreBeginPlay();
		InitializeTeams();
	}
	
	public virtual /*function */void InitializeTeams()
	{
		/*local */int Index = default;
	
		Index = 0;
		J0x07:{}
		if(Index < NumTeams)
		{
			Teams[Index] = Spawn(TeamData[Index].TeamClass, this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
			Teams[Index].TeamIndex = Index;
			Teams[Index].MaxTeamMembers = TeamData[Index].MaxMembers;
			GameReplicationInfo.SetTeam(Index, Teams[Index]);
			++ Index;
			goto J0x07;
		}
	}
	
	public virtual /*function */byte GetBalancedTeam(byte Current, Controller C)
	{
		/*local */int Index = default, LeastMembers = default, CurrentTeamSize = default;
	
		LeastMembers = 999;
		if(C == default)
		{
			return Current;
		}
		Index = 0;
		J0x23:{}
		if(Index < NumTeams)
		{
			CurrentTeamSize = ((Index == ((int)C.GetTeamNum())) ? Teams[Index].Size - 1 : Teams[Index].Size);
			if(CurrentTeamSize < Teams[Index].MaxTeamMembers)
			{
				if(CurrentTeamSize < LeastMembers)
				{
					LeastMembers = CurrentTeamSize;
					Current = (byte)((byte)(Teams[Index].TeamIndex));
					goto J0x125;
				}
				if(CurrentTeamSize == LeastMembers)
				{
					Current = (byte)((byte)(Min(Teams[((int)Current)].TeamIndex, Teams[Index].TeamIndex)));
				}
			}
			J0x125:{}
			++ Index;
			goto J0x23;
		}
		return Current;
	}
	
	public virtual /*function */byte GetRandomTeam(byte Current, Controller C)
	{
		return ((byte)(Rand(NumTeams)));
	}
	
	public override /*function */byte PickTeam(byte Current, Controller C)
	{
		return GetBalancedTeam((byte)Current, C);
	}
	
	public override /*function */bool ChangeTeam(Controller Other, int Num, bool bNewTeam)
	{
		/*local */TdTeamInfo NewTeam = default;
	
		if((Num >= 0) && Num < Teams.Length)
		{
			NewTeam = Teams[Num];		
		}
		else
		{
			NewTeam = Teams[((int)PickTeam(255, Other))];
		}
		if(((Other.PlayerReplicationInfo.Team == default) || Other.PlayerReplicationInfo.Team != NewTeam))
		{
			SetTeam(Other, NewTeam, bNewTeam);
			return true;
		}
		return false;
	}
	
	public virtual /*function */void SetTeam(Controller Other, TdTeamInfo NewTeam, bool bNewTeam)
	{
		Other.StartSpot = default;
		if(Other.PlayerReplicationInfo.Team != default)
		{
			Other.PlayerReplicationInfo.Team.RemoveFromTeam(Other);
			Other.PlayerReplicationInfo.Team = default;
		}
		if((NewTeam != default) && NewTeam.AddToTeam(Other))
		{
			if(bNewTeam && ((Other) as PlayerController) != default)
			{
				Broadcast(Other, (((Other.Name)).ToString() + " " + "Changed Team to ") + " " + NewTeam.GetHumanReadableName(), default(name?));
			}		
		}
	}
	
	public override /*function */bool CanSpectate(PlayerController Viewer, PlayerReplicationInfo ViewTarget)
	{
		if(((ViewTarget == default) || ViewTarget.bOnlySpectator))
		{
			return false;
		}
		return (Viewer.PlayerReplicationInfo.bOnlySpectator || ViewTarget.Team == Viewer.PlayerReplicationInfo.Team);
	}
	
	public override /*function */void ReduceDamage(ref int Damage, Pawn injured, Controller InstigatedBy, Object.Vector HitLocation, ref Object.Vector Momentum, Core.ClassT<DamageType> DamageType)
	{
		/*local */Controller InjuredController = default;
	
		if(injured != default)
		{
			InjuredController = injured.Controller;
		}
		if(((((((int)FriendlyFireScale) > ((int)0)) && InstigatedBy != default) && InjuredController != default) && InjuredController != InstigatedBy) && WorldInfo.GRI.OnSameTeam(InjuredController, InstigatedBy))
		{
			Damage = ((int)(((float)(Damage * ((int)FriendlyFireScale))) * 0.010f));
		}
		base.ReduceDamage(ref/*probably?*/ Damage, injured, InstigatedBy, HitLocation, ref/*probably?*/ Momentum, DamageType);
	}
	
	public override RatePlayerStart_del RatePlayerStart { get => bfield_RatePlayerStart ?? TdMPTeamGame_RatePlayerStart; set => bfield_RatePlayerStart = value; } RatePlayerStart_del bfield_RatePlayerStart;
	public override RatePlayerStart_del global_RatePlayerStart => TdMPTeamGame_RatePlayerStart;
	public /*function */float TdMPTeamGame_RatePlayerStart(PlayerStart P, byte Team, Controller Player)
	{
		if(((P) as TdTeamPlayerStart) == default)
		{
			return 0.0f;		
		}
		else
		{
			if(((((P) as TdTeamPlayerStart).TeamNumber == 2) || ((int)((byte)(((P) as TdTeamPlayerStart).TeamNumber))) == ((int)Team)))
			{
				return 1.0f + FRand();			
			}
			else
			{
				return -9.0f;
			}
		}
	}
	protected override void RestoreDefaultFunction()
	{
		RatePlayerStart = null;
	
	}
	public TdMPTeamGame()
	{
		// Object Offset:0x005FD1B9
		TeamData = new array<TdMPTeamGame.TdTeamData>
		{
			new TdMPTeamGame.TdTeamData
			{
				TeamClass = ClassT<TdRunnerTeamInfo>()/*Ref Class'TdRunnerTeamInfo'*/,
				MaxMembers = 8,
			},
			new TdMPTeamGame.TdTeamData
			{
				TeamClass = ClassT<TdCopTeamInfo>()/*Ref Class'TdCopTeamInfo'*/,
				MaxMembers = 8,
			},
		};
		NumTeams = 2;
		bAutoBalanceTeams = true;
		bTeamGame = true;
	}
}
}
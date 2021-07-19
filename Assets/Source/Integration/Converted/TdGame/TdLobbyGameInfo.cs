// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLobbyGameInfo : TdGameInfo/*
		native
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public partial struct /*native */LobbyPlayerStruct
	{
		public int PlayerId;
		public String PlayerName;
		public int PlayerRoleIndex;
		public bool bPlayerIsReady;
		public int TeamIndex;
		public int PlayerIndex;
		public OnlineSubsystem.UniqueNetId UniqueId;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00588A14
	//		PlayerId = 0;
	//		PlayerName = "";
	//		PlayerRoleIndex = 0;
	//		bPlayerIsReady = false;
	//		TeamIndex = 0;
	//		PlayerIndex = 0;
	//		UniqueId = new OnlineSubsystem.UniqueNetId
	//		{
	//			Uid = new StaticArray<byte, byte, byte, byte, byte, byte, byte, byte>/*[8]*/()
	//			{
	//				[0] = 0,
	//				[1] = 0,
	//				[2] = 0,
	//				[3] = 0,
	//				[4] = 0,
	//				[5] = 0,
	//				[6] = 0,
	//				[7] = 0,
	//			},
	//		};
	//	}
	};
	
	public partial struct /*native */LobbyPlayerRoleStruct
	{
		public Core.ClassT<Pawn> PlayerRoleClass;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00588C18
	//		PlayerRoleClass = default;
	//	}
	};
	
	public partial struct /*native */LobbyTeamDataStruct
	{
		public int TeamId;
		public String TeamName;
		public array<TdLobbyGameInfo.LobbyPlayerStruct> Players;
		public int MaxPlayers;
		public array<TdLobbyGameInfo.LobbyPlayerRoleStruct> PlayerRoles;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x00588DB0
	//		TeamId = 0;
	//		TeamName = "";
	//		Players = default;
	//		MaxPlayers = 0;
	//		PlayerRoles = default;
	//	}
	};
	
	[transient] public UIScene LobbyScene;
	[transient] public PlayerController ControllingPlayer;
	public array<TdTeamInfo> Teams;
	[transient] public array<TdLobbyGameInfo.LobbyTeamDataStruct> TeamData;
	
	public override /*event */void InitGame(String Options, ref String ErrorMessage)
	{
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
	}
	
	public override /*function */void PreBeginPlay()
	{
		base.PreBeginPlay();
		InitializeTeams();
	}
	
	public virtual /*function */void InitializeTeams()
	{
		/*local */int I = default;
	
		I = 0;
		J0x07:{}
		if(I < TeamData.Length)
		{
			Teams[I] = Spawn(ClassT<TdTeamInfo>(), this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor), default(bool?));
			Teams[I].TeamIndex = I;
			Teams[I].MaxTeamMembers = TeamData[I].MaxPlayers;
			GameReplicationInfo.SetTeam(I, Teams[I]);
			++ I;
			goto J0x07;
		}
	}
	
	public override /*event */PlayerController Login(String Portal, String Options, ref String ErrorMessage)
	{
		/*local */PlayerController PC = default;
		/*local */TdGameReplicationInfo TdGRI = default;
		/*local */String S = default;
	
		PC = base.Login(Portal, Options, ref/*probably?*/ ErrorMessage);
		TdGRI = ((GameReplicationInfo) as TdGameReplicationInfo);
		S = PC.PlayerReplicationInfo.PlayerName + ((PC.PlayerReplicationInfo.PlayerId)).ToString();
		PC.ServerChangeName(S);
		if((PC != default) && TdGRI.LobbyBackend != default)
		{
			TdGRI.LobbyBackend.OnPlayerLogin(PC);
		}
		ChangeRole(PC, GetRandomRoleIndex(PC.PlayerReplicationInfo.Team.TeamIndex));
		return PC;
	}
	
	public override Logout_del Logout { get => bfield_Logout ?? TdLobbyGameInfo_Logout; set => bfield_Logout = value; } Logout_del bfield_Logout;
	public override Logout_del global_Logout => TdLobbyGameInfo_Logout;
	public /*function */void TdLobbyGameInfo_Logout(Controller Exiting)
	{
		/*Transformed 'base.' to specific call*/GameInfo_Logout(Exiting);
		if(Exiting != default)
		{
			((GameReplicationInfo) as TdGameReplicationInfo).LobbyBackend.OnPlayerLogout(Exiting);
		}
		if(Exiting == ControllingPlayer)
		{
			ControllingPlayer = default;
			UpdateAdminPlayer();
		}
	}
	
	public override /*function */byte PickTeam(byte Current, Controller C)
	{
		return GetBalancedTeam((byte)Current, C);
	}
	
	public virtual /*function */byte GetBalancedTeam(byte Current, Controller C)
	{
		/*local */int TeamIdx = default, LeastMembers = default, CurrentTeamSize = default;
	
		LeastMembers = 999;
		if(C != default)
		{
			TeamIdx = 0;
			J0x1D:{}
			if(TeamIdx < Teams.Length)
			{
				CurrentTeamSize = ((TeamIdx == ((int)C.GetTeamNum())) ? Teams[TeamIdx].Size - 1 : Teams[TeamIdx].Size);
				if(CurrentTeamSize < Teams[TeamIdx].MaxTeamMembers)
				{
					if(CurrentTeamSize < LeastMembers)
					{
						LeastMembers = CurrentTeamSize;
						Current = (byte)((byte)(Teams[TeamIdx].TeamIndex));
						goto J0x120;
					}
					if(CurrentTeamSize == LeastMembers)
					{
						Current = (byte)((byte)(Min(Teams[((int)Current)].TeamIndex, Teams[TeamIdx].TeamIndex)));
					}
				}
				J0x120:{}
				++ TeamIdx;
				goto J0x1D;
			}
		}
		return Current;
	}
	
	public override /*function */bool ChangeTeam(Controller C, int TeamId, bool bNewTeam)
	{
		/*local */bool Success = default;
		/*local */TdTeamInfo NewTeam = default;
		/*local */TdGameReplicationInfo TdGRI = default;
	
		TdGRI = ((GameReplicationInfo) as TdGameReplicationInfo);
		Success = false;
		if(TeamId == 255)
		{
			NewTeam = Teams[((int)PickTeam(255, C))];		
		}
		else
		{
			TeamId = ((TeamId >= Teams.Length) ? 0 : TeamId);
			TeamId = ((TeamId < 0) ? Teams.Length - 1 : TeamId);
			NewTeam = Teams[TeamId];
		}
		if((NewTeam != default) && ((C.PlayerReplicationInfo.Team == default) || C.PlayerReplicationInfo.Team != NewTeam))
		{
			SetTeam(C, NewTeam, bNewTeam);
			((C.PlayerReplicationInfo) as TdPlayerReplicationInfo).bPlayerIsReady = false;
			ChangeRole(C, GetRandomRoleIndex(TeamId));
			if(TdGRI.LobbyBackend != default)
			{
				TdGRI.LobbyBackend.OnChangeTeam(C);
			}
			Success = true;
		}
		return Success;
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
	
	public virtual /*function */int GetRandomRoleIndex(int Team)
	{
		/*local */int NumRolesForTeam = default;
	
		NumRolesForTeam = TdGameData.GetNumRoles(Team);
		return Rand(NumRolesForTeam);
	}
	
	public virtual /*function */bool ChangeRole(Controller C, int NewRoleIndex)
	{
		/*local */TdGameReplicationInfo TdGRI = default;
		/*local */int TeamIndex = default;
		/*local */bool Result = default;
		/*local */int NumRolesForTeam = default;
	
		Result = false;
		TeamIndex = C.PlayerReplicationInfo.Team.TeamIndex;
		if(TeamIndex != -1)
		{
			NumRolesForTeam = TdGameData.GetNumRoles(TeamIndex);
			NewRoleIndex = ((NewRoleIndex >= NumRolesForTeam) ? 0 : NewRoleIndex);
			NewRoleIndex = ((NewRoleIndex < 0) ? NumRolesForTeam - 1 : NewRoleIndex);
			if((NewRoleIndex < NumRolesForTeam) && NewRoleIndex >= 0)
			{
				((C.PlayerReplicationInfo) as TdPlayerReplicationInfo).RoleIndexInTeam = NewRoleIndex;
				((C.PlayerReplicationInfo) as TdPlayerReplicationInfo).bPlayerIsReady = false;
				C.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
				TdGRI = ((GameReplicationInfo) as TdGameReplicationInfo);
				if(TdGRI.LobbyBackend != default)
				{
					TdGRI.LobbyBackend.OnChangeRole(C);
				}
				Result = true;
			}
		}
		return Result;
	}
	
	public virtual /*function */void SetPlayerReady(Controller C, bool bIsReady)
	{
		/*local */TdGameReplicationInfo TdGRI = default;
	
		((C.PlayerReplicationInfo) as TdPlayerReplicationInfo).bPlayerIsReady = bIsReady;
		C.PlayerReplicationInfo.SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
		TdGRI = ((GameReplicationInfo) as TdGameReplicationInfo);
		if(TdGRI.LobbyBackend != default)
		{
			TdGRI.LobbyBackend.OnSetReady(C);
		}
		Broadcast(C, ((C.Name)).ToString() + " " + "is ready", default(name?));
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdLobbyGameInfo_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdLobbyGameInfo_PostLogin;
	public /*event */void TdLobbyGameInfo_PostLogin(PlayerController NewPlayer)
	{
		/*local */TdPlayerController PC = default;
	
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
		UpdateAdminPlayer();
		PC = ((NewPlayer) as TdPlayerController);
		if(PC != default)
		{
			HandleLobby(PC);
		}
	}
	
	public virtual /*function */bool ShowLobby(TdPlayerController PC)
	{
		return true;
	}
	
	public virtual /*function */void UpdateAdminPlayer()
	{
		/*local */PlayerController P = default;
	
		if(ControllingPlayer == default)
		{
			
			// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
			using var e11 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
			while(e11.MoveNext() && (P = (PlayerController)e11.Current) == P)
			{
				if(P != default)
				{
					ControllingPlayer = P;
					break;
				}			
			}		
		}
	}
	
	public virtual /*function */void HandleLobby(TdPlayerController PC)
	{
	
	}
	
	public virtual /*function */void StartGame(String URL)
	{
		/*local */TdGameReplicationInfo TdGRI = default;
	
		TdGRI = ((GameReplicationInfo) as TdGameReplicationInfo);
		if(TdGRI.LobbyBackend != default)
		{
			TdGRI.LobbyBackend.OnGameStarted();
			TdGRI.LobbyBackend.Cleanup();
		}
		WorldInfo.ServerTravel(URL, default(bool?));
	}
	
	public override /*function */void ProcessServerTravel(String URL, /*optional */bool? _bAbsolute = default)
	{
		/*local */PlayerController P = default;
		/*local */TdPlayerReplicationInfo TdPRI = default;
		/*local */bool bSeamless = default;
		/*local */int Team = default;
		/*local */String PlayerRole = default;
		/*local */array<int> Roles = default;
	
		var bAbsolute = _bAbsolute ?? default;
		bLevelChange = true;
		EndLogging("mapchange");
		bSeamless = bUseSeamlessTravel && WorldInfo.TimeSeconds < 172800.0f;
		
		// foreach WorldInfo.AllControllers(ClassT<PlayerController>(), ref/*probably?*/ P)
		using var e70 = WorldInfo.AllControllers(ClassT<PlayerController>()).GetEnumerator();
		while(e70.MoveNext() && (P = (PlayerController)e70.Current) == P)
		{
			TdPRI = ((P.PlayerReplicationInfo) as TdPlayerReplicationInfo);
			if(TdPRI != default)
			{
				Team = TdPRI.Team.TeamIndex;
				Roles = TdGameData.GetRolesList(Team);
				PlayerRole = TdGameData.GetRoleClassNameFromIndex(Roles[TdPRI.RoleIndexInTeam]);
			}
			if((AsNetConnection(P.Player)) != default)
			{
				URL = (((URL + "?Team=") + ((Team)).ToString()) + "?Character=") + PlayerRole;
				P.ClientTravel(URL, Actor.ETravelType.TRAVEL_Relative/*2*/, bSeamless, default(Object.Guid?));
				continue;
			}
			P.PreClientTravel();
			if(((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/))
			{
				WorldInfo.NextURL = (((((((WorldInfo.NextURL + "?Team=") + ((Team)).ToString()) + "?Name=") + P.GetDefaultURL("Name")) + "?Class=") + P.GetDefaultURL("Class")) + "?Character=") + PlayerRole;
			}		
		}	
		if(bSeamless)
		{
			WorldInfo.SeamlessTravel(WorldInfo.NextURL, default(bool?), default(Object.Guid?));
			WorldInfo.NextURL = "";		
		}
		else
		{
			if((((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) && ((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_ListenServer/*2*/))
			{
				WorldInfo.NextSwitchCountdown = 0.0f;
			}
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Logout = null;
		PostLogin = null;
	
	}
	
	protected /*function */void TdLobbyGameInfo_PendingMatch_BeginState(name PreviousStateName)// state function
	{
		/*Transformed 'base.' to specific call*/Object_BeginState(PreviousStateName);
		StartMatch();
	}
	
	protected /*function */void TdLobbyGameInfo_PendingMatch_StartMatch()// state function
	{
		/*Transformed 'base.' to specific call*/GameInfo_PendingMatch_StartMatch();
		GotoState("MatchInProgress", default(name?), default(bool?), default(bool?));
	}
	
	(System.Action<name>, StateFlow, System.Action<name>) PendingMatch()/*auto state PendingMatch*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			StartMatch = TdLobbyGameInfo_PendingMatch_StartMatch;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (TdLobbyGameInfo_PendingMatch_BeginState, StateFlow, null);
	}
	
	
	(System.Action<name>, StateFlow, System.Action<name>) MatchInProgress()/*auto state MatchInProgress*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "PendingMatch": return PendingMatch();
			case "MatchInProgress": return MatchInProgress();
			default: return base.FindState(stateName);
		}
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) GetAutoState()
	{
	
	return PendingMatch();
	return MatchInProgress();
	#warning multiple autos
	}
	public TdLobbyGameInfo()
	{
		// Object Offset:0x0058AC36
		TeamData = new array<TdLobbyGameInfo.LobbyTeamDataStruct>
		{
			new TdLobbyGameInfo.LobbyTeamDataStruct
			{
				TeamId = 0,
				TeamName = "Criminals",
				Players = default,
				MaxPlayers = 6,
				PlayerRoles = default,
			},
			new TdLobbyGameInfo.LobbyTeamDataStruct
			{
				TeamId = 0,
				TeamName = "Police",
				Players = default,
				MaxPlayers = 6,
				PlayerRoles = default,
			},
		};
		HUDType = ClassT<TdLobbyHud>()/*Ref Class'TdLobbyHud'*/;
	}
}
}
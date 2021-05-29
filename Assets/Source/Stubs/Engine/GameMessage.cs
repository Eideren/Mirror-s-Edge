namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameMessage : LocalMessage{
	public /*const localized */string SwitchLevelMessage;
	public /*const localized */string LeftMessage;
	public /*const localized */string FailedTeamMessage;
	public /*const localized */string FailedPlaceMessage;
	public /*const localized */string FailedSpawnMessage;
	public /*const localized */string EnteredMessage;
	public /*const localized */string MaxedOutMessage;
	public /*const localized */string ArbitrationMessage;
	public /*const localized */string OvertimeMessage;
	public /*const localized */string GlobalNameChange;
	public /*const localized */string NewTeamMessage;
	public /*const localized */string NewTeamMessageTrailer;
	public /*const localized */string NoNameChange;
	public /*const localized */string VoteStarted;
	public /*const localized */string VotePassed;
	public /*const localized */string MustHaveStats;
	public /*const localized */string CantBeSpectator;
	public /*const localized */string CantBePlayer;
	public /*const localized */string BecameSpectator;
	public /*const localized */string NewPlayerMessage;
	public /*const localized */string KickWarning;
	public /*const localized */string NewSpecMessage;
	public /*const localized */string SpecEnteredMessage;
	
	public /*function */static string GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public GameMessage()
	{
		// Object Offset:0x00332182
		SwitchLevelMessage = "Switching Levels";
		LeftMessage = " left the game.";
		FailedTeamMessage = "Could not find team for player";
		FailedPlaceMessage = "Could not find a starting spot";
		FailedSpawnMessage = "Could not spawn player";
		EnteredMessage = " entered the game.";
		MaxedOutMessage = "Server is already at capacity.";
		ArbitrationMessage = "Arbitration Message (c.f. GameInfo.uc)";
		OvertimeMessage = "Score tied at the end of regulation. Sudden Death Overtime!!!";
		GlobalNameChange = "changed name to";
		NewTeamMessage = "is now on";
		NoNameChange = "Name is already in use.";
		VoteStarted = "started a vote.";
		VotePassed = "Vote passed.";
		MustHaveStats = "Must have stats enabled to join this server.";
		CantBeSpectator = "Sorry, you cannot become a spectator at this time.";
		CantBePlayer = "Sorry, you cannot become an active player at this time.";
		BecameSpectator = "became a spectator.";
		NewPlayerMessage = "A new player entered the game.";
		KickWarning = "You are about to be kicked for idling!";
		NewSpecMessage = "A spectator entered the game/";
		SpecEnteredMessage = " joined as a spectator.";
	}
}
}
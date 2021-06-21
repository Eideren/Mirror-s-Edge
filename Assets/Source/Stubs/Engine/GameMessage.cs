namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameMessage : LocalMessage{
	public /*const localized */String SwitchLevelMessage;
	public /*const localized */String LeftMessage;
	public /*const localized */String FailedTeamMessage;
	public /*const localized */String FailedPlaceMessage;
	public /*const localized */String FailedSpawnMessage;
	public /*const localized */String EnteredMessage;
	public /*const localized */String MaxedOutMessage;
	public /*const localized */String ArbitrationMessage;
	public /*const localized */String OvertimeMessage;
	public /*const localized */String GlobalNameChange;
	public /*const localized */String NewTeamMessage;
	public /*const localized */String NewTeamMessageTrailer;
	public /*const localized */String NoNameChange;
	public /*const localized */String VoteStarted;
	public /*const localized */String VotePassed;
	public /*const localized */String MustHaveStats;
	public /*const localized */String CantBeSpectator;
	public /*const localized */String CantBePlayer;
	public /*const localized */String BecameSpectator;
	public /*const localized */String NewPlayerMessage;
	public /*const localized */String KickWarning;
	public /*const localized */String NewSpecMessage;
	public /*const localized */String SpecEnteredMessage;
	
	public /*function */static String GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
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
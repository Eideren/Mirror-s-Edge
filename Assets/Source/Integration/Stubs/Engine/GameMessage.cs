namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GameMessage : LocalMessage{
	[Const, localized] public String SwitchLevelMessage;
	[Const, localized] public String LeftMessage;
	[Const, localized] public String FailedTeamMessage;
	[Const, localized] public String FailedPlaceMessage;
	[Const, localized] public String FailedSpawnMessage;
	[Const, localized] public String EnteredMessage;
	[Const, localized] public String MaxedOutMessage;
	[Const, localized] public String ArbitrationMessage;
	[Const, localized] public String OvertimeMessage;
	[Const, localized] public String GlobalNameChange;
	[Const, localized] public String NewTeamMessage;
	[Const, localized] public String NewTeamMessageTrailer;
	[Const, localized] public String NoNameChange;
	[Const, localized] public String VoteStarted;
	[Const, localized] public String VotePassed;
	[Const, localized] public String MustHaveStats;
	[Const, localized] public String CantBeSpectator;
	[Const, localized] public String CantBePlayer;
	[Const, localized] public String BecameSpectator;
	[Const, localized] public String NewPlayerMessage;
	[Const, localized] public String KickWarning;
	[Const, localized] public String NewSpecMessage;
	[Const, localized] public String SpecEnteredMessage;
	
	public /*function */static String GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
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
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPDMGame : TdMPGame/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public override /*event */void InitGame(string Options, ref string ErrorMessage)
	{
		base.InitGame(Options, ref/*probably?*/ ErrorMessage);
	}
	
	public override /*function */void PreBeginPlay()
	{
		base.PreBeginPlay();
	}
	
	public override /*function */PlayerStart ChoosePlayerStart(Controller Player, /*optional */byte InTeam = default)
	{
		return StartPoints[Rand(StartPoints.Length)];
	}
	
	public override Logout_del Logout { get => bfield_Logout ?? TdMPDMGame_Logout; set => bfield_Logout = value; } Logout_del bfield_Logout;
	public override Logout_del global_Logout => TdMPDMGame_Logout;
	public /*function */void TdMPDMGame_Logout(Controller Exiting)
	{
		/*Transformed 'base.' to specific call*/GameInfo_Logout(Exiting);
	}
	
	public override PostLogin_del PostLogin { get => bfield_PostLogin ?? TdMPDMGame_PostLogin; set => bfield_PostLogin = value; } PostLogin_del bfield_PostLogin;
	public override PostLogin_del global_PostLogin => TdMPDMGame_PostLogin;
	public /*event */void TdMPDMGame_PostLogin(PlayerController NewPlayer)
	{
		/*Transformed 'base.' to specific call*/GameInfo_PostLogin(NewPlayer);
	}
	
	public override /*function */bool CheckEndGame(PlayerReplicationInfo Winner, string Reason)
	{
		return base.CheckEndGame(Winner, Reason);
	}
	protected override void RestoreDefaultFunction()
	{
		Logout = null;
		PostLogin = null;
	
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
	
		return (null, StateFlow, null);
	}
	
	
	protected (System.Action<name>, StateFlow, System.Action<name>) MatchOver()/*state MatchOver*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = null)
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
			case "MatchInProgress": return MatchInProgress();
			case "MatchOver": return MatchOver();
			default: return base.FindState(stateName);
		}
	}
	public TdMPDMGame()
	{
		// Object Offset:0x005F7163
		HUDType = ClassT<TdTeamDMHUD>()/*Ref Class'TdTeamDMHUD'*/;
	}
}
}
namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitMessage : TdLocalMessage{
	[Const, localized] public String HelicopterIsApproaching;
	[Const, localized] public String HelicopterIsLeaving;
	[Const, localized] public String PoliceSearchingBag;
	[Const, localized] public String PoliceSearchingIntercepted;
	public SoundNodeWave VOHelicopterIsApproaching;
	public SoundNodeWave VOHelicopterIsLeaving;
	public SoundNodeWave VOPoliceSearchingBag;
	public SoundNodeWave VORunnerMissionBriefing;
	public SoundNodeWave VOCopMissionBriefing;
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _PitcherPRI = default, /*optional */PlayerReplicationInfo _RecieverPRI = default, /*optional */Object _OptionalObject = default)
	{
		// stub
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetString(/*optional */int? _InSwitch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public TdPursuitMessage()
	{
		// Object Offset:0x0000D83B
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		PosY = 0.250f;
		FontSize = 2;
	}
}
}
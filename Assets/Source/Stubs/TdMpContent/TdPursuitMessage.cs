namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPursuitMessage : TdLocalMessage{
	public /*const localized */string HelicopterIsApproaching;
	public /*const localized */string HelicopterIsLeaving;
	public /*const localized */string PoliceSearchingBag;
	public /*const localized */string PoliceSearchingIntercepted;
	public SoundNodeWave VOHelicopterIsApproaching;
	public SoundNodeWave VOHelicopterIsLeaving;
	public SoundNodeWave VOPoliceSearchingBag;
	public SoundNodeWave VORunnerMissionBriefing;
	public SoundNodeWave VOCopMissionBriefing;
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int InSwitch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
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
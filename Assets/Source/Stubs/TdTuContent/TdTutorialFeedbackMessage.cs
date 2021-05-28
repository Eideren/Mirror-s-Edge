namespace MEdge.TdTuContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdEditor;

public partial class TdTutorialFeedbackMessage : TdLocalMessage{
	public /*const localized */string GoodWork;
	public /*const localized */string TryAgain;
	public SoundNodeWave VOGoodWork;
	public SoundNodeWave VOTryAgain;
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int InSwitch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public TdTutorialFeedbackMessage()
	{
		// Object Offset:0x000022C1
		TryAgain = "Failed";
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		bIsUnique = true;
		bDrawOutline = true;
		Lifetime = 2.0f;
		PosY = 0.250f;
		FontSize = 3;
	}
}
}
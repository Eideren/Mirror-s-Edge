namespace MEdge.TdTuContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdEditor;

public partial class TdTutorialFeedbackMessage : TdLocalMessage{
	[Const, localized] public String GoodWork;
	[Const, localized] public String TryAgain;
	public SoundNodeWave VOGoodWork;
	public SoundNodeWave VOTryAgain;
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _PitcherPRI = default, /*optional */PlayerReplicationInfo _RecieverPRI = default, /*optional */Object _OptionalObject = default)
	{
		// stub
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetString(/*optional */int? _InSwitch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
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
namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdTTVictoryMessage : TdVictoryMessage{
	public /*const localized */StaticArray<string, string, string>/*[3]*/ NewRecord;
	public /*const localized */StaticArray<string, string, string>/*[3]*/ TryAgain;
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public /*function */static string GetString(/*optional */int InSwitch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public TdTTVictoryMessage()
	{
		// Object Offset:0x00006199
		NewRecord = new StaticArray<string, string, string>/*[3]*/()
		{ 
			[0] = "Good work!",
			[1] = "Excellent!",
			[2] = "Well done!",
	 	};
		TryAgain = new StaticArray<string, string, string>/*[3]*/()
		{ 
			[0] = "Not fast enough!",
			[1] = "Too slow!",
			[2] = "Try again!",
	 	};
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		bDrawOutline = true;
		PosY = 0.250f;
		FontSize = 3;
	}
}
}
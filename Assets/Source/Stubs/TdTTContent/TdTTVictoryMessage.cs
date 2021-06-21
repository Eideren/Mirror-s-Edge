namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdTTVictoryMessage : TdVictoryMessage{
	public /*const localized */StaticArray<String, String, String>/*[3]*/ NewRecord;
	public /*const localized */StaticArray<String, String, String>/*[3]*/ TryAgain;
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
	}
	
	public /*function */static String GetString(/*optional */int? _InSwitch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public TdTTVictoryMessage()
	{
		// Object Offset:0x00006199
		NewRecord = new StaticArray<String, String, String>/*[3]*/()
		{ 
			[0] = "Good work!",
			[1] = "Excellent!",
			[2] = "Well done!",
	 	};
		TryAgain = new StaticArray<String, String, String>/*[3]*/()
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
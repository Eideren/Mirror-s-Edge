namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdTimeMessage : TdLocalMessage{
	public Object.Color RedColor;
	public Object.Color GreenColor;
	public StaticArray<SoundNodeWave, SoundNodeWave, SoundNodeWave>/*[3]*/ TimeSound;
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _PitcherPRI = default, /*optional */PlayerReplicationInfo _RecieverPRI = default, /*optional */Object _OptionalObject = default)
	{
		// stub
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int? _InSwitch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public /*function */static String GetString(/*optional */int? _InSwitch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public /*function */static Object.Color GetColor(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default, /*optional */Object _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public TdTimeMessage()
	{
		// Object Offset:0x00004C9C
		RedColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		GreenColor = new Color
		{
			R=0,
			G=255,
			B=0,
			A=255
		};
		TimeSound = new StaticArray<SoundNodeWave, SoundNodeWave, SoundNodeWave>/*[3]*/()
		{ 
			[0] = LoadAsset<SoundNodeWave>("A_TimeTrial.RAW.A_TT_CP_Positive")/*Ref SoundNodeWave'A_TimeTrial.RAW.A_TT_CP_Positive'*/,
			[1] = LoadAsset<SoundNodeWave>("A_TimeTrial.RAW.A_TT_CP_Neutral")/*Ref SoundNodeWave'A_TimeTrial.RAW.A_TT_CP_Neutral'*/,
			[2] = LoadAsset<SoundNodeWave>("A_TimeTrial.RAW.A_TT_CP_Negative")/*Ref SoundNodeWave'A_TimeTrial.RAW.A_TT_CP_Negative'*/,
	 	};
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		bDrawOutline = true;
		Lifetime = 2.0f;
		DrawColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		PosY = 0.250f;
		FontSize = 2;
	}
}
}
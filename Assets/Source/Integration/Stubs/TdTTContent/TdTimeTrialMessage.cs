namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialMessage : TdLocalMessage{
	public /*const localized */String RaceStarted;
	public /*const localized */String TWO;
	public /*const localized */String ONE;
	public /*const localized */String THREE;
	public StaticArray<SoundNodeWave, SoundNodeWave>/*[2]*/ VORaceStarted;
	
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
	
	public /*function */static float GetLifeTime(int Switch)
	{
		// stub
		return default;
	}
	
	public TdTimeTrialMessage()
	{
		// Object Offset:0x00005BB2
		RaceStarted = "Go!!";
		TWO = "Ready";
		ONE = "Set";
		VORaceStarted = new StaticArray<SoundNodeWave, SoundNodeWave>/*[2]*/()
		{ 
			[0] = LoadAsset<SoundNodeWave>("A_TimeTrial.RAW.A_TT_CD_01")/*Ref SoundNodeWave'A_TimeTrial.RAW.A_TT_CD_01'*/,
			[1] = LoadAsset<SoundNodeWave>("A_TimeTrial.RAW.A_TT_CD_02")/*Ref SoundNodeWave'A_TimeTrial.RAW.A_TT_CD_02'*/,
	 	};
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		bIsUnique = true;
		bDrawOutline = true;
		PosY = 0.250f;
		FontSize = 3;
	}
}
}
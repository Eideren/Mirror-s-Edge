namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLocalMessage : LocalMessage{
	public enum EMessageArea 
	{
		EMA_Left,
		EMA_Right,
		EMA_Centered,
		EMA_MAX
	};
	
	public enum EMessageType 
	{
		MT_Taunt,
		MT_NeedAssistance,
		MT_Praise,
		MT_Dropped,
		MT_PickUp,
		MT_Intecepted,
		MT_Passed,
		MT_Catched,
		MT_YouHaveTheBag,
		MT_BagIsOnGround,
		MT_RequestBag,
		MT_NeedABagCatcher,
		MT_Kill,
		MT_NoKiller,
		MT_Suicide,
		MT_TeamKill,
		MT_MeleeKill,
		MT_BagKill,
		MT_BagThretener,
		MT_Helicopter_Approaching,
		MT_Helicopter_Leaving,
		MT_Police_Searching,
		MT_Searching_Intercepted,
		MT_MissionBriefing,
		MT_TTRaceStarted,
		MT_One,
		MT_Two,
		MT_Three,
		MT_NewPersonalRecord,
		MT_NewWorldRecord,
		MT_NewFriendsRecord,
		MT_TryAgain,
		MT_CheckpointCriteriaCompleted,
		MT_CheckpointCriteriaFailed,
		MT_MAX
	};
	
	public float RadioAnnouncementVolume;
	public TdLocalMessage.EMessageArea MessageArea;
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
		return default;
	}
	
	public /*function */static int GetMessageArea(/*optional */int? _Switch = default)
	{
		// stub
		return default;
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
		// stub
		return default;
	}
	
	public TdLocalMessage()
	{
		// Object Offset:0x0058C547
		RadioAnnouncementVolume = 1.0f;
		PosY = 0.050f;
		FontSize = 1;
	}
}
}
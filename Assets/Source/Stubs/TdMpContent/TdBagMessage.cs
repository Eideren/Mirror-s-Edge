namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBagMessage : TdLocalMessage{
	public /*const localized */string BagDropped;
	public /*const localized */string BagIntecepted;
	public /*const localized */string BagPickedUp;
	public /*const localized */string YouHaveBag;
	public /*const localized */string BagIsOnGround;
	public SoundNodeWave VOBagDroppedOnGround;
	public SoundNodeWave VOBagPickedUpByRunnerEnemy;
	public SoundNodeWave VOBagPickedUpByCopEnemy;
	public SoundNodeWave VOBagPickedUpByFriend;
	public SoundNodeWave VOYouHaveTheBag;
	public StaticArray<SoundNodeWave, SoundNodeWave>/*[2]*/ VONeedABagCatcher;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VORequestBag;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOBagPassed;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOBagCatched;
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _AnnouncerPRI = default, /*optional */PlayerReplicationInfo? _OtherPRI = default)
	{
	
		return default;
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
	
	}
	
	public /*function */static float GetLifeTime(int Switch)
	{
	
		return default;
	}
	
	public /*function */static Object.Color GetColor(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int? _InSwitch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public TdBagMessage()
	{
		// Object Offset:0x0000C05F
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		PosY = 0.250f;
		FontSize = 2;
	}
}
}
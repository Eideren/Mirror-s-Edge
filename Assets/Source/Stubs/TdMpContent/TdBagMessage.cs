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
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int Switch = default, /*optional */PlayerReplicationInfo AnnouncerPRI = default, /*optional */PlayerReplicationInfo OtherPRI = default)
	{
	
		return default;
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public /*function */static float GetLifeTime(int Switch)
	{
	
		return default;
	}
	
	public /*function */static Object.Color GetColor(/*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*function */static float GetPos(int Switch, HUD myHUD)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int InSwitch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
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
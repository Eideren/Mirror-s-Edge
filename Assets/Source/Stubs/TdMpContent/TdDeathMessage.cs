namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDeathMessage : TdLocalMessage{
	public /*const localized */string Suicide;
	public /*const localized */string NoKiller;
	public /*const localized */string KilledBy;
	public /*const localized */string MeleeKilledBy;
	public /*const localized */string TeamKilledBy;
	public /*const localized */string KilledBagCarrier;
	public SoundNodeWave VOCopKilledBagCarrier;
	public SoundNodeWave VORunnerKilledBagCarrier;
	public SoundNodeWave VOCopKilledBagThretener;
	public SoundNodeWave VORunnerKilledBagThretener;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOMeleeKill;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOKill;
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int Switch = default, /*optional */PlayerReplicationInfo AnnouncerPRI = default, /*optional */PlayerReplicationInfo OtherPRI = default)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int Switch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo Killer = default, /*optional */PlayerReplicationInfo Victim = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int Switch = default, /*optional */PlayerReplicationInfo Killer = default, /*optional */PlayerReplicationInfo Victim = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int Switch = default, /*optional */PlayerReplicationInfo PitcherPRI = default, /*optional */PlayerReplicationInfo RecieverPRI = default, /*optional */Object OptionalObject = default)
	{
	
	}
	
	public /*function */static Object.Color GetColor(/*optional */int Switch = default, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
}
}
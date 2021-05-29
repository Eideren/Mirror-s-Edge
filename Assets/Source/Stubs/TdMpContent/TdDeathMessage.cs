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
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _AnnouncerPRI = default, /*optional */PlayerReplicationInfo? _OtherPRI = default)
	{
	
		return default;
	}
	
	public /*function */static string GetString(/*optional */int? _Switch = default, /*optional */bool? _bPRI1HUD = default, /*optional */PlayerReplicationInfo? _Killer = default, /*optional */PlayerReplicationInfo? _Victim = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static SoundNodeWave GetAnnouncementSound(PlayerController LocalController, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _Killer = default, /*optional */PlayerReplicationInfo? _Victim = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
	public /*simulated function */static void ClientReceive(PlayerController P, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _PitcherPRI = default, /*optional */PlayerReplicationInfo? _RecieverPRI = default, /*optional */Object? _OptionalObject = default)
	{
	
	}
	
	public /*function */static Object.Color GetColor(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
	
		return default;
	}
	
}
}
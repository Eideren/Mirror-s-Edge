namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEmoteMessage : TdLocalMessage{
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOTaunt;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VONeedAssistance;
	public StaticArray<SoundCue, SoundCue>/*[2]*/ VOPraise;
	
	public /*simulated function */static SoundCue Get3DAnnouncementSound(/*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _AnnouncerPRI = default, /*optional */PlayerReplicationInfo? _OtherPRI = default)
	{
	
		return default;
	}
	
}
}
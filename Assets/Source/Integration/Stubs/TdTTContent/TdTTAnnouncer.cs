namespace MEdge.TdTTContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTuContent; using TdEditor;

public partial class TdTTAnnouncer : TdAnnouncerBase/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdTTAnnouncer()
	{
		var Default__TdTTAnnouncer_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTTAnnouncer.Sprite' */;
		// Object Offset:0x00005D7C
		RadioSoundCueTemplate = LoadAsset<SoundCue>("A_VO_Trial_Announcer.A_VO_Trial_SoundCueTemplate")/*Ref SoundCue'A_VO_Trial_Announcer.A_VO_Trial_SoundCueTemplate'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTTAnnouncer_Sprite/*Ref SpriteComponent'Default__TdTTAnnouncer.Sprite'*/,
		};
	}
}
}
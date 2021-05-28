namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnnouncerBase : Info/*
		abstract
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public /*private */Core.ClassT<TdLocalMessage> PlayingAnnouncementClass;
	public /*private */TdPlayerController PlayerOwner;
	public /*private */SoundCue RadioSoundCueTemplate;
	public /*private export editinline */AudioComponent CurrentAnnouncementComponent;
	
	public override /*function */void PostBeginPlay()
	{
	
	}
	
	public /*function */static void Play3DLocationalAnnouncement(Actor Announcer, Core.ClassT<LocalMessage> InMessageClass, int Switch, bool bReplicateToGhosts, bool bReplicateToOwner, /*optional */PlayerReplicationInfo RelatedPRI_1 = default, /*optional */PlayerReplicationInfo RelatedPRI_2 = default)
	{
	
	}
	
	public virtual /*function */void PlayAnnouncement(Core.ClassT<TdLocalMessage> InMessageClass, SoundNodeWave Announcement)
	{
	
	}
	
	public TdAnnouncerBase()
	{
		// Object Offset:0x005092A8
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdAnnouncerBase.Sprite")/*Ref SpriteComponent'Default__TdAnnouncerBase.Sprite'*/,
		};
	}
}
}
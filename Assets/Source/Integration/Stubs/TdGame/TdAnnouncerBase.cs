namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAnnouncerBase : Info/*
		abstract
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public/*private*/ Core.ClassT<TdLocalMessage> PlayingAnnouncementClass;
	public/*private*/ TdPlayerController PlayerOwner;
	public/*private*/ SoundCue RadioSoundCueTemplate;
	[export, editinline] public/*private*/ AudioComponent CurrentAnnouncementComponent;
	
	public override /*function */void eventPostBeginPlay()
	{
		// stub
	}
	
	public /*function */static void Play3DLocationalAnnouncement(Actor Announcer, Core.ClassT<LocalMessage> InMessageClass, int Switch, bool bReplicateToGhosts, bool bReplicateToOwner, /*optional */PlayerReplicationInfo _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo _RelatedPRI_2 = default)
	{
		// stub
	}
	
	public virtual /*function */void PlayAnnouncement(Core.ClassT<TdLocalMessage> InMessageClass, SoundNodeWave Announcement)
	{
		// stub
	}
	
	public TdAnnouncerBase()
	{
		var Default__TdAnnouncerBase_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdAnnouncerBase.Sprite' */;
		// Object Offset:0x005092A8
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdAnnouncerBase_Sprite/*Ref SpriteComponent'Default__TdAnnouncerBase.Sprite'*/,
		};
	}
}
}
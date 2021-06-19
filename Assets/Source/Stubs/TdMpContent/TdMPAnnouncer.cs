namespace MEdge.TdMpContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMPAnnouncer : TdAnnouncerBase/*
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public TdMPAnnouncer()
	{
		var Default__TdMPAnnouncer_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMPAnnouncer.Sprite' */;
		// Object Offset:0x0000D032
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMPAnnouncer_Sprite/*Ref SpriteComponent'Default__TdMPAnnouncer.Sprite'*/,
		};
	}
}
}
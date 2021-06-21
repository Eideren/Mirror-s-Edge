namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class BroadcastHandler : Info/*
		config(Game)
		notplaceable
		hidecategories(Navigation,Movement,Collision)*/{
	public int SentText;
	public /*config */bool bMuteSpectators;
	
	public virtual /*function */void UpdateSentText()
	{
		// stub
	}
	
	public virtual /*function */bool AllowsBroadcast(Actor broadcaster, int InLen)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void BroadcastText(PlayerReplicationInfo SenderPRI, PlayerController Receiver, /*coerce */String msg, /*optional */name? _Type = default)
	{
		// stub
	}
	
	public virtual /*function */void BroadcastLocalized(Actor Sender, PlayerController Receiver, Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
	}
	
	public virtual /*function */void Broadcast(Actor Sender, /*coerce */String msg, /*optional */name? _Type = default)
	{
		// stub
	}
	
	public virtual /*function */void BroadcastTeam(Controller Sender, /*coerce */String msg, /*optional */name? _Type = default)
	{
		// stub
	}
	
	public virtual /*event */void AllowBroadcastLocalized(Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
	}
	
	public virtual /*event */void AllowBroadcastLocalizedTeam(int TeamIndex, Actor Sender, Core.ClassT<LocalMessage> Message, /*optional */int? _Switch = default, /*optional */PlayerReplicationInfo? _RelatedPRI_1 = default, /*optional */PlayerReplicationInfo? _RelatedPRI_2 = default, /*optional */Object? _OptionalObject = default)
	{
		// stub
	}
	
	public BroadcastHandler()
	{
		var Default__BroadcastHandler_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__BroadcastHandler.Sprite' */;
		// Object Offset:0x002B33B4
		Components = new array</*export editinline */ActorComponent>
		{
			Default__BroadcastHandler_Sprite/*Ref SpriteComponent'Default__BroadcastHandler.Sprite'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
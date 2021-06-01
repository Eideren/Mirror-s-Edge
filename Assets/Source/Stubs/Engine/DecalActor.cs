namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DecalActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ /*const editconst export editinline */DecalComponent Decal;
	
	public DecalActor()
	{
		// Object Offset:0x003088FA
		Decal = new DecalComponent
		{
			// Object Offset:0x004668D3
			bStaticDecal = true,
		}/* Reference: DecalComponent'Default__DecalActor.NewDecalComponent' */;
		bStatic = true;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004CF86A
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__DecalActor.Sprite' */,
			new DecalComponent
			{
				// Object Offset:0x004668D3
				bStaticDecal = true,
			}/* Reference: DecalComponent'Default__DecalActor.NewDecalComponent' */,
			LoadAsset<ArrowComponent>("Default__DecalActor.ArrowComponent0")/*Ref ArrowComponent'Default__DecalActor.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
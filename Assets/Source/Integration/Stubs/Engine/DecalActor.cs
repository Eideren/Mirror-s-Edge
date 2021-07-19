namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DecalActor : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	[Category] [Const, editconst, export, editinline] public DecalComponent Decal;
	
	public DecalActor()
	{
		var Default__DecalActor_NewDecalComponent = new DecalComponent
		{
			// Object Offset:0x004668D3
			bStaticDecal = true,
		}/* Reference: DecalComponent'Default__DecalActor.NewDecalComponent' */;
		var Default__DecalActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CF86A
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__DecalActor.Sprite' */;
		var Default__DecalActor_ArrowComponent0 = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__DecalActor.ArrowComponent0' */;
		// Object Offset:0x003088FA
		Decal = Default__DecalActor_NewDecalComponent/*Ref DecalComponent'Default__DecalActor.NewDecalComponent'*/;
		bStatic = true;
		bMovable = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__DecalActor_Sprite/*Ref SpriteComponent'Default__DecalActor.Sprite'*/,
			Default__DecalActor_NewDecalComponent/*Ref DecalComponent'Default__DecalActor.NewDecalComponent'*/,
			Default__DecalActor_ArrowComponent0/*Ref ArrowComponent'Default__DecalActor.ArrowComponent0'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
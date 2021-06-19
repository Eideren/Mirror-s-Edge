namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMarker : Note/*
		native
		placeable
		hidecategories(Navigation)*/{
	public TdMarker()
	{
		var Default__TdMarker_Arrow = new ArrowComponent
		{
			// Object Offset:0x0053732A
			ArrowSize = 2.0f,
		}/* Reference: ArrowComponent'Default__TdMarker.Arrow' */;
		var Default__TdMarker_Sprite = new SpriteComponent
		{
			// Object Offset:0x0053735E
			Sprite = LoadAsset<Texture2D>("EngineResources.Corpse")/*Ref Texture2D'EngineResources.Corpse'*/,
		}/* Reference: SpriteComponent'Default__TdMarker.Sprite' */;
		// Object Offset:0x00537257
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMarker_Arrow/*Ref ArrowComponent'Default__TdMarker.Arrow'*/,
			Default__TdMarker_Sprite/*Ref SpriteComponent'Default__TdMarker.Sprite'*/,
			Default__TdMarker_Arrow/*Ref ArrowComponent'Default__TdMarker.Arrow'*/,
		};
	}
}
}
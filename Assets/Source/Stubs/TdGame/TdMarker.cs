namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMarker : Note/*
		native
		placeable
		hidecategories(Navigation)*/{
	public TdMarker()
	{
		// Object Offset:0x00537257
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new ArrowComponent
			{
				// Object Offset:0x0053732A
				ArrowSize = 2.0f,
			}/* Reference: ArrowComponent'Default__TdMarker.Arrow' */,
			new SpriteComponent
			{
				// Object Offset:0x0053735E
				Sprite = LoadAsset<Texture2D>("EngineResources.Corpse")/*Ref Texture2D'EngineResources.Corpse'*/,
			}/* Reference: SpriteComponent'Default__TdMarker.Sprite' */,
			new ArrowComponent
			{
				// Object Offset:0x0053732A
				ArrowSize = 2.0f,
			}/* Reference: ArrowComponent'Default__TdMarker.Arrow' */,
		};
	}
}
}
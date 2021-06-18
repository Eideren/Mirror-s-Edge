namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PolyMarker : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	public PolyMarker()
	{
		var Default__PolyMarker_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D0072
			Sprite = LoadAsset<Texture2D>("EngineResources.S_PolyMarker")/*Ref Texture2D'EngineResources.S_PolyMarker'*/,
		}/* Reference: SpriteComponent'Default__PolyMarker.Sprite' */;
		// Object Offset:0x003A2F11
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PolyMarker_Sprite,
		};
	}
}
}
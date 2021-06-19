namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ClipMarker : Keypoint/*
		native
		placeable
		hidecategories(Navigation)*/{
	public ClipMarker()
	{
		var Default__ClipMarker_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CF702
			Sprite = LoadAsset<Texture2D>("EngineResources.S_ClipMarker")/*Ref Texture2D'EngineResources.S_ClipMarker'*/,
		}/* Reference: SpriteComponent'Default__ClipMarker.Sprite' */;
		// Object Offset:0x002BC7D7
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__ClipMarker_Sprite/*Ref SpriteComponent'Default__ClipMarker.Sprite'*/,
		};
	}
}
}
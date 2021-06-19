namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCopSpawnMarker : TdMarker/*
		placeable
		hidecategories(Navigation)*/{
	public TdCopSpawnMarker()
	{
		var Default__TdCopSpawnMarker_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdCopSpawnMarker.Arrow' */;
		var Default__TdCopSpawnMarker_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51E75
			Sprite = LoadAsset<Texture2D>("TdEditorResources.CopSpawnIcon")/*Ref Texture2D'TdEditorResources.CopSpawnIcon'*/,
			Scale = 0.250f,
		}/* Reference: SpriteComponent'Default__TdCopSpawnMarker.Sprite' */;
		// Object Offset:0x00537392
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdCopSpawnMarker_Arrow/*Ref ArrowComponent'Default__TdCopSpawnMarker.Arrow'*/,
			Default__TdCopSpawnMarker_Sprite/*Ref SpriteComponent'Default__TdCopSpawnMarker.Sprite'*/,
			Default__TdCopSpawnMarker_Arrow/*Ref ArrowComponent'Default__TdCopSpawnMarker.Arrow'*/,
		};
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGenericSpawnMarker : TdMarker/*
		placeable
		hidecategories(Navigation)*/{
	public TdGenericSpawnMarker()
	{
		var Default__TdGenericSpawnMarker_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdGenericSpawnMarker.Arrow' */;
		var Default__TdGenericSpawnMarker_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E51FA5
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
			Scale = 0.250f,
		}/* Reference: SpriteComponent'Default__TdGenericSpawnMarker.Sprite' */;
		// Object Offset:0x0054D64E
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGenericSpawnMarker_Arrow/*Ref ArrowComponent'Default__TdGenericSpawnMarker.Arrow'*/,
			Default__TdGenericSpawnMarker_Sprite/*Ref SpriteComponent'Default__TdGenericSpawnMarker.Sprite'*/,
			Default__TdGenericSpawnMarker_Arrow/*Ref ArrowComponent'Default__TdGenericSpawnMarker.Arrow'*/,
		};
	}
}
}
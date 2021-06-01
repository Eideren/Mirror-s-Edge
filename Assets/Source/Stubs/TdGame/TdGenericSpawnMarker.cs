namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGenericSpawnMarker : TdMarker/*
		placeable
		hidecategories(Navigation)*/{
	public TdGenericSpawnMarker()
	{
		// Object Offset:0x0054D64E
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<ArrowComponent>("Default__TdGenericSpawnMarker.Arrow")/*Ref ArrowComponent'Default__TdGenericSpawnMarker.Arrow'*/,
			new SpriteComponent
			{
				// Object Offset:0x02E51FA5
				Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
				Scale = 0.250f,
			}/* Reference: SpriteComponent'Default__TdGenericSpawnMarker.Sprite' */,
			LoadAsset<ArrowComponent>("Default__TdGenericSpawnMarker.Arrow")/*Ref ArrowComponent'Default__TdGenericSpawnMarker.Arrow'*/,
		};
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSoundMarker : TdMarker/*
		placeable
		hidecategories(Navigation)*/{
	public TdSoundMarker()
	{
		// Object Offset:0x006597A1
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<ArrowComponent>("Default__TdSoundMarker.Arrow")/*Ref ArrowComponent'Default__TdSoundMarker.Arrow'*/,
			new SpriteComponent
			{
				// Object Offset:0x02E52605
				Sprite = LoadAsset<Texture2D>("TdEditorResources.SoundSourceIcon")/*Ref Texture2D'TdEditorResources.SoundSourceIcon'*/,
				Scale = 0.250f,
			}/* Reference: SpriteComponent'Default__TdSoundMarker.Sprite' */,
			LoadAsset<ArrowComponent>("Default__TdSoundMarker.Arrow")/*Ref ArrowComponent'Default__TdSoundMarker.Arrow'*/,
		};
	}
}
}
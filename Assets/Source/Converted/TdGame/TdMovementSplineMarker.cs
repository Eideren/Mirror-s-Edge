namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMovementSplineMarker : Keypoint/*
		transient
		native
		placeable
		hidecategories(Navigation)*/{
	public TdMovementSplineMarker()
	{
		// Object Offset:0x005F291A
		bHardAttach = true;
		bHiddenEd = true;
		bEdShouldSnap = true;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E521F9
				Sprite = LoadAsset<Texture2D>("EngineResources.S_PolyMarker")/*Ref Texture2D'EngineResources.S_PolyMarker'*/,
				Scale = 2.0f,
			}/* Reference: SpriteComponent'Default__TdMovementSplineMarker.Sprite' */,
		};
	}
}
}
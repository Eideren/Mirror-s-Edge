namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Keypoint : Actor/*
		abstract
		native
		placeable
		hidecategories(Navigation)*/{
	public Keypoint()
	{
		var Default__Keypoint_Sprite = new SpriteComponent
		{
			// Object Offset:0x0028D856
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Keypoint")/*Ref Texture2D'EngineResources.S_Keypoint'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__Keypoint.Sprite' */;
		// Object Offset:0x0028D75B
		bStatic = true;
		bHidden = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Keypoint_Sprite/*Ref SpriteComponent'Default__Keypoint.Sprite'*/,
		};
		TickGroup = Object.ETickingGroup.TG_DuringAsyncWork;
	}
}
}
namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialInstanceActor : Actor/*
		native
		placeable
		hidecategories(Navigation,Movement,Advanced,Collision,Display,Actor,Attachment)*/{
	public/*()*/ MaterialInstanceConstant MatInst;
	
	public MaterialInstanceActor()
	{
		var Default__MaterialInstanceActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFD5E
			Sprite = LoadAsset<Texture2D>("EngineResources.MatInstActSprite")/*Ref Texture2D'EngineResources.MatInstActSprite'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__MaterialInstanceActor.Sprite' */;
		// Object Offset:0x0035A56A
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__MaterialInstanceActor_Sprite/*Ref SpriteComponent'Default__MaterialInstanceActor.Sprite'*/,
		};
	}
}
}
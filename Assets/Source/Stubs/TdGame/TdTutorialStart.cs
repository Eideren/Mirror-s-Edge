namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialStart : TdPlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ array<TdSPTutorialGame.EMovementChallenge> BelongToChallenge;
	
	public virtual /*function */bool IsStartSpotInTrack(int TrackIndex)
	{
	
		return default;
	}
	
	public TdTutorialStart()
	{
		// Object Offset:0x00680543
		SphereRenderComponent = LoadAsset<DrawSphereComponent>("Default__TdTutorialStart.SpawnRadiusSphere")/*Ref DrawSphereComponent'Default__TdTutorialStart.SpawnRadiusSphere'*/;
		GenericSprite = LoadAsset<SpriteComponent>("Default__TdTutorialStart.Sprite")/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/;
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdTutorialStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdTutorialStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTutorialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdTutorialStart.Sprite")/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdTutorialStart.Sprite2")/*Ref SpriteComponent'Default__TdTutorialStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdTutorialStart.Sprite")/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdTutorialStart.Sprite2")/*Ref SpriteComponent'Default__TdTutorialStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdTutorialStart.Arrow")/*Ref ArrowComponent'Default__TdTutorialStart.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdTutorialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdTutorialStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdTutorialStart.PathRenderer'*/,
			LoadAsset<DrawSphereComponent>("Default__TdTutorialStart.SpawnRadiusSphere")/*Ref DrawSphereComponent'Default__TdTutorialStart.SpawnRadiusSphere'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTutorialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/;
	}
}
}
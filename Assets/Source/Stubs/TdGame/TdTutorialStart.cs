namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTutorialStart : TdPlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ array<TdSPTutorialGame.EMovementChallenge> BelongToChallenge;
	
	public virtual /*function */bool IsStartSpotInTrack(int TrackIndex)
	{
		// stub
		return default;
	}
	
	public TdTutorialStart()
	{
		var Default__TdTutorialStart_SpawnRadiusSphere = new DrawSphereComponent
		{
		}/* Reference: DrawSphereComponent'Default__TdTutorialStart.SpawnRadiusSphere' */;
		var Default__TdTutorialStart_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTutorialStart.Sprite' */;
		var Default__TdTutorialStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdTutorialStart.PlayerStartTextureResourcesObject' */;
		var Default__TdTutorialStart_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTutorialStart.CollisionCylinder' */;
		var Default__TdTutorialStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTutorialStart.Sprite2' */;
		var Default__TdTutorialStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTutorialStart.Arrow' */;
		var Default__TdTutorialStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdTutorialStart.PathRenderer' */;
		// Object Offset:0x00680543
		SphereRenderComponent = Default__TdTutorialStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTutorialStart.SpawnRadiusSphere'*/;
		GenericSprite = Default__TdTutorialStart_Sprite/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/;
		PlayerStartTextureResources = Default__TdTutorialStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__TdTutorialStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdTutorialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/;
		GoodSprite = Default__TdTutorialStart_Sprite/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/;
		BadSprite = Default__TdTutorialStart_Sprite2/*Ref SpriteComponent'Default__TdTutorialStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTutorialStart_Sprite/*Ref SpriteComponent'Default__TdTutorialStart.Sprite'*/,
			Default__TdTutorialStart_Sprite2/*Ref SpriteComponent'Default__TdTutorialStart.Sprite2'*/,
			Default__TdTutorialStart_Arrow/*Ref ArrowComponent'Default__TdTutorialStart.Arrow'*/,
			Default__TdTutorialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/,
			Default__TdTutorialStart_PathRenderer/*Ref PathRenderingComponent'Default__TdTutorialStart.PathRenderer'*/,
			Default__TdTutorialStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTutorialStart.SpawnRadiusSphere'*/,
		};
		CollisionComponent = Default__TdTutorialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTutorialStart.CollisionCylinder'*/;
	}
}
}
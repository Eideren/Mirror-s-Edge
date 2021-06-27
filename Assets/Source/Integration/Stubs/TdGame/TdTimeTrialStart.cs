namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialStart : TdPlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ TdSPTimeTrialGame.ETTStretch TrackIndex;
	
	public TdTimeTrialStart()
	{
		var Default__TdTimeTrialStart_SpawnRadiusSphere = new DrawSphereComponent
		{
			// Object Offset:0x01B685F2
			SphereRadius = 200.0f,
		}/* Reference: DrawSphereComponent'Default__TdTimeTrialStart.SpawnRadiusSphere' */;
		var Default__TdTimeTrialStart_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52865
			Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
			Scale = 1.0f,
		}/* Reference: SpriteComponent'Default__TdTimeTrialStart.Sprite' */;
		var Default__TdTimeTrialStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdTimeTrialStart.PlayerStartTextureResourcesObject' */;
		var Default__TdTimeTrialStart_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder' */;
		var Default__TdTimeTrialStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdTimeTrialStart.Sprite2' */;
		var Default__TdTimeTrialStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdTimeTrialStart.Arrow' */;
		var Default__TdTimeTrialStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdTimeTrialStart.PathRenderer' */;
		// Object Offset:0x0067A445
		SphereRenderComponent = Default__TdTimeTrialStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTimeTrialStart.SpawnRadiusSphere'*/;
		GenericSprite = Default__TdTimeTrialStart_Sprite/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite'*/;
		PlayerStartTextureResources = Default__TdTimeTrialStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__TdTimeTrialStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdTimeTrialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/;
		GoodSprite = Default__TdTimeTrialStart_Sprite/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite'*/;
		BadSprite = Default__TdTimeTrialStart_Sprite2/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdTimeTrialStart_Sprite/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite'*/,
			Default__TdTimeTrialStart_Sprite2/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite2'*/,
			Default__TdTimeTrialStart_Arrow/*Ref ArrowComponent'Default__TdTimeTrialStart.Arrow'*/,
			Default__TdTimeTrialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/,
			Default__TdTimeTrialStart_PathRenderer/*Ref PathRenderingComponent'Default__TdTimeTrialStart.PathRenderer'*/,
			Default__TdTimeTrialStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdTimeTrialStart.SpawnRadiusSphere'*/,
		};
		CollisionComponent = Default__TdTimeTrialStart_CollisionCylinder/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/;
	}
}
}
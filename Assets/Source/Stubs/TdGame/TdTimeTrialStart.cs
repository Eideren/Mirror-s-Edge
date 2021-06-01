namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTimeTrialStart : TdPlayerStart/*
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ TdSPTimeTrialGame.ETTStretch TrackIndex;
	
	public TdTimeTrialStart()
	{
		// Object Offset:0x0067A445
		SphereRenderComponent = new DrawSphereComponent
		{
			// Object Offset:0x01B685F2
			SphereRadius = 200.0f,
		}/* Reference: DrawSphereComponent'Default__TdTimeTrialStart.SpawnRadiusSphere' */;
		GenericSprite = new SpriteComponent
		{
			// Object Offset:0x02E52865
			Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
			Scale = 1.0f,
		}/* Reference: SpriteComponent'Default__TdTimeTrialStart.Sprite' */;
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdTimeTrialStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdTimeTrialStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTimeTrialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E52865
			Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
			Scale = 1.0f,
		}/* Reference: SpriteComponent'Default__TdTimeTrialStart.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdTimeTrialStart.Sprite2")/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x02E52865
				Sprite = LoadAsset<Texture2D>("TdEditorResources.Timer")/*Ref Texture2D'TdEditorResources.Timer'*/,
				Scale = 1.0f,
			}/* Reference: SpriteComponent'Default__TdTimeTrialStart.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdTimeTrialStart.Sprite2")/*Ref SpriteComponent'Default__TdTimeTrialStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdTimeTrialStart.Arrow")/*Ref ArrowComponent'Default__TdTimeTrialStart.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdTimeTrialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdTimeTrialStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdTimeTrialStart.PathRenderer'*/,
			new DrawSphereComponent
			{
				// Object Offset:0x01B685F2
				SphereRadius = 200.0f,
			}/* Reference: DrawSphereComponent'Default__TdTimeTrialStart.SpawnRadiusSphere' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTimeTrialStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTimeTrialStart.CollisionCylinder'*/;
	}
}
}
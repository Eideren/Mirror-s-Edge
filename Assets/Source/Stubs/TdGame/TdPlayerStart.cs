namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPlayerStart : PlayerStart/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ float Radius;
	public/*()*/ int SpawnPointID;
	public /*private export editinline */DrawSphereComponent SphereRenderComponent;
	public /*protected export editinline */SpriteComponent GenericSprite;
	
	public TdPlayerStart()
	{
		var Default__TdPlayerStart_SpawnRadiusSphere = new DrawSphereComponent
		{
			// Object Offset:0x0067485E
			SphereRadius = 300.0f,
		}/* Reference: DrawSphereComponent'Default__TdPlayerStart.SpawnRadiusSphere' */;
		var Default__TdPlayerStart_Sprite = new SpriteComponent
		{
			// Object Offset:0x00674792
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdPlayerStart.Sprite' */;
		var Default__TdPlayerStart_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00674812
			CollisionHeight = 94.0f,
		}/* Reference: CylinderComponent'Default__TdPlayerStart.CollisionCylinder' */;
		// Object Offset:0x00631808
		Radius = 300.0f;
		SphereRenderComponent = Default__TdPlayerStart_SpawnRadiusSphere;
		GenericSprite = Default__TdPlayerStart_Sprite;
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdPlayerStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdPlayerStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdPlayerStart_CollisionCylinder;
		GoodSprite = Default__TdPlayerStart_Sprite;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPlayerStart_Sprite,
			LoadAsset<SpriteComponent>("Default__TdPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdPlayerStart.Arrow")/*Ref ArrowComponent'Default__TdPlayerStart.Arrow'*/,
			Default__TdPlayerStart_CollisionCylinder,
			LoadAsset<PathRenderingComponent>("Default__TdPlayerStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdPlayerStart.PathRenderer'*/,
			Default__TdPlayerStart_SpawnRadiusSphere,
		};
		CollisionComponent = Default__TdPlayerStart_CollisionCylinder;
	}
}
}
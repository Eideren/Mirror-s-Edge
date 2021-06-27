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
		var Default__TdPlayerStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__TdPlayerStart.PlayerStartTextureResourcesObject' */;
		var Default__TdPlayerStart_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00674812
			CollisionHeight = 94.0f,
		}/* Reference: CylinderComponent'Default__TdPlayerStart.CollisionCylinder' */;
		var Default__TdPlayerStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdPlayerStart.Sprite2' */;
		var Default__TdPlayerStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdPlayerStart.Arrow' */;
		var Default__TdPlayerStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdPlayerStart.PathRenderer' */;
		// Object Offset:0x00631808
		Radius = 300.0f;
		SphereRenderComponent = Default__TdPlayerStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdPlayerStart.SpawnRadiusSphere'*/;
		GenericSprite = Default__TdPlayerStart_Sprite/*Ref SpriteComponent'Default__TdPlayerStart.Sprite'*/;
		PlayerStartTextureResources = Default__TdPlayerStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__TdPlayerStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = Default__TdPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerStart.CollisionCylinder'*/;
		GoodSprite = Default__TdPlayerStart_Sprite/*Ref SpriteComponent'Default__TdPlayerStart.Sprite'*/;
		BadSprite = Default__TdPlayerStart_Sprite2/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPlayerStart_Sprite/*Ref SpriteComponent'Default__TdPlayerStart.Sprite'*/,
			Default__TdPlayerStart_Sprite2/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/,
			Default__TdPlayerStart_Arrow/*Ref ArrowComponent'Default__TdPlayerStart.Arrow'*/,
			Default__TdPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerStart.CollisionCylinder'*/,
			Default__TdPlayerStart_PathRenderer/*Ref PathRenderingComponent'Default__TdPlayerStart.PathRenderer'*/,
			Default__TdPlayerStart_SpawnRadiusSphere/*Ref DrawSphereComponent'Default__TdPlayerStart.SpawnRadiusSphere'*/,
		};
		CollisionComponent = Default__TdPlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__TdPlayerStart.CollisionCylinder'*/;
	}
}
}
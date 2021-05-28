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
		// Object Offset:0x00631808
		Radius = 300.0f;
		SphereRenderComponent = new DrawSphereComponent
		{
			// Object Offset:0x0067485E
			SphereRadius = 300.0f,
		}/* Reference: DrawSphereComponent'Default__TdPlayerStart.SpawnRadiusSphere' */;
		GenericSprite = new SpriteComponent
		{
			// Object Offset:0x00674792
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdPlayerStart.Sprite' */;
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdPlayerStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdPlayerStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x00674812
			CollisionHeight = 94.0f,
		}/* Reference: CylinderComponent'Default__TdPlayerStart.CollisionCylinder' */;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x00674792
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdPlayerStart.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x00674792
				Sprite = LoadAsset<Texture2D>("TdEditorResources.GenericSpawnIcon")/*Ref Texture2D'TdEditorResources.GenericSpawnIcon'*/,
				Scale = 0.330f,
			}/* Reference: SpriteComponent'Default__TdPlayerStart.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdPlayerStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdPlayerStart.Arrow")/*Ref ArrowComponent'Default__TdPlayerStart.Arrow'*/,
			//Components[3]=
			new CylinderComponent
			{
				// Object Offset:0x00674812
				CollisionHeight = 94.0f,
			}/* Reference: CylinderComponent'Default__TdPlayerStart.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__TdPlayerStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdPlayerStart.PathRenderer'*/,
			//Components[5]=
			new DrawSphereComponent
			{
				// Object Offset:0x0067485E
				SphereRadius = 300.0f,
			}/* Reference: DrawSphereComponent'Default__TdPlayerStart.SpawnRadiusSphere' */,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x00674812
			CollisionHeight = 94.0f,
		}/* Reference: CylinderComponent'Default__TdPlayerStart.CollisionCylinder' */;
	}
}
}
namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdTeamPlayerStart : TdPlayerStart/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*()*/ bool CopSpawn;
	public/*()*/ bool RobberSpawn;
	public int TeamNumber;
	public /*protected export editinline */SpriteComponent CopSprite;
	public /*protected export editinline */SpriteComponent RunnerSprite;
	
	public override /*function */void PreBeginPlay()
	{
	
	}
	
	public TdTeamPlayerStart()
	{
		// Object Offset:0x006749E4
		CopSpawn = true;
		RobberSpawn = true;
		TeamNumber = 2;
		CopSprite = new SpriteComponent
		{
			// Object Offset:0x02E526A1
			Sprite = LoadAsset<Texture2D>("TdEditorResources.CopSpawnIcon")/*Ref Texture2D'TdEditorResources.CopSpawnIcon'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.CopSpawn' */;
		RunnerSprite = new SpriteComponent
		{
			// Object Offset:0x02E52745
			Sprite = LoadAsset<Texture2D>("TdEditorResources.RunnerSpawnIcon")/*Ref Texture2D'TdEditorResources.RunnerSpawnIcon'*/,
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
			Scale = 0.330f,
		}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.RunnerSpawn' */;
		SphereRenderComponent = LoadAsset<DrawSphereComponent>("Default__TdTeamPlayerStart.SpawnRadiusSphere")/*Ref DrawSphereComponent'Default__TdTeamPlayerStart.SpawnRadiusSphere'*/;
		GenericSprite = LoadAsset<SpriteComponent>("Default__TdTeamPlayerStart.Sprite")/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/;
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__TdTeamPlayerStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__TdTeamPlayerStart.PlayerStartTextureResourcesObject'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdTeamPlayerStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdTeamPlayerStart.Sprite")/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdTeamPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdTeamPlayerStart.Sprite")/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdTeamPlayerStart.Sprite2")/*Ref SpriteComponent'Default__TdTeamPlayerStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdTeamPlayerStart.Arrow")/*Ref ArrowComponent'Default__TdTeamPlayerStart.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdTeamPlayerStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdTeamPlayerStart.PathRenderer")/*Ref PathRenderingComponent'Default__TdTeamPlayerStart.PathRenderer'*/,
			LoadAsset<DrawSphereComponent>("Default__TdTeamPlayerStart.SpawnRadiusSphere")/*Ref DrawSphereComponent'Default__TdTeamPlayerStart.SpawnRadiusSphere'*/,
			//Components[6]=
			new SpriteComponent
			{
				// Object Offset:0x02E526A1
				Sprite = LoadAsset<Texture2D>("TdEditorResources.CopSpawnIcon")/*Ref Texture2D'TdEditorResources.CopSpawnIcon'*/,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
				Scale = 0.330f,
			}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.CopSpawn' */,
			//Components[7]=
			new SpriteComponent
			{
				// Object Offset:0x02E52745
				Sprite = LoadAsset<Texture2D>("TdEditorResources.RunnerSpawnIcon")/*Ref Texture2D'TdEditorResources.RunnerSpawnIcon'*/,
				HiddenGame = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
				Scale = 0.330f,
			}/* Reference: SpriteComponent'Default__TdTeamPlayerStart.RunnerSpawn' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdTeamPlayerStart.CollisionCylinder")/*Ref CylinderComponent'Default__TdTeamPlayerStart.CollisionCylinder'*/;
	}
}
}
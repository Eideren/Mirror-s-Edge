namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PlayerStart : NavigationPoint/*
		native
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force,Collision)*/{
	public /*const export editinline */RequestedTextureResources PlayerStartTextureResources;
	public/*()*/ bool bEnabled;
	public/*()*/ bool bPrimaryStart;
	
	public override /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public PlayerStart()
	{
		// Object Offset:0x003A24DC
		PlayerStartTextureResources = LoadAsset<RequestedTextureResources>("Default__PlayerStart.PlayerStartTextureResourcesObject")/*Ref RequestedTextureResources'Default__PlayerStart.PlayerStartTextureResourcesObject'*/;
		bEnabled = true;
		bPrimaryStart = true;
		CylinderComponent = new CylinderComponent
		{
			// Object Offset:0x0046671F
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__PlayerStart.CollisionCylinder' */;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x004CFFBE
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Player")/*Ref Texture2D'EngineResources.S_Player'*/,
		}/* Reference: SpriteComponent'Default__PlayerStart.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__PlayerStart.Sprite2")/*Ref SpriteComponent'Default__PlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004CFFBE
				Sprite = LoadAsset<Texture2D>("EngineResources.S_Player")/*Ref Texture2D'EngineResources.S_Player'*/,
			}/* Reference: SpriteComponent'Default__PlayerStart.Sprite' */,
			LoadAsset<SpriteComponent>("Default__PlayerStart.Sprite2")/*Ref SpriteComponent'Default__PlayerStart.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__PlayerStart.Arrow")/*Ref ArrowComponent'Default__PlayerStart.Arrow'*/,
			new CylinderComponent
			{
				// Object Offset:0x0046671F
				CollisionHeight = 80.0f,
				CollisionRadius = 40.0f,
			}/* Reference: CylinderComponent'Default__PlayerStart.CollisionCylinder' */,
			LoadAsset<PathRenderingComponent>("Default__PlayerStart.PathRenderer")/*Ref PathRenderingComponent'Default__PlayerStart.PathRenderer'*/,
		};
		CollisionComponent = new CylinderComponent
		{
			// Object Offset:0x0046671F
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__PlayerStart.CollisionCylinder' */;
	}
}
}
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
		// stub
	}
	
	public PlayerStart()
	{
		var Default__PlayerStart_PlayerStartTextureResourcesObject = new RequestedTextureResources
		{
		}/* Reference: RequestedTextureResources'Default__PlayerStart.PlayerStartTextureResourcesObject' */;
		var Default__PlayerStart_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x0046671F
			CollisionHeight = 80.0f,
			CollisionRadius = 40.0f,
		}/* Reference: CylinderComponent'Default__PlayerStart.CollisionCylinder' */;
		var Default__PlayerStart_Sprite = new SpriteComponent
		{
			// Object Offset:0x004CFFBE
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Player")/*Ref Texture2D'EngineResources.S_Player'*/,
		}/* Reference: SpriteComponent'Default__PlayerStart.Sprite' */;
		var Default__PlayerStart_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__PlayerStart.Sprite2' */;
		var Default__PlayerStart_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__PlayerStart.Arrow' */;
		var Default__PlayerStart_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__PlayerStart.PathRenderer' */;
		// Object Offset:0x003A24DC
		PlayerStartTextureResources = Default__PlayerStart_PlayerStartTextureResourcesObject/*Ref RequestedTextureResources'Default__PlayerStart.PlayerStartTextureResourcesObject'*/;
		bEnabled = true;
		bPrimaryStart = true;
		CylinderComponent = Default__PlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__PlayerStart.CollisionCylinder'*/;
		GoodSprite = Default__PlayerStart_Sprite/*Ref SpriteComponent'Default__PlayerStart.Sprite'*/;
		BadSprite = Default__PlayerStart_Sprite2/*Ref SpriteComponent'Default__PlayerStart.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__PlayerStart_Sprite/*Ref SpriteComponent'Default__PlayerStart.Sprite'*/,
			Default__PlayerStart_Sprite2/*Ref SpriteComponent'Default__PlayerStart.Sprite2'*/,
			Default__PlayerStart_Arrow/*Ref ArrowComponent'Default__PlayerStart.Arrow'*/,
			Default__PlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__PlayerStart.CollisionCylinder'*/,
			Default__PlayerStart_PathRenderer/*Ref PathRenderingComponent'Default__PlayerStart.PathRenderer'*/,
		};
		CollisionComponent = Default__PlayerStart_CollisionCylinder/*Ref CylinderComponent'Default__PlayerStart.CollisionCylinder'*/;
	}
}
}
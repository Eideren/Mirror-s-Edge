namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_GrabHeave : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public float WallDistance;
	public float MinWallHeight;
	public float MaxWallHeight;
	public/*()*/ bool bDoAutoWallAdjustment;
	public /*const export editinline */SpriteComponent MoveIcon;
	
	public TdMoveNode_GrabHeave()
	{
		var Default__TdMoveNode_GrabHeave_Sprite_Grab = new SpriteComponent
		{
			// Object Offset:0x02E522E1
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GrabIcon")/*Ref Texture2D'TdEditorResources.GrabIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite_Grab' */;
		var Default__TdMoveNode_GrabHeave_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder' */;
		var Default__TdMoveNode_GrabHeave_Sprite = new SpriteComponent
		{
			// Object Offset:0x02E52295
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite' */;
		var Default__TdMoveNode_GrabHeave_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite2' */;
		var Default__TdMoveNode_GrabHeave_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_GrabHeave.Arrow' */;
		var Default__TdMoveNode_GrabHeave_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_GrabHeave.PathRenderer' */;
		// Object Offset:0x005F2C9C
		WallDistance = 140.0f;
		MinWallHeight = 175.0f;
		MaxWallHeight = 350.0f;
		bDoAutoWallAdjustment = true;
		MoveIcon = Default__TdMoveNode_GrabHeave_Sprite_Grab/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite_Grab'*/;
		MoveReachspecClass = ClassT<TdReachSpec_GrabHeave>()/*Ref Class'TdReachSpec_GrabHeave'*/;
		SpecialMoveCost = 1200;
		bNeedsVelocityToTrigger = false;
		CylinderComponent = Default__TdMoveNode_GrabHeave_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_GrabHeave_Sprite/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite'*/;
		BadSprite = Default__TdMoveNode_GrabHeave_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_GrabHeave_Sprite/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite'*/,
			Default__TdMoveNode_GrabHeave_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite2'*/,
			Default__TdMoveNode_GrabHeave_Arrow/*Ref ArrowComponent'Default__TdMoveNode_GrabHeave.Arrow'*/,
			Default__TdMoveNode_GrabHeave_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/,
			Default__TdMoveNode_GrabHeave_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_GrabHeave.PathRenderer'*/,
			Default__TdMoveNode_GrabHeave_Sprite_Grab/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite_Grab'*/,
		};
		CollisionComponent = Default__TdMoveNode_GrabHeave_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/;
	}
}
}
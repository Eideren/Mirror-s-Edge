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
		// Object Offset:0x005F2C9C
		WallDistance = 140.0f;
		MinWallHeight = 175.0f;
		MaxWallHeight = 350.0f;
		bDoAutoWallAdjustment = true;
		MoveIcon = new SpriteComponent
		{
			// Object Offset:0x02E522E1
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GrabIcon")/*Ref Texture2D'TdEditorResources.GrabIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite_Grab' */;
		MoveReachspecClass = ClassT<TdReachSpec_GrabHeave>()/*Ref Class'TdReachSpec_GrabHeave'*/;
		SpecialMoveCost = 1200;
		bNeedsVelocityToTrigger = false;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_GrabHeave.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x02E52295
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_GrabHeave.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x02E52295
				Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
			}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_GrabHeave.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_GrabHeave.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_GrabHeave.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_GrabHeave.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_GrabHeave.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_GrabHeave.PathRenderer'*/,
			//Components[5]=
			new SpriteComponent
			{
				// Object Offset:0x02E522E1
				Sprite = LoadAsset<Texture2D>("TdEditorResources.GrabIcon")/*Ref Texture2D'TdEditorResources.GrabIcon'*/,
				HiddenGame = true,
				HiddenEditor = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__TdMoveNode_GrabHeave.Sprite_Grab' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_GrabHeave.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_GrabHeave.CollisionCylinder'*/;
	}
}
}
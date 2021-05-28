namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_SpeedVault : TdMoveNode_Vault/*
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdMoveNode_SpeedVault()
	{
		// Object Offset:0x005F3B8B
		VaultOntoIcon = LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite_VaultOnto")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOnto'*/;
		VaultOverIcon = LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite_VaultOver")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOver'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_SpeedVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_SpeedVault.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_SpeedVault.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_SpeedVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_SpeedVault.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_SpeedVault.PathRenderer'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite_VaultOver")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOver'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_SpeedVault.Sprite_VaultOnto")/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOnto'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_SpeedVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/;
	}
}
}
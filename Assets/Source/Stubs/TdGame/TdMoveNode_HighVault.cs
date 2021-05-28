namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_HighVault : TdMoveNode_Vault/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdMoveNode_HighVault()
	{
		// Object Offset:0x005F362A
		VaultOntoIcon = LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite_VaultOnto")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOnto'*/;
		VaultOverIcon = LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite_VaultOver")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOver'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_HighVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/;
		GoodSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite'*/;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_HighVault.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_HighVault.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_HighVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_HighVault.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_HighVault.PathRenderer'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite_VaultOver")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOver'*/,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_HighVault.Sprite_VaultOnto")/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOnto'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_HighVault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/;
	}
}
}
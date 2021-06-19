namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_HighVault : TdMoveNode_Vault/*
		config(PathfindingCosts)
		notplaceable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdMoveNode_HighVault()
	{
		var Default__TdMoveNode_HighVault_Sprite_VaultOnto = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOnto' */;
		var Default__TdMoveNode_HighVault_Sprite_VaultOver = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOver' */;
		var Default__TdMoveNode_HighVault_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder' */;
		var Default__TdMoveNode_HighVault_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_HighVault.Sprite' */;
		var Default__TdMoveNode_HighVault_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_HighVault.Sprite2' */;
		var Default__TdMoveNode_HighVault_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_HighVault.Arrow' */;
		var Default__TdMoveNode_HighVault_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_HighVault.PathRenderer' */;
		// Object Offset:0x005F362A
		VaultOntoIcon = Default__TdMoveNode_HighVault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOnto'*/;
		VaultOverIcon = Default__TdMoveNode_HighVault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOver'*/;
		CylinderComponent = Default__TdMoveNode_HighVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_HighVault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite'*/;
		BadSprite = Default__TdMoveNode_HighVault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_HighVault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite'*/,
			Default__TdMoveNode_HighVault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite2'*/,
			Default__TdMoveNode_HighVault_Arrow/*Ref ArrowComponent'Default__TdMoveNode_HighVault.Arrow'*/,
			Default__TdMoveNode_HighVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/,
			Default__TdMoveNode_HighVault_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_HighVault.PathRenderer'*/,
			Default__TdMoveNode_HighVault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOver'*/,
			Default__TdMoveNode_HighVault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_HighVault.Sprite_VaultOnto'*/,
		};
		CollisionComponent = Default__TdMoveNode_HighVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_HighVault.CollisionCylinder'*/;
	}
}
}
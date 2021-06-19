namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_SpeedVault : TdMoveNode_Vault/*
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public TdMoveNode_SpeedVault()
	{
		var Default__TdMoveNode_SpeedVault_Sprite_VaultOnto = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOnto' */;
		var Default__TdMoveNode_SpeedVault_Sprite_VaultOver = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOver' */;
		var Default__TdMoveNode_SpeedVault_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder' */;
		var Default__TdMoveNode_SpeedVault_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite' */;
		var Default__TdMoveNode_SpeedVault_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite2' */;
		var Default__TdMoveNode_SpeedVault_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_SpeedVault.Arrow' */;
		var Default__TdMoveNode_SpeedVault_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_SpeedVault.PathRenderer' */;
		// Object Offset:0x005F3B8B
		VaultOntoIcon = Default__TdMoveNode_SpeedVault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOnto'*/;
		VaultOverIcon = Default__TdMoveNode_SpeedVault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOver'*/;
		CylinderComponent = Default__TdMoveNode_SpeedVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_SpeedVault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite'*/;
		BadSprite = Default__TdMoveNode_SpeedVault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_SpeedVault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite'*/,
			Default__TdMoveNode_SpeedVault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite2'*/,
			Default__TdMoveNode_SpeedVault_Arrow/*Ref ArrowComponent'Default__TdMoveNode_SpeedVault.Arrow'*/,
			Default__TdMoveNode_SpeedVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/,
			Default__TdMoveNode_SpeedVault_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_SpeedVault.PathRenderer'*/,
			Default__TdMoveNode_SpeedVault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOver'*/,
			Default__TdMoveNode_SpeedVault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_SpeedVault.Sprite_VaultOnto'*/,
		};
		CollisionComponent = Default__TdMoveNode_SpeedVault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_SpeedVault.CollisionCylinder'*/;
	}
}
}
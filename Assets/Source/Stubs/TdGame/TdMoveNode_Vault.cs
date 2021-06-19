namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMoveNode_Vault : TdMoveNode/*
		native
		config(PathfindingCosts)
		placeable
		hidecategories(Navigation,Lighting,LightColor,Force)*/{
	public/*(Settings)*/ float ForcedSpeed;
	public float VaultOverWallDistance_LowVault;
	public float VaultOntoWallDistance_LowVault;
	public float VaultOverWallDistance_HighVault;
	public float VaultOntoWallDistance_HighVault;
	public float MinWallHeight_LowVault;
	public float MaxWallHeight_LowVault;
	public float MinWallHeight_HighVault;
	public float MaxWallHeight_HighVault;
	public /*const export editinline */SpriteComponent VaultOntoIcon;
	public /*const export editinline */SpriteComponent VaultOverIcon;
	public /*config */int iHighVaultCost;
	public /*config */int iVaultOntoCost;
	
	public TdMoveNode_Vault()
	{
		var Default__TdMoveNode_Vault_Sprite_VaultOnto = new SpriteComponent
		{
			// Object Offset:0x005F3586
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SpeedVaultIcon")/*Ref Texture2D'TdEditorResources.SpeedVaultIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOnto' */;
		var Default__TdMoveNode_Vault_Sprite_VaultOver = new SpriteComponent
		{
			// Object Offset:0x005F34E2
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultOverIcon")/*Ref Texture2D'TdEditorResources.VaultOverIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOver' */;
		var Default__TdMoveNode_Vault_CollisionCylinder = new CylinderComponent
		{
		}/* Reference: CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder' */;
		var Default__TdMoveNode_Vault_Sprite = new SpriteComponent
		{
			// Object Offset:0x005F344E
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite' */;
		var Default__TdMoveNode_Vault_Sprite2 = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite2' */;
		var Default__TdMoveNode_Vault_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdMoveNode_Vault.Arrow' */;
		var Default__TdMoveNode_Vault_PathRenderer = new PathRenderingComponent
		{
		}/* Reference: PathRenderingComponent'Default__TdMoveNode_Vault.PathRenderer' */;
		// Object Offset:0x005F313B
		ForcedSpeed = 500.0f;
		VaultOverWallDistance_LowVault = 250.0f;
		VaultOntoWallDistance_LowVault = 180.0f;
		VaultOverWallDistance_HighVault = 245.0f;
		VaultOntoWallDistance_HighVault = 270.0f;
		MinWallHeight_LowVault = 75.0f;
		MaxWallHeight_LowVault = 144.0f;
		MinWallHeight_HighVault = 145.0f;
		MaxWallHeight_HighVault = 304.0f;
		VaultOntoIcon = Default__TdMoveNode_Vault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOnto'*/;
		VaultOverIcon = Default__TdMoveNode_Vault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOver'*/;
		iHighVaultCost = 1000;
		iVaultOntoCost = 400;
		MoveReachspecClass = ClassT<TdReachSpec_Vault>()/*Ref Class'TdReachSpec_Vault'*/;
		CylinderComponent = Default__TdMoveNode_Vault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/;
		GoodSprite = Default__TdMoveNode_Vault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite'*/;
		BadSprite = Default__TdMoveNode_Vault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMoveNode_Vault_Sprite/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite'*/,
			Default__TdMoveNode_Vault_Sprite2/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite2'*/,
			Default__TdMoveNode_Vault_Arrow/*Ref ArrowComponent'Default__TdMoveNode_Vault.Arrow'*/,
			Default__TdMoveNode_Vault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/,
			Default__TdMoveNode_Vault_PathRenderer/*Ref PathRenderingComponent'Default__TdMoveNode_Vault.PathRenderer'*/,
			Default__TdMoveNode_Vault_Sprite_VaultOver/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOver'*/,
			Default__TdMoveNode_Vault_Sprite_VaultOnto/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOnto'*/,
		};
		CollisionComponent = Default__TdMoveNode_Vault_CollisionCylinder/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/;
	}
}
}
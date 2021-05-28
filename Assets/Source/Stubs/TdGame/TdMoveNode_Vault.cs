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
		VaultOntoIcon = new SpriteComponent
		{
			// Object Offset:0x005F3586
			Sprite = LoadAsset<Texture2D>("TdEditorResources.SpeedVaultIcon")/*Ref Texture2D'TdEditorResources.SpeedVaultIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOnto' */;
		VaultOverIcon = new SpriteComponent
		{
			// Object Offset:0x005F34E2
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultOverIcon")/*Ref Texture2D'TdEditorResources.VaultOverIcon'*/,
			HiddenGame = true,
			HiddenEditor = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOver' */;
		iHighVaultCost = 1000;
		iVaultOntoCost = 400;
		MoveReachspecClass = ClassT<TdReachSpec_Vault>()/*Ref Class'TdReachSpec_Vault'*/;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_Vault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/;
		GoodSprite = new SpriteComponent
		{
			// Object Offset:0x005F344E
			Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
		}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite' */;
		BadSprite = LoadAsset<SpriteComponent>("Default__TdMoveNode_Vault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite2'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x005F344E
				Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultStartIcon")/*Ref Texture2D'TdEditorResources.VaultStartIcon'*/,
			}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite' */,
			LoadAsset<SpriteComponent>("Default__TdMoveNode_Vault.Sprite2")/*Ref SpriteComponent'Default__TdMoveNode_Vault.Sprite2'*/,
			LoadAsset<ArrowComponent>("Default__TdMoveNode_Vault.Arrow")/*Ref ArrowComponent'Default__TdMoveNode_Vault.Arrow'*/,
			LoadAsset<CylinderComponent>("Default__TdMoveNode_Vault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/,
			LoadAsset<PathRenderingComponent>("Default__TdMoveNode_Vault.PathRenderer")/*Ref PathRenderingComponent'Default__TdMoveNode_Vault.PathRenderer'*/,
			//Components[5]=
			new SpriteComponent
			{
				// Object Offset:0x005F34E2
				Sprite = LoadAsset<Texture2D>("TdEditorResources.VaultOverIcon")/*Ref Texture2D'TdEditorResources.VaultOverIcon'*/,
				HiddenGame = true,
				HiddenEditor = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOver' */,
			//Components[6]=
			new SpriteComponent
			{
				// Object Offset:0x005F3586
				Sprite = LoadAsset<Texture2D>("TdEditorResources.SpeedVaultIcon")/*Ref Texture2D'TdEditorResources.SpeedVaultIcon'*/,
				HiddenGame = true,
				HiddenEditor = true,
				AlwaysLoadOnClient = false,
				AlwaysLoadOnServer = false,
			}/* Reference: SpriteComponent'Default__TdMoveNode_Vault.Sprite_VaultOnto' */,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdMoveNode_Vault.CollisionCylinder")/*Ref CylinderComponent'Default__TdMoveNode_Vault.CollisionCylinder'*/;
	}
}
}
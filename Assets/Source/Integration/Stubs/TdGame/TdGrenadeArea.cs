namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGrenadeArea : Actor/*
		native
		placeable
		hidecategories(Navigation)*/{
	public/*()*/ float Radius;
	public/*()*/ float Height;
	public Object.Color AreaColor;
	public/*()*/ bool bUsedAsTrigger;
	
	public TdGrenadeArea()
	{
		var Default__TdGrenadeArea_Sprite = new SpriteComponent
		{
			// Object Offset:0x005449AE
			Sprite = LoadAsset<Texture2D>("TdEditorResources.GrenadeIcon")/*Ref Texture2D'TdEditorResources.GrenadeIcon'*/,
			HiddenGame = true,
		}/* Reference: SpriteComponent'Default__TdGrenadeArea.Sprite' */;
		var Default__TdGrenadeArea_Renderer = new TdGrenadeTargetAreaRenderingComponent
		{
			// Object Offset:0x005449FE
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: TdGrenadeTargetAreaRenderingComponent'Default__TdGrenadeArea.Renderer' */;
		// Object Offset:0x00544883
		Radius = 200.0f;
		Height = 200.0f;
		AreaColor = new Color
		{
			R=0,
			G=0,
			B=255,
			A=0
		};
		bUsedAsTrigger = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdGrenadeArea_Sprite/*Ref SpriteComponent'Default__TdGrenadeArea.Sprite'*/,
			Default__TdGrenadeArea_Renderer/*Ref TdGrenadeTargetAreaRenderingComponent'Default__TdGrenadeArea.Renderer'*/,
		};
	}
}
}
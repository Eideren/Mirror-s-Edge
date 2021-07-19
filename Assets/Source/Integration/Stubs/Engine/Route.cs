namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Route : Info/*
		native
		placeable
		hidecategories(Navigation,Movement,Collision)*/{
	public enum ERouteFillAction 
	{
		RFA_Overwrite,
		RFA_Add,
		RFA_Remove,
		RFA_Clear,
		RFA_MAX
	};
	
	public enum ERouteDirection 
	{
		ERD_Forward,
		ERD_Reverse,
		ERD_MAX
	};
	
	public enum ERouteType 
	{
		ERT_Linear,
		ERT_Loop,
		ERT_Circle,
		ERT_MAX
	};
	
	[Category] public Route.ERouteType RouteType;
	[Category] public array<Actor.NavReference> NavList;
	
	public Route()
	{
		var Default__Route_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D0572
			Sprite = LoadAsset<Texture2D>("EngineResources.S_Route")/*Ref Texture2D'EngineResources.S_Route'*/,
		}/* Reference: SpriteComponent'Default__Route.Sprite' */;
		var Default__Route_RouteRenderer = new RouteRenderingComponent
		{
			// Object Offset:0x004CE5F6
			HiddenGame = true,
			AlwaysLoadOnClient = false,
			AlwaysLoadOnServer = false,
		}/* Reference: RouteRenderingComponent'Default__Route.RouteRenderer' */;
		// Object Offset:0x003B06E9
		bStatic = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__Route_Sprite/*Ref SpriteComponent'Default__Route.Sprite'*/,
			Default__Route_Sprite/*Ref SpriteComponent'Default__Route.Sprite'*/,
			Default__Route_RouteRenderer/*Ref RouteRenderingComponent'Default__Route.RouteRenderer'*/,
		};
	}
}
}